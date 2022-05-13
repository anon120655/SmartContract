using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Interfaces;
using SmartContract.Infrastructure.Interfaces.ContractTypeBureau.TMaster;
using SmartContract.Infrastructure.Resources.ContractTypeBureau;
using SmartContract.Infrastructure.Resources.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Enum;
using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Infrastructure.Wrapper;
using SmartContract.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartContract.Infrastructure.Data.EntityFramework;
using Microsoft.AspNetCore.Http;
using SmartContract.Infrastructure.Resources.ContractTypeBureau.Information;

namespace SmartContract.Infrastructure.Repositorys.ContractTypeBureau.TMaster
{
    public class T02BuRepo : IT02BuRepo
    {
        private IRepositoryWrapper _repo;
        private readonly IRepositoryBase _db;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly AppSettings _mySet;

        public T02BuRepo(IRepositoryWrapper repo, IRepositoryBase db, IMapper mapper, IWebHostEnvironment env, IOptions<AppSettings> settings)
        {
            _repo = repo;
            _db = db;
            _env = env;
            _mapper = mapper;
            _mySet = settings.Value;
        }

        public async Task<TAllMasterVendorView> InitialData(TAllMasterVendorView indata)
        {
            var departmentCode = _repo.UserService.GetDepartmentCode();
            indata.CTVendor.GetLookUp = new LookUpResource()
            {
                SubDomainServer = _mySet.SubDomainServer,
                BankInfos = _repo.MasterData.BankInfos(),
                UserSmctSigner = await _repo.MasterData.UserSmctSigner(),
                NhsoSigner = await _repo.MasterData.NhsoSigner(departmentCode),
                VNhsoEmployeeAll = await _repo.MasterData.VNhsoEmployeeAll(departmentCode: departmentCode)
            };

            string idSmctMaster = indata.ParameterCondition.IdSmctMaster;

            //ข้อมูลฝ่ายคู่สัญญา
            var smctMasters = await _repo.Context.SmctMasters.Include(x => x.IdRegisterNhsoNavigation).Where(x => x.IdSmctMaster == idSmctMaster && x.Used).FirstOrDefaultAsync();
            indata = await _repo.ContractShare.ViewInfoPartnersOfContract(indata, smctMasters.IdRegisterNhsoNavigation.VendorId);

            return indata;
        }

        public async Task<TAllMasterVendorView> GetView(ParameterCondition indata)
        {
            TAllMasterVendorView response = new TAllMasterVendorView()
            {
                ParameterCondition = indata
            };

            await this.InitialData(response);

            //ข้อมูลนิติกรรมสัญญา
            response = await _repo.ContractShareNhso.ViewInfoContract(response);

            //ข้อมูลฝ่าย สปสช. (ผู้มีอำนาจลงนาม)
            response = await _repo.ContractShareNhso.ViewMasterSignerNhso(response);

            //ข้อมูลผู้ลงนาม
            response = await _repo.ContractShare.ViewMasterSigners(response);

            if (indata.IsSentMail || indata.Station != ContractStationStatusAll.S5Signing2 || indata.IsPDF)
            {
                //ข้อมูลรายละเอียดนิติกรรมสัญญา
                response = await this.ViewContractDetail(response);
            }

            if (indata.Station == ContractStationStatusAll.S6ContractNumber)
            {
                response = await _repo.ContractShareNhso.ViewCheckList(response);
            }

            //รายละเอียดไฟล์แนบ
            response = await _repo.ContractShare.ViewMasterFiles(response);

            response = await _repo.ContractShare.ViewContractStation(response);

            return response;
        }

        private async Task<TAllMasterVendorView> ViewContractDetail(TAllMasterVendorView indata)
        {
            var _IdContract = indata.ParameterCondition.IdContract;
            var contractDetail = await _repo.Context.ContractDetail02s.Where(x => x.IdContract == _IdContract && x.Used).FirstOrDefaultAsync();
            if (contractDetail != null)
            {
                indata.InfoConDetail.ContractDetail02 = _mapper.Map<ContractDetail02DTO>(contractDetail);

                if (contractDetail.P21 != null
                   || contractDetail.P22 != null
                   || contractDetail.P23 != null
                   || contractDetail.P24 != null
                   || contractDetail.P25 != null)
                {
                    indata.InfoConDetail.ContractDetail02.IsP21_25 = true;
                }

                if (contractDetail.P34 != null
                    || contractDetail.P35 != null
                    || contractDetail.P36 != null
                    || contractDetail.P37 != null
                    || contractDetail.P38 != null)
                {
                    indata.InfoConDetail.ContractDetail02.IsP34_28 = true;
                }

                indata.InfoConDetail.ContractDetail02.IsP47 = contractDetail.P47 == "1";
                indata.InfoConDetail.ContractDetail02.IsP50 = contractDetail.P50 == "1";
                indata.InfoConDetail.ContractDetail02.IsP53 = contractDetail.P53 == "1";
                indata.InfoConDetail.ContractDetail02.IsP56 = contractDetail.P56 == "1";
                indata.InfoConDetail.ContractDetail02.IsP60 = contractDetail.P60 == "1";
                indata.InfoConDetail.ContractDetail02.IsP63 = contractDetail.P63 == "1";
            }


            return indata;
        }

