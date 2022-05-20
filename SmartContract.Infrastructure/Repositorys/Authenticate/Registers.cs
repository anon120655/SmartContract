using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MimeKit;
using SmartContract.Infrastructure.Data.EntityFramework;
using SmartContract.Infrastructure.Data.EntityFrameworkEbudget;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Interfaces;
using SmartContract.Infrastructure.Interfaces.Authenticate;
using SmartContract.Infrastructure.Resources.Authenticate;
using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Enum;
using SmartContract.Infrastructure.Resources.Registers;
using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Infrastructure.Wrapper;
using SmartContract.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Repositorys.Authenticate
{
	public class Registers : IRegisters
	{
		private IRepositoryWrapper _repo;
		private readonly IRepositoryBase _db;
		private readonly IWebHostEnvironment _env;
		private readonly AppSettings _mySet;
		private readonly IMapper _mapper;
		private bool IsRoleAdmin = false;

		public Registers(IRepositoryWrapper repo, IRepositoryBase db, IWebHostEnvironment env, IMapper mapper, IOptions<AppSettings> settings)
		{
			_db = db;
			_env = env;
			_repo = repo;
			_mapper = mapper;
			_mySet = settings.Value;
			IsRoleAdmin = GroupRoles.GroupRoleAdmin.Contains(_repo.UserService.GetRoleRoleCode());
		}

		public void ValidateUserCheck(RegisterMaster indata)
		{
			if (string.IsNullOrEmpty(indata.UserSmct.FirstName))
				throw new Exception("ระบุชื่อ");
			if (string.IsNullOrEmpty(indata.UserSmct.LastName))
				throw new Exception("ระบุชื่อนามสกุล");
			if (string.IsNullOrEmpty(indata.UserSmct.Cid))
				throw new Exception("ระบุรหัสบัตรประชาชน");
			if (string.IsNullOrEmpty(indata.UserSmct.Laser))
				throw new Exception("ระบุรหัสหลังบัตรประชาชน");
			if (indata.UserSmct.Laser.Length != 12)
				throw new Exception("ระบุรหัสหลังบัตรประชาชน 12 หลัก");
			if (string.IsNullOrEmpty(indata.UserSmct.BirthdayStr))
				throw new Exception("ระบุเกิดวันที่");
			if (string.IsNullOrEmpty(indata.UserSmct.Email))
				throw new Exception("ระบุ E-Mail");
		}

		public async Task<RegisterMaster> InitialData(RegisterMaster indata)
		{
			//var serviceUnits = await _repo.MasterData.ServiceUnits();
			//var masterVendor = await _repo.MasterData.MasterVendor();
			var nhsoZones = await _repo.MasterData.NhsoZones();
			var lkProvinces = await _repo.MasterData.LKProvinces();
			var userRoles = await _repo.UserService.UserRoles(GroupRole: "G2");

			var VNhsoZoneList = new List<VNhsoZone>();
			var nhsoZonesGroup = nhsoZones.ToLookup(x => x.NhsoZone);
			foreach (var item in nhsoZonesGroup)
			{
				VNhsoZoneList.Add(new VNhsoZone()
				{
					NhsoZone = item.Key,
					NhsoZonename = item.FirstOrDefault().NhsoZonename,
					ProvinceId = item.FirstOrDefault().ProvinceId,
					ProvinceName = item.FirstOrDefault().ProvinceName,
					Region = item.FirstOrDefault().Region,
					RegionName = item.FirstOrDefault().RegionName,
				});
			}

			indata.GetLookUp = new LookUpResource()
			{
				SubDomainServer = _mySet.SubDomainServer,
				NhsoZones = VNhsoZoneList,
				LKProvinces = lkProvinces,
				UserRoles = userRoles,
				UserSmctSigner = await _repo.MasterData.UserSmctSigner(),
				ProvincesUnderNHSOList = await _repo.MasterData.ProvincesUnderNHSO()
			};

			return indata;
		}

		public void Validate(RegisterMaster indata)
		{
			var indata_regis = indata.RegisterNhso;
			if (indata.Approvetype == "S" || indata.Approvetype == null)
			{
				if (indata_regis.RegisterType == "P11")
				{
					if (string.IsNullOrEmpty(indata_regis.Hcode) || indata_regis.Hcode == "00000")
						throw new Exception("ระบุหน่วยบริการ");
				}

				if (string.IsNullOrEmpty(indata.VendorId))
					throw new Exception("ระบุรหัสคู่สัญญา <br />กรณีไม่มีให้เลือก (--ไม่มี--)");
				if (indata.VendorId == "99999")
				{
					if (String.IsNullOrEmpty(indata.GPType))
						throw new Exception("ระบุ รัฐ/เอกชน");

					if (string.IsNullOrEmpty(indata_regis.CompanyName))
						throw new Exception("ระบุชื่อบุคคล/นิติบุคคล เจ้าของสถานบริการ");
					if (string.IsNullOrEmpty(indata.ProvinceId))
						throw new Exception("ระบุจังหวัดที่ตั้ง");
					if (string.IsNullOrEmpty(indata.ProvinceIdCatm))
						throw new Exception("ระบุจังหวัด");
					if (string.IsNullOrEmpty(indata.AmphurId))
						throw new Exception("ระบุอำเภอ");
					if (string.IsNullOrEmpty(indata.DistrictId))
						throw new Exception("ระบุตำบล/แขวง");
					if (string.IsNullOrEmpty(indata_regis.TaxId))
						throw new Exception("ระเลขฯผู้เสียภาษี");
					if (string.IsNullOrEmpty(indata_regis.PostCode))
						throw new Exception("ระบุรหัสไปรษณีย์");
					if (string.IsNullOrEmpty(indata_regis.Sp7))
						throw new Exception("ระบุตามใบอนุญาตฯเลขที่ (ส.พ.7)");
					if (string.IsNullOrEmpty(indata.Sp7DateStr))
						throw new Exception("ระบุลงวันที่");
				}
			}

			if (!IsRoleAdmin)
			{
				if (indata.Approvetype == "U" || indata.Approvetype == null)
				{
					if (indata.UserSmct != null)
					{
						if (indata.UserSmct.UserRights.IdUserRole == "00000")
							throw new Exception("ระบุ ประเภทผู้เข้าใช้งาน");
						if (string.IsNullOrEmpty(indata.UserSmct.UserFullname))
							throw new Exception("ระบุชื่อเต็ม");
						if (string.IsNullOrEmpty(indata.UserSmct.Cid))
							throw new Exception("ระบุรหัสบัตรประชาชน");
						if (string.IsNullOrEmpty(indata.UserSmct.Email))
							throw new Exception("ระบุ E-Mail");

						if (indata.ObjectState == TObjectState.Create)
						{
							if (_repo.Context.UserSmcts.Any(x => x.Email == indata.UserSmct.Email && x.Used))
							{
								throw new Exception($"E-Mail {indata.UserSmct.Email} ถูกสร้างแล้ว");
							}
						}

						if (indata.UserSmct.UserRights.IdUserRole != null)
						{
							//06 =95BF9F39536E40AAAAA967B1B402DD85
							//07 =50CFFEF3D4BB4529B3134E923B1B4B9E
							if (indata.UserSmct.UserRights.IdUserRole == "95BF9F39536E40AAAAA967B1B402DD85"
								| indata.UserSmct.UserRights.IdUserRole == "50CFFEF3D4BB4529B3134E923B1B4B9E")
							{
								if (indata.UserSmct.UserSmctSigners != null)
								{
									var smctSigners = indata.UserSmct.UserSmctSigners;
									if (smctSigners.SignerType == "S1")
									{
										if (string.IsNullOrEmpty(smctSigners.Signer1DocName))
											throw new Exception("ระบุตามหนังสือ");
										if (string.IsNullOrEmpty(smctSigners.Signer1DocNo))
											throw new Exception("ระบุเลขที่หนังสือ");
										if (string.IsNullOrEmpty(smctSigners.Signer1DocDateStr))
											throw new Exception("ระบุลงวันที่(เลขที่หนังสือ)");
									}
									else if (smctSigners.SignerType == "S2")
									{
										if (string.IsNullOrEmpty(smctSigners.Signer2PoaDocNo))
											throw new Exception("ระบุหนังสือมอบอำนาจเลขที่");
										if (string.IsNullOrEmpty(smctSigners.Signer2PoaDocDateStr))
											throw new Exception("ระบุลงวันที่(หนังสือมอบอำนาจ)");
										if (string.IsNullOrEmpty(smctSigners.Signer2PoaSigner1User) || smctSigners.Signer2PoaSigner1User == "00000")
											throw new Exception("ระบุจากผู้มีอำนาจ");
									}
								}

								if (indata.UserSmct.UserSmctSigners.UserSmctSignerFiles == null || indata.UserSmct.UserSmctSigners.UserSmctSignerFiles.Count == 0)
								{
									throw new Exception("ระบุ รายละเอียดไฟล์แนบ ผู้มีอำนาจลงนาม");
								}
								else
								{
									foreach (var item in indata.UserSmct.UserSmctSigners.UserSmctSignerFiles)
									{
										if (item.FormFile == null)
										{
											throw new Exception("ระบุ รายละเอียดไฟล์แนบ ผู้มีอำนาจลงนาม");
										}
									}
								}

							}

						}
					}
				}

			}


		}

		public async Task<RegisterMaster> GetView(string IdUserSmct = null, string email = null, String IdRegisterNhso = null)
		{
			if (String.IsNullOrEmpty(IdUserSmct) && String.IsNullOrEmpty(email) && String.IsNullOrEmpty(IdRegisterNhso))
			{
				throw new Exception("Parameter not found.");
			}

			UserSmct userSmcts = null;
			UserSmctDTO userSmctUse = null;
			UserSmctVendor userSmctVendors = null;
			RegisterNhso registerNhsos = null;

			if (!String.IsNullOrEmpty(IdUserSmct))
				userSmcts = _repo.Context.UserSmcts.FirstOrDefault(x => x.Used && x.IdUserSmct == IdUserSmct);

			if (!String.IsNullOrEmpty(email))
				userSmcts = _repo.Context.UserSmcts.FirstOrDefault(x => x.Used && x.Email == email);

			if (userSmcts != null)
			{
				userSmctUse = _mapper.Map<UserSmctDTO>(userSmcts);
				if (userSmctUse == null)
					throw new Exception("ไม่พบผู้ใช้งาน");

				var userRights = await _repo.Context.UserRights.FirstOrDefaultAsync(x => x.IdUserSmct == userSmctUse.IdUserSmct && x.Used);
				var userRoles = await _repo.Context.UserRoles.FirstOrDefaultAsync(x => x.IdUserRole == userRights.IdUserRole && x.Used);
				var userSmctSigners = await _repo.Context.UserSmctSigners.Include(x => x.UserSmctSignerFiles).Where(x => x.IdUserSmct == userSmctUse.IdUserSmct).FirstOrDefaultAsync();

				userSmctUse.UserRights = _mapper.Map<UserRightDTO>(userRights);
				userSmctUse.UserRoles = _mapper.Map<UserRoleDTO>(userRoles);
				userSmctUse.UserSmctSigners = _mapper.Map<UserSmctSignerDTO>(userSmctSigners);

				userSmctVendors = await _repo.Context.UserSmctVendors.FirstOrDefaultAsync(x => x.IdUserSmct == userSmctUse.IdUserSmct && x.Used);

				registerNhsos = await _repo.Context.RegisterNhsos.Include(x => x.RegisterNhsoFiles)
																	.FirstOrDefaultAsync(x => x.IdRegisterNhso == userSmctVendors.IdRegisterNhso && x.Used);

				if (GeneralUtils.CheckHashDate(userSmctUse.Birthday))
					userSmctUse.BirthdayStr = GeneralUtils.DateToThString(userSmctUse.Birthday);

				if (userSmctUse.UserSmctSigners != null)
				{
					if (GeneralUtils.CheckHashDate(userSmctUse.UserSmctSigners.Signer1DocDate))
						userSmctUse.UserSmctSigners.Signer1DocDateStr = GeneralUtils.DateToThString(userSmctUse.UserSmctSigners.Signer1DocDate);

					if (GeneralUtils.CheckHashDate(userSmctUse.UserSmctSigners.Signer2PoaDocDate))
						userSmctUse.UserSmctSigners.Signer2PoaDocDateStr = GeneralUtils.DateToThString(userSmctUse.UserSmctSigners.Signer2PoaDocDate);
					if (GeneralUtils.CheckHashDate(userSmctUse.UserSmctSigners.Signer2DocDate))
						userSmctUse.UserSmctSigners.Signer2DocDateStr = GeneralUtils.DateToThString(userSmctUse.UserSmctSigners.Signer2DocDate);
					if (GeneralUtils.CheckHashDate(userSmctUse.UserSmctSigners.Signer2StartDate))
						userSmctUse.UserSmctSigners.Signer2StartDateStr = GeneralUtils.DateToThString(userSmctUse.UserSmctSigners.Signer2StartDate);
					if (GeneralUtils.CheckHashDate(userSmctUse.UserSmctSigners.Signer2EndDate))
						userSmctUse.UserSmctSigners.Signer2EndDateStr = GeneralUtils.DateToThString(userSmctUse.UserSmctSigners.Signer2EndDate);
				}
			}

			if (!String.IsNullOrEmpty(IdRegisterNhso))
			{
				registerNhsos = await _repo.Context.RegisterNhsos.Include(x => x.RegisterNhsoFiles).FirstOrDefaultAsync(x => x.IdRegisterNhso == IdRegisterNhso && x.Used);
			}

			RegisterMaster response = new RegisterMaster()
			{
				UserSmct = userSmctUse,
				RegisterNhso = registerNhsos,
				CATMs = _repo.GeneralRepo.GetCATM(registerNhsos.Catm),
				UsersUnderServiceUnit = this.GetListRegCheckUser(new SearchOptionRegCheck() { Type = "P", VendorId = registerNhsos.VendorId }).ToList()
			};

			//string sp7DateStr = String.Empty;
			if (GeneralUtils.CheckHashDate(registerNhsos.Sp7Date))
				response.Sp7DateStr = GeneralUtils.DateToThString(registerNhsos.Sp7Date);

			response.VendorId = registerNhsos.VendorId;
			response.ProvinceId = registerNhsos.ProvinceId;
			if (response.CATMs != null)
			{
				response.ProvinceIdCatm = response.CATMs.ProvinceId;
				response.AmphurId = response.CATMs.AmphurId;
				response.DistrictId = response.CATMs.DistrictId;
			}
			response.FileList = _mapper.Map<IList<RegisterNhsoFileDTO>>(registerNhsos.RegisterNhsoFiles);
			response.ProvinceNameLocation = _repo.Context.LkProvinces.FirstOrDefault(x => x.ProvinceId == registerNhsos.ProvinceId)?.ProvinceName ?? String.Empty;

			return response;
		}

		public async Task<RegisterMaster> CreateAsync(RegisterMaster indata)
		{
			//var EcContractVendorReqs2 = await _repo.ContextEb.EcContractVendorReqs.ToListAsync();

			//var ecContractVendorReq = new EcContractVendorReq();
			//ecContractVendorReq.No = 3279646;
			//ecContractVendorReq.ContractNo = 3279611;
			//ecContractVendorReq.Id = "VL65/00006";
			//ecContractVendorReq.Status = "S1";
			//ecContractVendorReq.CreatedUser = 1;
			//ecContractVendorReq.CreatedDate = DateTime.Now;
			//ecContractVendorReq.EditedUser = 1;
			//ecContractVendorReq.EditedDate = DateTime.Now;
			//ecContractVendorReq.Used = "Y";

			////await _db.InsterAsync(ecContractVendorReq);
			////await _db.SaveAsync();
			//await _db.InsterEbAsync(ecContractVendorReq);
			//         await _db.SaveEbAsync();

			using (var _transaction = _repo.BeginTransaction())
			{
				var indata_regis = indata.RegisterNhso;
				IEnumerable<VMasterVendorDTO> masterVendor = null;
				VMasterVendorDTO masterVendorUse = null;
				if (indata_regis.Hcode != null)
				{
					masterVendor = await _repo.MasterData.MasterVendor(hcode: indata_regis.Hcode);
					masterVendorUse = masterVendor.FirstOrDefault();
				}

				//String vendorId = masterVendorUse?.VendorId ?? null;
				//String vendorName = masterVendorUse?.VendorName ?? null;
				String _Status = UserSmctStatus.WaitUse;
				if (IsRoleAdmin)
				{
					_Status = UserSmctStatus.Used;
				}

				String _VendorId = String.Empty;
				String _VendorName = String.Empty;
				String _RegisterAt = String.Empty;
				String _CompanyName = String.Empty;
				String _ProvinceId = String.Empty;
				String _Catm = String.Empty;
				String _VillageNo = String.Empty;
				String _Building = String.Empty;
				String _TaxId = String.Empty;
				String _Soi = String.Empty;
				String _Road = String.Empty;
				String _PostCode = String.Empty;
				String _Phone = String.Empty;
				String _Fax = String.Empty;
				String _Email = String.Empty;
				String _Sp7 = String.Empty;
				DateTime? _Sp7Date = null;
				String _Moo = String.Empty;

				//มีรหัสคู่สัญญาแล้ว นำข้อมูลจาก mastervendor ไปใส่ใน registernhso
				if (indata.CheckRegister)
				{
					_Status = UserSmctStatus.Used;
					var vMasterVendors = _repo.Context.VMasterVendors.FirstOrDefault(x => x.VendorId == indata.VendorId);
					_VendorId = vMasterVendors.VendorId;
					_VendorName = vMasterVendors.VendorName;
					_RegisterAt = vMasterVendors.RegisterAt;
					_CompanyName = vMasterVendors.CompanyName;
					_ProvinceId = vMasterVendors.ProvinceId;
					_Catm = vMasterVendors.Catm;
					_VillageNo = vMasterVendors.VillageNo;
					_Building = vMasterVendors.Building;
					_TaxId = vMasterVendors.TaxId;
					_Soi = vMasterVendors.Soi;
					_Road = vMasterVendors.Road;
					_PostCode = vMasterVendors.PostCode;
					_Phone = vMasterVendors.Phone;
					_Fax = vMasterVendors.Fax;
					_Email = vMasterVendors.Email;
					_Sp7 = vMasterVendors.Sp7;
					_Sp7Date = vMasterVendors.Sp7Date;
					_Moo = vMasterVendors.Moo;
				}
				else
				{
					//เลือกไม่มีรหัสคู่สัญญา ใช้ข้อมูลจาก form 
					int moo = 0;
					int.TryParse(indata_regis.Moo, out moo);

					_VendorId = indata.VendorId;
					_VendorName = indata_regis.VendorName;
					_RegisterAt = indata_regis.RegisterAt;
					_CompanyName = indata_regis.CompanyName;
					_ProvinceId = indata.ProvinceId;
					_Catm = $"{indata.ProvinceIdCatm}{indata.AmphurId}{indata.DistrictId}{moo.ToString("00")}";
					_VillageNo = indata_regis.VillageNo;
					_Building = indata_regis.Building;
					_TaxId = indata_regis.TaxId;
					_Soi = indata_regis.Soi;
					_Road = indata_regis.Road;
					_PostCode = indata_regis.PostCode;
					_Phone = indata_regis.Phone;
					_Fax = indata_regis.Fax;
					_Email = indata_regis.Email;
					_Sp7 = indata_regis.Sp7;
					_Sp7Date = GeneralUtils.DateToEn(indata.Sp7DateStr);
					_Moo = indata_regis.Moo;
				}

				var departmentCode = this.GetDepartmentCodeZone(_ProvinceId);

				var registerNhso = new RegisterNhso();
				if (indata_regis.RegisterType == "P11")//ลงทะเบียนผ่านระบบสมัคร
				{
					registerNhso = _repo.Context.RegisterNhsos.FirstOrDefault(x => x.Hcode != null && x.Hcode == indata_regis.Hcode && x.Used);
				}
				else //ไม่ได้ลงทะเบียนผ่านระบบสมัคร
				{
					registerNhso = _repo.Context.RegisterNhsos.FirstOrDefault(x => x.VendorId == _VendorId && x.Used);
				}
				//ยังไม่เคยลงทะเบียนของ smct ต้อง insert ใหม่
				if (registerNhso == null)
				{
					//หน่วยบริการ(สังกัด)
					indata_regis.Hcode = indata_regis.Hcode;
					indata_regis.RegisterType = this.GetRegisterType(indata, masterVendorUse);
					indata_regis.DepartmentCode = departmentCode;
					indata_regis.RegisterNo = await RegisterRunning();
					indata_regis.VendorId = _VendorId;
					indata_regis.VendorName = _VendorName;
					indata_regis.RegisterAt = _RegisterAt;
					indata_regis.CompanyName = _CompanyName;
					indata_regis.ProvinceId = _ProvinceId;
					indata_regis.Catm = _Catm;
					indata_regis.VillageNo = _VillageNo;
					indata_regis.Building = _Building;
					indata_regis.TaxId = _TaxId;
					indata_regis.Soi = _Soi;
					indata_regis.Road = _Road;
					indata_regis.PostCode = _PostCode;
					indata_regis.Phone = _Phone;
					indata_regis.Fax = _Fax;
					indata_regis.Email = _Email;
					indata_regis.Sp7 = _Sp7;
					indata_regis.Sp7Date = _Sp7Date;
					indata_regis.Moo = _Moo;
					indata_regis.Status = _Status;
					indata_regis.CreateUser = _repo.UserService.GetIdUserSmct();
					indata_regis.EditUser = _repo.UserService.GetIdUserSmct();
					indata_regis.CreateDate = DateTime.Now;
					indata_regis.EditDate = DateTime.Now;
					indata_regis.Used = true;

					await _db.InsterAsync(indata_regis);
					await _db.SaveAsync();
				}
				else
				{
					indata_regis = registerNhso;
				}

				if (indata.FileList != null && indata.FileList.Count > 0)
				{
					int index_file = 0;
					foreach (var item in indata.FileList)
					{
						if (item.FormFile != null)
						{
							index_file++;
							var fileFTP = _repo.UploadFiles.GenFileName(item.FormFile, Guid.NewGuid().ToString(), $"FILE_Register");
							String thaiYear = GeneralUtils.getThaiYear(DateTime.Now.Year);

							var registerNhsoFile = new RegisterNhsoFile
							{
								IdRegisterNhso = indata_regis.IdRegisterNhso,
								RegisterFileType = "F1",
								RegisterFileName = item.FormFile != null ? item.FormFile.FileName : String.Empty,
								RegisterFileFtp = fileFTP,
								CreateUser = _repo.UserService.GetIdUserSmct(),
								EditUser = _repo.UserService.GetIdUserSmct(),
								CreateDate = DateTime.Now,
								EditDate = DateTime.Now,
								RegisterFileNo = index_file,
								Used = true,
								PathFolder = thaiYear
							};
							await _db.InsterAsync(registerNhsoFile);
							await _db.SaveAsync();

							String PathFolder = $"Register\\Vendor\\{thaiYear}";
							this.HandleUploadfile(item.FormFile, fileFTP, PathFolder);
						}
					}
				}

				if (!IsRoleAdmin)
				{
					//ผู้ขอลงทะเบียน
					if (indata.UserSmct != null)
					{
						var userSmct = new UserSmct
						{
							IdUserLevel = "096D1A88CF414EC59EC9C48ED5BAEF10",
							DepartmentCode = departmentCode,
							Username = indata.UserSmct.Email,
							Password = " ",
							UserFullname = indata.UserSmct.UserFullname,
							PositionName = indata.UserSmct.PositionName,
							Email = indata.UserSmct.Email,
							Cid = indata.UserSmct.Cid,
							UserType = UserSmctType.TwoFactor,
							Status = _Status,
							CreateUser = _repo.UserService.GetIdUserSmct(),
							EditUser = _repo.UserService.GetIdUserSmct(),
							CreateDate = DateTime.Now,
							EditDate = DateTime.Now,
							Used = true,
							Birthday = GeneralUtils.DateToEn(indata.UserSmct.BirthdayStr)
						};
						await _db.InsterAsync(userSmct);
						await _db.SaveAsync();

						var userRight = new UserRight
						{
							IdUserSmct = userSmct.IdUserSmct,
							IdUserRole = indata.UserSmct.UserRights.IdUserRole,
							Status = _Status,
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
							Hcode = indata_regis.Hcode,
							VendorId = _VendorId,
							Status = _Status,
							CreateUser = _repo.UserService.GetIdUserSmct(),
							EditUser = _repo.UserService.GetIdUserSmct(),
							CreateDate = DateTime.Now,
							EditDate = DateTime.Now,
							Used = true,
							IdRegisterNhso = indata_regis.IdRegisterNhso
						};
						await _db.InsterAsync(userSmctVendor);
						await _db.SaveAsync();


						//ผู้มีอำนาจ,ผู้รับมอบอำนาจ
						//UserRoleCode 06,07
						if (userRight.IdUserRole == "95BF9F39536E40AAAAA967B1B402DD85" || userRight.IdUserRole == "50CFFEF3D4BB4529B3134E923B1B4B9E")
						{
							if (indata.UserSmct.UserSmctSigners != null)
							{
								var smctSigner = indata.UserSmct.UserSmctSigners;

								String Signer1Name = String.Empty;
								var userSmcts = _repo.Context.UserSmcts.Where(x => x.Used);

								String _Signer1User = String.Empty;
								String _Signer1UserFullName = String.Empty;
								//ผู้มีอำนาจด้วยตนเอง
								if (userRight.IdUserRole == "95BF9F39536E40AAAAA967B1B402DD85")
								{
									_Signer1User = userSmct.IdUserSmct;
									_Signer1UserFullName = userSmct.UserFullname;
								}

								var userSmctSigner = new UserSmctSigner
								{
									IdUserSmct = userSmct.IdUserSmct,
									SignerType = smctSigner.SignerType,
									Signer1User = _Signer1User,
									Signer1Name = _Signer1UserFullName,
									Signer1DocName = smctSigner.Signer1DocName,
									Signer1DocNo = smctSigner.Signer1DocNo,
									Signer1DocDate = GeneralUtils.DateToEn(smctSigner.Signer1DocDateStr),
									Signer2PoaDocNo = smctSigner.Signer2PoaDocNo,
									Signer2PoaDocDate = GeneralUtils.DateToEn(smctSigner.Signer2PoaDocDateStr),
									Signer2PoaSigner1User = smctSigner.Signer2PoaSigner1User,
									Signer2PoaSigner1Name = userSmcts.FirstOrDefault(x => x.IdUserSmct == smctSigner.Signer2PoaSigner1User)?.UserFullname ?? String.Empty,
									Signer2DocName = smctSigner.Signer2DocName,
									Signer2DocNo = smctSigner.Signer2DocNo,
									Signer2DocDate = GeneralUtils.DateToEn(smctSigner.Signer2DocDateStr),
									Signer2StartDate = GeneralUtils.DateToEn(smctSigner.Signer2StartDateStr),
									Signer2EndDate = GeneralUtils.DateToEn(smctSigner.Signer2EndDateStr),
									Status = _Status,
									CreateUser = _repo.UserService.GetIdUserSmct(),
									EditUser = _repo.UserService.GetIdUserSmct(),
									CreateDate = DateTime.Now,
									EditDate = DateTime.Now,
									Used = true
								};
								await _db.InsterAsync(userSmctSigner);
								await _db.SaveAsync();

								if (smctSigner.UserSmctSignerFiles != null && smctSigner.UserSmctSignerFiles.Count > 0)
								{
									int index_file = 0;
									foreach (var item in smctSigner.UserSmctSignerFiles)
									{
										if (item.FormFile != null)
										{
											index_file++;
											var fileFTP = _repo.UploadFiles.GenFileName(item.FormFile, Guid.NewGuid().ToString(), $"FILE_Signer");
											String thaiYear = GeneralUtils.getThaiYear(DateTime.Now.Year);

											var userSmctSignerFile = new UserSmctSignerFile
											{
												IdUserSmctSigner = userSmctSigner.IdUserSmctSigner,
												SignerFileType = "F1",
												SignerFileName = item.FormFile != null ? item.FormFile.FileName : String.Empty,
												SignerFileFtp = fileFTP,
												CreateUser = _repo.UserService.GetIdUserSmct(),
												EditUser = _repo.UserService.GetIdUserSmct(),
												CreateDate = DateTime.Now,
												EditDate = DateTime.Now,
												SignerFileNo = index_file,
												Used = true,
												PathFolder = thaiYear
											};
											await _db.InsterAsync(userSmctSignerFile);
											await _db.SaveAsync();

											String PathFolder = $"Register\\Signer\\{thaiYear}";
											this.HandleUploadfile(item.FormFile, fileFTP, PathFolder);
										}
									}
								}
							}
						}

					}
				}

				//insert ebudget
				try
				{
					//ไม่มีรหัสคู่สัญญา
					if (!indata.CheckRegister)
					{
						//ย้ายไปเพิ่มตอนสร้างนิติกรรมแบบไม่มี veddorlink แทน

						//var vendorLinkReqApprove = new VendorLinkReqApprove();
						//vendorLinkReqApprove.CreateUser = _repo.UserService.GetIdUserSmct();
						//vendorLinkReqApprove.CreateDate = DateTime.Now;
						//vendorLinkReqApprove.EditUser = _repo.UserService.GetIdUserSmct();
						//vendorLinkReqApprove.EditDate = DateTime.Now;
						//vendorLinkReqApprove.Status = "Y";
						//vendorLinkReqApprove.IdSmctMaster = "";
						//vendorLinkReqApprove.IdVendorLinkReq = "";
						//vendorLinkReqApprove.VendorType = "";
						//vendorLinkReqApprove.VendorId = _VendorId;
						//vendorLinkReqApprove.VendorName = _VendorName;
						//vendorLinkReqApprove.CompanyName = _CompanyName;
						//vendorLinkReqApprove.ProvinceId = _ProvinceId;
						//vendorLinkReqApprove.Catm = _Catm;
						//vendorLinkReqApprove.Moo = _Moo;
						//vendorLinkReqApprove.HouseNumber = _VillageNo;
						//vendorLinkReqApprove.Building = _Building;
						//vendorLinkReqApprove.PostCode = _PostCode;
						//vendorLinkReqApprove.Road = _Road;
						//vendorLinkReqApprove.Soi = _Soi;
						//vendorLinkReqApprove.Phone = _Phone;
						//vendorLinkReqApprove.Mobile = _Phone;
						//vendorLinkReqApprove.Fax = _Fax;
						//vendorLinkReqApprove.Email = _Email;
						//vendorLinkReqApprove.ContractorName = "";
						//vendorLinkReqApprove.AccName = "";
						//vendorLinkReqApprove.AccNo = "";
						//vendorLinkReqApprove.BankId = "";
						//vendorLinkReqApprove.BranchName = "";
						//vendorLinkReqApprove.BranchId = "";
						//vendorLinkReqApprove.CardType = "";
						//vendorLinkReqApprove.CardId = "";
						//vendorLinkReqApprove.SearchTerm = "";
						//vendorLinkReqApprove.CostCenter = "";
						//vendorLinkReqApprove.TaxId = _TaxId;
						//vendorLinkReqApprove.ApproveDate = null;
						//vendorLinkReqApprove.ApproveUser = null;
						//vendorLinkReqApprove.Enaccname = "";
						//vendorLinkReqApprove.Enaccadr1 = "";
						//vendorLinkReqApprove.Enaccadr2 = "";
						//vendorLinkReqApprove.Enaccadr3 = "";
						//vendorLinkReqApprove.BankBrnInd = "";
						//await _db.InsterAsync(vendorLinkReqApprove);
						//await _db.SaveAsync();

					}
				}
				catch (Exception ex)
				{

					throw;
				}

				await _transaction.CommitAsync();

				indata.RegisterNhso = indata_regis;
				return indata;
			}
		}

		public async Task<RegisterMaster> UpdateAsync(RegisterMaster indata)
		{
			using (var _transaction = _repo.BeginTransaction())
			{
				var indata_regis = indata.RegisterNhso;
				IEnumerable<VMasterVendorDTO> masterVendor = null;
				VMasterVendorDTO masterVendorUse = null;
				if (indata_regis.Hcode != null)
				{
					masterVendor = await _repo.MasterData.MasterVendor(hcode: indata_regis.Hcode);
					masterVendorUse = masterVendor.FirstOrDefault();
				}

				String vendorId = masterVendorUse?.VendorId ?? null;
				String vendorName = masterVendorUse?.VendorName ?? null;
				String _Status = UserSmctStatus.WaitUse;
				if (IsRoleAdmin)
				{
					_Status = UserSmctStatus.Used;
				}

				int moo = 0;
				int.TryParse(indata_regis.Moo, out moo);

				var registerNhso = _repo.Context.RegisterNhsos.FirstOrDefault(x => x.IdRegisterNhso == indata_regis.IdRegisterNhso && x.Used);
				if (indata.Approvetype != "U")
				{
					String _Catm = $"{indata.ProvinceIdCatm}{indata.AmphurId}{indata.DistrictId}{moo.ToString("00")}";
					registerNhso.VendorId = vendorId;
					registerNhso.VendorName = indata_regis.VendorName;
					registerNhso.RegisterAt = indata_regis.RegisterAt;
					registerNhso.CompanyName = indata_regis.CompanyName;
					registerNhso.ProvinceId = indata.ProvinceId;
					registerNhso.Catm = _Catm;
					registerNhso.VillageNo = indata_regis.VillageNo;
					registerNhso.Building = indata_regis.Building;
					registerNhso.TaxId = indata_regis.TaxId;
					registerNhso.Soi = indata_regis.Soi;
					registerNhso.Road = indata_regis.Road;
					registerNhso.PostCode = indata_regis.PostCode;
					registerNhso.Phone = indata_regis.Phone;
					registerNhso.Fax = indata_regis.Fax;
					registerNhso.Sp7 = indata_regis.Sp7;
					registerNhso.Sp7Date = GeneralUtils.DateToEn(indata.Sp7DateStr).Value;
					registerNhso.Moo = indata_regis.Moo;
					registerNhso.Status = _Status;
					registerNhso.EditUser = _repo.UserService.GetIdUserSmct();
					registerNhso.EditDate = DateTime.Now;

					_db.Update(registerNhso);
					await _db.SaveAsync();

					//fileList หน่วยบริการ ที่ลบ
					var registerNhsoFilesRemove = _repo.Context.RegisterNhsoFiles.Where(x => x.IdRegisterNhso == indata_regis.IdRegisterNhso).ToList();
					if (indata.FileList != null && indata.FileList.Count > 0)
					{
						registerNhsoFilesRemove = registerNhsoFilesRemove.Where(x => !indata.FileList.Select(r => r.IdRegisterNhsoFile).Contains(x.IdRegisterNhsoFile)).ToList();
					}
					if (registerNhsoFilesRemove.Count > 0)
					{
						_db.DeleteRange(registerNhsoFilesRemove);
						await _repo.SaveAsync();
					}
					if (indata.FileList != null && indata.FileList.Count > 0)
					{
						int index_file = 1;
						foreach (var item in indata.FileList)
						{
							var fileFTP = _repo.UploadFiles.GenFileName(item.FormFile, Guid.NewGuid().ToString(), $"FILE_Register");
							String thaiYear = GeneralUtils.getThaiYear(DateTime.Now.Year);

							var registerNhsoFile = await _repo.Context.RegisterNhsoFiles.FirstOrDefaultAsync(x => x.IdRegisterNhso == indata_regis.IdRegisterNhso
																								   && x.IdRegisterNhsoFile == item.IdRegisterNhsoFile);
							if (registerNhsoFile != null)
							{
								registerNhsoFile.RegisterFileNo = index_file++;
								registerNhsoFile.EditUser = _repo.UserService.GetIdUserSmct();
								registerNhsoFile.EditDate = DateTime.Now;
								registerNhsoFile.PathFolder = thaiYear;
								_db.Update(registerNhsoFile);
								await _db.SaveAsync();
							}
							else
							{
								registerNhsoFile = new RegisterNhsoFile
								{
									IdRegisterNhso = indata_regis.IdRegisterNhso,
									RegisterFileType = "F1",
									RegisterFileName = item.FormFile != null ? item.FormFile.FileName : String.Empty,
									RegisterFileFtp = fileFTP,
									CreateUser = _repo.UserService.GetIdUserSmct(),
									EditUser = _repo.UserService.GetIdUserSmct(),
									CreateDate = DateTime.Now,
									EditDate = DateTime.Now,
									RegisterFileNo = index_file++,
									Used = true,
									PathFolder = thaiYear
								};
								await _db.InsterAsync(registerNhsoFile);
								await _db.SaveAsync();
							}

							if (item.FormFile != null)
							{
								String PathFolder = $"Register\\Vendor\\{thaiYear}";
								this.HandleUploadfile(item.FormFile, fileFTP, PathFolder);
							}
						}
					}
				}

				if (!IsRoleAdmin)
				{
					if (indata.Approvetype != "S")
					{
						//ผู้ขอลงทะเบียน
						if (indata.UserSmct != null)
						{
							var userSmct = await _repo.Context.UserSmcts.FirstOrDefaultAsync(x => x.IdUserSmct == indata.UserSmct.IdUserSmct);
							userSmct.UserFullname = indata.UserSmct.UserFullname;
							userSmct.PositionName = indata.UserSmct.PositionName;
							userSmct.Cid = indata.UserSmct.Cid;
							userSmct.Status = _Status;
							userSmct.EditUser = _repo.UserService.GetIdUserSmct();
							userSmct.EditDate = DateTime.Now;
							userSmct.Birthday = GeneralUtils.DateToEn(indata.UserSmct.BirthdayStr);
							_db.Update(userSmct);
							await _db.SaveAsync();

							var userRight = await _repo.Context.UserRights.FirstOrDefaultAsync(x => x.IdUserSmct == indata.UserSmct.IdUserSmct);
							userRight.IdUserRole = indata.UserSmct.UserRights.IdUserRole;
							userRight.Status = _Status;
							userRight.EditUser = _repo.UserService.GetIdUserSmct();
							userRight.EditDate = DateTime.Now;
							_db.Update(userRight);
							await _db.SaveAsync();

							var userSmctVendor = await _repo.Context.UserSmctVendors.FirstOrDefaultAsync(x => x.IdUserSmct == indata.UserSmct.IdUserSmct);
							userSmctVendor.Status = _Status;
							userSmctVendor.EditUser = _repo.UserService.GetIdUserSmct();
							userSmctVendor.EditDate = DateTime.Now;
							_db.Update(userSmctVendor);
							await _db.SaveAsync();


							//ผู้มีอำนาจ,ผู้รับมอบอำนาจ
							//กรณีเปลี่ยนจากผู้ใช้งานที่ไม่ใช่ ผู้มีอำนาจ,ผู้รับมอบอำนาจ
							if (userRight.IdUserRole != "95BF9F39536E40AAAAA967B1B402DD85" && userRight.IdUserRole != "50CFFEF3D4BB4529B3134E923B1B4B9E")
							{
								var userSmctSignerRemove = await _repo.Context.UserSmctSigners.Where(x => x.IdUserSmct == indata.UserSmct.IdUserSmct).ToListAsync();
								if (userSmctSignerRemove.Count > 0)
								{
									var UserSmctSignerFileRemove = await _repo.Context.UserSmctSignerFiles.Where(x => x.IdUserSmctSigner == userSmctSignerRemove.FirstOrDefault().IdUserSmctSigner).ToListAsync();
									if (UserSmctSignerFileRemove.Count > 0)
									{
										_db.DeleteRange(UserSmctSignerFileRemove);
										await _db.SaveAsync();
									}
									_db.DeleteRange(userSmctSignerRemove);
									await _db.SaveAsync();
								}
							}
							//UserRoleCode 06,07
							if (userRight.IdUserRole == "95BF9F39536E40AAAAA967B1B402DD85" || userRight.IdUserRole == "50CFFEF3D4BB4529B3134E923B1B4B9E")
							{
								if (indata.UserSmct.UserSmctSigners != null)
								{
									var smctSigner = indata.UserSmct.UserSmctSigners;
									var userSmcts = _repo.Context.UserSmcts.Where(x => x.Used);

									String _Signer1User = String.Empty;
									String _Signer1UserFullName = String.Empty;
									//ผู้มีอำนาจด้วยตนเอง
									if (userRight.IdUserRole == "95BF9F39536E40AAAAA967B1B402DD85")
									{
										_Signer1User = userSmct.IdUserSmct;
										_Signer1UserFullName = userSmct.UserFullname;
									}

									var userSmctSigner = await _repo.Context.UserSmctSigners.FirstOrDefaultAsync(x => x.IdUserSmct == indata.UserSmct.IdUserSmct);
									if (userSmctSigner == null)
									{
										userSmctSigner = new UserSmctSigner
										{
											IdUserSmct = userSmct.IdUserSmct,
											SignerType = smctSigner.SignerType,
											Signer1User = _Signer1User,
											Signer1Name = _Signer1UserFullName,
											Signer1DocName = smctSigner.Signer1DocName,
											Signer1DocNo = smctSigner.Signer1DocNo,
											Signer1DocDate = GeneralUtils.DateToEn(smctSigner.Signer1DocDateStr),
											Signer2PoaDocNo = smctSigner.Signer2PoaDocNo,
											Signer2PoaDocDate = GeneralUtils.DateToEn(smctSigner.Signer2PoaDocDateStr),
											Signer2PoaSigner1User = smctSigner.Signer2PoaSigner1User,
											Signer2PoaSigner1Name = userSmcts.FirstOrDefault(x => x.IdUserSmct == smctSigner.Signer2PoaSigner1User)?.UserFullname ?? String.Empty,
											Signer2DocName = smctSigner.Signer2DocName,
											Signer2DocNo = smctSigner.Signer2DocNo,
											Signer2DocDate = GeneralUtils.DateToEn(smctSigner.Signer2DocDateStr),
											Signer2StartDate = GeneralUtils.DateToEn(smctSigner.Signer2StartDateStr),
											Signer2EndDate = GeneralUtils.DateToEn(smctSigner.Signer2EndDateStr),
											Status = _Status,
											CreateUser = _repo.UserService.GetIdUserSmct(),
											EditUser = _repo.UserService.GetIdUserSmct(),
											CreateDate = DateTime.Now,
											EditDate = DateTime.Now,
											Used = true
										};
										await _db.InsterAsync(userSmctSigner);
										await _db.SaveAsync();
									}
									else
									{
										userSmctSigner.SignerType = smctSigner.SignerType;
										userSmctSigner.Signer1User = _Signer1User;
										userSmctSigner.Signer1Name = _Signer1UserFullName;
										userSmctSigner.Signer1DocName = smctSigner.Signer1DocName;
										userSmctSigner.Signer1DocNo = smctSigner.Signer1DocNo;
										userSmctSigner.Signer1DocDate = GeneralUtils.DateToEn(smctSigner.Signer1DocDateStr);
										userSmctSigner.Signer2PoaDocNo = smctSigner.Signer2PoaDocNo;
										userSmctSigner.Signer2PoaDocDate = GeneralUtils.DateToEn(smctSigner.Signer2PoaDocDateStr);
										userSmctSigner.Signer2PoaSigner1User = smctSigner.Signer2PoaSigner1User;
										userSmctSigner.Signer2PoaSigner1Name = userSmcts.FirstOrDefault(x => x.IdUserSmct == smctSigner.Signer2PoaSigner1User)?.UserFullname ?? String.Empty;
										userSmctSigner.Signer2DocName = smctSigner.Signer2DocName;
										userSmctSigner.Signer2DocNo = smctSigner.Signer2DocNo;
										userSmctSigner.Signer2DocDate = GeneralUtils.DateToEn(smctSigner.Signer2DocDateStr);
										userSmctSigner.Signer2StartDate = GeneralUtils.DateToEn(smctSigner.Signer2StartDateStr);
										userSmctSigner.Signer2EndDate = GeneralUtils.DateToEn(smctSigner.Signer2EndDateStr);
										userSmctSigner.EditUser = _repo.UserService.GetIdUserSmct();
										userSmctSigner.EditDate = DateTime.Now;
										_db.Update(userSmctSigner);
										await _db.SaveAsync();
									}
									//fileList ที่กดลบ
									var userSmctSignerFilesRemove = _repo.Context.UserSmctSignerFiles.Where(x => x.IdUserSmctSigner == userSmctSigner.IdUserSmctSigner).ToList();
									if (smctSigner.UserSmctSignerFiles != null && smctSigner.UserSmctSignerFiles.Count > 0)
									{
										userSmctSignerFilesRemove = userSmctSignerFilesRemove.Where(x => !smctSigner.UserSmctSignerFiles.Select(r => r.IdUserSmctSignerFile).Contains(x.IdUserSmctSignerFile)).ToList();
									}
									if (userSmctSignerFilesRemove.Count > 0)
									{
										_db.DeleteRange(userSmctSignerFilesRemove);
										await _repo.SaveAsync();
									}
									if (smctSigner.UserSmctSignerFiles != null && smctSigner.UserSmctSignerFiles.Count > 0)
									{
										int index_file = 1;
										foreach (var item in smctSigner.UserSmctSignerFiles)
										{
											var fileFTP = _repo.UploadFiles.GenFileName(item.FormFile, Guid.NewGuid().ToString(), $"FILE_Signer");
											String thaiYear = GeneralUtils.getThaiYear(DateTime.Now.Year);

											var userSmctSignerFiles = await _repo.Context.UserSmctSignerFiles.FirstOrDefaultAsync(x => x.IdUserSmctSigner == userSmctSigner.IdUserSmctSigner
																									  && x.IdUserSmctSignerFile == item.IdUserSmctSignerFile);
											if (userSmctSignerFiles != null)
											{
												userSmctSignerFiles.SignerFileNo = index_file++;
												userSmctSignerFiles.PathFolder = thaiYear;
												_db.Update(userSmctSignerFiles);
												await _db.SaveAsync();
											}
											else
											{
												var userSmctSignerFile = new UserSmctSignerFile
												{
													IdUserSmctSigner = userSmctSigner.IdUserSmctSigner,
													SignerFileType = "F1",
													SignerFileName = item.FormFile != null ? item.FormFile.FileName : String.Empty,
													SignerFileFtp = fileFTP,
													CreateUser = _repo.UserService.GetIdUserSmct(),
													EditUser = _repo.UserService.GetIdUserSmct(),
													CreateDate = DateTime.Now,
													EditDate = DateTime.Now,
													SignerFileNo = index_file++,
													Used = true,
													PathFolder = thaiYear
												};
												await _db.InsterAsync(userSmctSignerFile);
												await _db.SaveAsync();
											}

											if (item.FormFile != null)
											{
												String PathFolder = $"Register\\Signer\\{thaiYear}";
												this.HandleUploadfile(item.FormFile, fileFTP, PathFolder);
											}

										}
									}
								}
							}

						}
					}


				}

				await _transaction.CommitAsync();

				indata.RegisterNhso = indata_regis;
				return indata;
			}
		}

		private void HandleUploadfile(IFormFile FormFile, String fileFTP, String folderName)
		{
			//    UploadFilesResource saveFile = new UploadFilesResource()
			//    {
			//        Files = new List<IFormFile> { FormFile },
			//        ContentRootPath = _env.ContentRootPath,
			//        SubDirectory = @$"wwwroot\files\{folderName}\",
			//        FileNameServer = fileFTP
			//    };

			//    await _repo.UploadFiles.SaveFile(saveFile);
			//    return saveFile;
			_repo.UploadFiles.FTPSaveFile(FormFile, fileFTP, folderName);
		}

		private async Task<string> RegisterRunning()
		{
			int budgetYear = new ThaiBuddhistCalendar().GetYear(DateTime.Now);

			//ปีงบประมาณใหม่
			if (DateTime.Now.Month >= 10 && DateTime.Now.Day >= 1)
				budgetYear++;

			var query = await _repo.Context.RegisterNhsos.OrderByDescending(x => x.RegisterNo)
														 .FirstOrDefaultAsync(x => x.Used);
			String _BudgetYear = budgetYear.ToString().Substring(2);
			if (query == null)
			{
				return $"{_BudgetYear}R00001";
			}

			var registerNo = int.Parse(query.RegisterNo.Substring(3)) + 1;
			return $"{_BudgetYear}R{registerNo.ToString("00000")}";

		}

		private string GetRegisterType(RegisterMaster indata, VMasterVendorDTO indataMV)
		{
			var indata_regis = indata.RegisterNhso;
			/******* REGISTER_NHSO.REGISTER_TYPE *************
             - ถ้าไม่มี Vendor ให้เพิ่ม radio รัฐ/เอกชน ( GPType G=รัฐ ,P=เอกชน )
             - ถ้ามี Vendor แล้ว ให้เช็คที่ V_master_vendor.VENDOR_TYPE  รัฐ=H1+O1 ,เอกชน= H2+O2
            "ประเภทการลงทะเบียน
                1.ลงทะเบียนระบบสมัคร
                  1.1 G11 = รัฐ HCODE(มี) + VENDOR_ID(มี)
                  1.2 G12 = รัฐ HCODE(มี) + VENDOR_ID(ไม่มี)
                  1.3 P11 = เอกชน HCODE(มี) + VENDOR_ID(มี)
                  1.4 P12 = เอกชน HCODE(มี) + VENDOR_ID(ไม่มี)
                2.ไม่ลงทะเบียนระบบสมัคร
                  2.1 G21 =  รัฐ VENDOR_ID(มี)
                  2.2 G22 =  รัฐ VENDOR_ID(ไม่มี)
                  2.3 P21 =  เอกชน VENDOR_ID(มี)
                  2.4 P22 =  เอกชน VENDOR_ID(ไม่มี)"
            **************************************************************/

			////ลงทะเบียนจากระบบสมัครและไม่มี vendor
			//if (indata_regis.RegisterType == "P11" && indataMV == null) return "P22";

			////รัฐ ไม่ได้ลงทะเบียนจากระบบสมัครและไม่มี vendor
			//if (indata.GPType == GPTypes.Government && indata_regis.RegisterType == "P21" && indataMV == null) return "G22";
			////เอกชน ไม่ได้ลงทะเบียนจากระบบสมัครและไม่มี vendor
			//if (indata.GPType == GPTypes.Private && indata_regis.RegisterType == "P21" && indataMV == null) return "P22";

			//vendorId จาก MasterVendor(มี Vendor แล้ว)
			if (indataMV != null)
			{
				if (!String.IsNullOrEmpty(indataMV.VendorId) && indataMV.VendorId.Length > 1)
				{
					indata.GPType = indataMV.VendorType.EndsWith("1") ? GPTypes.Government : GPTypes.Private;
				}

			}

			//1.ลงทะเบียนระบบสมัคร
			if (indata_regis.RegisterType == "P11")
			{
				if (indata.GPType == GPTypes.Government)
				{
					if (indata_regis.Hcode.Length > 1 && indata_regis.Hcode != "99999" && !String.IsNullOrEmpty(indata.VendorId) && indata.VendorId != "99999")
						indata_regis.RegisterType = "G11";
					if (indata_regis.Hcode.Length > 1 && indata_regis.Hcode != "99999" && indata.VendorId == "99999")
						indata_regis.RegisterType = "G12";
				}
				if (indata.GPType == GPTypes.Private)
				{
					if (indata_regis.Hcode.Length > 1 && indata_regis.Hcode != "99999" && !String.IsNullOrEmpty(indata.VendorId) && indata.VendorId != "99999")
						indata_regis.RegisterType = "P11";
					if (indata_regis.Hcode.Length > 1 && indata_regis.Hcode != "99999" && indata.VendorId == "99999")
						indata_regis.RegisterType = "P12";
				}
			}
			else if (indata_regis.RegisterType == "P21")
			{
				if (indata.GPType == GPTypes.Government)
				{
					if (indata.VendorId.Length > 1 && indata.VendorId != "99999")
						indata_regis.RegisterType = "G21";
					if (indata.VendorId == "99999")
						indata_regis.RegisterType = "G22";
				}
				if (indata.GPType == GPTypes.Private)
				{
					if (indata.VendorId.Length > 1 && indata.VendorId != "99999")
						indata_regis.RegisterType = "P21";
					if (indata.VendorId == "99999")
						indata_regis.RegisterType = "P22";
				}
			}

			return indata_regis.RegisterType;
		}

		private string GetDepartmentCodeZone(String ProvinceId)
		{
			var lkProvinces = _repo.Context.LkProvinces.FirstOrDefault(x => x.ProvinceId == ProvinceId);
			if (lkProvinces == null)
				throw new Exception("ไม่พบจังหวัดที่ตั้งในฐานข้อมูล");

			var lkDepartments = _repo.Context.LkDepartments.FirstOrDefault(x => x.NhsoZone == lkProvinces.NhsoZone);
			if (lkDepartments == null)
				throw new Exception("ไม่พบสำนักในฐานข้อมูล");

			return lkDepartments.Dcode;
		}

		public async Task<TrackingRegCheckMain> Dashboard(TrackingRegCheckMain indata)
		{
			var registerNhsos = _repo.Context.RegisterNhsos.Where(x => x.Used);

			var query = await registerNhsos.GroupBy(s => s.Status)
			  .Select(grp => new
			  {
				  Status = grp.Key,
				  StatusCount = grp.Count()
			  }).ToListAsync();

			indata.Dashboard = new DashboardCheck()
			{
				CancelCount = query.FirstOrDefault(x => x.Status == UserSmctStatus.Cancel)?.StatusCount ?? 0,
				WaitUse = query.FirstOrDefault(x => x.Status == UserSmctStatus.WaitUse)?.StatusCount ?? 0,
				NotUse = query.FirstOrDefault(x => x.Status == UserSmctStatus.NotUse)?.StatusCount ?? 0,
				Used = query.FirstOrDefault(x => x.Status == UserSmctStatus.Used)?.StatusCount ?? 0,

			};
			return indata;
		}

		public IList<TrackingRegCheckView> GetListRegCheck(SearchOptionRegCheck condition = null)
		{
			var query = from r in _repo.Context.RegisterNhsos.Where(x => x.Used)
							//join uv in _repo.Context.UserSmctVendors.Where(x => x.Used) on r.IdRegisterNhso equals uv.IdRegisterNhso into ruv
							//from ruvResult in ruv.DefaultIfEmpty()
							//join u in _repo.Context.UserSmcts.Where(x => x.Used) on ruvResult.IdUserSmct equals u.IdUserSmct into ruv_u
							//from ruv_uResult in ruv_u.DefaultIfEmpty()
							//join mv in _repo.Context.VtVMasterVendors.Where(x => x.Hcode != null) on ruvResult.VendorId equals mv.VendorId into ruv_mv
							//from ruv_mvResult in ruv_mv.DefaultIfEmpty()
						select new TrackingRegCheckView
						{
							IdRegisterNhso = r.IdRegisterNhso,
							//IdUserSmct = _repo.Context.UserSmctVendors.Where(x => x.IdRegisterNhso == r.IdRegisterNhso && x.Used)
							//                                          .Select(x => x.IdUserSmctNavigation.IdUserSmct).FirstOrDefault(),
							IdUserSmct = _repo.Context.UserSmctVendors.Where(x => x.IdRegisterNhso == r.IdRegisterNhso && x.Used)
																	  .Select(x => x.IdUserSmct).FirstOrDefault(),
							RegisterNo = r.RegisterNo,
							RegisterType = r.RegisterType,
							VendorId = r.VendorId,
							VendorName = r.VendorName,
							VendorType = "",//ruv_mvResult.VendorType,
							ProvinceId = r.ProvinceId,
							Catm = r.Catm,
							//CATMs = _repo.GeneralRepo.GetCATM(r.Catm),
							VillageNo = r.VillageNo,
							Building = r.Building,
							TaxId = r.TaxId,
							Soi = r.Soi,
							Moo = r.Moo,
							Road = r.Road,
							PostCode = r.PostCode,
							CreateDate = r.CreateDate,
							EditDate = r.EditDate,
							Username = r.CreateUserNavigation.Username,
							UserFullname = r.CreateUserNavigation.UserFullname,
							Status = r.Status
						};
			if (condition != null)
			{
				if (!String.IsNullOrEmpty(condition.Status))
					query = query.Where(x => x.Status == condition.Status);
			}

			return query.OrderByDescending(x => x.EditDate).ToList();
		}

		public PaginationView<List<TrackingRegCheckView>> GetTrackingRegCheck(int? page, int pageSize, SearchOptionRegCheck condition = null)
		{
			IEnumerable<TrackingRegCheckView> queryMap = null;

			queryMap = this.GetListRegCheck(condition);

			var pager = new Pager(queryMap.Count(), page, pageSize, condition);
			pager.UrlAction = "";

			var itemss = queryMap.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);

			var response = new PaginationView<List<TrackingRegCheckView>>()
			{
				Items = itemss.ToList(),
				Pager = pager
			};

			return response;
		}

		public async Task<TrackingRegCheckMain> DashboardUser(TrackingRegCheckMain indata)
		{
			var userSmcts = _repo.Context.UserSmcts.Where(x => x.Used);

			var query = await userSmcts.GroupBy(s => s.Status)
			  .Select(grp => new
			  {
				  Status = grp.Key,
				  StatusCount = grp.Count()
			  }).ToListAsync();

			indata.Dashboard = new DashboardCheck()
			{
				CancelCount = query.FirstOrDefault(x => x.Status == UserSmctStatus.Cancel)?.StatusCount ?? 0,
				WaitUse = query.FirstOrDefault(x => x.Status == UserSmctStatus.WaitUse)?.StatusCount ?? 0,
				NotUse = query.FirstOrDefault(x => x.Status == UserSmctStatus.NotUse)?.StatusCount ?? 0,
				Used = query.FirstOrDefault(x => x.Status == UserSmctStatus.Used)?.StatusCount ?? 0,

			};
			return indata;
		}

		public IQueryable<TrackingRegCheckView> GetListRegCheckUser(SearchOptionRegCheck condition = null)
		{
			var query = from regis in _repo.Context.RegisterNhsos.Where(x => x.Used)
						join smctsv in _repo.Context.UserSmctVendors.Where(x => x.Used)
						 on regis.IdRegisterNhso equals smctsv.IdRegisterNhso
						join smct in _repo.Context.UserSmcts.Where(x => x.Used)
						 on smctsv.IdUserSmct equals smct.IdUserSmct
						//join masterven in _repo.Context.VMasterVendors.Where(x => x.Hcode != null)
						// on regis.VendorId equals masterven.VendorId
						select new TrackingRegCheckView
						{
							IdRegisterNhso = regis.IdRegisterNhso,
							IdUserSmct = smct.IdUserSmct,
							RegisterNo = regis.RegisterNo,
							RegisterType = regis.RegisterType,
							VendorId = smctsv.VendorId,
							VendorName = regis.VendorName,
							VendorType = "",//masterven.VendorType,
							ProvinceId = regis.ProvinceId,
							Catm = regis.Catm,
							VillageNo = regis.VillageNo,
							Building = regis.Building,
							TaxId = regis.TaxId,
							Soi = regis.Soi,
							Moo = regis.Moo,
							Road = regis.Road,
							PostCode = regis.PostCode,
							CreateDate = regis.CreateDate,
							EditDate = smct.EditDate,
							Username = smct.Username,
							UserFullname = smct.UserFullname,
							PositionName = smct.PositionName,
							CreateUser = smct.CreateUser,
							UserFullnameCreate = smct.CreateUserNavigation.UserFullname,
							Status = smct.Status,
							SignerType = smct.UserSmctSignerIdUserSmctNavigations.Select(x => x.SignerType).FirstOrDefault(),
						};
			if (condition != null)
			{
				if (!String.IsNullOrEmpty(condition.VendorId))
					query = query.Where(x => x.VendorId == condition.VendorId);

				if (String.IsNullOrEmpty(condition.VendorId) && condition.Type == "P")
					query = query.Where(x => x.VendorId == condition.VendorId);

				if (!String.IsNullOrEmpty(condition.Status))
					query = query.Where(x => x.Status == condition.Status);
			}

			return query.OrderByDescending(x => x.EditDate);
		}

		public PaginationView<List<TrackingRegCheckView>> GetTrackingRegCheckUser(int? page, int pageSize, SearchOptionRegCheck condition = null)
		{
			IQueryable<TrackingRegCheckView> queryMap = null;

			queryMap = this.GetListRegCheckUser(condition);

			var pager = new Pager(queryMap.Count(), page, pageSize, condition);
			pager.UrlAction = "";

			var itemss = queryMap.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);

			var response = new PaginationView<List<TrackingRegCheckView>>()
			{
				Items = itemss.ToList(),
				Pager = pager
			};

			return response;
		}

		public async Task<RegisterMaster> SaveStatus(RegisterMaster indata)
		{
			if (!indata.Approve.Approve && !indata.Approve.UnApprove)
				throw new Exception("ระบุผลการตรวจสอบ");
			if (indata.Approve.UnApprove)
				if (String.IsNullOrEmpty(indata.Approve.Remark))
					throw new Exception("ระบุรายละเอียดหมายเหตุ");


			using (var _transaction = _repo.BeginTransaction())
			{
				if (indata.Approvetype == "U")
				{
					var query_reg = await _repo.Context.RegisterNhsos.FirstOrDefaultAsync(x => x.IdRegisterNhso == indata.RegisterNhso.IdRegisterNhso && x.Used);
					if (query_reg == null || query_reg.Status == UserSmctStatus.WaitUse)
						throw new Exception("หน่วยบริการสังกัด ยังไม่ได้รับการอนุมัติ");

					var userSmcts = await _repo.Context.UserSmcts.FirstOrDefaultAsync(x => x.IdUserSmct == indata.UserSmct.IdUserSmct && x.Used);
					var userRights = await _repo.Context.UserRights.FirstOrDefaultAsync(x => x.IdUserSmct == indata.UserSmct.IdUserSmct && x.Used);
					var userSmctVendors = await _repo.Context.UserSmctVendors.FirstOrDefaultAsync(x => x.IdUserSmct == indata.UserSmct.IdUserSmct && x.Used);
					if (indata.Approve.Approve)
					{
						userSmcts.Password = GeneralUtils.GetRandomString(8);
						userSmcts.Status = UserSmctStatus.Used;
						userSmctVendors.Status = UserSmctStatus.Used;
						userRights.Status = UserSmctStatus.Used;
					}
					if (indata.Approve.UnApprove)
					{
						userSmcts.Status = UserSmctStatus.NotUse;
						userSmctVendors.Status = UserSmctStatus.NotUse;
						userRights.Status = UserSmctStatus.NotUse;
						userRights.Remark = indata.Approve.Remark;
					}

					_db.Update(userSmcts);
					_db.Update(userSmctVendors);
				}
				else if (indata.Approvetype == "S")
				{
					var query = await _repo.Context.RegisterNhsos.FirstOrDefaultAsync(x => x.IdRegisterNhso == indata.RegisterNhso.IdRegisterNhso && x.Used);
					if (indata.Approve.Approve)
						query.Status = UserSmctStatus.Used;
					if (indata.Approve.UnApprove)
					{
						query.Status = UserSmctStatus.NotUse;
						query.Remark = indata.Approve.Remark;
					}

					_db.Update(query);
				}

				await _db.SaveAsync();
				await _transaction.CommitAsync();
				return indata;
			}
		}

		public ResourceEmail GetMailVerify(RegisterMaster indata, string htmlBody)
		{
			var builder = new BodyBuilder();

			builder.HtmlBody = htmlBody;

			String ApprovetypeName = indata.Approvetype == "U" ? "ผู้เข้าใช้งาน" : "หน่วยบริการ";

			return new ResourceEmail()
			{
				Builder = builder,
				Subject = $"Verify {ApprovetypeName}",
				Message = htmlBody,
				Email = indata.UserSmct.Email,
				Template = "Verify"
			};
		}

	}
}
