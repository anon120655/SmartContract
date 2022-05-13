﻿using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Utils;
using SmartContract.Infrastructure.Data.EntityFramework;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Interfaces;
using SmartContract.Infrastructure.Interfaces.ContractTypeVendor.TMaster;
using SmartContract.Infrastructure.Resources.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.ContractTypeVendor.Information;
using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Enum;
using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Infrastructure.Wrapper;
using SmartContract.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using static SmartContract.Infrastructure.Resources.ContractTypeVendor.Information.InfoSignerPartnersOfContract;

namespace SmartContract.Infrastructure.Repositorys.ContractTypeVendor.TMaster
{
    public class T14Repo : IT14Repo
    {
        private IRepositoryWrapper _repo;
        private readonly IRepositoryBase _db;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly AppSettings _mySet;

        public T14Repo(IRepositoryWrapper repo, IRepositoryBase db, IMapper mapper, IWebHostEnvironment env, IOptions<AppSettings> settings)
        {
            _repo = repo;
            _db = db;
            _env = env;
            _mapper = mapper;
            _mySet = settings.Value;
        }

        public IEnumerable<ContractStationDTO> GetList(SearchOptionCTV Condition = null)
        {
            var departmentCode = _repo.UserService.GetDepartmentCode();

            var response = new List<ContractStationDTO>();

            var contractTypesUse = _repo.Context.ContractTypes.Where(x => x.Used && x.GpType == "G" || x.GpType == "GP").Select(x => x.ContractTypeId).ToList();

            var contractStations = _repo.Context.ContractStations.Where(x => x.Used && x.ContractStyleCode == "S43" && x.DepartmentCode == departmentCode && contractTypesUse.Contains(x.ContractTypeId)).OrderByDescending(x => x.EditDate);

            if (Condition != null)
            {
                if (!String.IsNullOrEmpty(Condition.Station))
                    contractStations = contractStations.Where(x => x.StationStatusCurr == Condition.Station).OrderByDescending(x => x.EditDate);
            }

            response = _mapper.Map<List<ContractStationDTO>>(contractStations);

            return response;
        }

        public async Task<TAllMasterVendorView> InitialData(TAllMasterVendorView indata)
        {
            var vendorId = _repo.UserService.GetVendorId();

            indata.CTVendor.GetLookUp = new LookUpResource()
            {
                SubDomainServer = _mySet.SubDomainServer,
                ContractTypes = await _repo.MasterData.ContractTypes(),
                BankInfos = _repo.MasterData.BankInfos(),
                UserSmctSigner = await _repo.MasterData.UserSmctSigner(),
                Coordinators = await _repo.MasterData.Coordinators(),
                NhsoSigner = await _repo.MasterData.NhsoSigner()
            };

            //ข้อมูลนิติกรรมสัญญา
            if (indata.ParameterCondition.IdSmctMaster == null)
            {
                indata = await _repo.ContractShare.ViewInfoContract(indata);
            }
            indata = await _repo.ContractShare.ViewInfoContract(indata);

            //ข้อมูลฝ่ายคู่สัญญา
            indata = await _repo.ContractShare.ViewInfoPartnersOfContract(indata, vendorId);

            return indata;
        }

        public async Task<TAllMasterVendorView> GetView(ParameterCondition indata)
        {
            TAllMasterVendorView response = new TAllMasterVendorView()
            {
                ParameterCondition = indata
            };
            //ข้อมูลนิติกรรมสัญญา
            response = await _repo.ContractShare.ViewInfoContract(response);

            //หนังสือขออนุมัติ
            response = await _repo.ContractShare.ViewRequestForApproval(response);

            //ข้อมูลผู้ลงนาม
            response = await _repo.ContractShare.ViewMasterSigners(response);

            if (indata.IsPDF)
            {
                //เงื่อนไขการจ่ายเงิน
                response = await _repo.ContractShareNhso.ViewConditionPayment(response);
            }

            //รายละเอียดไฟล์แนบ
            response = await _repo.ContractShare.ViewMasterFiles(response);

            response = await _repo.ContractShare.ViewContractStation(response);

            await this.InitialData(response);

            return response;
        }

