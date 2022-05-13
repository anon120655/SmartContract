using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Interfaces.Share;
using SmartContract.Infrastructure.Resources.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Infrastructure.Wrapper;
using SmartContract.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SmartContract.Web.Controllers
{
    public class ElectronicSignatureController : Controller
    {
        private IRepositoryWrapper _repo;
        private readonly AppSettings _mySet;
        private readonly IRazorViewToStringRenderer _razorView;

        public ElectronicSignatureController(IRepositoryWrapper repo, IOptions<AppSettings> settings, IRazorViewToStringRenderer razorView)
        {
            _repo = repo;
            _mySet = settings.Value;
            _razorView = razorView;
        }

        public async Task<IActionResult> SentMailSignature(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView model = new TAllMasterVendorView();
                String _PathRedirect = String.Empty;
                model.DomainName = _mySet.SubDomainServer;
                var pathView = $@"/Views/Shared/EmailTemplate/Signature/ElectronicSign.cshtml";
                if (indata.SendmailType.StartsWith("SN4"))
                {
                    pathView = $@"/Views/Shared/EmailTemplate/Signature/PaperSign.cshtml";
                }

                model.ParameterCondition = indata;

                if (indata.SendmailType == SendmailTypes.VendorWitness || indata.SendmailType == SendmailTypes.NhsoWitness || indata.SendmailType == SendmailTypes.NhsoWitnessP) model.BtnSubmit = "4";
                if (indata.SendmailType == SendmailTypes.VendorAuthority || indata.SendmailType == SendmailTypes.NhsoAuthority || indata.SendmailType == SendmailTypes.NhsoAuthorityP) model.BtnSubmit = "3";

                if (indata.SendmailType == SendmailTypes.VendorWitness || indata.SendmailType == SendmailTypes.VendorAuthority)
                {
                    _PathRedirect = _repo.ContractShare.SetUrlRedirect(model);
                    if (indata.ContractTypeId.Contains("01"))
                        model = await _repo.T01Repo.GetView(indata);
                    else if (indata.ContractTypeId.Contains("02"))
                        model = await _repo.T02Repo.GetView(indata);
                    else if (indata.ContractTypeId.Contains("03"))
                        model = await _repo.T03Repo.GetView(indata);
                    else if (indata.ContractTypeId.Contains("04"))
                        model = await _repo.T04Repo.GetView(indata);
                    else if (indata.ContractTypeId.Contains("05"))
                        model = await _repo.T05Repo.GetView(indata);
                    else if (indata.ContractTypeId.Contains("06"))
                        model = await _repo.T06Repo.GetView(indata);
                    else if (indata.ContractTypeId.Contains("07"))
                        model = await _repo.T07Repo.GetView(indata);
                    else if (indata.ContractTypeId.Contains("08"))
                        model = await _repo.T08Repo.GetView(indata);
                    else if (indata.ContractTypeId.Contains("09"))
                        model = await _repo.T09Repo.GetView(indata);
                    else if (indata.ContractTypeId.Contains("10"))
                        model = await _repo.T10Repo.GetView(indata);
                    else if (indata.ContractTypeId.Contains("11"))
                        model = await _repo.T11Repo.GetView(indata);
                    else if (indata.ContractTypeId.Contains("12"))
                        model = await _repo.T12Repo.GetView(indata);
                    else if (indata.ContractTypeId.Contains("13"))
                        model = await _repo.T13Repo.GetView(indata);
                    else if (indata.ContractTypeId.Contains("14"))
                        model = await _repo.T14Repo.GetView(indata);
                }
                else
                {
                    _PathRedirect = _repo.ContractShareNhso.SetUrlRedirectContract(model);
                    if (indata.ContractTypeId.Contains("01"))
                        model = await _repo.T01BuRepo.GetView(indata);
                    else if (indata.ContractTypeId.Contains("02"))
                        model = await _repo.T02BuRepo.GetView(indata);
                    else if (indata.ContractTypeId.Contains("03"))
                        model = await _repo.T03BuRepo.GetView(indata);
                    else if (indata.ContractTypeId.Contains("04"))
                        model = await _repo.T04BuRepo.GetView(indata);
                    else if (indata.ContractTypeId.Contains("05"))
                        model = await _repo.T05BuRepo.GetView(indata);
                    else if (indata.ContractTypeId.Contains("06"))
                        model = await _repo.T06BuRepo.GetView(indata);
                    else if (indata.ContractTypeId.Contains("07"))
                        model = await _repo.T07BuRepo.GetView(indata);
                    else if (indata.ContractTypeId.Contains("08"))
                        model = await _repo.T08BuRepo.GetView(indata);
                    else if (indata.ContractTypeId.Contains("09"))
                        model = await _repo.T09BuRepo.GetView(indata);
                    else if (indata.ContractTypeId.Contains("10"))
                        model = await _repo.T10BuRepo.GetView(indata);
                    else if (indata.ContractTypeId.Contains("11"))
                        model = await _repo.T11BuRepo.GetView(indata);
                    else if (indata.ContractTypeId.Contains("12"))
                        model = await _repo.T12BuRepo.GetView(indata);
                    else if (indata.ContractTypeId.Contains("13"))
                        model = await _repo.T13BuRepo.GetView(indata);
                    else if (indata.ContractTypeId.Contains("14"))
                        model = await _repo.T14BuRepo.GetView(indata);
                }

                model.UrlSignature = _repo.ContractShare.SetUrlSignature(model);

                var htmlBody = await _razorView.RenderViewToStringAsync(pathView, model);
                var emaildata = await _repo.ContractShare.GetSentMailSignature(model, htmlBody);
                await _repo.emailSender.SendEmail(emaildata);
                model.ResourceEmail = emaildata;
                await _repo.ContractShare.UpdateSignature(model);

                return Redirect(_PathRedirect);
            }
            catch (Exception ex)
            {
                return RedirectToAction("SystemNoti", "Authorize", new { message = ex.Message });
            }
        }

        public async Task<IActionResult> Signature(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response.CTVendor.GetLookUp = new LookUpResource()
                    {
                        SubDomainServer = _mySet.SubDomainServer
                    };

                    response = await _repo.ContractShare.ViewContractStation(response);
                    response = await _repo.ContractShare.ViewInfoPartnersOfContract(response, null);
                }

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Signature(TAllMasterVendorView indata)
        {
            try
            {
                var parmCon = indata.ParameterCondition;
                if (String.IsNullOrWhiteSpace(parmCon.SignatureData)) throw new Exception("Please a electronic signature.");

                var base64Signature = parmCon.SignatureData.Split(",")[1];
                var binarySignature = Convert.FromBase64String(base64Signature);

                MemoryStream stream = new MemoryStream(binarySignature);
                IFormFile file = new FormFile(stream, 0, binarySignature.Length, "signature", "signature.png");

                await _repo.ContractShare.SignatureUploadfile(file, indata);
                if (parmCon.SendmailType == SendmailTypes.VendorWitness || parmCon.SendmailType == SendmailTypes.NhsoWitness)
                    indata.BtnSubmit = "4";
                if (parmCon.SendmailType == SendmailTypes.VendorAuthority || parmCon.SendmailType == SendmailTypes.NhsoAuthority)
                    indata.BtnSubmit = "3";

                if (parmCon.SendmailType == SendmailTypes.VendorWitness || parmCon.SendmailType == SendmailTypes.VendorAuthority)
                    await _repo.ContractShare.UpdateSigner(indata);
                else
                    await _repo.ContractShareNhso.UpdateSigner(indata);

                indata = await _repo.ContractShare.ViewContractStation(indata);

                return Json(new ResultModelJson<TAllMasterVendorView>
                {
                    Status = true,
                    Result = indata,
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

        public async Task<IActionResult> SignatureComfirm(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;

                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {

                    response = await _repo.ContractShare.ViewInfoContract(response);
                    response = await _repo.ContractShare.ViewMasterFiles(response);
                    response = await _repo.ContractShare.ViewMasterSigners(response);
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
        public async Task<IActionResult> SignatureComfirm(TAllMasterVendorView indata)
        {
            try
            {
                var parmCon = indata.ParameterCondition;

                if (parmCon.SendmailType == SendmailTypes.VendorWitness || parmCon.SendmailType == SendmailTypes.VendorAuthority)
                    await _repo.ContractShare.UpdateSigner(indata);
                else
                    await _repo.ContractShareNhso.UpdateSigner(indata);

                indata = await _repo.ContractShare.ViewContractStation(indata);

                return Json(new ResultModelJson<TAllMasterVendorView>
                {
                    Status = true,
                    Result = indata,
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

        public async Task<IActionResult> PaperComfirm(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;

                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.ContractShare.ViewInfoContract(response);
                    response = await _repo.ContractShare.ViewMasterFiles(response);
                    response = await _repo.ContractShare.ViewMasterSigners(response);
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
        public async Task<IActionResult> PaperComfirm(TAllMasterVendorView indata)
        {
            try
            {
                var parmCon = indata.ParameterCondition;

                await _repo.ContractShareNhso.UpdateSigner(indata);
                indata = await _repo.ContractShare.ViewContractStation(indata);

                return Json(new ResultModelJson<TAllMasterVendorView>
                {
                    Status = true,
                    Result = indata,
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
