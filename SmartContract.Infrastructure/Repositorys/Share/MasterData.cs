using Microsoft.Extensions.Options;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Interfaces.Share;
using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Infrastructure.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartContract.Utils;
using SmartContract.Infrastructure.Interfaces;
using AutoMapper;
using SmartContract.Infrastructure.Resources.DTO;
using Microsoft.EntityFrameworkCore;
using SmartContract.Infrastructure.Data.EntityFramework;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using SmartContract.Infrastructure.Resources.Registers;
using SmartContract.Infrastructure.Resources.Guarantee;

namespace SmartContract.Infrastructure.Repositorys.Share
{
	public class MasterData : IMasterData
	{
		private IRepositoryWrapper _repo;
		private readonly IRepositoryBase _db;
		private readonly IMapper _mapper;
		private readonly AppSettings _mySet;

		public MasterData(IRepositoryWrapper repo, IRepositoryBase db, IMapper mapper, IOptions<AppSettings> settings)
		{
			_repo = repo;
			_db = db;
			_mapper = mapper;
			_mySet = settings.Value;
		}

		public List<BudgetYearModel> BudgetYear(int Range = 6)
		{
			List<BudgetYearModel> response = new List<BudgetYearModel>();
			DateTime Dn = DateTime.Now;

			var lastSixYear = Enumerable.Range(1, Range).Select(i => DateTime.Now.AddYears(i - Range).ToString("yyyy")).OrderByDescending(x => x);

			foreach (var Year in lastSixYear)
			{
				response.Add(new BudgetYearModel()
				{
					Id = (int.Parse(Year) + 543).ToString(),
					Value = (int.Parse(Year) + 543).ToString()
				});
			}
			return response;
		}

		public List<MonthModel> GetMonths()
		{
			List<MonthModel> response = new List<MonthModel>();
			for (int i = 1; i <= 12; i++)
			{
				String _MonthName = String.Empty;
				if (i == 1) _MonthName = "มกราคม";
				if (i == 2) _MonthName = "กุมภาพันธ์";
				if (i == 3) _MonthName = "มีนาคม";
				if (i == 4) _MonthName = "เมษายน";
				if (i == 5) _MonthName = "พฤษภาคม";
				if (i == 6) _MonthName = "มิถุนายน";
				if (i == 7) _MonthName = "กรกฎาคม";
				if (i == 8) _MonthName = "สิงหาคม";
				if (i == 9) _MonthName = "กันยายน";
				if (i == 10) _MonthName = "ตุลาคม";
				if (i == 11) _MonthName = "พฤศจิกายน";
				if (i == 12) _MonthName = "ธันวาคม";

				response.Add(new MonthModel()
				{
					Id = i.ToString(),
					Value = _MonthName
				});
			}
			return response;
		}

		public List<AuthoritySign> AuthoritySigns()
		{
			return new List<AuthoritySign>()
			{
				 new AuthoritySign(){Id =1,Name = "ผู้มีอำนาจลงนาม1"},
				 new AuthoritySign(){Id =2,Name = "ผู้มีอำนาจลงนาม2"},
				 new AuthoritySign(){Id =3,Name = "ผู้มีอำนาจลงนาม3"},
				 new AuthoritySign(){Id =4,Name = "ผู้มีอำนาจลงนาม4"},
				 new AuthoritySign(){Id =5,Name = "ผู้มีอำนาจลงนาม5"}
			};
		}

		public List<LkBank> BankInfos()
		{
			var query = _repo.Context.LkBanks.Where(x => x.BankId != null && x.BankName != null).ToList();

			return query;
		}

		/// <summary>
		/// ประเภทนิติกรรมสัญญา
		/// </summary>
		/// <param name="contractTypeId"></param>
		/// <returns></returns>
		public async Task<IList<ContractType>> ContractTypes(String contractTypeId = null)
		{
			var query = _repo.Context.ContractTypes.Where(x => x.Used);

			if (!String.IsNullOrEmpty(contractTypeId))
				query = query.Where(x => x.ContractTypeId == contractTypeId);

			return await query.ToListAsync();
		}

