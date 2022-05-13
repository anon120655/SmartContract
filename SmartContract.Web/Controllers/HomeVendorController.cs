using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Resources.ContractTypeBureau;
using SmartContract.Infrastructure.Resources.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Infrastructure.Wrapper;
using SmartContract.Utils;

namespace SmartContract.Web.Controllers
{
    [TypeFilter(typeof(AccessTokenAttribute))]
    public class HomeVendorController : Controller
    {
        private IRepositoryWrapper _repo;
        private readonly AppSettings _mySet;

        public HomeVendorController(IRepositoryWrapper repo, IOptions<AppSettings> settings)
        {
            _repo = repo;
            _mySet = settings.Value;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                TrackingCTVendorMain response = new TrackingCTVendorMain();

                response.DashboardMain = await _repo.CTVendorCondition.GetDashboardAll(new SearchOptionCTV() { GpType = "P" });

                return View(response);

            }
            catch (Exception ex)
            {
                return View(new TrackingCTVendorMain() { errorCheck = true, errorMessage = ex.Message });
            }
        }

        public async Task<IActionResult> Index2()
        {
            try
            {
                TrackingCTVendorMain response = new TrackingCTVendorMain();

                response.DashboardMain = await _repo.CTVendorCondition.GetDashboardAll(new SearchOptionCTV() { GpType = "G" });

                return View(response);

            }
            catch (Exception ex)
            {
                return View(new TrackingCTVendorMain() { errorCheck = true, errorMessage = ex.Message });
            }
        }

        public async Task<IActionResult> Tracking(int? page = 1, int pagesize = 10, String Style = null, SearchOptionCTV Condition = null)
        {
            try
            {
                TrackingCTVendorMain response = new TrackingCTVendorMain();

                response.Dashboards = await _repo.CTVendorCondition.GetDashboard(Condition);
                response.TrackingResource = _repo.CTVendorCondition.GetTracking(page, pagesize, Condition);

                return View(response);

            }
            catch (Exception ex)
            {
                return View(new TrackingCTVendorMain() { errorCheck = true, errorMessage = ex.Message });
            }
        }

        public async Task<IActionResult> Tracking2(int? page = 1, int pagesize = 10, String Style = null, SearchOptionCTV Condition = null)
        {
            try
            {
                TrackingCTVendorMain response = new TrackingCTVendorMain();

                response.Dashboards = await _repo.CTVendorCondition2.GetDashboard(Condition);
                response.TrackingResource = _repo.CTVendorCondition2.GetTracking(page, pagesize, Condition);

                return View(response);

            }
            catch (Exception ex)
            {
                return View(new TrackingCTVendorMain() { errorCheck = true, errorMessage = ex.Message });
            }
        }

        public IActionResult IndexBinding(int? page = 1, int pagesize = 10, SearchOptionStation Condition = null)
        {
            try
            {
                TrackingContractMain response = new TrackingContractMain();
                Condition.PathUrlAction = "HomeVendor/IndexBinding";
                response.TrackingSuccess = _repo.ContractRepo.GetTrackingBinding(page, pagesize, Condition);
                response.Condition = Condition;

                return View(response);

            }
            catch (Exception ex)
            {
                return View(new TrackingContractMain() { errorCheck = true, errorMessage = ex.Message });
            }
        }

        public async Task<IActionResult> TrackingBinding(int? page = 1, int pagesize = 10, SearchOptionStation Condition = null)
        {
            try
            {
                TrackingContractMain response = new TrackingContractMain();
                Condition.PathUrlAction = "HomeVendor/TrackingBinding";
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

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult coming_soon()
        {
            return View();
        }

        public async Task<IActionResult> ContractCondition(String style, String sector)
        {
            CTVendorMasterView response = new CTVendorMasterView();
            response = await _repo.CTVendorCondition.GetContractCondition(style, sector);

            return View(response);
        }

        [HttpPost]
        public IActionResult ContractCondition(CTVendorMasterView indata)
        {
            try
            {
                _repo.CTVendorCondition.SetContractCondition(indata);
                return Json(new ResultModelJson<Boolean>
                {
                    Status = true,
                    Result = true,
                    UrlRedirect = _repo.CTVendorCondition.SetUrlRedirect(indata),
                });
            }
            catch (Exception ex)
            {
                return Json(new ResultModelJson<Boolean>
                {
                    Status = false,
                    MessagError = ex.Message
                });
            }
        }

        public async Task<IActionResult> ContractCondition2(String style, String sector)
        {
            CTVendorMasterView response = new CTVendorMasterView();
            response = await _repo.CTVendorCondition2.GetContractCondition(style, sector);

            return View(response);
        }

        [HttpPost]
        public IActionResult ContractCondition2(CTVendorMasterView indata)
        {
            try
            {
                _repo.CTVendorCondition2.SetContractCondition(indata);
                return Json(new ResultModelJson<Boolean>
                {
                    Status = true,
                    Result = true,
                    UrlRedirect = _repo.CTVendorCondition2.SetUrlRedirect(indata),
                });
            }
            catch (Exception ex)
            {
                return Json(new ResultModelJson<Boolean>
                {
                    Status = false,
                    MessagError = ex.Message
                });
            }
        }

        public IActionResult ContractCreate()
        {
            return View();
        }
        public IActionResult ContractApproveStation()
        {
            return View();
        }
    }
}
