using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Interfaces.Authenticate;
using SmartContract.Infrastructure.Resources.Authenticate;
using SmartContract.Infrastructure.Resources.Other;
using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Infrastructure.Wrapper;
using SmartContract.Utils;
using SmartContract.Web.Models;
using Microsoft.Extensions.Configuration;
using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Share.ServiceOther;

namespace SmartContract.Web.Controllers
{
	public class AuthorizeController : Controller
	{
		private readonly AppSettings _mySet;
		private IRepositoryWrapper _repo;
		private readonly IUserService _userManager;

		public const string SessionToken = "accesstoken";
		public const string SessionUserName = "username";
		public const string SessionUserFullName = "userfullname";
		public const string SessionUserDepartmentCode = "departmentcode";
		public const string SessionUserVendorId = "vendorid";
		public const string SessionUserVendorName = "vendorname";
		public const string SessionRoleCode = "rolecode";
		public const string SessionRoleShotName = "roleshotname";
		public const string SessionRoleFullName = "rolefullname";
		public const string SessionUserIdUserSmct = "idusersmct";
		public const string SessionUserEmail = "email";
		public const string SessionSpecialCodeCheck = "specialcodecheck";
		public const string SessionSubDomainServer = "subdomainserver";
		public const string SessionRegisterType = "registertype";


		public AuthorizeController(IRepositoryWrapper repo, IOptions<AppSettings> settings, IUserService userManager)
		{
			_mySet = settings.Value;
			_repo = repo;
			_userManager = userManager;
		}

		public async Task<IActionResult> Portal(String Uid)
		{
			try
			{
				//var hastmd5 = SecurityRepo.MD5Encrypt("User1");
				var userName = SecurityRepo.MD5Decrypt(Uid);
				var data = await _userManager.LocalAuthen(new UserLogin()
				{
					Email = userName
				}, true).ConfigureAwait(true);

				await _repo.UserService.LogUser(data.IdUserSmct);
				HttpContext.Session.SetString(SessionUserIdUserSmct, data.IdUserSmct);
				HttpContext.Session.SetString(SessionUserDepartmentCode, data.DepartmentCode);
				HttpContext.Session.SetString(SessionUserName, data.Username);
				HttpContext.Session.SetString(SessionUserEmail, data.Email);
				HttpContext.Session.SetString(SessionRoleCode, data.UserRoles.UserRoleCode);
				HttpContext.Session.SetString(SessionRoleShotName, data.UserRoles.ShortName);
				HttpContext.Session.SetString(SessionRoleFullName, data.UserRoles.FullName);
				HttpContext.Session.SetString(SessionUserFullName, data.UserFullname);
				HttpContext.Session.SetString(SessionUserVendorId, data.VendorId);
				HttpContext.Session.SetString(SessionUserVendorName, data.VendorName);
				HttpContext.Session.SetString(SessionRegisterType, data?.RegisterType ?? String.Empty);
				HttpContext.Session.SetString(SessionSubDomainServer, _mySet.SubDomainServer);

				if (data.Status == UserSmctStatus.WaitUse)
				{
					return Redirect($"{_mySet.SubDomainServer}/Register/Profile?email={data.Email}");
				}

				Enum.TryParse(data.UserRoles.UserRoleCode, out PermissionRole userRoleCode);

				if (GroupRoles.GroupRoleAdmin.Contains(userRoleCode))
				{
					return Redirect($"{_mySet.SubDomainServer}/Home/dashboard");
				}

				String _HomeVendor = "/HomeVendor/Index";
				if (data.RegisterType.StartsWith("G"))
				{
					_HomeVendor = "/HomeVendor/Index2";
				}

				return Redirect(_HomeVendor);

			}
			catch (Exception ex)
			{
				return RedirectToAction("SystemNoti", "Authorize", new { message = GeneralUtils.GetExMessage(ex) });
			}
		}

		public IActionResult Local()
		{
			//var hastmd5 = SecurityRepo.MD5Encrypt("123456789");
			//var de = SecurityRepo.MD5Decrypt(hastmd5);
			String _State = GeneralUtils.RandomString(8);
			String _UrlDDOPA = $"{_mySet.DDOPAs.DomainDDOPA}/{_mySet.DDOPAs.UrlAuth}/?response_type={_mySet.DDOPAs.response_type}";
			_UrlDDOPA = $"{_UrlDDOPA}&client_id={_mySet.DDOPAs.client_id}";
			_UrlDDOPA = $"{_UrlDDOPA}&redirect_uri={_mySet.DDOPAs.redirect_uri}";
			_UrlDDOPA = $"{_UrlDDOPA}&scope=pid%20th_fullname%20en_fullname%20dob%20address%20th_fname%20th_mname%20th_lname%20en_fname%20en_mname%20en_lname%20sex%20openid";
			//_UrlDDOPA = $"{_UrlDDOPA}&scope=pid%20th_fullname%20en_fullname%20dob%20address%20th_fname%20th_mname%20th_lname%20en_fname%20en_mname%20en_lname%20sex";
			_UrlDDOPA = $"{_UrlDDOPA}&state={_State}";

			UserLogin Modal = new UserLogin()
			{
				UrlDDOPA = _UrlDDOPA,
				StateRandom = _State,
				ServerSite = _mySet.ServerSite
			};

			return View(Modal);
		}

