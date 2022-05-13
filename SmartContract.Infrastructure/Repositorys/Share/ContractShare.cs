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
using SmartContract.Infrastructure.Resources.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.ContractTypeVendor.Information;
using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Enum;
using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Infrastructure.Wrapper;
using SmartContract.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using static SmartContract.Infrastructure.Resources.ContractTypeVendor.Information.InfoSignerPartnersOfContract;

namespace SmartContract.Infrastructure.Repositorys.Share
{
	public class ContractShare : IContractShare
	{
		private IRepositoryWrapper _repo;
		private readonly IMapper _mapper;
		private readonly IRepositoryBase _db;
		private readonly AppSettings _mySet;
		private readonly IWebHostEnvironment _env;

		public ContractShare(IRepositoryWrapper repo, IRepositoryBase db, IMapper mapper, IWebHostEnvironment env, IOptions<AppSettings> settings)
		{
			_repo = repo;
			_db = db;
			_env = env;
			_mapper = mapper;
			_mySet = settings.Value;
		}

		public string SetUrlRedirect(TAllMasterVendorView indata)
		{
			String UrlRedirect = String.Empty;

			int btnSubmit = int.Parse(indata.BtnSubmit);
			bool IsUrlOld = true;
			String _SectorType = indata.ParameterCondition.Sector == Sectors.Government ? "2" : String.Empty;
			if (btnSubmit == (int)ButtonState.Draft || btnSubmit == (int)ButtonState.SignerWitness || btnSubmit == (int)ButtonState.Signer)
			{
				if (btnSubmit == (int)ButtonState.Signer)
				{
					var contractStations = _repo.Context.ContractStations.Where(x => x.IdSmctMaster == indata.ParameterCondition.IdSmctMaster && x.Used).FirstOrDefault();
					if (contractStations.StationStatusCurr == ContractStationStatusAll.S6ContractNumber)
					{
						IsUrlOld = false;
						UrlRedirect = $"{_mySet.SubDomainServer}/homevendor/tracking{_SectorType}?style={indata.ParameterCondition.Style}";
					}
					else
						IsUrlOld = true;
				}

				if (IsUrlOld)
				{
					UrlRedirect = $"{_mySet.SubDomainServer}/ContractTypeVendor/T{indata.ParameterCondition.ContractTypeId}?style={indata.ParameterCondition.Style}";
					if (!String.IsNullOrEmpty(indata.ParameterCondition.Station))
					{
						UrlRedirect = $"{UrlRedirect}&Station={indata.ParameterCondition.Station}";
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
			}
			else if (btnSubmit == (int)ButtonState.Forward)
			{
				UrlRedirect = $"../homevendor/tracking{_SectorType}?style={indata.ParameterCondition.Style}";
			}
			else if (btnSubmit == (int)ButtonState.T0_CANCEL || btnSubmit == (int)ButtonState.T1_EDIT
					|| btnSubmit == (int)ButtonState.T2_CANCEL
					|| btnSubmit == (int)ButtonState.T3_EXPAND
					|| btnSubmit == (int)ButtonState.T4_CLOSEPROJECT
					|| btnSubmit == (int)ButtonState.T5_TERMINATE)
			{
				UrlRedirect = $"{_mySet.SubDomainServer}/homevendor/TrackingBinding?Menuen={indata.ParameterCondition.MenuEn}";
				if (!String.IsNullOrEmpty(indata.ParameterCondition.ContractSuccessTypeEn))
				{
					UrlRedirect = $"{UrlRedirect}&ContractSuccessTypeEn={indata.ParameterCondition.ContractSuccessTypeEn}";
				}
			}
			else
			{
				UrlRedirect = $"../homevendor/tracking{_SectorType}?style={indata.ParameterCondition.Style}";
			}

			return UrlRedirect;
		}

		//Validate
		public void ValidateGuaranteeContract(TAllMasterVendorView indata)
		{
			//ข้อมูลหลักประกันสัญญา
			if (!indata.InfoGuaranteeContract.GuaranteeType1
				&& !indata.InfoGuaranteeContract.GuaranteeType2
				&& !indata.InfoGuaranteeContract.GuaranteeType3
				&& !indata.InfoGuaranteeContract.GuaranteeType4)
				throw new Exception("ระบุหลักประกันสัญญา");

			//หักจากเงินโอนงวดที่ 1
			//if (indata.InfoGuaranteeContract.GuaranteeType4)
			//    if (!indata.InfoGuaranteeContract.DeductedAmountMoney.HasValue/* || indata.InfoGuaranteeContract.DeductedAmountMoney == 0*/)
			//        throw new Exception("ระบุจำนวนเงินหักจากเงินโอนงวดที่ 1");
			//เงินสด
			if (indata.InfoGuaranteeContract.GuaranteeType1)
				if (!indata.InfoGuaranteeContract.AmountMoney.HasValue/* || indata.InfoGuaranteeContract.AmountMoney == 0*/)
					throw new Exception("ระบุจำนวนเงินสด");
			//แคชเชียร์เช็ค
			if (indata.InfoGuaranteeContract.GuaranteeType2)
			{
				if (indata.InfoGuaranteeContract.CashierChequeDesc == null && indata.InfoGuaranteeContract.CashierChequeDesc.Count == 0)
				{
					throw new Exception("ระบุแคชเชียร์เช็ค");
				}
				else
				{
					foreach (var item in indata.InfoGuaranteeContract.CashierChequeDesc)
					{
						if (String.IsNullOrEmpty(item.BankCode) || String.IsNullOrEmpty(item.CheckNumber) || String.IsNullOrEmpty(item.DateStr) || item.AmountMoney == null || item.AmountMoney.Value == 0)
							throw new Exception("ระบุแคชเชียร์เช็คไม่ครบถ้วน");
					}
				}
			}
			//หนังสือค้ำประกัน
			if (indata.InfoGuaranteeContract.GuaranteeType3)
			{
				if (indata.InfoGuaranteeContract.BookGuaranteeDesc == null && indata.InfoGuaranteeContract.BookGuaranteeDesc.Count == 0)
				{
					throw new Exception("ระบุหนังสือค้ำประกัน");
				}
				else
				{
					foreach (var item in indata.InfoGuaranteeContract.BookGuaranteeDesc)
					{
						if (String.IsNullOrEmpty(item.BankCode) || String.IsNullOrEmpty(item.BookNumber)
							|| String.IsNullOrEmpty(item.StartDateStr) || String.IsNullOrEmpty(item.EndDateStr)
							|| item.AmountMoney == null || item.AmountMoney.Value == 0)
							throw new Exception("ระบุหนังสือค้ำประกันไม่ครบถ้วน");
					}
				}
			}
		}

		//VIEW
		public async Task<TAllMasterVendorView> ViewInfoContract(TAllMasterVendorView indata)
		{
			String idSmctMaster = indata.ParameterCondition.IdSmctMaster;
			if (indata.ParameterCondition.DepartmentCodeCurr == null)
				indata.ParameterCondition.DepartmentCodeCurr = _repo.UserService.GetDepartmentCode();

			if (indata.ParameterCondition.IdUserSmctCurr == null)
				indata.ParameterCondition.IdUserSmctCurr = _repo.UserService.GetIdUserSmct();

			if (indata.ParameterCondition.VendorIdCurr == null)
				indata.ParameterCondition.VendorIdCurr = _repo.UserService.GetVendorId();

			var indataPara = indata.ParameterCondition;

			var departmentCode = _repo.UserService.GetDepartmentCode();
			var idUserSmct = _repo.UserService.GetIdUserSmct();
			var vendorId = _repo.UserService.GetVendorId();
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

			indata.InfoGuaranteeContract.GetLookUp = indata.CTVendor.GetLookUp;

			indata.InfoContract.BureauSubFundCounty = $"{lkDepartments.Dname} ({lkDepartments.Dcode})";
			indata.InfoContract.ContractTypeFullName = contractTypes.ContractTypeFullName;
			indata.ParameterCondition.ContractTypeFullName = contractTypes.ContractTypeFullName;
			indata.ParameterCondition.ContractTypeId = contractTypes.ContractTypeId;
			indata.ParameterCondition.IdContractType = contractTypes.IdContractType;

			if (!String.IsNullOrEmpty(indata.ParameterCondition.SigningTypeEn))
				indata.InfoContract.SigningType = ContractUtils.SigningTypes(SecurityRepo.Decrypt(indata.ParameterCondition.SigningTypeEn)).Description;

			var smctMasters = await _repo.Context.SmctMasters.Where(x => x.IdSmctMaster == idSmctMaster && x.Used).FirstOrDefaultAsync();
			if (smctMasters != null)
			{
				indata.ParameterCondition.IdSmctMaster = smctMasters.IdSmctMaster;
				indata.InfoContract.RefId = smctMasters.RefId;
				indata.InfoContract.RefDate = smctMasters.RefDate;
			}

			var _Contract = await _repo.Context.Contracts.Where(x => x.IdSmctMaster == idSmctMaster && x.Used).FirstOrDefaultAsync();
			if (_Contract != null)
			{
				indata.InfoContract.ContractId = _Contract.ContractId;
				indata.InfoContract.ContractDate = _Contract.ContractDate;
				indata.ParameterCondition.IdContract = _Contract.IdContract;
				indata.InfoContract.PayVendorTypeD = _Contract.PayVendorType == "D";
				indata.InfoContract.PayVendorTypeI = _Contract.PayVendorType == "I";
				indata.InfoContract.Budget = _Contract.Budget;
			}


			return indata;
		}

		public async Task<TAllMasterVendorView> ViewRequestForApproval(TAllMasterVendorView indata)
		{
			String idSmctMaster = indata.ParameterCondition.IdSmctMaster;
			var approvalReqs = await _repo.Context.ApprovalReqs.Where(x => x.IdSmctMaster == idSmctMaster && x.Used).FirstOrDefaultAsync();
			if (approvalReqs != null)
			{
				indata.InfoRequestForApproval.ContractName = approvalReqs.ContractName;
				indata.InfoRequestForApproval.Reason = approvalReqs.Reason;
				indata.InfoRequestForApproval.CoordinatorUserSelect = approvalReqs.CoordinatorUser;
				indata.InfoRequestForApproval.Email = approvalReqs.Email;
				indata.InfoRequestForApproval.Phone = approvalReqs.Phone;
				indata.InfoRequestForApproval.Fax = approvalReqs.Fax;
				indata.InfoRequestForApproval.ApprovalReqUser = approvalReqs.ApprovalReqUser;
				indata.InfoRequestForApproval.ApprovalReqUserPos = approvalReqs.ApprovalReqUserPos;
				indata.InfoRequestForApproval.ApprovalReqId = approvalReqs.ApprovalReqId;
				indata.InfoRequestForApproval.ApprovalReqDate = approvalReqs.ApprovalReqDate;
			}
			return indata;
		}

		public async Task<TAllMasterVendorView> ViewGuaranteeContract(TAllMasterVendorView indata)
		{
			String idSmctMaster = indata.ParameterCondition.IdSmctMaster;
			var contractGuarantees = await _repo.Context.ContractGuarantees.Where(x => x.IdSmctMaster == idSmctMaster && x.Used).ToListAsync();
			if (contractGuarantees != null && contractGuarantees.Count > 0)
			{
				foreach (var item_main in contractGuarantees)
				{
					var contractGuaranteeDetails = await _repo.Context.ContractGuaranteeDetails.Where(x => x.IdContractGuarantee == item_main.IdContractGuarantee && x.Used).ToListAsync();
					if (item_main.GuaranteeType == GuaranteeTypes.DeductedTransfer1 && contractGuaranteeDetails.Count == 1)
					{

						indata.InfoGuaranteeContract.IdContractGuaranteeDetail = contractGuaranteeDetails[0].IdContractGuaranteeDetail;
						indata.InfoGuaranteeContract.GuaranteeType4 = true;
						indata.InfoGuaranteeContract.DeductedAmountMoney = contractGuaranteeDetails[0].Amount;
					}
					if (item_main.GuaranteeType == GuaranteeTypes.Cash && contractGuaranteeDetails.Count == 1)
					{
						indata.InfoGuaranteeContract.IdContractGuaranteeDetail = contractGuaranteeDetails[0].IdContractGuaranteeDetail;
						indata.InfoGuaranteeContract.GuaranteeType1 = true;
						indata.InfoGuaranteeContract.AmountMoney = contractGuaranteeDetails[0].Amount;
					}
					if (item_main.GuaranteeType == GuaranteeTypes.CashierCheck)
					{
						indata.InfoGuaranteeContract.GuaranteeType2 = true;
						foreach (var item in contractGuaranteeDetails)
						{
							indata.InfoGuaranteeContract.CashierChequeDesc.Add(new CashierChequeDescription()
							{
								IdContractGuaranteeDetail = item.IdContractGuaranteeDetail,
								BankCode = item.BankId,
								CheckNumber = item.CashierId,
								DateStr = GeneralUtils.DateToThString(item.CashierDate),
								AmountMoney = item.Amount
							});
						}
					}
					if (item_main.GuaranteeType == GuaranteeTypes.BookGuarantee)
					{
						indata.InfoGuaranteeContract.GuaranteeType3 = true;
						foreach (var item in contractGuaranteeDetails)
						{
							indata.InfoGuaranteeContract.BookGuaranteeDesc.Add(new BookGuaranteeDescription()
							{
								IdContractGuaranteeDetail = item.IdContractGuaranteeDetail,
								BankCode = item.BankId,
								BookNumber = item.GuaranteeDocId,
								StartDateStr = GeneralUtils.DateToThString(item.GuaranteeDocStartDate),
								EndDateStr = GeneralUtils.DateToThString(item.GuaranteeDocEndDate),
								AmountMoney = item.Amount
							});
						}
					}
				}

			}

			return indata;
		}

		public async Task<TAllMasterVendorView> ViewInfoPartnersOfContract(TAllMasterVendorView indata, String VendorId)
		{
			String idSmctMaster = indata.ParameterCondition.IdSmctMaster;
			var _ParameterCon = indata.ParameterCondition;

			//รายละเอียดคู่สัญญา
			String _IdRegisterNhso = String.Empty;
			if (String.IsNullOrEmpty(VendorId))
			{
				//เฉพาะหน่วยบริการที่ยังไม่มีรหัสคู่สัญญา จะมีแค่ครั้งแรก
				var userSmctVendors = await _repo.Context.UserSmctVendors.FirstOrDefaultAsync(x => x.IdUserSmct == _ParameterCon.IdUserSmctCurr);
				if (userSmctVendors != null)
				{
					_IdRegisterNhso = userSmctVendors.IdRegisterNhso;
				}
			}

			//รายละเอียดคู่สัญญา
			var registerNhsos = await _repo.Context.RegisterNhsos.FirstOrDefaultAsync(x => x.VendorId == VendorId || x.IdRegisterNhso == _IdRegisterNhso);
			if (registerNhsos != null)
			{
				indata.InfoPartnersOfContract.VendorId = registerNhsos.VendorId;
				indata.InfoPartnersOfContract.VendorName = registerNhsos?.VendorName ?? "-";
				if (registerNhsos.Catm != null)
				{
					indata.InfoPartnersOfContract.CATMs = _repo.GeneralRepo.GetCATM(registerNhsos.Catm);
				}
				indata.InfoPartnersOfContract.Moo = registerNhsos.Moo;
				indata.InfoPartnersOfContract.ZipCpde = registerNhsos.PostCode;
				indata.InfoPartnersOfContract.TelephoneNumber = registerNhsos.Phone;
				indata.InfoPartnersOfContract.TaxNumber = registerNhsos.TaxId;
				indata.InfoPartnersOfContract.VillageNo = registerNhsos.VillageNo;
				indata.InfoPartnersOfContract.Building = registerNhsos.Building;
				indata.InfoPartnersOfContract.Soi = registerNhsos.Soi;
				indata.InfoPartnersOfContract.Road = registerNhsos.Road;
				indata.InfoPartnersOfContract.TaxId = registerNhsos.TaxId;
			}

			//รายละเอียดคู่สัญญา
			//var vMasterVendors = await _repo.Context.VMasterVendors.FirstOrDefaultAsync(x => x.VendorId == VendorId);
			//if (vMasterVendors != null)
			//{
			//    indata.InfoPartnersOfContract.VendorId = vMasterVendors.VendorId;
			//    indata.InfoPartnersOfContract.VendorName = vMasterVendors.VendorName;
			//    if (vMasterVendors.Catm != null)
			//    {
			//        indata.InfoPartnersOfContract.CATMs = _repo.GeneralRepo.GetCATM(vMasterVendors.Catm);
			//    }
			//    indata.InfoPartnersOfContract.Moo = vMasterVendors.Moo;
			//    indata.InfoPartnersOfContract.ZipCpde = vMasterVendors.PostCode;
			//    indata.InfoPartnersOfContract.TelephoneNumber = vMasterVendors.Phone;
			//    indata.InfoPartnersOfContract.TaxNumber = vMasterVendors.TaxId;
			//    indata.InfoPartnersOfContract.VillageNo = vMasterVendors.VillageNo;
			//    indata.InfoPartnersOfContract.Building = vMasterVendors.Building;
			//    indata.InfoPartnersOfContract.Soi = vMasterVendors.Soi;
			//    indata.InfoPartnersOfContract.Road = vMasterVendors.Road;
			//    indata.InfoPartnersOfContract.TaxId = vMasterVendors.TaxId;
			//}

			if (idSmctMaster != null)
			{
				var MasterSigners = _repo.Context.SmctMasterSigners.FirstOrDefault(x => x.IdSmctMaster == idSmctMaster);
				if (MasterSigners != null)
				{
					var masterSignerDetail1s = _repo.Context.SmctMasterSignerDetail1s.FirstOrDefault(x => x.IdSmctMasterSigner == MasterSigners.IdSmctMasterSigner);
					if (masterSignerDetail1s != null)
					{
						indata.ParameterCondition.VendorWitnessStatus = masterSignerDetail1s.VendorWitnessStatus;
						indata.ParameterCondition.NhsoWitnessStatus = masterSignerDetail1s.NhsoWitnessStatus;

						indata.InfoPartnersOfContract.SmctMasterSigner.ContractSignerType = MasterSigners.ContractSignerType;
						if (MasterSigners.ContractSignerType == SignerTypes.AuthBySelf)
						{
							indata.InfoPartnersOfContract.SmctMasterSigner.SmctMasterSignerDetail1.VendorSignerUser = masterSignerDetail1s.VendorSignerUser;
						}
						else
						{
							indata.InfoPartnersOfContract.SmctMasterSigner.SmctMasterSignerDetail1.VendorSignerUser2 = masterSignerDetail1s.VendorSignerUser;
						}
					}
				}
			}

			return indata;
		}

		public async Task<TAllMasterVendorView> ViewMasterSigners(TAllMasterVendorView indata)
		{
			var indataPara = indata.ParameterCondition;
			String idSmctMaster = indata.ParameterCondition.IdSmctMaster;

			var smctMasterSigners = await _repo.Context.SmctMasterSigners.FirstOrDefaultAsync(x => x.IdSmctMaster == idSmctMaster && x.Used);
			if (smctMasterSigners != null)
			{
				var smctMasterSignerDetail1s = await _repo.Context.SmctMasterSignerDetail1s.FirstOrDefaultAsync(x => x.IdSmctMasterSigner == smctMasterSigners.IdSmctMasterSigner && x.Used);
				if (smctMasterSignerDetail1s != null)
				{
					//ฝ่ายคู่สัญญา
					indata.InfoSignerPartnersOfContract.VendorSignerUser = smctMasterSignerDetail1s.VendorSignerUser;
					indata.InfoSignerPartnersOfContract.VendorWitnessUser = smctMasterSignerDetail1s.VendorWitnessUser;
					indata.InfoSignerPartnersOfContract.VendorWitnessStatus = smctMasterSignerDetail1s.VendorWitnessStatus;
					if (!String.IsNullOrEmpty(smctMasterSignerDetail1s.VendorFootnoteUser1))
					{
						indata.InfoSignerPartnersOfContract.FootNotes.Add(new FootNoteModel() { IdUserSmct = smctMasterSignerDetail1s.VendorFootnoteUser1 });
					}
					if (!String.IsNullOrEmpty(smctMasterSignerDetail1s.VendorFootnoteUser2))
					{
						indata.InfoSignerPartnersOfContract.FootNotes.Add(new FootNoteModel() { IdUserSmct = smctMasterSignerDetail1s.VendorFootnoteUser2 });
					}
					if (!String.IsNullOrEmpty(smctMasterSignerDetail1s.VendorFootnoteUser3))
					{
						indata.InfoSignerPartnersOfContract.FootNotes.Add(new FootNoteModel() { IdUserSmct = smctMasterSignerDetail1s.VendorFootnoteUser3 });
					}

					//ฝ่ายสำนักงาน
					indata.InfoSignerPartnersOfContract.NhsoSignerUser = smctMasterSignerDetail1s.NhsoSignerUser;
					indata.InfoSignerPartnersOfContract.NhsoWitnessUser = smctMasterSignerDetail1s.NhsoWitnessUser;
					indata.InfoSignerPartnersOfContract.NhsoWitnessStatus = smctMasterSignerDetail1s.NhsoWitnessStatus;
					if (!String.IsNullOrEmpty(smctMasterSignerDetail1s.NhsoFootnoteUser1))
					{
						indata.InfoSignerPartnersOfContract.FootNotesNhso.Add(new FootNoteNhsoModel() { EmpId = smctMasterSignerDetail1s.NhsoFootnoteUser1 });
					}
					if (!String.IsNullOrEmpty(smctMasterSignerDetail1s.NhsoFootnoteUser2))
					{
						indata.InfoSignerPartnersOfContract.FootNotesNhso.Add(new FootNoteNhsoModel() { EmpId = smctMasterSignerDetail1s.NhsoFootnoteUser2 });
					}
					if (!String.IsNullOrEmpty(smctMasterSignerDetail1s.NhsoFootnoteUser3))
					{
						indata.InfoSignerPartnersOfContract.FootNotesNhso.Add(new FootNoteNhsoModel() { EmpId = smctMasterSignerDetail1s.NhsoFootnoteUser3 });
					}

					if ((indataPara.SendmailType == SendmailTypes.NhsoWitness || indataPara.SendmailType == SendmailTypes.NhsoWitnessP) && indata.InfoSignerPartnersOfContract.NhsoWitnessStatus == WitnessStatusAll.W1WitnessUnsigned)
					{
						var nhsoSigners = await _repo.Context.VNhsoSigners.FirstOrDefaultAsync(x => x.EmpId == smctMasterSignerDetail1s.NhsoWitnessUser && x.SignerEmail != null);
						if (nhsoSigners != null)
						{
							var mail = new MailAddress(nhsoSigners.SignerEmail);
							indata.ApproveProposal.UserNameCA = mail.User.ToLower();
						}
					}
					if ((indataPara.SendmailType == SendmailTypes.NhsoAuthority || indataPara.SendmailType == SendmailTypes.NhsoAuthorityP) && indataPara.Station != ContractStationStatusAll.S7Binding)
					{
						var nhsoSigners = await _repo.Context.VNhsoSigners.FirstOrDefaultAsync(x => x.EmpId == smctMasterSignerDetail1s.NhsoSignerUser && x.SignerEmail != null);
						if (nhsoSigners != null)
						{
							var mail = new MailAddress(nhsoSigners.SignerEmail);
							indata.ApproveProposal.UserNameCA = mail.User.ToLower();
						}
					}
				}
			}

			var smctMasterSendmails = await _repo.Context.SmctMasterSendmails.Where(x => x.IdSmctMaster == idSmctMaster && x.Used).ToListAsync();
			indata.MasterSendmail = _mapper.Map<List<SmctMasterSendmailDTO>>(smctMasterSendmails);

			return indata;
		}

		public async Task<TAllMasterVendorView> ViewMasterFiles(TAllMasterVendorView indata)
		{
			String idSmctMaster = indata.ParameterCondition.IdSmctMaster;

			var smctMasterFiles = await _repo.Context.SmctMasterFiles.Where(x => x.IdSmctMaster == idSmctMaster && x.Used).OrderBy(x => x.FileNo).ToListAsync();
			if (smctMasterFiles.Count > 0)
			{
				foreach (var item in smctMasterFiles)
				{
					if (item.FileType == "F1" || item.FileType == "F8")
					{
						indata.InfoAttachDraftContract.SmctMasterFile.Add(new SmctMasterFileDTO
						{
							IdSmctMasterFile = item.IdSmctMasterFile,
							FileName = item.FileName,
							FileType = item.FileType,
							FileFtp = item.FileFtp,
							FileNo = item.FileNo,
							PathFolder = item.PathFolder
						});
					}
					if (item.FileType == "F2")
					{
						indata.InfoAttachDraftContractAppReq.SmctMasterFile.Add(new SmctMasterFileDTO
						{
							IdSmctMasterFile = item.IdSmctMasterFile,
							FileName = item.FileName,
							FileType = item.FileType,
							FileFtp = item.FileFtp,
							FileNo = item.FileNo,
							PathFolder = item.PathFolder
						});
					}
					if (item.FileType == "F3")
					{
						indata.InfoAttachFileRealVersion.SmctMasterFile.Add(new SmctMasterFileDTO
						{
							IdSmctMasterFile = item.IdSmctMasterFile,
							FileName = item.FileName,
							FileType = item.FileType,
							FileFtp = item.FileFtp,
							FileNo = item.FileNo,
							PathFolder = item.PathFolder
						});
					}
					if (item.FileType == "F4" || item.FileType == "F5" || item.FileType == "F6" || item.FileType == "F7" || item.FileType == "F13")
					{
						indata.InfoAttachFileSignature.SmctMasterFile.Add(new SmctMasterFileDTO
						{
							IdSmctMasterFile = item.IdSmctMasterFile,
							FileName = item.FileName,
							FileType = item.FileType,
							FileFtp = item.FileFtp,
							FileNo = item.FileNo,
							PathFolder = item.PathFolder
						});
					}
					if (item.FileType == "F9")
					{
						indata.InfoRequestBinding.SmctMasterFile = new SmctMasterFileDTO()
						{
							IdSmctMasterFile = item.IdSmctMasterFile,
							FileName = item.FileName,
							FileType = item.FileType,
							FileFtp = item.FileFtp,
							FileNo = item.FileNo,
							PathFolder = item.PathFolder
						};
					}
					if (item.FileType == "F10")
					{
						indata.InfoFMPDF.SmctMasterFile_APPROVAL = new SmctMasterFileDTO()
						{
							IdSmctMasterFile = item.IdSmctMasterFile,
							FileName = item.FileName,
							FileType = item.FileType,
							FileFtp = item.FileFtp,
							FileNo = item.FileNo,
							PathFolder = item.PathFolder
						};
					}
					if (item.FileType == "F11")
					{
						indata.InfoFMPDF.SmctMasterFile_CONTRACT = new SmctMasterFileDTO()
						{
							IdSmctMasterFile = item.IdSmctMasterFile,
							FileName = item.FileName,
							FileType = item.FileType,
							FileFtp = item.FileFtp,
							FileNo = item.FileNo,
							PathFolder = item.PathFolder
						};
					}
					if (item.FileType == "F12")
					{
						indata.InfoFMPDF.SmctMasterFile_PAY = new SmctMasterFileDTO()
						{
							IdSmctMasterFile = item.IdSmctMasterFile,
							FileName = item.FileName,
							FileType = item.FileType,
							FileFtp = item.FileFtp,
							FileNo = item.FileNo,
							PathFolder = item.PathFolder
						};
					}
				}
			}

			return indata;
		}

		public async Task<TAllMasterVendorView> ViewApprovalReqStation(TAllMasterVendorView indata)
		{
			String idSmctMaster = indata.ParameterCondition.IdSmctMaster;
			var approvalReq = await _repo.Context.ApprovalReqs.FirstOrDefaultAsync(x => x.IdSmctMaster == idSmctMaster);
			if (approvalReq != null)
			{
				var approvalReqStations = await _repo.Context.ApprovalReqStations.FirstOrDefaultAsync(x => x.IdSmctMaster == idSmctMaster);
				indata.ApprovalReqStation = _mapper.Map<ApprovalReqStationDTO>(approvalReqStations);
				indata.ApprovalReqStation.StatusCheckMail = approvalReq.StatusCheckMail;
				indata.ParameterCondition.StatusReq = approvalReq.Status;
				indata.ParameterCondition.StationReq = approvalReqStations.StationStatusCurr;
				if (!String.IsNullOrEmpty(approvalReq.StatusCheckMail))
				{
					if (approvalReqStations.StationStatusCurr == ApproveStationStatusAll.S3Consider)
					{
						var vNhsoBorads = await _repo.Context.VNhsoBorads.FirstOrDefaultAsync(x => x.DepartmentCode == indata.ParameterCondition.DepartmentCodeCurr);
						if (vNhsoBorads != null)
						{
							var mail = new MailAddress(vNhsoBorads.BoradEmail);
							indata.ApproveProposal.UserNameCA = mail.User;
						}
						else
						{
							var mail = new MailAddress("ti-claim@nhso.go.th");
							indata.ApproveProposal.UserNameCA = mail.User;
						}
					}
					else
					{
						var vNhsoEmployeeAlls = await _repo.Context.VNhsoEmployeeAlls.Where(x => x.PersonNhsoMail != null).ToListAsync();
						if (vNhsoEmployeeAlls != null)
						{
							vNhsoEmployeeAlls.Add(new VNhsoEmployeeAll()
							{
								EmpId = "EM001",
								PersonNhsoMail = "ti-claim@nhso.go.th"
							});
							var vNhsoEmployeeAllsFirst = vNhsoEmployeeAlls.FirstOrDefault(x => x.PersonNhsoMail != null && x.EmpId == indata.InfoRequestForApproval.ApprovalReqUser);
							if (vNhsoEmployeeAllsFirst != null)
							{
								var mail = new MailAddress(vNhsoEmployeeAllsFirst.PersonNhsoMail);
								indata.ApproveProposal.UserNameCA = mail.User;
							}
						}
					}
				}
				if (indata.ParameterCondition.IsPDF)
				{
					var masterVendor = await _repo.MasterData.MasterVendor(vendorId: approvalReqStations.VendorId);
					if (masterVendor.Count() > 0)
					{
						var Vendor = masterVendor.FirstOrDefault();
						indata.ApprovalReqStation.MasterVendor = Vendor;
						indata.ApprovalReqStation.MasterVendor.CATMs = _repo.GeneralRepo.GetCATM(Vendor.Catm);
					}
				}
			}

			return indata;
		}

		public async Task<TAllMasterVendorView> ViewContractStation(TAllMasterVendorView indata)
		{
			String idSmctMaster = indata.ParameterCondition.IdSmctMaster;
			if (indata.ParameterCondition.DepartmentCodeCurr == null)
				indata.ParameterCondition.DepartmentCodeCurr = _repo.UserService.GetDepartmentCode();

			if (indata.ParameterCondition.IdUserSmctCurr == null)
				indata.ParameterCondition.IdUserSmctCurr = _repo.UserService.GetIdUserSmct();

			if (indata.ParameterCondition.VendorIdCurr == null)
				indata.ParameterCondition.VendorIdCurr = _repo.UserService.GetVendorId();

			var contractStation = await _repo.Context.ContractStations.FirstOrDefaultAsync(x => x.IdSmctMaster == idSmctMaster);
			if (contractStation != null)
			{
				indata.ParameterCondition.Station = contractStation.StationStatusCurr;
				indata.ParameterCondition.ItemStatusCurr = contractStation.ItemStatusCurr;
				indata.ParameterCondition.ContractTypeId = contractStation.ContractTypeId;
				indata.ParameterCondition.ContractTypeIdEn = SecurityRepo.Encrypt(contractStation.ContractTypeId);
				indata.ParameterCondition.Style = contractStation.ContractStyleCode;
				indata.ParameterCondition.RefId = contractStation.RefId;
				indata.ParameterCondition.SigningType = contractStation.ContractSignType;
				indata.ParameterCondition.IdContract = contractStation.IdContract;
				indata.ParameterCondition.SigningTypeEn = SecurityRepo.Encrypt(contractStation.ContractSignType);
				indata.ContractStation = _mapper.Map<ContractStationDTO>(contractStation);
			}
			var periodType = await _repo.Context.ContractPeriods.FirstOrDefaultAsync(x => x.IdContract == indata.ParameterCondition.IdContract && x.Used);
			if (periodType != null)
				indata.ParameterCondition.PeriodType = periodType.PeriodType;

			if (indata.ParameterCondition.MenuEn != null)
			{
				String _Menu = SecurityRepo.Decrypt(indata.ParameterCondition.MenuEn);
				indata.ParameterCondition.Menu = _Menu;

				var contractStationSuccess = await _repo.Context.ContractStationSuccesses.FirstOrDefaultAsync(x => x.IdSmctMaster == idSmctMaster);
				if (contractStationSuccess != null)
				{
					indata.ParameterCondition.ContractSuccessType = contractStationSuccess.ContractSuccessType;
					indata.ParameterCondition.ContractSuccessTypeEn = SecurityRepo.Encrypt(contractStationSuccess.ContractSuccessType);
					indata.InfoRequestBinding.ContractSuccessStatus = contractStationSuccess.ContractSuccessStatus;
					indata.InfoRequestBinding.ContractSuccessRemark = contractStationSuccess.ContractSuccessRemark;
					indata.InfoRequestBinding.ContractSuccessRemarkKet = contractStationSuccess.ContractSuccessRemarkKet;
				}
			}

			return indata;
		}

		public Task<TAllMasterVendorView> ViewVendorLinkReq(TAllMasterVendorView indata)
		{
			throw new NotImplementedException();
		}

		//INSERT
		public async Task<SmctMaster> InsertSmctMaster(TAllMasterVendorView indata)
		{
			var _ParameterCon = indata.ParameterCondition;

			var smctMaster = new SmctMaster()
			{
				Status = _ParameterCon.Status,
				RefId = await _repo.CTVendorCondition.REFRunning(),
				RefDate = DateTime.Now,
				Budgetyear = _ParameterCon.BudgetYear,
				DepartmentCode = _ParameterCon.DepartmentCode,
				FVendorlink = "Y",
				ContractSignType = _ParameterCon.SigningType,
				IdRegisterNhso = _ParameterCon.IdRegisterNhso,
				CreateUser = _ParameterCon.IdUserSmctCurr,
				EditUser = _ParameterCon.IdUserSmctCurr,
				CreateDate = DateTime.Now,
				EditDate = DateTime.Now,
				Used = true
			};
			await _db.InsterAsync(smctMaster);
			await _db.SaveAsync();

			return smctMaster;
		}

		public async Task<SmctMasterSigner> InsertMasterSigners(TAllMasterVendorView indata)
		{
			var _ParameterCon = indata.ParameterCondition;

			String _VendorSignerUser = String.Empty;
			var MasterSigner = indata.InfoPartnersOfContract.SmctMasterSigner;
			if (MasterSigner.ContractSignerType == SignerTypes.AuthBySelf)
				_VendorSignerUser = MasterSigner.SmctMasterSignerDetail1.VendorSignerUser;
			else
				_VendorSignerUser = MasterSigner.SmctMasterSignerDetail1.VendorSignerUser2;

			String _ContractSignerType = MasterSigner.ContractSignerType;
			if (indata.ParameterCondition.ContractTypeId == "14")
				_ContractSignerType = SignerTypes.AuthBySelf;

			var smctMasterSigner = new SmctMasterSigner();
			if (indata.InfoSignerPartnersOfContract != null)
			{
				smctMasterSigner = new SmctMasterSigner()
				{
					IdSmctMaster = _ParameterCon.IdSmctMaster,
					ContractSignerType = _ContractSignerType,
					CreateUser = _ParameterCon.IdUserSmctCurr,
					EditUser = _ParameterCon.IdUserSmctCurr,
					CreateDate = DateTime.Now,
					EditDate = DateTime.Now,
					Used = true
				};
				await _db.InsterAsync(smctMasterSigner);
				await _db.SaveAsync();

				String _VendorWitnessStatus = WitnessStatusAll.W1WitnessUnsigned;
				if (String.IsNullOrEmpty(indata.InfoSignerPartnersOfContract.VendorWitnessUser))
				{
					_VendorWitnessStatus = WitnessStatusAll.W0NotWitness;
				}

				//โครงการไม่มีข้อมูลผู้ลงนาม และจะเก็บที่ table SmctMasterSignerDetail2
				if (indata.ParameterCondition.ContractTypeId != "14")
				{
					var smctMasterSignerDetail1 = new SmctMasterSignerDetail1()
					{
						IdSmctMasterSigner = smctMasterSigner.IdSmctMasterSigner,
						VendorSignerUser = _VendorSignerUser,
						VendorWitnessStatus = _VendorWitnessStatus,
						NhsoWitnessStatus = WitnessStatusAll.W1WitnessUnsigned,
						VendorWitnessUser = indata.InfoSignerPartnersOfContract.VendorWitnessUser,
						CreateUser = _ParameterCon.IdUserSmctCurr,
						EditUser = _ParameterCon.IdUserSmctCurr,
						CreateDate = DateTime.Now,
						EditDate = DateTime.Now,
						Used = true
					};

					if (indata.InfoSignerPartnersOfContract.FootNotes != null && indata.InfoSignerPartnersOfContract.FootNotes.Count > 0)
					{
						int index_footNotes = 0;
						foreach (var item in indata.InfoSignerPartnersOfContract.FootNotes)
						{
							if (index_footNotes == 0)
								smctMasterSignerDetail1.VendorFootnoteUser1 = item.IdUserSmct;
							if (index_footNotes == 1)
								smctMasterSignerDetail1.VendorFootnoteUser2 = item.IdUserSmct;
							if (index_footNotes == 2)
								smctMasterSignerDetail1.VendorFootnoteUser3 = item.IdUserSmct;

							index_footNotes++;
						}
					}

					await _db.InsterAsync(smctMasterSignerDetail1);
					await _db.SaveAsync();
				}
				else
				{
					//โครงการ
					var smctMasterSignerDetail2 = new SmctMasterSignerDetail2()
					{
						IdSmctMasterSigner = smctMasterSigner.IdSmctMasterSigner,
						CreateUser = _ParameterCon.IdUserSmctCurr,
						EditUser = _ParameterCon.IdUserSmctCurr,
						CreateDate = DateTime.Now,
						EditDate = DateTime.Now,
						Used = true
					};

					await _db.InsterAsync(smctMasterSignerDetail2);
					await _db.SaveAsync();
				}

			}
			return smctMasterSigner;
		}

		public async Task<SmctMasterFile> InsertInfoAttachDraftContract(TAllMasterVendorView indata, String ContractTypeId)
		{
			var _ParameterCon = indata.ParameterCondition;
			var smctMasterFile = new SmctMasterFile();

			if (indata.InfoAttachDraftContract != null && indata.InfoAttachDraftContract.SmctMasterFile != null && indata.InfoAttachDraftContract.SmctMasterFile.Count > 0)
			{
				int index_file = 0;
				foreach (var item in indata.InfoAttachDraftContract.SmctMasterFile)
				{
					if (item.FormFile != null)
					{
						index_file++;
						var fileFTP = _repo.UploadFiles.GenFileName(item.FormFile, _ParameterCon.RefId, $"FILE_{ContractTypeId}_F1_{index_file}");
						String thaiYear = GeneralUtils.getThaiYear(DateTime.Now.Year);

						smctMasterFile = new SmctMasterFile()
						{
							IdSmctMaster = _ParameterCon.IdSmctMaster,
							FileType = "F1",
							FileName = item.FormFile.FileName,
							FileFtp = fileFTP,
							CreateUser = _ParameterCon.IdUserSmctCurr,
							EditUser = _ParameterCon.IdUserSmctCurr,
							CreateDate = DateTime.Now,
							EditDate = DateTime.Now,
							FileNo = index_file,
							Used = true,
							PathFolder = thaiYear
						};
						await _db.InsterAsync(smctMasterFile);
						await _db.SaveAsync();

						String PathFolder = $"Attach/{ContractTypeId}/{thaiYear}";
						this.HandleUploadfile(item.FormFile, fileFTP, PathFolder);
					}
				}
			}
			return smctMasterFile;
		}

		public async Task<ApprovalReqStation> InsertApprovalReqStation(TAllMasterVendorView indata)
		{
			var _ParameterCon = indata.ParameterCondition;

			String vendorId = _repo.UserService.GetVendorId();
			String vendorName = _repo.UserService.GetVendorName();
			int btnSubmit = int.Parse(indata.BtnSubmit);
			var userSmcts = _repo.Context.UserSmcts.Where(x => x.Used);
			String userFullname = userSmcts.FirstOrDefault(x => x.IdUserSmct == _ParameterCon.IdUserSmctCurr)?.UserFullname ?? String.Empty;
			var coordinatorFullname = userSmcts.FirstOrDefault(x => x.IdUserSmct == indata.InfoRequestForApproval.CoordinatorUserSelect);

			var approvalReq = new ApprovalReq()
			{
				IdSmctMaster = _ParameterCon.IdSmctMaster,
				ContractName = indata.InfoRequestForApproval.ContractName,
				Reason = indata.InfoRequestForApproval.Reason,
				CoordinatorUser = indata.InfoRequestForApproval.CoordinatorUserSelect,
				CoordinatorFullname = coordinatorFullname.UserFullname,
				Email = indata.InfoRequestForApproval.Email,
				Phone = indata.InfoRequestForApproval.Phone,
				Fax = indata.InfoRequestForApproval.Fax,
				CreateUser = _ParameterCon.IdUserSmctCurr,
				EditUser = _ParameterCon.IdUserSmctCurr,
				CreateDate = DateTime.Now,
				EditDate = DateTime.Now,
				Used = true,
				Version = "1",
				Status = UserSmctStatus.WaitUse,
			};
			await _db.InsterAsync(approvalReq);
			await _db.SaveAsync();

			String _AppStationStatusCurr = ApproveStationStatusAll.S1CreateProposal;
			String _AppItemStatusCurr = ApproveStationStatusItemAll.S11Draft;
			if (btnSubmit == (int)ButtonState.Forward)
			{
				_AppStationStatusCurr = ApproveStationStatusAll.S2CreateApprove;
				_AppItemStatusCurr = ApproveStationStatusItemAll.S12SaveForward;
			}

			var approvalReqStation = new ApprovalReqStation()
			{
				IdSmctMaster = _ParameterCon.IdSmctMaster,
				IdApprovalReq = approvalReq.IdApprovalReq,
				Budgetyear = _ParameterCon.BudgetYear,
				DepartmentCode = _ParameterCon.DepartmentCode,
				FRetarn = F_RETARN.NEW,
				StationStatusPrev = ApproveStationStatusAll.S1CreateProposal,
				StationStatusCurr = _AppStationStatusCurr,
				StationBeginDate = DateTime.Now,
				StationBeginUser = _ParameterCon.IdUserSmctCurr,
				ItemStatusPrev = ApproveStationStatusItemAll.S11Draft,
				ItemStatusCurr = _AppItemStatusCurr,
				ItemBeginDate = DateTime.Now,
				ItemBeginUser = _ParameterCon.IdUserSmctCurr,
				RefId = _ParameterCon.RefId,
				RefDate = _ParameterCon.RefDate,
				ContractName = indata.InfoRequestForApproval.ContractName,
				ContractTypeName = indata.InfoContract.ContractTypeFullName,
				ContractSignType = _ParameterCon.SigningType,
				VendorId = vendorId,
				VendorName = vendorName,
				CreateUserFullname = userFullname,
				CreateUser = _ParameterCon.IdUserSmctCurr,
				EditUserFullname = userFullname,
				EditUser = _ParameterCon.IdUserSmctCurr,
				CreateDate = DateTime.Now,
				EditDate = DateTime.Now,
				Used = true,
				DepartmentName = _ParameterCon.Dname,
				ContractTypeId = _ParameterCon.ContractTypeId,
				ContractStyleCode = _ParameterCon.ContractStyleCode,
				ContractStyleFullName = _ParameterCon.ContractStyleFullName
			};
			await _db.InsterAsync(approvalReqStation);
			await _db.SaveAsync();

			return approvalReqStation;
		}

		public async Task<ContractStation> InsertContractStation(TAllMasterVendorView indata)
		{
			var _ParameterCon = indata.ParameterCondition;

			String vendorId = _repo.UserService.GetVendorId();
			String vendorName = _repo.UserService.GetVendorName();
			int btnSubmit = int.Parse(indata.BtnSubmit);
			var userSmcts = _repo.Context.UserSmcts.Where(x => x.Used);
			String userFullname = userSmcts.FirstOrDefault(x => x.IdUserSmct == _ParameterCon.IdUserSmctCurr)?.UserFullname ?? String.Empty;

			var ContractType = _repo.Context.ContractTypes.FirstOrDefault(x => x.Used && x.IdContractType == _ParameterCon.IdContractType);
			var userSmctVendors = _repo.Context.UserSmctVendors.Include(n => n.IdRegisterNhsoNavigation).FirstOrDefault(x => x.Used && x.IdUserSmct == _ParameterCon.IdUserSmctCurr);

			String _ContractName = indata.InfoRequestForApproval.ContractName;
			//ไม่มีหนังสือขออนุมัติ
			if (ContractType.FApprovalReq == false)
				_ContractName = _ParameterCon.ContractTypeFullName;

			//กรณีหนังสือแสดงความจำนง ต้องระบุเลขที่ สัญญาให้บริการสาธาณสุขฯ(เอกชน) / ข้อตกลงให้บริการสาธาณสุขฯ(รัฐ)
			String _ContractMainId = null;
			if (_ParameterCon.ContractTypeId == "13")
			{
				if (!String.IsNullOrEmpty(_ParameterCon.ContractIdSelectEn))
					_ContractMainId = SecurityRepo.Decrypt(_ParameterCon.ContractIdSelectEn);
			}

			var _Contract = new Contract()
			{
				IdSmctMaster = _ParameterCon.IdSmctMaster,
				IdContractType = _ParameterCon.IdContractType,
				Status = UserSmctStatus.WaitUse,
				ContractName = _ContractName,
				CreateUser = _ParameterCon.IdUserSmctCurr,
				EditUser = _ParameterCon.IdUserSmctCurr,
				CreateDate = DateTime.Now,
				EditDate = DateTime.Now,
				Used = true,
				Version = "1",
				ContractMainId = _ContractMainId
			};
			await _db.InsterAsync(_Contract);
			await _db.SaveAsync();

			String _StationStatusCurr = ContractStationStatusAll.S1Draft;
			String _ConItemStatusCurr = ContractStationStatusItemAll.S11Draft;
			if (btnSubmit == (int)ButtonState.Forward)
			{
				//ไม่มีหนังสือขออนุุมัติ
				if (ContractType.FApprovalReq == false)
				{
					//กำหนดรหัสคู่สัญญา
					if (String.IsNullOrEmpty(userSmctVendors.IdRegisterNhsoNavigation.VendorId))
					{
						_StationStatusCurr = ContractStationStatusAll.S3SetVendor;
						_ConItemStatusCurr = ContractStationStatusItemAll.S31WaitSetVendor;
					}
					else
					{
						//สร้างนิติกรรมสัญญา
						_StationStatusCurr = ContractStationStatusAll.S4CreateContract;
						_ConItemStatusCurr = ContractStationStatusItemAll.S41WaitNhsoCreateContract;
					}
				}
				else
				{
					//หนังสือขออนุมัติ
					_StationStatusCurr = ContractStationStatusAll.S2BookRequestApproval;
					_ConItemStatusCurr = ContractStationStatusItemAll.S12SaveForward;
				}
			}

			var contractStation = new ContractStation()
			{
				IdSmctMaster = _ParameterCon.IdSmctMaster,
				IdContract = _Contract.IdContract,
				Budgetyear = _ParameterCon.BudgetYear,
				DepartmentCode = _ParameterCon.DepartmentCode,
				FVendorlink = "Y",
				FRetarn = F_RETARN.NEW,
				StationStatusPrev = ContractStationStatusAll.S1Draft,
				StationStatusCurr = _StationStatusCurr,
				StationBeginDate = DateTime.Now,
				StationBeginUser = _ParameterCon.IdUserSmctCurr,
				ItemStatusPrev = ContractStationStatusItemAll.S11Draft,
				ItemStatusCurr = _ConItemStatusCurr,
				ItemBeginDate = DateTime.Now,
				ItemBeginUser = _ParameterCon.IdUserSmctCurr,
				RefId = _ParameterCon.RefId,
				RefDate = _ParameterCon.RefDate,
				ContractName = _ContractName,
				ContractTypeName = indata.InfoContract.ContractTypeFullName,
				ContractSignType = _ParameterCon.SigningType,
				VendorId = vendorId,
				VendorName = vendorName,
				CreateUserFullname = userFullname,
				CreateUser = _ParameterCon.IdUserSmctCurr,
				EditUserFullname = userFullname,
				EditUser = _ParameterCon.IdUserSmctCurr,
				CreateDate = DateTime.Now,
				EditDate = DateTime.Now,
				Used = true,
				DepartmentName = _ParameterCon.Dname,
				ContractTypeId = _ParameterCon.ContractTypeId,
				ContractStyleCode = _ParameterCon.ContractStyleCode,
				ContractStyleFullName = _ParameterCon.ContractStyleFullName
			};
			await _db.InsterAsync(contractStation);
			await _db.SaveAsync();


			//กรณีเลือกไม่มีรหัสคู่สัญญา(Vendor) ตอนลงทะเบียน และยังไม่มีการสร้างนิติกรรมของรหัสคู่สัญญานี้ จะเกิดแค่ครั้งแรกที่มีการสร้างนิติกรรมรหัสคู่สัญญานี้
			if (String.IsNullOrEmpty(userSmctVendors.IdRegisterNhsoNavigation.VendorId))
			{
				await this.InsertVendorLinkReq(indata);
			}

			return contractStation;
		}

		public async Task<VendorLinkReq> InsertVendorLinkReq(TAllMasterVendorView indata)
		{
			var _ParameterCon = indata.ParameterCondition;

			int btnSubmit = int.Parse(indata.BtnSubmit);
			var userSmcts = _repo.Context.UserSmcts.Where(x => x.Used);
			String userFullname = userSmcts.FirstOrDefault(x => x.IdUserSmct == _ParameterCon.IdUserSmctCurr)?.UserFullname ?? String.Empty;
			var ContractType = _repo.Context.ContractTypes.FirstOrDefault(x => x.Used && x.IdContractType == _ParameterCon.IdContractType);

			String _ContractName = indata.InfoRequestForApproval.ContractName;
			//ไม่มีหนังสือขออนุมัติ
			if (ContractType.FApprovalReq == false)
				_ContractName = _ParameterCon.ContractTypeFullName;

			var userSmctVendors = await _repo.Context.UserSmctVendors.FirstOrDefaultAsync(x => x.IdUserSmct == _ParameterCon.IdUserSmctCurr);
			var registerNhsos = await _repo.Context.RegisterNhsos.FirstOrDefaultAsync(x => x.IdRegisterNhso == userSmctVendors.IdRegisterNhso);

			var vendorLinkReq = new VendorLinkReq()
			{
				IdSmctMaster = _ParameterCon.IdSmctMaster,
				ReqId = await this.VLRunning(),
				Hcode = null,
				VendorId = null,
				VendorName = registerNhsos.VendorName,
				RegisterAt = registerNhsos.RegisterAt,
				CompanyName = registerNhsos.CompanyName,
				ProvinceId = registerNhsos.ProvinceId,
				Catm = registerNhsos.Catm,
				VillageNo = registerNhsos.VillageNo,
				Building = registerNhsos.Building,
				TaxId = registerNhsos.TaxId,
				Soi = registerNhsos.Soi,
				Road = registerNhsos.Road,
				PostCode = registerNhsos.PostCode,
				Phone = registerNhsos.Phone,
				Fax = registerNhsos.Fax,
				Email = registerNhsos.Email,
				Sp7 = registerNhsos.Sp7,
				Sp7Date = registerNhsos.Sp7Date,
				Moo = registerNhsos.Moo,
				Status = ContractStatusAll.S1WaitApprove,
				CreateUser = _ParameterCon.IdUserSmctCurr,
				EditUser = _ParameterCon.IdUserSmctCurr,
				CreateDate = DateTime.Now,
				EditDate = DateTime.Now,
				Used = true,
				Version = "1"
			};
			await _db.InsterAsync(vendorLinkReq);
			await _db.SaveAsync();

			String _StationStatusCurr = VendorLinkStationStatusAll.S1CreateProposal;
			String _ItemStatusCurr = VendorLinkStationStatusItemAll.S11Draft;

			if (btnSubmit == (int)ButtonState.Forward)
			{
				_StationStatusCurr = VendorLinkStationStatusAll.S2Check;
				_ItemStatusCurr = VendorLinkStationStatusItemAll.S21WaitCheck;
			}

			var vendorLinkReqStation = new VendorLinkReqStation()
			{
				IdSmctMaster = _ParameterCon.IdSmctMaster,
				IdVendorLinkReq = vendorLinkReq.IdVendorLinkReq,
				Budgetyear = _ParameterCon.BudgetYear,
				DepartmentCode = _ParameterCon.DepartmentCode,
				FRetarn = F_RETARN.NEW,
				StationStatusPrev = VendorLinkStationStatusAll.S1CreateProposal,
				StationStatusCurr = _StationStatusCurr,
				StationBeginDate = DateTime.Now,
				StationBeginUser = _ParameterCon.IdUserSmctCurr,
				ItemStatusPrev = VendorLinkStationStatusItemAll.S11Draft,
				ItemStatusCurr = _ItemStatusCurr,
				ItemBeginDate = DateTime.Now,
				ItemBeginUser = _ParameterCon.IdUserSmctCurr,
				RefId = _ParameterCon.RefId,
				RefDate = _ParameterCon.RefDate,
				ApprovalReqId = vendorLinkReq.ReqId,
				ApprovalReqDate = null,
				ContractName = _ContractName,
				ContractTypeName = indata.InfoContract.ContractTypeFullName,
				ContractSignType = _ParameterCon.SigningType,
				VendorId = null,
				VendorName = null,
				CreateUserFullname = userFullname,
				CreateUser = _ParameterCon.IdUserSmctCurr,
				EditUserFullname = userFullname,
				EditUser = _ParameterCon.IdUserSmctCurr,
				CreateDate = DateTime.Now,
				EditDate = DateTime.Now,
				Used = true,
				DepartmentName = _ParameterCon.Dname,
				ContractTypeId = _ParameterCon.ContractTypeId,
				ContractStyleCode = _ParameterCon.ContractStyleCode,
				ContractStyleFullName = _ParameterCon.ContractStyleFullName
			};
			await _db.InsterAsync(vendorLinkReqStation);
			await _db.SaveAsync();

			return vendorLinkReq;
		}

		//UPDATE
		public async Task<SmctMaster> UpdateSmctMaster(TAllMasterVendorView indata)
		{
			var _ParameterCon = indata.ParameterCondition;

			var smctMaster = await _repo.Context.SmctMasters.FirstOrDefaultAsync(x => x.IdSmctMaster == _ParameterCon.IdSmctMaster);
			smctMaster.EditUser = _ParameterCon.IdUserSmctCurr;
			smctMaster.EditDate = DateTime.Now;
			_db.Update(smctMaster);
			await _db.SaveAsync();

			return smctMaster;
		}

		public async Task UpdateStatusApproveReq(ParameterStatusStation indata)
		{
			String idSmctMaster = indata.IdSmctMaster;
			String idUserSmct = _repo.UserService.GetIdUserSmct();
			var approvalReq = await _repo.Context.ApprovalReqs.FirstOrDefaultAsync(x => x.IdSmctMaster == idSmctMaster);

			if (!String.IsNullOrEmpty(indata.Status))
			{
				approvalReq.Status = indata.Status;
				if (indata.Status == ApprovalReqStatus.S2UnApprove)
				{
					approvalReq.StatusCheckMail = null;
				}
			}
			approvalReq.EditUser = idUserSmct;
			approvalReq.EditDate = DateTime.Now;
			_db.Update(approvalReq);
			await _db.SaveAsync();


			String userFullname = _repo.Context.UserSmcts.FirstOrDefault(x => x.IdUserSmct == idUserSmct)?.UserFullname ?? String.Empty;
			var approvalReqStation = _repo.Context.ApprovalReqStations.FirstOrDefault(x => x.IdSmctMaster == idSmctMaster);

			approvalReqStation.StationStatusPrev = approvalReqStation.StationStatusCurr;

			if (!String.IsNullOrEmpty(indata.StationStatusCurr))
				approvalReqStation.StationStatusCurr = indata.StationStatusCurr;

			approvalReqStation.ItemStatusPrev = approvalReqStation.ItemStatusCurr;

			if (!String.IsNullOrEmpty(indata.ItemStatusCurr))
				approvalReqStation.ItemStatusCurr = indata.ItemStatusCurr;

			approvalReqStation.OfficerReamrk = indata.OfficerReamrk;
			approvalReqStation.DirectorRemark = indata.DirectorRemark;

			approvalReqStation.EditUserFullname = userFullname;
			approvalReqStation.EditUser = idUserSmct;
			approvalReqStation.EditDate = DateTime.Now;
			_db.Update(approvalReqStation);
			await _db.SaveAsync();
		}

		public async Task UpdateStatusContract(ParameterStatusStation indata)
		{
			String idSmctMaster = indata.IdSmctMaster;
			String idUserSmct = _repo.UserService.GetIdUserSmct();
			var _Contracts = await _repo.Context.Contracts.FirstOrDefaultAsync(x => x.IdSmctMaster == idSmctMaster);

			if (!String.IsNullOrEmpty(indata.Status))
				_Contracts.Status = indata.Status;

			_Contracts.EditUser = idUserSmct;
			_Contracts.EditDate = DateTime.Now;
			_db.Update(_Contracts);
			await _db.SaveAsync();


			String userFullname = _repo.Context.UserSmcts.FirstOrDefault(x => x.IdUserSmct == idUserSmct)?.UserFullname ?? String.Empty;
			var contractStations = _repo.Context.ContractStations.FirstOrDefault(x => x.IdSmctMaster == idSmctMaster);

			contractStations.ContractId = _Contracts.ContractId;
			contractStations.ContractDate = _Contracts.ContractDate;

			if (!String.IsNullOrEmpty(indata.StationStatusPrev))
				contractStations.StationStatusPrev = indata.StationStatusPrev;
			else
			{
				contractStations.StationStatusPrev = contractStations.StationStatusCurr;
			}

			if (!String.IsNullOrEmpty(indata.StationStatusCurr))
				contractStations.StationStatusCurr = indata.StationStatusCurr;

			if (!String.IsNullOrEmpty(indata.ItemStatusPrev))
				contractStations.ItemStatusPrev = indata.ItemStatusPrev;
			else
			{
				contractStations.ItemStatusPrev = contractStations.ItemStatusCurr;
			}

			if (!String.IsNullOrEmpty(indata.ItemStatusCurr))
				contractStations.ItemStatusCurr = indata.ItemStatusCurr;

			if (!String.IsNullOrEmpty(indata.KetRemark))
				contractStations.KetRemark = indata.KetRemark;

			if (!String.IsNullOrEmpty(indata.SbbRemark))
				contractStations.SbbRemark = indata.SbbRemark;

			contractStations.FRetarn = indata.FRetarn;

			contractStations.EditUserFullname = userFullname;
			contractStations.EditUser = idUserSmct;
			contractStations.EditDate = DateTime.Now;
			_db.Update(contractStations);
			await _db.SaveAsync();
		}

		public async Task UpdateStatusVendorLink(ParameterStatusStation indata)
		{
			String idSmctMaster = indata.IdSmctMaster;
			String idUserSmct = _repo.UserService.GetIdUserSmct();
			var vendorLinkReqs = await _repo.Context.VendorLinkReqs.FirstOrDefaultAsync(x => x.IdSmctMaster == idSmctMaster);

			if (!String.IsNullOrEmpty(indata.Status))
				vendorLinkReqs.Status = indata.Status;

			if (!String.IsNullOrEmpty(indata.VendorId))
				vendorLinkReqs.VendorId = indata.VendorId;

			if (!String.IsNullOrEmpty(indata.VendorName))
				vendorLinkReqs.VendorName = indata.VendorName;

			vendorLinkReqs.EditUser = idUserSmct;
			vendorLinkReqs.EditDate = DateTime.Now;
			_db.Update(vendorLinkReqs);
			await _db.SaveAsync();

			String userFullname = _repo.Context.UserSmcts.FirstOrDefault(x => x.IdUserSmct == idUserSmct)?.UserFullname ?? String.Empty;
			var vendorLinkReqStations = _repo.Context.VendorLinkReqStations.FirstOrDefault(x => x.IdSmctMaster == idSmctMaster);

			if (!String.IsNullOrEmpty(indata.StationStatusPrev))
				vendorLinkReqStations.StationStatusPrev = indata.StationStatusPrev;
			else
			{
				vendorLinkReqStations.StationStatusPrev = vendorLinkReqStations.StationStatusCurr;
			}

			if (!String.IsNullOrEmpty(indata.StationStatusCurr))
				vendorLinkReqStations.StationStatusCurr = indata.StationStatusCurr;

			if (!String.IsNullOrEmpty(indata.ItemStatusPrev))
				vendorLinkReqStations.ItemStatusPrev = indata.ItemStatusPrev;
			else
			{
				vendorLinkReqStations.ItemStatusPrev = vendorLinkReqStations.ItemStatusCurr;
			}

			if (!String.IsNullOrEmpty(indata.ItemStatusCurr))
				vendorLinkReqStations.ItemStatusCurr = indata.ItemStatusCurr;

			if (!String.IsNullOrEmpty(indata.KetRemark))
				vendorLinkReqStations.KetRemark = indata.KetRemark;

			if (!String.IsNullOrEmpty(indata.SbbRemark))
				vendorLinkReqStations.SbbRemark = indata.SbbRemark;

			if (!String.IsNullOrEmpty(indata.VendorId))
				vendorLinkReqStations.VendorId = indata.VendorId;

			if (!String.IsNullOrEmpty(indata.VendorName))
				vendorLinkReqStations.VendorName = indata.VendorName;

			if (!String.IsNullOrEmpty(indata.Status) && indata.Status == ContractStatusAll.S3Approve)
				vendorLinkReqStations.ApprovalReqDate = DateTime.Now;

			vendorLinkReqStations.EditUserFullname = userFullname;
			vendorLinkReqStations.EditUser = idUserSmct;
			vendorLinkReqStations.EditDate = DateTime.Now;
			_db.Update(vendorLinkReqStations);
			await _db.SaveAsync();
		}

		public async Task UpdateMasterSigners(TAllMasterVendorView indata)
		{

			String idUserSmct = _repo.UserService.GetIdUserSmct();
			String idSmctMaster = indata.ParameterCondition.IdSmctMaster;

			if (indata.InfoSignerPartnersOfContract != null)
			{
				var MasterSigner = indata.InfoPartnersOfContract.SmctMasterSigner;
				String _ContractSignerType = MasterSigner.ContractSignerType;
				if (indata.ParameterCondition.ContractTypeId == "14")
					_ContractSignerType = SignerTypes.AuthBySelf;

				var smctMasterSigner = await _repo.Context.SmctMasterSigners.FirstOrDefaultAsync(x => x.IdSmctMaster == idSmctMaster);
				smctMasterSigner.ContractSignerType = _ContractSignerType;
				smctMasterSigner.EditUser = idUserSmct;
				smctMasterSigner.EditDate = DateTime.Now;
				_db.Update(smctMasterSigner);
				await _db.SaveAsync();

				//โครงการไม่มีข้อมูลผู้ลงนาม และจะเก็บที่ table SmctMasterSignerDetail2
				if (indata.ParameterCondition.ContractTypeId != "14")
				{
					var smctMasterSignerDetail1 = await _repo.Context.SmctMasterSignerDetail1s.FirstOrDefaultAsync(x => x.IdSmctMasterSigner == smctMasterSigner.IdSmctMasterSigner);

					String _VendorSignerUser = String.Empty;
					if (MasterSigner.ContractSignerType == SignerTypes.AuthBySelf)
						_VendorSignerUser = MasterSigner.SmctMasterSignerDetail1.VendorSignerUser;
					else
						_VendorSignerUser = MasterSigner.SmctMasterSignerDetail1.VendorSignerUser2;

					if (String.IsNullOrEmpty(indata.InfoSignerPartnersOfContract.VendorWitnessUser))
					{
						smctMasterSignerDetail1.VendorWitnessStatus = WitnessStatusAll.W0NotWitness;
					}

					smctMasterSignerDetail1.VendorSignerUser = _VendorSignerUser;
					smctMasterSignerDetail1.VendorWitnessUser = indata.InfoSignerPartnersOfContract.VendorWitnessUser;
					smctMasterSignerDetail1.VendorFootnoteUser1 = null;
					smctMasterSignerDetail1.VendorFootnoteUser2 = null;
					smctMasterSignerDetail1.VendorFootnoteUser3 = null;

					if (indata.InfoSignerPartnersOfContract.FootNotes != null && indata.InfoSignerPartnersOfContract.FootNotes.Count > 0)
					{
						int index_footNotes = 0;
						foreach (var item in indata.InfoSignerPartnersOfContract.FootNotes)
						{
							if (index_footNotes == 0) smctMasterSignerDetail1.VendorFootnoteUser1 = item.IdUserSmct;
							if (index_footNotes == 1) smctMasterSignerDetail1.VendorFootnoteUser2 = item.IdUserSmct;
							if (index_footNotes == 2) smctMasterSignerDetail1.VendorFootnoteUser3 = item.IdUserSmct;
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

					smctMasterSignerDetail2.EditUser = idUserSmct;
					smctMasterSignerDetail2.EditDate = DateTime.Now;
					_db.Update(smctMasterSignerDetail2);
					await _db.SaveAsync();
				}

			}

		}

		public async Task UpdateGuaranteeContract(TAllMasterVendorView indata)
		{
			String idUserSmct = _repo.UserService.GetIdUserSmct();
			String idSmctMaster = indata.ParameterCondition.IdSmctMaster;
			//Type
			//ประเภทปรูปแบบหลักประกัน
			//T1 = มีหลักประกัน : หักจากงวดที่1
			//T2 = มีหลักประกัน : ไม่หักจากงวดที่1
			//T3 = ยกเว้นหลักประกันสัญญา
			if (indata.InfoGuaranteeContract != null)
			{
				var contractGuarantees = await _repo.Context.ContractGuarantees.Where(x => x.IdSmctMaster == idSmctMaster).ToListAsync();
				if (contractGuarantees.Count > 0)
				{
					var removeDetailGuarantee = _repo.Context.ContractGuaranteeDetails.Where(x => contractGuarantees.Select(x => x.IdContractGuarantee).Contains(x.IdContractGuarantee)).ToList();
					if (removeDetailGuarantee.Count > 0)
					{
						_db.DeleteRange(removeDetailGuarantee);
						await _repo.SaveAsync();
					}
					_db.DeleteRange(contractGuarantees);
					await _repo.SaveAsync();
				}


				if (indata.InfoGuaranteeContract.GuaranteeType4)
				{
					var contractGuarantee = new ContractGuarantee()
					{
						IdSmctMaster = idSmctMaster,
						Type = GuaranteeFormatTypes.HaveGuaranteeY1,
						GuaranteeType = GuaranteeTypes.DeductedTransfer1,
						CreateUser = idUserSmct,
						EditUser = idUserSmct,
						CreateDate = DateTime.Now,
						EditDate = DateTime.Now,
						Used = true
					};
					await _db.InsterAsync(contractGuarantee);
					await _db.SaveAsync();

					if (indata.InfoContract.Budget > 0)
					{
						indata.InfoGuaranteeContract.DeductedAmountMoney = ((indata.InfoContract.Budget * 5) / 100);
					}
					else
					{
						indata.InfoGuaranteeContract.DeductedAmountMoney = 0;
					}


					var contractGuaranteeDetail = new ContractGuaranteeDetail()
					{
						IdContractGuarantee = contractGuarantee.IdContractGuarantee,
						Amount = indata.InfoGuaranteeContract.DeductedAmountMoney.Value,
						CreateUser = idUserSmct,
						EditUser = idUserSmct,
						CreateDate = DateTime.Now,
						EditDate = DateTime.Now,
						Used = true
					};
					await _db.InsterAsync(contractGuaranteeDetail);
					await _db.SaveAsync();
				}
				if (indata.InfoGuaranteeContract.GuaranteeType1)
				{
					var contractGuarantee = new ContractGuarantee()
					{
						IdSmctMaster = idSmctMaster,
						Type = GuaranteeFormatTypes.HaveGuaranteeN1,
						GuaranteeType = GuaranteeTypes.Cash,
						CreateUser = idUserSmct,
						EditUser = idUserSmct,
						CreateDate = DateTime.Now,
						EditDate = DateTime.Now,
						Used = true
					};
					await _db.InsterAsync(contractGuarantee);
					await _db.SaveAsync();

					var contractGuaranteeDetail = new ContractGuaranteeDetail()
					{
						IdContractGuarantee = contractGuarantee.IdContractGuarantee,
						Amount = indata.InfoGuaranteeContract.AmountMoney.Value,
						CreateUser = idUserSmct,
						EditUser = idUserSmct,
						CreateDate = DateTime.Now,
						EditDate = DateTime.Now,
						Used = true
					};
					await _db.InsterAsync(contractGuaranteeDetail);
					await _db.SaveAsync();
				}
				if (indata.InfoGuaranteeContract.GuaranteeType2)
				{
					var contractGuarantee = new ContractGuarantee()
					{
						IdSmctMaster = idSmctMaster,
						Type = GuaranteeFormatTypes.HaveGuaranteeN1,
						GuaranteeType = GuaranteeTypes.CashierCheck,
						CreateUser = idUserSmct,
						EditUser = idUserSmct,
						CreateDate = DateTime.Now,
						EditDate = DateTime.Now,
						Used = true
					};
					await _db.InsterAsync(contractGuarantee);
					await _db.SaveAsync();

					if (indata.InfoGuaranteeContract.CashierChequeDesc != null && indata.InfoGuaranteeContract.CashierChequeDesc.Count > 0)
					{
						foreach (var item in indata.InfoGuaranteeContract.CashierChequeDesc)
						{
							var contractGuaranteeDetail = new ContractGuaranteeDetail()
							{
								IdContractGuarantee = contractGuarantee.IdContractGuarantee,
								BankId = item.BankCode,
								CashierId = item.CheckNumber,
								CashierDate = GeneralUtils.DateTimeToEn(item.DateStr),
								Amount = item.AmountMoney.Value,
								CreateUser = idUserSmct,
								EditUser = idUserSmct,
								CreateDate = DateTime.Now,
								EditDate = DateTime.Now,
								Used = true
							};
							await _db.InsterAsync(contractGuaranteeDetail);
							await _db.SaveAsync();
						}
					}
				}
				if (indata.InfoGuaranteeContract.GuaranteeType3)
				{
					var contractGuarantee = new ContractGuarantee()
					{
						IdSmctMaster = idSmctMaster,
						Type = GuaranteeFormatTypes.HaveGuaranteeN1,
						GuaranteeType = GuaranteeTypes.BookGuarantee,
						CreateUser = idUserSmct,
						EditUser = idUserSmct,
						CreateDate = DateTime.Now,
						EditDate = DateTime.Now,
						Used = true
					};
					await _db.InsterAsync(contractGuarantee);
					await _db.SaveAsync();

					if (indata.InfoGuaranteeContract.BookGuaranteeDesc != null && indata.InfoGuaranteeContract.BookGuaranteeDesc.Count > 0)
					{
						foreach (var item in indata.InfoGuaranteeContract.BookGuaranteeDesc)
						{
							var contractGuaranteeDetail = new ContractGuaranteeDetail()
							{
								IdContractGuarantee = contractGuarantee.IdContractGuarantee,
								BankId = item.BankCode,
								GuaranteeDocId = item.BookNumber,
								GuaranteeDocStartDate = GeneralUtils.DateTimeToEn(item.StartDateStr),
								GuaranteeDocEndDate = GeneralUtils.DateTimeToEn(item.EndDateStr),
								Amount = item.AmountMoney.Value,
								CreateUser = idUserSmct,
								EditUser = idUserSmct,
								CreateDate = DateTime.Now,
								EditDate = DateTime.Now,
								Used = true
							};
							await _db.InsterAsync(contractGuaranteeDetail);
							await _db.SaveAsync();
						}
					}
				}
			}

		}

		public async Task UpdateInfoAttachDraftContract(TAllMasterVendorView indata, String ContractTypeId)
		{
			var _ParameterCon = indata.ParameterCondition;

			var smctMasterFileRemove = _repo.Context.SmctMasterFiles.Where(x => x.IdSmctMaster == _ParameterCon.IdSmctMaster && x.FileType == "F1").ToList();
			if (indata.InfoAttachDraftContract != null && indata.InfoAttachDraftContract.SmctMasterFile != null && indata.InfoAttachDraftContract.SmctMasterFile.Count > 0)
			{
				smctMasterFileRemove = smctMasterFileRemove.Where(x => !indata.InfoAttachDraftContract.SmctMasterFile.Select(r => r.IdSmctMasterFile).Contains(x.IdSmctMasterFile)).ToList();
			}
			if (smctMasterFileRemove.Count > 0)
			{
				_db.DeleteRange(smctMasterFileRemove);
				await _repo.SaveAsync();
			}
			if (indata.InfoAttachDraftContract != null && indata.InfoAttachDraftContract.SmctMasterFile != null && indata.InfoAttachDraftContract.SmctMasterFile.Count > 0)
			{
				int index_file = 0;
				foreach (var item in indata.InfoAttachDraftContract.SmctMasterFile)
				{
					index_file++;

					var fileFTP = _repo.UploadFiles.GenFileName(item.FormFile, _ParameterCon.RefId, $"FILE_{ContractTypeId}_F1_{index_file}");
					String thaiYear = GeneralUtils.getThaiYear(DateTime.Now.Year);

					var smctMasterFile = _repo.Context.SmctMasterFiles.FirstOrDefault(x => x.IdSmctMaster == _ParameterCon.IdSmctMaster && x.IdSmctMasterFile == item.IdSmctMasterFile);
					if (smctMasterFile != null)
					{
						smctMasterFile.FileNo = index_file;
						smctMasterFile.EditUser = _ParameterCon.IdUserSmctCurr;
						smctMasterFile.EditDate = DateTime.Now;
						smctMasterFile.PathFolder = thaiYear;
						_db.Update(smctMasterFile);
						await _db.SaveAsync();
					}
					else
					{
						smctMasterFile = new SmctMasterFile()
						{
							IdSmctMaster = _ParameterCon.IdSmctMaster,
							FileType = "F1",
							FileName = item.FormFile.FileName,
							FileFtp = fileFTP,
							CreateUser = _ParameterCon.IdUserSmctCurr,
							EditUser = _ParameterCon.IdUserSmctCurr,
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
						String PathFolder = $"Attach/{ContractTypeId}/{thaiYear}";
						this.HandleUploadfile(item.FormFile, fileFTP, PathFolder);
					}

				}
			}

		}

		public async Task UpdateApprovalReqStation(TAllMasterVendorView indata)
		{
			var _ParameterCon = indata.ParameterCondition;

			var contractStation = _repo.Context.ContractStations.FirstOrDefault(x => x.IdSmctMaster == _ParameterCon.IdSmctMaster);
			//ถูกตีกลับจากขั้นตอนการสร้างนิติกรรม ,ถูกตีกลับจากขั้นตอนการออกเลขที่สัญญา ไม่ต้อง Update เพราะอนุมัติหนังสือไปแล้ว
			if (contractStation.ItemStatusPrev != ContractStationStatusItemAll.S43NhsoReject && contractStation.ItemStatusPrev != ContractStationStatusItemAll.S641RejectToVendor)
			{
				String vendorId = _repo.UserService.GetVendorId();
				String vendorName = _repo.UserService.GetVendorName();
				int btnSubmit = int.Parse(indata.BtnSubmit);
				var userSmcts = _repo.Context.UserSmcts.Where(x => x.Used);
				String userFullname = userSmcts.FirstOrDefault(x => x.IdUserSmct == _ParameterCon.IdUserSmctCurr)?.UserFullname ?? String.Empty;

				String _ContractName = indata.InfoRequestForApproval.ContractName;
				if (_ParameterCon.Style == "S1")
					_ContractName = _ParameterCon.ContractTypeFullName;

				var coordinatorFullname = userSmcts.FirstOrDefault(x => x.IdUserSmct == indata.InfoRequestForApproval.CoordinatorUserSelect);
				var approvalReq = await _repo.Context.ApprovalReqs.FirstOrDefaultAsync(x => x.IdSmctMaster == _ParameterCon.IdSmctMaster);
				approvalReq.ContractName = _ContractName;
				approvalReq.Reason = indata.InfoRequestForApproval.Reason;
				approvalReq.CoordinatorUser = indata.InfoRequestForApproval.CoordinatorUserSelect;
				approvalReq.CoordinatorFullname = coordinatorFullname.UserFullname;
				approvalReq.Email = indata.InfoRequestForApproval.Email;
				approvalReq.Phone = indata.InfoRequestForApproval.Phone;
				approvalReq.Fax = indata.InfoRequestForApproval.Fax;
				approvalReq.EditUser = _ParameterCon.IdUserSmctCurr;
				approvalReq.EditDate = DateTime.Now;
				_db.Update(approvalReq);
				await _db.SaveAsync();

				String _AppStationStatusCurr = ApproveStationStatusAll.S1CreateProposal;
				String _AppItemStatusPrev = ApproveStationStatusItemAll.S11Draft;
				String _AppItemStatusCurr = ApproveStationStatusItemAll.S11Draft;
				if (btnSubmit == (int)ButtonState.Forward)
				{
					_AppStationStatusCurr = ApproveStationStatusAll.S2CreateApprove;
					_AppItemStatusPrev = ApproveStationStatusItemAll.S12SaveForward;
					_AppItemStatusCurr = ApproveStationStatusItemAll.S21WaitBookRequestApproval;
				}

				var approvalReqStation = _repo.Context.ApprovalReqStations.FirstOrDefault(x => x.IdSmctMaster == _ParameterCon.IdSmctMaster);
				approvalReqStation.ContractName = indata.InfoRequestForApproval.ContractName;
				approvalReqStation.ContractTypeName = indata.InfoContract.ContractTypeFullName;
				approvalReqStation.StationStatusCurr = _AppStationStatusCurr;
				approvalReqStation.ItemStatusPrev = _AppItemStatusPrev;
				approvalReqStation.ItemStatusCurr = _AppItemStatusCurr;
				approvalReqStation.EditUserFullname = userFullname;
				approvalReqStation.EditUser = _ParameterCon.IdUserSmctCurr;
				approvalReqStation.EditDate = DateTime.Now;
				_db.Update(approvalReqStation);
				await _db.SaveAsync();
			}
		}

		public async Task<ContractStation> UpdateContractStation(TAllMasterVendorView indata)
		{
			var _ParameterCon = indata.ParameterCondition;

			String vendorId = _repo.UserService.GetVendorId();
			String vendorName = _repo.UserService.GetVendorName();
			int btnSubmit = int.Parse(indata.BtnSubmit);
			var userSmcts = _repo.Context.UserSmcts.Where(x => x.Used);
			String userFullname = userSmcts.FirstOrDefault(x => x.IdUserSmct == _ParameterCon.IdUserSmctCurr)?.UserFullname ?? String.Empty;
			var ContractType = _repo.Context.ContractTypes.FirstOrDefault(x => x.Used && x.IdContractType == _ParameterCon.IdContractType);
			var userSmctVendors = _repo.Context.UserSmctVendors.Include(n => n.IdRegisterNhsoNavigation).FirstOrDefault(x => x.Used && x.IdUserSmct == _ParameterCon.IdUserSmctCurr);

			String _ContractName = indata.InfoRequestForApproval.ContractName;
			//ไม่มีหนังสือขออนุมัติ
			if (ContractType.FApprovalReq == false)
				_ContractName = _ParameterCon.ContractTypeFullName;

			var contractStation = _repo.Context.ContractStations.FirstOrDefault(x => x.IdSmctMaster == _ParameterCon.IdSmctMaster);

			var _Contract = _repo.Context.Contracts.FirstOrDefault(x => x.IdSmctMaster == _ParameterCon.IdSmctMaster);
			_Contract.ContractName = _ContractName;
			if (contractStation.ItemStatusPrev == ContractStationStatusItemAll.S43NhsoReject)
			{
				_Contract.Status = ContractStatusAll.S1WaitApprove;
			}
			_Contract.EditUser = _ParameterCon.IdUserSmctCurr;
			_Contract.EditDate = DateTime.Now;
			_db.Update(_Contract);
			await _db.SaveAsync();

			String _ConStationStatusPrev = ContractStationStatusAll.S1Draft;
			String _ConStationStatusCurr = ContractStationStatusAll.S1Draft;
			String _ConItemStatusPrev = ContractStationStatusItemAll.S11Draft;
			String _ConItemStatusCurr = ContractStationStatusItemAll.S11Draft;

			if (btnSubmit == (int)ButtonState.Forward)
			{
				//ไม่มีหนังสือขออนุุมัติ
				if (ContractType.FApprovalReq == false)
				{
					//กำหนดรหัสคู่สัญญา
					if (String.IsNullOrEmpty(userSmctVendors.IdRegisterNhsoNavigation.VendorId))
					{
						_ConStationStatusCurr = ContractStationStatusAll.S3SetVendor;
						_ConItemStatusPrev = ContractStationStatusItemAll.S12SaveForward;
						_ConItemStatusCurr = ContractStationStatusItemAll.S31WaitSetVendor;
					}
					else
					{
						//สร้างนิติกรรมสัญญา
						_ConStationStatusCurr = ContractStationStatusAll.S4CreateContract;
						_ConItemStatusPrev = ContractStationStatusItemAll.S12SaveForward;
						_ConItemStatusCurr = ContractStationStatusItemAll.S41WaitNhsoCreateContract;
					}
				}
				else
				{
					//สร้างหนังสือขออนุมัติ
					_ConStationStatusCurr = ContractStationStatusAll.S2BookRequestApproval;
					_ConItemStatusPrev = ContractStationStatusItemAll.S12SaveForward;
					_ConItemStatusCurr = ContractStationStatusItemAll.S21WaitApproval;
				}
				//ส่งต่อไปสร้างนิติกรรมสัญญา(กรณีหนังสืออนุมัติแล้ว ถูกตีกลับจากขั้นตอนการสร้างนิติกรรม) S43NhsoReject
				if (contractStation.ItemStatusPrev == ContractStationStatusItemAll.S43NhsoReject)
				{
					_ConStationStatusCurr = ContractStationStatusAll.S4CreateContract;
					_ConItemStatusPrev = ContractStationStatusItemAll.S12SaveForward;
					_ConItemStatusCurr = ContractStationStatusItemAll.S41WaitNhsoCreateContract;
				}
				//ส่งต่อไปออกเลขที่สัญญา(กรณี ถูกตีกลับจากขั้นตอนการออกเลขที่สัญญา) S641RejectToVendor
				if (contractStation.ItemStatusPrev == ContractStationStatusItemAll.S641RejectToVendor)
				{
					_ConStationStatusCurr = ContractStationStatusAll.S6ContractNumber;
					_ConItemStatusPrev = ContractStationStatusItemAll.S12SaveForward;
					_ConItemStatusCurr = ContractStationStatusItemAll.S61WaitNhsoCentralCheckApproval;
				}
			}

			contractStation.ContractName = _ContractName;
			contractStation.ContractTypeName = indata.InfoContract.ContractTypeFullName;
			contractStation.StationStatusPrev = _ConStationStatusPrev;
			contractStation.StationStatusCurr = _ConStationStatusCurr;
			contractStation.ItemStatusPrev = _ConItemStatusPrev;
			contractStation.ItemStatusCurr = _ConItemStatusCurr;
			contractStation.EditUserFullname = userFullname;
			contractStation.EditUser = _ParameterCon.IdUserSmctCurr;
			contractStation.EditDate = DateTime.Now;
			_db.Update(contractStation);
			await _db.SaveAsync();

			//กรณีเลือกไม่มีรหัสคู่สัญญา(Vendor) ตอนลงทะเบียน และยังไม่มีการสร้างนิติกรรมของรหัสคู่สัญญานี้ จะเกิดแค่ครั้งแรกที่มีการสร้างนิติกรรมรหัสคู่สัญญานี้
			if (String.IsNullOrEmpty(userSmctVendors.IdRegisterNhsoNavigation.VendorId)
			   && contractStation.ItemStatusPrev != ContractStationStatusItemAll.S43NhsoReject //ไม่ถูกตีกลับจากขั้นตอนการสร้างนิติกรรม
			   && contractStation.ItemStatusPrev != ContractStationStatusItemAll.S641RejectToVendor) //ไม่ถูกตีกลับจากขั้นตอนการออกเลขที่สัญญา
			{
				await this.UpdateVendorLinkReq(indata);
			}

			return contractStation;
		}

		public async Task<VendorLinkReq> UpdateVendorLinkReq(TAllMasterVendorView indata)
		{
			var _ParameterCon = indata.ParameterCondition;

			String vendorId = _repo.UserService.GetVendorId();
			String vendorName = _repo.UserService.GetVendorName();
			int btnSubmit = int.Parse(indata.BtnSubmit);
			var userSmcts = _repo.Context.UserSmcts.Where(x => x.Used);
			String userFullname = userSmcts.FirstOrDefault(x => x.IdUserSmct == _ParameterCon.IdUserSmctCurr)?.UserFullname ?? String.Empty;
			var ContractType = _repo.Context.ContractTypes.FirstOrDefault(x => x.Used && x.IdContractType == _ParameterCon.IdContractType);

			String _ContractName = indata.InfoRequestForApproval.ContractName;
			//ไม่มีหนังสือขออนุมัติ
			if (ContractType.FApprovalReq == false)
				_ContractName = _ParameterCon.ContractTypeFullName;

			var vendorLinkReqStations = _repo.Context.VendorLinkReqStations.FirstOrDefault(x => x.IdSmctMaster == _ParameterCon.IdSmctMaster);
			var vendorLinkReq = _repo.Context.VendorLinkReqs.FirstOrDefault(x => x.IdSmctMaster == _ParameterCon.IdSmctMaster);
			vendorLinkReq.EditUser = _ParameterCon.IdUserSmctCurr;
			vendorLinkReq.EditDate = DateTime.Now;
			_db.Update(vendorLinkReq);
			await _db.SaveAsync();

			String _StationStatusPrev = VendorLinkStationStatusAll.S1CreateProposal;
			String _StationStatusCurr = VendorLinkStationStatusAll.S1CreateProposal;
			String _ItemStatusPrev = VendorLinkStationStatusItemAll.S11Draft;
			String _ItemStatusCurr = VendorLinkStationStatusItemAll.S11Draft;

			if (btnSubmit == (int)ButtonState.Forward && ContractType.FApprovalReq == false)
			{
				_StationStatusCurr = VendorLinkStationStatusAll.S2Check;
				_ItemStatusPrev = VendorLinkStationStatusItemAll.S12SaveForward;
				_ItemStatusCurr = VendorLinkStationStatusItemAll.S21WaitCheck;
			}

			vendorLinkReqStations.ContractName = _ContractName;
			vendorLinkReqStations.ContractTypeName = indata.InfoContract.ContractTypeFullName;
			vendorLinkReqStations.StationStatusPrev = _StationStatusPrev;
			vendorLinkReqStations.StationStatusCurr = _StationStatusCurr;
			vendorLinkReqStations.ItemStatusPrev = _ItemStatusPrev;
			vendorLinkReqStations.ItemStatusCurr = _ItemStatusCurr;
			vendorLinkReqStations.EditUserFullname = userFullname;
			vendorLinkReqStations.EditUser = _ParameterCon.IdUserSmctCurr;
			vendorLinkReqStations.EditDate = DateTime.Now;
			_db.Update(vendorLinkReqStations);
			await _db.SaveAsync();

			return vendorLinkReq;
		}

		public async Task UpdateSigner(TAllMasterVendorView indata)
		{
			using (var _transaction = _repo.BeginTransaction())
			{
				String idSmctMaster = indata.ParameterCondition.IdSmctMaster;
				String _SigningType = SecurityRepo.Decrypt(indata.ParameterCondition.SigningTypeEn);
				String idUserSmct = _repo.UserService.GetIdUserSmct();
				int btnSubmit = int.Parse(indata.BtnSubmit);
				//พยานลงนาม
				if (btnSubmit == (int)ButtonState.SignerWitness)
				{
					var masterSigners = _repo.Context.SmctMasterSigners.FirstOrDefault(x => x.IdSmctMaster == idSmctMaster);
					var masterSignerDetail1s = _repo.Context.SmctMasterSignerDetail1s.FirstOrDefault(x => x.IdSmctMasterSigner == masterSigners.IdSmctMasterSigner);
					masterSignerDetail1s.VendorWitnessStatus = WitnessStatusAll.W2WitnessComplete;
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
					//StationStatusPrev,StationStatusCurr เหมือนกันเพราะต้องไปให้ ฝั่ง สปสข. ลงนามต่อ
					await _repo.ContractShare.UpdateStatusContract(new ParameterStatusStation()
					{
						IdSmctMaster = idSmctMaster,
						Status = ContractStatusAll.S1WaitApprove,
						StationStatusPrev = ContractStationStatusAll.S5Signing2,
						StationStatusCurr = ContractStationStatusAll.S5Signing2,
						ItemStatusPrev = ContractStationStatusItemAll.S51WaitSigning2,
						ItemStatusCurr = ContractStationStatusItemAll.S53WaitSigningNhso
					});
				}
				_transaction.Commit();
			}
		}

		public async Task UpdateRequestBinding(TAllMasterVendorView indata)
		{
			int btnSubmit = int.Parse(indata.BtnSubmit);
			var _requestBinding = indata.InfoRequestBinding;
			String idUserSmct = _repo.UserService.GetIdUserSmct();
			var _ParameterCon = indata.ParameterCondition;

			if (btnSubmit != (int)ButtonState.T0_CANCEL)
			{
				if (_requestBinding.SmctMasterFile.FormFile == null || _requestBinding.SmctMasterFile.FormFile.Length == 0)
					throw new Exception("ระบุไฟล์เอกสารขอแก้ไขนิติกรรม");
				if (_requestBinding.ContractSuccessRemark == null)
					throw new Exception("ระบุหมายเหตุ");
			}

			using (var _transaction = _repo.BeginTransaction())
			{
				String _ContractSuccessStatus = ContractStatusAll.S1WaitApprove;
				if (btnSubmit == (int)ButtonState.T0_CANCEL)
				{
					_ContractSuccessStatus = ContractStatusAll.S0Cancel;
				}
				var contractStationSuccesses = await _repo.Context.ContractStationSuccesses.FirstOrDefaultAsync(x => x.IdSmctMaster == _ParameterCon.IdSmctMaster && x.Used && x.StationStatusCurr == "S7");
				contractStationSuccesses.ContractSuccessType = _ParameterCon.Menu;
				contractStationSuccesses.ContractSuccessStatus = _ContractSuccessStatus;
				contractStationSuccesses.ContractSuccessRemark = _requestBinding.ContractSuccessRemark;
				contractStationSuccesses.ContractSuccessEditUser = idUserSmct;
				contractStationSuccesses.ContractSuccessEditDate = DateTime.Now;
				_db.Update(contractStationSuccesses);
				await _db.SaveAsync();

				if (btnSubmit != (int)ButtonState.T0_CANCEL)
				{

					var _Contract = await _repo.Context.Contracts.Where(x => x.IdSmctMaster == _ParameterCon.IdSmctMaster && x.Used).FirstOrDefaultAsync();
					if (_Contract != null)
					{
						DateTime _ExtendStartDatePrev = _Contract.StartDate.Value;
						DateTime _ExtendEndDatePrev = _Contract.EndDate.Value;

						//ขยายสัญญา
						if (btnSubmit == (int)ButtonState.T3_EXPAND)
						{
							int _ExtendNo = 1;
							ContractExtend _ContractExtend = await _repo.Context.ContractExtends.OrderByDescending(x => x.EditDate).FirstOrDefaultAsync(x => x.IdContract == _Contract.IdContract && x.Used);
							if (_ContractExtend != null)
							{
								if (_ContractExtend.Status == ContractStatusAll.S3Approve)
								{
									//Run เฉพาะอนุมัติ นอกนั้นจะ run no เดิมเรื่อยๆ
									_ExtendNo = _ContractExtend.ExtendNo + 1;
								}
								else
								{
									_ExtendNo = _ContractExtend.ExtendNo;
								}
							}

							_ContractExtend = new ContractExtend()
							{
								CreateUser = idUserSmct,
								EditUser = idUserSmct,
								CreateDate = DateTime.Now,
								EditDate = DateTime.Now,
								Used = true,
								IdContract = _Contract.IdContract,
								Status = ContractStatusAll.S1WaitApprove,
								ExtendNo = _ExtendNo,
								ExtendStartDatePrev = _ExtendStartDatePrev,
								ExtendEndDatePrev = _ExtendEndDatePrev
							};
							await _db.InsterAsync(_ContractExtend);
							await _db.SaveAsync();
						}
					}

					String thaiYear = GeneralUtils.getThaiYear(DateTime.Now.Year);
					var fileFTP = _repo.UploadFiles.GenFileName(_requestBinding.SmctMasterFile.FormFile, _ParameterCon.RefId, $"FILE_{_ParameterCon.ContractTypeId}_RequestBinding");
					var smctMasterFile = await _repo.Context.SmctMasterFiles.FirstOrDefaultAsync(x => x.IdSmctMaster == _ParameterCon.IdSmctMaster && x.Used && x.FileType == "F9");
					if (smctMasterFile != null)
					{
						_db.Delete(smctMasterFile);
						await _db.SaveAsync();
					}
					smctMasterFile = new SmctMasterFile()
					{
						IdSmctMaster = _ParameterCon.IdSmctMaster,
						FileType = "F9",
						FileName = _requestBinding.SmctMasterFile.FormFile.FileName,
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

					String PathFolder = $"RequestBinding/T{_ParameterCon.ContractTypeId}/{thaiYear}";
					this.HandleUploadfile(_requestBinding.SmctMasterFile.FormFile, fileFTP, PathFolder);
				}

				_transaction.Commit();
			}
		}

		//OTHER
		public async Task<ResourceEmail> GetSentMailSignature(TAllMasterVendorView indata, String htmlBody)
		{
			var builder = new BodyBuilder();

			String emailSent = String.Empty;
			builder.HtmlBody = htmlBody;

			var paraCon = indata.ParameterCondition;
			if (paraCon.SendmailType == SendmailTypes.VendorWitness)
			{
				var User = indata.InfoSignerPartnersOfContract.VendorWitnessUser;
				var userSmcts = await _repo.Context.UserSmcts.FirstOrDefaultAsync(x => x.IdUserSmct == User);
				if (userSmcts != null)
				{
					emailSent = userSmcts.Email;
				}
			}
			if (paraCon.SendmailType == SendmailTypes.VendorAuthority)
			{
				var User = indata.InfoSignerPartnersOfContract.VendorSignerUser;
				var userSmcts = await _repo.Context.UserSmcts.FirstOrDefaultAsync(x => x.IdUserSmct == User);
				if (userSmcts != null)
				{
					emailSent = userSmcts.Email;
				}
			}
			if (paraCon.SendmailType == SendmailTypes.NhsoWitness || paraCon.SendmailType == SendmailTypes.NhsoWitnessP)
			{
				var User = indata.InfoSignerPartnersOfContract.NhsoWitnessUser;
				var vNhsoSigners = await _repo.Context.VNhsoSigners.FirstOrDefaultAsync(x => x.EmpId == User);
				if (vNhsoSigners != null)
				{
					emailSent = vNhsoSigners.SignerEmail;
				}
			}
			if (paraCon.SendmailType == SendmailTypes.NhsoAuthority || paraCon.SendmailType == SendmailTypes.NhsoAuthorityP)
			{
				var User = indata.InfoSignerPartnersOfContract.NhsoSignerUser;
				var vNhsoSigners = await _repo.Context.VNhsoSigners.FirstOrDefaultAsync(x => x.EmpId == User);
				if (vNhsoSigners != null)
				{
					emailSent = vNhsoSigners.SignerEmail;
				}
			}

			String _RefId = indata.InfoContract != null ? indata.InfoContract.RefId : String.Empty;

			String _Subject = $"Electronic Sign";
			if (paraCon.SendmailType.StartsWith("SN4"))
				_Subject = $"Paper Sign";

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

		public string SetUrlSignature(TAllMasterVendorView indata)
		{
			String UrlRedirect = String.Empty;
			String ActionSignature = "Signature";
			if (indata.ParameterCondition.SendmailType == SendmailTypes.NhsoWitness || indata.ParameterCondition.SendmailType == SendmailTypes.NhsoAuthority)
			{
				ActionSignature = "SignatureComfirm";
			}
			if (indata.ParameterCondition.SendmailType.StartsWith("SN4"))
			{
				ActionSignature = "PaperComfirm";
			}

			UrlRedirect = $"{_mySet.SubDomainServer}/ElectronicSignature/{ActionSignature}?style={indata.ParameterCondition.Style}";
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
			if (!String.IsNullOrEmpty(indata.ParameterCondition.ContractTypeId))
			{
				UrlRedirect = $"{UrlRedirect}&ContractTypeId={indata.ParameterCondition.ContractTypeId}";
			}
			if (!String.IsNullOrEmpty(indata.ParameterCondition.ContractTypeIdEn))
			{
				UrlRedirect = $"{UrlRedirect}&ContractTypeIdEn={indata.ParameterCondition.ContractTypeIdEn}";
			}
			if (!String.IsNullOrEmpty(indata.ParameterCondition.RefId))
			{
				UrlRedirect = $"{UrlRedirect}&RefId={indata.ParameterCondition.RefId}";
			}
			if (!String.IsNullOrEmpty(indata.ParameterCondition.SendmailType))
			{
				UrlRedirect = $"{UrlRedirect}&SendmailType={indata.ParameterCondition.SendmailType}";
				UrlRedirect = $"{UrlRedirect}&SendmailTypeEn={SecurityRepo.Encrypt(indata.ParameterCondition.SendmailType)}";
			}
			if (!String.IsNullOrEmpty(indata.ParameterCondition.DepartmentCodeCurr))
			{
				UrlRedirect = $"{UrlRedirect}&DepartmentCodeCurr={indata.ParameterCondition.DepartmentCodeCurr}";
			}
			UrlRedirect = $"{UrlRedirect}&IsSentMail={indata.ParameterCondition.IsSentMail}";
			//

			return UrlRedirect;
		}

		public async Task<List<SmctMasterSendmailDTO>> GetSignature(ParameterCondition indata)
		{
			var smctMasterSendmails = _repo.Context.SmctMasterSendmails.Where(x => x.Used && x.IdSmctMaster == indata.IdSmctMaster);

			if (!String.IsNullOrEmpty(indata.SendmailType))
			{
				smctMasterSendmails = smctMasterSendmails.Where(x => x.SendmailType == indata.SendmailType);
			}

			if (smctMasterSendmails != null)
			{
				return _mapper.Map<List<SmctMasterSendmailDTO>>(await smctMasterSendmails.ToListAsync());
			}
			return null;
		}

		public async Task<TAllMasterVendorView> UpdateSignature(TAllMasterVendorView indata)
		{
			String idUserSmct = _repo.UserService.GetIdUserSmct();
			var paraCon = indata.ParameterCondition;
			var emailRes = indata.ResourceEmail;
			var smctMasterSendmails = await _repo.Context.SmctMasterSendmails.FirstOrDefaultAsync(x => x.Used && x.IdSmctMaster == paraCon.IdSmctMaster
																								  && x.SendmailType == paraCon.SendmailType);
			if (smctMasterSendmails == null)
			{
				smctMasterSendmails = new SmctMasterSendmail()
				{
					IdSmctMaster = paraCon.IdSmctMaster,
					SendmailType = paraCon.SendmailType,
					SendmailFr = emailRes.Sender,
					SendmailTo = emailRes.Email,
					SendmailSubject = emailRes.Subject,
					SendmailDetail = emailRes.Builder.HtmlBody,
					SendmailDate = DateTime.Now,
					CreateUser = idUserSmct,
					EditUser = idUserSmct,
					CreateDate = DateTime.Now,
					EditDate = DateTime.Now,
					Used = true
				};
				await _db.InsterAsync(smctMasterSendmails);
				await _db.SaveAsync();
			}

			return indata;
		}

		public async Task SignatureUploadfile(IFormFile FormFile, TAllMasterVendorView indata)
		{
			String idUserSmct = _repo.UserService.GetIdUserSmct();
			var idSmctMaster = indata.ParameterCondition.IdSmctMaster;
			var _SendmailType = indata.ParameterCondition.SendmailType;
			var _ContractTypeId = indata.ParameterCondition.ContractTypeId;
			var _RefId = indata.ParameterCondition.RefId;

			String _fileType = String.Empty;
			if (_SendmailType == SendmailTypes.VendorWitness)
				_fileType = "F4";
			if (_SendmailType == SendmailTypes.VendorAuthority)
				_fileType = "F5";
			if (_SendmailType == SendmailTypes.NhsoWitness)
				_fileType = "F6";
			if (_SendmailType == SendmailTypes.NhsoAuthority)
				_fileType = "F7";

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

			//UploadFilesResource saveFile = new UploadFilesResource()
			//{
			//    Files = new List<IFormFile> { FormFile },
			//    ContentRootPath = _env.ContentRootPath,
			//    SubDirectory = @$"wwwroot\files\Signature\T{PathFolder}\",
			//    FileNameServer = fileFTP
			//};
			//await _repo.UploadFiles.SaveFile(saveFile);
			String PathFolder = $"Signature/T{_ContractTypeId}/{thaiYear}";
			this.HandleUploadfile(FormFile, fileFTP, PathFolder);
		}

		public async Task<bool> CheckSignature(string idSmctMaster, string SendmailType)
		{
			var masterSigners = await _repo.Context.SmctMasterSigners.FirstOrDefaultAsync(x => x.IdSmctMaster == idSmctMaster);
			if (masterSigners != null)
			{
				var masterSignerDetail1s = _repo.Context.SmctMasterSignerDetail1s.FirstOrDefault(x => x.IdSmctMasterSigner == masterSigners.IdSmctMasterSigner);
				if (masterSignerDetail1s != null)
				{
					if (SendmailType == SendmailTypes.VendorWitness)
					{
						return masterSignerDetail1s.VendorWitnessStatus == WitnessStatusAll.W2WitnessComplete;
					}
					else if (SendmailType == SendmailTypes.VendorAuthority)
					{
						var contractStations = _repo.Context.ContractStations.FirstOrDefault(x => x.IdSmctMaster == idSmctMaster);
						return contractStations.ItemStatusCurr == ContractStationStatusItemAll.S53WaitSigningNhso;
					}
					else if (SendmailType == SendmailTypes.NhsoWitness || SendmailType == SendmailTypes.NhsoWitnessP)
					{
						return masterSignerDetail1s.NhsoWitnessStatus == WitnessStatusAll.W2WitnessComplete;
					}
					else if (SendmailType == SendmailTypes.NhsoAuthority)
					{
						var contractStations = _repo.Context.ContractStations.FirstOrDefault(x => x.IdSmctMaster == idSmctMaster);
						return contractStations.ItemStatusCurr == ContractStationStatusItemAll.S71BindingElectronic;
					}
					else if (SendmailType == SendmailTypes.NhsoAuthorityP)
					{
						var contractStations = _repo.Context.ContractStations.FirstOrDefault(x => x.IdSmctMaster == idSmctMaster);
						return contractStations.ItemStatusCurr == ContractStationStatusItemAll.S72BindingPaper;
					}
				}
			}
			return false;
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
			//return saveFile;

			//Create Folder FTP
			//_repo.UploadFiles.FTPMakeDirectory(folderName);

			_repo.UploadFiles.FTPSaveFile(FormFile, fileFTP, folderName);

		}

		private async Task<string> VLRunning()
		{
			int budgetYear = new ThaiBuddhistCalendar().GetYear(DateTime.Now);

			//ปีงบประมาณใหม่
			if (DateTime.Now.Month >= 10 && DateTime.Now.Day >= 1)
				budgetYear++;

			var query = await _repo.Context.VendorLinkReqs.OrderByDescending(x => x.ReqId)
														 .FirstOrDefaultAsync(x => x.Used);

			String _BudgetYear = budgetYear.ToString().Substring(2);
			if (query == null)
			{
				return $"VL{_BudgetYear}00001";
			}

			var registerNo = int.Parse(query.ReqId.Substring(4)) + 1;
			return $"VL{_BudgetYear}{registerNo.ToString("00000")}";

		}

	}
}
