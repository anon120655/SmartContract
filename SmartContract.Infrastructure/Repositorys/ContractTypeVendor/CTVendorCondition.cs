using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SmartContract.Infrastructure.Data.EntityFramework;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Interfaces.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Infrastructure.Wrapper;
using SmartContract.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Repositorys.ContractTypeVendor
{
    public class CTVendorCondition : ICTVendorCondition
    {
        private IRepositoryWrapper _repo;
        private readonly IMapper _mapper;
        private readonly AppSettings _mySet;
        private readonly IWebHostEnvironment _env;
        private IHttpContextAccessor _httpConAcc;

        public CTVendorCondition(IRepositoryWrapper repo, IWebHostEnvironment env, IMapper mapper, IOptions<AppSettings> settings, IHttpContextAccessor httpConAcc)
        {
            _repo = repo;
            _env = env;
            _mapper = mapper;
            _mySet = settings.Value;
            _httpConAcc = httpConAcc;
        }

        public string ParameterURL(Pager indata)
        {
            SearchOptionCTV options = new SearchOptionCTV();

            if (indata.Condition != null)
            {
                Type t = indata.Condition.GetType();
                if (t.Equals(typeof(SearchOptionCTV)))
                {
                    var condition = (SearchOptionCTV)indata.Condition;
                    options = new SearchOptionCTV()
                    {
                        Style = !String.IsNullOrEmpty(condition.Style) ? condition.Style.Trim() : String.Empty,
                        Sector = !String.IsNullOrEmpty(condition.Sector) ? condition.Sector.Trim() : String.Empty,
                    };
                }
            }

            String _Parameter = String.Empty;
            _Parameter = !String.IsNullOrEmpty(options.Style) ? $"{_Parameter}&Style={options.Style}" : _Parameter;
            _Parameter = !String.IsNullOrEmpty(options.Sector) ? $"{_Parameter}&Sector={options.Sector}" : _Parameter;

            return _Parameter;
        }

        public async Task<DashboardMain> GetDashboardAll(SearchOptionCTV Condition = null)
        {
            var departmentCode = _repo.UserService.GetDepartmentCode();
            var roleCode = _repo.UserService.GetRoleRoleCode();
            String idUserSmct = _repo.UserService.GetIdUserSmct();

            var contractStations = _repo.Context.ContractStations.Where(x => x.Used && x.DepartmentCode == departmentCode);
            var contractStyles = _repo.Context.ContractStyles.Where(x => x.Used && x.ContractStyleCode != null);
            var contractTypes = _repo.Context.ContractTypes.Where(x => x.Used).ToList();
            if (Condition != null)
            {
                contractTypes = contractTypes.Where(x => x.GpType == Condition.GpType || x.GpType == "GP").ToList();
            }
            var contractTypesUse = contractTypes.Select(x => x.ContractTypeId).ToList();


            //SuperAdmin ,ส่วนกลาง = แสดงข้อมูลทั้งหมด
            if (roleCode != PermissionRole.SystemAdmin && roleCode != PermissionRole.CentralAdmin && roleCode != PermissionRole.CentralUser)
            {
                //เขต = แสดงข้อมูลเขตนั้นๆ
                if (roleCode == PermissionRole.KetOfficer || roleCode == PermissionRole.KetSigner)
                {
                    contractStations = contractStations.Where(x => x.DepartmentCode == departmentCode);
                }
                else //หน่วยบริการ = แสดงข้อมูลหน่วยบริการตนเอง
                {
                    contractStations = contractStations.Where(x => x.DepartmentCode == departmentCode && x.CreateUser == idUserSmct);
                }
            }


            DashboardMain response = new DashboardMain();
            foreach (var item in contractStyles)
            {
                var queryCount = await contractStations.Where(x => x.ContractStyleCode == item.ContractStyleCode && x.FRetarn == F_RETARN.NEW && contractTypesUse.Contains(x.ContractTypeId)).GroupBy(s => s.StationStatusCurr)
                 .Select(grp => new
                 {
                     StationStatusCurr = grp.Key,
                     StationStatusCurrCount = grp.Count()
                 }).ToListAsync();

                var _DraftCount = queryCount.FirstOrDefault(x => x.StationStatusCurr == ContractStationStatusAll.S1Draft)?.StationStatusCurrCount;
                var _ReqAppCount = queryCount.FirstOrDefault(x => x.StationStatusCurr == ContractStationStatusAll.S2BookRequestApproval)?.StationStatusCurrCount;
                var _ContractCount = queryCount.FirstOrDefault(x => x.StationStatusCurr == ContractStationStatusAll.S4CreateContract)?.StationStatusCurrCount;
                var _Sign2Count = queryCount.FirstOrDefault(x => x.StationStatusCurr == ContractStationStatusAll.S5Signing2)?.StationStatusCurrCount;
                var _GenContractIdCount = queryCount.FirstOrDefault(x => x.StationStatusCurr == ContractStationStatusAll.S6ContractNumber)?.StationStatusCurrCount;
                var _BindingCount = queryCount.FirstOrDefault(x => x.StationStatusCurr == ContractStationStatusAll.S7Binding)?.StationStatusCurrCount;
                var _CancelCount = queryCount.FirstOrDefault(x => x.StationStatusCurr == ContractStationStatusAll.S8Cancel)?.StationStatusCurrCount;
                var _FRetarnCount = queryCount.FirstOrDefault(x => x.StationStatusCurr == ContractStationStatusAll.S8Cancel)?.StationStatusCurrCount;
                response.Dashboards.Add(new Dashboards()
                {
                    Style = item.ContractStyleCode,
                    DraftCount = _DraftCount ?? 0,
                    ReqAppCount = _ReqAppCount ?? 0,
                    ContractCount = _ContractCount ?? 0,
                    Sign2Count = _Sign2Count ?? 0,
                    GenContractIdCount = _GenContractIdCount ?? 0,
                    BindingCount = _BindingCount ?? 0,
                    CancelCount = _CancelCount ?? 0,
                });

                var queryCountFR = await contractStations.Where(x => x.ContractStyleCode == item.ContractStyleCode && x.FRetarn == F_RETARN.REJECT && contractTypesUse.Contains(x.ContractTypeId)).GroupBy(s => s.StationStatusCurr)
                 .Select(grp => new
                 {
                     StationStatusCurr = grp.Key,
                     FRetarnCount = grp.Count()
                 }).ToListAsync();

                var _DraftCountFR = queryCountFR.FirstOrDefault(x => x.StationStatusCurr == ContractStationStatusAll.S1Draft)?.FRetarnCount;
                var _ReqAppCountFR = queryCountFR.FirstOrDefault(x => x.StationStatusCurr == ContractStationStatusAll.S2BookRequestApproval)?.FRetarnCount;
                var _ContractCountFR = queryCountFR.FirstOrDefault(x => x.StationStatusCurr == ContractStationStatusAll.S4CreateContract)?.FRetarnCount;
                var _Sign2CountFR = queryCountFR.FirstOrDefault(x => x.StationStatusCurr == ContractStationStatusAll.S5Signing2)?.FRetarnCount;
                var _GenContractIdCountFR = queryCountFR.FirstOrDefault(x => x.StationStatusCurr == ContractStationStatusAll.S6ContractNumber)?.FRetarnCount;
                var _BindingCountFR = queryCountFR.FirstOrDefault(x => x.StationStatusCurr == ContractStationStatusAll.S7Binding)?.FRetarnCount;
                var _CancelCountFR = queryCountFR.FirstOrDefault(x => x.StationStatusCurr == ContractStationStatusAll.S8Cancel)?.FRetarnCount;
                var _FRetarnCountFR = queryCountFR.FirstOrDefault(x => x.StationStatusCurr == ContractStationStatusAll.S8Cancel)?.FRetarnCount;
                response.DashboardFReturn.Add(new DashboardFReturn()
                {
                    Style = item.ContractStyleCode,
                    DraftCount = _DraftCountFR ?? 0,
                    ReqAppCount = _ReqAppCountFR ?? 0,
                    ContractCount = _ContractCountFR ?? 0,
                    Sign2Count = _Sign2CountFR ?? 0,
                    GenContractIdCount = _GenContractIdCountFR ?? 0,
                    BindingCount = _BindingCountFR ?? 0,
                    CancelCount = _CancelCountFR ?? 0,
                });
            }

            return response;
        }

        public async Task<Dashboards> GetDashboard(SearchOptionCTV Condition = null)
        {
            var departmentCode = _repo.UserService.GetDepartmentCode();
            var roleCode = _repo.UserService.GetRoleRoleCode();
            String idUserSmct = _repo.UserService.GetIdUserSmct();

            var contractStations = _repo.Context.ContractStations.Where(x => x.Used && x.DepartmentCode == departmentCode);
            var contractTypes = _repo.Context.ContractTypes.Where(x => x.Used).ToList();
            if (Condition != null)
            {

                if (!String.IsNullOrEmpty(Condition.Style))
                    contractStations = contractStations.Where(x => x.ContractStyleCode == Condition.Style);
            }

            //SuperAdmin ,ส่วนกลาง = แสดงข้อมูลทั้งหมด
            if (roleCode != PermissionRole.SystemAdmin && roleCode != PermissionRole.CentralAdmin && roleCode != PermissionRole.CentralUser)
            {
                //เขต = แสดงข้อมูลเขตนั้นๆ
                if (roleCode == PermissionRole.KetOfficer || roleCode == PermissionRole.KetSigner)
                {
                    contractStations = contractStations.Where(x => x.DepartmentCode == departmentCode);
                }
                else //หน่วยบริการ = แสดงข้อมูลหน่วยบริการตนเอง
                {
                    contractStations = contractStations.Where(x => x.DepartmentCode == departmentCode && x.CreateUser == idUserSmct);
                }
            }

            contractTypes = contractTypes.Where(x => x.GpType == "P" || x.GpType == "GP").ToList();
            var contractTypesUse = contractTypes.Select(x => x.ContractTypeId).ToList();

            var queryCount = await contractStations.Where(x => contractTypesUse.Contains(x.ContractTypeId)).GroupBy(s => s.StationStatusCurr)
                     .Select(grp => new
                     {
                         StationStatusCurr = grp.Key,
                         StationStatusCurrCount = grp.Count()
                     }).ToListAsync();


            var _DraftCount = queryCount.FirstOrDefault(x => x.StationStatusCurr == ContractStationStatusAll.S1Draft)?.StationStatusCurrCount;
            var _ReqAppCount = queryCount.FirstOrDefault(x => x.StationStatusCurr == ContractStationStatusAll.S2BookRequestApproval)?.StationStatusCurrCount;
            var _ContractCount = queryCount.FirstOrDefault(x => x.StationStatusCurr == ContractStationStatusAll.S4CreateContract)?.StationStatusCurrCount;
            var _Sign2Count = queryCount.FirstOrDefault(x => x.StationStatusCurr == ContractStationStatusAll.S5Signing2)?.StationStatusCurrCount;
            var _GenContractIdCount = queryCount.FirstOrDefault(x => x.StationStatusCurr == ContractStationStatusAll.S6ContractNumber)?.StationStatusCurrCount;
            var _BindingCount = queryCount.FirstOrDefault(x => x.StationStatusCurr == ContractStationStatusAll.S7Binding)?.StationStatusCurrCount;
            var _CancelCount = queryCount.FirstOrDefault(x => x.StationStatusCurr == ContractStationStatusAll.S8Cancel)?.StationStatusCurrCount;

            return new Dashboards()
            {
                DraftCount = _DraftCount ?? 0,
                ReqAppCount = _ReqAppCount ?? 0,
                ContractCount = _ContractCount ?? 0,
                Sign2Count = _Sign2Count ?? 0,
                GenContractIdCount = _GenContractIdCount ?? 0,
                BindingCount = _BindingCount ?? 0,
                CancelCount = _CancelCount ?? 0,
            };
        }

        public PaginationView<List<ContractStationDTO>> GetTracking(int? page, int pageSize, SearchOptionCTV Condition = null)
        {
            IEnumerable<ContractStationDTO> queryMap = null;
            String idUserSmct = _repo.UserService.GetIdUserSmct();
            var departmentCode = _repo.UserService.GetDepartmentCode();
            var roleCode = _repo.UserService.GetRoleRoleCode();

            if (Condition.Style == "S1") //T01 ,T03 ,T04
                queryMap = _repo.T01Repo.GetList(Condition);
            else if (Condition.Style == "S2") //T06 ,T08
                queryMap = _repo.T06Repo.GetList(Condition);
            else if (Condition.Style == "S41")
                queryMap = _repo.T11Repo.GetList(Condition); //T11
            else if (Condition.Style == "S42")
                queryMap = _repo.T13Repo.GetList(Condition); //T13

            //SuperAdmin ,ส่วนกลาง = แสดงข้อมูลทั้งหมด
            if (roleCode != PermissionRole.SystemAdmin && roleCode != PermissionRole.CentralAdmin && roleCode != PermissionRole.CentralUser)
            {
                //เขต = แสดงข้อมูลเขตนั้นๆ
                if (roleCode == PermissionRole.KetOfficer || roleCode == PermissionRole.KetSigner)
                {
                    queryMap = queryMap.Where(x => x.DepartmentCode == departmentCode);
                }
                else //หน่วยบริการ = แสดงข้อมูลหน่วยบริการตนเอง
                {
                    queryMap = queryMap.Where(x => x.DepartmentCode == departmentCode && x.CreateUser == idUserSmct);
                }
            }

            var pager = new Pager(queryMap.Count(), page, pageSize, Condition);
            pager.UrlAction = $"{_mySet.SubDomainServer}/HomeVendor/Tracking";

            var itemss = queryMap.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);

            var response = new PaginationView<List<ContractStationDTO>>()
            {
                Items = itemss.ToList(),
                Pager = pager
            };

            return response;
        }

        public async Task<CTVendorMasterView> InitialData(CTVendorMasterView indata)
        {
            var contractTypes = await _repo.MasterData.ContractTypes();

            indata.GetLookUp = new LookUpResource()
            {
                SubDomainServer = _mySet.SubDomainServer,
                ContractTypes = contractTypes
            };

            if (indata.Style == "S42")
            {
                var ContractStationSuccesses = await _repo.Context.ContractStationSuccesses.Where(x => x.ContractTypeId == "01").ToListAsync();
                indata.ContractStationSuccess = _mapper.Map<List<ContractStationSuccessDTO>>(ContractStationSuccesses);
            }

            return indata;
        }

        public string SetUrlRedirect(CTVendorMasterView indata)
        {
            String fullPath = $"{_mySet.SubDomainServer}/ContractTypeVendor/T{indata.ConditionType.ContractTypeSelected}?Style={indata.Style}&ContractTypeIdEn={SecurityRepo.Encrypt(indata.ConditionType.ContractTypeSelected)}";
            if (!String.IsNullOrEmpty(indata.Sector))
            {
                fullPath = $"{fullPath}&Sector={indata.Sector}";
            }
            if (!String.IsNullOrEmpty(indata.ConditionType.ContractIdSelected))
            {
                fullPath = $"{fullPath}&ContractIdSelectEn={SecurityRepo.Encrypt(indata.ConditionType.ContractIdSelected)}";
            }

            String SigningTypeEn = indata.ConditionType.SigningElectronic ? SecurityRepo.Encrypt(SigningTypes.Electronic) : SecurityRepo.Encrypt(SigningTypes.Paper);
            fullPath = $"{fullPath}&SigningTypeEn={SigningTypeEn}";

            return fullPath;
        }

        public async Task<CTVendorMasterView> GetContractCondition(String style, String sector = null)
        {
            CTVendorMasterView response = new CTVendorMasterView();

            var departmentCode = _repo.UserService.GetDepartmentCode();

            var lkDepartments = await _repo.Context.LkDepartments.FirstOrDefaultAsync(x => x.Dcode == departmentCode);
            if (lkDepartments == null)
                throw new Exception($"ไม่พบสำนักงาน");

            var contractStyles = await _repo.Context.ContractStyles.FirstOrDefaultAsync(x => x.ContractStyleCode == style);
            if (contractStyles == null)
                throw new Exception($"ไม่พบรูปแบบนิติกรรมสัญญา {style}");

            response.ConditionType.BureauSubFundCounty = $"{lkDepartments.Dname} ({lkDepartments.Dcode})";
            response.Style = style;
            response.Sector = sector;

            response = await this.InitialData(response);

            return response;
        }

        public CTVendorMasterView SetContractCondition(CTVendorMasterView indata)
        {
            if (String.IsNullOrEmpty(indata.ConditionType.ContractTypeSelected))
                throw new Exception("ระบุประเภทนิติกรรมสัญญา");

            if (indata.Style == "S42")
            {
                if (String.IsNullOrEmpty(indata.ConditionType.ContractIdSelected))
                    throw new Exception("ระบุสัญญาให้บริการสาธารณสุขฯ");
            }

            if (!indata.ConditionType.SigningElectronic && !indata.ConditionType.SigningPaper)
                throw new Exception("ระบุรูปแบบการลงนาม");


            String idUserSmct = _repo.UserService.GetIdUserSmct();
            var vendorLinkReqs = _repo.Context.VendorLinkReqs.FirstOrDefault(x => x.CreateUser == idUserSmct);
            if (vendorLinkReqs != null)
            {
                if (vendorLinkReqs.VendorId == null || vendorLinkReqs.Status != ContractStatusAll.S3Approve)
                {
                    throw new Exception($"มีนิติกรรมที่อยู่ในขั้นตอน<br />ขอกำหนดรหัสคู่สัญญา<br />ต้องรอให้นิติกรรมฉบับแรก<br />ได้รหัสคู่สัญญาก่อน");
                }
            }

            return indata;
        }

        public async Task<string> REFRunning()
        {
            int budgetYear = new ThaiBuddhistCalendar().GetYear(DateTime.Now);

            //ปีงบประมาณใหม่
            if (DateTime.Now.Month >= 10 && DateTime.Now.Day >= 1)
                budgetYear++;

            var query = await _repo.Context.SmctMasters.OrderByDescending(x => x.RefId)
                                                         .FirstOrDefaultAsync(x => x.Used);

            String _BudgetYear = budgetYear.ToString().Substring(2);
            if (query == null)
            {
                return $"REF{_BudgetYear}00001";
            }

            var registerNo = int.Parse(query.RefId.Substring(5)) + 1;
            return $"REF{_BudgetYear}{registerNo.ToString("00000")}";

        }

    }
}
