using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Resources.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.Other;
using SmartContract.Infrastructure.Wrapper;

namespace SmartContract.Web.Controllers
{

    public class OtherController : Controller
    {
        private IRepositoryWrapper _repo;
        private readonly AppSettings _mySet;

        public OtherController(IRepositoryWrapper repo, IOptions<AppSettings> settings)
        {
            _repo = repo;
            _mySet = settings.Value;
        }

        public async Task<IActionResult> Search(int? page = 1, int pagesize = 10, String Style = null, OtherSearchOption Condition = null)
        {
            try
            {
                SearchMain response = new SearchMain();
                response.GetLookUp = new Infrastructure.Resources.Share.LookUpResource()
                {
                    BudgetYears = _repo.MasterData.BudgetYear(),
                    ContractTypes = await _repo.MasterData.ContractTypes(),
                    LkDepartmentList = await _repo.MasterData.LKDepartments()
                };
                response.SearchResource = _repo.OtherRepo.GetSearch(page, pagesize, Condition);

                return View(response);

            }
            catch (Exception ex)
            {
                return View(new SearchMain() { errorCheck = true, errorMessage = ex.Message });
            }
        }


    }
}
