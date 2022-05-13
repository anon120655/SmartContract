using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SmartContract.Infrastructure.Data.EntityFramework;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Interfaces;
using SmartContract.Infrastructure.Interfaces.ContractTypeBureau;
using SmartContract.Infrastructure.Repositorys.ContractTypeVendor;
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

namespace SmartContract.Infrastructure.Repositorys.ContractTypeBureau
{
    public class ContractRepo : IContractRepo
    {
        private IRepositoryWrapper _repo;
        private readonly IRepositoryBase _db;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly AppSettings _mySet;

        public ContractRepo(IRepositoryWrapper repo, IRepositoryBase db, IMapper mapper, IWebHostEnvironment env, IOptions<AppSettings> settings)
        {
            _repo = repo;
            _db = db;
            _env = env;
            _mapper = mapper;
            _mySet = settings.Value;
        }

        public async Task<DashboardHomeMain> GetDashboardHome()
        {
            PermissionRole roleCode = _repo.UserService.GetRoleRoleCode();
            var response = new DashboardHomeMain();

            var queryMap = _repo.Context.ContractStations.Where(x => x.Used).OrderByDescending(x => x.EditDate).AsEnumerable();

            //ส่วนกลาง CentralUser สร้างนิติกรรมเฉพาะ style1-2 = T01 T02 T03 T04 T05
            if (roleCode == PermissionRole.CentralUser)
            {
                queryMap = queryMap.Where(x => x.ContractStyleCode == "S1" || x.ContractStyleCode == "S2").OrderByDescending(x => x.EditDate);
            }
            //เขตสร้างนิติกรรมเฉพาะ  style3-4 = T10 T11 T12 T13 T14
            if (roleCode == PermissionRole.KetSigner || roleCode == PermissionRole.KetOfficer)
            {
                queryMap = queryMap.Where(x => x.ContractStyleCode == "S3" || x.ContractStyleCode == "S41" || x.ContractStyleCode == "S42" || x.ContractStyleCode == "S43").OrderByDescending(x => x.EditDate);
            }

            var pager = new Pager(queryMap.Count(), 1, 5, null);
            pager.UrlAction = $"{_mySet.SubDomainServer}/Home/Dashboard";

            var items = queryMap.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);

            var itemss = _mapper.Map<List<ContractStationDTO>>(items);

            response.ContractList = new PaginationView<List<ContractStationDTO>>()
            {
                Items = itemss.ToList(),
                Pager = pager
            };

            var contractStations = _repo.Context.ContractStations.Where(x => x.Used);
            var queryCount = await contractStations.GroupBy(s => s.ContractTypeId)
                     .Select(grp => new
                     {
                         ContractTypeId = grp.Key,
                         ContractTypeIdCount = grp.Count()
                     }).ToListAsync();


            var _ContractType1Count = queryCount.Where(x => x.ContractTypeId == "01" || x.ContractTypeId == "11").Sum(x => x.ContractTypeIdCount);
            var _ContractType2Count = queryCount.Where(x => x.ContractTypeId == "02" || x.ContractTypeId == "05" || x.ContractTypeId == "07" || x.ContractTypeId == "09" || x.ContractTypeId == "10" || x.ContractTypeId == "12").Sum(x => x.ContractTypeIdCount);
            var _ContractType3Count = queryCount.Where(x => x.ContractTypeId == "13").Sum(x => x.ContractTypeIdCount);
            var _ContractType4Count = queryCount.Where(x => x.ContractTypeId == "14").Sum(x => x.ContractTypeIdCount);

            response.ContractTypeCount = new ContractTypeCount()
            {
                ContractType1 = _ContractType1Count,
                ContractType2 = _ContractType2Count,
                ContractType3 = _ContractType3Count,
                ContractType4 = _ContractType4Count,
            };


            return response;
        }