		[HttpPost]
		public async Task<IActionResult> Local(UserLogin login)
		{
			try
			{
				var data = await _userManager.LocalAuthen(login).ConfigureAwait(true);
				await _repo.UserService.LogUser(data.IdUserSmct);
				HttpContext.Session.SetString(SessionUserIdUserSmct, data.IdUserSmct);
				HttpContext.Session.SetString(SessionUserDepartmentCode, data.DepartmentCode);
				HttpContext.Session.SetString(SessionUserName, data.Username);
				HttpContext.Session.SetString(SessionUserEmail, data.Email);
				HttpContext.Session.SetString(SessionRoleCode, data.UserRoles.UserRoleCode);
				HttpContext.Session.SetString(SessionRoleShotName, data.UserRoles.ShortName);
				HttpContext.Session.SetString(SessionRoleFullName, data.UserRoles.FullName);
				HttpContext.Session.SetString(SessionUserFullName, data.UserFullname);
				HttpContext.Session.SetString(SessionUserVendorId, data?.VendorId ?? String.Empty);
				HttpContext.Session.SetString(SessionUserVendorName, data?.VendorName ?? String.Empty);
				HttpContext.Session.SetString(SessionRegisterType, data?.RegisterType ?? String.Empty);
				HttpContext.Session.SetString(SessionSubDomainServer, _mySet.SubDomainServer);

				if (data.Status == UserSmctStatus.WaitUse)
				{
					return Json(new ResultModelJson<Boolean>
					{
						Status = true,
						Result = true,
						UrlRedirect = $"{_mySet.SubDomainServer}/Register/Profile?email={data.Email}"
					});
				}
				//TempData.Put("LKProvinces", _repo.MasterData.LKProvinces());
				//TempData.Put("LKAmphurs", _repo.MasterData.LKAmphurs());
				//TempData.Put("LKDistricts", _repo.MasterData.LKDistricts());
				Enum.TryParse(data.UserRoles.UserRoleCode, out PermissionRole userRoleCode);

				if (GroupRoles.GroupRoleAdmin.Contains(userRoleCode))
				{
					return Json(new ResultModelJson<Boolean>
					{
						Status = true,
						Result = true,
						UrlRedirect = $"{_mySet.SubDomainServer}/Home/dashboard"
					});
				}

				if (data.RegisterType == null) throw new Exception("ประเภทผู้ใช้งาน ไม่ตรงกับบทบาท");

				String _HomeVendor = "/HomeVendor/Index";
				if (data.RegisterType.StartsWith("G"))
				{
					_HomeVendor = "/HomeVendor/Index2";
				}
				return Json(new ResultModelJson<Boolean>
				{
					Status = true,
					Result = true,
					UrlRedirect = $"{_mySet.SubDomainServer}{_HomeVendor}"
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

		//fix ไว้ให้กดที่ qr code ได้ ใช้จริงไม่ได้ใช้
		[HttpPost]
		public async Task<IActionResult> Local2(UserLogin login)
		{
			try
			{
				var data = await _userManager.LocalAuthen(login).ConfigureAwait(true);

				HttpContext.Session.SetString(SessionUserIdUserSmct, data.IdUserSmct);
				HttpContext.Session.SetString(SessionUserDepartmentCode, data.DepartmentCode);
				HttpContext.Session.SetString(SessionUserName, data.Username);
				HttpContext.Session.SetString(SessionUserEmail, data.Email);
				HttpContext.Session.SetString(SessionRoleCode, data.UserRoles.UserRoleCode);
				HttpContext.Session.SetString(SessionRoleShotName, data.UserRoles.ShortName);
				HttpContext.Session.SetString(SessionRoleFullName, data.UserRoles.FullName);
				HttpContext.Session.SetString(SessionUserFullName, data.UserFullname);
				HttpContext.Session.SetString(SessionUserVendorId, data.VendorId);
				HttpContext.Session.SetString(SessionUserVendorName, data.VendorName);

				Enum.TryParse(data.UserRoles.UserRoleCode, out PermissionRole userRoleCode);

				if (GroupRoles.GroupRoleAdmin.Contains(userRoleCode))
				{
					return RedirectToAction("Dashboard", "Home");
				}

				return RedirectToAction("Index", "HomeVendor");

			}
			catch (Exception ex)
			{
				return RedirectToAction("SystemNoti", "Authorize", new { message = ex.Message });
			}
		}

		public async Task<IActionResult> DDOPA(DDOPALogin login)
		{
			try
			{
				var data2 = await _userManager.DDOPAAuthen(login).ConfigureAwait(true);

				if (!String.IsNullOrEmpty(login.code) && !String.IsNullOrEmpty(login.state))
				{
					var ddopatoken = await _repo.ServiceOther.DDOPAToken(new DDOPATokenRequest()
					{
						code = login.code
					});

					if (ddopatoken == null || ddopatoken.pid == null) throw new Exception("ไม่พบข้อมูล DDOPA");

					var user = await _userManager.GetUserByCID(ddopatoken.pid);
					
					if (user == null) throw new Exception("ไม่พบข้อมูลผู้ใช้งาน");

					var data = await _userManager.LocalAuthen(new UserLogin() { Email = user.Email, PassWord = user.Password }).ConfigureAwait(true);
					HttpContext.Session.SetString(SessionUserIdUserSmct, data.IdUserSmct);
					HttpContext.Session.SetString(SessionUserDepartmentCode, data.DepartmentCode);
					HttpContext.Session.SetString(SessionUserName, data.Username);
					HttpContext.Session.SetString(SessionUserEmail, data.Email);
					HttpContext.Session.SetString(SessionRoleCode, data.UserRoles.UserRoleCode);
					HttpContext.Session.SetString(SessionRoleShotName, data.UserRoles.ShortName);
					HttpContext.Session.SetString(SessionRoleFullName, data.UserRoles.FullName);
					HttpContext.Session.SetString(SessionUserFullName, data.UserFullname);
					HttpContext.Session.SetString(SessionUserVendorId, data?.VendorId ?? String.Empty);
					HttpContext.Session.SetString(SessionUserVendorName, data?.VendorName ?? String.Empty);
					HttpContext.Session.SetString(SessionRegisterType, data?.RegisterType ?? String.Empty);
					HttpContext.Session.SetString(SessionSubDomainServer, _mySet.SubDomainServer);

					return RedirectToAction("dashboard", "Home");
				}

				if (login.error != null && login.error_description != null)
				{
					throw new Exception(login.error_description);
				}
				else
				{
					throw new Exception("เกิดข้อมูลพลาดในการเชื่อมต่อ DDOPA กรุณาติดต่อผู้ดูแลระบบ");
				}
			}
			catch (Exception ex)
			{
				return RedirectToAction("SystemNoti", "Authorize", new { message = ex.Message });
			}
		}

		public IActionResult LoginPassCode()
		{
			return View();
		}

		public IActionResult LogOut(string code = null)
		{
			HttpContext.Session.SetString(SessionToken, String.Empty);
			HttpContext.Session.SetString(SessionUserName, String.Empty);
			HttpContext.Session.SetString(SessionUserFullName, String.Empty);
			HttpContext.Session.SetString(SessionUserVendorId, String.Empty);
			HttpContext.Session.SetString(SessionUserVendorName, String.Empty);
			HttpContext.Session.SetString(SessionUserDepartmentCode, String.Empty);
			HttpContext.Session.SetString(SessionRoleCode, String.Empty);
			HttpContext.Session.SetString(SessionRoleShotName, String.Empty);
			HttpContext.Session.SetString(SessionRoleFullName, String.Empty);
			HttpContext.Session.SetString(SessionUserIdUserSmct, String.Empty);
			HttpContext.Session.SetString(SessionUserEmail, String.Empty);
			HttpContext.Session.SetString(SessionSpecialCodeCheck, String.Empty);
			HttpContext.Session.SetString(SessionRegisterType, String.Empty);
			HttpContext.Session.SetString(SessionSubDomainServer, String.Empty);

			return RedirectToAction("Local");
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

		public IActionResult ChangePassword()
		{
			try
			{
				ChangePasswordMain response = new ChangePasswordMain();
				response.IdUserSmct = _repo.UserService.GetIdUserSmct();
				return View(response);
			}
			catch (Exception ex)
			{
				return RedirectToAction("SystemNoti", "Authorize", new { message = GeneralUtils.GetExMessage(ex) });
			}

		}

		[HttpPost]
		public async Task<IActionResult> ChangePassword(ChangePasswordMain indata)
		{
			try
			{
				await _userManager.ChangePassword(indata);

				String _ActionHome = "Index";
				if (_userManager.GetRegisterType().Contains("G"))
					_ActionHome = "Index2";

				return Json(new ResultModelJson<ChangePasswordMain>
				{
					Status = true,
					Result = indata,
					UrlRedirect = $"{_mySet.SubDomainServer}/homevendor/{_ActionHome}"
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
