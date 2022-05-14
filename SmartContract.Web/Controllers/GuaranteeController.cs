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
		public IActionResult Tracking(int? page = 1, int pagesize = 10, SearchOptionLG Condition = null)
		{
			try
			{
				TrackingGuaranteeMain response = new TrackingGuaranteeMain();
				response.TrackingStation = _repo.GuaranteeRepo.GetTrackingLG(page, pagesize, Condition);
				response.Condition = Condition;

				return View(response);

			}
			catch (Exception ex)
			{
				return View(new TrackingGuaranteeMain() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
			}
		}

		public IActionResult Tracking2(int? page = 1, int pagesize = 10, SearchOptionLG Condition = null)
		{
			try
			{
				TrackingGuaranteeMain response = new TrackingGuaranteeMain();
				response.VGuaranteeLgContract = _repo.GuaranteeRepo.GetTrackingSearchLG(page, pagesize, Condition);
				response.Condition = Condition;

				return View(response);

			}
			catch (Exception ex)
			{
				return View(new TrackingGuaranteeMain() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
			}
		}
		#endregion

		//สร้างคำขอหนังสือค้ำประกัน L/G
		public async Task<IActionResult> Create(ParameterCreate indata)
		{
			try
			{
				ELGCreateMain response = new ELGCreateMain();

				String _lgNumber = "00019/200008/0211/65"; //SecurityRepo.Decrypt(indata.lgNumber)

				var lGDocumentSearch = await _repo.ServiceOther.eLGDocumentSearch(new eLGDocumentSearchRequest()
				{
					lgNumber = _lgNumber
				});

				if (lGDocumentSearch.status != "200" && lGDocumentSearch.message != null)
				{
					throw new Exception(lGDocumentSearch.message);
				}

				if (lGDocumentSearch.result == null || lGDocumentSearch.result.Count == 0)
				{
					throw new Exception($"{indata.lgNumber} Not Found.");
				}
				if (lGDocumentSearch.result.Count != 1)
				{
					throw new Exception("Found more than 1 item.");
				}

				var lGData = lGDocumentSearch.result[0];

				response.Request.taxId = lGData.taxId;
				response.Request.lgNumber = lGData.lgNumber;
				response.Request.requesterNameTh = lGData.requesterNameTh;
				response.Request.contractNo = SecurityRepo.Decrypt(indata.contractNo);

				if (indata.contractDate != null)
				{
					var _contractDate = GeneralUtils.DateToEn(indata.contractDate, "dd/MM/yyyy HH:mm:ss");
					response.Request.contractDate = GeneralUtils.DateToThString(_contractDate);
				}

				if (lGData.effectiveDateStart != null)
				{
					var _effectiveDateStart = GeneralUtils.DateToEn(lGData.effectiveDateStart, "yyyy-MM-dd");
					response.Request.effectiveDateStart = GeneralUtils.DateToThString(_effectiveDateStart);
				}
				if (lGData.effectiveDateEnd != null)
				{
					var _effectiveDateEnd = GeneralUtils.DateToEn(lGData.effectiveDateEnd, "yyyy-MM-dd");
					response.Request.effectiveDateEnd = GeneralUtils.DateToThString(_effectiveDateEnd);
				}

				response.Request.lgAmount = lGData.lgAmount;
				response.Request.guaranteeTypeId = lGData.guaranteeTypeId;
				response.Request.contractTypeId = lGData.contractTypeId;
				response.Request.contractDetail = lGData.contractDetail;
				response.Request.comment = lGData.comment;
				response.Request.guranteeTypeDesc = lGData.guranteeTypeDesc;
				response.Request.contractTypeDesc = lGData.contractTypeDesc;
				response.Request.hospitalCode = lGData.hospitalCode;
				response.Request.hospitalName = lGData.hospitalName;

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
					UrlRedirect = "Tracking"
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