		public async Task<IList<UserSmctDTO>> Coordinators()
		{
			var query = from smct in _repo.Context.UserSmcts.Where(x => x.Used)
						join uri in _repo.Context.UserRights.Where(x => x.Used)
						 on smct.IdUserSmct equals uri.IdUserSmct
						join uro in _repo.Context.UserRoles.Where(x => x.Used)
						on uri.IdUserRole equals uro.IdUserRole
						where uro.UserRoleCode == "08"
						select new UserSmctDTO
						{
							IdUserSmct = smct.IdUserSmct,
							UserFullname = smct.UserFullname,
							UserRoles = new UserRoleDTO()
							{
								IdUserRole = uro.IdUserRole,
								UserRoleCode = uro.UserRoleCode,
								ShortName = uro.ShortName,
								FullName = uro.FullName
							}
						};

			return await query.ToListAsync();
		}

		public async Task<IEnumerable<VNhsoZone>> NhsoZones(string NhsoZone = null)
		{
			var query = _repo.Context.VNhsoZones.AsQueryable();

			if (!String.IsNullOrEmpty(NhsoZone))
				query = query.Where(x => x.NhsoZone == NhsoZone);

			return await query.OrderBy(x => x.NhsoZone).ToListAsync();
		}

		public async Task<IEnumerable<VMasterVendorDTO>> MasterVendor(String vendorId = null, String hcode = null, String nhsoZone = null)
		{
			//var query = _repo.Context.VMasterVendors.Where(x => x.VendorId != null && x.Hcode != null);
			var query = _repo.Context.VMasterVendors.Where(x => x.VendorId != null);

			//fix ข้อมูลก่อนเพราะตอนโหลดจะช้า หาวิธีแก้ทีหลัง
			//query = query.Where(x => x.Catm != null && x.VendorId.StartsWith("110") || x.VendorId.StartsWith("210") || x.VendorId.StartsWith("231")).OrderBy(x => x.VendorId);


			if (!String.IsNullOrEmpty(vendorId))
			{
				query = query.Where(x => x.VendorId == vendorId);
				if (query.Count() == 1)
				{
					var responseMap1 = _mapper.Map<List<VMasterVendorDTO>>(await query.ToListAsync());
					responseMap1.ForEach(x => x.CheckRegister = true);
					responseMap1.ForEach(x => x.CompanyName = x.VendorName);
					return responseMap1;
				}
			}
			if (!String.IsNullOrEmpty(hcode))
			{
				if (hcode == "99999" && !String.IsNullOrEmpty(nhsoZone))
				{
					var vnhsoZones = _repo.Context.VNhsoZones.Where(x => x.NhsoZone == nhsoZone).Select(x => x.ProvinceId).ToList();
					query = query.Where(x => vnhsoZones.Contains(x.ProvinceId));

				}
				else
				{
					query = query.Where(x => x.Hcode == hcode);
					if (query.Count() == 1)
					{
						var responseMap1 = _mapper.Map<List<VMasterVendorDTO>>(await query.ToListAsync());
						responseMap1.ForEach(x => x.CheckRegister = true);
						responseMap1.ForEach(x => x.CompanyName = x.VendorName);
						return responseMap1;
					}
				}
			}


			var responseMap = _mapper.Map<List<VMasterVendorDTO>>(await query.ToListAsync());

			return responseMap;
		}

		public async Task<IEnumerable<ViewHraRegisterDTO>> ServiceUnits(String vendorId = null, String hcode = null, String nhsoZone = null)
		{
			var query = _repo.Context.ViewHraRegisters.Where(x => x.VendorId != null && x.Hcode != null);

			//fix ข้อมูลก่อนเพราะตอนโหลดจะช้า หาวิธีแก้ทีหลัง
			//query = query.Where(x => x.VendorId.StartsWith("11") || x.VendorId.StartsWith("210")).OrderBy(x => x.VendorId);

			if (!String.IsNullOrEmpty(vendorId))
				query = query.Where(x => x.VendorId == vendorId);
			if (!String.IsNullOrEmpty(hcode))
				query = query.Where(x => x.Hcode == hcode);
			if (!String.IsNullOrEmpty(nhsoZone))
			{

				var vnhsoZones = _repo.Context.VNhsoZones.Where(x => x.NhsoZone == nhsoZone).Select(x => x.ProvinceId).ToList();
				query = query.Where(x => vnhsoZones.Contains(x.ProvinceId));
			}

			var responseMap = _mapper.Map<List<ViewHraRegisterDTO>>(await query.ToListAsync());
			return responseMap;
		}

