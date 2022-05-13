using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Interfaces.Share;
using SmartContract.Infrastructure.Resources.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Infrastructure.Wrapper;
using SmartContract.Utils;
using System;
using System.Threading.Tasks;

namespace SmartContract.Web.Controllers
{
    public class AuthorizeAllowController : Controller
    {
        private IRepositoryWrapper _repo;
        private readonly AppSettings _mySet;
        private readonly IRazorViewToStringRenderer _razorView;

        public AuthorizeAllowController(IRepositoryWrapper repo, IOptions<AppSettings> settings, IRazorViewToStringRenderer razorView)
        {
            _repo = repo;
            _mySet = settings.Value;
            _razorView = razorView;
        }

        public async Task<IActionResult> MailAppReqDetail(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.ContractShare.ViewMasterFiles(response);
                    response = await _repo.ContractShare.ViewRequestForApproval(response);
                    response = await _repo.ContractShare.ViewApprovalReqStation(response);
                    response = await _repo.ContractShare.ViewContractStation(response);
                }

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }
        }

        [HttpPost]
        public async Task<IActionResult> MailAppReqDetail([FromForm] TAllMasterVendorView indata)
        {
            try
            {
                using (var _transaction = _repo.BeginTransaction())
                {
                    await _repo.ContractShareNhso.UpdateStatusBookReq(indata);
                    await _repo.ContractShareNhso.ViewRequestForApproval(indata);
                    indata = await _repo.ContractShare.ViewContractStation(indata);

                    _transaction.Commit();

                    return Json(new ResultModelJson<TAllMasterVendorView>
                    {
                        Status = true,
                        Result = indata,
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new ResultModelJson<Boolean>
                {
                    MessagError = GeneralUtils.GetExMessage(ex)
                });
            }
        }

        public async Task<IActionResult> SentMainToConsider(ParameterCondition indata)
        {
            try
            {
                using (var _transaction = _repo.BeginTransaction())
                {
                    TAllMasterVendorView model = new TAllMasterVendorView();

                    model.ParameterCondition = indata;

                    if (indata.ContractTypeId.Contains("11"))
                        model = await _repo.T11BuRepo.GetView(indata);
                    else if (indata.ContractTypeId.Contains("12"))
                        model = await _repo.T12BuRepo.GetView(indata);
                    else if (indata.ContractTypeId.Contains("13"))
                        model = await _repo.T13BuRepo.GetView(indata);
                    else if (indata.ContractTypeId.Contains("14"))
                        model = await _repo.T14BuRepo.GetView(indata);

                    model.DomainName = _mySet.SubDomainServer;
                    var pathView = $@"/Views/Shared/EmailTemplate/ApproveReq/ReqCheckConsider.cshtml";
                    var htmlBody = await _razorView.RenderViewToStringAsync(pathView, model);
                    var emaildata = await _repo.ContractShareNhso.GetSentMainToConsider(model, htmlBody);
                    await _repo.emailSender.SendEmail(emaildata);

                    await _repo.ContractShareNhso.UpdateStatusBookReqMailStatus(model, true);


                    _transaction.Commit();

                    return Json(new ResultModelJson<Boolean>
                    {
                        Status = true,
                        Result = true,
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new ResultModelJson<Boolean>
                {
                    MessagError = GeneralUtils.GetExMessage(ex)
                });
            }
        }

        public async Task<IActionResult> MailAppReqConsiderDetail(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.ContractShare.ViewMasterFiles(response);
                    response = await _repo.ContractShare.ViewApprovalReqStation(response);
                    response = await _repo.ContractShare.ViewContractStation(response);
                }

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }
        }

        [HttpPost]
        public async Task<IActionResult> MailAppReqConsiderDetail([FromForm] TAllMasterVendorView indata)
        {
            try
            {
                using (var _transaction = _repo.BeginTransaction())
                {
                    await _repo.ContractShareNhso.UpdateStatusBookReq(indata);
                    indata = await _repo.ContractShare.ViewContractStation(indata);
                    _transaction.Commit();

                    return Json(new ResultModelJson<TAllMasterVendorView>
                    {
                        Status = true,
                        Result = indata,
                    });
                }
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