        public void Validate(TAllMasterVendorView indata)
        {
            int btnSubmit = int.Parse(indata.BtnSubmit);
            //if (btnSubmit == (int)ButtonState.Forward)
            //{
            // ข้อมูลขออนุมัติดำเนินการ
            if (string.IsNullOrEmpty(indata.InfoRequestForApproval.ContractName))
                throw new Exception("ระบุชื่อโครงการ");
            if (string.IsNullOrEmpty(indata.InfoRequestForApproval.Reason))
                throw new Exception("ระบุเหตุผลความจำเป็น");
            if (string.IsNullOrEmpty(indata.InfoRequestForApproval.CoordinatorUserSelect))
                throw new Exception("ระบุผู้ประสานงาน");

            //}

        }

        public async Task<TAllMasterVendorView> CreateAsync(TAllMasterVendorView indata)
        {
            using (var _transaction = _repo.BeginTransaction())
            {
                int btnSubmit = int.Parse(indata.BtnSubmit);
                String _Status = UserSmctStatus.WaitUse;
                int budgetYear = new ThaiBuddhistCalendar().GetYear(DateTime.Now);
                String vendorId = _repo.UserService.GetVendorId();
                String vendorName = _repo.UserService.GetVendorName();
                String idUserSmct = _repo.UserService.GetIdUserSmct();
                String departmentCode = _repo.UserService.GetDepartmentCode();
                //ปีงบประมาณใหม่
                if (DateTime.Now.Month >= 10 && DateTime.Now.Day >= 1) budgetYear++;

                var userSmcts = _repo.Context.UserSmcts.Where(x => x.Used);
                var userSmctVendors = await _repo.Context.UserSmctVendors.FirstOrDefaultAsync(x => x.IdUserSmct == idUserSmct);

                var _SigningType = SecurityRepo.Decrypt(indata.ParameterCondition.SigningTypeEn);
                var _StyleCode = indata.ParameterCondition.Style;
                var contractStyles = await _repo.Context.ContractStyles.FirstOrDefaultAsync(x => x.ContractStyleCode == _StyleCode);
                var lkDepartments = await _repo.Context.LkDepartments.FirstOrDefaultAsync(x => x.Dcode == departmentCode);
                var contractTypes = await _repo.Context.ContractTypes.FirstOrDefaultAsync(x => x.IdContractStyle == contractStyles.IdContractStyle && x.ContractTypeId == indata.ParameterCondition.ContractTypeId);

                indata.ParameterCondition.IdUserSmctCurr = idUserSmct;
                indata.ParameterCondition.ContractTypeId = contractTypes.ContractTypeId;
                indata.ParameterCondition.SigningType = _SigningType;
                indata.ParameterCondition.ContractStyleCode = contractStyles.ContractStyleCode;
                indata.ParameterCondition.ContractStyleFullName = contractStyles.ContractStyleFullName;
                indata.ParameterCondition.IdRegisterNhso = userSmctVendors.IdRegisterNhso;
                indata.ParameterCondition.DepartmentCode = departmentCode;
                indata.ParameterCondition.Dname = lkDepartments.Dname;
                indata.ParameterCondition.BudgetYear = budgetYear.ToString();
                indata.ParameterCondition.Status = _Status;

                //SMCT_MASTER
                var smctMaster = await _repo.ContractShare.InsertSmctMaster(indata);
                indata.ParameterCondition.IdSmctMaster = smctMaster.IdSmctMaster;
                indata.ParameterCondition.RefId = smctMaster.RefId;
                indata.ParameterCondition.RefDate = smctMaster.RefDate;

                //ข้อมูลฝ่ายคู่สัญญา,ข้อมูลผู้ลงนามฝ่ายคู่สัญญา
                var smctMasterSigner = await _repo.ContractShare.InsertMasterSigners(indata);

                //ข้อมูลไฟล์แนบท้าย          
                var smctMasterFile = await _repo.ContractShare.InsertInfoAttachDraftContract(indata, $"T{contractTypes.ContractTypeId}");

                //หนังสือขออนุมัติ
                var approvalReqStation = await _repo.ContractShare.InsertApprovalReqStation(indata);

                //ContractStation
                indata.ParameterCondition.IdContractType = contractTypes.IdContractType;
                var contractStation = await _repo.ContractShare.InsertContractStation(indata);

                await _transaction.CommitAsync();

                indata.ContractStation = _mapper.Map<ContractStationDTO>(contractStation);

                return indata;
            }
        }