		public async Task<IEnumerable<LkDepartment>> LKDepartments(string dcode = null)
		{
			var query = _repo.Context.LkDepartments.Where(x => x.Display == "Y");

			if (!String.IsNullOrEmpty(dcode))
				query = query.Where(x => x.Dcode == dcode);

			return await query.OrderBy(x => x.Dename).ToListAsync();
		}

		public async Task<IEnumerable<LkProvince>> LKProvinces(string provinceId = null)
		{
			var query = _repo.Context.LkProvinces.Where(x => x.ProvinceId != null
														&& !x.ProvinceId.Contains("SP")
														&& !x.ProvinceId.Contains("SN")
														&& !x.ProvinceId.Contains("NHSO"));

			if (!String.IsNullOrEmpty(provinceId))
				query = query.Where(x => x.ProvinceId == provinceId);

			return await query.OrderBy(x => x.ProvinceName).ToListAsync();
		}

		public async Task<IEnumerable<LkAmphur>> LKAmphurs(string provinceId = null)
		{

			var query = _repo.Context.LkAmphurs.Where(x => x.Code != null && x.ProvinceId != null && x.Available == 1);

			if (!String.IsNullOrEmpty(provinceId))
			{
				provinceId = provinceId.Length > 2 && provinceId != "00000" ? provinceId.Substring(0, 2) : provinceId;
				query = query.Where(x => x.ProvinceId == provinceId);
			}

			return await query.OrderBy(x => x.Name).ToListAsync();
		}

		public async Task<IEnumerable<LkDistrict>> LKDistricts(string code = null)
		{
			var query = _repo.Context.LkDistricts.Where(x => x.Code != null && x.Available == 1);

			if (!String.IsNullOrEmpty(code))
				query = query.Where(x => x.Code.Contains(code));

			return await query.OrderBy(x => x.Name).ToListAsync();
		}

		public async Task<IEnumerable<LkCatm>> LKCatm(string catm = null)
		{
			var query = _repo.Context.LkCatms.Where(x => x.Catm != null);

			if (!String.IsNullOrEmpty(catm))
				query = query.Where(x => x.Catm == catm);

			return await query.ToListAsync();
		}

		/// <summary>
		/// คู่สัญญาหน่วยบริการ
		/// </summary>
		/// <returns></returns>
		public async Task<IEnumerable<LmHospital>> LMHospitals()
		{
			var query = _repo.Context.LmHospitals.Where(x => x.Catm != null);


			return await query.ToListAsync();
		}

		/// <summary>
		/// ชื่อหน้าหน่วยบริการ
		/// </summary>
		/// <param name="htitleId"></param>
		/// <returns></returns>
		public async Task<IEnumerable<LmHtitle>> LMHtitles(string htitleId = null)
		{
			var query = _repo.Context.LmHtitles.Where(x => x.HtitleId != null);

			if (!String.IsNullOrEmpty(htitleId))
				query = query.Where(x => x.HtitleId == htitleId);

			return await query.ToListAsync();
		}

