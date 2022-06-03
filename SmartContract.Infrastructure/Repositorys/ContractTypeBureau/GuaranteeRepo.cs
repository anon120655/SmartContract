using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SmartContract.Infrastructure.Data.EntityFramework;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Interfaces;
using SmartContract.Infrastructure.Interfaces.ContractTypeBureau;
using SmartContract.Infrastructure.Resources.ContractTypeBureau;
using SmartContract.Infrastructure.Resources.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Guarantee;
using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Infrastructure.Wrapper;
using SmartContract.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Repositorys.ContractTypeBureau
{
	public class GuaranteeRepo : IGuaranteeRepo
	{

		private IRepositoryWrapper _repo;
		private readonly IRepositoryBase _db;
		private readonly IMapper _mapper;
		private readonly IWebHostEnvironment _env;
		private readonly AppSettings _mySet;

		public GuaranteeRepo(IRepositoryWrapper repo, IRepositoryBase db, IMapper mapper, IWebHostEnvironment env, IOptions<AppSettings> settings)
		{
			_repo = repo;
			_db = db;
			_env = env;
			_mapper = mapper;
			_mySet = settings.Value;
		}


		public async Task<ELGCreateMain> GetView(ParameterCreate indata)
		{
			var _GuaranteeLgReqs = await _repo.Context.GuaranteeLgReqs.FirstOrDefaultAsync(x => x.IdGuaranteeLgReq == indata.IdGuaranteeLgReq);
			var _GuaranteeLgReqStations = await _repo.Context.GuaranteeLgReqStations.FirstOrDefaultAsync(x => x.IdGuaranteeLgReq == indata.IdGuaranteeLgReq);

			var _LgStatusName = _repo.MasterData.LgStatus(_GuaranteeLgReqs.LgStatus).FirstOrDefault().Value;
			var _effectiveDateStart = GeneralUtils.DateToEn(_GuaranteeLgReqStations.EffectiveDateStart, "yyyy-MM-dd");
			var _effectiveDateEnd = GeneralUtils.DateToEn(_GuaranteeLgReqStations.EffectiveDateEnd, "yyyy-MM-dd");

			var response = new ELGCreateMain()
			{
				Request = new Resources.Share.ServiceOther.eLGCreateRequest()
				{
					appTypeId = _GuaranteeLgReqStations.AppTypeId,
					taxId = _GuaranteeLgReqStations.TaxId,
					requesterNameTh = _GuaranteeLgReqStations.RequesterNameTh,
					contractNo = _GuaranteeLgReqStations.ContractId,
					contractDate = GeneralUtils.DateToThString(_GuaranteeLgReqStations.ContractDate),
					lgNumber = _GuaranteeLgReqStations.LgNumber,
					effectiveDateStart = GeneralUtils.DateToThString(_effectiveDateStart),
					effectiveDateEnd = GeneralUtils.DateToThString(_effectiveDateEnd),
					lgAmount = _GuaranteeLgReqStations.LgAmount.Value,
					guaranteeTypeId = _GuaranteeLgReqStations.GuaranteeTypeId,
					contractTypeId = _GuaranteeLgReqStations.ContractTypeId,
					contractDetail = _GuaranteeLgReqs.ContractDetail,
					comment = _GuaranteeLgReqs.Comments,
					LgStatusName = _LgStatusName
				}
			};
			;
			return response;
		}

		public async Task<DashboardLG> GetDashboardLG()
		{
			var lGReqStations = _repo.Context.GuaranteeLgReqStations.Where(x => x.Used);
			var queryCount = await lGReqStations.GroupBy(s => s.LgStatus)
					.Select(grp => new
					{
						LgStatus = grp.Key,
						LgStatusCount = grp.Count()
					}).ToListAsync();

			var _DefualtCount = queryCount.FirstOrDefault(x => x.LgStatus == null)?.LgStatusCount;
			var _CreatedCount = queryCount.FirstOrDefault(x => x.LgStatus == "Created")?.LgStatusCount;
			var _ExtendedCount = queryCount.FirstOrDefault(x => x.LgStatus == "Extended")?.LgStatusCount;
			var _IncreasedCount = queryCount.FirstOrDefault(x => x.LgStatus == "Increased")?.LgStatusCount;
			var _DecreasedCount = queryCount.FirstOrDefault(x => x.LgStatus == "Decreased")?.LgStatusCount;
			var _ClaimedCount = queryCount.FirstOrDefault(x => x.LgStatus == "Claimed")?.LgStatusCount;
			return new DashboardLG()
			{
				DefualtCount = _DefualtCount ?? 0,
				CreatedCount = _CreatedCount ?? 0,
				ExtendedCount = _ExtendedCount ?? 0,
				IncreasedCount = _IncreasedCount ?? 0,
				DecreasedCount = _DecreasedCount ?? 0,
				ClaimedCount = _ClaimedCount ?? 0
			};
		}

		public IQueryable<GuaranteeLgReqStation> GetListLG(SearchOptionLG condition = null)
		{
			var queryMap = _repo.Context.GuaranteeLgReqStations.OrderByDescending(x => x.EditDate).AsQueryable();

			if (condition != null)
			{
				if (!String.IsNullOrEmpty(condition.DepartmentCode))
					queryMap = queryMap.Where(x => x.DepartmentCode.Contains(condition.DepartmentCode)).AsQueryable();

				if (!String.IsNullOrEmpty(condition.LgStatus))
				{
					if (condition.LgStatus == "Defualt")
					{
						queryMap = queryMap.Where(x => x.LgStatus == null).AsQueryable();
					}
					else
					{
						queryMap = queryMap.Where(x => x.DepartmentCode.Contains(condition.LgStatus)).AsQueryable();
					}
				}

			}
			return queryMap;
		}

		public PaginationView<List<GuaranteeLgReqStationDTO>> GetTrackingLG(int? page, int pageSize, SearchOptionLG condition = null)
		{
			IQueryable<GuaranteeLgReqStation> queryMap = null;

			queryMap = this.GetListLG(condition);

			var pager = new Pager(queryMap.Count(), page, pageSize, condition);

			var itemss = queryMap.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);

			var response = new PaginationView<List<GuaranteeLgReqStationDTO>>()
			{
				Items = _mapper.Map<List<GuaranteeLgReqStationDTO>>(itemss),
				Pager = pager
			};

			return response;
		}

		public string SetUrlRedirect(TAllMasterVendorView indata)
		{
			String UrlRedirect = String.Empty;

			UrlRedirect = $"{_mySet.SubDomainServer}/Guarantee/Tracking?Menuen={indata.ParameterCondition.ContractGuaranteeTypeEn}";

			return UrlRedirect;
		}

		public IQueryable<VGuaranteeLgContract> GetListSearchLG(SearchOptionLG condition = null)
		{
			var queryMap = _repo.Context.VGuaranteeLgContracts.AsQueryable();

			if (condition != null)
			{
				if (!String.IsNullOrEmpty(condition.requesterNameTh))
					queryMap = queryMap.Where(x => x.VendorName.Contains(condition.requesterNameTh)).AsQueryable();

				if (!String.IsNullOrEmpty(condition.contractNo))
					queryMap = queryMap.Where(x => x.ContractId.Contains(condition.contractNo)).AsQueryable();

				if (!String.IsNullOrEmpty(condition.lgNumber))
					queryMap = queryMap.Where(x => x.LgNumber.Contains(condition.lgNumber)).AsQueryable();

				if (!String.IsNullOrEmpty(condition.DepartmentCode))
					queryMap = queryMap.Where(x => x.DepartmentCode.Contains(condition.DepartmentCode)).AsQueryable();
			}

			return queryMap;
		}

		public PaginationView<List<VGuaranteeLgContract>> GetTrackingSearchLG(int? page, int pageSize, SearchOptionLG condition = null)
		{
			IQueryable<VGuaranteeLgContract> queryMap = null;

			queryMap = this.GetListSearchLG(condition);

			var pager = new Pager(queryMap.Count(), page, pageSize, condition);

			var itemss = queryMap.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);

			var response = new PaginationView<List<VGuaranteeLgContract>>()
			{
				Items = itemss.ToList(),
				Pager = pager
			};

			return response;
		}

		public void Validate(TAllMasterVendorView indata)
		{
			//ข้อมูลหลักประกันสัญญา
			_repo.ContractShare.ValidateGuaranteeContract(indata);
		}

		public async Task<TAllMasterVendorView> UpdateReNewAsync(TAllMasterVendorView indata)
		{
			using (var _transaction = _repo.BeginTransaction())
			{
				var _ParameterCon = indata.ParameterCondition;

				await _repo.ContractShare.UpdateGuaranteeContract(indata);

				var contractStationGuarantees = _repo.Context.ContractStationGuarantees.FirstOrDefault(x => x.IdSmctMaster == _ParameterCon.IdSmctMaster);
				contractStationGuarantees.ContractGuaranteeType = SecurityRepo.Decrypt(indata.ParameterCondition.ContractGuaranteeTypeEn);
				contractStationGuarantees.ContractGuaranteeEditUser = _ParameterCon.IdUserSmctCurr;
				contractStationGuarantees.ContractGuaranteeEditDate = DateTime.Now;
				_db.Update(contractStationGuarantees);
				await _db.SaveAsync();

				_transaction.Commit();

				return indata;
			}
		}

		public async Task<TAllMasterVendorView> UpdateReturnAsync(TAllMasterVendorView indata)
		{
			using (var _transaction = _repo.BeginTransaction())
			{
				var _ParameterCon = indata.ParameterCondition;

				await _repo.ContractShare.UpdateGuaranteeContract(indata);

				var contractStationGuarantees = _repo.Context.ContractStationGuarantees.FirstOrDefault(x => x.IdSmctMaster == _ParameterCon.IdSmctMaster);
				contractStationGuarantees.ContractGuaranteeType = SecurityRepo.Decrypt(indata.ParameterCondition.ContractGuaranteeTypeEn);
				contractStationGuarantees.ContractGuaranteeEditUser = _ParameterCon.IdUserSmctCurr;
				contractStationGuarantees.ContractGuaranteeEditDate = DateTime.Now;
				_db.Update(contractStationGuarantees);
				await _db.SaveAsync();

				_transaction.Commit();

				return indata;
			}
		}

		public async Task<TAllMasterVendorView> UpdateClaimAsync(TAllMasterVendorView indata)
		{
			using (var _transaction = _repo.BeginTransaction())
			{
				var _ParameterCon = indata.ParameterCondition;

				await _repo.ContractShare.UpdateGuaranteeContract(indata);

				_transaction.Commit();

				return indata;
			}
		}

		public async Task<List<GuaranteeLgReqStationRpt>> GuaranteeLgReqStationRpt(SearchOptionGuarantee Condition = null)
		{
			List<GuaranteeLgReqStationRpt> response = new List<GuaranteeLgReqStationRpt>();

			string[] Dcodes = { "03000", "03100", "03200", "03300", "03400", "03500", "03600", "03700", "03800", "03900", "04000", "04100", "04200" };

			var _VGuaranteeLgContracts = _repo.Context.VGuaranteeLgContracts.Where(x => x.LgNumber != "");//NewCount=ออกใหม่
			var _GuaranteeLgReqStations = _repo.Context.GuaranteeLgReqStations.Where(x => x.Used);//ReturnCount=ขอคืน,ClaimCount=ขอเคลม,ReNewCount=ขอเพิ่ม,Discount=ขอลด

			if (Condition != null)
			{
				if (!String.IsNullOrEmpty(Condition.Year))
					_GuaranteeLgReqStations = _GuaranteeLgReqStations.Where(x => x.Budgetyear == Condition.Year);
				if (!String.IsNullOrEmpty(Condition.Month))
				{
					int _Month = int.Parse(Condition.Month);
					_GuaranteeLgReqStations = _GuaranteeLgReqStations.Where(x => x.ContractDate.Month == _Month);
				}
			}


			var LkDepartments = _repo.Context.LkDepartments.Where(x => x.Display == "Y" && x.Dcode != null && Dcodes.Contains(x.Dcode)).OrderBy(x => x.Dcode).ToList();
			foreach (var item in LkDepartments)
			{
				var queryCount1 = await _VGuaranteeLgContracts.Where(x => x.DepartmentCode == item.Dcode).GroupBy(s => s.DepartmentCode)
						.Select(grp => new
						{
							AppTypeId = grp.Key,
							AppTypeIdCount = grp.Count()
						}).ToListAsync();

				var queryCount2 = await _GuaranteeLgReqStations.Where(x => x.DepartmentCode == item.Dcode).GroupBy(s => s.AppTypeId)
						.Select(grp => new
						{
							AppTypeId = grp.Key,
							AppTypeIdCount = grp.Count()
						}).ToListAsync();

				//NewCount=ออกใหม่,ReturnCount=ขอคืน,ClaimCount=ขอเคลม,ReNewCount=ขอเพิ่ม,Discount=ขอลด
				response.Add(new Resources.ContractTypeBureau.GuaranteeLgReqStationRpt()
				{
					Dcode = item.Dcode,
					DnameNew = item.DnameNew,
					NewCount = queryCount1.FirstOrDefault(x => x.AppTypeId != "")?.AppTypeIdCount ?? 0,
					ReturnCount = queryCount2.FirstOrDefault(x => x.AppTypeId == "3")?.AppTypeIdCount ?? 0,
					ClaimCount = queryCount2.FirstOrDefault(x => x.AppTypeId == "4")?.AppTypeIdCount ?? 0,
					ReNewCount = queryCount2.FirstOrDefault(x => x.AppTypeId == "5")?.AppTypeIdCount ?? 0,
					DisCount = queryCount2.FirstOrDefault(x => x.AppTypeId == "6")?.AppTypeIdCount ?? 0
				});
			}

			return response;
		}


		public async Task<List<GuaranteeLgReqStationDashboard>> GuaranteeLgReqStationDashboard(SearchOptionGuarantee Condition = null)
		{
			List<GuaranteeLgReqStationDashboard> response = new List<GuaranteeLgReqStationDashboard>();

			string[] Dcodes = { "03000", "03100", "03200", "03300", "03400", "03500", "03600", "03700", "03800", "03900", "04000", "04100", "04200" };

			var _VGuaranteeLgContracts = _repo.Context.VGuaranteeLgContracts.Where(x => x.LgNumber != "");//NewCount=ออกใหม่
			var _GuaranteeLgReqStations = _repo.Context.GuaranteeLgReqStations.Where(x => x.Used);//ReturnCount=ขอคืน,ClaimCount=ขอเคลม,ReNewCount=ขอเพิ่ม,Discount=ขอลด

			//if (Condition != null)
			//{
			//	if (!String.IsNullOrEmpty(Condition.Year))
			//		_GuaranteeLgReqStations = _GuaranteeLgReqStations.Where(x => x.Budgetyear == Condition.Year);
			//	if (!String.IsNullOrEmpty(Condition.Month))
			//	{
			//		int _Month = int.Parse(Condition.Month);
			//		_GuaranteeLgReqStations = _GuaranteeLgReqStations.Where(x => x.ContractDate.Month == _Month);
			//	}
			//}


			var LkDepartments = _repo.Context.LkDepartments.Where(x => x.Display == "Y" && x.Dcode != null && Dcodes.Contains(x.Dcode)).OrderBy(x => x.Dcode).ToList();
			foreach (var item in LkDepartments)
			{
				//NewCount=ออกใหม่
				var queryCount1 = await _VGuaranteeLgContracts.Where(x => x.DepartmentCode == item.Dcode).GroupBy(s => s.DepartmentCode)
						.Select(grp => new
						{
							AppTypeId = grp.Key,
							AppTypeIdCount = grp.Count()
						}).ToListAsync();

				//ReturnCount=ขอคืน/ยกเลิก
				var queryCount2 = await _GuaranteeLgReqStations.Where(x => x.DepartmentCode == item.Dcode && x.AppTypeId == "3").GroupBy(s => s.LgStatus)
						.Select(grp => new
						{
							LgStatus = grp.Key,
							LgStatusCount = grp.Count()
						}).ToListAsync();

				//ClaimCount=ขอเคลม
				var queryCount3 = await _GuaranteeLgReqStations.Where(x => x.DepartmentCode == item.Dcode && x.AppTypeId == "4").GroupBy(s => s.LgStatus)
						.Select(grp => new
						{
							LgStatus = grp.Key,
							LgStatusCount = grp.Count()
						}).ToListAsync();

				//ReNewCount=ขอเพิ่ม
				var queryCount4 = await _GuaranteeLgReqStations.Where(x => x.DepartmentCode == item.Dcode && x.AppTypeId == "5").GroupBy(s => s.LgStatus)
						.Select(grp => new
						{
							LgStatus = grp.Key,
							LgStatusCount = grp.Count()
						}).ToListAsync();

				//Discount=ขอลด
				var queryCount5 = await _GuaranteeLgReqStations.Where(x => x.DepartmentCode == item.Dcode && x.AppTypeId == "6").GroupBy(s => s.LgStatus)
						.Select(grp => new
						{
							LgStatus = grp.Key,
							LgStatusCount = grp.Count()
						}).ToListAsync();

				response.Add(new Resources.ContractTypeBureau.GuaranteeLgReqStationDashboard()
				{
					Dcode = item.Dcode,
					DnameNew = item.DnameNew,

					NewCount1 = 0,
					NewCount2 = queryCount1.FirstOrDefault(x => x.AppTypeId != "")?.AppTypeIdCount ?? 0,
					NewCount3 = 0,
					NewCount4 = 0,

					ReturnCount1 = queryCount2.FirstOrDefault(x => x.LgStatus == "")?.LgStatusCount ?? 0,
					ReturnCount2 = queryCount2.FirstOrDefault(x => x.LgStatus != "")?.LgStatusCount ?? 0,
					ReturnCount3 = 0,
					ReturnCount4 = 0,

					ClaimCount1 = queryCount3.FirstOrDefault(x => x.LgStatus == "")?.LgStatusCount ?? 0,
					ClaimCount2 = queryCount3.FirstOrDefault(x => x.LgStatus != "")?.LgStatusCount ?? 0,
					ClaimCount3 = 0,
					ClaimCount4 = 0,

					ReNewCount1 = queryCount4.FirstOrDefault(x => x.LgStatus == "")?.LgStatusCount ?? 0,
					ReNewCount2 = queryCount4.FirstOrDefault(x => x.LgStatus != "")?.LgStatusCount ?? 0,
					ReNewCount3 = 0,
					ReNewCount4 = 0,

					DisCount1 = queryCount4.FirstOrDefault(x => x.LgStatus == "")?.LgStatusCount ?? 0,
					DisCount2 = queryCount4.FirstOrDefault(x => x.LgStatus != "")?.LgStatusCount ?? 0,
					DisCount3 = 0,
					DisCount4 = 0
				});
			}

			return response;
		}

	}
}