        //หนังสือขออนุมัติ
        public async Task<DashboardsReqApp> GetDashboardReqApp()
        {
            var departmentCode = _repo.UserService.GetDepartmentCode();
            PermissionRole roleCode = _repo.UserService.GetRoleRoleCode();

            var approvalReqStations = _repo.Context.ApprovalReqStations.Where(x => x.Used);


            //SuperAdmin ,ส่วนกลาง = แสดงข้อมูลทั้งหมด
            if (roleCode != PermissionRole.SystemAdmin && roleCode != PermissionRole.CentralAdmin && roleCode != PermissionRole.CentralUser)
            {
                //เขต = แสดงข้อมูลเขตนั้นๆ
                if (roleCode == PermissionRole.KetOfficer || roleCode == PermissionRole.KetSigner)
                {
                    approvalReqStations = approvalReqStations.Where(x => x.DepartmentCode == departmentCode);
                }
            }


            //ส่วนกลาง CentralUser สร้างนิติกรรมเฉพาะ style1-2 = T01 T02 T03 T04 T05
            if (roleCode == PermissionRole.CentralUser)
            {
                approvalReqStations = approvalReqStations.Where(x => x.ContractStyleCode == "S1" || x.ContractStyleCode == "S2").OrderByDescending(x => x.EditDate);
            }
            //เขตสร้างนิติกรรมเฉพาะ  style3-4 = T10 T11 T12 T13 T14
            if (roleCode == PermissionRole.KetSigner || roleCode == PermissionRole.KetOfficer)
            {
                approvalReqStations = approvalReqStations.Where(x => x.ContractStyleCode == "S3" || x.ContractStyleCode == "S41" || x.ContractStyleCode == "S42" || x.ContractStyleCode == "S43").OrderByDescending(x => x.EditDate);
            }

            var queryCount = await approvalReqStations.GroupBy(s => s.StationStatusCurr)
                     .Select(grp => new
                     {
                         StationStatusCurr = grp.Key,
                         StationStatusCurrCount = grp.Count()
                     }).ToListAsync();

            var _S1CreateProposalCount = queryCount.FirstOrDefault(x => x.StationStatusCurr == ApproveStationStatusAll.S1CreateProposal)?.StationStatusCurrCount;
            var _S2CreateApproveCount = queryCount.FirstOrDefault(x => x.StationStatusCurr == ApproveStationStatusAll.S2CreateApprove)?.StationStatusCurrCount;
            var _S3ConsiderCount = queryCount.FirstOrDefault(x => x.StationStatusCurr == ApproveStationStatusAll.S3Consider)?.StationStatusCurrCount;
            var _S4ApproveCount = queryCount.FirstOrDefault(x => x.StationStatusCurr == ApproveStationStatusAll.S4Approve)?.StationStatusCurrCount;
            var _S5CancelCount = queryCount.FirstOrDefault(x => x.StationStatusCurr == ApproveStationStatusAll.S5Cancel)?.StationStatusCurrCount;

            return new DashboardsReqApp()
            {
                S1CreateProposalCount = _S1CreateProposalCount ?? 0,
                S2CreateApproveCount = _S2CreateApproveCount ?? 0,
                S3ConsiderCount = _S3ConsiderCount ?? 0,
                S4ApproveCount = _S4ApproveCount ?? 0,
                S5CancelCount = _S5CancelCount ?? 0
            };
        }

        public IEnumerable<ApprovalReqStationDTO> GetListReqApprove(SearchOptionStation condition = null)
        {
            var departmentCode = _repo.UserService.GetDepartmentCode();
            PermissionRole roleCode = _repo.UserService.GetRoleRoleCode();

            var response = new List<ApprovalReqStationDTO>();

            var approvalReqStations = _repo.Context.ApprovalReqStations.Where(x => x.Used /*&& x.DepartmentCode == departmentCode*/).OrderByDescending(x => x.EditDate);

            if (condition != null)
            {
                if (!String.IsNullOrEmpty(condition.Station))
                    approvalReqStations = approvalReqStations.Where(x => x.StationStatusCurr == condition.Station).OrderByDescending(x => x.EditDate);
            }
            //ส่วนกลาง CentralUser สร้างนิติกรรมเฉพาะ style1-2 = T01 T02 T03 T04 T05
            if (roleCode == PermissionRole.CentralUser)
            {
                approvalReqStations = approvalReqStations.Where(x => x.ContractStyleCode == "S1" || x.ContractStyleCode == "S2").OrderByDescending(x => x.EditDate);
            }
            //เขตสร้างนิติกรรมเฉพาะ  style3-4 = T10 T11 T12 T13 T14
            if (roleCode == PermissionRole.KetSigner || roleCode == PermissionRole.KetOfficer)
            {
                approvalReqStations = approvalReqStations.Where(x => x.ContractStyleCode == "S3" || x.ContractStyleCode == "S41" || x.ContractStyleCode == "S42" || x.ContractStyleCode == "S43").OrderByDescending(x => x.EditDate);
            }

            approvalReqStations = approvalReqStations.OrderByDescending(x => x.EditDate);

            response = _mapper.Map<List<ApprovalReqStationDTO>>(approvalReqStations);

            return response;
        }

