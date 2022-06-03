using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using SmartContract.Infrastructure.Resources.ContractTypeBureau;
using SmartContract.Infrastructure.Resources.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.Enum;
using SmartContract.Infrastructure.Resources.Guarantee;
using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Infrastructure.Resources.Share.ServiceOther;
using SmartContract.Infrastructure.Wrapper;
using SmartContract.Utils;

namespace SmartContract.Web.Controllers
{
   
    public class ReportController : Controller
    {
        private IRepositoryWrapper _repo;

        public ReportController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        #region รายงาน1

        public async Task<IActionResult> Report01(SearchOptionContractReport Condition = null)
        {
            try
            {
                ContractReportMain response = new ContractReportMain();
                response.GetLookUp = new Infrastructure.Resources.Share.LookUpResource()
                {
                    BudgetYears = _repo.MasterData.BudgetYear(),
                    Months = _repo.MasterData.GetMonths()
                };

                response.ContractReport01 = await _repo.ContractRepo.ContractReport01(Condition);

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new ContractReportMain() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }
        }

        #endregion
        public IActionResult Report01_1()
        {
            return View();
        }

        public IActionResult Report01Detail()
        {
            return View();
        }

        public IActionResult Report02()
        {
            return View();
        }

        public IActionResult Report02Detail()
        {
            return View();
        }

        public IActionResult ComingSoon()
        {
            return View();
        }
    }
}