        public void ValidateContract(TAllMasterVendorView indata)
        {
            int btnSubmit = int.Parse(indata.BtnSubmit);

            if (string.IsNullOrEmpty(indata.InfoContract.StartDateStr))
                throw new Exception("ระบุ วันที่เริ่มต้นสัญญา");
            if (string.IsNullOrEmpty(indata.InfoContract.EndDateStr))
                throw new Exception("ระบุ วันที่สิ้นสุดสัญญา");

            if (String.IsNullOrEmpty(indata.InfoContractNhso.EmpId))
                throw new Exception("ระบุ ผู้มีอำนาจลงนาม ฝ่าย สปสช.");
            if (String.IsNullOrEmpty(indata.InfoContractNhso.NhsoContractId))
                throw new Exception("ระบุ คำสั่งสำนักงานหลักประกันสุขภาพแห่งชาติ ที่");
            if (String.IsNullOrEmpty(indata.InfoContractNhso.NhsoContractDateStr))
                throw new Exception("ระบุ ลงวันที่ (คำสั่งสำนักงานหลักประกันสุขภาพแห่งชาติ)");

            //รายละเอียดนิติกรรมสัญญา
            var indataDetail = indata.InfoConDetail.ContractDetail02;


            //ข้อมูลผู้ลงนาม
            if (String.IsNullOrEmpty(indata.InfoSignerPartnersOfContract.NhsoWitnessUser))
                throw new Exception("ระบุ พยาน (ฝ่ายสำนักงาน)");
            if (indata.InfoSignerPartnersOfContract.FootNotesNhso == null || indata.InfoSignerPartnersOfContract.FootNotesNhso.Count == 0)
            {
                throw new Exception("ระบุ Foot Note (ฝ่ายสำนักงาน)");
            }
            else
            {
                foreach (var item in indata.InfoSignerPartnersOfContract.FootNotesNhso)
                {
                    if (String.IsNullOrEmpty(item.EmpId))
                        throw new Exception("ระบุ Foot Note (ฝ่ายสำนักงาน)ไม่ครบถ้วน");
                }
            }
        }

        public async Task<TAllMasterVendorView> UpdateAsyncContract(TAllMasterVendorView indata)
        {
            using (var _transaction = _repo.BeginTransaction())
            {
                int btnSubmit = int.Parse(indata.BtnSubmit);
                String idSmctMaster = indata.ParameterCondition.IdSmctMaster;
                String idUserSmct = _repo.UserService.GetIdUserSmct();

                // ข้อมูลนิติกรรมสัญญา                   
                await _repo.ContractShareNhso.UpdateInfoContract(indata);

                //ข้อมูลฝ่าย สปสช. (ผู้มีอำนาจลงนาม) ,ข้อมูลผู้ลงนาม
                await _repo.ContractShareNhso.UpdateMasterSigners(indata);

                //ข้อมูลรายละเอียดนิติกรรมสัญญา
                await this.UpdateContractDetail(indata);

                //ไฟล์แนบท้าย(ร่าง)นิติกรรม(สำนัก/กองทุนย่อย/เขต)
                await _repo.ContractShareNhso.UpdateReqAppAttachDraftContract(indata, $"T{indata.ParameterCondition.ContractTypeId}");

                //UPDATE STATION
                if (btnSubmit == (int)ButtonState.Forward)
                {
                    await _repo.ContractShareNhso.UpdateStatusContract(indata);
                }
                if (btnSubmit == (int)ButtonState.T1_EDIT)
                {
                    await _repo.ContractShareNhso.UpdateRequestBinding(indata);
                }

                //ผู้บันทึกล่าสสุด
                await _repo.ContractShareNhso.UpdateContractEditLast(indata);

                _transaction.Commit();

                return indata;
            }
        }

        private async Task UpdateContractDetail(TAllMasterVendorView indata)
        {
            String idSmctMaster = indata.ParameterCondition.IdSmctMaster;
            String idUserSmct = _repo.UserService.GetIdUserSmct();

            var _Contract = await _repo.Context.Contracts.Where(x => x.IdSmctMaster == idSmctMaster && x.Used).FirstOrDefaultAsync();
            if (_Contract != null)
            {
                var _ContractDetail = indata.InfoConDetail.ContractDetail02;
                var contractDetail = await _repo.Context.ContractDetail02s.Where(x => x.IdContract == _Contract.IdContract && x.Used).FirstOrDefaultAsync();
                if (contractDetail != null)
                {
                    _mapper.Map(_ContractDetail, contractDetail);
                    contractDetail.P47 = _ContractDetail.IsP47 ? "1" : "2";
                    contractDetail.P50 = _ContractDetail.IsP50 ? "1" : "2";
                    contractDetail.P53 = _ContractDetail.IsP53 ? "1" : "2";
                    contractDetail.P56 = _ContractDetail.IsP56 ? "1" : "2";
                    contractDetail.P60 = _ContractDetail.IsP60 ? "1" : "2";
                    contractDetail.P63 = _ContractDetail.IsP63 ? "1" : "2";

                    contractDetail.EditUser = idUserSmct;
                    contractDetail.EditDate = DateTime.Now;
                    _db.Update(contractDetail);
                    await _db.SaveAsync();
                }
                else
                {
                    contractDetail = _mapper.Map<ContractDetail02>(_ContractDetail);

                    contractDetail.P47 = _ContractDetail.IsP47 ? "1" : "2";
                    contractDetail.P50 = _ContractDetail.IsP50 ? "1" : "2";
                    contractDetail.P53 = _ContractDetail.IsP53 ? "1" : "2";
                    contractDetail.P56 = _ContractDetail.IsP56 ? "1" : "2";
                    contractDetail.P60 = _ContractDetail.IsP60 ? "1" : "2";
                    contractDetail.P63 = _ContractDetail.IsP63 ? "1" : "2";

                    contractDetail.IdContract = _Contract.IdContract;
                    contractDetail.CreateUser = idUserSmct;
                    contractDetail.CreateDate = DateTime.Now;
                    contractDetail.EditUser = idUserSmct;
                    contractDetail.EditDate = DateTime.Now;
                    contractDetail.Used = true;
                    await _db.InsterAsync(contractDetail);
                    await _db.SaveAsync();
                }
            }
        }


    }
}
