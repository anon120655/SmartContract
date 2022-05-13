using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Interfaces.Share;
using SmartContract.Infrastructure.Repositorys.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.Enum;
using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Infrastructure.Wrapper;
using SmartContract.Utils;

namespace SmartContract.Web.Controllers
{
    [TypeFilter(typeof(AccessTokenAttribute))]
    public class ContractTypeVendorController : Controller
    {
        private IRepositoryWrapper _repo;
        private readonly AppSettings _mySet;
        private readonly IRazorViewToStringRenderer _razorView;

        public ContractTypeVendorController(IRepositoryWrapper repo, IOptions<AppSettings> settings, IRazorViewToStringRenderer razorView)
        {
            _repo = repo;
            _mySet = settings.Value;
            _razorView = razorView;
        }

        //(01) สัญญาให้บริการสาธารณสุขฯ
        public async Task<IActionResult> T01(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.T01Repo.GetView(indata);
                    response.ObjectState = TObjectState.Update;
                }
                else
                {
                    response = await _repo.T01Repo.InitialData(response);
                    response.ObjectState = TObjectState.Create;
                }

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }

        }

        [HttpPost]
        public async Task<IActionResult> T01([FromForm] TAllMasterVendorView indata)
        {
            try
            {
                int btnSubmit = int.Parse(indata.BtnSubmit);
                if (btnSubmit == (int)ButtonState.Draft || btnSubmit == (int)ButtonState.Forward)
                {
                    _repo.T01Repo.Validate(indata);
                    if (indata.ObjectState == TObjectState.Create)
                    {
                        indata = await _repo.T01Repo.CreateAsync(indata);
                    }
                    else if (indata.ObjectState == TObjectState.Update)
                    {
                        indata = await _repo.T01Repo.UpdateAsync(indata);
                    }
                    else
                        await _repo.T01Repo.DeleteAsync(indata);
                }
                else if (btnSubmit == (int)ButtonState.Signer || btnSubmit == (int)ButtonState.SignerWitness)
                {
                    await _repo.ContractShare.UpdateSigner(indata);
                }
                else if (btnSubmit == (int)ButtonState.T0_CANCEL || btnSubmit == (int)ButtonState.T1_EDIT
                    || btnSubmit == (int)ButtonState.T2_CANCEL
                    || btnSubmit == (int)ButtonState.T3_EXPAND
                    || btnSubmit == (int)ButtonState.T4_CLOSEPROJECT
                    || btnSubmit == (int)ButtonState.T5_TERMINATE)
                {
                    await _repo.ContractShare.UpdateRequestBinding(indata);
                }

                return Json(new ResultModelJson<Boolean>
                {
                    Status = true,
                    Result = true,
                    UrlRedirect = _repo.ContractShare.SetUrlRedirect(indata)
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

        //(02) ข้อตกลงให้บริการสาธารณสุขฯ
        public async Task<IActionResult> T02(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.T02Repo.GetView(indata);
                    response.ObjectState = TObjectState.Update;
                }
                else
                {
                    response = await _repo.T02Repo.InitialData(response);
                    response.ObjectState = TObjectState.Create;
                }

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }

        }

        [HttpPost]
        public async Task<IActionResult> T02([FromForm] TAllMasterVendorView indata)
        {
            try
            {
                int btnSubmit = int.Parse(indata.BtnSubmit);
                if (btnSubmit == (int)ButtonState.Draft || btnSubmit == (int)ButtonState.Forward)
                {
                    _repo.T02Repo.Validate(indata);
                    if (indata.ObjectState == TObjectState.Create)
                    {
                        indata = await _repo.T02Repo.CreateAsync(indata);
                    }
                    else if (indata.ObjectState == TObjectState.Update)
                    {
                        indata = await _repo.T02Repo.UpdateAsync(indata);
                    }
                    else
                        await _repo.T02Repo.DeleteAsync(indata);
                }
                else if (btnSubmit == (int)ButtonState.Signer || btnSubmit == (int)ButtonState.SignerWitness)
                {
                    await _repo.ContractShare.UpdateSigner(indata);
                }
                else if (btnSubmit == (int)ButtonState.T0_CANCEL || btnSubmit == (int)ButtonState.T1_EDIT
                    || btnSubmit == (int)ButtonState.T2_CANCEL
                    || btnSubmit == (int)ButtonState.T3_EXPAND
                    || btnSubmit == (int)ButtonState.T4_CLOSEPROJECT
                    || btnSubmit == (int)ButtonState.T5_TERMINATE)
                {
                    await _repo.ContractShare.UpdateRequestBinding(indata);
                }

                indata.ParameterCondition.Sector = Sectors.Government;
                return Json(new ResultModelJson<Boolean>
                {
                    Status = true,
                    Result = true,
                    UrlRedirect = _repo.ContractShare.SetUrlRedirect(indata)
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

        //(03) สัญญาให้บริการฯ(ศูนย์สำรองเตียง)
        public async Task<IActionResult> T03(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.T03Repo.GetView(indata);
                    response.ObjectState = TObjectState.Update;
                }
                else
                {
                    response = await _repo.T03Repo.InitialData(response);
                    response.ObjectState = TObjectState.Create;
                }

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }

        }

        [HttpPost]
        public async Task<IActionResult> T03([FromForm] TAllMasterVendorView indata)
        {
            try
            {
                int btnSubmit = int.Parse(indata.BtnSubmit);
                if (btnSubmit == (int)ButtonState.Draft || btnSubmit == (int)ButtonState.Forward)
                {
                    _repo.T03Repo.Validate(indata);
                    if (indata.ObjectState == TObjectState.Create)
                    {
                        indata = await _repo.T03Repo.CreateAsync(indata);
                    }
                    else if (indata.ObjectState == TObjectState.Update)
                    {
                        indata = await _repo.T03Repo.UpdateAsync(indata);
                    }
                    else
                        await _repo.T03Repo.DeleteAsync(indata);
                }
                else if (btnSubmit == (int)ButtonState.Signer || btnSubmit == (int)ButtonState.SignerWitness)
                {
                    await _repo.ContractShare.UpdateSigner(indata);
                }
                else if (btnSubmit == (int)ButtonState.T0_CANCEL || btnSubmit == (int)ButtonState.T1_EDIT
                    || btnSubmit == (int)ButtonState.T2_CANCEL
                    || btnSubmit == (int)ButtonState.T3_EXPAND
                    || btnSubmit == (int)ButtonState.T4_CLOSEPROJECT
                    || btnSubmit == (int)ButtonState.T5_TERMINATE)
                {
                    await _repo.ContractShare.UpdateRequestBinding(indata);
                }


                return Json(new ResultModelJson<Boolean>
                {
                    Status = true,
                    Result = true,
                    UrlRedirect = _repo.ContractShare.SetUrlRedirect(indata)
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

        //(04) สัญญาให้บริการฯ(ศูนย์สำรองเตียง)เฉพาะด้าน
        public async Task<IActionResult> T04(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.T04Repo.GetView(indata);
                    response.ObjectState = TObjectState.Update;
                }
                else
                {
                    response = await _repo.T04Repo.InitialData(response);
                    response.ObjectState = TObjectState.Create;
                }

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }

        }

        [HttpPost]
        public async Task<IActionResult> T04([FromForm] TAllMasterVendorView indata)
        {
            try
            {
                int btnSubmit = int.Parse(indata.BtnSubmit);
                if (btnSubmit == (int)ButtonState.Draft || btnSubmit == (int)ButtonState.Forward)
                {
                    _repo.T04Repo.Validate(indata);
                    if (indata.ObjectState == TObjectState.Create)
                    {
                        indata = await _repo.T04Repo.CreateAsync(indata);
                    }
                    else if (indata.ObjectState == TObjectState.Update)
                    {
                        indata = await _repo.T04Repo.UpdateAsync(indata);
                    }
                    else
                        await _repo.T04Repo.DeleteAsync(indata);
                }
                else if (btnSubmit == (int)ButtonState.Signer || btnSubmit == (int)ButtonState.SignerWitness)
                {
                    await _repo.ContractShare.UpdateSigner(indata);
                }
                else if (btnSubmit == (int)ButtonState.T0_CANCEL || btnSubmit == (int)ButtonState.T1_EDIT
                    || btnSubmit == (int)ButtonState.T2_CANCEL
                    || btnSubmit == (int)ButtonState.T3_EXPAND
                    || btnSubmit == (int)ButtonState.T4_CLOSEPROJECT
                    || btnSubmit == (int)ButtonState.T5_TERMINATE)
                {
                    await _repo.ContractShare.UpdateRequestBinding(indata);
                }


                return Json(new ResultModelJson<Boolean>
                {
                    Status = true,
                    Result = true,
                    UrlRedirect = _repo.ContractShare.SetUrlRedirect(indata)
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

        //(05) ข้อตกลงกองทุนฟื้นฟูฯจังหวัด
        public async Task<IActionResult> T05(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.T05Repo.GetView(indata);
                    response.ObjectState = TObjectState.Update;
                }
                else
                {
                    response = await _repo.T05Repo.InitialData(response);
                    response.ObjectState = TObjectState.Create;
                }

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }

        }

        [HttpPost]
        public async Task<IActionResult> T05([FromForm] TAllMasterVendorView indata)
        {
            try
            {
                int btnSubmit = int.Parse(indata.BtnSubmit);
                if (btnSubmit == (int)ButtonState.Draft || btnSubmit == (int)ButtonState.Forward)
                {
                    _repo.T05Repo.Validate(indata);
                    if (indata.ObjectState == TObjectState.Create)
                    {
                        indata = await _repo.T05Repo.CreateAsync(indata);
                    }
                    else if (indata.ObjectState == TObjectState.Update)
                    {
                        indata = await _repo.T05Repo.UpdateAsync(indata);
                    }
                    else
                        await _repo.T05Repo.DeleteAsync(indata);
                }
                else if (btnSubmit == (int)ButtonState.Signer || btnSubmit == (int)ButtonState.SignerWitness)
                {
                    await _repo.ContractShare.UpdateSigner(indata);
                }
                else if (btnSubmit == (int)ButtonState.T0_CANCEL || btnSubmit == (int)ButtonState.T1_EDIT
                    || btnSubmit == (int)ButtonState.T2_CANCEL
                    || btnSubmit == (int)ButtonState.T3_EXPAND
                    || btnSubmit == (int)ButtonState.T4_CLOSEPROJECT
                    || btnSubmit == (int)ButtonState.T5_TERMINATE)
                {
                    await _repo.ContractShare.UpdateRequestBinding(indata);
                }

                indata.ParameterCondition.Sector = Sectors.Government;
                return Json(new ResultModelJson<Boolean>
                {
                    Status = true,
                    Result = true,
                    UrlRedirect = _repo.ContractShare.SetUrlRedirect(indata)
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

        //(06) สัญญาให้บริการฯตามกิจกรรมบริการ
        public async Task<IActionResult> T06(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.T06Repo.GetView(indata);
                    response.ObjectState = TObjectState.Update;
                }
                else
                {
                    response = await _repo.T06Repo.InitialData(response);
                    response.ObjectState = TObjectState.Create;
                }

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }

        }

        [HttpPost]
        public async Task<IActionResult> T06([FromForm] TAllMasterVendorView indata)
        {
            try
            {
                int btnSubmit = int.Parse(indata.BtnSubmit);
                if (btnSubmit == (int)ButtonState.Draft || btnSubmit == (int)ButtonState.Forward)
                {
                    _repo.T06Repo.Validate(indata);
                    if (indata.ObjectState == TObjectState.Create)
                    {
                        indata = await _repo.T06Repo.CreateAsync(indata);
                    }
                    else if (indata.ObjectState == TObjectState.Update)
                    {
                        indata = await _repo.T06Repo.UpdateAsync(indata);
                    }
                    else
                        await _repo.T06Repo.DeleteAsync(indata);
                }
                else if (btnSubmit == (int)ButtonState.Signer || btnSubmit == (int)ButtonState.SignerWitness)
                {
                    await _repo.ContractShare.UpdateSigner(indata);
                }
                else if (btnSubmit == (int)ButtonState.T0_CANCEL || btnSubmit == (int)ButtonState.T1_EDIT
                    || btnSubmit == (int)ButtonState.T2_CANCEL
                    || btnSubmit == (int)ButtonState.T4_CLOSEPROJECT
                    || btnSubmit == (int)ButtonState.T5_TERMINATE)
                {
                    await _repo.ContractShare.UpdateRequestBinding(indata);
                }


                return Json(new ResultModelJson<Boolean>
                {
                    Status = true,
                    Result = true,
                    UrlRedirect = _repo.ContractShare.SetUrlRedirect(indata)
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

        //(07) ข้อตกลงให้บริการฯตามกิจกรรมบริการ
        public async Task<IActionResult> T07(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.T07Repo.GetView(indata);
                    response.ObjectState = TObjectState.Update;
                }
                else
                {
                    response = await _repo.T07Repo.InitialData(response);
                    response.ObjectState = TObjectState.Create;
                }

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }

        }

        [HttpPost]
        public async Task<IActionResult> T07([FromForm] TAllMasterVendorView indata)
        {
            try
            {
                int btnSubmit = int.Parse(indata.BtnSubmit);
                if (btnSubmit == (int)ButtonState.Draft || btnSubmit == (int)ButtonState.Forward)
                {
                    _repo.T07Repo.Validate(indata);
                    if (indata.ObjectState == TObjectState.Create)
                    {
                        indata = await _repo.T07Repo.CreateAsync(indata);
                    }
                    else if (indata.ObjectState == TObjectState.Update)
                    {
                        indata = await _repo.T07Repo.UpdateAsync(indata);
                    }
                    else
                        await _repo.T07Repo.DeleteAsync(indata);
                }
                else if (btnSubmit == (int)ButtonState.Signer || btnSubmit == (int)ButtonState.SignerWitness)
                {
                    await _repo.ContractShare.UpdateSigner(indata);
                }
                else if (btnSubmit == (int)ButtonState.T0_CANCEL || btnSubmit == (int)ButtonState.T1_EDIT
                    || btnSubmit == (int)ButtonState.T2_CANCEL
                    || btnSubmit == (int)ButtonState.T4_CLOSEPROJECT
                    || btnSubmit == (int)ButtonState.T5_TERMINATE)
                {
                    await _repo.ContractShare.UpdateRequestBinding(indata);
                }

                indata.ParameterCondition.Sector = Sectors.Government;
                return Json(new ResultModelJson<Boolean>
                {
                    Status = true,
                    Result = true,
                    UrlRedirect = _repo.ContractShare.SetUrlRedirect(indata)
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

        //(08) สัญญาให้บริการฯตามกิจกรรมบริการ ไตเทียม
        public async Task<IActionResult> T08(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.T08Repo.GetView(indata);
                    response.ObjectState = TObjectState.Update;
                }
                else
                {
                    response = await _repo.T08Repo.InitialData(response);
                    response.ObjectState = TObjectState.Create;
                }

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }

        }

        [HttpPost]
        public async Task<IActionResult> T08([FromForm] TAllMasterVendorView indata)
        {
            try
            {
                int btnSubmit = int.Parse(indata.BtnSubmit);
                if (btnSubmit == (int)ButtonState.Draft || btnSubmit == (int)ButtonState.Forward)
                {
                    _repo.T08Repo.Validate(indata);
                    if (indata.ObjectState == TObjectState.Create)
                    {
                        indata = await _repo.T08Repo.CreateAsync(indata);
                    }
                    else if (indata.ObjectState == TObjectState.Update)
                    {
                        indata = await _repo.T08Repo.UpdateAsync(indata);
                    }
                    else
                        await _repo.T08Repo.DeleteAsync(indata);
                }
                else if (btnSubmit == (int)ButtonState.Signer || btnSubmit == (int)ButtonState.SignerWitness)
                {
                    await _repo.ContractShare.UpdateSigner(indata);
                }
                else if (btnSubmit == (int)ButtonState.T0_CANCEL || btnSubmit == (int)ButtonState.T1_EDIT
                    || btnSubmit == (int)ButtonState.T2_CANCEL
                    || btnSubmit == (int)ButtonState.T4_CLOSEPROJECT
                    || btnSubmit == (int)ButtonState.T5_TERMINATE)
                {
                    await _repo.ContractShare.UpdateRequestBinding(indata);
                }


                return Json(new ResultModelJson<Boolean>
                {
                    Status = true,
                    Result = true,
                    UrlRedirect = _repo.ContractShare.SetUrlRedirect(indata)
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

        //(09) ข้อตกลงให้บริการฯตามกิจกรรมบริการ ไตเทียม
        public async Task<IActionResult> T09(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.T09Repo.GetView(indata);
                    response.ObjectState = TObjectState.Update;
                }
                else
                {
                    response = await _repo.T09Repo.InitialData(response);
                    response.ObjectState = TObjectState.Create;
                }

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }

        }

        [HttpPost]
        public async Task<IActionResult> T09([FromForm] TAllMasterVendorView indata)
        {
            try
            {
                int btnSubmit = int.Parse(indata.BtnSubmit);
                if (btnSubmit == (int)ButtonState.Draft || btnSubmit == (int)ButtonState.Forward)
                {
                    _repo.T09Repo.Validate(indata);
                    if (indata.ObjectState == TObjectState.Create)
                    {
                        indata = await _repo.T09Repo.CreateAsync(indata);
                    }
                    else if (indata.ObjectState == TObjectState.Update)
                    {
                        indata = await _repo.T09Repo.UpdateAsync(indata);
                    }
                    else
                        await _repo.T09Repo.DeleteAsync(indata);
                }
                else if (btnSubmit == (int)ButtonState.Signer || btnSubmit == (int)ButtonState.SignerWitness)
                {
                    await _repo.ContractShare.UpdateSigner(indata);
                }
                else if (btnSubmit == (int)ButtonState.T0_CANCEL || btnSubmit == (int)ButtonState.T1_EDIT
                    || btnSubmit == (int)ButtonState.T2_CANCEL
                    || btnSubmit == (int)ButtonState.T4_CLOSEPROJECT
                    || btnSubmit == (int)ButtonState.T5_TERMINATE)
                {
                    await _repo.ContractShare.UpdateRequestBinding(indata);
                }

                indata.ParameterCondition.Sector = Sectors.Government;
                return Json(new ResultModelJson<Boolean>
                {
                    Status = true,
                    Result = true,
                    UrlRedirect = _repo.ContractShare.SetUrlRedirect(indata)
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

        //(10) ข้อตกลง (อปท.)
        public async Task<IActionResult> T10(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.T10Repo.GetView(indata);
                    response.ObjectState = TObjectState.Update;
                }
                else
                {
                    response = await _repo.T10Repo.InitialData(response);
                    response.ObjectState = TObjectState.Create;
                }

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }

        }

        [HttpPost]
        public async Task<IActionResult> T10([FromForm] TAllMasterVendorView indata)
        {
            try
            {
                int btnSubmit = int.Parse(indata.BtnSubmit);
                if (btnSubmit == (int)ButtonState.Draft || btnSubmit == (int)ButtonState.Forward)
                {
                    _repo.T10Repo.Validate(indata);
                    if (indata.ObjectState == TObjectState.Create)
                    {
                        indata = await _repo.T10Repo.CreateAsync(indata);
                    }
                    else if (indata.ObjectState == TObjectState.Update)
                    {
                        indata = await _repo.T10Repo.UpdateAsync(indata);
                    }
                    else
                        await _repo.T10Repo.DeleteAsync(indata);
                }
                else if (btnSubmit == (int)ButtonState.Signer || btnSubmit == (int)ButtonState.SignerWitness)
                {
                    await _repo.ContractShare.UpdateSigner(indata);
                }
                else if (btnSubmit == (int)ButtonState.T0_CANCEL || btnSubmit == (int)ButtonState.T1_EDIT
                    || btnSubmit == (int)ButtonState.T2_CANCEL
                    || btnSubmit == (int)ButtonState.T4_CLOSEPROJECT
                    || btnSubmit == (int)ButtonState.T5_TERMINATE)
                {
                    await _repo.ContractShare.UpdateRequestBinding(indata);
                }

                indata.ParameterCondition.Sector = Sectors.Government;
                return Json(new ResultModelJson<Boolean>
                {
                    Status = true,
                    Result = true,
                    UrlRedirect = _repo.ContractShare.SetUrlRedirect(indata)
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

        //11 สัญญาดำเนินการตามโครงการ
        public async Task<IActionResult> T11(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.T11Repo.GetView(indata);
                    response.ObjectState = TObjectState.Update;
                }
                else
                {
                    response = await _repo.T11Repo.InitialData(response);
                    response.ObjectState = TObjectState.Create;
                }

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }
        }

        [HttpPost]
        public async Task<IActionResult> T11([FromForm] TAllMasterVendorView indata)
        {
            try
            {
                int btnSubmit = int.Parse(indata.BtnSubmit);
                if (btnSubmit == (int)ButtonState.Cancel)
                {
                    await _repo.T11Repo.DeleteAsync(indata);
                }
                else if (btnSubmit == (int)ButtonState.Draft || btnSubmit == (int)ButtonState.Forward)
                {
                    _repo.T11Repo.Validate(indata);
                    if (indata.ObjectState == TObjectState.Create)
                    {
                        indata = await _repo.T11Repo.CreateAsync(indata);
                    }
                    else if (indata.ObjectState == TObjectState.Update)
                    {
                        indata = await _repo.T11Repo.UpdateAsync(indata);
                    }
                }
                else if (btnSubmit == (int)ButtonState.Signer || btnSubmit == (int)ButtonState.SignerWitness)
                {
                    await _repo.ContractShare.UpdateSigner(indata);
                }
                else if (btnSubmit == (int)ButtonState.T0_CANCEL || btnSubmit == (int)ButtonState.T1_EDIT
                    || btnSubmit == (int)ButtonState.T2_CANCEL
                    || btnSubmit == (int)ButtonState.T3_EXPAND
                    || btnSubmit == (int)ButtonState.T4_CLOSEPROJECT
                    || btnSubmit == (int)ButtonState.T5_TERMINATE)
                {
                    await _repo.ContractShare.UpdateRequestBinding(indata);
                }

                return Json(new ResultModelJson<Boolean>
                {
                    Status = true,
                    Result = true,
                    UrlRedirect = _repo.ContractShare.SetUrlRedirect(indata)
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

        //12 ข้อตกลงดำเนินการตามโครงการ
        public async Task<IActionResult> T12(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.T12Repo.GetView(indata);
                    response.ObjectState = TObjectState.Update;
                }
                else
                {
                    response = await _repo.T12Repo.InitialData(response);
                    response.ObjectState = TObjectState.Create;
                }

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }
        }

        [HttpPost]
        public async Task<IActionResult> T12([FromForm] TAllMasterVendorView indata)
        {
            try
            {
                int btnSubmit = int.Parse(indata.BtnSubmit);
                if (btnSubmit == (int)ButtonState.Draft || btnSubmit == (int)ButtonState.Forward)
                {
                    _repo.T12Repo.Validate(indata);
                    if (indata.ObjectState == TObjectState.Create)
                    {
                        indata = await _repo.T12Repo.CreateAsync(indata);
                    }
                    else if (indata.ObjectState == TObjectState.Update)
                    {
                        indata = await _repo.T12Repo.UpdateAsync(indata);
                    }
                    else
                        await _repo.T12Repo.DeleteAsync(indata);
                }
                else if (btnSubmit == (int)ButtonState.Signer || btnSubmit == (int)ButtonState.SignerWitness)
                {
                    await _repo.ContractShare.UpdateSigner(indata);
                }
                else if (btnSubmit == (int)ButtonState.T0_CANCEL || btnSubmit == (int)ButtonState.T1_EDIT
                    || btnSubmit == (int)ButtonState.T2_CANCEL
                    || btnSubmit == (int)ButtonState.T3_EXPAND
                    || btnSubmit == (int)ButtonState.T4_CLOSEPROJECT
                    || btnSubmit == (int)ButtonState.T5_TERMINATE)
                {
                    await _repo.ContractShare.UpdateRequestBinding(indata);
                }

                indata.ParameterCondition.Sector = Sectors.Government;
                return Json(new ResultModelJson<Boolean>
                {
                    Status = true,
                    Result = true,
                    UrlRedirect = _repo.ContractShare.SetUrlRedirect(indata)
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

        //13 หนังสือแสดงความจำนงฯ
        public async Task<IActionResult> T13(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.T13Repo.GetView(indata);
                    response.ObjectState = TObjectState.Update;
                }
                else
                {
                    response = await _repo.T13Repo.InitialData(response);
                    response.ObjectState = TObjectState.Create;
                }

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }
        }

        [HttpPost]
        public async Task<IActionResult> T13([FromForm] TAllMasterVendorView indata)
        {
            try
            {
                int btnSubmit = int.Parse(indata.BtnSubmit);
                if (btnSubmit == (int)ButtonState.Draft || btnSubmit == (int)ButtonState.Forward)
                {
                    _repo.T13Repo.Validate(indata);
                    if (indata.ObjectState == TObjectState.Create)
                    {
                        indata = await _repo.T13Repo.CreateAsync(indata);
                    }
                    else if (indata.ObjectState == TObjectState.Update)
                    {
                        indata = await _repo.T13Repo.UpdateAsync(indata);
                    }
                    else
                        await _repo.T13Repo.DeleteAsync(indata);
                }
                else if (btnSubmit == (int)ButtonState.Signer || btnSubmit == (int)ButtonState.SignerWitness)
                {
                    await _repo.ContractShare.UpdateSigner(indata);
                }
                else if (btnSubmit == (int)ButtonState.T0_CANCEL || btnSubmit == (int)ButtonState.T1_EDIT
                    || btnSubmit == (int)ButtonState.T2_CANCEL
                    || btnSubmit == (int)ButtonState.T3_EXPAND
                    || btnSubmit == (int)ButtonState.T4_CLOSEPROJECT
                    || btnSubmit == (int)ButtonState.T5_TERMINATE)
                {
                    await _repo.ContractShare.UpdateRequestBinding(indata);
                }

                indata.ParameterCondition.Sector = Sectors.Government;
                return Json(new ResultModelJson<Boolean>
                {
                    Status = true,
                    Result = true,
                    UrlRedirect = _repo.ContractShare.SetUrlRedirect(indata)
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

        //14 โครงการ
        public async Task<IActionResult> T14(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.T14Repo.GetView(indata);
                    response.ObjectState = TObjectState.Update;
                }
                else
                {
                    response = await _repo.T14Repo.InitialData(response);
                    response.ObjectState = TObjectState.Create;
                }

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }
        }

        [HttpPost]
        public async Task<IActionResult> T14([FromForm] TAllMasterVendorView indata)
        {
            try
            {
                int btnSubmit = int.Parse(indata.BtnSubmit);
                if (btnSubmit == (int)ButtonState.Draft || btnSubmit == (int)ButtonState.Forward)
                {
                    _repo.T14Repo.Validate(indata);
                    if (indata.ObjectState == TObjectState.Create)
                    {
                        indata = await _repo.T14Repo.CreateAsync(indata);
                    }
                    else if (indata.ObjectState == TObjectState.Update)
                    {
                        indata = await _repo.T14Repo.UpdateAsync(indata);
                    }
                    else
                        await _repo.T14Repo.DeleteAsync(indata);
                }
                else if (btnSubmit == (int)ButtonState.Signer || btnSubmit == (int)ButtonState.SignerWitness)
                {
                    await _repo.ContractShare.UpdateSigner(indata);
                }
                else if (btnSubmit == (int)ButtonState.T0_CANCEL || btnSubmit == (int)ButtonState.T1_EDIT
                    || btnSubmit == (int)ButtonState.T2_CANCEL
                    || btnSubmit == (int)ButtonState.T3_EXPAND
                    || btnSubmit == (int)ButtonState.T4_CLOSEPROJECT
                    || btnSubmit == (int)ButtonState.T5_TERMINATE)
                {
                    await _repo.ContractShare.UpdateRequestBinding(indata);
                }

                indata.ParameterCondition.Sector = Sectors.Government;
                return Json(new ResultModelJson<Boolean>
                {
                    Status = true,
                    Result = true,
                    UrlRedirect = _repo.ContractShare.SetUrlRedirect(indata)
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


        public IActionResult Signer()
        {
            return View();
        }
        public IActionResult RequestApproval()
        {
            return View();
        }
        public IActionResult Payment()
        {
            return View();
        }

    }
}

/*
  OLD -> NEW
  01 -> 01 S1  สัญญาให้บริการสาธารณสุขฯ
  02 -> 02 S1  ข้อตกลงให้บริการสาธารณสุขฯ
  11 -> 03 S1  สัญญาให้บริการฯ(ศูนย์สำรองเตียง)
     -> 04 S1  สัญญาให้บริการฯ(ศูนย์สำรองเตียง)เฉพาะด้าน
  12 -> 05 S1  ข้อตกลงกองทุนฟื้นฟูฯจังหวัด
  13 -> 06 S2  สัญญาให้บริการฯตามกิจกรรมบริการ
  16 -> 07 S2  ข้อตกลงให้บริการฯตามกิจกรรมบริการ
  23 -> 08 S2  สัญญาให้บริการฯตามกิจกรรมบริการ ไตเทียม
  22 -> 09 S2  ข้อตกลงให้บริการฯตามกิจกรรมบริการ ไตเทียม
  18 -> 10 S3  ข้อตกลง (อปท.)
  03 -> 11 S41 สัญญาดำเนินการตามโครงการ
  04 -> 12 S41 ข้อตกลงดำเนินการตามโครงการ
  15 -> 13 S42 หนังสือแสดงความจำนงฯ
  20 -> 14 S43 โครงการ
*/