        public async Task<TAllMasterVendorView> UpdateAsync(TAllMasterVendorView indata)
        {
            using (var _transaction = _repo.BeginTransaction())
            {
                int btnSubmit = int.Parse(indata.BtnSubmit);
                String idSmctMaster = indata.ParameterCondition.IdSmctMaster;
                int budgetYear = new ThaiBuddhistCalendar().GetYear(DateTime.Now);
                String vendorId = _repo.UserService.GetVendorId();
                String vendorName = _repo.UserService.GetVendorName();
                String idUserSmct = _repo.UserService.GetIdUserSmct();
                String departmentCode = _repo.UserService.GetDepartmentCode();
                //ปีงบประมาณใหม่
                if (DateTime.Now.Month >= 10 && DateTime.Now.Day >= 1) budgetYear++;

                var userSmcts = _repo.Context.UserSmcts.Where(x => x.Used);
                var userSmctVendors = await _repo.Context.UserSmctVendors.FirstOrDefaultAsync(x => x.IdUserSmct == idUserSmct);

                var _SigningType = SecurityRepo.Decrypt(indata.ParameterCondition.SigningTypeEn);
                var _StyleCode = indata.ParameterCondition.Style;
                var smctMaster = await _repo.Context.SmctMasters.FirstOrDefaultAsync(x => x.IdSmctMaster == idSmctMaster);
                var contractStyles = await _repo.Context.ContractStyles.FirstOrDefaultAsync(x => x.ContractStyleCode == _StyleCode);
                var lkDepartments = await _repo.Context.LkDepartments.FirstOrDefaultAsync(x => x.Dcode == departmentCode);
                var contractTypes = await _repo.Context.ContractTypes.FirstOrDefaultAsync(x => x.IdContractStyle == contractStyles.IdContractStyle && x.ContractTypeId == indata.ParameterCondition.ContractTypeId);

                indata.ParameterCondition.IdUserSmctCurr = idUserSmct;
                indata.ParameterCondition.ContractTypeId = contractTypes.ContractTypeId;
                indata.ParameterCondition.SigningType = _SigningType;
                indata.ParameterCondition.ContractStyleCode = contractStyles.ContractStyleCode;
                indata.ParameterCondition.ContractStyleFullName = contractStyles.ContractStyleFullName;
                indata.ParameterCondition.IdRegisterNhso = userSmctVendors.IdRegisterNhso;
                indata.ParameterCondition.DepartmentCode = departmentCode;
                indata.ParameterCondition.Dname = lkDepartments.Dname;
                indata.ParameterCondition.BudgetYear = budgetYear.ToString();
                indata.ParameterCondition.RefId = smctMaster.RefId;
                indata.ParameterCondition.RefDate = smctMaster.RefDate;


                //SMCT_MASTER
                await _repo.ContractShare.UpdateSmctMaster(indata);

                //ข้อมูลฝ่ายคู่สัญญา,ข้อมูลผู้ลงนามฝ่ายคู่สัญญา
                await _repo.ContractShare.UpdateMasterSigners(indata);

                //ข้อมูลไฟล์แนบท้าย
                await _repo.ContractShare.UpdateInfoAttachDraftContract(indata, $"T{contractTypes.ContractTypeId}");

                //ทำหนังสือขออนุมัติ
                await _repo.ContractShare.UpdateApprovalReqStation(indata);

                //ContractStation
                var contractStation = await _repo.ContractShare.UpdateContractStation(indata);

                await _transaction.CommitAsync();

                indata.ContractStation = _mapper.Map<ContractStationDTO>(contractStation);

                return indata;
            }
        }

        public async Task<TAllMasterVendorView> DeleteAsync(TAllMasterVendorView indata)
        {
            throw new NotImplementedException();
        }

    }
}
