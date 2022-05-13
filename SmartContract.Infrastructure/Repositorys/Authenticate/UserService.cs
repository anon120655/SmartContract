using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MimeKit;
using SmartContract.Infrastructure.Data.ConnectionContext;
using SmartContract.Infrastructure.Data.EntityFramework;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Interfaces;
using SmartContract.Infrastructure.Interfaces.Authenticate;
using SmartContract.Infrastructure.Resources.Authenticate;
using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Other;
using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Infrastructure.Wrapper;
using SmartContract.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Repositorys.Authenticate
{
	public class UserService : IUserService
	{
		private IRepositoryWrapper _repo;
		private readonly IRepositoryBase _db;
		private readonly IWebHostEnvironment _env;
		private readonly AppSettings _mySet;
		private IHttpContextAccessor _httpConAcc;
		private readonly IMapper _mapper;

		public UserService(IRepositoryWrapper repo, IRepositoryBase db,
			IWebHostEnvironment env, IMapper mapper, IOptions<AppSettings> settings, IHttpContextAccessor httpConAcc)
		{
			_db = db;
			_env = env;
			_repo = repo;
			_mapper = mapper;
			_mySet = settings.Value;
			_httpConAcc = httpConAcc;
		}

		public string GetIdUserSmct()
		{
			String IdUserSmct = "8741AA9AFC914431A79124047B9974B9";
			if (_httpConAcc.HttpContext.Session.GetString("idusersmct") != null && _httpConAcc.HttpContext.Session.GetString("idusersmct") != "")
			{
				IdUserSmct = _httpConAcc.HttpContext.Session.GetString("idusersmct")?.ToString();
			}
			return IdUserSmct;
		}
		public string GetEmail()
		{
			return _httpConAcc.HttpContext.Session.GetString("email")?.ToString() ?? String.Empty;
		}

		public PermissionRole GetRoleRoleCode()
		{
			String rolecode = _httpConAcc.HttpContext.Session.GetString("rolecode")?.ToString() ?? String.Empty;
			if (rolecode == "01")
				return PermissionRole.SystemAdmin;
			if (rolecode == "02")
				return PermissionRole.CentralAdmin;
			if (rolecode == "03")
				return PermissionRole.CentralUser;
			if (rolecode == "04")
				return PermissionRole.KetSigner;
			if (rolecode == "05")
				return PermissionRole.KetOfficer;
			if (rolecode == "06")
				return PermissionRole.Signer1;
			if (rolecode == "07")
				return PermissionRole.Signer2;
			if (rolecode == "08")
				return PermissionRole.Coordinator;
			if (rolecode == "09")
				return PermissionRole.User;

			return PermissionRole.User;
		}

		public string GetRoleShotName()
		{
			return _httpConAcc.HttpContext.Session.GetString("roleshotname")?.ToString() ?? String.Empty;
		}

		public string GetRoleFullName()
		{
			return _httpConAcc.HttpContext.Session.GetString("rolefullname")?.ToString() ?? String.Empty;
		}

		public string GetUserName()
		{
			return _httpConAcc.HttpContext.Session.GetString("username")?.ToString() ?? String.Empty;
		}

		public string GetUserFullName()
		{
			return _httpConAcc.HttpContext.Session.GetString("userfullname")?.ToString() ?? String.Empty;
		}

		public string GetVendorId()
		{
			return _httpConAcc.HttpContext.Session.GetString("vendorid")?.ToString() ?? String.Empty;
		}

		public string GetVendorName()
		{
			return _httpConAcc.HttpContext.Session.GetString("vendorname")?.ToString() ?? " ";
		}

		public string GetDepartmentCode()
		{
			//ถ้าไม่มีใน 13 เขต ใน Default เป็น 42000 เขต กทม.
			var departmentcode = _httpConAcc.HttpContext.Session.GetString("departmentcode")?.ToString() ?? String.Empty;
			if (departmentcode == "03000"
				|| departmentcode == "03100"
				|| departmentcode == "03200"
				|| departmentcode == "03300"
				|| departmentcode == "03400"
				|| departmentcode == "03500"
				|| departmentcode == "03600"
				|| departmentcode == "03700"
				|| departmentcode == "03800"
				|| departmentcode == "03900"
				|| departmentcode == "04000"
				|| departmentcode == "04100"
				|| departmentcode == "04200")
			{
				return departmentcode;
			}
			return "04200";
		}

		public string GetRegisterType()
		{
			return _httpConAcc.HttpContext.Session.GetString("registertype")?.ToString() ?? String.Empty;
		}

		public async Task<UserSmctDTO> GetUserByCID(string CID)
		{
			var userSmct = await _repo.Context.UserSmcts.Where(x => x.Cid == CID && x.Used).FirstOrDefaultAsync();

			if (userSmct == null) return null;

			var responseMap = _mapper.Map<UserSmctDTO>(userSmct);

			return responseMap;
		}

		public async Task<UserSmctDTO> LocalAuthen(UserLogin iuser, bool? IsPortal = null)
		{
			var userSmct = await _repo.Context.UserSmcts.Where(x => (x.Email == iuser.Email || x.Username.StartsWith(iuser.Email)) && x.Used).FirstOrDefaultAsync();

			var responseMap = _mapper.Map<UserSmctDTO>(userSmct);

			if (userSmct == null)
			{
				try
				{
					var responseApi = await _repo.SoapService.authenAndUserInfoAsync(new ServiceIAMAuthentication.authenWSRequest()
					{
						domainName = _mySet.IAMs.domainName,
						userName = iuser.Email,
						password = iuser.PassWord
					});
					if (responseApi != null && responseApi.@return.message == "OK")
					{
						await this.AddUserInfoByiAm(responseApi, iuser.PassWord);
						userSmct = await _repo.Context.UserSmcts.Where(x => (x.Email == iuser.Email || x.Username == iuser.Email) && x.Used).FirstOrDefaultAsync();
						responseMap = _mapper.Map<UserSmctDTO>(userSmct);
					}
					else
					{
						throw new Exception("ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง");
					}
				}
				catch (Exception ex)
				{
					throw new Exception($"ERROR URL:{$"{_mySet.IAMs.DomainIAM}{_mySet.IAMs.UrlAuthenAndUserInfo}"} ex : {GeneralUtils.GetExMessage(ex)}");
				}
			}
			else
			{
				if (IsPortal == null)
				{
					if (userSmct.Password != iuser.PassWord)
						throw new Exception("ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง");
				}
			}

			//if (userSmct.Status == UserSmctStatus.WaitUse)
			//    return responseMap;
			if (userSmct.Status == UserSmctStatus.WaitUse)
				throw new Exception("ผู้ใช้รออนุมัติใช้งาน");


			var userRights = await _repo.Context.UserRights.FirstOrDefaultAsync(x => x.IdUserSmct == userSmct.IdUserSmct && x.Used);
			if (userRights == null)
				throw new Exception("ไม่พบสิทธิ์ผู้เข้าใช้งาน UserRights");

			responseMap.UserRights = _mapper.Map<UserRightDTO>(userRights);

			var userRoles = await _repo.Context.UserRoles.FirstOrDefaultAsync(x => x.IdUserRole == userRights.IdUserRole && x.Used);
			if (userRoles == null)
				throw new Exception("ไม่พบข้อมูล UserRoles");
			responseMap.UserRoles = _mapper.Map<UserRoleDTO>(userRoles);

			/*
               USER_TYPE=S คือ เขต และ ส่วนกลาง
               1.USER_TYPE=S ไม่ต้องเช็คสถานะการลงทะเบียนหน่วยบริการ
               2.USER_TYPE=F+D ต้องเช็คสถานะการลงทะเบียนหน่วยบริการ
             */
			var userSmctVen = await _repo.Context.UserSmctVendors.FirstOrDefaultAsync(x => x.IdUserSmct == userSmct.IdUserSmct && x.Used);
			if (userSmctVen == null)
				throw new Exception("ไม่พบข้อมูลคู่สัญญา");

			responseMap.VendorId = userSmctVen.VendorId;

			if (responseMap.UserType == UserSmctType.TwoFactor || responseMap.UserType == UserSmctType.DDopa)
			{
				var registerNhsos = await _repo.Context.RegisterNhsos.FirstOrDefaultAsync(x => x.IdRegisterNhso == userSmctVen.IdRegisterNhso
																						  && x.Used);
				if (registerNhsos == null)
					throw new Exception("ไม่พบข้อมูลการลงทะเบียน");

				responseMap.VendorName = registerNhsos.VendorName;
				responseMap.RegisterType = registerNhsos.RegisterType;
			}

			if (responseMap.UserType == UserSmctType.SingleSignOn)
			{
				var LkDepartments = await _repo.Context.LkDepartments.FirstOrDefaultAsync(x => x.Dcode == responseMap.DepartmentCode
																						   && x.Display == "Y");
				if (LkDepartments == null)
					throw new Exception("ไม่พบข้อมูล สำนัก/เขต");

				responseMap.VendorName = LkDepartments.DnameNew;
			}


			return responseMap;
		}

		public async Task AddUserInfoByiAm(ServiceIAMAuthentication.authenAndUserInfoResponse indata, String PassWord)
		{
			var userInfo = indata.@return.userInfo;

			using (var _transaction = _repo.BeginTransaction())
			{
				var userSmct = new UserSmct
				{
					IdUserLevel = "096D1A88CF414EC59EC9C48ED5BAEF10",
					DepartmentCode = "04200",//สำนักงานหลักประกันสุขภาพแห่งชาติ เขต 13 กรุงเทพมหานคร
					Username = userInfo.userName,
					Password = PassWord,
					UserFullname = userInfo.displayName,
					PositionName = userInfo.description,
					Email = userInfo.email,
					Cid = null,
					UserType = UserSmctType.SingleSignOn,
					Status = UserSmctStatus.Used,
					CreateUser = _repo.UserService.GetIdUserSmct(),
					EditUser = _repo.UserService.GetIdUserSmct(),
					CreateDate = DateTime.Now,
					EditDate = DateTime.Now,
					Used = true,
					Birthday = null
				};
				await _db.InsterAsync(userSmct);
				await _db.SaveAsync();

				String _IdUserRole = "9FD48C1845184EDEB53563C9BCB7A88C"; //KetOfficer เจ้าหน้าที่ สำนัก/กองทุนย่อย/เขต
				if (userInfo.zoneCode == "00")
				{
					_IdUserRole = "6F2161F193BE4589B4B29F0B780FC18C"; //CentralUser	ผู้ใช้งานทั่วไป ส่วนกลาง
				}

				var userRight = new UserRight
				{
					IdUserSmct = userSmct.IdUserSmct,
					IdUserRole = _IdUserRole,
					Status = UserSmctStatus.Used,
					CreateUser = _repo.UserService.GetIdUserSmct(),
					EditUser = _repo.UserService.GetIdUserSmct(),
					CreateDate = DateTime.Now,
					EditDate = DateTime.Now,
					Used = true
				};
				await _db.InsterAsync(userRight);
				await _db.SaveAsync();

				var userSmctVendor = new UserSmctVendor
				{
					IdUserSmct = userSmct.IdUserSmct,
					Hcode = "NHSO",
					VendorId = "NHSO",
					Status = UserSmctStatus.Used,
					CreateUser = _repo.UserService.GetIdUserSmct(),
					EditUser = _repo.UserService.GetIdUserSmct(),
					CreateDate = DateTime.Now,
					EditDate = DateTime.Now,
					Used = true,
					IdRegisterNhso = "CE750861E85F2C92E05400144FF9ABD9"
				};
				await _db.InsterAsync(userSmctVendor);
				await _db.SaveAsync();

				_transaction.Commit();
			}
		}

		public async Task<DDOPALogin> DDOPAAuthen(DDOPALogin iuser)
		{
			var userDdopa = new UserDdopa
			{
				CreateUser = _repo.UserService.GetIdUserSmct(),
				EditUser = _repo.UserService.GetIdUserSmct(),
				CreateDate = DateTime.Now,
				EditDate = DateTime.Now,
				Used = true,
				Code = iuser.code ?? " ",
				State = iuser.state ?? " ",
				Error = iuser.error,
				ErrorDescription = iuser.error_description,
				ErrorUri = iuser.error_uri
			};
			await _db.InsterAsync(userDdopa);
			await _db.SaveAsync();

			return iuser;
		}

		public ResourceEmail CheckMailPassCode(CheckPassCode resource, string htmlBody, string email)
		{
			var builder = new BodyBuilder();

			builder.HtmlBody = htmlBody;

			return new ResourceEmail()
			{
				Builder = builder,
				Subject = $"CheckMailPassCode",
				Message = htmlBody,
				Email = email,
				Template = "CheckMailPassCode"
			};
		}

		public async Task<IEnumerable<UserRole>> UserRoles(string userRoleCode = null, String GroupRole = null)
		{
			var query = await _repo.Context.UserRoles.Where(x => x.Used).ToListAsync();
			if (!String.IsNullOrEmpty(userRoleCode))
				query = query.Where(x => x.UserRoleCode == userRoleCode).ToList();

			var UserRole = new List<UserRole>();
			if (!String.IsNullOrEmpty(GroupRole))
			{
				foreach (var item in query)
				{
					if ((GroupRole == "G1"))
					{
						Enum.TryParse(item.UserRoleCode, out PermissionRole enumRoleCode);
						if (GroupRoles.GroupRoleAdmin.Contains(enumRoleCode))
							UserRole.Add(item);
					}
					if ((GroupRole == "G2"))
					{
						Enum.TryParse(item.UserRoleCode, out PermissionRole enumRoleCode);
						if (GroupRoles.GroupRoleUnit.Contains(enumRoleCode))
							UserRole.Add(item);
					}
				}
			}

			return UserRole.OrderBy(x => x.UserRoleCode);
		}

		public async Task LogUser(string idUserSmct)
		{
			try
			{
				var remoteIpAddress = _httpConAcc.HttpContext.Connection.RemoteIpAddress.ToString();

				UserSmctLog userSmctLog = new UserSmctLog()
				{
					CreateDate = DateTime.Now,
					IdUserSmct = idUserSmct,
					IpAddress = remoteIpAddress
				};

				await _db.InsterAsync(userSmctLog);
				await _db.SaveAsync();
			}
			catch (Exception ex)
			{
			}
		}

		public int CountlogUser()
		{
			return _repo.Context.UserSmctLogs.Count(x => x.IdUserSmct != null);
		}

		public async Task ChangePassword(ChangePasswordMain indata)
		{
			if (string.IsNullOrEmpty(indata.CurrentPassword))
				throw new Exception("ระบุ รหัสผ่านปัจจุบัน");
			if (string.IsNullOrEmpty(indata.NewPassword))
				throw new Exception("ระบุ รหัสผ่านใหม่");
			if (string.IsNullOrEmpty(indata.NewPasswordConfirm))
				throw new Exception("ระบุ ยืนยันรหัสผ่านใหม่");
			if (indata.NewPassword != indata.NewPasswordConfirm)
				throw new Exception("ระบุ ยืนยันรหัสผ่านไม่ถูกต้อง");

			var userSmct = await _repo.Context.UserSmcts.Where(x => x.IdUserSmct == indata.IdUserSmct && x.Password == indata.CurrentPassword && x.Used).FirstOrDefaultAsync();
			if (userSmct == null) throw new Exception("ระบุ รหัสผ่านไม่ถูกต้อง");

			userSmct.Password = indata.NewPassword;
			_db.Update(userSmct);
			await _db.SaveAsync();
		}

	}
}