		/// <summary>
		/// ผู้มีอำนาจลงนาม
		/// </summary>
		/// <param name="IdUserSmct"></param>
		/// <returns></returns>
		public async Task<IList<UserSmctDTO>> UserSmctSigner(string IdUserSmct = null, string IdRegisterNhso = null)
		{
			var query = from smct in _repo.Context.UserSmcts.Where(x => x.Used)
						join smctsv in _repo.Context.UserSmctVendors.Where(x => x.Used)
						 on smct.IdUserSmct equals smctsv.IdUserSmct
						join smcts in _repo.Context.UserSmctSigners.Where(x => x.Used)
						 on smct.IdUserSmct equals smcts.IdUserSmct
						join regis in _repo.Context.RegisterNhsos.Where(x => x.Used)
						 on smctsv.IdRegisterNhso equals regis.IdRegisterNhso
						select new UserSmctDTO
						{
							IdUserSmct = smct.IdUserSmct,
							IdRegisterNhso = regis.IdRegisterNhso,
							VendorId = smctsv.VendorId,
							UserFullname = smct.UserFullname,
							SignerType = smcts.SignerType,
							PositionName = smct.PositionName,
							Used = smct.Used,
							UserSmctSigners = new UserSmctSignerDTO()
							{
								IdUserSmct = smcts.IdUserSmct,
								IdUserSmctSigner = smcts.IdUserSmctSigner,
								SignerType = smcts.SignerType,
								Signer1DocName = smcts.Signer1DocName,
								Signer1DocNo = smcts.Signer1DocNo,
								Signer1DocDate = smcts.Signer1DocDate,
								Signer1DocDateStr = GeneralUtils.DateToThString(smcts.Signer1DocDate),
								Signer2PoaDocNo = smcts.Signer2PoaDocNo,
								Signer2PoaDocDate = smcts.Signer2PoaDocDate,
								Signer2PoaDocDateStr = GeneralUtils.DateToThString(smcts.Signer2PoaDocDate),
								Signer2PoaSigner1User = smcts.Signer2PoaSigner1User,
								Signer2PoaSigner1Name = smcts.Signer2PoaSigner1Name,
								Signer2DocName = smcts.Signer2DocName,
								Signer2DocNo = smcts.Signer2DocNo,
								Signer2DocDate = smcts.Signer2DocDate,
								Signer2DocDateStr = GeneralUtils.DateToThString(smcts.Signer2DocDate),
								Signer2StartDate = smcts.Signer2StartDate,
								Signer2StartDateStr = GeneralUtils.DateToThString(smcts.Signer2StartDate),
								Signer2EndDate = smcts.Signer2EndDate,
								Signer2EndDateStr = GeneralUtils.DateToThString(smcts.Signer2EndDate),
								Status = smcts.Status,
								Signer1User = smcts.Signer1User,
								Signer1Name = smcts.Signer1Name,
								Used = smcts.Used
							}
						};

			if (!String.IsNullOrEmpty(IdUserSmct))
				query = query.Where(x => x.IdUserSmct == IdUserSmct);
			if (!String.IsNullOrEmpty(IdRegisterNhso))
				query = query.Where(x => x.IdRegisterNhso == IdRegisterNhso);


			return await query.ToListAsync();
		}

		public async Task<IEnumerable<VNhsoBoradDTO>> CommitteeList(string departmentCode)
		{
			var query = _repo.Context.VNhsoBorads.Where(x => x.DepartmentCode != null);

			if (!String.IsNullOrEmpty(departmentCode))
				query = query.Where(x => x.DepartmentCode == departmentCode);

			var responseMap = _mapper.Map<List<VNhsoBoradDTO>>(await query.ToListAsync());

			if (_mySet.ServerSite == "UAT")
			{
				responseMap.Add(new VNhsoBoradDTO() { EmpId = "EM001", DepartmentCode = "03300", BoradFullname = "กรรมการ ทดสอบ1", BoradType = "C", BoradEmail = "ti-claim@nhso.go.th" });
				responseMap.Add(new VNhsoBoradDTO() { EmpId = "EM002", DepartmentCode = "03300", BoradFullname = "กรรมการ ทดสอบ2", BoradType = "C", BoradEmail = "ti-claim@nhso.go.th" });
				responseMap.Add(new VNhsoBoradDTO() { EmpId = "EM003", DepartmentCode = "03300", BoradFullname = "กรรมการ ทดสอบ3", BoradType = "C", BoradEmail = "ti-claim@nhso.go.th" });
			}

			return responseMap;
		}

