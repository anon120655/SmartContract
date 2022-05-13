using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Resources.ContractTypeBureau;
using SmartContract.Infrastructure.Wrapper;
using SmartContract.Web.Models;

namespace SmartContract.Web.Controllers
{
    [TypeFilter(typeof(AccessTokenAttribute))]
    public class HomeController : Controller
    {
        private IRepositoryWrapper _repo;
        private readonly AppSettings _mySet;

        public HomeController(IRepositoryWrapper repo, IOptions<AppSettings> settings)
        {
            _repo = repo;
            _mySet = settings.Value;
        }

        public async Task<IActionResult> IndexProposal(int? page = 1, int pagesize = 10, String Style = null, SearchOptionStation Condition = null)
        {
            try
            {
                TrackingContractMain response = new TrackingContractMain();
                response.DashboardsReqApp = await _repo.ContractRepo.GetDashboardReqApp();
                response.TrackingResourceApp = _repo.ContractRepo.GetTrackingBookReqApprove(page, pagesize, Condition);

                return View(response);

            }
            catch (Exception ex)
            {
                return View(new TrackingContractMain() { errorCheck = true, errorMessage = ex.Message });
            }
        }

        public async Task<IActionResult> Index(int? page = 1, int pagesize = 10, String Style = null, SearchOptionStation Condition = null)
        {
            try
            {
                TrackingContractMain response = new TrackingContractMain();
                if (String.IsNullOrEmpty(Condition.Menu) && String.IsNullOrEmpty(Condition.StationEn))
                    response.DashboardsContract = await _repo.ContractRepo.GetDashboardsContract();

                response.TrackingContractResource = _repo.ContractRepo.GetTrackingContract(page, pagesize, Condition);
                response.Condition = Condition;

                return View(response);

            }
            catch (Exception ex)
            {
                return View(new TrackingContractMain() { errorCheck = true, errorMessage = ex.Message });
            }
        }

        public async Task<IActionResult> IndexBinding(int? page = 1, int pagesize = 10, SearchOptionStation Condition = null)
        {
            try
            {
                TrackingContractMain response = new TrackingContractMain();
                Condition.PathUrlAction = "Home/IndexBinding";
                response.DashboardBinding = await _repo.ContractRepo.GetDashboardBinding(Condition);
                response.TrackingSuccess = _repo.ContractRepo.GetTrackingBinding(page, pagesize, Condition);
                response.Condition = Condition;

                return View(response);

            }
            catch (Exception ex)
            {
                return View(new TrackingContractMain() { errorCheck = true, errorMessage = ex.Message });
            }
        }

        public async Task<IActionResult> IndexVendorLink(int? page = 1, int pagesize = 10, String Style = null, SearchOptionStation Condition = null)
        {
            try
            {
                TrackingContractMain response = new TrackingContractMain();
                Condition.PathUrlAction = "Home/IndexVendorLink";
                response.DashboardsVendorLink = await _repo.ContractRepo.GetDashboardVendorLink(Condition);
                response.TrackingVendorLinkResource = _repo.ContractRepo.GetTrackingVendorLink(page, pagesize, Condition);
                response.Condition = Condition;

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TrackingContractMain() { errorCheck = true, errorMessage = ex.Message });
            }
        }

        public IActionResult TrackingProposal()
        {
            return View();
        }

        public IActionResult Tracking()
        {
            return View();
        }

        public async Task<IActionResult> Dashboard()
        {
            try
            {
                DashboardHomeMain response = new DashboardHomeMain();

                response = await _repo.ContractRepo.GetDashboardHome();

                return View(response);

            }
            catch (Exception ex)
            {
                return View(new TrackingContractMain() { errorCheck = true, errorMessage = ex.Message });
            }
        }

        public IActionResult ComingSoon()
        {
            return View();
        }

        public IActionResult ContractCondition()
        {
            return View();
        }

        public IActionResult ContractCreate()
        {
            return View();
        }

        public IActionResult ContractApproveStation()
        {
            return View();
        }

        public IActionResult SystemNoti(string message)
        {
            string exceptionMessage = message != null ? message : string.Empty;
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            if (exceptionFeature != null)
            {
                var exceptionError = exceptionFeature.Error;
                exceptionMessage = exceptionFeature.Error.Message;
            }
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                MessageError = exceptionMessage
            }); ;
        }

    }
}
