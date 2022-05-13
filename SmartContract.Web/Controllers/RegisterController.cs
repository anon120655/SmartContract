using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Interfaces.Authenticate;
using SmartContract.Infrastructure.Interfaces.Share;
using SmartContract.Infrastructure.Resources.Authenticate;
using SmartContract.Infrastructure.Resources.Enum;
using SmartContract.Infrastructure.Resources.Registers;
using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Infrastructure.Wrapper;
using SmartContract.Utils;

namespace SmartContract.Web.Controllers
{

    public class RegisterController : Controller
    {
        private IRepositoryWrapper _repo;
        private readonly IUserService _userManager;
        private readonly AppSettings _mySet;
        private readonly IRazorViewToStringRenderer _razorView;
        private readonly IWebHostEnvironment _env;
        public const string SessionSpecialCode = "specialcode";
        public const string SessionSpecialCodeCheck = "specialcodecheck";

        public RegisterController(IRepositoryWrapper repo, IOptions<AppSettings> settings
            , IUserService userManager, IRazorViewToStringRenderer razorView, IWebHostEnvironment env)
        {
            _repo = repo;
            _userManager = userManager;
            _mySet = settings.Value;
            _razorView = razorView;
            _env = env;
        }

        public async Task<IActionResult> Profile(string email = null, string Approvetype = null)
        {
            try
            {
                var response = new RegisterMaster();

                response = await _repo.Registers.GetView(email: email);
                response = await _repo.Registers.InitialData(response);
                if (!String.IsNullOrEmpty(Approvetype))
                    response.Approvetype = SecurityRepo.Decrypt(Approvetype);

                return View(response);
            }
            catch (Exception ex)
            {
                return RedirectToAction("SystemNoti", "Authorize", new { message = GeneralUtils.GetExMessage(ex) });
            }
        }

