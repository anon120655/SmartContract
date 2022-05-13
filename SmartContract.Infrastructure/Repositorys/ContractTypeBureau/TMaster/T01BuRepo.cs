using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Interfaces;
using SmartContract.Infrastructure.Interfaces.ContractTypeBureau.TMaster;
using SmartContract.Infrastructure.Resources.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Enum;
using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Infrastructure.Wrapper;
using SmartContract.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;
using SmartContract.Infrastructure.Data.EntityFramework;

namespace SmartContract.Infrastructure.Repositorys.ContractTypeBureau.TMaster
{
    public class T01BuRepo : IT01BuRepo
    {
        private IRepositoryWrapper _repo;
        private readonly IRepositoryBase _db;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly AppSettings _mySet;

        public T01BuRepo(IRepositoryWrapper repo, IRepositoryBase db, IMapper mapper, IWebHostEnvironment env, IOptions<AppSettings> settings)
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
                //ข้อมูลหลักประกันสัญญา
                response = await _repo.ContractShare.ViewGuaranteeContract(response);

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
            var contractDetail = await _repo.Context.ContractDetail01s.Where(x => x.IdContract == _IdContract && x.Used).FirstOrDefaultAsync();
            if (contractDetail != null)
            {
                indata.InfoConDetail.ContractDetail01 = _mapper.Map<ContractDetail01DTO>(contractDetail);
                indata.InfoConDetail.ContractDetail01.IsP37 = contractDetail.P37 == "1";
                indata.InfoConDetail.ContractDetail01.IsP40 = contractDetail.P40 == "1";
                indata.InfoConDetail.ContractDetail01.IsP43 = contractDetail.P43 == "1";
                indata.InfoConDetail.ContractDetail01.IsP46 = contractDetail.P46 == "1";
                indata.InfoConDetail.ContractDetail01.IsP50 = contractDetail.P50 == "1";
                indata.InfoConDetail.ContractDetail01.IsP53 = contractDetail.P53 == "1";
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

            //ข้อมูลหลักประกันสัญญา
            _repo.ContractShare.ValidateGuaranteeContract(indata);

            //รายละเอียดนิติกรรมสัญญา
            var indataDetail = indata.InfoConDetail.ContractDetail01;
            if (String.IsNullOrEmpty(indataDetail.P9) && !String.IsNullOrEmpty(indataDetail.P10) || !String.IsNullOrEmpty(indataDetail.P9) && String.IsNullOrEmpty(indataDetail.P10))
                throw new Exception("ระบุ 2.5 ผนวก 5 ไม่ครบถ้วน");
            if (String.IsNullOrEmpty(indataDetail.P11) && !String.IsNullOrEmpty(indataDetail.P12) || !String.IsNullOrEmpty(indataDetail.P11) && String.IsNullOrEmpty(indataDetail.P12))
                throw new Exception("ระบุ 2.5 ผนวก 5 ไม่ครบถ้วน");
            if (String.IsNullOrEmpty(indataDetail.P13) && !String.IsNullOrEmpty(indataDetail.P14) || !String.IsNullOrEmpty(indataDetail.P13) && String.IsNullOrEmpty(indataDetail.P14))
                throw new Exception("ระบุ 2.5 ผนวก 5 ไม่ครบถ้วน");
            if (String.IsNullOrEmpty(indataDetail.P15) && !String.IsNullOrEmpty(indataDetail.P16) || !String.IsNullOrEmpty(indataDetail.P15) && String.IsNullOrEmpty(indataDetail.P16))
                throw new Exception("ระบุ 2.5 ผนวก 5 ไม่ครบถ้วน");
            if (String.IsNullOrEmpty(indataDetail.P17) && !String.IsNullOrEmpty(indataDetail.P18) || !String.IsNullOrEmpty(indataDetail.P17) && String.IsNullOrEmpty(indataDetail.P18))
                throw new Exception("ระบุ 2.5 ผนวก 5 ไม่ครบถ้วน");

            if (indataDetail.P19 == "1")
            {
                if (String.IsNullOrEmpty(indataDetail.P20))
                    throw new Exception("ระบุ 3.1 หน่วยบริการที่รับการส่งต่อคือ");
                //if (String.IsNullOrEmpty(indataDetail.P25))
                //    throw new Exception("ระบุ 3.1 หน่วยบริการที่ร่วมให้บริการคือ");
            }
            if (indataDetail.P19 == "3")
            {
                if (String.IsNullOrEmpty(indataDetail.P26))
                    throw new Exception("ระบุ 3.1 หน่วยบริการที่รับการส่งต่อ (ทั่วไป,เฉพาะทาง)");
                if (indataDetail.P26 == "2")
                    if (String.IsNullOrEmpty(indataDetail.P27))
                        throw new Exception("ระบุ 3.1 หน่วยบริการที่รับการส่งต่อ เฉพาะทาง");
            }
            if (indataDetail.P19 == "4")
            {
                if (String.IsNullOrEmpty(indataDetail.P32))
                    throw new Exception("ระบุ 3.1 หน่วยที่ร่วมบริการ");
            }

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

                //ข้อมูลนิติกรรมสัญญา                   
                await _repo.ContractShareNhso.UpdateInfoContract(indata);

                //ข้อมูลฝ่าย สปสช. (ผู้มีอำนาจลงนาม) ,ข้อมูลผู้ลงนาม
                await _repo.ContractShareNhso.UpdateMasterSigners(indata);

                //กรณีทำหลักประกันสัญญา
                await _repo.ContractShare.UpdateGuaranteeContract(indata);

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
                var _ContractDetail = indata.InfoConDetail.ContractDetail01;
                var contractDetail = await _repo.Context.ContractDetail01s.Where(x => x.IdContract == _Contract.IdContract && x.Used).FirstOrDefaultAsync();
                if (contractDetail != null)
                {
                    _mapper.Map(_ContractDetail, contractDetail);

                    contractDetail.P37 = _ContractDetail.IsP37 ? "1" : "2";
                    contractDetail.P40 = _ContractDetail.IsP40 ? "1" : "2";
                    contractDetail.P43 = _ContractDetail.IsP43 ? "1" : "2";
                    contractDetail.P46 = _ContractDetail.IsP46 ? "1" : "2";
                    contractDetail.P50 = _ContractDetail.IsP50 ? "1" : "2";
                    contractDetail.P53 = _ContractDetail.IsP53 ? "1" : "2";

                    contractDetail.EditUser = idUserSmct;
                    contractDetail.EditDate = DateTime.Now;
                    _db.Update(contractDetail);
                    await _db.SaveAsync();
                }
                else
                {
                    contractDetail = _mapper.Map<ContractDetail01>(_ContractDetail);

                    contractDetail.P37 = _ContractDetail.IsP37 ? "1" : "2";
                    contractDetail.P40 = _ContractDetail.IsP40 ? "1" : "2";
                    contractDetail.P43 = _ContractDetail.IsP43 ? "1" : "2";
                    contractDetail.P46 = _ContractDetail.IsP46 ? "1" : "2";
                    contractDetail.P50 = _ContractDetail.IsP50 ? "1" : "2";
                    contractDetail.P53 = _ContractDetail.IsP53 ? "1" : "2";

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
