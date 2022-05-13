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

	public class GuaranteeController : Controller
	{
		private IRepositoryWrapper _repo;

		public GuaranteeController(IRepositoryWrapper repo)
		{
			_repo = repo;
		}

		#region หน้าติดตามทุกประเภท
		public IActionResult Tracking(int? page = 1, int pagesize = 10, SearchOptionStation Condition = null)
		{
			try
			{
				TrackingGuaranteeMain response = new TrackingGuaranteeMain();
				Condition.PathUrlAction = "Guarantee/GuaranteeNew";
				response.TrackingGuaranteeNew = _repo.GuaranteeRepo.GetTrackingGuaranteeNew(page, pagesize, Condition);
				response.Condition = Condition;

				return View(response);

			}
			catch (Exception ex)
			{
				return View(new TrackingGuaranteeMain() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
			}
		}

		public IActionResult Tracking2(int? page = 1, int pagesize = 10, SearchOptionStation Condition = null)
		{
			try
			{
				TrackingGuaranteeMain response = new TrackingGuaranteeMain();
				Condition.PathUrlAction = "Guarantee/GuaranteeNew";
				response.TrackingGuaranteeNew = _repo.GuaranteeRepo.GetTrackingGuaranteeNew(page, pagesize, Condition);
				response.Condition = Condition;

				return View(response);

			}
			catch (Exception ex)
			{
				return View(new TrackingGuaranteeMain() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
			}
		}

		public IActionResult Tracking3(int? page = 1, int pagesize = 10, SearchOptionStation Condition = null)
		{
			try
			{
				TrackingGuaranteeMain response = new TrackingGuaranteeMain();
				Condition.PathUrlAction = "Guarantee/GuaranteeNew";
				response.TrackingGuaranteeNew = _repo.GuaranteeRepo.GetTrackingGuaranteeNew(page, pagesize, Condition);
				response.Condition = Condition;

				return View(response);

			}
			catch (Exception ex)
			{
				return View(new TrackingGuaranteeMain() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
			}
		}
		#endregion

		#region รายการขอต่ออายุ
		public async Task<IActionResult> GuaranteeRenew(ParameterCondition indata)
		{
			try
			{
				TAllMasterVendorView response = new TAllMasterVendorView();
				response.ParameterCondition = indata;

				String _ContractTypeId = SecurityRepo.Decrypt(indata.ContractTypeIdEn);
				if (_ContractTypeId == "01")
					response = await _repo.T01BuRepo.GetView(indata);
				else if (_ContractTypeId == "03")
					response = await _repo.T03BuRepo.GetView(indata);
				else if (_ContractTypeId == "04")
					response = await _repo.T04BuRepo.GetView(indata);
				else if (_ContractTypeId == "11")
					response = await _repo.T11BuRepo.GetView(indata);

				response.ObjectState = TObjectState.Update;

				return View(response);
			}
			catch (Exception ex)
			{
				return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
			}
		}

		[HttpPost]
		public async Task<IActionResult> GuaranteeRenew([FromForm] TAllMasterVendorView indata)
		{
			try
			{
				_repo.GuaranteeRepo.Validate(indata);
				indata = await _repo.GuaranteeRepo.UpdateReNewAsync(indata);

				indata = await _repo.ContractShare.ViewContractStation(indata);

				return Json(new ResultModelJson<TAllMasterVendorView>
				{
					Status = true,
					Result = indata,
					UrlRedirect = _repo.GuaranteeRepo.SetUrlRedirect(indata)
				});
			}
			catch (Exception ex)
			{
				return Json(new ResultModelJson<Boolean>
				{
					MessagError = GeneralUtils.GetExMessage(ex)
				});
			}
		}
		#endregion

		#region รายการขอคืน
		public async Task<IActionResult> GuaranteeReturn(ParameterCondition indata)
		{
			try
			{
				TAllMasterVendorView response = new TAllMasterVendorView();
				response.ParameterCondition = indata;

				String _ContractTypeId = SecurityRepo.Decrypt(indata.ContractTypeIdEn);
				if (_ContractTypeId == "01")
					response = await _repo.T01BuRepo.GetView(indata);
				else if (_ContractTypeId == "03")
					response = await _repo.T03BuRepo.GetView(indata);
				else if (_ContractTypeId == "04")
					response = await _repo.T04BuRepo.GetView(indata);
				else if (_ContractTypeId == "11")
					response = await _repo.T11BuRepo.GetView(indata);

				response.ObjectState = TObjectState.Update;

				return View(response);
			}
			catch (Exception ex)
			{
				return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
			}
		}

		[HttpPost]
		public async Task<IActionResult> GuaranteeReturn([FromForm] TAllMasterVendorView indata)
		{
			try
			{
				_repo.GuaranteeRepo.Validate(indata);
				indata = await _repo.GuaranteeRepo.UpdateReturnAsync(indata);

				indata = await _repo.ContractShare.ViewContractStation(indata);

				return Json(new ResultModelJson<TAllMasterVendorView>
				{
					Status = true,
					Result = indata,
					UrlRedirect = _repo.GuaranteeRepo.SetUrlRedirect(indata)
				});
			}
			catch (Exception ex)
			{
				return Json(new ResultModelJson<Boolean>
				{
					MessagError = GeneralUtils.GetExMessage(ex)
				});
			}
		}
		#endregion

		#region รายการขอเคลม
		public async Task<IActionResult> GuaranteeClaim(ParameterCondition indata)
		{
			try
			{
				TAllMasterVendorView response = new TAllMasterVendorView();
				response.ParameterCondition = indata;

				String _ContractTypeId = SecurityRepo.Decrypt(indata.ContractTypeIdEn);
				if (_ContractTypeId == "01")
					response = await _repo.T01BuRepo.GetView(indata);
				else if (_ContractTypeId == "03")
					response = await _repo.T03BuRepo.GetView(indata);
				else if (_ContractTypeId == "04")
					response = await _repo.T04BuRepo.GetView(indata);
				else if (_ContractTypeId == "11")
					response = await _repo.T11BuRepo.GetView(indata);

				response.ObjectState = TObjectState.Update;

				return View(response);
			}
			catch (Exception ex)
			{
				return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
			}
		}

		[HttpPost]
		public async Task<IActionResult> GuaranteeClaim([FromForm] TAllMasterVendorView indata)
		{
			try
			{
				_repo.GuaranteeRepo.Validate(indata);
				indata = await _repo.GuaranteeRepo.UpdateClaimAsync(indata);

				indata = await _repo.ContractShare.ViewContractStation(indata);

				return Json(new ResultModelJson<TAllMasterVendorView>
				{
					Status = true,
					Result = indata,
					UrlRedirect = _repo.GuaranteeRepo.SetUrlRedirect(indata)
				});
			}
			catch (Exception ex)
			{
				return Json(new ResultModelJson<Boolean>
				{
					MessagError = GeneralUtils.GetExMessage(ex)
				});
			}
		}
		#endregion

		public async Task<IActionResult> GuaranteeReport(SearchOptionGuarantee Condition = null)
		{
			try
			{
				GuaranteeReportMain response = new GuaranteeReportMain();
				response.GetLookUp = new Infrastructure.Resources.Share.LookUpResource()
				{
					BudgetYears = _repo.MasterData.BudgetYear(),
					Months = _repo.MasterData.GetMonths()
				};

				response.GuaranteeReportView = await _repo.GuaranteeRepo.GuaranteeReportView(Condition);

				return View(response);
			}
			catch (Exception ex)
			{
				return View(new GuaranteeReportMain() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
			}
		}

		//สร้างคำขอหนังสือค้ำประกัน L/G
		public async Task<IActionResult> Create()
		{
			try
			{
				ELGCreateMain response = new ELGCreateMain();


				return View(response);
			}
			catch (Exception ex)
			{
				return View(new ELGCreateMain() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
			}
		}

		public async Task<IActionResult> Create2()
		{
			try
			{
				ELGCreateMain response = new ELGCreateMain();


				return View(response);
			}
			catch (Exception ex)
			{
				return View(new ELGCreateMain() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
			}
		}


		[HttpPost]
		public async Task<IActionResult> Create(ELGCreateMain indata)
		{
			try
			{
				var response = await _repo.ServiceOther.eLGCreate(indata.Request);
				if (response.respCode != "000")
				{
					throw new Exception(response.respDesc);
				}
				if (!String.IsNullOrEmpty(response.error) && !String.IsNullOrEmpty(response.error_description))
				{
					throw new Exception(response.error_description);
				}

				return Json(new ResultModelJson<eLGCreateResponse>
				{
					Status = true,
					Result = response,
					UrlRedirect = "Tracking?MenuEn=-jBFSc26KiogIA8Lv0yuvQ"
				});
			}
			catch (Exception ex)
			{
				return Json(new ResultModelJson<Boolean>
				{
					MessagError = GeneralUtils.GetExMessage(ex)
				});
			}
		}

	}
}