        public PaginationView<List<ApprovalReqStationDTO>> GetTrackingBookReqApprove(int? page, int pageSize, SearchOptionStation condition = null)
        {
            var departmentCode = _repo.UserService.GetDepartmentCode();
            var roleCode = _repo.UserService.GetRoleRoleCode();
            String idUserSmct = _repo.UserService.GetIdUserSmct();

            IEnumerable<ApprovalReqStationDTO> queryMap = null;

            queryMap = this.GetListReqApprove(condition);

            //SuperAdmin ,ส่วนกลาง = แสดงข้อมูลทั้งหมด
            if (roleCode != PermissionRole.SystemAdmin && roleCode != PermissionRole.CentralAdmin && roleCode != PermissionRole.CentralUser)
            {
                //เขต = แสดงข้อมูลเขตนั้นๆ
                if (roleCode == PermissionRole.KetOfficer || roleCode == PermissionRole.KetSigner)
                {
                    queryMap = queryMap.Where(x => x.DepartmentCode == departmentCode);
                }
            }

            var pager = new Pager(queryMap.Count(), page, pageSize, condition);
            pager.UrlAction = $"{_mySet.SubDomainServer}/Home/IndexProposal";

            var itemss = queryMap.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);

            var response = new PaginationView<List<ApprovalReqStationDTO>>()
            {
                Items = itemss.ToList(),
                Pager = pager
            };

