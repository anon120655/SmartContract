using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Interfaces.Share;
using SmartContract.Infrastructure.Resources.Authenticate;
using SmartContract.Infrastructure.Resources.ContractTypeBureau;
using SmartContract.Infrastructure.Resources.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.Enum;
using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Infrastructure.Wrapper;
using SmartContract.Utils;

namespace SmartContract.Web.Controllers
{
    [TypeFilter(typeof(AccessTokenAttribute))]
    public class ContractTypeController : Controller
    {
        private IRepositoryWrapper _repo;
        private readonly AppSettings _mySet;
        private readonly IRazorViewToStringRenderer _razorView;

        public ContractTypeController(IRepositoryWrapper repo, IOptions<AppSettings> settings, IRazorViewToStringRenderer razorView)
        {
            _repo = repo;
            _mySet = settings.Value;
            _razorView = razorView;
        }

        //(01) สัญญาให้บริการสาธารณสุขฯ
        public async Task<IActionResult> T01C(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.T01BuRepo.GetView(indata);
                    response.ObjectState = _repo.GeneralRepo.SetState(indata.State);
                }
                else
                {
                    response = await _repo.T01BuRepo.InitialData(response);
                }

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }
        }

        [HttpPost]
        public async Task<IActionResult> T01C([FromForm] TAllMasterVendorView indata)
        {
            try
            {
                int btnSubmit = int.Parse(indata.BtnSubmit);
                if (btnSubmit == (int)ButtonState.Draft || btnSubmit == (int)ButtonState.Forward || btnSubmit == (int)ButtonState.T1_EDIT)
                {
                    if (indata.ApproveContract != null && indata.ApproveContract.UnApprove && btnSubmit == (int)ButtonState.Forward)
                    {
                        using (var _transaction = _repo.BeginTransaction())
                        {
                            await _repo.ContractShareNhso.UpdateStatusContract(indata);
                            _transaction.Commit();
                        }
                    }
                    else
                    {
                        //ขอแก้ไขหลังผูกพัน
                        if (indata.ApproveBinding != null && indata.ApproveBinding.UnApprove)
                        {
                            using (var _transaction = _repo.BeginTransaction())
                            {
                                await _repo.ContractShareNhso.UpdateRequestBinding(indata);
                                _transaction.Commit();
                            }
                        }
                        else
                        {
                            _repo.T01BuRepo.ValidateContract(indata);
                            indata = await _repo.T01BuRepo.UpdateAsyncContract(indata);
                        }
                    }
                }
                else if (btnSubmit == (int)ButtonState.GenContractId)
                {
                    await _repo.ContractShareNhso.UpdateContractNumber(indata);
                }
                else if (btnSubmit == (int)ButtonState.SignerAttachFile || btnSubmit == (int)ButtonState.Signer || btnSubmit == (int)ButtonState.SignerWitness)
                {
                    await _repo.ContractShareNhso.UpdateSigner(indata);
                }
                else if (btnSubmit == (int)ButtonState.T2_CANCEL || btnSubmit == (int)ButtonState.T4_CLOSEPROJECT || btnSubmit == (int)ButtonState.T5_TERMINATE)
                {
                    await _repo.ContractShareNhso.UpdateRequestBinding(indata);
                }
                else if (btnSubmit == (int)ButtonState.T3_EXPAND)
                {
                    await _repo.ContractShareNhso.UpdateEXPAND(indata);
                }

                indata = await _repo.ContractShare.ViewContractStation(indata);

                return Json(new ResultModelJson<TAllMasterVendorView>
                {
                    Status = true,
                    Result = indata,
                    UrlRedirect = _repo.ContractShareNhso.SetUrlRedirectContract(indata)
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
        public async Task<IActionResult> T02C(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.T02BuRepo.GetView(indata);
                    response.ObjectState = _repo.GeneralRepo.SetState(indata.State);
                }
                else
                {
                    response = await _repo.T02BuRepo.InitialData(response);
                }

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }
        }

        [HttpPost]
        public async Task<IActionResult> T02C([FromForm] TAllMasterVendorView indata)
        {
            try
            {
                int btnSubmit = int.Parse(indata.BtnSubmit);
                if (btnSubmit == (int)ButtonState.Draft || btnSubmit == (int)ButtonState.Forward || btnSubmit == (int)ButtonState.T1_EDIT)
                {
                    if (indata.ApproveContract != null && indata.ApproveContract.UnApprove && btnSubmit == (int)ButtonState.Forward)
                    {
                        using (var _transaction = _repo.BeginTransaction())
                        {
                            await _repo.ContractShareNhso.UpdateStatusContract(indata);
                            _transaction.Commit();
                        }
                    }
                    else
                    {
                        //ขอแก้ไขหลังผูกพัน
                        if (indata.ApproveBinding != null && indata.ApproveBinding.UnApprove)
                        {
                            using (var _transaction = _repo.BeginTransaction())
                            {
                                await _repo.ContractShareNhso.UpdateRequestBinding(indata);
                                _transaction.Commit();
                            }
                        }
                        else
                        {
                            _repo.T02BuRepo.ValidateContract(indata);
                            indata = await _repo.T02BuRepo.UpdateAsyncContract(indata);
                        }
                    }
                }
                else if (btnSubmit == (int)ButtonState.GenContractId)
                {
                    await _repo.ContractShareNhso.UpdateContractNumber(indata);
                }
                else if (btnSubmit == (int)ButtonState.SignerAttachFile || btnSubmit == (int)ButtonState.Signer || btnSubmit == (int)ButtonState.SignerWitness)
                {
                    await _repo.ContractShareNhso.UpdateSigner(indata);
                }
                else if (btnSubmit == (int)ButtonState.T2_CANCEL || btnSubmit == (int)ButtonState.T4_CLOSEPROJECT || btnSubmit == (int)ButtonState.T5_TERMINATE)
                {
                    await _repo.ContractShareNhso.UpdateRequestBinding(indata);
                }
                else if (btnSubmit == (int)ButtonState.T3_EXPAND)
                {
                    await _repo.ContractShareNhso.UpdateEXPAND(indata);
                }

                indata = await _repo.ContractShare.ViewContractStation(indata);

                indata.ParameterCondition.Sector = Sectors.Government;
                return Json(new ResultModelJson<TAllMasterVendorView>
                {
                    Status = true,
                    Result = indata,
                    UrlRedirect = _repo.ContractShareNhso.SetUrlRedirectContract(indata)
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
        public async Task<IActionResult> T03C(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.T03BuRepo.GetView(indata);
                    response.ObjectState = _repo.GeneralRepo.SetState(indata.State);
                }
                else
                {
                    response = await _repo.T03BuRepo.InitialData(response);
                }

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }
        }

        [HttpPost]
        public async Task<IActionResult> T03C([FromForm] TAllMasterVendorView indata)
        {
            try
            {
                int btnSubmit = int.Parse(indata.BtnSubmit);
                if (btnSubmit == (int)ButtonState.Draft || btnSubmit == (int)ButtonState.Forward || btnSubmit == (int)ButtonState.T1_EDIT)
                {
                    if (indata.ApproveContract != null && indata.ApproveContract.UnApprove && btnSubmit == (int)ButtonState.Forward)
                    {
                        using (var _transaction = _repo.BeginTransaction())
                        {
                            await _repo.ContractShareNhso.UpdateStatusContract(indata);
                            _transaction.Commit();
                        }
                    }
                    else
                    {
                        //ขอแก้ไขหลังผูกพัน
                        if (indata.ApproveBinding != null && indata.ApproveBinding.UnApprove)
                        {
                            using (var _transaction = _repo.BeginTransaction())
                            {
                                await _repo.ContractShareNhso.UpdateRequestBinding(indata);
                                _transaction.Commit();
                            }
                        }
                        else
                        {
                            _repo.T01BuRepo.ValidateContract(indata);
                            indata = await _repo.T03BuRepo.UpdateAsyncContract(indata);
                        }
                    }
                }
                else if (btnSubmit == (int)ButtonState.GenContractId)
                {
                    await _repo.ContractShareNhso.UpdateContractNumber(indata);
                }
                else if (btnSubmit == (int)ButtonState.SignerAttachFile || btnSubmit == (int)ButtonState.Signer || btnSubmit == (int)ButtonState.SignerWitness)
                {
                    await _repo.ContractShareNhso.UpdateSigner(indata);
                }
                else if (btnSubmit == (int)ButtonState.T2_CANCEL || btnSubmit == (int)ButtonState.T4_CLOSEPROJECT || btnSubmit == (int)ButtonState.T5_TERMINATE)
                {
                    await _repo.ContractShareNhso.UpdateRequestBinding(indata);
                }
                else if (btnSubmit == (int)ButtonState.T3_EXPAND)
                {
                    await _repo.ContractShareNhso.UpdateEXPAND(indata);
                }

                indata = await _repo.ContractShare.ViewContractStation(indata);

                return Json(new ResultModelJson<TAllMasterVendorView>
                {
                    Status = true,
                    Result = indata,
                    UrlRedirect = _repo.ContractShareNhso.SetUrlRedirectContract(indata)
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
        public async Task<IActionResult> T04C(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.T04BuRepo.GetView(indata);
                    response.ObjectState = _repo.GeneralRepo.SetState(indata.State);
                }
                else
                {
                    response = await _repo.T04BuRepo.InitialData(response);
                }

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }
        }

        [HttpPost]
        public async Task<IActionResult> T04C([FromForm] TAllMasterVendorView indata)
        {
            try
            {
                int btnSubmit = int.Parse(indata.BtnSubmit);
                if (btnSubmit == (int)ButtonState.Draft || btnSubmit == (int)ButtonState.Forward || btnSubmit == (int)ButtonState.T1_EDIT)
                {
                    if (indata.ApproveContract != null && indata.ApproveContract.UnApprove && btnSubmit == (int)ButtonState.Forward)
                    {
                        using (var _transaction = _repo.BeginTransaction())
                        {
                            await _repo.ContractShareNhso.UpdateStatusContract(indata);
                            _transaction.Commit();
                        }
                    }
                    else
                    {
                        //ขอแก้ไขหลังผูกพัน
                        if (indata.ApproveBinding != null && indata.ApproveBinding.UnApprove)
                        {
                            using (var _transaction = _repo.BeginTransaction())
                            {
                                await _repo.ContractShareNhso.UpdateRequestBinding(indata);
                                _transaction.Commit();
                            }
                        }
                        else
                        {
                            _repo.T01BuRepo.ValidateContract(indata);
                            indata = await _repo.T04BuRepo.UpdateAsyncContract(indata);
                        }
                    }
                }
                else if (btnSubmit == (int)ButtonState.GenContractId)
                {
                    await _repo.ContractShareNhso.UpdateContractNumber(indata);
                }
                else if (btnSubmit == (int)ButtonState.SignerAttachFile || btnSubmit == (int)ButtonState.Signer || btnSubmit == (int)ButtonState.SignerWitness)
                {
                    await _repo.ContractShareNhso.UpdateSigner(indata);
                }
                else if (btnSubmit == (int)ButtonState.T2_CANCEL || btnSubmit == (int)ButtonState.T4_CLOSEPROJECT || btnSubmit == (int)ButtonState.T5_TERMINATE)
                {
                    await _repo.ContractShareNhso.UpdateRequestBinding(indata);
                }
                else if (btnSubmit == (int)ButtonState.T3_EXPAND)
                {
                    await _repo.ContractShareNhso.UpdateEXPAND(indata);
                }

                indata = await _repo.ContractShare.ViewContractStation(indata);

                return Json(new ResultModelJson<TAllMasterVendorView>
                {
                    Status = true,
                    Result = indata,
                    UrlRedirect = _repo.ContractShareNhso.SetUrlRedirectContract(indata)
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
        public async Task<IActionResult> T05C(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.T05BuRepo.GetView(indata);
                    response.ObjectState = _repo.GeneralRepo.SetState(indata.State);
                }
                else
                {
                    response = await _repo.T05BuRepo.InitialData(response);
                }

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }
        }

        [HttpPost]
        public async Task<IActionResult> T05C([FromForm] TAllMasterVendorView indata)
        {
            try
            {
                int btnSubmit = int.Parse(indata.BtnSubmit);
                if (btnSubmit == (int)ButtonState.Draft || btnSubmit == (int)ButtonState.Forward || btnSubmit == (int)ButtonState.T1_EDIT)
                {
                    if (indata.ApproveContract != null && indata.ApproveContract.UnApprove && btnSubmit == (int)ButtonState.Forward)
                    {
                        using (var _transaction = _repo.BeginTransaction())
                        {
                            await _repo.ContractShareNhso.UpdateStatusContract(indata);
                            _transaction.Commit();
                        }
                    }
                    else
                    {
                        //ขอแก้ไขหลังผูกพัน
                        if (indata.ApproveBinding != null && indata.ApproveBinding.UnApprove)
                        {
                            using (var _transaction = _repo.BeginTransaction())
                            {
                                await _repo.ContractShareNhso.UpdateRequestBinding(indata);
                                _transaction.Commit();
                            }
                        }
                        else
                        {
                            _repo.T05BuRepo.ValidateContract(indata);
                            indata = await _repo.T05BuRepo.UpdateAsyncContract(indata);
                        }
                    }
                }
                else if (btnSubmit == (int)ButtonState.GenContractId)
                {
                    await _repo.ContractShareNhso.UpdateContractNumber(indata);
                }
                else if (btnSubmit == (int)ButtonState.SignerAttachFile || btnSubmit == (int)ButtonState.Signer || btnSubmit == (int)ButtonState.SignerWitness)
                {
                    await _repo.ContractShareNhso.UpdateSigner(indata);
                }
                else if (btnSubmit == (int)ButtonState.T2_CANCEL || btnSubmit == (int)ButtonState.T4_CLOSEPROJECT || btnSubmit == (int)ButtonState.T5_TERMINATE)
                {
                    await _repo.ContractShareNhso.UpdateRequestBinding(indata);
                }
                else if (btnSubmit == (int)ButtonState.T3_EXPAND)
                {
                    await _repo.ContractShareNhso.UpdateEXPAND(indata);
                }

                indata = await _repo.ContractShare.ViewContractStation(indata);

                indata.ParameterCondition.Sector = Sectors.Government;
                return Json(new ResultModelJson<TAllMasterVendorView>
                {
                    Status = true,
                    Result = indata,
                    UrlRedirect = _repo.ContractShareNhso.SetUrlRedirectContract(indata)
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
        public async Task<IActionResult> T06C(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.T06BuRepo.GetView(indata);
                    response.ObjectState = _repo.GeneralRepo.SetState(indata.State);
                }
                else
                {
                    response = await _repo.T06BuRepo.InitialData(response);
                }

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }
        }

        [HttpPost]
        public async Task<IActionResult> T06C([FromForm] TAllMasterVendorView indata)
        {
            try
            {
                int btnSubmit = int.Parse(indata.BtnSubmit);
                if (btnSubmit == (int)ButtonState.Draft || btnSubmit == (int)ButtonState.Forward || btnSubmit == (int)ButtonState.T1_EDIT)
                {
                    if (indata.ApproveContract != null && indata.ApproveContract.UnApprove && btnSubmit == (int)ButtonState.Forward)
                    {
                        using (var _transaction = _repo.BeginTransaction())
                        {
                            await _repo.ContractShareNhso.UpdateStatusContract(indata);
                            _transaction.Commit();
                        }
                    }
                    else
                    {
                        //ขอแก้ไขหลังผูกพัน
                        if (indata.ApproveBinding != null && indata.ApproveBinding.UnApprove)
                        {
                            using (var _transaction = _repo.BeginTransaction())
                            {
                                await _repo.ContractShareNhso.UpdateRequestBinding(indata);
                                _transaction.Commit();
                            }
                        }
                        else
                        {
                            _repo.T06BuRepo.ValidateContract(indata);
                            indata = await _repo.T06BuRepo.UpdateAsyncContract(indata);
                        }
                    }
                }
                else if (btnSubmit == (int)ButtonState.GenContractId)
                {
                    await _repo.ContractShareNhso.UpdateContractNumber(indata);
                }
                else if (btnSubmit == (int)ButtonState.SignerAttachFile || btnSubmit == (int)ButtonState.Signer || btnSubmit == (int)ButtonState.SignerWitness)
                {
                    await _repo.ContractShareNhso.UpdateSigner(indata);
                }
                else if (btnSubmit == (int)ButtonState.T2_CANCEL
                   || btnSubmit == (int)ButtonState.T4_CLOSEPROJECT
                   || btnSubmit == (int)ButtonState.T5_TERMINATE)
                {
                    await _repo.ContractShareNhso.UpdateRequestBinding(indata);
                }

                indata = await _repo.ContractShare.ViewContractStation(indata);

                return Json(new ResultModelJson<TAllMasterVendorView>
                {
                    Status = true,
                    Result = indata,
                    UrlRedirect = _repo.ContractShareNhso.SetUrlRedirectContract(indata)
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
        public async Task<IActionResult> T07C(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.T07BuRepo.GetView(indata);
                    response.ObjectState = _repo.GeneralRepo.SetState(indata.State);
                }
                else
                {
                    response = await _repo.T07BuRepo.InitialData(response);
                }

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }
        }

        [HttpPost]
        public async Task<IActionResult> T07C([FromForm] TAllMasterVendorView indata)
        {
            try
            {
                int btnSubmit = int.Parse(indata.BtnSubmit);
                if (btnSubmit == (int)ButtonState.Draft || btnSubmit == (int)ButtonState.Forward || btnSubmit == (int)ButtonState.T1_EDIT)
                {
                    if (indata.ApproveContract != null && indata.ApproveContract.UnApprove && btnSubmit == (int)ButtonState.Forward)
                    {
                        using (var _transaction = _repo.BeginTransaction())
                        {
                            await _repo.ContractShareNhso.UpdateStatusContract(indata);
                            _transaction.Commit();
                        }
                    }
                    else
                    {
                        //ขอแก้ไขหลังผูกพัน
                        if (indata.ApproveBinding != null && indata.ApproveBinding.UnApprove)
                        {
                            using (var _transaction = _repo.BeginTransaction())
                            {
                                await _repo.ContractShareNhso.UpdateRequestBinding(indata);
                                _transaction.Commit();
                            }
                        }
                        else
                        {
                            _repo.T07BuRepo.ValidateContract(indata);
                            indata = await _repo.T07BuRepo.UpdateAsyncContract(indata);
                        }
                    }
                }
                else if (btnSubmit == (int)ButtonState.GenContractId)
                {
                    await _repo.ContractShareNhso.UpdateContractNumber(indata);
                }
                else if (btnSubmit == (int)ButtonState.SignerAttachFile || btnSubmit == (int)ButtonState.Signer || btnSubmit == (int)ButtonState.SignerWitness)
                {
                    await _repo.ContractShareNhso.UpdateSigner(indata);
                }
                else if (btnSubmit == (int)ButtonState.T2_CANCEL
                   || btnSubmit == (int)ButtonState.T4_CLOSEPROJECT
                   || btnSubmit == (int)ButtonState.T5_TERMINATE)
                {
                    await _repo.ContractShareNhso.UpdateRequestBinding(indata);
                }

                indata = await _repo.ContractShare.ViewContractStation(indata);

                indata.ParameterCondition.Sector = Sectors.Government;
                return Json(new ResultModelJson<TAllMasterVendorView>
                {
                    Status = true,
                    Result = indata,
                    UrlRedirect = _repo.ContractShareNhso.SetUrlRedirectContract(indata)
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

        //(08) สัญญาให้บริการสาธารณสุขตามกิจกรรมบริการ ไตเทียม
        public async Task<IActionResult> T08C(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.T08BuRepo.GetView(indata);
                    response.ObjectState = _repo.GeneralRepo.SetState(indata.State);
                }
                else
                {
                    response = await _repo.T08BuRepo.InitialData(response);
                }

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }
        }

        [HttpPost]
        public async Task<IActionResult> T08C([FromForm] TAllMasterVendorView indata)
        {
            try
            {
                int btnSubmit = int.Parse(indata.BtnSubmit);
                if (btnSubmit == (int)ButtonState.Draft || btnSubmit == (int)ButtonState.Forward || btnSubmit == (int)ButtonState.T1_EDIT)
                {
                    if (indata.ApproveContract != null && indata.ApproveContract.UnApprove && btnSubmit == (int)ButtonState.Forward)
                    {
                        using (var _transaction = _repo.BeginTransaction())
                        {
                            await _repo.ContractShareNhso.UpdateStatusContract(indata);
                            _transaction.Commit();
                        }
                    }
                    else
                    {
                        //ขอแก้ไขหลังผูกพัน
                        if (indata.ApproveBinding != null && indata.ApproveBinding.UnApprove)
                        {
                            using (var _transaction = _repo.BeginTransaction())
                            {
                                await _repo.ContractShareNhso.UpdateRequestBinding(indata);
                                _transaction.Commit();
                            }
                        }
                        else
                        {
                            _repo.T08BuRepo.ValidateContract(indata);
                            indata = await _repo.T08BuRepo.UpdateAsyncContract(indata);
                        }
                    }
                }
                else if (btnSubmit == (int)ButtonState.GenContractId)
                {
                    await _repo.ContractShareNhso.UpdateContractNumber(indata);
                }
                else if (btnSubmit == (int)ButtonState.SignerAttachFile || btnSubmit == (int)ButtonState.Signer || btnSubmit == (int)ButtonState.SignerWitness)
                {
                    await _repo.ContractShareNhso.UpdateSigner(indata);
                }
                else if (btnSubmit == (int)ButtonState.T2_CANCEL
                   || btnSubmit == (int)ButtonState.T4_CLOSEPROJECT
                   || btnSubmit == (int)ButtonState.T5_TERMINATE)
                {
                    await _repo.ContractShareNhso.UpdateRequestBinding(indata);
                }

                indata = await _repo.ContractShare.ViewContractStation(indata);

                return Json(new ResultModelJson<TAllMasterVendorView>
                {
                    Status = true,
                    Result = indata,
                    UrlRedirect = _repo.ContractShareNhso.SetUrlRedirectContract(indata)
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
        public async Task<IActionResult> T09C(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.T09BuRepo.GetView(indata);
                    response.ObjectState = _repo.GeneralRepo.SetState(indata.State);
                }
                else
                {
                    response = await _repo.T09BuRepo.InitialData(response);
                }

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }
        }

        [HttpPost]
        public async Task<IActionResult> T09C([FromForm] TAllMasterVendorView indata)
        {
            try
            {
                int btnSubmit = int.Parse(indata.BtnSubmit);
                if (btnSubmit == (int)ButtonState.Draft || btnSubmit == (int)ButtonState.Forward || btnSubmit == (int)ButtonState.T1_EDIT)
                {
                    if (indata.ApproveContract != null && indata.ApproveContract.UnApprove && btnSubmit == (int)ButtonState.Forward)
                    {
                        using (var _transaction = _repo.BeginTransaction())
                        {
                            await _repo.ContractShareNhso.UpdateStatusContract(indata);
                            _transaction.Commit();
                        }
                    }
                    else
                    {
                        //ขอแก้ไขหลังผูกพัน
                        if (indata.ApproveBinding != null && indata.ApproveBinding.UnApprove)
                        {
                            using (var _transaction = _repo.BeginTransaction())
                            {
                                await _repo.ContractShareNhso.UpdateRequestBinding(indata);
                                _transaction.Commit();
                            }
                        }
                        else
                        {
                            _repo.T09BuRepo.ValidateContract(indata);
                            indata = await _repo.T09BuRepo.UpdateAsyncContract(indata);
                        }
                    }
                }
                else if (btnSubmit == (int)ButtonState.GenContractId)
                {
                    await _repo.ContractShareNhso.UpdateContractNumber(indata);
                }
                else if (btnSubmit == (int)ButtonState.SignerAttachFile || btnSubmit == (int)ButtonState.Signer || btnSubmit == (int)ButtonState.SignerWitness)
                {
                    await _repo.ContractShareNhso.UpdateSigner(indata);
                }
                else if (btnSubmit == (int)ButtonState.T2_CANCEL
                   || btnSubmit == (int)ButtonState.T4_CLOSEPROJECT
                   || btnSubmit == (int)ButtonState.T5_TERMINATE)
                {
                    await _repo.ContractShareNhso.UpdateRequestBinding(indata);
                }

                indata = await _repo.ContractShare.ViewContractStation(indata);

                indata.ParameterCondition.Sector = Sectors.Government;
                return Json(new ResultModelJson<TAllMasterVendorView>
                {
                    Status = true,
                    Result = indata,
                    UrlRedirect = _repo.ContractShareNhso.SetUrlRedirectContract(indata)
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
        public async Task<IActionResult> T10C(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.T10BuRepo.GetView(indata);
                    response.ObjectState = _repo.GeneralRepo.SetState(indata.State);
                }
                else
                {
                    response = await _repo.T10BuRepo.InitialData(response);
                }

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }
        }

        [HttpPost]
        public async Task<IActionResult> T10C([FromForm] TAllMasterVendorView indata)
        {
            try
            {
                int btnSubmit = int.Parse(indata.BtnSubmit);
                if (btnSubmit == (int)ButtonState.Draft || btnSubmit == (int)ButtonState.Forward || btnSubmit == (int)ButtonState.T1_EDIT)
                {
                    if (indata.ApproveContract != null && indata.ApproveContract.UnApprove && btnSubmit == (int)ButtonState.Forward)
                    {
                        using (var _transaction = _repo.BeginTransaction())
                        {
                            await _repo.ContractShareNhso.UpdateStatusContract(indata);
                            _transaction.Commit();
                        }
                    }
                    else
                    {
                        //ขอแก้ไขหลังผูกพัน
                        if (indata.ApproveBinding != null && indata.ApproveBinding.UnApprove)
                        {
                            using (var _transaction = _repo.BeginTransaction())
                            {
                                await _repo.ContractShareNhso.UpdateRequestBinding(indata);
                                _transaction.Commit();
                            }
                        }
                        else
                        {
                            _repo.T10BuRepo.ValidateContract(indata);
                            indata = await _repo.T10BuRepo.UpdateAsyncContract(indata);
                        }
                    }
                }
                else if (btnSubmit == (int)ButtonState.GenContractId)
                {
                    await _repo.ContractShareNhso.UpdateContractNumber(indata);
                }
                else if (btnSubmit == (int)ButtonState.SignerAttachFile || btnSubmit == (int)ButtonState.Signer || btnSubmit == (int)ButtonState.SignerWitness)
                {
                    await _repo.ContractShareNhso.UpdateSigner(indata);
                }
                else if (btnSubmit == (int)ButtonState.T2_CANCEL
                   || btnSubmit == (int)ButtonState.T4_CLOSEPROJECT
                   || btnSubmit == (int)ButtonState.T5_TERMINATE)
                {
                    await _repo.ContractShareNhso.UpdateRequestBinding(indata);
                }

                indata = await _repo.ContractShare.ViewContractStation(indata);

                indata.ParameterCondition.Sector = Sectors.Government;
                return Json(new ResultModelJson<TAllMasterVendorView>
                {
                    Status = true,
                    Result = indata,
                    UrlRedirect = _repo.ContractShareNhso.SetUrlRedirectContract(indata)
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

        //T11 สัญญาดำเนินการตามโครงการ หนังสือขออนุมัติ
        public async Task<IActionResult> T11(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.T11BuRepo.GetView(indata);
                    response.ObjectState = _repo.GeneralRepo.SetState(indata.State);
                }
                else
                {
                    response = await _repo.T11BuRepo.InitialData(response);
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
                if (indata.ApprovalReqStation.StationStatusCurr == ApproveStationStatusAll.S3Consider)
                {
                    using (var _transaction = _repo.BeginTransaction())
                    {
                        await _repo.ContractShareNhso.UpdateStatusBookReq(indata);
                        _transaction.Commit();
                    }
                }
                else
                {
                    _repo.T11BuRepo.ValidateBookReq(indata);
                    indata = await _repo.T11BuRepo.UpdateAsyncBookReq(indata);
                }

                indata = await _repo.ContractShare.ViewApprovalReqStation(indata);
                indata = await _repo.ContractShare.ViewContractStation(indata);

                return Json(new ResultModelJson<TAllMasterVendorView>
                {
                    Status = true,
                    Result = indata,
                    UrlRedirect = _repo.ContractShareNhso.SetUrlRedirectReqApprove(indata)
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

        //T11 สัญญาดำเนินการตามโครงการ สร้างนิติกรรมสัญญา,ออกเลขที่สัญญา
        public async Task<IActionResult> T11C(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.T11BuRepo.GetView(indata);
                    response.ObjectState = _repo.GeneralRepo.SetState(indata.State);
                }
                else
                {
                    response = await _repo.T11BuRepo.InitialData(response);
                }

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }
        }

        [HttpPost]
        public async Task<IActionResult> T11C([FromForm] TAllMasterVendorView indata)
        {
            try
            {
                int btnSubmit = int.Parse(indata.BtnSubmit);
                if (btnSubmit == (int)ButtonState.Draft || btnSubmit == (int)ButtonState.Forward || btnSubmit == (int)ButtonState.T1_EDIT)
                {
                    if (indata.ApproveContract != null && indata.ApproveContract.UnApprove && btnSubmit == (int)ButtonState.Forward)
                    {
                        using (var _transaction = _repo.BeginTransaction())
                        {
                            await _repo.ContractShareNhso.UpdateStatusContract(indata);
                            _transaction.Commit();
                        }
                    }
                    else
                    {
                        //ขอแก้ไขหลังผูกพัน
                        if (indata.ApproveBinding != null && indata.ApproveBinding.UnApprove)
                        {
                            using (var _transaction = _repo.BeginTransaction())
                            {
                                await _repo.ContractShareNhso.UpdateRequestBinding(indata);
                                _transaction.Commit();
                            }
                        }
                        else
                        {
                            _repo.T11BuRepo.ValidateContract(indata);
                            indata = await _repo.T11BuRepo.UpdateAsyncContract(indata);
                        }
                    }
                }
                else if (btnSubmit == (int)ButtonState.GenContractId)
                {
                    await _repo.ContractShareNhso.UpdateContractNumber(indata);
                }
                else if (btnSubmit == (int)ButtonState.SignerAttachFile || btnSubmit == (int)ButtonState.Signer || btnSubmit == (int)ButtonState.SignerWitness)
                {
                    await _repo.ContractShareNhso.UpdateSigner(indata);
                }
                else if (btnSubmit == (int)ButtonState.T2_CANCEL || btnSubmit == (int)ButtonState.T4_CLOSEPROJECT || btnSubmit == (int)ButtonState.T5_TERMINATE)
                {
                    await _repo.ContractShareNhso.UpdateRequestBinding(indata);
                }
                else if (btnSubmit == (int)ButtonState.T3_EXPAND)
                {
                    await _repo.ContractShareNhso.UpdateEXPAND(indata);
                }

                indata = await _repo.ContractShare.ViewApprovalReqStation(indata);
                indata = await _repo.ContractShare.ViewContractStation(indata);

                return Json(new ResultModelJson<TAllMasterVendorView>
                {
                    Status = true,
                    Result = indata,
                    UrlRedirect = _repo.ContractShareNhso.SetUrlRedirectContract(indata)
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

        //T12 ข้อตกลงดำเนินการตามโครงการ หนังสือขออนุมัติ
        public async Task<IActionResult> T12(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.T12BuRepo.GetView(indata);
                    response.ObjectState = _repo.GeneralRepo.SetState(indata.State);
                }
                else
                {
                    response = await _repo.T12BuRepo.InitialData(response);
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
                if (indata.ApprovalReqStation.StationStatusCurr == ApproveStationStatusAll.S3Consider)
                {
                    using (var _transaction = _repo.BeginTransaction())
                    {
                        await _repo.ContractShareNhso.UpdateStatusBookReq(indata);
                        _transaction.Commit();
                    }
                }
                else
                {
                    _repo.T12BuRepo.ValidateBookReq(indata);
                    indata = await _repo.T12BuRepo.UpdateAsyncBookReq(indata);
                }

                indata = await _repo.ContractShare.ViewApprovalReqStation(indata);
                indata = await _repo.ContractShare.ViewContractStation(indata);

                return Json(new ResultModelJson<TAllMasterVendorView>
                {
                    Status = true,
                    Result = indata,
                    UrlRedirect = _repo.ContractShareNhso.SetUrlRedirectReqApprove(indata)
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

        //T12 ข้อตกลงดำเนินการตามโครงการ สร้างนิติกรรมสัญญา,ออกเลขที่สัญญา
        public async Task<IActionResult> T12C(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.T12BuRepo.GetView(indata);
                    response.ObjectState = _repo.GeneralRepo.SetState(indata.State);
                }
                else
                {
                    response = await _repo.T12BuRepo.InitialData(response);
                }

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }
        }

        [HttpPost]
        public async Task<IActionResult> T12C([FromForm] TAllMasterVendorView indata)
        {
            try
            {
                int btnSubmit = int.Parse(indata.BtnSubmit);
                if (btnSubmit == (int)ButtonState.Draft || btnSubmit == (int)ButtonState.Forward || btnSubmit == (int)ButtonState.T1_EDIT)
                {
                    if (indata.ApproveContract != null && indata.ApproveContract.UnApprove && btnSubmit == (int)ButtonState.Forward)
                    {
                        using (var _transaction = _repo.BeginTransaction())
                        {
                            await _repo.ContractShareNhso.UpdateStatusContract(indata);
                            _transaction.Commit();
                        }
                    }
                    else
                    {
                        //ขอแก้ไขหลังผูกพัน
                        if (indata.ApproveBinding != null && indata.ApproveBinding.UnApprove)
                        {
                            using (var _transaction = _repo.BeginTransaction())
                            {
                                await _repo.ContractShareNhso.UpdateRequestBinding(indata);
                                _transaction.Commit();
                            }
                        }
                        else
                        {
                            _repo.T12BuRepo.ValidateContract(indata);
                            indata = await _repo.T12BuRepo.UpdateAsyncContract(indata);
                        }
                    }
                }
                else if (btnSubmit == (int)ButtonState.GenContractId)
                {
                    await _repo.ContractShareNhso.UpdateContractNumber(indata);
                }
                else if (btnSubmit == (int)ButtonState.SignerAttachFile || btnSubmit == (int)ButtonState.Signer || btnSubmit == (int)ButtonState.SignerWitness)
                {
                    await _repo.ContractShareNhso.UpdateSigner(indata);
                }
                else if (btnSubmit == (int)ButtonState.T2_CANCEL || btnSubmit == (int)ButtonState.T4_CLOSEPROJECT || btnSubmit == (int)ButtonState.T5_TERMINATE)
                {
                    await _repo.ContractShareNhso.UpdateRequestBinding(indata);
                }
                else if (btnSubmit == (int)ButtonState.T3_EXPAND)
                {
                    await _repo.ContractShareNhso.UpdateEXPAND(indata);
                }

                indata = await _repo.ContractShare.ViewApprovalReqStation(indata);
                indata = await _repo.ContractShare.ViewContractStation(indata);

                return Json(new ResultModelJson<TAllMasterVendorView>
                {
                    Status = true,
                    Result = indata,
                    UrlRedirect = _repo.ContractShareNhso.SetUrlRedirectContract(indata)
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

        //T13 หนังสือแสดงความจำนงฯ
        public async Task<IActionResult> T13(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.T13BuRepo.GetView(indata);
                    response.ObjectState = _repo.GeneralRepo.SetState(indata.State);
                }
                else
                {
                    response = await _repo.T13BuRepo.InitialData(response);
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
                if (indata.ApprovalReqStation.StationStatusCurr == ApproveStationStatusAll.S3Consider)
                {
                    using (var _transaction = _repo.BeginTransaction())
                    {
                        await _repo.ContractShareNhso.UpdateStatusBookReq(indata);
                        _transaction.Commit();
                    }
                }
                else
                {
                    _repo.T13BuRepo.ValidateBookReq(indata);
                    indata = await _repo.T13BuRepo.UpdateAsyncBookReq(indata);
                }

                indata = await _repo.ContractShare.ViewApprovalReqStation(indata);
                indata = await _repo.ContractShare.ViewContractStation(indata);

                return Json(new ResultModelJson<TAllMasterVendorView>
                {
                    Status = true,
                    Result = indata,
                    UrlRedirect = _repo.ContractShareNhso.SetUrlRedirectReqApprove(indata)
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

        //T13 หนังสือแสดงความจำนงฯ สร้างนิติกรรมสัญญา,ออกเลขที่สัญญา
        public async Task<IActionResult> T13C(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.T13BuRepo.GetView(indata);
                    response.ObjectState = _repo.GeneralRepo.SetState(indata.State);
                }
                else
                {
                    response = await _repo.T13BuRepo.InitialData(response);
                }

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }
        }

        [HttpPost]
        public async Task<IActionResult> T13C([FromForm] TAllMasterVendorView indata)
        {
            try
            {
                int btnSubmit = int.Parse(indata.BtnSubmit);
                if (btnSubmit == (int)ButtonState.Draft || btnSubmit == (int)ButtonState.Forward || btnSubmit == (int)ButtonState.T1_EDIT)
                {
                    if (indata.ApproveContract != null && indata.ApproveContract.UnApprove && btnSubmit == (int)ButtonState.Forward)
                    {
                        using (var _transaction = _repo.BeginTransaction())
                        {
                            await _repo.ContractShareNhso.UpdateStatusContract(indata);
                            _transaction.Commit();
                        }
                    }
                    else
                    {
                        //ขอแก้ไขหลังผูกพัน
                        if (indata.ApproveBinding != null && indata.ApproveBinding.UnApprove)
                        {
                            using (var _transaction = _repo.BeginTransaction())
                            {
                                await _repo.ContractShareNhso.UpdateRequestBinding(indata);
                                _transaction.Commit();
                            }
                        }
                        else
                        {
                            _repo.T13BuRepo.ValidateContract(indata);
                            indata = await _repo.T13BuRepo.UpdateAsyncContract(indata);
                        }
                    }
                }
                else if (btnSubmit == (int)ButtonState.GenContractId)
                {
                    await _repo.ContractShareNhso.UpdateContractNumber(indata);
                }
                else if (btnSubmit == (int)ButtonState.SignerAttachFile || btnSubmit == (int)ButtonState.Signer || btnSubmit == (int)ButtonState.SignerWitness)
                {
                    await _repo.ContractShareNhso.UpdateSigner(indata);
                }
                else if (btnSubmit == (int)ButtonState.T2_CANCEL || btnSubmit == (int)ButtonState.T4_CLOSEPROJECT || btnSubmit == (int)ButtonState.T5_TERMINATE)
                {
                    await _repo.ContractShareNhso.UpdateRequestBinding(indata);
                }
                else if (btnSubmit == (int)ButtonState.T3_EXPAND)
                {
                    await _repo.ContractShareNhso.UpdateEXPAND(indata);
                }

                indata = await _repo.ContractShare.ViewApprovalReqStation(indata);
                indata = await _repo.ContractShare.ViewContractStation(indata);

                return Json(new ResultModelJson<TAllMasterVendorView>
                {
                    Status = true,
                    Result = indata,
                    UrlRedirect = _repo.ContractShareNhso.SetUrlRedirectContract(indata)
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

        //T14 โครงการ หนังสือขออนุมัติ
        public async Task<IActionResult> T14(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.T14BuRepo.GetView(indata);
                    response.ObjectState = _repo.GeneralRepo.SetState(indata.State);
                }
                else
                {
                    response = await _repo.T14BuRepo.InitialData(response);
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
                if (indata.ApprovalReqStation.StationStatusCurr == ApproveStationStatusAll.S3Consider)
                {
                    using (var _transaction = _repo.BeginTransaction())
                    {
                        await _repo.ContractShareNhso.UpdateStatusBookReq(indata);
                        _transaction.Commit();
                    }
                }
                else
                {
                    _repo.T14BuRepo.ValidateBookReq(indata);
                    indata = await _repo.T14BuRepo.UpdateAsyncBookReq(indata);
                }

                indata = await _repo.ContractShare.ViewApprovalReqStation(indata);
                indata = await _repo.ContractShare.ViewContractStation(indata);

                return Json(new ResultModelJson<TAllMasterVendorView>
                {
                    Status = true,
                    Result = indata,
                    UrlRedirect = _repo.ContractShareNhso.SetUrlRedirectReqApprove(indata)
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

        //T14 โครงการ สร้างนิติกรรมสัญญา,ออกเลขที่สัญญา 
        public async Task<IActionResult> T14C(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;
                if (!string.IsNullOrEmpty(indata.IdSmctMaster))
                {
                    response = await _repo.T14BuRepo.GetView(indata);
                    response.ObjectState = _repo.GeneralRepo.SetState(indata.State);
                }
                else
                {
                    response = await _repo.T14BuRepo.InitialData(response);
                }

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }
        }

        [HttpPost]
        public async Task<IActionResult> T14C([FromForm] TAllMasterVendorView indata)
        {
            try
            {
                int btnSubmit = int.Parse(indata.BtnSubmit);
                if (btnSubmit == (int)ButtonState.Draft || btnSubmit == (int)ButtonState.Forward || btnSubmit == (int)ButtonState.T1_EDIT)
                {
                    if (indata.ApproveContract != null && indata.ApproveContract.UnApprove && btnSubmit == (int)ButtonState.Forward)
                    {
                        using (var _transaction = _repo.BeginTransaction())
                        {
                            await _repo.ContractShareNhso.UpdateStatusContract(indata);
                            _transaction.Commit();
                        }
                    }
                    else
                    {
                        //ขอแก้ไขหลังผูกพัน
                        if (indata.ApproveBinding != null && indata.ApproveBinding.UnApprove)
                        {
                            using (var _transaction = _repo.BeginTransaction())
                            {
                                await _repo.ContractShareNhso.UpdateRequestBinding(indata);
                                _transaction.Commit();
                            }
                        }
                        else
                        {
                            _repo.T14BuRepo.ValidateContract(indata);
                            indata = await _repo.T14BuRepo.UpdateAsyncContract(indata);
                        }
                    }
                }
                else if (btnSubmit == (int)ButtonState.GenContractId)
                {
                    await _repo.ContractShareNhso.UpdateContractNumber(indata);
                }
                else if (btnSubmit == (int)ButtonState.SignerAttachFile || btnSubmit == (int)ButtonState.Signer || btnSubmit == (int)ButtonState.SignerWitness)
                {
                    await _repo.ContractShareNhso.UpdateSigner(indata);
                }
                else if (btnSubmit == (int)ButtonState.T2_CANCEL || btnSubmit == (int)ButtonState.T4_CLOSEPROJECT || btnSubmit == (int)ButtonState.T5_TERMINATE)
                {
                    await _repo.ContractShareNhso.UpdateRequestBinding(indata);
                }
                else if (btnSubmit == (int)ButtonState.T3_EXPAND)
                {
                    await _repo.ContractShareNhso.UpdateEXPAND(indata);
                }

                indata = await _repo.ContractShare.ViewApprovalReqStation(indata);
                indata = await _repo.ContractShare.ViewContractStation(indata);

                return Json(new ResultModelJson<TAllMasterVendorView>
                {
                    Status = true,
                    Result = indata,
                    UrlRedirect = _repo.ContractShareNhso.SetUrlRedirectContract(indata)
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
        public IActionResult ApprovalNHSODept()
        {
            return View();
        }
        public IActionResult ApprovalNHSO()
        {
            return View();
        }

        public async Task<IActionResult> CheckList(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView response = new TAllMasterVendorView();
                response.ParameterCondition = indata;

                response = await _repo.ContractShareNhso.ViewCheckList(response);

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CheckList([FromForm] TAllMasterVendorView indata)
        {
            try
            {
                await _repo.ContractShareNhso.UpdateCheckList(indata);

                return Json(new ResultModelJson<Boolean>
                {
                    Status = true,
                    Result = true,
                    UrlRedirect = _repo.ContractShareNhso.SetUrlRedirectReqApprove(indata)
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

        //กำหนดรหัสคู่สัญญา
        public async Task<IActionResult> VendorLink(ParameterCondition indata)
        {
            try
            {
                RegisterMaster response = new RegisterMaster();
                String _IdUserSmct = String.Empty;
                if (!String.IsNullOrEmpty(indata.Idvl))
                    _IdUserSmct = SecurityRepo.Decrypt(indata.Idvl);

                response = await _repo.Registers.GetView(IdUserSmct: _IdUserSmct);
                response = await _repo.Registers.InitialData(response);
                response.ParameterCondition = indata;

                return View(response);
            }
            catch (Exception ex)
            {
                return View(new TAllMasterVendorView() { errorCheck = true, errorMessage = GeneralUtils.GetExMessage(ex) });
            }
        }

        [HttpPost]
        public async Task<IActionResult> VendorLink([FromForm] RegisterMaster indata)
        {
            try
            {
                RegisterMaster response = new RegisterMaster();

                await _repo.ContractShareNhso.ApproveVendorLink(indata);

                return Json(new ResultModelJson<Boolean>
                {
                    Status = true,
                    Result = true,
                    UrlRedirect = $"{_mySet.SubDomainServer}/home/indexvendorlink"
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

        public async Task<IActionResult> SentMailApprovalReq(ParameterCondition indata)
        {
            try
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
                var pathView = $@"/Views/Shared/EmailTemplate/ApproveReq/ReqCheck.cshtml";
                var htmlBody = await _razorView.RenderViewToStringAsync(pathView, model);
                var emaildata = await _repo.ContractShareNhso.GetSentMailReqApp(model, htmlBody);
                await _repo.emailSender.SendEmail(emaildata);

                await _repo.ContractShareNhso.UpdateStatusBookReqMailStatus(model, true);

                return Json(new ResultModelJson<Boolean>
                {
                    Status = true
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

        public async Task<IActionResult> SentMailSigner(ParameterCondition indata)
        {
            try
            {
                TAllMasterVendorView model = new TAllMasterVendorView();

                model.ParameterCondition = indata;
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

                model.DomainName = _mySet.SubDomainServer;
                var pathView = $@"/Views/Shared/EmailTemplate/Signer/ServiceUnit.cshtml";
                var htmlBody = await _razorView.RenderViewToStringAsync(pathView, model);
                var emaildata = await _repo.ContractShareNhso.GetSentMailSigner(model, htmlBody);
                await _repo.emailSender.SendEmail(emaildata);

                return Json(new ResultModelJson<Boolean>
                {
                    Status = true
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