		public async Task<IEnumerable<BudgetcodeViewDTO>> BudgetcodeList(string budgetcode, bool? IsCurrentYear = null)
		{
			var query = _repo.Context.BudgetcodeViews.Where(x => x.Budgetcode != null);

			if (!String.IsNullOrEmpty(budgetcode))
				query = query.Where(x => x.Budgetcode == budgetcode);

			if (IsCurrentYear.HasValue && IsCurrentYear.Value)
			{
				int budgetYear = new ThaiBuddhistCalendar().GetYear(DateTime.Now);
				//ปีงบประมาณใหม่
				if (DateTime.Now.Month >= 10 && DateTime.Now.Day >= 1)
					budgetYear++;

				string Current = budgetYear.ToString();

				query = query.Where(x => x.Budgetyear == Current);
			}

			var responseMap = _mapper.Map<List<BudgetcodeViewDTO>>(await query.ToListAsync());
			return responseMap;
		}

		public async Task<IList<VNhsoSigner>> NhsoSigner(string departmentCode = null)
		{
			var query = _repo.Context.VNhsoSigners.Where(x => x.DepartmentCode != null && x.SignerEmail != null);

			if (!String.IsNullOrEmpty(departmentCode))
				query = query.Where(x => x.DepartmentCode == departmentCode);

			return await query.ToListAsync();
		}

		public async Task<IList<VNhsoEmployeeAll>> VNhsoEmployeeAll(string EmpId = null, String departmentCode = null)
		{
			var query = _repo.Context.VNhsoEmployeeAlls.Where(x => x.EmpId != null && x.PersonNhsoMail.Contains("@nhso"));

			if (!String.IsNullOrEmpty(EmpId))
				query = query.Where(x => x.EmpId == EmpId);
			if (!String.IsNullOrEmpty(departmentCode))
				query = query.Where(x => x.EmpDepartmentCode == departmentCode);

			//fix ข้อมูลก่อนเพราะตอนโหลดจะช้า หาวิธีแก้ทีหลัง
			//query = query.Where(x => x.EmpDepartmentCode.Contains("003") && x.EmpStatus == "Y");

			var responseMap = await query.ToListAsync();
			//if (_mySet.ServerSite == "UAT")
			//{
			//    responseMap.Add(new VNhsoEmployeeAll() { EmpId = "EM001", EmpFullname = "ผู้ขออนุมัติ ทดสอบ1", EmpPosition = "ผู้ขออนุมัติ" });
			//    responseMap.Add(new VNhsoEmployeeAll() { EmpId = "EM002", EmpFullname = "ผู้ขออนุมัติ ทดสอบ2", EmpPosition = "ผู้ขออนุมัติ" });
			//    responseMap.Add(new VNhsoEmployeeAll() { EmpId = "EM003", EmpFullname = "ผู้ขออนุมัติ ทดสอบ3", EmpPosition = "ผู้ขออนุมัติ" });
			//}

			return responseMap;
		}

		public async Task<IList<VDFiBankVendor>> VDFiBankVendorList(String VendorId = null)
		{
			var query = _repo.Context.VDFiBankVendors.AsQueryable();

			if (!String.IsNullOrEmpty(VendorId))
				query = query.Where(x => x.VendorId == VendorId);

			return await query.ToListAsync();
		}

		public async Task<IList<VNhsoZone>> ProvincesUnderNHSO()
		{

			var query = _repo.Context.VNhsoZones.AsQueryable();

			return await query.ToListAsync();
		}

		public async Task<IEnumerable<FileSystemDTO>> GetAttachSystem(string hcode = null)
		{
			var FileSystemDTO = new List<FileSystemDTO>();

			string DomainName = "http://192.168.202.10:8080";
			if (_mySet.ServerSite == "TEST")
			{
				DomainName = "https://test.nhso.go.th/hra";
			}
			else if (_mySet.ServerSite == "PRO")
			{
				DomainName = "https://hra.nhso.go.th/hra";
			}
			//var query = await _repo.Context.ViewAttachFiles.Where(x => x.FileName != null && x.FilePath != null && x.OriginalFileName != null).ToListAsync();
			var query = await _repo.Context.ViewRegisterAttachFiles.Where(x => x.Hcode == hcode).ToListAsync();
			foreach (var item in query)
			{
				FileSystemDTO.Add(new Resources.Registers.FileSystemDTO()
				{
					OriginalFileName = item.OriginalFileName,
					Url = $"{DomainName}/public/download/attach-file/{item.Id}/{item.Uuid}"
				});
			}

			return FileSystemDTO;
		}

