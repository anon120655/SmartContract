using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MimeKit;
using SmartContract.Infrastructure.Data.EntityFramework;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Interfaces;
using SmartContract.Infrastructure.Interfaces.Share;
using SmartContract.Infrastructure.Resources.Authenticate;
using SmartContract.Infrastructure.Resources.ContractTypeBureau.Information;
using SmartContract.Infrastructure.Resources.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Enum;
using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Infrastructure.Resources.Share.ServiceOther;
using SmartContract.Infrastructure.Wrapper;
using SmartContract.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Repositorys.Share
{
	public class ContractShareNhso : IContractShareNhso
	{
		private IRepositoryWrapper _repo;
		private readonly IMapper _mapper;
		private readonly IRepositoryBase _db;
		private readonly AppSettings _mySet;
		private readonly IWebHostEnvironment _env;

		public ContractShareNhso(IRepositoryWrapper repo, IRepositoryBase db, IMapper mapper, IWebHostEnvironment env, IOptions<AppSettings> settings)
		{
			_repo = repo;
			_db = db;
			_env = env;
			_mapper = mapper;
			_mySet = settings.Value;
		}

		public string SetUrlRedirectReqApprove(TAllMasterVendorView indata)
		{
			String UrlRedirect = String.Empty;

			int btnSubmit = int.Parse(indata.BtnSubmit);
			if (btnSubmit == (int)ButtonState.Draft)
			{
				UrlRedirect = $"{_mySet.SubDomainServer}/ContractType/T{indata.ParameterCondition.ContractTypeId}?style={indata.ParameterCondition.Style}";
				if (!String.IsNullOrEmpty(indata.ParameterCondition.Station))
				{
					UrlRedirect = $"{UrlRedirect}&Station={indata.ParameterCondition.Station}";
				}
				if (!String.IsNullOrEmpty(indata.ParameterCondition.StationReq))
				{
					UrlRedirect = $"{UrlRedirect}&StationReq={indata.ParameterCondition.StationReq}";
				}
				if (!String.IsNullOrEmpty(indata.ParameterCondition.IdSmctMaster))
				{
					UrlRedirect = $"{UrlRedirect}&IdSmctMaster={indata.ParameterCondition.IdSmctMaster}";
					indata.ObjectState = TObjectState.Update;
				}
				if (!String.IsNullOrEmpty(indata.ParameterCondition.SigningTypeEn))
				{
					UrlRedirect = $"{UrlRedirect}&SigningTypeEn={indata.ParameterCondition.SigningTypeEn}";
				}
				if (!String.IsNullOrEmpty(indata.ParameterCondition.ContractTypeIdEn))
				{
					UrlRedirect = $"{UrlRedirect}&ContractTypeIdEn={indata.ParameterCondition.ContractTypeIdEn}";
				}
			}
			else if (btnSubmit == (int)ButtonState.Forward)
			{
				if (indata.ParameterCondition.StationReq == ApproveStationStatusAll.S2CreateApprove || indata.ParameterCondition.StationReq == ApproveStationStatusAll.S3Consider)
				{
					UrlRedirect = $"{_mySet.SubDomainServer}/home/indexproposal";
				}
			}
			else
			{
				UrlRedirect = $"{_mySet.SubDomainServer}/home/indexproposal";
			}

			return UrlRedirect;
		}

		public string SetUrlRedirectContract(TAllMasterVendorView indata)
		{
			String UrlRedirect = String.Empty;

			int btnSubmit = int.Parse(indata.BtnSubmit);
			bool IsUrlOld = true;
			if (btnSubmit == (int)ButtonState.Draft || btnSubmit == (int)ButtonState.SignerAttachFile || btnSubmit == (int)ButtonState.SignerWitness || btnSubmit == (int)ButtonState.Signer)
			{
				if (btnSubmit == (int)ButtonState.SignerAttachFile || btnSubmit == (int)ButtonState.Signer)
				{
					indata.ParameterCondition.IsShowSign = true;
				}

				if (IsUrlOld)
				{
					indata.ParameterCondition.ContractTypeId = indata.ParameterCondition.ContractTypeId.Replace("T", String.Empty).Replace("C", String.Empty);
					UrlRedirect = $"{_mySet.SubDomainServer}/ContractType/T{indata.ParameterCondition.ContractTypeId}C?style={indata.ParameterCondition.Style}";
					if (!String.IsNullOrEmpty(indata.ParameterCondition.SigningTypeEn))
					{
						UrlRedirect = $"{UrlRedirect}&SigningTypeEn={indata.ParameterCondition.SigningTypeEn}";
					}
					if (!String.IsNullOrEmpty(indata.ParameterCondition.IdSmctMaster))
					{
						UrlRedirect = $"{UrlRedirect}&IdSmctMaster={indata.ParameterCondition.IdSmctMaster}";
						indata.ObjectState = TObjectState.Update;
					}
					if (!String.IsNullOrEmpty(indata.ParameterCondition.SigningTypeEn))
					{
						UrlRedirect = $"{UrlRedirect}&SigningTypeEn={indata.ParameterCondition.SigningTypeEn}";
					}
					if (!String.IsNullOrEmpty(indata.ParameterCondition.Station))
					{
						UrlRedirect = $"{UrlRedirect}&Station={indata.ParameterCondition.Station}";
					}
					if (!String.IsNullOrEmpty(indata.ParameterCondition.ContractTypeIdEn))
					{
						UrlRedirect = $"{UrlRedirect}&ContractTypeIdEn={indata.ParameterCondition.ContractTypeIdEn}";
					}
					UrlRedirect = $"{UrlRedirect}&IsShowSign={indata.ParameterCondition.IsShowSign}";
				}
			}
			else if (btnSubmit == (int)ButtonState.Forward)
			{
				if (indata.ParameterCondition.Station == ContractStationStatusAll.S1Draft
					|| indata.ParameterCondition.Station == ContractStationStatusAll.S4CreateContract
					|| indata.ParameterCondition.Station == ContractStationStatusAll.S5Signing2
					|| indata.ParameterCondition.Station == ContractStationStatusAll.S6ContractNumber)
				{
					UrlRedirect = $"{_mySet.SubDomainServer}/home/index";
				}
			}
			else if (btnSubmit == (int)ButtonState.T1_EDIT || btnSubmit == (int)ButtonState.T2_CANCEL
					|| btnSubmit == (int)ButtonState.T3_EXPAND
					|| btnSubmit == (int)ButtonState.T4_CLOSEPROJECT
					|| btnSubmit == (int)ButtonState.T5_TERMINATE)
			{
				UrlRedirect = $"{_mySet.SubDomainServer}/home/IndexBinding?Menuen={indata.ParameterCondition.MenuEn}";
				if (!String.IsNullOrEmpty(indata.ParameterCondition.StationEn))
				{
					UrlRedirect = $"{UrlRedirect}&StationEn={indata.ParameterCondition.StationEn}";
				}
			}
			else
			{
				UrlRedirect = $"{_mySet.SubDomainServer}/home/index";
			}

			return UrlRedirect;
		}

		//VAlIDATE
		public void ValidateConditionPayment(TAllMasterVendorView indata)
		{
			//เงื่อนไขการจ่ายเงิน
			if (String.IsNullOrEmpty(indata.InfoConditionPayment.PeriodType))
				throw new Exception("ระบุ เงื่อนไขการจ่ายเงิน");

			if (indata.InfoConditionPayment.PeriodType == PeriodTypes.PayOne100)
			{
				if (indata.InfoConditionPayment.P1Budgetcode != null && indata.InfoConditionPayment.P1Budgetcode.Count > 0)
				{
					foreach (var item in indata.InfoConditionPayment.P1Budgetcode)
					{
						if (item.PeriodPercent == null || item.PeriodPercent.Value == 0)
							throw new Exception("ระบุ ระบุยอดเงินแต่ละรหัสไม่ครบ");
					}
				}

				if (string.IsNullOrEmpty(indata.InfoConditionPayment.PeriodP1Detail))
					throw new Exception("ระบุ จ่ายงวดเดียว 100% เนื่องจาก");
				if (string.IsNullOrEmpty(indata.InfoConditionPayment.ContractPeriodDetail1))
					throw new Exception("ระบุ ผลการดำเนินงานที่ส่งมอบ");
			}
			else if (indata.InfoConditionPayment.PeriodType == PeriodTypes.PayOneMutiRow)
			{
				if (string.IsNullOrEmpty(indata.InfoConditionPayment.PaymentSelect))
					throw new Exception("ระบุ แบ่งจ่ายเงินเป็นจำนวน");

				if (indata.InfoConditionPayment.PeriodList != null && indata.InfoConditionPayment.PeriodList.Count > 0)
				{
					decimal PeriodPercentSum = 0;
					foreach (var item in indata.InfoConditionPayment.PeriodList)
					{
						if (item.ContractPeriod != null && item.ContractPeriod.Count > 0)
						{
							//คงเหลือรหัสงบ>=Sumจำนวนเงินในงวดรายรหัสงบ
							var toLookBudgetCode = item.ContractPeriod.ToLookup(x=>x.PeriodBudgetcode);
							//คงเหลือรหัสงบ>=Sumจำนวนเงินในงวดรายรหัสงบ
							foreach (var itemCode in toLookBudgetCode)
							{
								var budgetcodeViews = _repo.Context.BudgetcodeViews.FirstOrDefault(x => x.Budgetcode == itemCode.Key);
								if (budgetcodeViews != null)
								{
									var SubBudgetPerPeriod = item.ContractPeriod.Where(x => x.PeriodBudgetcode == itemCode.Key).Sum(x => x.PeriodPercent);
									if (SubBudgetPerPeriod > budgetcodeViews.Remain)
									{
										throw new Exception($"เงินคงเหลือรหัสงบ {itemCode.Key} ไม่พอ");
									}
								}
							}							

							foreach (var itemPeriod in item.ContractPeriod)
							{
								if (string.IsNullOrEmpty(itemPeriod.PeriodBudgetcode))
									throw new Exception($"ระบุ รหัสงบประมาณงวดที่ {item.PeriodNo} ไม่ครบถ้วน");
								if (itemPeriod.PeriodPercent == null || itemPeriod.PeriodPercent.Value == 0)
									throw new Exception($"ระบุ วงเงินในงวดที่ {item.PeriodNo} ไม่ครบถ้วน");
								if (string.IsNullOrEmpty(itemPeriod.PeriodVendorId))
									throw new Exception($"ระบุ รหัสคู่สัญญางวดที่ {item.PeriodNo} ไม่ครบถ้วน");

								PeriodPercentSum += itemPeriod.PeriodPercent.Value;




							}
						}
						else
							throw new Exception($"ระบุ ข้อมูลงวดที่ {item.PeriodNo} ไม่ครบถ้วน");
						if (item.ContractPeriodDetail != null && item.ContractPeriodDetail.Count > 0)
						{
							foreach (var itemPeriodDetail in item.ContractPeriodDetail)
							{
								if (string.IsNullOrEmpty(itemPeriodDetail.ContractPeriodDetail1))
									throw new Exception($"ระบุ ผลการดำเนินงานที่ส่งมอบงวดที่ {item.PeriodNo} ไม่ครบถ้วน");
							}
						}
						else
							throw new Exception("ระบุ ผลการดำเนินงานที่ส่งมอบ");
					}

					if (PeriodPercentSum != indata.InfoContract.Budget)
					{
						throw new Exception("ยอดรวมงวดต้องเท่ากับวงเงินในสัญญา");
					}

				}
				else
				{
					throw new Exception("ระบุ ข้อมูลรายงวด");
				}

			}
		}

		public void ValidateEXPAND(TAllMasterVendorView indata)
		{
			if (string.IsNullOrEmpty(indata.InfoContract.StartDateStr))
				throw new Exception("ระบุ วันที่เริ่มต้นสัญญา");
			if (string.IsNullOrEmpty(indata.InfoContract.EndDateStr))
				throw new Exception("ระบุ วันที่สิ้นสุดสัญญา");

			var contractTypes = _repo.Context.ContractTypes.FirstOrDefault(x => x.ContractTypeId == indata.ParameterCondition.ContractTypeId);
			if (contractTypes != null)
			{
				if (contractTypes.FPay)
				{
					_repo.ContractShareNhso.ValidateConditionPayment(indata);
				}
			}
		}

		//VIEW
		public async Task<TAllMasterVendorView> ViewInfoContract(TAllMasterVendorView indata)
		{
			string idSmctMaster = indata.ParameterCondition.IdSmctMaster;
			if (indata.ParameterCondition.DepartmentCodeCurr == null)
				indata.ParameterCondition.DepartmentCodeCurr = _repo.UserService.GetDepartmentCode();

			if (indata.ParameterCondition.IdUserSmctCurr == null)
				indata.ParameterCondition.IdUserSmctCurr = _repo.UserService.GetIdUserSmct();

			if (indata.ParameterCondition.VendorIdCurr == null)
				indata.ParameterCondition.VendorIdCurr = _repo.UserService.GetVendorId();

			var indataPara = indata.ParameterCondition;

			String _ContractTypeId = null;
			if (indataPara.ContractTypeIdEn != null)
				_ContractTypeId = SecurityRepo.Decrypt(indataPara.ContractTypeIdEn);

			var lkDepartments = await _repo.Context.LkDepartments.FirstOrDefaultAsync(x => x.Dcode == indataPara.DepartmentCodeCurr);
			if (lkDepartments == null)
				throw new Exception($"ไม่พบสำนักงาน");

			var contractStyles = await _repo.Context.ContractStyles.FirstOrDefaultAsync(x => x.ContractStyleCode == indataPara.Style);
			if (contractStyles == null)
				throw new Exception($"ไม่พบรูปแบบนิติกรรมสัญญา {indata.ParameterCondition.Style}");

			var contractTypes = await _repo.Context.ContractTypes.FirstOrDefaultAsync(x => x.IdContractStyle == contractStyles.IdContractStyle && x.ContractTypeId == _ContractTypeId);
			if (contractTypes == null)
				throw new Exception($"ไม่พบประเภทนิติกรรมสัญญา");

			indata.InfoContract.BureauSubFundCounty = $"{lkDepartments.Dname} ({lkDepartments.Dcode})";
			indata.InfoContract.ContractTypeFullName = contractTypes.ContractTypeFullName;
			indata.ParameterCondition.ContractTypeFullName = contractTypes.ContractTypeFullName;
			indata.ParameterCondition.ContractTypeId = contractTypes.ContractTypeId;
			indata.ParameterCondition.IdContractType = contractTypes.IdContractType;

			if (!String.IsNullOrEmpty(indata.ParameterCondition.SigningTypeEn))
			{
				var _SigningType = SecurityRepo.Decrypt(indata.ParameterCondition.SigningTypeEn);
				indata.InfoContract.SigningType = ContractUtils.SigningTypes(_SigningType).Description;
				indata.ParameterCondition.SigningType = _SigningType;
			}


			var smctMasters = await _repo.Context.SmctMasters.Where(x => x.IdSmctMaster == idSmctMaster && x.Used).FirstOrDefaultAsync();
			indata.ParameterCondition.IdSmctMaster = smctMasters.IdSmctMaster;
			indata.InfoContract.RefId = smctMasters.RefId;
			indata.InfoContract.RefDate = smctMasters.RefDate;

			var _Contracts = await _repo.Context.Contracts.Where(x => x.IdSmctMaster == idSmctMaster && x.Used).FirstOrDefaultAsync();
			if (_Contracts != null)
			{
				indata.ParameterCondition.ContractName = _Contracts.ContractName;
				indata.ParameterCondition.IdContract = _Contracts.IdContract;
				indata.ParameterCondition.IdContractType = _Contracts.IdContractType;
				indata.InfoContract.ContractId = _Contracts.ContractId;
				indata.InfoContract.ContractDate = _Contracts.ContractDate;
				indata.InfoContract.ContractDateStr = GeneralUtils.DateToThString(_Contracts.ContractDate);
				indata.InfoContract.PayVendorTypeD = _Contracts.PayVendorType == "D";
				indata.InfoContract.PayVendorTypeI = _Contracts.PayVendorType == "I";
				indata.InfoContract.Budget = _Contracts.Budget;
				indata.InfoContract.StartDateStr = GeneralUtils.DateToThString(_Contracts.StartDate);
				indata.InfoContract.EndDateStr = GeneralUtils.DateToThString(_Contracts.EndDate);
				indata.InfoContract.StartDate = _Contracts.StartDate;
				indata.InfoContract.EndDate = _Contracts.EndDate;
				indata.InfoContract.GuaranteeDay = _Contracts.GuaranteeDay != 0 ? _Contracts.GuaranteeDay.ToString() : String.Empty;

				var _ContractPlans = await _repo.Context.ContractPlans.Where(x => x.IdContract == _Contracts.IdContract && x.Used).OrderBy(x => x.Planno).ToListAsync();
				if (_ContractPlans.Count > 0)
				{
					foreach (var item in _ContractPlans)
						indata.InfoContract.Budgetcodes.Add(new BudgetcodeViewDTO() { Budgetcode = item.Budgetcode });
				}
			}


			//var _EcContractVendorOwners = await _repo.ContextEb.EcContractVendorOwners.ToListAsync();


			return indata;
		}

		public async Task<TAllMasterVendorView> ViewRequestForApproval(TAllMasterVendorView indata)
		{
			string idSmctMaster = indata.ParameterCondition.IdSmctMaster;

			var approvalReqs = await _repo.Context.ApprovalReqs.Where(x => x.IdSmctMaster == idSmctMaster && x.Used).FirstOrDefaultAsync();
			if (approvalReqs != null)
			{
				indata.InfoRequestForApproval.ContractName = approvalReqs.ContractName;
				indata.InfoRequestForApproval.Reason = approvalReqs.Reason;
				indata.InfoRequestForApproval.CoordinatorUserSelect = approvalReqs.CoordinatorUser;
				indata.InfoRequestForApproval.Email = approvalReqs.Email;
				indata.InfoRequestForApproval.Phone = approvalReqs.Phone;
				indata.InfoRequestForApproval.Fax = approvalReqs.Fax;
				indata.InfoRequestForApproval.ApprovalReqId = approvalReqs.ApprovalReqId;
				indata.InfoRequestForApproval.ApprovalReqDate = approvalReqs.ApprovalReqDate;

				indata.InfoRequestForApproval.ApprovalReqUserChairm = approvalReqs.Chairman;
				indata.InfoRequestForApproval.ApprovalReqUser = approvalReqs.ApprovalReqUser;
				indata.InfoRequestForApproval.ApprovalReqUserPos = approvalReqs.ApprovalReqUserPos;

				if (!String.IsNullOrEmpty(approvalReqs.Board1))
					indata.InfoRequestForApproval.Committees.Add(new VNhsoBoradDTO() { EmpId = approvalReqs.Board1 });
				if (!String.IsNullOrEmpty(approvalReqs.Board2))
					indata.InfoRequestForApproval.Committees.Add(new VNhsoBoradDTO() { EmpId = approvalReqs.Board2 });
				if (!String.IsNullOrEmpty(approvalReqs.Board3))
					indata.InfoRequestForApproval.Committees.Add(new VNhsoBoradDTO() { EmpId = approvalReqs.Board3 });
				if (!String.IsNullOrEmpty(approvalReqs.Board4))
					indata.InfoRequestForApproval.Committees.Add(new VNhsoBoradDTO() { EmpId = approvalReqs.Board4 });
				if (!String.IsNullOrEmpty(approvalReqs.Board5))
					indata.InfoRequestForApproval.Committees.Add(new VNhsoBoradDTO() { EmpId = approvalReqs.Board5 });
			}
			return indata;
		}

		public async Task<TAllMasterVendorView> ViewMasterSignerNhso(TAllMasterVendorView indata)
		{
			string idSmctMaster = indata.ParameterCondition.IdSmctMaster;
			var indataPara = indata.ParameterCondition;

			indata.InfoContractNhso.NhsoAddress = await _repo.Context.VNhsoDepartmentAddresses.FirstOrDefaultAsync(x => x.Dcode == indataPara.DepartmentCodeCurr);

			var smctMasterSigners = await _repo.Context.SmctMasterSigners.FirstOrDefaultAsync(x => x.IdSmctMaster == idSmctMaster && x.Used);
			if (smctMasterSigners != null)
			{
				var smctMasterSignerDetail1s = await _repo.Context.SmctMasterSignerDetail1s.FirstOrDefaultAsync(x => x.IdSmctMasterSigner == smctMasterSigners.IdSmctMasterSigner && x.Used);
				if (smctMasterSignerDetail1s != null)
				{
					indata.InfoContractNhso.EmpId = smctMasterSignerDetail1s.NhsoSignerUser;
					indata.InfoContractNhso.NhsoContractId = smctMasterSignerDetail1s.NhsoContractId;
					indata.InfoContractNhso.NhsoContractDateStr = GeneralUtils.DateToThString(smctMasterSignerDetail1s.NhsoContractDate);
					indata.InfoContractNhso.NhsoWitnessStatus = smctMasterSignerDetail1s.NhsoWitnessStatus;
					indata.InfoContractNhso.VendorWitnessStatus = smctMasterSignerDetail1s.VendorWitnessStatus;
					var nhsoSigners = _repo.Context.VNhsoSigners.FirstOrDefault(x => x.DepartmentCode != null && x.EmpId == smctMasterSignerDetail1s.NhsoSignerUser);
					if (nhsoSigners != null)
					{
						indata.InfoContractNhso.SignerPosition = nhsoSigners.SignerPosition;
						indata.InfoContractNhso.SignerEmail = nhsoSigners.SignerEmail;
					}
				}
			}
			return indata;
		}

		public async Task<TAllMasterVendorView> ViewConditionPayment(TAllMasterVendorView indata)
		{
			string idSmctMaster = indata.ParameterCondition.IdSmctMaster;

			var _Contract = await _repo.Context.Contracts.Where(x => x.IdSmctMaster == idSmctMaster && x.Used).FirstOrDefaultAsync();
			if (_Contract != null)
			{
				indata.ParameterCondition.IdContract = _Contract.IdContract;
				//วงเงินทั้งหมด tab เงื่อนไขการจ่ายเงิน
				indata.InfoConditionPayment.PeriodPercent = _Contract.Budget;

				var periodType = await _repo.Context.ContractPeriods.FirstOrDefaultAsync(x => x.IdContract == _Contract.IdContract && x.Used);
				if (periodType != null)
				{
					indata.InfoConditionPayment.PeriodType = periodType.PeriodType;
					if (periodType.PeriodType == PeriodTypes.PayMutiToN)
						indata.InfoConditionPayment.PeriodType = PeriodTypes.PayOneMutiRow;

					var contractPeriodNo = await _repo.Context.ContractPeriods.Where(x => x.IdContract == _Contract.IdContract && x.Used)
																		   .GroupBy(b => b.PeriodNo)
																		   .Select(x => x.Key)
																		   .ToListAsync();

					indata.InfoConditionPayment.PaymentSelect = contractPeriodNo.Count().ToString();
					foreach (var item_period in contractPeriodNo)
					{
						var contractPeriods = await _repo.Context.ContractPeriods.Where(x => x.PeriodNo == item_period && x.IdContract == _Contract.IdContract && x.Used).OrderBy(x => x.EditDate).ToListAsync();
						var contractPeriodDetail = await _repo.Context.ContractPeriodDetails.Where(x => x.PeriodNo == item_period && x.IdContract == _Contract.IdContract && x.Used).OrderBy(x => x.ContractPeriodDetailNo).ToListAsync();

						if (indata.InfoConditionPayment.PeriodType == PeriodTypes.PayOne100)
						{
							indata.InfoConditionPayment.PeriodP1Detail = contractPeriods.FirstOrDefault()?.PeriodP1Detail ?? String.Empty;
							indata.InfoConditionPayment.ContractPeriodDetail1 = contractPeriodDetail.FirstOrDefault()?.ContractPeriodDetail1 ?? String.Empty;
							foreach (var item in contractPeriods)
							{
								ContractPeriodDTO Period = new ContractPeriodDTO();
								Period = _mapper.Map<ContractPeriodDTO>(item);
								Period.PeriodVendorName = indata.CTVendor.GetLookUp.MasterVendors.FirstOrDefault(x => x.VendorId == item.PeriodVendorId)?.VendorName ?? String.Empty;
								indata.InfoConditionPayment.P1Budgetcode.Add(Period);
							}
						}
						else
						{
							List<ContractPeriodDTO> ContractPeriodList = new List<ContractPeriodDTO>();
							foreach (var item in contractPeriods)
							{
								ContractPeriodDTO Period = new ContractPeriodDTO();
								Period = _mapper.Map<ContractPeriodDTO>(item);
								Period.PeriodVendorName = indata.CTVendor.GetLookUp.MasterVendors.FirstOrDefault(x => x.VendorId == item.PeriodVendorId)?.VendorName ?? String.Empty;
								ContractPeriodList.Add(Period);
							}
							indata.InfoConditionPayment.PeriodList.Add(new PeriodModel()
							{
								PeriodNo = item_period,
								ContractPeriod = ContractPeriodList,
								ContractPeriodDetail = _mapper.Map<List<ContractPeriodDetailDTO>>(contractPeriodDetail)
							});
						}
					}
				}

			}
			return indata;
		}

		//UPDATE RequestApprove
		public async Task UpdateReqAppContractBudgetCode(TAllMasterVendorView indata)
		{
			String idSmctMaster = indata.ParameterCondition.IdSmctMaster;
			String idUserSmct = _repo.UserService.GetIdUserSmct();
			String departmentCode = _repo.UserService.GetDepartmentCode();

			var _Contract = _repo.Context.Contracts.FirstOrDefault(x => x.IdSmctMaster == idSmctMaster);
			_Contract.PayVendorType = indata.InfoContract.PayVendorTypeD ? "D" : "I";
			_Contract.Budget = indata.InfoContract.Budget;
			_Contract.StartDate = GeneralUtils.DateTimeToEn(indata.InfoContract.StartDateStr);

			var _EndDate = GeneralUtils.DateTimeToEn(indata.InfoContract.EndDateStr);
			if (_EndDate.HasValue)
			{
				DateTime _EndDateCheck = new DateTime(_EndDate.Value.Year, 8, 31);
				int result = DateTime.Compare(_EndDate.Value, _EndDateCheck);
				if (result > 0)
				{
					throw new Exception("ระบุ วันที่สิ้นสุดสัญญา ต้องไม่เกิน 31/08/256X");
				}
			}

			_Contract.EndDate = GeneralUtils.DateTimeToEn(indata.InfoContract.EndDateStr);

			_Contract.GuaranteeDay = int.Parse(indata.InfoContract.GuaranteeDay);
			_Contract.EditUser = idUserSmct;
			_Contract.EditDate = DateTime.Now;
			_db.Update(_Contract);
			await _db.SaveAsync();


			var contractPlansRemove = await _repo.Context.ContractPlans.Where(x => x.IdContract == _Contract.IdContract).ToListAsync();
			if (contractPlansRemove.Count > 0)
			{
				_db.DeleteRange(contractPlansRemove);
				await _repo.SaveAsync();
			}
			if (indata.InfoContract.Budgetcodes != null && indata.InfoContract.Budgetcodes.Count > 0)
			{
				int indexPlanNo = 1;
				foreach (var item in indata.InfoContract.Budgetcodes)
				{
					if (!String.IsNullOrEmpty(item.Budgetcode))
					{
						decimal _Budget = 0;
						var budgetcodeViews = _repo.Context.BudgetcodeViews.FirstOrDefault(x => x.Budgetcode == item.Budgetcode);
						if (budgetcodeViews != null) _Budget = budgetcodeViews?.Remain ?? 0;

						var contractPlan = new ContractPlan()
						{
							IdContract = _Contract.IdContract,
							Budgetcode = item.Budgetcode,
							Budget = _Budget,
							CreateUser = idUserSmct,
							EditUser = idUserSmct,
							CreateDate = DateTime.Now,
							EditDate = DateTime.Now,
							Used = true,
							Planno = indexPlanNo++
						};
						await _db.InsterAsync(contractPlan);
						await _db.SaveAsync();
					}
				}
			}
		}

		public async Task UpdateReqAppAttachDraftContract(TAllMasterVendorView indata, string ContractTypeId)
		{
			var _ParameterCon = indata.ParameterCondition;
			String idSmctMaster = indata.ParameterCondition.IdSmctMaster;
			String idUserSmct = _repo.UserService.GetIdUserSmct();

			var smctMasterFileRemove = _repo.Context.SmctMasterFiles.Where(x => x.IdSmctMaster == idSmctMaster && x.FileType == "F2").ToList();
			if (indata.InfoAttachDraftContractAppReq != null && indata.InfoAttachDraftContractAppReq.SmctMasterFile != null && indata.InfoAttachDraftContractAppReq.SmctMasterFile.Count > 0)
			{
				smctMasterFileRemove = smctMasterFileRemove.Where(x => !indata.InfoAttachDraftContractAppReq.SmctMasterFile.Select(r => r.IdSmctMasterFile).Contains(x.IdSmctMasterFile)).ToList();
			}
			if (smctMasterFileRemove.Count > 0)
			{
				_db.DeleteRange(smctMasterFileRemove);
				await _repo.SaveAsync();
			}
			if (indata.InfoAttachDraftContractAppReq != null && indata.InfoAttachDraftContractAppReq.SmctMasterFile != null && indata.InfoAttachDraftContractAppReq.SmctMasterFile.Count > 0)
			{
				int index_file = 0;
				foreach (var item in indata.InfoAttachDraftContractAppReq.SmctMasterFile)
				{
					index_file++;

					var fileFTP = _repo.UploadFiles.GenFileName(item.FormFile, _ParameterCon.RefId, $"FILE_{ContractTypeId}_F2_{index_file}");
					String thaiYear = GeneralUtils.getThaiYear(DateTime.Now.Year);

					var smctMasterFile = _repo.Context.SmctMasterFiles.FirstOrDefault(x => x.IdSmctMaster == idSmctMaster && x.IdSmctMasterFile == item.IdSmctMasterFile);
					if (smctMasterFile != null)
					{
						smctMasterFile.FileNo = index_file;
						smctMasterFile.EditUser = idUserSmct;
						smctMasterFile.EditDate = DateTime.Now;
						smctMasterFile.PathFolder = thaiYear;
						_db.Update(smctMasterFile);
						await _db.SaveAsync();
					}
					else
					{
						smctMasterFile = new SmctMasterFile()
						{
							IdSmctMaster = idSmctMaster,
							FileType = "F2",
							FileName = item.FormFile.FileName,
							FileFtp = fileFTP,
							CreateUser = idUserSmct,
							EditUser = idUserSmct,
							CreateDate = DateTime.Now,
							EditDate = DateTime.Now,
							FileNo = index_file,
							Used = true,
							PathFolder = thaiYear
						};
						await _db.InsterAsync(smctMasterFile);
						await _db.SaveAsync();
					}

					if (item.FormFile != null)
					{
						String PathFolder = $"Attach/{ContractTypeId}/{thaiYear}"; ;
						this.HandleUploadfile(item.FormFile, fileFTP, PathFolder);
					}

				}
			}
		}

		public async Task UpdateReqAppChairmanBoard(TAllMasterVendorView indata)
		{
			String idSmctMaster = indata.ParameterCondition.IdSmctMaster;
			String idUserSmct = _repo.UserService.GetIdUserSmct();

			var approvalReq = await _repo.Context.ApprovalReqs.FirstOrDefaultAsync(x => x.IdSmctMaster == idSmctMaster);

			approvalReq.Chairman = indata.InfoRequestForApproval.ApprovalReqUserChairm;

			approvalReq.Board1 = null;
			approvalReq.Board2 = null;
			approvalReq.Board3 = null;
			approvalReq.Board4 = null;
			approvalReq.Board5 = null;
			int index_footNotes = 0;
			foreach (var item in indata.InfoRequestForApproval.Committees)
			{
				if (index_footNotes == 0)
					approvalReq.Board1 = item.EmpId;
				if (index_footNotes == 1)
					approvalReq.Board2 = item.EmpId;
				if (index_footNotes == 2)
					approvalReq.Board3 = item.EmpId;
				if (index_footNotes == 3)
					approvalReq.Board4 = item.EmpId;
				if (index_footNotes == 4)
					approvalReq.Board5 = item.EmpId;

				index_footNotes++;
			}
			approvalReq.ApprovalReqUser = indata.InfoRequestForApproval.ApprovalReqUser;
			approvalReq.ApprovalReqUserPos = indata.InfoRequestForApproval.ApprovalReqUserPos;

			approvalReq.EditUser = idUserSmct;
			approvalReq.EditDate = DateTime.Now;
			_db.Update(approvalReq);
			await _db.SaveAsync();
		}

		public async Task UpdateStatusBookReqMailStatus(TAllMasterVendorView indata, bool? IsSuccess = null)
		{
			String idSmctMaster = indata.ParameterCondition.IdSmctMaster;
			String idUserSmct = _repo.UserService.GetIdUserSmct();
			var approvalReq = await _repo.Context.ApprovalReqs.FirstOrDefaultAsync(x => x.IdSmctMaster == idSmctMaster);
			var approvalReqStations = await _repo.Context.ApprovalReqStations.FirstOrDefaultAsync(x => x.IdSmctMaster == idSmctMaster);

			if (approvalReqStations.StationStatusCurr == ApproveStationStatusAll.S2CreateApprove)
			{
				approvalReq.StatusCheckMail = StatusCheckMails.M11SentMail;
				if (IsSuccess.HasValue && IsSuccess.Value)
				{
					approvalReq.StatusCheckMail = StatusCheckMails.M12SentMail;
				}
			}

			if (approvalReqStations.StationStatusCurr == ApproveStationStatusAll.S3Consider)
			{
				approvalReq.StatusCheckMail = StatusCheckMails.M21SentMail;
				if (IsSuccess.HasValue && IsSuccess.Value)
				{
					approvalReq.StatusCheckMail = StatusCheckMails.M22SentMail;
				}
			}

			approvalReq.EditUser = idUserSmct;
			approvalReq.EditDate = DateTime.Now;
			_db.Update(approvalReq);
			await _db.SaveAsync();
		}

		public async Task UpdateStatusBookReq(TAllMasterVendorView indata)
		{
			String idSmctMaster = indata.ParameterCondition.IdSmctMaster;

			if (indata.ParameterCondition.StationReq == ApproveStationStatusAll.S2CreateApprove)
			{

				if (!indata.ApproveProposal.Approve && !indata.ApproveProposal.UnApprove)
					throw new Exception("ระบุผลการตรวจสอบ");
				if (indata.ApproveProposal.UnApprove)
					if (String.IsNullOrEmpty(indata.ApproveProposal.Remark))
						throw new Exception("ระบุรายละเอียดหมายเหตุ");
			}
			if (indata.ParameterCondition.StationReq == ApproveStationStatusAll.S3Consider)
			{

				if (!indata.ApproveReq.Approve && !indata.ApproveReq.UnApprove && !indata.ApproveReq.UnApproveCheck)
					throw new Exception("ระบุผลการตรวจสอบ");
				if (indata.ApproveReq.UnApprove || indata.ApproveReq.UnApproveCheck)
					if (String.IsNullOrEmpty(indata.ApproveReq.Remark))
						throw new Exception("ระบุรายละเอียดหมายเหตุ");
				if (String.IsNullOrEmpty(indata.ApproveProposal.UserNameCA))
					throw new Exception("ระบุ Username NHSO CA Gateway");
				if (String.IsNullOrEmpty(indata.ApproveProposal.PasswordCA))
					throw new Exception("ระบุ Password NHSO CA Gateway");
			}

			//เจ้าหน้าที่ตรวจสอบ
			if (indata.ParameterCondition.StationReq == ApproveStationStatusAll.S2CreateApprove)
			{
				if (indata.ApproveProposal.Approve)
				{
					await _repo.ContractShare.UpdateStatusApproveReq(new ParameterStatusStation()
					{
						IdSmctMaster = idSmctMaster,
						Status = ApprovalReqStatus.S1WaitApprove,
						StationStatusCurr = ApproveStationStatusAll.S3Consider,
						ItemStatusCurr = ApproveStationStatusItemAll.S31WaitApproval
					});
					await _repo.ContractShare.UpdateStatusContract(new ParameterStatusStation()
					{
						IdSmctMaster = idSmctMaster,
						Status = ContractStatusAll.S1WaitApprove,
						StationStatusCurr = ContractStationStatusAll.S2BookRequestApproval,
						ItemStatusCurr = ContractStationStatusItemAll.S21WaitApproval
					});
				}
				if (indata.ApproveProposal.UnApprove)
				{
					await _repo.ContractShare.UpdateStatusApproveReq(new ParameterStatusStation()
					{
						IdSmctMaster = idSmctMaster,
						Status = ApprovalReqStatus.S2UnApprove,
						StationStatusCurr = ApproveStationStatusAll.S1CreateProposal,
						ItemStatusCurr = ApproveStationStatusItemAll.S13Reject,
						OfficerReamrk = indata.ApproveProposal.Remark
					});
					await _repo.ContractShare.UpdateStatusContract(new ParameterStatusStation()
					{
						IdSmctMaster = idSmctMaster,
						Status = ContractStatusAll.S2UnApprove,
						StationStatusCurr = ContractStationStatusAll.S1Draft,
						ItemStatusCurr = ContractStationStatusItemAll.S21WaitApproval
					});
				}
			}
			//ผอ.พิจารณาอนุมัติ
			if (indata.ParameterCondition.StationReq == ApproveStationStatusAll.S3Consider)
			{
				if (indata.ApproveReq.Approve)
				{
					//เลขที่หนังสือขออนุมัติดำเนินการ
					await _repo.ContractShareNhso.UpdateBookNumber(indata);

					await _repo.ContractShare.UpdateStatusApproveReq(new ParameterStatusStation()
					{
						IdSmctMaster = idSmctMaster,
						Status = ApprovalReqStatus.S3Approve,
						StationStatusCurr = ApproveStationStatusAll.S4Approve,
						ItemStatusCurr = ApproveStationStatusItemAll.S41Approve
					});

					//ส่งต่อไปกำหนดรหัสคู่สัญญา VendorLink 
					var smctMasters = _repo.Context.SmctMasters.FirstOrDefault(x => x.Used && x.IdSmctMaster == indata.ParameterCondition.IdSmctMaster);
					var userSmctVendors = _repo.Context.UserSmctVendors.Include(n => n.IdRegisterNhsoNavigation).FirstOrDefault(x => x.Used && x.IdUserSmct == smctMasters.CreateUser);
					if (String.IsNullOrEmpty(userSmctVendors.IdRegisterNhsoNavigation.VendorId))
					{
						await _repo.ContractShare.UpdateStatusVendorLink(new ParameterStatusStation()
						{
							IdSmctMaster = idSmctMaster,
							StationStatusCurr = VendorLinkStationStatusAll.S2Check,
							ItemStatusPrev = VendorLinkStationStatusItemAll.S12SaveForward,
							ItemStatusCurr = VendorLinkStationStatusItemAll.S21WaitCheck
						});

						await _repo.ContractShare.UpdateStatusContract(new ParameterStatusStation()
						{
							IdSmctMaster = idSmctMaster,
							StationStatusPrev = ContractStationStatusAll.S2BookRequestApproval,
							StationStatusCurr = ContractStationStatusAll.S3SetVendor,
							ItemStatusPrev = ContractStationStatusItemAll.S22ApprovalForward,
							ItemStatusCurr = ContractStationStatusItemAll.S31WaitSetVendor
						});
					}
					else
					{
						//สร้างนิติกรรมสัญญา
						await _repo.ContractShare.UpdateStatusContract(new ParameterStatusStation()
						{
							IdSmctMaster = idSmctMaster,
							Status = ContractStatusAll.S3Approve,
							StationStatusCurr = ContractStationStatusAll.S4CreateContract,
							ItemStatusCurr = ContractStationStatusItemAll.S41WaitNhsoCreateContract
						});
					}


					String _UserNameCA = indata.ApproveProposal.UserNameCA;
					String _PasswordCA = indata.ApproveProposal.PasswordCA;

					if (indata.ApproveProposal.PasswordCA == "8888" || indata.ApproveProposal.PasswordCA == "9999")
					{
						var CAModels = _repo.GeneralRepo.GetAuthCAFix(indata.ApproveProposal.PasswordCA);
						_UserNameCA = CAModels.UserNameCA;
						_PasswordCA = CAModels.PasswordCA;
					}

					var responseApi = await _repo.SoapService.authenAndUserInfoAsync(new ServiceIAMAuthentication.authenWSRequest()
					{
						domainName = _mySet.IAMs.domainName,
						userName = _UserNameCA,
						password = _PasswordCA
					});
					if (responseApi != null && responseApi.@return.message == "OK")
					{
						byte[] binarySignature = null;
						indata.ParameterCondition.CadCA = responseApi.@return.userInfo.info;
						if (!String.IsNullOrEmpty(responseApi.@return.userInfo.signImage))
							binarySignature = Convert.FromBase64String(responseApi.@return.userInfo.signImage);
						else
						{
							//Fix Your Signature ตาม Defult ของ service CA
							binarySignature = Convert.FromBase64String("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");
						}

						MemoryStream stream = new MemoryStream(binarySignature);
						IFormFile file = new FormFile(stream, 0, binarySignature.Length, "signature", "signature.png");
						await _repo.ContractShareNhso.SignatureAppReqUploadfile(file, indata);
					}
					else
					{
						//************** นำออกชั่วคราว ไว้เทส เนื่องจากยังไม่มีรหัสผ่าน Auth API ที่ทดสอบได้ *********************
						//throw new Exception($"IAMWS : {responseApi.@return.message} ");
					}

				}
				//ตีกลับไปที่หน่วยบริการ
				if (indata.ApproveReq.UnApprove)
				{
					await _repo.ContractShare.UpdateStatusApproveReq(new ParameterStatusStation()
					{
						IdSmctMaster = idSmctMaster,
						Status = ApprovalReqStatus.S2UnApprove,
						StationStatusCurr = ApproveStationStatusAll.S1CreateProposal,
						ItemStatusCurr = ApproveStationStatusItemAll.S13Reject,
						OfficerReamrk = indata.ApproveProposal.Remark
					});
					await _repo.ContractShare.UpdateStatusContract(new ParameterStatusStation()
					{
						IdSmctMaster = idSmctMaster,
						Status = ApprovalReqStatus.S2UnApprove,
						StationStatusCurr = ContractStationStatusAll.S1Draft,
						ItemStatusCurr = ContractStationStatusItemAll.S21WaitApproval
					});
				}
				//ตีกลับไปที่เจ้าหน้าที่ตรวจสอบ
				if (indata.ApproveReq.UnApproveCheck)
				{
					await _repo.ContractShare.UpdateStatusApproveReq(new ParameterStatusStation()
					{
						IdSmctMaster = idSmctMaster,
						Status = ApprovalReqStatus.S2UnApprove,
						StationStatusCurr = ApproveStationStatusAll.S2CreateApprove,
						ItemStatusCurr = ApproveStationStatusItemAll.S21WaitBookRequestApproval,
						DirectorRemark = indata.ApproveProposal.Remark
					});
				}
			}
		}

		public async Task SignatureAppReqUploadfile(IFormFile FormFile, TAllMasterVendorView indata)
		{
			String idUserSmct = _repo.UserService.GetIdUserSmct();
			var idSmctMaster = indata.ParameterCondition.IdSmctMaster;
			var _SendmailType = indata.ParameterCondition.SendmailType;
			var _ContractTypeId = indata.ParameterCondition.ContractTypeId;
			var _RefId = indata.ParameterCondition.RefId;

			String _fileType = "F13";

			var fileFTP = _repo.UploadFiles.GenFileName(FormFile, _RefId, $"FILE_T{_ContractTypeId}_SIGN_{_fileType}");
			String thaiYear = GeneralUtils.getThaiYear(DateTime.Now.Year);

			var smctMasterFile = _repo.Context.SmctMasterFiles.FirstOrDefault(x => x.IdSmctMaster == idSmctMaster && x.FileType == _fileType);
			if (smctMasterFile != null)
			{
				smctMasterFile.FileName = FormFile.FileName;
				smctMasterFile.FileFtp = fileFTP;
				smctMasterFile.EditUser = idUserSmct;
				smctMasterFile.EditDate = DateTime.Now;
				smctMasterFile.PathFolder = thaiYear;
				_db.Update(smctMasterFile);
				await _db.SaveAsync();
			}
			else
			{
				//F13 ผู้ขออนุมัติหนังสือ
				smctMasterFile = new SmctMasterFile()
				{
					IdSmctMaster = idSmctMaster,
					FileType = _fileType,
					FileName = FormFile.FileName,
					FileFtp = fileFTP,
					CreateUser = idUserSmct,
					EditUser = idUserSmct,
					CreateDate = DateTime.Now,
					EditDate = DateTime.Now,
					FileNo = 1,
					Used = true,
					PathFolder = thaiYear
				};
				await _db.InsterAsync(smctMasterFile);
				await _db.SaveAsync();
			}

			String PathFolder = $"Signature/T{_ContractTypeId}/{thaiYear}";
			this.HandleUploadfile(FormFile, fileFTP, PathFolder);
		}


		public async Task UpdateBookNumber(TAllMasterVendorView indata)
		{
			String idSmctMaster = indata.ParameterCondition.IdSmctMaster;
			String idUserSmct = _repo.UserService.GetIdUserSmct();
			var approvalReq = await _repo.Context.ApprovalReqs.FirstOrDefaultAsync(x => x.IdSmctMaster == idSmctMaster);

			if (approvalReq.ApprovalReqId == null)
				approvalReq.ApprovalReqId = await this.BookNumberRunning();

			approvalReq.ApprovalReqDate = DateTime.Now;
			approvalReq.EditUser = idUserSmct;
			approvalReq.EditDate = DateTime.Now;
			_db.Update(approvalReq);
			await _db.SaveAsync();


			String userFullname = _repo.Context.UserSmcts.FirstOrDefault(x => x.IdUserSmct == idUserSmct)?.UserFullname ?? String.Empty;
			var approvalReqStation = _repo.Context.ApprovalReqStations.FirstOrDefault(x => x.IdSmctMaster == idSmctMaster);

			approvalReqStation.ApprovalReqId = approvalReq.ApprovalReqId;
			approvalReqStation.ApprovalReqDate = DateTime.Now;
			approvalReqStation.EditUserFullname = userFullname;
			approvalReqStation.EditUser = idUserSmct;
			approvalReqStation.EditDate = DateTime.Now;
			_db.Update(approvalReqStation);
			await _db.SaveAsync();
		}

		public async Task<string> BookNumberRunning()
		{
			int budgetYear = new ThaiBuddhistCalendar().GetYear(DateTime.Now);

			//ปีงบประมาณใหม่
			if (DateTime.Now.Month >= 10 && DateTime.Now.Day >= 1)
				budgetYear++;

			var query = await _repo.Context.ApprovalReqs.OrderByDescending(x => x.ApprovalReqId).FirstOrDefaultAsync(x => x.Used && x.ApprovalReqId != null);

			String _BudgetYear = budgetYear.ToString().Substring(2);
			if (query == null)
			{
				return $"{_BudgetYear}/R/00001";
			}

			var ContractId = int.Parse(query.ApprovalReqId.Substring(5)) + 1;
			return $"{_BudgetYear}/R/{ContractId.ToString("00000")}";

		}

		//UPDATE ContractAll
		public async Task UpdateInfoContract(TAllMasterVendorView indata)
		{
			String idSmctMaster = indata.ParameterCondition.IdSmctMaster;
			String idUserSmct = _repo.UserService.GetIdUserSmct();

			var _Contract = await _repo.Context.Contracts.Where(x => x.IdSmctMaster == idSmctMaster && x.Used).FirstOrDefaultAsync();
			if (_Contract != null)
			{
				_Contract.StartDate = GeneralUtils.DateTimeToEn(indata.InfoContract.StartDateStr);
				_Contract.EndDate = GeneralUtils.DateTimeToEn(indata.InfoContract.EndDateStr);
				_Contract.EditUser = idUserSmct;
				_Contract.EditDate = DateTime.Now;
				_db.Update(_Contract);
				await _db.SaveAsync();
			}
		}

		public async Task UpdateMasterSigners(TAllMasterVendorView indata)
		{
			String idSmctMaster = indata.ParameterCondition.IdSmctMaster;
			String idUserSmct = _repo.UserService.GetIdUserSmct();

			if (indata.InfoSignerPartnersOfContract != null)
			{
				var smctMasterSigner = await _repo.Context.SmctMasterSigners.FirstOrDefaultAsync(x => x.IdSmctMaster == idSmctMaster);
				smctMasterSigner.EditUser = idUserSmct;
				smctMasterSigner.EditDate = DateTime.Now;
				_db.Update(smctMasterSigner);
				await _db.SaveAsync();
				//โครงการไม่มีข้อมูลผู้ลงนาม และจะเก็บที่ table SmctMasterSignerDetail2
				if (indata.ParameterCondition.ContractTypeId != "14")
				{
					var smctMasterSignerDetail1 = await _repo.Context.SmctMasterSignerDetail1s.FirstOrDefaultAsync(x => x.IdSmctMasterSigner == smctMasterSigner.IdSmctMasterSigner);
					smctMasterSignerDetail1.NhsoSignerUser = indata.InfoContractNhso.EmpId;
					smctMasterSignerDetail1.NhsoContractId = indata.InfoContractNhso.NhsoContractId;
					smctMasterSignerDetail1.NhsoContractDate = GeneralUtils.DateTimeToEn(indata.InfoContractNhso.NhsoContractDateStr);
					smctMasterSignerDetail1.NhsoWitnessUser = indata.InfoSignerPartnersOfContract.NhsoWitnessUser;
					smctMasterSignerDetail1.NhsoFootnoteUser1 = null;
					smctMasterSignerDetail1.NhsoFootnoteUser2 = null;
					smctMasterSignerDetail1.NhsoFootnoteUser3 = null;
					if (indata.InfoSignerPartnersOfContract.FootNotesNhso != null && indata.InfoSignerPartnersOfContract.FootNotesNhso.Count > 0)
					{
						int index_footNotes = 0;
						foreach (var item in indata.InfoSignerPartnersOfContract.FootNotesNhso)
						{
							if (index_footNotes == 0) smctMasterSignerDetail1.NhsoFootnoteUser1 = item.EmpId;
							if (index_footNotes == 1) smctMasterSignerDetail1.NhsoFootnoteUser2 = item.EmpId;
							if (index_footNotes == 2) smctMasterSignerDetail1.NhsoFootnoteUser3 = item.EmpId;
							index_footNotes++;
						}
					}

					smctMasterSignerDetail1.EditUser = idUserSmct;
					smctMasterSignerDetail1.EditDate = DateTime.Now;
					_db.Update(smctMasterSignerDetail1);
					await _db.SaveAsync();
				}
				else
				{
					//โครงการ
					var smctMasterSignerDetail2 = await _repo.Context.SmctMasterSignerDetail2s.FirstOrDefaultAsync(x => x.IdSmctMasterSigner == smctMasterSigner.IdSmctMasterSigner);

					smctMasterSignerDetail2.NhsoKetProposalUser = idUserSmct;
					smctMasterSignerDetail2.EditUser = idUserSmct;
					smctMasterSignerDetail2.EditDate = DateTime.Now;
					_db.Update(smctMasterSignerDetail2);
					await _db.SaveAsync();
				}

			}
		}

		public async Task UpdateStatusContract(TAllMasterVendorView indata)
		{
			String idSmctMaster = indata.ParameterCondition.IdSmctMaster;
			int btnSubmit = int.Parse(indata.BtnSubmit);

			if (indata.ParameterCondition.Station == ContractStationStatusAll.S4CreateContract)
			{

				if (!indata.ApproveContract.Approve && !indata.ApproveContract.UnApprove)
					throw new Exception("ระบุผลการตรวจสอบ");
				if (indata.ApproveContract.UnApprove)
					if (String.IsNullOrEmpty(indata.ApproveContract.Remark))
						throw new Exception("ระบุรายละเอียดหมายเหตุ");
			}

			if (indata.ApproveContract.Approve)
			{
				//20210915 สลับ State เป็น ส่งต่อจากสร้างนิติกรรม --> ออกเลขที่สัญญา --> ลงนาม 2 ฝ่าย
				await _repo.ContractShare.UpdateStatusContract(new ParameterStatusStation()
				{
					IdSmctMaster = idSmctMaster,
					Status = ContractStatusAll.S1WaitApprove,
					StationStatusPrev = ContractStationStatusAll.S4CreateContract,
					StationStatusCurr = ContractStationStatusAll.S6ContractNumber,
					ItemStatusPrev = ContractStationStatusItemAll.S42NhsoSaveForward,
					ItemStatusCurr = ContractStationStatusItemAll.S61WaitNhsoCentralCheckApproval
				});
			}
			if (indata.ApproveContract.UnApprove)
			{
				await _repo.ContractShare.UpdateStatusContract(new ParameterStatusStation()
				{
					IdSmctMaster = idSmctMaster,
					Status = ApprovalReqStatus.S2UnApprove,
					StationStatusPrev = ContractStationStatusAll.S4CreateContract,
					StationStatusCurr = ContractStationStatusAll.S1Draft,
					ItemStatusPrev = ContractStationStatusItemAll.S43NhsoReject,
					ItemStatusCurr = ContractStationStatusItemAll.S13Reject,
					KetRemark = indata.ApproveContract.Remark,
					FRetarn = F_RETARN.REJECT
				});
			}

		}

		public async Task UpdateContractEditLast(TAllMasterVendorView indata)
		{
			String idSmctMaster = indata.ParameterCondition.IdSmctMaster;
			String idUserSmct = _repo.UserService.GetIdUserSmct();

			var _Contracts = await _repo.Context.Contracts.Where(x => x.IdSmctMaster == idSmctMaster && x.Used).FirstOrDefaultAsync();
			_Contracts.EditUser = idUserSmct;
			_Contracts.EditDate = DateTime.Now;
			_db.Update(_Contracts);
			await _db.SaveAsync();

			var contractStations = await _repo.Context.ContractStations.Where(x => x.IdSmctMaster == idSmctMaster && x.Used).FirstOrDefaultAsync();
			contractStations.EditUser = idUserSmct;
			contractStations.EditDate = DateTime.Now;
			_db.Update(contractStations);
			await _db.SaveAsync();
		}

		public async Task UpdateSigner(TAllMasterVendorView indata)
		{
			using (var _transaction = _repo.BeginTransaction())
			{
				var _ParameterCon = indata.ParameterCondition;
				String idSmctMaster = indata.ParameterCondition.IdSmctMaster;
				String _SigningType = SecurityRepo.Decrypt(indata.ParameterCondition.SigningTypeEn);
				String idUserSmct = _repo.UserService.GetIdUserSmct();
				String _ContractTypeId = indata.ParameterCondition.ContractTypeId;
				int btnSubmit = int.Parse(indata.BtnSubmit);

				if (btnSubmit == (int)ButtonState.SignerAttachFile)
				{
					if (indata.InfoAttachFileRealVersion == null
					|| indata.InfoAttachFileRealVersion.SmctMasterFile == null
					|| indata.InfoAttachFileRealVersion.SmctMasterFile.Count == 0
					|| indata.InfoAttachFileRealVersion.SmctMasterFile[0].FormFile == null)
					{
						throw new Exception("แนบไฟล์แสกน นิติกรรมสัญญา(ฉบับจริง)");
					}
				}
				if (String.IsNullOrEmpty(indata.ApproveProposal.UserNameCA))
					throw new Exception("ระบุ UserName NHSO CA Gateway");
				if (String.IsNullOrEmpty(indata.ApproveProposal.PasswordCA))
					throw new Exception("ระบุ Password NHSO CA Gateway");

				String _UserNameCA = indata.ApproveProposal.UserNameCA;
				String _PasswordCA = indata.ApproveProposal.PasswordCA;

				if (indata.ApproveProposal.PasswordCA == "8888" || indata.ApproveProposal.PasswordCA == "9999")
				{
					var CAModels = _repo.GeneralRepo.GetAuthCAFix(indata.ApproveProposal.PasswordCA);
					_UserNameCA = CAModels.UserNameCA;
					_PasswordCA = CAModels.PasswordCA;
				}


				byte[] binarySignature = null;
				var responseApi = await _repo.SoapService.authenAndUserInfoAsync(new ServiceIAMAuthentication.authenWSRequest()
				{
					domainName = _mySet.IAMs.domainName,
					userName = _UserNameCA,
					password = _PasswordCA
				});
				if (responseApi != null && responseApi.@return.message == "OK")
				{
					indata.ParameterCondition.CadCA = responseApi.@return.userInfo.info;
					if (!String.IsNullOrEmpty(responseApi.@return.userInfo.signImage))
						binarySignature = Convert.FromBase64String(responseApi.@return.userInfo.signImage);
					else
					{
						//Fix Your Signature ตาม Defult ของ service CA
						binarySignature = Convert.FromBase64String("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");
					}

					if (_SigningType == SigningTypes.Electronic)
					{
						MemoryStream stream = new MemoryStream(binarySignature);
						IFormFile file = new FormFile(stream, 0, binarySignature.Length, "signature", "signature.png");
						await _repo.ContractShare.SignatureUploadfile(file, indata);
					}
					if (_SigningType == SigningTypes.Paper)
					{
						//แนบไฟล์ฉบับจริง 
						if (btnSubmit == (int)ButtonState.SignerAttachFile)
						{
							var FileReal = indata.InfoAttachFileRealVersion.SmctMasterFile[0];
							var fileFTP = _repo.UploadFiles.GenFileName(FileReal.FormFile, _ParameterCon.RefId, $"FILE_{_ContractTypeId}_F3_Real");
							String thaiYear = GeneralUtils.getThaiYear(DateTime.Now.Year);

							var smctMasterFile = new SmctMasterFile()
							{
								IdSmctMaster = idSmctMaster,
								FileType = "F3",
								FileName = FileReal.FormFile.FileName,
								FileFtp = fileFTP,
								CreateUser = idUserSmct,
								EditUser = idUserSmct,
								CreateDate = DateTime.Now,
								EditDate = DateTime.Now,
								FileNo = 1,
								Used = true,
								PathFolder = thaiYear
							};
							await _db.InsterAsync(smctMasterFile);
							await _db.SaveAsync();

							//CA files
							byte[] outPdfBuffer = null;
							using (var ms = new MemoryStream())
							{
								FileReal.FormFile.CopyTo(ms);
								outPdfBuffer = ms.ToArray();
								outPdfBuffer = await _repo.ContractShareNhso.PDFCAFile(outPdfBuffer, responseApi.@return.userInfo.info, null, null, 1);
							}

							//CA ไฟล์จาก FTP และ Upload ไฟล์ไปที่ FTP
							MemoryStream stream = new MemoryStream(outPdfBuffer);
							IFormFile fileCA = new FormFile(stream, 0, outPdfBuffer.Length, "File_Real", "File_Real.pdf");
							String PathFolder = $"Attach/T{_ContractTypeId}/{thaiYear}";
							this.HandleUploadfile(fileCA, fileFTP, PathFolder);

							//ผูกพัน ลงนามจริงในเอกสาร
							await _repo.ContractShare.UpdateStatusContract(new ParameterStatusStation()
							{
								IdSmctMaster = idSmctMaster,
								Status = ContractStatusAll.S3Approve,
								StationStatusPrev = ContractStationStatusAll.S5Signing2,
								StationStatusCurr = ContractStationStatusAll.S7Binding,
								ItemStatusPrev = ContractStationStatusItemAll.S55Signing2PaperSuccess,
								ItemStatusCurr = ContractStationStatusItemAll.S72BindingPaper
							});

							await this.UpdateContractStationSuccess(indata);
							//เฉพาะที่มีหลักประกัน
							if (_ContractTypeId == "01" || _ContractTypeId == "03" || _ContractTypeId == "04" || _ContractTypeId == "11")
								await this.UpdateContractStationGuarantees(indata);

						}
					}
				}
				else
				{
					throw new Exception($"iAMWS : {responseApi.@return.message} ");
				}

				//พยานลงนาม
				if (btnSubmit == (int)ButtonState.SignerWitness)
				{
					var masterSigners = _repo.Context.SmctMasterSigners.FirstOrDefault(x => x.IdSmctMaster == idSmctMaster);
					var masterSignerDetail1s = _repo.Context.SmctMasterSignerDetail1s.FirstOrDefault(x => x.IdSmctMasterSigner == masterSigners.IdSmctMasterSigner);
					masterSignerDetail1s.NhsoWitnessStatus = WitnessStatusAll.W2WitnessComplete;
					masterSignerDetail1s.EditUser = idUserSmct;
					masterSignerDetail1s.EditDate = DateTime.Now;
					_db.Update(masterSignerDetail1s);
					await _db.SaveAsync();

					String userFullname = _repo.Context.UserSmcts.FirstOrDefault(x => x.IdUserSmct == idUserSmct)?.UserFullname ?? String.Empty;
					var contractStations = _repo.Context.ContractStations.FirstOrDefault(x => x.IdSmctMaster == idSmctMaster);
					contractStations.EditUserFullname = userFullname;
					contractStations.EditUser = idUserSmct;
					contractStations.EditDate = DateTime.Now;
					_db.Update(contractStations);
					await _db.SaveAsync();
				}
				//ผู้มีอำนาจ ลงนาม
				else if (btnSubmit == (int)ButtonState.Signer)
				{
					String _ItemStatusPrev = String.Empty;
					String _ItemStatusCurr = String.Empty;

					if (_SigningType == SigningTypes.Electronic)
					{
						_ItemStatusPrev = ContractStationStatusItemAll.S54Signing2ElectronicSuccess;
						_ItemStatusCurr = ContractStationStatusItemAll.S71BindingElectronic;
					}
					else if (_SigningType == SigningTypes.Paper)
					{
						_ItemStatusPrev = ContractStationStatusItemAll.S55Signing2PaperSuccess;
						_ItemStatusCurr = ContractStationStatusItemAll.S72BindingPaper;
					}

					//ผูกพัน ลงนาม Electronic
					await _repo.ContractShare.UpdateStatusContract(new ParameterStatusStation()
					{
						IdSmctMaster = idSmctMaster,
						Status = ContractStatusAll.S3Approve,
						StationStatusPrev = ContractStationStatusAll.S5Signing2,
						StationStatusCurr = ContractStationStatusAll.S7Binding,
						ItemStatusPrev = _ItemStatusPrev,
						ItemStatusCurr = _ItemStatusCurr
					});

					await this.UpdateContractStationSuccess(indata);
					//เฉพาะที่มีหลักประกัน
					if (_ContractTypeId == "01" || _ContractTypeId == "03" || _ContractTypeId == "04" || _ContractTypeId == "11")
						await this.UpdateContractStationGuarantees(indata);
				}

				_transaction.Commit();
			}
		}


		public async Task UpdateContractStationGuarantees(TAllMasterVendorView indata)
		{
			String idUserSmct = _repo.UserService.GetIdUserSmct();
			String idSmctMaster = indata.ParameterCondition.IdSmctMaster;
			var ContractStations = _repo.Context.ContractStations.FirstOrDefault(x => x.IdSmctMaster == idSmctMaster && x.Used && x.StationStatusCurr == "S7");
			var ContractStationGuarantee = _repo.Context.ContractStationGuarantees.FirstOrDefault(x => x.IdSmctMaster == idSmctMaster && x.Used && x.StationStatusCurr == "S7");
			if (ContractStationGuarantee == null)
			{
				ContractStationGuarantee = _mapper.Map<ContractStationGuarantee>(ContractStations);
				ContractStationGuarantee.ContractGuaranteeType = ContractGuaranteeTypes.T1_NEW;
				ContractStationGuarantee.ContractGuaranteeStatus = "S1";
				ContractStationGuarantee.ContractGuaranteeFFile = "N";
				ContractStationGuarantee.ContractGuaranteeCreateUser = idUserSmct;
				ContractStationGuarantee.ContractGuaranteeCreateDate = DateTime.Now;
				ContractStationGuarantee.ContractGuaranteeEditUser = idUserSmct;
				ContractStationGuarantee.ContractGuaranteeEditDate = DateTime.Now;
				ContractStationGuarantee.ContractStatus = ContractStatusAll.S3Approve; //S3=ใช้งาน 
				await _db.InsterAsync(ContractStationGuarantee);
				await _db.SaveAsync();
			}
		}

		public async Task UpdateContractStationSuccess(TAllMasterVendorView indata)
		{
			String idUserSmct = _repo.UserService.GetIdUserSmct();
			String idSmctMaster = indata.ParameterCondition.IdSmctMaster;
			var ContractStations = _repo.Context.ContractStations.FirstOrDefault(x => x.IdSmctMaster == idSmctMaster && x.Used && x.StationStatusCurr == "S7");
			var ContractStationSuccess = _repo.Context.ContractStationSuccesses.FirstOrDefault(x => x.IdSmctMaster == idSmctMaster && x.Used && x.StationStatusCurr == "S7");
			if (ContractStationSuccess == null)
			{
				ContractStationSuccess = _mapper.Map<ContractStationSuccess>(ContractStations);
				ContractStationSuccess.ContractSuccessType = ContractSuccessTypes.TA_NORMAL;
				ContractStationSuccess.ContractSuccessStatus = "S1";
				ContractStationSuccess.ContractSuccessFFile = "N";
				ContractStationSuccess.ContractSuccessCreateUser = idUserSmct;
				ContractStationSuccess.ContractSuccessCreateDate = DateTime.Now;
				ContractStationSuccess.ContractSuccessEditUser = idUserSmct;
				ContractStationSuccess.ContractSuccessEditDate = DateTime.Now;
				ContractStationSuccess.ContractStatus = ContractStatusAll.S3Approve; //S3=ใช้งาน 
				await _db.InsterAsync(ContractStationSuccess);
				await _db.SaveAsync();
			}
		}


		public async Task UpdateConditionPayment(TAllMasterVendorView indata)
		{
			String idUserSmct = _repo.UserService.GetIdUserSmct();
			String idSmctMaster = indata.ParameterCondition.IdSmctMaster;
			//Type
			//ประเภทปรูปแบบหลักประกัน
			//T1 = มีหลักประกัน : หักจากงวดที่1
			//T2 = มีหลักประกัน : ไม่หักจากงวดที่1
			//T3 = ยกเว้นหลักประกันสัญญา
			if (indata.InfoConditionPayment != null)
			{
				var _Contracts = await _repo.Context.Contracts.FirstOrDefaultAsync(x => x.IdSmctMaster == idSmctMaster);
				var removeContractPeriods = _repo.Context.ContractPeriods.Where(x => x.IdContract == _Contracts.IdContract).ToList();
				if (removeContractPeriods.Count > 0)
				{
					_db.DeleteRange(removeContractPeriods);
					await _repo.SaveAsync();
				}
				var removeContractPeriodDetails = _repo.Context.ContractPeriodDetails.Where(x => x.IdContract == _Contracts.IdContract).ToList();
				if (removeContractPeriodDetails.Count > 0)
				{
					_db.DeleteRange(removeContractPeriodDetails);
					await _repo.SaveAsync();
				}
				if (indata.InfoConditionPayment.PeriodType == PeriodTypes.PayOne100)
				{
					//มีรหัสงบประมาณเดียว
					if (indata.InfoConditionPayment.P1Budgetcode == null || indata.InfoConditionPayment.P1Budgetcode.Count == 0)
					{
						var _ContractPlans = await _repo.Context.ContractPlans.Where(x => x.IdContract == _Contracts.IdContract && x.Used).OrderBy(x => x.Planno).ToListAsync();
						if (_ContractPlans.Count > 0)
						{
							if (indata.InfoContract != null)
							{
								var InfoBudget = indata.InfoContract;
								indata.InfoConditionPayment.P1Budgetcode = new List<ContractPeriodDTO>() {
									 new ContractPeriodDTO(){
										 PeriodBudgetcode = _ContractPlans[0].Budgetcode,
										 PeriodPercent = InfoBudget.Budget,
									 }
								};
							}
						}
					}

					if (indata.InfoConditionPayment.P1Budgetcode != null && indata.InfoConditionPayment.P1Budgetcode.Count > 0)
					{
						var smctMasters = await _repo.Context.SmctMasters.Include(x => x.IdRegisterNhsoNavigation).Where(x => x.IdSmctMaster == idSmctMaster && x.Used).FirstOrDefaultAsync();

						byte index_no = 1;
						foreach (var item in indata.InfoConditionPayment.P1Budgetcode)
						{
							var contractPeriod = new ContractPeriod()
							{
								IdContract = _Contracts.IdContract,
								PeriodType = PeriodTypes.PayOne100,
								PeriodNo = 1,
								PeriodBudgetcode = item.PeriodBudgetcode,
								PeriodPercent = item.PeriodPercent,
								PeriodVendorId = smctMasters.IdRegisterNhsoNavigation.VendorId,
								PeriodP1Detail = indata.InfoConditionPayment.PeriodP1Detail,
								CreateUser = idUserSmct,
								EditUser = idUserSmct,
								CreateDate = DateTime.Now,
								EditDate = DateTime.Now,
								Used = true
							};
							_db.Inster(contractPeriod);
							await _repo.SaveAsync();
							if (index_no == 1)
							{
								var contractPeriodDetail = new ContractPeriodDetail()
								{
									IdContract = _Contracts.IdContract,
									PeriodNo = 1,
									ContractPeriodDetailNo = index_no++,
									ContractPeriodDetail1 = indata.InfoConditionPayment.ContractPeriodDetail1,
									CreateUser = idUserSmct,
									EditUser = idUserSmct,
									CreateDate = DateTime.Now,
									EditDate = DateTime.Now,
									Used = true
								};
								_db.Inster(contractPeriodDetail);
								await _repo.SaveAsync();
							}
						}
					}
				}
				else
				{
					foreach (var item in indata.InfoConditionPayment.PeriodList)
					{
						String _PeriodType = indata.InfoConditionPayment.PeriodType;
						if (indata.InfoConditionPayment.PeriodList.Count > 1)
						{
							_PeriodType = PeriodTypes.PayMutiToN;
						}

						foreach (var item_period in item.ContractPeriod)
						{
							var contractPeriod = new ContractPeriod()
							{
								IdContract = _Contracts.IdContract,
								PeriodType = _PeriodType,
								PeriodNo = item.PeriodNo,
								PeriodBudgetcode = item_period.PeriodBudgetcode,
								PeriodPercent = item_period.PeriodPercent,
								PeriodVendorId = item_period.PeriodVendorId,
								PeriodP1Detail = null,
								CreateUser = idUserSmct,
								EditUser = idUserSmct,
								CreateDate = DateTime.Now,
								EditDate = DateTime.Now,
								Used = true
							};
							_db.Inster(contractPeriod);
							await _repo.SaveAsync();
						}
						byte index_no = 1;
						foreach (var item_detail in item.ContractPeriodDetail)
						{
							var contractPeriodDetail = new ContractPeriodDetail()
							{
								IdContract = _Contracts.IdContract,
								PeriodNo = item.PeriodNo,
								ContractPeriodDetailNo = index_no++,
								ContractPeriodDetail1 = item_detail.ContractPeriodDetail1,
								CreateUser = idUserSmct,
								EditUser = idUserSmct,
								CreateDate = DateTime.Now,
								EditDate = DateTime.Now,
								Used = true
							};
							_db.Inster(contractPeriodDetail);
							await _repo.SaveAsync();
						}
					}
				}


			}
		}

		public async Task<byte[]> PDFCAFile(byte[] outPdfBuffer, String Cad = null, String ImagePath = null, String SendmailType = null, int SignaturePage = 1)
		{
			var outPdfBufferTemp = outPdfBuffer;
			try
			{
				String Rectangle = "10,10,10,10";
				if (SendmailType == "SN22")//สปสช : พยานลงนาม SN22
					Rectangle = "250,105,100,800";
				else if (SendmailType == "SN21")//สปสช : ผู้มีอำนาจลงนาม SN21
					Rectangle = "250,445,100,500";


				//ตั้งค่าให้แสดงตำแหน่ง แต่จัดตำแหน่งให้อยู่นอก PDF เพราะไม่ต้องการให้ข้อความ Digitally signed by ขึ้นที่ PDF เนื่องจากส่งรูปไปแสดงที่ API GEN PDF แล้ว
				Rectangle = "0,0,0,0";


				//UAT fix ใช้ของ pitima.b ไปก่อน ของคนอื่น error 500 Failed to signed WebService request - 1632736482367. Please refer to error log of worker: demo",
				if (Cad == null || _mySet.ServerSite == "UAT")
					Cad = "sy1ORJpPOgb/vnoPFmONy8s5CdB1zG5mj6wkqBLatCauvYOTWjfl/emMQgl+9Fc94DwuOXbbzYfUFCGswMD00XOHDExYtp8WuJ4T0IkNWOkO9uyb/bNIuy+tqCTC0WvYvNZo5bd3vJ1d1Z+MYXc132SmkeDkWuEFhQlV6X7A9HQ=";

				if (ImagePath == null)
					ImagePath = "iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKCAYAAACNMs+9AAAACXBIWXMAAC4jAAAuIwF4pT92AAAF8WlUWHRYTUw6Y29tLmFkb2JlLnhtcAAAAAAAPD94cGFja2V0IGJlZ2luPSLvu78iIGlkPSJXNU0wTXBDZWhpSHpyZVN6TlRjemtjOWQiPz4gPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyIgeDp4bXB0az0iQWRvYmUgWE1QIENvcmUgNi4wLWMwMDMgNzkuMTY0NTI3LCAyMDIwLzEwLzE1LTE3OjQ4OjMyICAgICAgICAiPiA8cmRmOlJERiB4bWxuczpyZGY9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkvMDIvMjItcmRmLXN5bnRheC1ucyMiPiA8cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0iIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtbG5zOnhtcE1NPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvbW0vIiB4bWxuczpzdEV2dD0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL3NUeXBlL1Jlc291cmNlRXZlbnQjIiB4bWxuczpkYz0iaHR0cDovL3B1cmwub3JnL2RjL2VsZW1lbnRzLzEuMS8iIHhtbG5zOnBob3Rvc2hvcD0iaHR0cDovL25zLmFkb2JlLmNvbS9waG90b3Nob3AvMS4wLyIgeG1wOkNyZWF0b3JUb29sPSJBZG9iZSBQaG90b3Nob3AgMjIuMSAoV2luZG93cykiIHhtcDpDcmVhdGVEYXRlPSIyMDIxLTA5LTE2VDExOjAwOjM1KzA3OjAwIiB4bXA6TWV0YWRhdGFEYXRlPSIyMDIxLTA5LTE2VDExOjAwOjM1KzA3OjAwIiB4bXA6TW9kaWZ5RGF0ZT0iMjAyMS0wOS0xNlQxMTowMDozNSswNzowMCIgeG1wTU06SW5zdGFuY2VJRD0ieG1wLmlpZDo2NWY5YTU1Yi1jY2Y3LWMwNDYtYmY1ZC05OTU4YjI1MzEzYzgiIHhtcE1NOkRvY3VtZW50SUQ9ImFkb2JlOmRvY2lkOnBob3Rvc2hvcDpiNzA2YzEyMC03OTVmLWY5NGUtODc5MS1mZTc2OGVjZWFiY2UiIHhtcE1NOk9yaWdpbmFsRG9jdW1lbnRJRD0ieG1wLmRpZDoyMDFkYzk4Yi01ZWZjLWFjNDItYmE4Yi00YzhhOTFiM2NlNjUiIGRjOmZvcm1hdD0iaW1hZ2UvcG5nIiBwaG90b3Nob3A6Q29sb3JNb2RlPSIzIiBwaG90b3Nob3A6SUNDUHJvZmlsZT0ic1JHQiBJRUM2MTk2Ni0yLjEiPiA8eG1wTU06SGlzdG9yeT4gPHJkZjpTZXE+IDxyZGY6bGkgc3RFdnQ6YWN0aW9uPSJjcmVhdGVkIiBzdEV2dDppbnN0YW5jZUlEPSJ4bXAuaWlkOjIwMWRjOThiLTVlZmMtYWM0Mi1iYThiLTRjOGE5MWIzY2U2NSIgc3RFdnQ6d2hlbj0iMjAyMS0wOS0xNlQxMTowMDozNSswNzowMCIgc3RFdnQ6c29mdHdhcmVBZ2VudD0iQWRvYmUgUGhvdG9zaG9wIDIyLjEgKFdpbmRvd3MpIi8+IDxyZGY6bGkgc3RFdnQ6YWN0aW9uPSJzYXZlZCIgc3RFdnQ6aW5zdGFuY2VJRD0ieG1wLmlpZDo2NWY5YTU1Yi1jY2Y3LWMwNDYtYmY1ZC05OTU4YjI1MzEzYzgiIHN0RXZ0OndoZW49IjIwMjEtMDktMTZUMTE6MDA6MzUrMDc6MDAiIHN0RXZ0OnNvZnR3YXJlQWdlbnQ9IkFkb2JlIFBob3Rvc2hvcCAyMi4xIChXaW5kb3dzKSIgc3RFdnQ6Y2hhbmdlZD0iLyIvPiA8L3JkZjpTZXE+IDwveG1wTU06SGlzdG9yeT4gPC9yZGY6RGVzY3JpcHRpb24+IDwvcmRmOlJERj4gPC94OnhtcG1ldGE+IDw/eHBhY2tldCBlbmQ9InIiPz62zgGRAAAAF0lEQVQYlWP8//8/AzGAiShVowqpphAA1RIDET0/PewAAAAASUVORK5CYII=";

				string base64PDF = Convert.ToBase64String(outPdfBuffer, 0, outPdfBuffer.Length);
				var PDFSignResult = await _repo.ServiceOther.PDFSigningByCAD(new PDFSigningByCADRequest()
				{
					workerName = _mySet.CAGateways.WorkerName,
					cad = Cad,
					contentData = base64PDF,
					certify = _mySet.CAGateways.Certify,
					visibleSignature = _mySet.CAGateways.VisibleSignature,
					visibleSignaturePage = SignaturePage,
					visibleSignatureRectangle = Rectangle,
					visibleSignatureImagePath = ImagePath
				});

				if (PDFSignResult != null)
				{
					if (PDFSignResult.status == "200" && !String.IsNullOrEmpty(PDFSignResult.signingResponse))
					{
						if (GeneralUtils.IsBase64String(PDFSignResult.signingResponse))
						{
							var outPdfBufferCA = Convert.FromBase64String(PDFSignResult.signingResponse);
							if (outPdfBufferCA.Length > 0)
							{
								outPdfBufferTemp = outPdfBufferCA;
							}
						}
					}
				}

				return outPdfBufferTemp;
			}
			catch
			{
				return outPdfBufferTemp;
			}
		}

		public async Task UpdateFMPDF(ParameterCondition indata, string fmtype, byte[] outPdfBuffer)
		{
			String idUserSmct = _repo.UserService.GetIdUserSmct();
			var idSmctMaster = indata.IdSmctMaster;

			String _fileType = String.Empty;
			if (fmtype.StartsWith("FM_APPROVAL"))
				_fileType = "F10";
			if (fmtype.StartsWith("FM_CONTRACT"))
				_fileType = "F11";
			if (fmtype.StartsWith("FM_PAY"))
				_fileType = "F12";

			String thaiYear = GeneralUtils.getThaiYear(DateTime.Now.Year);
			var fileFTP = $"{indata.RefId}_T{indata.ContractTypeId}_{_fileType}_V{indata.VersionNo}.pdf";
			String PathFolder = $"FM/{fmtype}/{thaiYear}";
			//var pathSave = $@"{_env.ContentRootPath}\wwwroot\files\FM\{PathFolder}\{fileFTP}";


			var smctMasterFile = _repo.Context.SmctMasterFiles.FirstOrDefault(x => x.IdSmctMaster == idSmctMaster && x.FileType == _fileType);
			if (smctMasterFile != null)
			{
				smctMasterFile.FileName = fileFTP;
				smctMasterFile.FileFtp = fileFTP;
				smctMasterFile.EditUser = idUserSmct;
				smctMasterFile.EditDate = DateTime.Now;
				smctMasterFile.PathFolder = thaiYear;
				_db.Update(smctMasterFile);
				await _db.SaveAsync();
			}
			else
			{
				smctMasterFile = new SmctMasterFile()
				{
					IdSmctMaster = idSmctMaster,
					FileType = _fileType,
					FileName = fileFTP,
					FileFtp = fileFTP,
					CreateUser = idUserSmct,
					EditUser = idUserSmct,
					CreateDate = DateTime.Now,
					EditDate = DateTime.Now,
					FileNo = 1,
					Used = true,
					PathFolder = thaiYear
				};
				await _db.InsterAsync(smctMasterFile);
				await _db.SaveAsync();
			}


			//FileInfo fileInfo = new FileInfo(pathSave);
			//if (!fileInfo.Exists)
			//    Directory.CreateDirectory(fileInfo.Directory.FullName);

			////var pathSave = $@"{_env.ContentRootPath}\wwwroot\files\FM\{fmtype}\{indata.IdSmctMaster}_T{indata.ContractTypeId}_V{indata.VersionNo}.pdf";
			//System.IO.File.WriteAllBytes(pathSave, outPdfBuffer);

			var stream = new MemoryStream(outPdfBuffer);
			IFormFile FormFile = new FormFile(stream, 0, outPdfBuffer.Length, fileFTP, fileFTP);

			try
			{
				_repo.UploadFiles.FTPSaveFile(FormFile, fileFTP, PathFolder);
			}
			catch (Exception ex)
			{
				String PathFTP = @$"ftp://{_mySet.FTPs.UserName}@{_mySet.FTPs.Host}//ebudget//Smct//{PathFolder}//{fileFTP}";
				throw new Exception($"ERROR FTP URL:{$"{PathFTP}"} ex : {GeneralUtils.GetExMessage(ex)}");
			}
		}

		public async Task UpdateContractNumber(TAllMasterVendorView indata)
		{
			//_ContractSbbCklHeadings = 0 แสดงว่าบางสัญญายังไม่มีข้อมูลจะทดสอบต่อไม่ได้ จะตัดการเช็คออกก่อนให้ออกเลขที่สัญญาได้
			var _ContractSbbCklHeadings = _repo.Context.ContractSbbCklHeadings.Where(x => x.IdContractType == indata.ParameterCondition.IdContractType && x.FCb != "N" && x.Used).ToList();
			if (_ContractSbbCklHeadings.Count > 0)
			{
				if (indata.CheckListMain.ContractSbbCkl.ContractSbbCklDetails == null || indata.CheckListMain.ContractSbbCkl.ContractSbbCklDetails.Count == 0)
					throw new Exception("ระบุ ผลตรวจเช็ค");

				if (_ContractSbbCklHeadings.Count != indata.CheckListMain.ContractSbbCkl.ContractSbbCklDetails.Count || indata.CheckListMain.ContractSbbCkl.ContractSbbCklDetails.Any(x => !x.C1 && !x.C2 && !x.C3))
				{
					throw new Exception("ระบุ ผลตรวจเช็ค ไม่ครบ");
				}
			}

			if (!indata.ApproveGenContract.Approve && !indata.ApproveGenContract.UnApproveVendor && !indata.ApproveGenContract.UnApproveNhso)
				throw new Exception("ระบุผลการตรวจสอบ");
			if (indata.ApproveGenContract.UnApproveVendor || indata.ApproveGenContract.UnApproveNhso)
				if (String.IsNullOrEmpty(indata.ApproveGenContract.Remark))
					throw new Exception("ระบุรายละเอียดหมายเหตุ");

			using (var _transaction = _repo.BeginTransaction())
			{
				String idSmctMaster = indata.ParameterCondition.IdSmctMaster;
				String _SigningType = SecurityRepo.Decrypt(indata.ParameterCondition.SigningTypeEn);
				String idUserSmct = _repo.UserService.GetIdUserSmct();

				var _Contract = await _repo.Context.Contracts.Where(x => x.IdSmctMaster == idSmctMaster && x.Used).FirstOrDefaultAsync();
				if (_Contract != null)
				{
					await this.UpdateCheckList(indata);

					if (indata.ApproveGenContract.Approve)
					{
						_Contract.ContractId = await _repo.ContractShareNhso.ContractNumberRunning();
						_Contract.ContractDate = DateTime.Now;
					}
					_Contract.EditUser = idUserSmct;
					_Contract.EditDate = DateTime.Now;
					_db.Update(_Contract);
					await _db.SaveAsync();

					if (indata.ApproveGenContract.Approve)
					{
						//14 โครงการ ไม่มีลงนาม จะไป State ผูกพัน
						if (indata.ParameterCondition.ContractTypeId == "14")
						{
							await _repo.ContractShare.UpdateStatusContract(new ParameterStatusStation()
							{
								IdSmctMaster = idSmctMaster,
								Status = ContractStatusAll.S3Approve,
								StationStatusPrev = ContractStationStatusAll.S6ContractNumber,
								StationStatusCurr = ContractStationStatusAll.S7Binding,
								ItemStatusPrev = ContractStationStatusItemAll.S61WaitNhsoCentralCheckApproval,
								ItemStatusCurr = ContractStationStatusItemAll.S72BindingPaper
							});
						}
						else
						{
							await _repo.ContractShare.UpdateStatusContract(new ParameterStatusStation()
							{
								IdSmctMaster = idSmctMaster,
								Status = ContractStatusAll.S1WaitApprove,
								StationStatusPrev = ContractStationStatusAll.S6ContractNumber,
								StationStatusCurr = ContractStationStatusAll.S5Signing2,
								ItemStatusPrev = ContractStationStatusItemAll.S61WaitNhsoCentralCheckApproval,
								ItemStatusCurr = ContractStationStatusItemAll.S51WaitSigning2
							});
						}
					}
					if (indata.ApproveGenContract.UnApproveVendor)
					{
						//ตีกลับไปที่ หน่วยบริการ
						await _repo.ContractShare.UpdateStatusContract(new ParameterStatusStation()
						{
							IdSmctMaster = idSmctMaster,
							Status = ApprovalReqStatus.S2UnApprove,
							StationStatusPrev = ContractStationStatusAll.S6ContractNumber,
							StationStatusCurr = ContractStationStatusAll.S1Draft,
							ItemStatusPrev = ContractStationStatusItemAll.S641RejectToVendor,
							ItemStatusCurr = ContractStationStatusItemAll.S13Reject,
							SbbRemark = indata.ApproveGenContract.Remark,
							FRetarn = F_RETARN.REJECT
						});
					}
					if (indata.ApproveGenContract.UnApproveNhso)
					{
						//ตีกลับไปที่ สปสช.เขต
						await _repo.ContractShare.UpdateStatusContract(new ParameterStatusStation()
						{
							IdSmctMaster = idSmctMaster,
							Status = ApprovalReqStatus.S2UnApprove,
							StationStatusPrev = ContractStationStatusAll.S6ContractNumber,
							StationStatusCurr = ContractStationStatusAll.S4CreateContract,
							ItemStatusPrev = ContractStationStatusItemAll.S642RejectToVendorNhso,
							ItemStatusCurr = ContractStationStatusItemAll.S41WaitNhsoCreateContract,
							SbbRemark = indata.ApproveGenContract.Remark,
							FRetarn = F_RETARN.REJECT
						});
					}

					_transaction.Commit();
				}
			}
		}

		public async Task<string> ContractNumberRunning()
		{
			int budgetYear = new ThaiBuddhistCalendar().GetYear(DateTime.Now);

			//ปีงบประมาณใหม่
			if (DateTime.Now.Month >= 10 && DateTime.Now.Day >= 1)
				budgetYear++;

			var query = await _repo.Context.Contracts.OrderByDescending(x => x.ContractId).FirstOrDefaultAsync(x => x.Used && x.ContractId != null);

			String _BudgetYear = budgetYear.ToString().Substring(2);
			if (query == null)
			{
				return $"{_BudgetYear}/B/00001";
			}

			var ContractId = int.Parse(query.ContractId.Substring(5)) + 1;
			return $"{_BudgetYear}/B/{ContractId.ToString("00000")}";

		}

		//CheckList
		public async Task<TAllMasterVendorView> ViewCheckList(TAllMasterVendorView indata)
		{
			var _IdContract = indata.ParameterCondition.IdContract;
			var _IdContractType = indata.ParameterCondition.IdContractType;

			var _ContractSbbCklHeadings = await _repo.Context.ContractSbbCklHeadings.Where(x => x.IdContractType == _IdContractType && x.Used).OrderBy(x => x.L1Item).ThenBy(x => x.L2Item).ThenBy(x => x.DetailItem).ToListAsync();
			if (_ContractSbbCklHeadings.Count > 0)
			{
				foreach (var item in _ContractSbbCklHeadings)
				{
					indata.CheckListMain.ContractSbbCkl.ContractSbbCklDetails.Add(new ContractSbbCklDetailDTO()
					{
						IdContractSbbCklHeading = item.IdContractSbbCklHeading,
						DetailItem = item.DetailItem,
						FCb = item.FCb
					});
				}
			}

			var _ContractSbbCkls = await _repo.Context.ContractSbbCkls.Include(x => x.ChecklistUserNavigation).Where(x => x.IdContract == _IdContract).ToListAsync();
			if (_ContractSbbCkls != null)
			{
				foreach (var item in _ContractSbbCkls)
				{
					ContractSbbCklDTO ContractSbbCkl = _mapper.Map<ContractSbbCklDTO>(item);
					ContractSbbCkl.ChecklistUserFullname = item.CreateUserNavigation.UserFullname;
					indata.CheckListMain.ContractSbbCklHistory.Add(ContractSbbCkl);
				}
			}

			return indata;
		}

		public async Task UpdateCheckList(TAllMasterVendorView indata)
		{
			String idUserSmct = _repo.UserService.GetIdUserSmct();
			var _IdContract = indata.ParameterCondition.IdContract;
			var _ContractSbbCklDetail = indata.CheckListMain.ContractSbbCkl.ContractSbbCklDetails;

			if (_ContractSbbCklDetail.Count > 0)
			{
				String _Status = ContractStationStatusItemAll.S63NhsoCentralContractId;
				if (indata.ApproveGenContract.UnApproveNhso)
					_Status = ContractStationStatusItemAll.S642RejectToVendorNhso;
				if (indata.ApproveGenContract.UnApproveVendor)
					_Status = ContractStationStatusItemAll.S641RejectToVendor;

				var _ContractSbbCkl = new ContractSbbCkl()
				{
					IdContract = _IdContract,
					ChecklistId = await this.CheckListNumberRunning(),
					ChecklistUser = idUserSmct,
					ChecklistDate = DateTime.Now,
					CreateUser = idUserSmct,
					EditUser = idUserSmct,
					CreateDate = DateTime.Now,
					EditDate = DateTime.Now,
					Used = true,
					Status = _Status,
					Remark = indata.ApproveGenContract.Remark
				};
				await _db.InsterAsync(_ContractSbbCkl);
				await _db.SaveAsync();

				foreach (var item in _ContractSbbCklDetail)
				{
					var ContractSbbCklDetail = new ContractSbbCklDetail()
					{
						IdContractSbbCkl = _ContractSbbCkl.IdContractSbbCkl,
						IdContractSbbCklHeading = item.IdContractSbbCklHeading,
						C1 = item.C1,
						C2 = item.C2,
						C3 = item.C3,
						CDetail = item.CDetail,
						CreateUser = idUserSmct,
						EditUser = idUserSmct,
						CreateDate = DateTime.Now,
						EditDate = DateTime.Now,
						Used = true
					};
					await _db.InsterAsync(ContractSbbCklDetail);
					await _db.SaveAsync();
				}
			}
		}

		public async Task<ContractSbbCklDTO> CheckListHistory(string ChecklistId, string IdContractType)
		{
			ContractSbbCklDTO ContractSbbCkl = new ContractSbbCklDTO();
			var _ContractSbbCkls = await _repo.Context.ContractSbbCkls.Where(x => x.ChecklistId == ChecklistId).FirstOrDefaultAsync();
			if (_ContractSbbCkls != null)
			{
				ContractSbbCkl = _mapper.Map<ContractSbbCklDTO>(_ContractSbbCkls);

				var _ContractSbbCklHeadings = await _repo.Context.ContractSbbCklHeadings.Where(x => x.IdContractType == IdContractType && x.Used).OrderBy(x => x.L1Item).ThenBy(x => x.L2Item).ThenBy(x => x.DetailItem).ToListAsync();
				if (_ContractSbbCklHeadings.Count > 0)
				{
					foreach (var item in _ContractSbbCklHeadings)
					{
						var _ContractSbbCklDetails = await _repo.Context.ContractSbbCklDetails.FirstOrDefaultAsync(x => x.IdContractSbbCkl == _ContractSbbCkls.IdContractSbbCkl && x.IdContractSbbCklHeading == item.IdContractSbbCklHeading);
						if (_ContractSbbCklDetails != null)
						{
							ContractSbbCkl.ContractSbbCklDetails.Add(new ContractSbbCklDetailDTO()
							{
								DetailItem = item.DetailItem,
								C1 = _ContractSbbCklDetails.C1,
								C2 = _ContractSbbCklDetails.C2,
								C3 = _ContractSbbCklDetails.C3,
								CDetail = _ContractSbbCklDetails.CDetail,
								FCb = item.FCb
							});
						}
						else
						{
							ContractSbbCkl.ContractSbbCklDetails.Add(new ContractSbbCklDetailDTO()
							{
								DetailItem = item.DetailItem,
								FCb = item.FCb
							});
						}

					}
				}


			}

			return ContractSbbCkl;
		}

		public async Task<string> CheckListNumberRunning()
		{
			int budgetYear = new ThaiBuddhistCalendar().GetYear(DateTime.Now);

			//ปีงบประมาณใหม่
			if (DateTime.Now.Month >= 10 && DateTime.Now.Day >= 1)
				budgetYear++;

			var query = await _repo.Context.ContractSbbCkls.OrderByDescending(x => x.ChecklistId).FirstOrDefaultAsync(x => x.Used && x.ChecklistId != null);

			String _BudgetYear = budgetYear.ToString().Substring(2);
			if (query == null)
			{
				return $"{_BudgetYear}/C/00001";
			}

			var ChecklistId = int.Parse(query.ChecklistId.Substring(5)) + 1;
			return $"{_BudgetYear}/C/{ChecklistId.ToString("00000")}";

		}

		//ขอแก้ไขหลังผูกพัน
		public async Task UpdateRequestBinding(TAllMasterVendorView indata)
		{
			int btnSubmit = int.Parse(indata.BtnSubmit);
			String idUserSmct = _repo.UserService.GetIdUserSmct();
			var _ParameterCon = indata.ParameterCondition;


			if (!indata.ApproveBinding.Approve && !indata.ApproveBinding.UnApprove)
				throw new Exception("ระบุผลการตรวจสอบ");
			if (indata.ApproveBinding.UnApprove)
			{
				if (indata.ApproveBinding.Remark == null)
					throw new Exception("ระบุหมายเหตุ");
			}

			String _SuccessStatus = ContractStatusAll.S3Approve;
			if (indata.ApproveBinding.UnApprove)
				_SuccessStatus = ContractStatusAll.S2UnApprove;

			String _ContractStatus = ContractStatusAll.S3Approve; //S3=ใช้งาน
			if (btnSubmit == (int)ButtonState.T2_CANCEL)
				_ContractStatus = ContractStatusAll.S0Cancel;
			if (btnSubmit == (int)ButtonState.T4_CLOSEPROJECT)
				_ContractStatus = ContractStatusAll.S4CloseProject;
			if (btnSubmit == (int)ButtonState.T5_TERMINATE)
				_ContractStatus = ContractStatusAll.S5Terminate;

			var contractStationSuccesses = await _repo.Context.ContractStationSuccesses.FirstOrDefaultAsync(x => x.IdSmctMaster == _ParameterCon.IdSmctMaster && x.Used && x.StationStatusCurr == "S7");
			//ไม่ต้อง update เพราะจะติดตามสถานะไม่ได้ ถ้าถูก update อีกครั้งตอนหน่วยบริการขอแก้ไขมาใหม่
			//contractStationSuccesses.ContractSuccessType = ContractSuccessTypes.TA_NORMAL;
			contractStationSuccesses.ContractSuccessStatus = _SuccessStatus;
			contractStationSuccesses.ContractSuccessRemarkKet = indata.ApproveBinding.Remark;
			contractStationSuccesses.ContractSuccessEditUser = idUserSmct;
			contractStationSuccesses.ContractSuccessEditDate = DateTime.Now;
			contractStationSuccesses.ContractStatus = _ContractStatus;
			_db.Update(contractStationSuccesses);
			await _db.SaveAsync();

			var _Contracts = await _repo.Context.Contracts.FirstOrDefaultAsync(x => x.IdSmctMaster == _ParameterCon.IdSmctMaster && x.Used);
			if (_Contracts != null)
			{
				String _ContractStatusMain = _Contracts.Status;
				if (btnSubmit == (int)ButtonState.T2_CANCEL)
					_ContractStatusMain = ContractStatusAll.S0Cancel;
				if (btnSubmit == (int)ButtonState.T4_CLOSEPROJECT)
					_ContractStatusMain = ContractStatusAll.S4CloseProject;
				if (btnSubmit == (int)ButtonState.T5_TERMINATE)
					_ContractStatusMain = ContractStatusAll.S5Terminate;

				_Contracts.Status = _ContractStatusMain;
				_Contracts.EditDate = DateTime.Now;
				_db.Update(_Contracts);
				await _db.SaveAsync();
			}

		}

		private void HandleUploadfile(IFormFile FormFile, String fileFTP, String folderName)
		{
			//UploadFilesResource saveFile = new UploadFilesResource()
			//{
			//    Files = new List<IFormFile> { FormFile },
			//    ContentRootPath = _env.ContentRootPath,
			//    SubDirectory = @$"wwwroot\files\{folderName}\",
			//    FileNameServer = fileFTP
			//};
			//await _repo.UploadFiles.SaveFile(saveFile);
			_repo.UploadFiles.FTPSaveFile(FormFile, fileFTP, folderName);
		}

		public async Task UpdateEXPAND(TAllMasterVendorView indata)
		{
			using (var _transaction = _repo.BeginTransaction())
			{
				String _Status = ContractStatusAll.S3Approve;
				String idUserSmct = _repo.UserService.GetIdUserSmct();
				var _ParameterCon = indata.ParameterCondition;
				//ข้อมูลนิติกรรมสัญญา(วันที่เริ่มต้น-สิ้นสุด)     
				if (indata.ApproveBinding.Approve)
				{
					_repo.ContractShareNhso.ValidateEXPAND(indata);
					await _repo.ContractShareNhso.UpdateInfoContract(indata);

					var contractTypes = _repo.Context.ContractTypes.FirstOrDefault(x => x.ContractTypeId == indata.ParameterCondition.ContractTypeId);
					if (contractTypes != null)
					{
						if (contractTypes.FPay)
						{
							await _repo.ContractShareNhso.UpdateConditionPayment(indata);
						}
					}
				}
				else
				{
					_Status = ContractStatusAll.S2UnApprove;
				}

				ContractExtend _ContractExtend = await _repo.Context.ContractExtends.OrderByDescending(x => x.EditDate).FirstOrDefaultAsync(x => x.IdContract == _ParameterCon.IdContract && x.Used);
				_ContractExtend.Status = _Status;
				_ContractExtend.EditUser = idUserSmct;
				_ContractExtend.EditDate = DateTime.Now;
				_db.Update(_ContractExtend);
				await _db.SaveAsync();

				await _repo.ContractShareNhso.UpdateRequestBinding(indata);

				_transaction.Commit();
			}
		}

		public async Task ApproveVendorLink(RegisterMaster indata)
		{
			using (var _transaction = _repo.BeginTransaction())
			{
				var indataPara = indata.ParameterCondition;

				var registerNhsos = _repo.Context.RegisterNhsos.FirstOrDefault(x => x.Used && x.IdRegisterNhso == indata.RegisterNhso.IdRegisterNhso);
				if (String.IsNullOrEmpty(registerNhsos.VendorId))
					throw new Exception("ยังไม่ได้รหัสคู่สัญญา");

				String _IdUserSmct = SecurityRepo.Decrypt(indataPara.Idvl);
				var userSmctVendors = _repo.Context.UserSmctVendors.FirstOrDefault(x => x.Used && x.IdUserSmct == _IdUserSmct && x.IdRegisterNhso == indata.RegisterNhso.IdRegisterNhso);
				userSmctVendors.VendorId = registerNhsos.VendorId;
				_db.Update(userSmctVendors);
				await _db.SaveAsync();

				var approvalReqStations = _repo.Context.ApprovalReqStations.FirstOrDefault(x => x.Used && x.CreateUser == _IdUserSmct);
				if (approvalReqStations != null)
				{
					approvalReqStations.VendorId = registerNhsos.VendorId;
					approvalReqStations.VendorName = registerNhsos.VendorName;
					_db.Update(approvalReqStations);
					await _db.SaveAsync();
				}

				await _repo.ContractShare.UpdateStatusVendorLink(new ParameterStatusStation()
				{
					IdSmctMaster = indataPara.IdSmctMaster,
					Status = ContractStatusAll.S3Approve,
					StationStatusPrev = VendorLinkStationStatusAll.S2Check,
					StationStatusCurr = VendorLinkStationStatusAll.S3VendorSuccess,
					ItemStatusPrev = VendorLinkStationStatusItemAll.S22GenVendor,
					ItemStatusCurr = VendorLinkStationStatusItemAll.S31GenVendorSuccess,
					VendorId = registerNhsos.VendorId,
					VendorName = registerNhsos.VendorName
				});

				await _repo.ContractShare.UpdateStatusContract(new ParameterStatusStation()
				{
					IdSmctMaster = indataPara.IdSmctMaster,
					StationStatusPrev = ContractStationStatusAll.S3SetVendor,
					StationStatusCurr = ContractStationStatusAll.S4CreateContract,
					ItemStatusPrev = ContractStationStatusItemAll.S31WaitSetVendor,
					ItemStatusCurr = ContractStationStatusItemAll.S31SetVendorForward
				});

				_transaction.Commit();
			}
		}

		public async Task<ResourceEmail> GetSentMailReqApp(TAllMasterVendorView indata, string htmlBody)
		{
			var builder = new BodyBuilder();

			String emailSent = String.Empty;

			if (!String.IsNullOrEmpty(indata.InfoRequestForApproval.ApprovalReqUser))
			{
				var vNhsoEmployeeAlls = await _repo.Context.VNhsoEmployeeAlls.Where(x => x.PersonNhsoMail != null).ToListAsync();
				if (vNhsoEmployeeAlls != null)
				{
					vNhsoEmployeeAlls.Add(new VNhsoEmployeeAll()
					{
						EmpId = "EM001",
						PersonNhsoMail = "ti-claim@nhso.go.th"
					});
					var vNhsoEmployeeAllsFirst = vNhsoEmployeeAlls.FirstOrDefault(x => x.EmpId == indata.InfoRequestForApproval.ApprovalReqUser);
					if (vNhsoEmployeeAllsFirst != null)
					{
						emailSent = vNhsoEmployeeAllsFirst.PersonNhsoMail;
					}
				}
			}

			String _RefId = indata.InfoContract != null ? indata.InfoContract.RefId : String.Empty;

			builder.HtmlBody = htmlBody;
			String _Subject = "Approve Request";

			return new ResourceEmail()
			{
				Builder = builder,
				Subject = _Subject,
				Message = htmlBody,
				Email = emailSent,
				Template = _Subject,
				RefId = _RefId
			};
		}

		public async Task<ResourceEmail> GetSentMainToConsider(TAllMasterVendorView indata, string htmlBody)
		{
			var builder = new BodyBuilder();

			String emailSent = String.Empty;

			String idSmctMaster = indata.ParameterCondition.IdSmctMaster;
			var smctMasters = await _repo.Context.SmctMasters.FirstOrDefaultAsync(x => x.IdSmctMaster == idSmctMaster);
			if (smctMasters != null)
			{
				var vNhsoBorads = await _repo.Context.VNhsoBorads.FirstOrDefaultAsync(x => x.BoradType == "D" && x.DepartmentCode == smctMasters.DepartmentCode);
				if (vNhsoBorads != null)
				{
					emailSent = vNhsoBorads.BoradEmail;
				}
			}

			String _RefId = indata.InfoContract != null ? indata.InfoContract.RefId : String.Empty;

			builder.HtmlBody = htmlBody;
			String _Subject = "Approve Request Consider";

			return new ResourceEmail()
			{
				Builder = builder,
				Subject = _Subject,
				Message = htmlBody,
				Email = emailSent,
				Template = _Subject,
				RefId = _RefId
			};
		}

		public async Task<ResourceEmail> GetSentMailSigner(TAllMasterVendorView indata, string htmlBody)
		{
			var builder = new BodyBuilder();
			String emailSent = String.Empty;

			if (!String.IsNullOrEmpty(indata.ContractStation.CreateUser))
			{
				var userSmcts = await _repo.Context.UserSmcts.FirstOrDefaultAsync(x => x.IdUserSmct == indata.ContractStation.CreateUser && x.Used);
				if (userSmcts != null)
				{
					emailSent = userSmcts.Email;
				}
			}

			String _RefId = indata.InfoContract != null ? indata.InfoContract.RefId : String.Empty;

			builder.HtmlBody = htmlBody;
			String _Subject = "Signer";
			if (indata.ParameterCondition.StationReq == ApproveStationStatusAll.S3Consider)
			{
				_Subject = "Signer";
			}

			return new ResourceEmail()
			{
				Builder = builder,
				Subject = _Subject,
				Message = htmlBody,
				Email = emailSent,
				Template = _Subject,
				RefId = _RefId
			};
		}

	}
}