            return response;
        }

        //สร้างนิติกรรมสัญญา
        public async Task<DashboardsContract> GetDashboardsContract()
        {
            var departmentCode = _repo.UserService.GetDepartmentCode();
            PermissionRole roleCode = _repo.UserService.GetRoleRoleCode();

            var contractStations = _repo.Context.ContractStations.Where(x => x.Used);


            //SuperAdmin ,ส่วนกลาง = แสดงข้อมูลทั้งหมด
            if (roleCode != PermissionRole.SystemAdmin && roleCode != PermissionRole.CentralAdmin && roleCode != PermissionRole.CentralUser)
            {
                //เขต = แสดงข้อมูลเขตนั้นๆ
                if (roleCode == PermissionRole.KetOfficer || roleCode == PermissionRole.KetSigner)
                {
                    contractStations = contractStations.Where(x => x.DepartmentCode == departmentCode);
                }
            }

            //ส่วนกลาง CentralUser สร้างนิติกรรมเฉพาะ style1-2 = T01 T02 T03 T04 T05
            if (roleCode == PermissionRole.CentralUser)
            {
                contractStations = contractStations.Where(x => x.ContractStyleCode == "S1" || x.ContractStyleCode == "S2").OrderByDescending(x => x.EditDate);
            }
            //เขตสร้างนิติกรรมเฉพาะ  style3-4 = T10 T11 T12 T13 T14
            if (roleCode == PermissionRole.KetSigner || roleCode == PermissionRole.KetOfficer)
            {
                contractStations = contractStations.Where(x => x.ContractStyleCode == "S3" || x.ContractStyleCode == "S41" || x.ContractStyleCode == "S42" || x.ContractStyleCode == "S43").OrderByDescending(x => x.EditDate);
            }

            var queryCount = await contractStations.GroupBy(s => s.StationStatusCurr)
                     .Select(grp => new
                     {
                         StationStatusCurr = grp.Key,
                         StationStatusCurrCount = grp.Count()
                     }).ToListAsync();

            var _S1DraftCount = queryCount.FirstOrDefault(x => x.StationStatusCurr == ContractStationStatusAll.S1Draft)?.StationStatusCurrCount;
            var _S2BookRequestApprovalCount = queryCount.FirstOrDefault(x => x.StationStatusCurr == ContractStationStatusAll.S2BookRequestApproval)?.StationStatusCurrCount;
            var _S3SetVendorCount = queryCount.FirstOrDefault(x => x.StationStatusCurr == ContractStationStatusAll.S3SetVendor)?.StationStatusCurrCount;
            var _S4CreateContractCount = queryCount.FirstOrDefault(x => x.StationStatusCurr == ContractStationStatusAll.S4CreateContract)?.StationStatusCurrCount;
            var _S5Signing2Count = queryCount.FirstOrDefault(x => x.StationStatusCurr == ContractStationStatusAll.S5Signing2)?.StationStatusCurrCount;
            var _S6ContractNumberCount = queryCount.FirstOrDefault(x => x.StationStatusCurr == ContractStationStatusAll.S6ContractNumber)?.StationStatusCurrCount;
            var _S7BindingCount = queryCount.FirstOrDefault(x => x.StationStatusCurr == ContractStationStatusAll.S7Binding)?.StationStatusCurrCount;
            var _S8CancelCount = queryCount.FirstOrDefault(x => x.StationStatusCurr == ContractStationStatusAll.S8Cancel)?.StationStatusCurrCount;

            return new DashboardsContract()
            {
                S1DraftCount = _S1DraftCount ?? 0,
                S2BookRequestApprovalCount = _S2BookRequestApprovalCount ?? 0,
                S3SetVendorCount = _S3SetVendorCount ?? 0,
                S4CreateContractCount = _S4CreateContractCount ?? 0,
                S5Signing2Count = _S5Signing2Count ?? 0,
                S6ContractNumberCount = _S6ContractNumberCount ?? 0,
                S7BindingCount = _S7BindingCount ?? 0,
                S8CancelCount = _S8CancelCount ?? 0
            };
        }

        public IEnumerable<ContractStationDTO> GetListContract(SearchOptionStation condition = null)
        {
            var departmentCode = _repo.UserService.GetDepartmentCode();
            PermissionRole roleCode = _repo.UserService.GetRoleRoleCode();

            var response = new List<ContractStationDTO>();

            var contractStations = _repo.Context.ContractStations.Where(x => x.Used /*&& x.DepartmentCode == departmentCode*/).OrderByDescending(x => x.EditDate);

            if (condition != null)
            {
                if (!String.IsNullOrEmpty(condition.Station))
                    contractStations = contractStations.Where(x => x.StationStatusCurr == condition.Station).OrderByDescending(x => x.EditDate);

                if (!String.IsNullOrEmpty(condition.StationEn))
                {
                    String _Station = SecurityRepo.Decrypt(condition.StationEn);
                    contractStations = contractStations.Where(x => x.StationStatusCurr == _Station).OrderByDescending(x => x.EditDate);
                }
            }
            //ส่วนกลาง CentralUser สร้างนิติกรรมเฉพาะ style1-2 = T01 T02 T03 T04 T05
            if (roleCode == PermissionRole.CentralUser)
            {
                contractStations = contractStations.Where(x => x.ContractStyleCode == "S1" || x.ContractStyleCode == "S2").OrderByDescending(x => x.EditDate);
            }
            //เขตสร้างนิติกรรมเฉพาะ  style3-4 = T10 T11 T12 T13 T14
            if (roleCode == PermissionRole.KetSigner || roleCode == PermissionRole.KetOfficer)
            {
                contractStations = contractStations.Where(x => x.ContractStyleCode == "S3" || x.ContractStyleCode == "S41" || x.ContractStyleCode == "S42" || x.ContractStyleCode == "S43").OrderByDescending(x => x.EditDate);
            }


            response = _mapper.Map<List<ContractStationDTO>>(contractStations);

            return response;
        }

        public PaginationView<List<ContractStationDTO>> GetTrackingContract(int? page, int pageSize, SearchOptionStation condition = null)
        {
            var departmentCode = _repo.UserService.GetDepartmentCode();
            var roleCode = _repo.UserService.GetRoleRoleCode();

            IEnumerable<ContractStationDTO> queryMap = null;

            queryMap = this.GetListContract(condition);

            //SuperAdmin ,ส่วนกลาง = แสดงข้อมูลทั้งหมด
            if (roleCode != PermissionRole.SystemAdmin && roleCode != PermissionRole.CentralAdmin && roleCode != PermissionRole.CentralUser)
            {
                //เขต = แสดงข้อมูลเขตนั้นๆ
                if (roleCode == PermissionRole.KetOfficer || roleCode == PermissionRole.KetSigner)
                {
                    queryMap = queryMap.Where(x => x.DepartmentCode == departmentCode);
                }
            }

            var pager = new Pager(queryMap.Count(), page, pageSize, condition);
            pager.UrlAction = $"{_mySet.SubDomainServer}/Home/Index";

            var itemss = queryMap.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);

            var response = new PaginationView<List<ContractStationDTO>>()
            {
                Items = itemss.ToList(),
                Pager = pager
            };

            return response;
        }

        //กำหนดรหัสคู่สัญญา
        public async Task<DashboardsVendorLink> GetDashboardVendorLink(SearchOptionStation Condition)
        {
            var departmentCode = _repo.UserService.GetDepartmentCode();
            PermissionRole roleCode = _repo.UserService.GetRoleRoleCode();

            var vendorLinkReqStations = _repo.Context.VendorLinkReqStations.Where(x => x.Used);

            //ส่วนกลาง CentralUser สร้างนิติกรรมเฉพาะ style1-2 = T01 T02 T03 T04 T05
            if (roleCode == PermissionRole.CentralUser)
            {
                vendorLinkReqStations = vendorLinkReqStations.Where(x => x.ContractStyleCode == "S1" || x.ContractStyleCode == "S2").OrderByDescending(x => x.EditDate);
            }
            //เขตสร้างนิติกรรมเฉพาะ  style3-4 = T10 T11 T12 T13 T14
            if (roleCode == PermissionRole.KetSigner || roleCode == PermissionRole.KetOfficer)
            {
                vendorLinkReqStations = vendorLinkReqStations.Where(x => x.ContractStyleCode == "S3" || x.ContractStyleCode == "S41" || x.ContractStyleCode == "S42" || x.ContractStyleCode == "S43").OrderByDescending(x => x.EditDate);
            }

            var queryCount = await vendorLinkReqStations.GroupBy(s => s.StationStatusCurr)
                     .Select(grp => new
                     {
                         StationStatusCurr = grp.Key,
                         StationStatusCurrCount = grp.Count()
                     }).ToListAsync();

            var _S1CreateProposalCount = queryCount.FirstOrDefault(x => x.StationStatusCurr == VendorLinkStationStatusAll.S1CreateProposal)?.StationStatusCurrCount;
            var _S2CheckCount = queryCount.FirstOrDefault(x => x.StationStatusCurr == VendorLinkStationStatusAll.S2Check)?.StationStatusCurrCount;
            var _S3VendorSuccessCount = queryCount.FirstOrDefault(x => x.StationStatusCurr == VendorLinkStationStatusAll.S3VendorSuccess)?.StationStatusCurrCount;
            var _S4CancelCount = queryCount.FirstOrDefault(x => x.StationStatusCurr == VendorLinkStationStatusAll.S4Cancel)?.StationStatusCurrCount;

            return new DashboardsVendorLink()
            {
                S1CreateProposalCount = _S1CreateProposalCount ?? 0,
                S2CheckCount = _S2CheckCount ?? 0,
                S3VendorSuccessCount = _S3VendorSuccessCount ?? 0,
                S4CancelCount = _S4CancelCount ?? 0
            };
        }

        public IEnumerable<VendorLinkReqStationDTO> GetListVendorLink(SearchOptionStation condition = null)
        {
            var departmentCode = _repo.UserService.GetDepartmentCode();

            var response = new List<VendorLinkReqStationDTO>();

            var vendorLinkReqStations = _repo.Context.VendorLinkReqStations.Where(x => x.Used /*&& x.DepartmentCode == departmentCode*/).OrderByDescending(x => x.EditDate);

            if (condition != null)
            {
                if (!String.IsNullOrEmpty(condition.Station))
                    vendorLinkReqStations = vendorLinkReqStations.Where(x => x.StationStatusCurr == condition.Station).OrderByDescending(x => x.EditDate);
            }

            response = _mapper.Map<List<VendorLinkReqStationDTO>>(vendorLinkReqStations);

            return response;
        }

        public PaginationView<List<VendorLinkReqStationDTO>> GetTrackingVendorLink(int? page, int pageSize, SearchOptionStation condition = null)
        {
            IEnumerable<VendorLinkReqStationDTO> queryMap = null;

            queryMap = this.GetListVendorLink(condition);

            var pager = new Pager(queryMap.Count(), page, pageSize, condition);
            pager.UrlAction = $"{_mySet.SubDomainServer}/Home/IndexVendorLink";

            var itemss = queryMap.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);

            var response = new PaginationView<List<VendorLinkReqStationDTO>>()
            {
                Items = itemss.ToList(),
                Pager = pager
            };

            return response;
        }

        //แก้ไขหลังผูกพัน
        public string ParameterSearchOptionStation(Pager indata)
        {
            SearchOptionStation options = new SearchOptionStation();

            if (indata.Condition != null)
            {
                Type t = indata.Condition.GetType();
                if (t.Equals(typeof(SearchOptionStation)))
                {
                    var condition = (SearchOptionStation)indata.Condition;
                    options = new SearchOptionStation()
                    {
                        Style = !String.IsNullOrEmpty(condition.Style) ? condition.Style.Trim() : String.Empty,
                        Menu = !String.IsNullOrEmpty(condition.Menu) ? condition.Menu.Trim() : String.Empty,
                        MenuEn = !String.IsNullOrEmpty(condition.MenuEn) ? condition.MenuEn.Trim() : String.Empty,
                        IdSmctMaster = !String.IsNullOrEmpty(condition.IdSmctMaster) ? condition.IdSmctMaster.Trim() : String.Empty,
                        Station = !String.IsNullOrEmpty(condition.Station) ? condition.Station.Trim() : String.Empty,
                        StationEn = !String.IsNullOrEmpty(condition.StationEn) ? condition.StationEn.Trim() : String.Empty,
                        ContractSuccessStatus = !String.IsNullOrEmpty(condition.ContractSuccessStatus) ? condition.ContractSuccessStatus.Trim() : String.Empty,
                        SuccessState = !String.IsNullOrEmpty(condition.SuccessState) ? condition.SuccessState.Trim() : String.Empty,
                    };
                }
            }

            String _Parameter = String.Empty;
            _Parameter = !String.IsNullOrEmpty(options.Style) ? $"{_Parameter}&Style={options.Style}" : _Parameter;
            _Parameter = !String.IsNullOrEmpty(options.Menu) ? $"{_Parameter}&Menu={options.Menu}" : _Parameter;
            _Parameter = !String.IsNullOrEmpty(options.MenuEn) ? $"{_Parameter}&MenuEn={options.MenuEn}" : _Parameter;
            _Parameter = !String.IsNullOrEmpty(options.IdSmctMaster) ? $"{_Parameter}&IdSmctMaster={options.IdSmctMaster}" : _Parameter;
            _Parameter = !String.IsNullOrEmpty(options.Station) ? $"{_Parameter}&Station={options.Station}" : _Parameter;
            _Parameter = !String.IsNullOrEmpty(options.StationEn) ? $"{_Parameter}&StationEn={options.StationEn}" : _Parameter;
            _Parameter = !String.IsNullOrEmpty(options.ContractSuccessStatus) ? $"{_Parameter}&ContractSuccessStatus={options.ContractSuccessStatus}" : _Parameter;
            _Parameter = !String.IsNullOrEmpty(options.SuccessState) ? $"{_Parameter}&SuccessState={options.SuccessState}" : _Parameter;

            return _Parameter;
        }

        public async Task<DashboardBinding> GetDashboardBinding(SearchOptionStation Condition)
        {
            //var departmentCode = _repo.UserService.GetDepartmentCode();
            String _Menu = SecurityRepo.Decrypt(Condition.MenuEn);
            var contractStationSuccess = _repo.Context.ContractStationSuccesses.Where(x => x.Used && x.ContractSuccessType == _Menu);
            var queryCount = await contractStationSuccess.GroupBy(s => s.ContractSuccessStatus)
                     .Select(grp => new
                     {
                         ContractSuccessStatus = grp.Key,
                         ContractSuccessStatusCount = grp.Count()
                     }).ToListAsync();

            var _S1WaitApproveCount = queryCount.FirstOrDefault(x => x.ContractSuccessStatus == ContractStatusAll.S1WaitApprove)?.ContractSuccessStatusCount;
            var _S2UnApproveCount = queryCount.FirstOrDefault(x => x.ContractSuccessStatus == ContractStatusAll.S2UnApprove)?.ContractSuccessStatusCount;
            var _S3ApproveCount = queryCount.FirstOrDefault(x => x.ContractSuccessStatus == ContractStatusAll.S3Approve)?.ContractSuccessStatusCount;
            var _S0CancelCount = queryCount.FirstOrDefault(x => x.ContractSuccessStatus == ContractStatusAll.S0Cancel)?.ContractSuccessStatusCount;

            return new DashboardBinding()
            {
                S1WaitApproveCount = _S1WaitApproveCount ?? 0,
                S2UnApproveCount = _S2UnApproveCount ?? 0,
                S3ApproveCount = _S3ApproveCount ?? 0,
                S0CancelCount = _S0CancelCount ?? 0
            };
        }

        public IEnumerable<ContractStationSuccessDTO> GetListSuccess(SearchOptionStation condition = null)
        {
            var departmentCode = _repo.UserService.GetDepartmentCode();

            var response = new List<ContractStationSuccessDTO>();

            var contractStationSuccesses = _repo.Context.ContractStationSuccesses.Where(x => x.Used).OrderByDescending(x => x.ContractSuccessEditDate);

            if (condition != null)
            {
                TObjectState _ObjectState = TObjectState.View;
                if (!String.IsNullOrEmpty(condition.SuccessState))
                {
                    Enum.TryParse(SecurityRepo.Decrypt(condition.SuccessState), out _ObjectState);
                }

                if (!String.IsNullOrEmpty(condition.MenuEn))
                {
                    String _Menu = SecurityRepo.Decrypt(condition.MenuEn);
                    //กรณีกดไปจากปุ่มเพิ่มข้อมูล ไม่ต้อง where เพราะต้องโชว์สถานะที่ผูกพันทั้งหมดที่เป็นสถานะปกติ และโชว์สถานะอนุมัติหรือยกเลิก สามารถกลับมาเลือกใหม่ได้
                    if (_ObjectState == TObjectState.Create)
                    {
                        contractStationSuccesses = contractStationSuccesses.Where(x => x.ContractSuccessType == ContractSuccessTypes.TA_NORMAL
                        || x.ContractSuccessStatus == ContractStatusAll.S3Approve || x.ContractSuccessStatus == ContractStatusAll.S0Cancel).OrderByDescending(x => x.EditDate);
                    }
                    else
                    {
                        contractStationSuccesses = contractStationSuccesses.Where(x => x.ContractSuccessType == _Menu).OrderByDescending(x => x.ContractSuccessEditDate);

                        if (!String.IsNullOrEmpty(condition.ContractSuccessStatus))
                            contractStationSuccesses = contractStationSuccesses.Where(x => x.ContractSuccessStatus == condition.ContractSuccessStatus).OrderByDescending(x => x.EditDate);
                    }

                    //ขยายสัญญาเฉพาะ Style1,4
                    if (_Menu == ContractSuccessTypes.T3_EXPAND)
                        contractStationSuccesses = contractStationSuccesses.Where(x => x.ContractStyleCode == "S1" || x.ContractStyleCode.Contains("S4")).OrderByDescending(x => x.ContractSuccessEditDate);
                    //ยุติสัญญาเฉพาะ Style1
                    if (_Menu == ContractSuccessTypes.T5_TERMINATE)
                        contractStationSuccesses = contractStationSuccesses.Where(x => x.ContractStyleCode == "S1").OrderByDescending(x => x.ContractSuccessEditDate);
                    //ปิดโครงการเฉาพะโครงการมีงวดเงิน
                    if (_Menu == ContractSuccessTypes.T4_CLOSEPROJECT)
                    {
                        var contractTypesUse = _repo.Context.ContractTypes.Where(x => x.Used && x.FPay).Select(x => x.ContractTypeId).ToList();
                        contractStationSuccesses = contractStationSuccesses.Where(x => contractTypesUse.Contains(x.ContractTypeId)).OrderByDescending(x => x.ContractSuccessEditDate);
                    }

                }
            }

            response = _mapper.Map<List<ContractStationSuccessDTO>>(contractStationSuccesses);

            return response;
        }

        public PaginationView<List<ContractStationSuccessDTO>> GetTrackingBinding(int? page, int pageSize, SearchOptionStation condition = null)
        {
            IEnumerable<ContractStationSuccessDTO> queryMap = null;

            queryMap = this.GetListSuccess(condition);

            var pager = new Pager(queryMap.Count(), page, pageSize, condition);
            pager.UrlAction = $"{_mySet.SubDomainServer}/{condition.PathUrlAction}";

            var itemss = queryMap.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);

            var response = new PaginationView<List<ContractStationSuccessDTO>>()
            {
                Items = itemss.ToList(),
                Pager = pager
            };

            return response;
        }


    }
}