		public IEnumerable<AppTypeModel> GetAppTypeList(string AppTypeId = null)
		{
			var response = new List<AppTypeModel>();
			response.Add(new AppTypeModel() { Id = "3", Value = "ขอคืน/ยกเลิก" });
			response.Add(new AppTypeModel() { Id = "4", Value = "ขอเคลม" });
			response.Add(new AppTypeModel() { Id = "5", Value = "ขอเพิ่ม" });
			response.Add(new AppTypeModel() { Id = "6", Value = "ขอลด" });

			if (AppTypeId != null)
			{
				response = response.Where(x => x.Id == AppTypeId).ToList();
			}
			return response;
		}

		public IEnumerable<AppTypeModel> LgStatus(string status = null)
		{
			var response = new List<AppTypeModel>();
			response.Add(new AppTypeModel() { Id = null, Value = "อยู่ระหว่างส่งคำขอ" });
			response.Add(new AppTypeModel() { Id = "created", Value = "ขอออกใหม่" });
			response.Add(new AppTypeModel() { Id = "cancelled", Value = "ขอคืน/ยกเลิก" });
			response.Add(new AppTypeModel() { Id = "extended", Value = "ขอต่ออายุ" });
			response.Add(new AppTypeModel() { Id = "increased", Value = "ขอเพิ่มวงเงิน" });
			response.Add(new AppTypeModel() { Id = "decreased", Value = "ขอลดวงเงิน" });
			response.Add(new AppTypeModel() { Id = "claimed", Value = "ขอเคลม" });

			if (status != null)
			{
				response = response.Where(x => x.Id == status).ToList();
			}

			return response;
		}

		public IEnumerable<AppTypeModel> GetContractTypeList(string Id = null)
		{
			var response = new List<AppTypeModel>();
			response.Add(new AppTypeModel() { Id = "1", Value = "สัญญาจ้าง" });
			response.Add(new AppTypeModel() { Id = "2", Value = "สัญญาซื้อขาย" });
			response.Add(new AppTypeModel() { Id = "3", Value = "สัญญาจะซื้อจะขาย" });
			response.Add(new AppTypeModel() { Id = "4", Value = "สัญญาเช่า" });
			response.Add(new AppTypeModel() { Id = "5", Value = "ใบเสนอราคา" });
			response.Add(new AppTypeModel() { Id = "6", Value = "ใบสั่งซื้อ" });
			response.Add(new AppTypeModel() { Id = "7", Value = "Purchase Order" });
			response.Add(new AppTypeModel() { Id = "8", Value = "เอกสารยืนยันการว่าจ้าง" });
			response.Add(new AppTypeModel() { Id = "99", Value = "อื่นๆ โปรดระบุ" });

			if (Id != null)
			{
				response = response.Where(x => x.Id == Id).ToList();
			}

			return response;
		}

		public IEnumerable<AppTypeModel> GetGuaranteeTypeList(string Id = null)
		{
			var response = new List<AppTypeModel>();
			response.Add(new AppTypeModel() { Id = "1", Value = "ยื่นซอง" });
			response.Add(new AppTypeModel() { Id = "2", Value = "การรับเงินล่วงหน้า" });
			response.Add(new AppTypeModel() { Id = "3", Value = "การปฎิบัติตามสัญญา" });
			response.Add(new AppTypeModel() { Id = "5", Value = "การใช้กระแสไฟฟ้า" });
			response.Add(new AppTypeModel() { Id = "6", Value = "ค่าภาษีอากร 19 ทวิ" });
			response.Add(new AppTypeModel() { Id = "7", Value = "การซื้อสินค้า" });
			response.Add(new AppTypeModel() { Id = "8", Value = "สาธารณูปโภคเพื่อการจัดสรรที่ดิน" });
			response.Add(new AppTypeModel() { Id = "9", Value = "การรับเงินประกันผลงาน" });

			if (Id != null)
			{
				response = response.Where(x => x.Id == Id).ToList();
			}

			return response;
		}

	}
}
