using AutoMapper;
using Microsoft.Extensions.Options;
using SmartContract.Infrastructure.Data.EntityFramework;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Interfaces;
using SmartContract.Infrastructure.Interfaces.Share;
using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Other;
using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Infrastructure.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Repositorys.Share
{
    public class OtherRepo : IOtherRepo
    {
        private IRepositoryWrapper _repo;
        private readonly IRepositoryBase _db;
        private readonly IMapper _mapper;
        private readonly AppSettings _mySet;

        public OtherRepo(IRepositoryWrapper repo, IRepositoryBase db, IMapper mapper, IOptions<AppSettings> settings)
        {
            _repo = repo;
            _db = db;
            _mapper = mapper;
            _mySet = settings.Value;
        }

        public string ParameterSearchOptionsAll(Pager indata)
        {
            OtherSearchOption options = new OtherSearchOption();

            if (indata.Condition != null)
            {
                Type t = indata.Condition.GetType();
                if (t.Equals(typeof(OtherSearchOption)))
                {
                    var condition = (OtherSearchOption)indata.Condition;
                    options = new OtherSearchOption()
                    {
                        BudgetYear = !String.IsNullOrEmpty(condition.BudgetYear) ? condition.BudgetYear.Trim() : String.Empty,
                        ContractTypeId = !String.IsNullOrEmpty(condition.ContractTypeId) ? condition.ContractTypeId.Trim() : String.Empty,
                        DepartmentCode = !String.IsNullOrEmpty(condition.DepartmentCode) ? condition.DepartmentCode.Trim() : String.Empty,
                        RefId = !String.IsNullOrEmpty(condition.RefId) ? condition.RefId.Trim() : String.Empty,
                        ContractId = !String.IsNullOrEmpty(condition.ContractId) ? condition.ContractId.Trim() : String.Empty,
                        VendorName = !String.IsNullOrEmpty(condition.VendorName) ? condition.VendorName.Trim() : String.Empty,
                        BudgetCode = !String.IsNullOrEmpty(condition.BudgetCode) ? condition.BudgetCode.Trim() : String.Empty,
                    };
                }
            }

            String _Parameter = String.Empty;
            _Parameter = !String.IsNullOrEmpty(options.BudgetYear) ? $"{_Parameter}&BudgetYear={options.BudgetYear}" : _Parameter;
            _Parameter = !String.IsNullOrEmpty(options.ContractTypeId) ? $"{_Parameter}&ContractTypeId={options.ContractTypeId}" : _Parameter;
            _Parameter = !String.IsNullOrEmpty(options.DepartmentCode) ? $"{_Parameter}&DepartmentCode={options.DepartmentCode}" : _Parameter;
            _Parameter = !String.IsNullOrEmpty(options.RefId) ? $"{_Parameter}&RefId={options.RefId}" : _Parameter;
            _Parameter = !String.IsNullOrEmpty(options.ContractId) ? $"{_Parameter}&ContractId={options.ContractId}" : _Parameter;
            _Parameter = !String.IsNullOrEmpty(options.VendorName) ? $"{_Parameter}&VendorName={options.VendorName}" : _Parameter;
            _Parameter = !String.IsNullOrEmpty(options.BudgetCode) ? $"{_Parameter}&BudgetCode={options.BudgetCode}" : _Parameter;

            return _Parameter;
        }

        public PaginationView<List<ContractStationDTO>> GetSearch(int? page, int pageSize, OtherSearchOption Condition = null)
        {
            IEnumerable<ContractStation> queryMap = null;

            var departmentCode = _repo.UserService.GetDepartmentCode();

            queryMap = _repo.Context.ContractStations.Where(x => x.Used).OrderByDescending(x => x.EditDate);

            if (Condition != null)
            {
                if (!String.IsNullOrEmpty(Condition.BudgetYear))
                    queryMap = queryMap.Where(x => x.Budgetyear == Condition.BudgetYear);
                if (!String.IsNullOrEmpty(Condition.ContractTypeId))
                    queryMap = queryMap.Where(x => x.ContractTypeId == Condition.ContractTypeId);
                if (!String.IsNullOrEmpty(Condition.DepartmentCode))
                    queryMap = queryMap.Where(x => x.DepartmentCode == Condition.DepartmentCode);
                if (!String.IsNullOrEmpty(Condition.RefId))
                    queryMap = queryMap.Where(x => x.RefId == Condition.RefId);
                if (!String.IsNullOrEmpty(Condition.ContractId))
                    queryMap = queryMap.Where(x => x.ContractId == Condition.ContractId);
                if (!String.IsNullOrEmpty(Condition.VendorName))
                    queryMap = queryMap.Where(x => x.VendorName == Condition.VendorName);
                if (!String.IsNullOrEmpty(Condition.BudgetCode))
                {
                    var contractPeriods = _repo.Context.ContractPeriods.Where(x => x.Used && x.PeriodBudgetcode.Contains(Condition.BudgetCode)).Select(x => x.IdContract);
                    queryMap = queryMap.Where(x => contractPeriods.Contains(x.IdContract));
                }
            }

            var pager = new Pager(queryMap.Count(), page, pageSize, Condition);
            pager.UrlAction = $"{_mySet.SubDomainServer}/Other/Search";

            var itemTake = queryMap.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
            var itemTakeMap = _mapper.Map<List<ContractStationDTO>>(itemTake);
            var response = new PaginationView<List<ContractStationDTO>>()
            {
                Items = itemTakeMap,
                Pager = pager
            };

            return response;
        }

    }
}