        public async Task<IActionResult> UserCheck(String email)
        {
            try
            {
                var response = new RegisterMaster();

                return View(response);
            }
            catch (Exception ex)
            {
                return RedirectToAction("SystemNoti", "Authorize", new { message = GeneralUtils.GetExMessage(ex) });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UserCheck([FromForm] RegisterMaster indata)
        {
            try
            {
                _repo.Registers.ValidateUserCheck(indata);
                if (_mySet.CheckCards.IsEnable)
                {
                    indata.UserSmct.UserFullname = $"{indata.UserSmct.FirstName} {indata.UserSmct.LastName}";
                    //var responseCardApi = await _repo.SoapService.CheckCardByLaserAsync("3440900372380", "บุญโฮม", "พานพิมพ์", "25070222", "JC2077425956");                 
                    String BirthDay = $"{indata.UserSmct.BirthdayStr.Substring(6)}{indata.UserSmct.BirthdayStr.Substring(3, 2)}{ indata.UserSmct.BirthdayStr.Substring(0, 2)}";
                    var responseCardApi = await _repo.SoapService.CheckCardByLaserAsync(indata.UserSmct.Cid, indata.UserSmct.FirstName, indata.UserSmct.LastName, BirthDay, indata.UserSmct.Laser);
                    if (responseCardApi.IsError)
                    {
                        throw new Exception(responseCardApi.Desc);
                    }
                }

                return Json(new ResultModelJson<object>
                {
                    Status = true,
                    Result = new { semail = "" },
                    UrlRedirect = $"Register?email={indata.UserSmct.Email}" +
                    $"&UserFullname={indata.UserSmct.FirstName} {indata.UserSmct.LastName}" +
                    //$"&PositionName={indata.UserSmct.PositionName}" +
                    $"&Cid={indata.UserSmct.Cid}" +
                    $"&BirthdayStr={indata.UserSmct.BirthdayStr}"
                });
            }
            catch (Exception ex)
            {
                return Json(new ResultModelJson<Boolean>
                {
                    Status = false,
                    MessagError = GeneralUtils.GetExMessage(ex)
                });
            }
        }

        public async Task<IActionResult> Register(string email, string UserFullname = null, /*string PositionName = null,*/ string Cid = null, string BirthdayStr = null, string IdUserSmct = null, string State = null, string Verify = null, string Approvetype = null)
        {

            //var _StateEn = SecurityRepo.Encrypt("2");
            try
            {
                var roleCode = _repo.UserService.GetRoleRoleCode();
                if (GroupRoles.GroupRoleUnit.Contains(roleCode))
                {
                    if (!String.IsNullOrEmpty(Verify))
                    {
                        if (SecurityRepo.Decrypt(Verify) != "true")
                        {
                            //var specialCodeCheck = HttpContext.Session.GetString(SessionSpecialCodeCheck);
                            //if (specialCodeCheck != "Success")
                            //    return RedirectToAction("SystemNoti", "Authorize", new { message = "ยังไม่ผ่านการยืนยัน 2FA" });
                        }
                    }
                    else
                    {
                        //var specialCodeCheck = HttpContext.Session.GetString(SessionSpecialCodeCheck);
                        //if (specialCodeCheck != "Success")
                        //    return RedirectToAction("SystemNoti", "Authorize", new { message = "ยังไม่ผ่านการยืนยัน 2FA" });
                    }
                }

                var response = new RegisterMaster();
                if (!String.IsNullOrEmpty(email))
                    response.UserSmct.Email = email;
                if (!String.IsNullOrEmpty(UserFullname))
                    response.UserSmct.UserFullname = UserFullname;
                //if (!String.IsNullOrEmpty(PositionName))
                //    response.UserSmct.PositionName = PositionName;
                if (!String.IsNullOrEmpty(Cid))
                    response.UserSmct.Cid = Cid;
                if (!String.IsNullOrEmpty(BirthdayStr))
                    response.UserSmct.BirthdayStr = BirthdayStr;

                if (!String.IsNullOrEmpty(IdUserSmct))
                {
                    response = await _repo.Registers.GetView(IdUserSmct: IdUserSmct);
                }
                response = await _repo.Registers.InitialData(response);
                response.ObjectState = _repo.GeneralRepo.SetState(State);
                if (!String.IsNullOrEmpty(Approvetype))
                    response.Approvetype = SecurityRepo.Decrypt(Approvetype);

                return View(response);
            }
            catch (Exception ex)
            {
                return RedirectToAction("SystemNoti", "Authorize", new { message = GeneralUtils.GetExMessage(ex) });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterMaster indata)
        {
            try
            {
                //_repo.Registers.Validate(indata);
                if (indata.ObjectState == TObjectState.Create)
                {
                    await _repo.Registers.CreateAsync(indata);
                }
                else if (indata.ObjectState == TObjectState.Update)
                {
                    await _repo.Registers.UpdateAsync(indata);
                }

                HttpContext.Session.SetString(SessionSpecialCodeCheck, String.Empty);
                return Json(new ResultModelJson<Boolean>
                {
                    Status = true,
                    Result = true,
                    UrlRedirect = $"Profile?email={indata.UserSmct.Email}&Approvetype={SecurityRepo.Encrypt(indata.Approvetype)}"
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

        public IActionResult RegisterUser()
        {
            return View();
        }


        public IActionResult CheckMailPassCode()
        {
            String _State = GeneralUtils.RandomString(8);
            String _UrlDDOPA = $"{_mySet.DDOPAs.DomainDDOPA}/{_mySet.DDOPAs.UrlAuth}/?response_type={_mySet.DDOPAs.response_type}";
            _UrlDDOPA = $"{_UrlDDOPA}&client_id={_mySet.DDOPAs.client_id}";
            _UrlDDOPA = $"{_UrlDDOPA}&redirect_uri={_mySet.DDOPAs.redirect_uri}";
            _UrlDDOPA = $"{_UrlDDOPA}&scope=pid%20th_fullname%20en_fullname%20dob%20address%20th_fname%20th_mname%20th_lname%20en_fname%20en_mname%20en_lname%20sex";
            _UrlDDOPA = $"{_UrlDDOPA}&state={_State}";

            RegisterMaster Modal = new RegisterMaster()
            {
                UrlDDOPA = _UrlDDOPA,
                StateRandom = _State,
                ServerSite = _mySet.ServerSite
            };

            return View(Modal);
        }

        [HttpPost]
        public async Task<IActionResult> CheckMailPassCode(String email)
        {
            try
            {
                if (String.IsNullOrEmpty(email)) throw new Exception("ระบุ email!");

                String passCode = GeneralUtils.RandomString(8);
                HttpContext.Session.SetString(SessionSpecialCode, String.Empty);
                HttpContext.Session.SetString(SessionSpecialCode, passCode);
                CheckPassCode modelBody = new CheckPassCode()
                {
                    email = email,
                    PassCode = passCode
                };
                var pathView = $@"/Views/Shared/EmailTemplate/Register/CheckPassCode.cshtml";
                var htmlBody = await _razorView.RenderViewToStringAsync(pathView, modelBody);
                var emaildata = _userManager.CheckMailPassCode(modelBody, htmlBody, email);
                await _repo.emailSender.SendEmail(emaildata);
                return Json(new ResultModelJson<object>
                {
                    Status = true,
                    Result = new { semail = email },
                    UrlRedirect = ""
                });
            }
            catch (Exception ex)
            {
                return Json(new ResultModelJson<Boolean>
                {
                    Status = false,
                    MessagError = GeneralUtils.GetExMessage(ex)
                });
            }
        }


        [HttpPost]
        public IActionResult SpecialCode(String code, String semail)
        {
            try
            {
                if (String.IsNullOrEmpty(code))
                    throw new Exception("ระบุรหัสพิเศษ!");

                var specialCode = HttpContext.Session.GetString(SessionSpecialCode);

                if (specialCode != code)
                    throw new Exception("ระบุรหัสพิเศษไม่ถูกต้อง");

                HttpContext.Session.SetString(SessionSpecialCode, String.Empty);
                HttpContext.Session.SetString(SessionSpecialCodeCheck, "Success");
                return Json(new ResultModelJson<Boolean>
                {
                    Status = true,
                    Result = true,
                    UrlRedirect = $"UserCheck?email={semail}"
                });
            }
            catch (Exception ex)
            {
                return Json(new ResultModelJson<Boolean>
                {
                    Status = false,
                    MessagError = GeneralUtils.GetExMessage(ex)
                });
            }
        }

        public IActionResult Manager()
        {
            return View();
        }

        public async Task<IActionResult> RegisterCheck(int? page = 1, int pagesize = 10, String Style = null, SearchOptionRegCheck Condition = null)
        {
            try
            {
                TrackingRegCheckMain response = new TrackingRegCheckMain();
                response = await _repo.Registers.Dashboard(response);
                response.TrackingResource = _repo.Registers.GetTrackingRegCheck(page, pagesize, Condition);

                return View(response);

            }
            catch (Exception ex)
            {
                return View(new TrackingRegCheckMain() { errorCheck = true, errorMessage = ex.Message });
            }
        }

        public async Task<IActionResult> RegisterCheckUser(int? page = 1, int pagesize = 10, String Style = null, SearchOptionRegCheck Condition = null)
        {
            try
            {
                TrackingRegCheckMain response = new TrackingRegCheckMain();
                response = await _repo.Registers.DashboardUser(response);
                response.TrackingResource = _repo.Registers.GetTrackingRegCheckUser(page, pagesize, Condition);

                return View(response);

            }
            catch (Exception ex)
            {
                return View(new TrackingRegCheckMain() { errorCheck = true, errorMessage = ex.Message });
            }
        }

        public async Task<IActionResult> Approve(string IdUserSmct, string IdRegisterNhso, string Approvetype)
        {
            try
            {
                var response = new RegisterMaster();

                response = await _repo.Registers.GetView(IdUserSmct: IdUserSmct, IdRegisterNhso: IdRegisterNhso);
                response.Approvetype = SecurityRepo.Decrypt(Approvetype);

                return View(response);
            }
            catch (Exception ex)
            {
                return RedirectToAction("SystemNoti", "Authorize", new { message = GeneralUtils.GetExMessage(ex) });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Approve([FromForm] RegisterMaster indata)
        {
            try
            {
                await _repo.Registers.SaveStatus(indata);

                return Json(new ResultModelJson<String>
                {
                    Status = true,
                    Result = indata.Approvetype,
                    UrlRedirect = indata.Approvetype == "U" ? "registercheckuser" : "registercheck"
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

        [HttpPost]
        public async Task<IActionResult> SentMailVerify(string IdUserSmct, string Approvetype)
        {
            try
            {
                RegisterMaster response = new RegisterMaster();
                response = await _repo.Registers.GetView(IdUserSmct: IdUserSmct);
                response.Approvetype = Approvetype;

                response.DomainName = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                var pathView = $@"/Views/Shared/EmailTemplate/Register/Verify.cshtml";
                var htmlBody = await _razorView.RenderViewToStringAsync(pathView, response);
                var emaildata = _repo.Registers.GetMailVerify(response, htmlBody);
                await _repo.emailSender.SendEmail(emaildata);

                return Json(new ResultModelJson<Boolean>
                {
                    Status = true
                });


                throw new Exception("SentMail Off");
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


    }
}
