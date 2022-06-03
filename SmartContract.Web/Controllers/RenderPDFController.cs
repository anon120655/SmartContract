using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Resources.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.PDFAPI;
using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Infrastructure.Wrapper;
using SmartContract.Utils;

namespace SmartContract.Web.Controllers
{
	public class RenderPDFController : Controller
	{
		private IRepositoryWrapper _repo;
		private readonly AppSettings _mySet;
		private readonly IWebHostEnvironment _env;

		public RenderPDFController(IRepositoryWrapper repo, IOptions<AppSettings> settings, IWebHostEnvironment env)
		{
			_repo = repo;
			_env = env;
			_mySet = settings.Value;
		}

		//หนังสือขออนุมัติ 
		public async Task<IActionResult> FM_APPROVAL_REQ(ParameterCondition indata, String fmtype = null)
		{
			try
			{
				TAllMasterVendorView data = new TAllMasterVendorView();
				string _StationReq = indata.StationReq;
				indata.ContractTypeIdEn = SecurityRepo.Encrypt(indata.ContractTypeId);
				if (indata.ContractTypeId == "11") data = await _repo.T11BuRepo.GetView(indata);
				if (indata.ContractTypeId == "12") data = await _repo.T12BuRepo.GetView(indata);
				if (indata.ContractTypeId == "13") data = await _repo.T13BuRepo.GetView(indata);
				if (indata.ContractTypeId == "14") data = await _repo.T14BuRepo.GetView(indata);

				var lookUp = data.CTVendor.GetLookUp;
				var indataCon = data.InfoContract;
				var indataPara = data.ParameterCondition;
				var indataNhso = data.InfoContractNhso;
				var indataReqStation = data.ApprovalReqStation;
				var indataConstation = data.ContractStation;
				var indataReqApp = data.InfoRequestForApproval;
				var infoSignature = data.InfoAttachFileSignature;

				String BudgetYear = indataReqStation.ApprovalReqDate.HasValue ? (indataReqStation.ApprovalReqDate.Value.Year + 543).ToString() : String.Empty;

				var FSignature = _repo.GeneralRepo.GetFSignature(infoSignature, indata);
				var board = _repo.Context.VNhsoBorads.FirstOrDefault(x => x.BoradType == "D" && x.DepartmentCode == indataPara.DepartmentCodeCurr);

				var response = await _repo.PDFAPIRepo.FM_APPROVAL_REQ(new FM_APPROVAL_REQ_Request()
				{
					ID = data.InfoContract.RefId ?? "....................",
					HEAD = indataNhso.NhsoAddress.Header ?? " - ",
					ADDRESS0 = indataNhso.NhsoAddress.Address0 ?? " - ",
					ADDRESS1 = indataNhso.NhsoAddress.Address1 ?? " - ",
					ADDRESS2 = indataNhso.NhsoAddress.Address2 ?? " - ",
					F01 = indataReqStation.ApprovalReqId != null ? indataReqStation.ApprovalReqId : "....................",
					F02 = indataReqStation.ApprovalReqDate != null ? GeneralUtils.getFullThaiFullShot(indataReqStation.ApprovalReqDate) : "....................",
					F03 = $"ขออนุมัติดำเนินการตาม{indataCon.ContractTypeFullName} ปีงบประมาณ {BudgetYear}",
					F04 = indataReqStation.DepartmentName ?? " - ",
					F05 = indataReqStation.VendorName ?? " - ",
					F06 = indataReqStation.MasterVendor.VillageNo ?? " - ",
					F07 = indataReqStation.MasterVendor.Road ?? " - ",
					F08 = indataReqStation.MasterVendor.CATMs.DistrictName ?? " - ",
					F09 = indataReqStation.MasterVendor.CATMs.AmphurName ?? " - ",
					F10 = indataReqStation.MasterVendor.CATMs.ProvinceName ?? " - ",
					F11 = indataReqStation.MasterVendor.PostCode ?? " - ",
					F12 = indataReqStation.MasterVendor.Phone ?? " - ",
					F13 = indataReqStation.ContractName ?? " - ",
					F14 = $"ปีงบประมาณ {BudgetYear}",
					F15 = $"งบบริการผู้ป่วยนอกจ่ายแบบเหมาจ่ายต่อผู้มีสิทธิ",
					F16 = indataReqApp.Reason,
					F17 = indataCon.Budget > 0 ? indataCon.Budget.ToString("#,##0.00") : "0" + $"บาท ({GeneralUtils.ThaiBahtText(indataCon.Budget.ToString())})",
					F18 = indataCon.StartDateStr != null ? $"{indataCon.StartDateStr} ถึง {indataCon.EndDateStr}" : "....................ถึง....................",
					F19 = $"{lookUp.Coordinators.FirstOrDefault(x => x.IdUserSmct == indataReqApp.CoordinatorUserSelect)?.UserFullname ?? String.Empty} E-mail {indataReqApp.Email} เบอร์โทรศัพท์  {indataReqApp.Phone} โทรสาร  {indataReqApp.Fax}",
					F20 = lookUp.CommitteeList.FirstOrDefault(x => x.EmpId == indataReqApp.ApprovalReqUserChairm)?.BoradFullname ?? "FALSE",
					F21 = indataReqApp.Committees.Count >= 1 ? lookUp.CommitteeList.FirstOrDefault(x => x.EmpId == indataReqApp.Committees[0].EmpId)?.BoradFullname ?? String.Empty : "FALSE",
					F22 = indataReqApp.Committees.Count >= 2 ? lookUp.CommitteeList.FirstOrDefault(x => x.EmpId == indataReqApp.Committees[1].EmpId)?.BoradFullname ?? String.Empty : "FALSE",
					F23 = indataReqApp.Committees.Count >= 3 ? lookUp.CommitteeList.FirstOrDefault(x => x.EmpId == indataReqApp.Committees[2].EmpId)?.BoradFullname ?? String.Empty : "FALSE",
					F24 = indataReqApp.Committees.Count >= 4 ? lookUp.CommitteeList.FirstOrDefault(x => x.EmpId == indataReqApp.Committees[3].EmpId)?.BoradFullname ?? String.Empty : "FALSE",
					F25 = board?.BoradFullname ?? String.Empty,
					F26 = board?.BoradPosition ?? String.Empty,
					F27 = "",// ไม่ได้ใช้งาน
					FSignature01 = _StationReq == ApproveStationStatusAll.S4Approve ? FSignature.FSignature01APPREQ : String.Empty,
					CHECK1 =  _StationReq == ApproveStationStatusAll.S4Approve ? "/" : "",
					CHECK2 = _StationReq == ApprovalReqStatus.S2UnApprove ? "/" : "",
					DATA = _repo.PDFAPIRepo.DataTable2Base64_APPROVAL_REQ(indataCon)
				});

				if (response.RESP_STATUS == "OK")
				{
					byte[] outPdfBuffer = null;
					outPdfBuffer = System.Convert.FromBase64String(response.PDF_FILE);
					await _repo.ContractShareNhso.UpdateFMPDF(indata, fmtype, outPdfBuffer);
				}

				return Json(new ResultModelJson<FM_CONTRACT_TXX_Response>
				{
					Status = true,
					Result = response
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

		public async Task<IActionResult> FM_CONTRACT_T01(ParameterCondition indata, String fmtype = null)
		{
			try
			{
				indata.ContractTypeIdEn = SecurityRepo.Encrypt(indata.ContractTypeId);
				var data = await _repo.T01BuRepo.GetView(indata);
				var lookUp = data.CTVendor.GetLookUp;
				var indataCon = data.InfoContract;
				var indataVendor = data.InfoPartnersOfContract;
				var indataNhso = data.InfoContractNhso;
				var indataSigner = data.InfoSignerPartnersOfContract;
				var conDetail = data.InfoConDetail.ContractDetail01;
				var infoSignature = data.InfoAttachFileSignature;

				var FSignature = _repo.GeneralRepo.GetFSignature(infoSignature, indata);
				var response = await _repo.PDFAPIRepo.FM_CONTRACT_T01(new FM_CONTRACT_T01_Request()
				{
					ID = data.InfoContract.RefId ?? "....................",
					HEAD = data.ParameterCondition.ContractTypeFullName,
					F01 = data.InfoContract.ContractId != null ? data.InfoContract.ContractId : "....................",
					F03 = indataNhso.NhsoAddress.Header ?? " - ",
					F04 = indataNhso.NhsoAddress.Address ?? " - ",
					F05 = indataNhso.NhsoAddress.Road ?? " - ",
					F06 = indataNhso.NhsoAddress.TumbonName ?? " - ",
					F07 = indataNhso.NhsoAddress.AmphurName ?? " - ",
					F08 = indataNhso.NhsoAddress.ChangwatName ?? " - ",
					F09 = !String.IsNullOrEmpty(indataCon.ContractDateStr) ? int.Parse(indataCon.ContractDateStr.Substring(0, 2)).ToString() : ".....",//String.Empty,
					F10 = !String.IsNullOrEmpty(indataCon.ContractDateStr) ? GeneralUtils.getThaiMonth(int.Parse(indataCon.ContractDateStr.Substring(3, 2))) : "....................",//String.Empty,
					F11 = !String.IsNullOrEmpty(indataCon.ContractDateStr) ? indataCon.ContractDateStr.Substring(6, 4) : "..........",//String.Empty,
					F12 = $"{indataSigner.NhsoSignerUser} ปฏิบัติงานแทนเลขาธิการสำนักงานหลักประกันสุขภาพแห่งชาติ", //data.ContractStation.CreateUserFullname,
					F91 = indataNhso.NhsoContractId ?? " - ",
					F92 = indataNhso.NhsoContractDateStr ?? " - ",
					F13 = indataVendor.VendorName,
					//F13 = $"({indataVendor.VendorId ?? "ไม่มีรหัส"})",
					//F93 = indataVendor.VendorName,
					F93 = String.Empty,
					F14 = indataVendor.VillageNo ?? " - ",
					F17 = indataVendor.Road ?? " - ",
					F18 = indataVendor.CATMs.DistrictName ?? " - ",
					F19 = indataVendor.CATMs.AmphurName ?? " - ",
					F20 = indataVendor.CATMs.ProvinceName ?? " - ",
					F21 = lookUp.UserSmctSigner
					.FirstOrDefault(x => x.IdUserSmct == indataVendor.SmctMasterSigner.SmctMasterSignerDetail1.VendorSignerUser)
					?.UserFullname ?? " - ",
					F23 = " - ",//ชื่อบริษัท
					F24 = " - ",//เลขที่หนังสือลงทะเบียนบริษัท
					F25 = " - ",//ลงวันที่
					F26 = " - ",//เดือน
					F27 = " - ",//ปี พ.ศ.
					F28 = " - ",//และหนังสือมอบอำนาจลงวันที่
					F29 = " - ",//เดือน
					F30 = " - ",//ปี พ.ศ.
					F31 = indataVendor.VendorName ?? " - ",
					F32 = indataVendor.VillageNo ?? " - ",
					F33 = indataVendor.Soi ?? " - ",
					F34 = indataVendor.Road ?? " - ",
					F35 = indataVendor.CATMs.DistrictName ?? " - ",
					F36 = indataVendor.CATMs.AmphurName ?? " - ",
					F37 = indataVendor.CATMs.ProvinceName ?? " - ",
					F38 = " - ",//สพ.7 เลขที่
					F39 = " - ",//ลงวันที่
					F40 = " - ",//เดือน
					F41 = " - ",//ปี พ.ศ.
					F48 = conDetail.P2 ?? " - ",
					F49 = conDetail.P4 ?? " - ",
					F50 = conDetail.P6 ?? " - ",
					F56 = conDetail.P8 ?? " - ",
					F57 = conDetail.P9 ?? " - ",
					CB1 = conDetail.P19 == "1" ? "/" : String.Empty,
					F61 = $"{conDetail.P20} {conDetail.P21} {conDetail.P22} {conDetail.P23} {conDetail.P24}",
					CB2 = conDetail.P19 == "2" ? "/" : String.Empty,
					CB3 = conDetail.P19 == "3" ? "/" : String.Empty,
					CB4 = conDetail.P26 == "1" ? "/" : String.Empty,
					CB5 = conDetail.P26 == "2" ? "/" : String.Empty,
					F58 = $"{conDetail.P27} {conDetail.P28} {conDetail.P29} {conDetail.P30} {conDetail.P31}",

					F64 = conDetail.P37 == "true" ? $"{conDetail.P38} ถึงเวลา {conDetail.P39}" : "เปิดให้บริการ 24 ชั่วโมง",
					F65 = conDetail.P40 == "true" ? $"{conDetail.P41} ถึงเวลา {conDetail.P42}" : "เปิดให้บริการ 24 ชั่วโมง",
					F66 = conDetail.P43 == "true" ? $"{conDetail.P44} ถึงเวลา {conDetail.P45}" : "เปิดให้บริการ 24 ชั่วโมง",
					F67 = conDetail.P46 == "true" ? $"{conDetail.P47} ถึงเวลา {conDetail.P48}" : "เปิดให้บริการ 24 ชั่วโมง",

					//F64 = $"{conDetail.P38 ?? " - "} ถึง {conDetail.P39 ?? " - "}",
					//F65 = $"{conDetail.P41 ?? " - "} ถึง {conDetail.P42 ?? " - "}",
					//F66 = $"{conDetail.P44 ?? " - "} ถึง {conDetail.P45 ?? " - "}",
					//F67 = $"{conDetail.P47 ?? " - "} ถึง {conDetail.P48 ?? " - "}",

					//หลักประกันสัญญา
					F71 = " - ",

					//วันที่ยกเลิกสัญญา 31/08/6x(ปีงบ)
					F59 = " - ",

					//วันที่เริ่ม
					F72 = !String.IsNullOrEmpty(indataCon.StartDateStr) ? int.Parse(indataCon.StartDateStr.Substring(0, 2)).ToString() : ".....",//String.Empty,
					F73 = !String.IsNullOrEmpty(indataCon.StartDateStr) ? GeneralUtils.getThaiMonth(int.Parse(indataCon.StartDateStr.Substring(3, 2))) : "..........",//String.Empty,
					F74 = !String.IsNullOrEmpty(indataCon.StartDateStr) ? indataCon.StartDateStr.Substring(6, 4) : "..........",//String.Empty,

					//วันสิ้นสุด
					F75 = !String.IsNullOrEmpty(indataCon.EndDateStr) ? int.Parse(indataCon.EndDateStr.Substring(0, 2)).ToString() : ".....",//String.Empty,
					F76 = !String.IsNullOrEmpty(indataCon.EndDateStr) ? GeneralUtils.getThaiMonth(int.Parse(indataCon.EndDateStr.Substring(3, 2))) : "..........",//String.Empty,
					F77 = !String.IsNullOrEmpty(indataCon.EndDateStr) ? indataCon.EndDateStr.Substring(6, 4) : "..........",//String.Empty,


					//Footer Sign
					F81 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoSignerUser)?.SignerFullname ?? String.Empty,
					F82 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorSignerUser)?.UserFullname ?? String.Empty,
					//ผู้มีอำนาจลงนาม (สำนักงาน)
					F83 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoSignerUser)?.SignerFullname ?? String.Empty,
					F84 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoSignerUser)?.SignerPosition ?? String.Empty,
					//ผู้มีอำนาจลงนาม (คู่สัญญา)
					F85 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorSignerUser)?.UserFullname ?? String.Empty,
					F86 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorSignerUser)?.PositionName ?? String.Empty,
					//พยาน (สำนักงาน)
					F87 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoWitnessUser)?.SignerFullname ?? String.Empty,
					F88 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoWitnessUser)?.SignerPosition ?? String.Empty,
					//พยาน (คู่สัญญา)
					F89 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorWitnessUser)?.UserFullname ?? String.Empty,
					F90 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorWitnessUser)?.PositionName ?? String.Empty,

					//FSignature
					FSignature01 = FSignature.FSignature01,
					FSignature02 = FSignature.FSignature02,
					FSignature03 = FSignature.FSignature03,
					FSignature04 = FSignature.FSignature04,
					FSignaturefootnote01 = FSignature.FSignature01,
					FSignaturefootnote02 = FSignature.FSignature02
				});

				if (response.RESP_STATUS == "OK")
				{
					byte[] outPdfBuffer = null;
					outPdfBuffer = System.Convert.FromBase64String(response.PDF_FILE);
					await _repo.ContractShareNhso.UpdateFMPDF(indata, fmtype, outPdfBuffer);
				}

				return Json(new ResultModelJson<FM_CONTRACT_TXX_Response>
				{
					Status = true,
					Result = response
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

		public async Task<IActionResult> FM_CONTRACT_T02(ParameterCondition indata, String fmtype = null)
		{
			try
			{
				indata.ContractTypeIdEn = SecurityRepo.Encrypt(indata.ContractTypeId);
				var data = await _repo.T02BuRepo.GetView(indata);
				var lookUp = data.CTVendor.GetLookUp;
				var indataCon = data.InfoContract;
				var indataVendor = data.InfoPartnersOfContract;
				var indataNhso = data.InfoContractNhso;
				var indataSigner = data.InfoSignerPartnersOfContract;
				var conDetail = data.InfoConDetail.ContractDetail02;
				var infoSignature = data.InfoAttachFileSignature;

				var FSignature = _repo.GeneralRepo.GetFSignature(infoSignature, indata);

				var response = await _repo.PDFAPIRepo.FM_CONTRACT_T02(new FM_CONTRACT_T02_Request()
				{
					ID = data.InfoContract.RefId ?? "....................",
					HEAD = data.ParameterCondition.ContractTypeFullName,
					F01 = data.InfoContract.ContractId != null ? data.InfoContract.ContractId : "....................",
					F03 = indataNhso.NhsoAddress.Header ?? " - ",
					F04 = indataNhso.NhsoAddress.Address ?? " - ",
					F05 = indataNhso.NhsoAddress.Road ?? " - ",
					F06 = indataNhso.NhsoAddress.TumbonName ?? " - ",
					F07 = indataNhso.NhsoAddress.AmphurName ?? " - ",
					F08 = indataNhso.NhsoAddress.ChangwatName ?? " - ",
					F09 = !String.IsNullOrEmpty(indataCon.ContractDateStr) ? int.Parse(indataCon.ContractDateStr.Substring(0, 2)).ToString() : ".....",//String.Empty,
					F10 = !String.IsNullOrEmpty(indataCon.ContractDateStr) ? GeneralUtils.getThaiMonth(int.Parse(indataCon.ContractDateStr.Substring(3, 2))) : "....................",//String.Empty,
					F11 = !String.IsNullOrEmpty(indataCon.ContractDateStr) ? indataCon.ContractDateStr.Substring(6, 4) : "..........",//String.Empty,
					F12 = $"{indataSigner.NhsoSignerUser} ปฏิบัติงานแทนเลขาธิการสำนักงานหลักประกันสุขภาพแห่งชาติ", //F12 = data.ContractStation.CreateUserFullname,
					F91 = indataNhso.NhsoContractId ?? " - ",
					F92 = indataNhso.NhsoContractDateStr ?? " - ",
					F13 = indataVendor.VendorName,
					//F93 = indataVendor.VendorName,
					F93 = String.Empty,
					F14 = indataVendor.VillageNo,
					F17 = indataVendor.Road,
					F18 = indataVendor.CATMs.DistrictName ?? " - ",
					F19 = indataVendor.CATMs.AmphurName ?? " - ",
					F20 = indataVendor.CATMs.ProvinceName ?? " - ",
					F21 = " - ",//โดย
					F24 = " - ",//ตามคำสั่งเลขที่
					F25 = " - ",//ลงวันที่
					F26 = " - ",//เดือน
					F27 = " - ",//ปี พ.ศ.
					F31 = indataVendor.VendorName,
					F32 = indataVendor.VillageNo ?? " - ",
					F33 = indataVendor.Soi ?? " - ",
					F34 = indataVendor.Road ?? " - ",
					F35 = indataVendor.CATMs.DistrictName ?? " - ",
					F36 = indataVendor.CATMs.AmphurName ?? " - ",
					F37 = indataVendor.CATMs.ProvinceName ?? " - ",

					F48 = conDetail.A1 ?? " - ",
					F49 = conDetail.A2 ?? " - ",
					F50 = conDetail.A3 ?? " - ",
					F51 = conDetail.A4 ?? " - ",

					CB1 = conDetail.A5 == "1" ? "/" : String.Empty,
					F61 = $"{conDetail.A6}",
					CB2 = conDetail.A5 == "2" ? "/" : String.Empty,

					CB3 = conDetail.A5 == "3" ? "/" : String.Empty,
					CB4 = conDetail.A7 == "true" ? "/" : String.Empty,
					CB5 = conDetail.A8 == "true" ? "/" : String.Empty,
					F63 = $"{conDetail.A9}",

					F64 = conDetail.A10 == "true" ? $"{conDetail.A11} ถึงเวลา {conDetail.A12}" : "เปิดให้บริการ 24 ชั่วโมง",
					F65 = conDetail.A13 == "true" ? $"{conDetail.A14} ถึงเวลา {conDetail.A15}" : "เปิดให้บริการ 24 ชั่วโมง",
					F66 = conDetail.A16 == "true" ? $"{conDetail.A17} ถึงเวลา {conDetail.A18}" : "เปิดให้บริการ 24 ชั่วโมง",
					F67 = conDetail.A16 == "true" ? $"{conDetail.A17} ถึงเวลา {conDetail.A18}" : "เปิดให้บริการ 24 ชั่วโมง", // F67 = conDetail.A19 == "true" ? $"{conDetail.A20} ถึงเวลา {conDetail.A21}" : "เปิดให้บริการ 24 ชั่วโมง",


					//วันที่เริ่ม
					F71 = !String.IsNullOrEmpty(indataCon.StartDateStr) ? int.Parse(indataCon.StartDateStr.Substring(0, 2)).ToString() : ".....",//String.Empty,
					F72 = !String.IsNullOrEmpty(indataCon.StartDateStr) ? GeneralUtils.getThaiMonth(int.Parse(indataCon.StartDateStr.Substring(3, 2))) : "..........",//String.Empty,
					F73 = !String.IsNullOrEmpty(indataCon.StartDateStr) ? indataCon.StartDateStr.Substring(6, 4) : "..........",//String.Empty,

					//วันสิ้นสุด
					F74 = !String.IsNullOrEmpty(indataCon.EndDateStr) ? int.Parse(indataCon.EndDateStr.Substring(0, 2)).ToString() : ".....",//String.Empty,
					F75 = !String.IsNullOrEmpty(indataCon.EndDateStr) ? GeneralUtils.getThaiMonth(int.Parse(indataCon.EndDateStr.Substring(3, 2))) : "..........",//String.Empty,
					F76 = !String.IsNullOrEmpty(indataCon.EndDateStr) ? indataCon.EndDateStr.Substring(6, 4) : "..........",//String.Empty,



					//CB6 = conDetail.P18 == "true" ? "/" : String.Empty,
					//CB7 = conDetail.P19 == "true" ? "/" : String.Empty,
					//CB8 = conDetail.P20 == "true" ? "/" : String.Empty,
					//CB9 = conDetail.IsP21_25 ? "/" : String.Empty,
					//F58 = $"{conDetail.P21} {conDetail.P22} {conDetail.P23} {conDetail.P24} {conDetail.P25}",
					//CB10 = conDetail.P12 == "4" ? "/" : String.Empty,
					//CB11 = conDetail.P27 == "true" ? "/" : String.Empty,
					//CB12 = conDetail.P28 == "true" ? "/" : String.Empty,
					//CB13 = conDetail.P29 == "true" ? "/" : String.Empty,
					//CB14 = conDetail.P30 == "true" ? "/" : String.Empty,
					//CB15 = conDetail.P31 == "true" ? "/" : String.Empty,
					//CB16 = conDetail.P32 == "true" ? "/" : String.Empty,
					//CB17 = conDetail.P33 == "true" ? "/" : String.Empty,
					//CB18 = conDetail.IsP34_28 ? "/" : String.Empty,
					//F59 = $"{conDetail.P34} {conDetail.P35} {conDetail.P36} {conDetail.P37} {conDetail.P38}",

					//F60 = conDetail.P39,
					//F61 = $"{conDetail.P40} {conDetail.P41} {conDetail.P42} {conDetail.P43} {conDetail.P44}",
					//F62 = conDetail.P45,
					//F63 = conDetail.P46,

					//F64 = !conDetail.IsP47 ? $"{conDetail.P48} ถึงเวลา {conDetail.P49}" : "เปิดให้บริการ 24 ชั่วโมง",
					//F65 = !conDetail.IsP50 ? $"{conDetail.P51} ถึงเวลา {conDetail.P52}" : "เปิดให้บริการ 24 ชั่วโมง",
					//F66 = !conDetail.IsP53 ? $"{conDetail.P54} ถึงเวลา {conDetail.P55}" : "เปิดให้บริการ 24 ชั่วโมง",
					//F67 = !conDetail.IsP56 ? $"{conDetail.P57} ถึงเวลา {conDetail.P58}" : "เปิดให้บริการ 24 ชั่วโมง",
					//F68 = conDetail.P59,
					//F69 = !conDetail.IsP60 ? $"{conDetail.P61} ถึงเวลา {conDetail.P62}" : "เปิดให้บริการ 24 ชั่วโมง",
					//F70 = !conDetail.IsP63 ? $"{conDetail.P64} ถึงเวลา {conDetail.P65}" : "เปิดให้บริการ 24 ชั่วโมง",

					//Footer Sign
					F81 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoSignerUser)?.SignerFullname ?? String.Empty,
					F82 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorSignerUser)?.UserFullname ?? String.Empty,
					//ผู้มีอำนาจลงนาม (สำนักงาน)
					F83 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoSignerUser)?.SignerFullname ?? String.Empty,
					F84 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoSignerUser)?.SignerPosition ?? String.Empty,
					//ผู้มีอำนาจลงนาม (คู่สัญญา)
					F85 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorSignerUser)?.UserFullname ?? String.Empty,
					F86 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorSignerUser)?.PositionName ?? String.Empty,
					//พยาน (สำนักงาน)
					F87 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoWitnessUser)?.SignerFullname ?? String.Empty,
					F88 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoWitnessUser)?.SignerPosition ?? String.Empty,
					//พยาน (คู่สัญญา)
					F89 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorWitnessUser)?.UserFullname ?? String.Empty,
					F90 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorWitnessUser)?.PositionName ?? String.Empty,

					//FSignature
					FSignature02 = FSignature.FSignature02,
					FSignature04 = FSignature.FSignature04,
					FSignature01 = FSignature.FSignature01,
					FSignature03 = FSignature.FSignature03,
					FSignaturefootnote01 = FSignature.FSignature01,
					FSignaturefootnote02 = FSignature.FSignature02
				});

				byte[] outPdfBuffer = null;

				if (response.RESP_STATUS == "OK")
				{
					outPdfBuffer = System.Convert.FromBase64String(response.PDF_FILE);
					await _repo.ContractShareNhso.UpdateFMPDF(indata, fmtype, outPdfBuffer);
				}

				return Json(new ResultModelJson<FM_CONTRACT_TXX_Response>
				{
					Status = true,
					Result = response
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

		public async Task<IActionResult> FM_CONTRACT_T03(ParameterCondition indata, String fmtype = null)
		{
			try
			{
				indata.ContractTypeIdEn = SecurityRepo.Encrypt(indata.ContractTypeId);
				var data = await _repo.T03BuRepo.GetView(indata);
				var lookUp = data.CTVendor.GetLookUp;
				var indataCon = data.InfoContract;
				var indataVendor = data.InfoPartnersOfContract;
				var indataNhso = data.InfoContractNhso;
				var indataSigner = data.InfoSignerPartnersOfContract;
				var conDetail = data.InfoConDetail.ContractDetail03;
				var infoSignature = data.InfoAttachFileSignature;

				var FSignature = _repo.GeneralRepo.GetFSignature(infoSignature, indata);

				var response = await _repo.PDFAPIRepo.FM_CONTRACT_T03(new FM_CONTRACT_T03_Request()
				{
					ID = data.InfoContract.RefId ?? "....................",
					HEAD = data.ParameterCondition.ContractTypeFullName,
					F01 = data.InfoContract.ContractId != null ? data.InfoContract.ContractId : "....................",
					F02 = indataNhso.NhsoAddress.Header ?? " - ",
					F03 = indataNhso.NhsoAddress.Address ?? " - ",
					F05 = indataNhso.NhsoAddress.Road ?? " - ",
					F06 = indataNhso.NhsoAddress.TumbonName ?? " - ",
					F07 = indataNhso.NhsoAddress.AmphurName ?? " - ",
					F08 = indataNhso.NhsoAddress.ChangwatName ?? " - ",
					F09 = !String.IsNullOrEmpty(indataNhso.NhsoContractDateStr) ? int.Parse(indataNhso.NhsoContractDateStr.Substring(0, 2)).ToString() : ".....",//String.Empty,
					F10 = !String.IsNullOrEmpty(indataNhso.NhsoContractDateStr) ? GeneralUtils.getThaiMonth(int.Parse(indataNhso.NhsoContractDateStr.Substring(3, 2))) : "....................",//String.Empty,
					F11 = !String.IsNullOrEmpty(indataNhso.NhsoContractDateStr) ? indataNhso.NhsoContractDateStr.Substring(6, 4) : "..........",//String.Empty,
																																				//F12 = data.ContractStation.CreateUserFullname,
					F12 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataNhso.EmpId)?.SignerFullname ?? String.Empty,
					F45 = conDetail.P1,
					F46 = conDetail.P2,
					F47 = conDetail.P3,

					//Footer Sign
					F81 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoSignerUser)?.SignerFullname ?? String.Empty,
					F82 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorSignerUser)?.UserFullname ?? String.Empty,
					//ผู้มีอำนาจลงนาม (สำนักงาน)
					F83 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoSignerUser)?.SignerFullname ?? String.Empty,
					F84 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoSignerUser)?.SignerPosition ?? String.Empty,
					//ผู้มีอำนาจลงนาม (คู่สัญญา)
					F85 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorSignerUser)?.UserFullname ?? String.Empty,
					F86 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorSignerUser)?.PositionName ?? String.Empty,
					//พยาน (สำนักงาน)
					F87 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoWitnessUser)?.SignerFullname ?? String.Empty,
					F88 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoWitnessUser)?.SignerPosition ?? String.Empty,
					//พยาน (คู่สัญญา)
					F89 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorWitnessUser)?.UserFullname ?? String.Empty,
					F90 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorWitnessUser)?.PositionName ?? String.Empty,

					//FSignature
					FSignature02 = FSignature.FSignature02,
					FSignature04 = FSignature.FSignature04,
					FSignature01 = FSignature.FSignature01,
					FSignature03 = FSignature.FSignature03,
					FSignaturefootnote01 = FSignature.FSignature01,
					FSignaturefootnote02 = FSignature.FSignature02
				});

				byte[] outPdfBuffer = null;

				if (response.RESP_STATUS == "OK")
				{
					outPdfBuffer = System.Convert.FromBase64String(response.PDF_FILE);
					await _repo.ContractShareNhso.UpdateFMPDF(indata, fmtype, outPdfBuffer);
				}

				return Json(new ResultModelJson<FM_CONTRACT_TXX_Response>
				{
					Status = true,
					Result = response
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

		public async Task<IActionResult> FM_CONTRACT_T04(ParameterCondition indata, String fmtype = null)
		{
			try
			{
				indata.ContractTypeIdEn = SecurityRepo.Encrypt(indata.ContractTypeId);
				var data = await _repo.T04BuRepo.GetView(indata);
				var lookUp = data.CTVendor.GetLookUp;
				var indataVendor = data.InfoPartnersOfContract;
				var indataNhso = data.InfoContractNhso;
				var indataSigner = data.InfoSignerPartnersOfContract;
				var conDetail = data.InfoConDetail.ContractDetail04;
				var infoSignature = data.InfoAttachFileSignature;

				var FSignature = _repo.GeneralRepo.GetFSignature(infoSignature, indata);

				var response = await _repo.PDFAPIRepo.FM_CONTRACT_T04(new FM_CONTRACT_T04_Request()
				{
					ID = data.InfoContract.RefId ?? "....................",
					HEAD = data.ParameterCondition.ContractTypeFullName,
					F01 = data.InfoContract.ContractId != null ? data.InfoContract.ContractId : "....................",

					F05 = indataNhso.NhsoAddress.Road ?? " - ",
					F06 = indataNhso.NhsoAddress.TumbonName ?? " - ",
					F07 = indataNhso.NhsoAddress.AmphurName ?? " - ",
					F08 = indataNhso.NhsoAddress.ChangwatName ?? " - ",

					F45 = conDetail.P1 ?? " - ",
					F46 = conDetail.P2 ?? " - ",
					F47 = conDetail.P3 ?? " - ",

					//Footer Sign
					F81 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoSignerUser)?.SignerFullname ?? String.Empty,
					F82 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorSignerUser)?.UserFullname ?? String.Empty,
					//ผู้มีอำนาจลงนาม (สำนักงาน)
					F83 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoSignerUser)?.SignerFullname ?? String.Empty,
					F84 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoSignerUser)?.SignerPosition ?? String.Empty,
					//ผู้มีอำนาจลงนาม (คู่สัญญา)
					F85 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorSignerUser)?.UserFullname ?? String.Empty,
					F86 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorSignerUser)?.PositionName ?? String.Empty,
					//พยาน (สำนักงาน)
					F87 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoWitnessUser)?.SignerFullname ?? String.Empty,
					F88 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoWitnessUser)?.SignerPosition ?? String.Empty,
					//พยาน (คู่สัญญา)
					F89 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorWitnessUser)?.UserFullname ?? String.Empty,
					F90 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorWitnessUser)?.PositionName ?? String.Empty,

					//FSignature
					FSignature02 = FSignature.FSignature02,
					FSignature04 = FSignature.FSignature04,
					FSignature01 = FSignature.FSignature01,
					FSignature03 = FSignature.FSignature03,
					FSignaturefootnote01 = FSignature.FSignature01,
					FSignaturefootnote02 = FSignature.FSignature02
				});

				byte[] outPdfBuffer = null;

				if (response.RESP_STATUS == "OK")
				{
					outPdfBuffer = System.Convert.FromBase64String(response.PDF_FILE);
					await _repo.ContractShareNhso.UpdateFMPDF(indata, fmtype, outPdfBuffer);
				}

				return Json(new ResultModelJson<FM_CONTRACT_TXX_Response>
				{
					Status = true,
					Result = response
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

		public async Task<IActionResult> FM_CONTRACT_T05(ParameterCondition indata, String fmtype = null)
		{
			try
			{
				indata.ContractTypeIdEn = SecurityRepo.Encrypt(indata.ContractTypeId);
				var data = await _repo.T05BuRepo.GetView(indata);
				var lookUp = data.CTVendor.GetLookUp;
				var indataVendor = data.InfoPartnersOfContract;
				var indataCon = data.InfoContract;
				var indataNhso = data.InfoContractNhso;
				var indataSigner = data.InfoSignerPartnersOfContract;
				var conDetail = data.InfoConDetail.ContractDetail05;
				var infoSignature = data.InfoAttachFileSignature;

				var FSignature = _repo.GeneralRepo.GetFSignature(infoSignature, indata);

				var response = await _repo.PDFAPIRepo.FM_CONTRACT_T05(new FM_CONTRACT_T05_Request()
				{
					ID = data.InfoContract.RefId ?? "....................",
					HEAD = data.ParameterCondition.ContractTypeFullName,
					F01 = data.InfoContract.ContractId != null ? data.InfoContract.ContractId : "....................",
					F03 = indataNhso.NhsoAddress.Header ?? " - ",
					F05 = indataNhso.NhsoAddress.Road ?? " - ",
					F06 = indataNhso.NhsoAddress.TumbonName ?? " - ",
					F07 = indataNhso.NhsoAddress.AmphurName ?? " - ",
					F08 = indataNhso.NhsoAddress.ChangwatName ?? " - ",

					F41 = !String.IsNullOrEmpty(indataCon.StartDateStr) ? int.Parse(indataCon.StartDateStr.Substring(0, 2)).ToString() : ".....",//String.Empty,
					F42 = !String.IsNullOrEmpty(indataCon.StartDateStr) ? GeneralUtils.getThaiMonth(int.Parse(indataCon.StartDateStr.Substring(3, 2))) : "....................",//String.Empty,
					F43 = !String.IsNullOrEmpty(indataCon.StartDateStr) ? indataCon.StartDateStr.Substring(6, 4) : "..........",//String.Empty,
					F12 = data.ContractStation.CreateUserFullname,

					F44 = !String.IsNullOrEmpty(indataCon.EndDateStr) ? int.Parse(indataCon.EndDateStr.Substring(0, 2)).ToString() : ".....",//String.Empty,
					F45 = !String.IsNullOrEmpty(indataCon.EndDateStr) ? GeneralUtils.getThaiMonth(int.Parse(indataCon.EndDateStr.Substring(3, 2))) : "....................",//String.Empty,
					F46 = !String.IsNullOrEmpty(indataCon.EndDateStr) ? indataCon.EndDateStr.Substring(6, 4) : "..........",//String.Empty,

					//Footer Sign
					F71 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoSignerUser)?.SignerFullname ?? String.Empty,
					F72 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorSignerUser)?.UserFullname ?? String.Empty,
					//ผู้มีอำนาจลงนาม (สำนักงาน)
					F73 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoSignerUser)?.SignerFullname ?? String.Empty,
					F74 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoSignerUser)?.SignerPosition ?? String.Empty,
					//ผู้มีอำนาจลงนาม (คู่สัญญา)
					F75 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorSignerUser)?.UserFullname ?? String.Empty,
					F76 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorSignerUser)?.PositionName ?? String.Empty,
					//พยาน (สำนักงาน)
					F77 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoWitnessUser)?.SignerFullname ?? String.Empty,
					F78 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoWitnessUser)?.SignerPosition ?? String.Empty,
					//พยาน (คู่สัญญา)
					F79 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorWitnessUser)?.UserFullname ?? String.Empty,
					F70 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorWitnessUser)?.PositionName ?? String.Empty,

					//FSignature
					FSignature02 = FSignature.FSignature02,
					FSignature04 = FSignature.FSignature04,
					FSignature01 = FSignature.FSignature01,
					FSignature03 = FSignature.FSignature03,
					FSignaturefootnote01 = FSignature.FSignature01,
					FSignaturefootnote02 = FSignature.FSignature02
				});

				byte[] outPdfBuffer = null;

				if (response.RESP_STATUS == "OK")
				{
					outPdfBuffer = System.Convert.FromBase64String(response.PDF_FILE);
					await _repo.ContractShareNhso.UpdateFMPDF(indata, fmtype, outPdfBuffer);
				}

				return Json(new ResultModelJson<FM_CONTRACT_TXX_Response>
				{
					Status = true,
					Result = response
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

		public async Task<IActionResult> FM_CONTRACT_T06(ParameterCondition indata, String fmtype = null)
		{
			try
			{
				indata.ContractTypeIdEn = SecurityRepo.Encrypt(indata.ContractTypeId);
				var data = await _repo.T06BuRepo.GetView(indata);
				var response = await _repo.PDFAPIRepo.FM_CONTRACT_T06(new FM_CONTRACT_T06_Request()
				{

				}
				);

				byte[] outPdfBuffer = null;

				if (response.RESP_STATUS == "OK")
				{
					outPdfBuffer = System.Convert.FromBase64String(response.PDF_FILE);
					await _repo.ContractShareNhso.UpdateFMPDF(indata, fmtype, outPdfBuffer);
				}

				return Json(new ResultModelJson<FM_CONTRACT_TXX_Response>
				{
					Status = true,
					Result = response
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

		public async Task<IActionResult> FM_CONTRACT_T07(ParameterCondition indata, String fmtype = null)
		{
			try
			{
				indata.ContractTypeIdEn = SecurityRepo.Encrypt(indata.ContractTypeId);
				var data = await _repo.T07BuRepo.GetView(indata);
				var response = await _repo.PDFAPIRepo.FM_CONTRACT_T07(new FM_CONTRACT_T07_Request()
				{

				}
				);

				byte[] outPdfBuffer = null;

				if (response.RESP_STATUS == "OK")
				{
					outPdfBuffer = System.Convert.FromBase64String(response.PDF_FILE);
					await _repo.ContractShareNhso.UpdateFMPDF(indata, fmtype, outPdfBuffer);
				}

				return Json(new ResultModelJson<FM_CONTRACT_TXX_Response>
				{
					Status = true,
					Result = response
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

		public async Task<IActionResult> FM_CONTRACT_T08(ParameterCondition indata, String fmtype = null)
		{
			try
			{
				indata.ContractTypeIdEn = SecurityRepo.Encrypt(indata.ContractTypeId);
				var data = await _repo.T08BuRepo.GetView(indata);
				var response = await _repo.PDFAPIRepo.FM_CONTRACT_T08(new FM_CONTRACT_T08_Request()
				{

				}
				);

				byte[] outPdfBuffer = null;

				if (response.RESP_STATUS == "OK")
				{
					outPdfBuffer = System.Convert.FromBase64String(response.PDF_FILE);
					await _repo.ContractShareNhso.UpdateFMPDF(indata, fmtype, outPdfBuffer);
				}

				return Json(new ResultModelJson<FM_CONTRACT_TXX_Response>
				{
					Status = true,
					Result = response
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

		public async Task<IActionResult> FM_CONTRACT_T09(ParameterCondition indata, String fmtype = null)
		{
			try
			{
				indata.ContractTypeIdEn = SecurityRepo.Encrypt(indata.ContractTypeId);
				var data = await _repo.T09BuRepo.GetView(indata);
				var response = await _repo.PDFAPIRepo.FM_CONTRACT_T09(new FM_CONTRACT_T09_Request()
				{

				}
				);

				byte[] outPdfBuffer = null;

				if (response.RESP_STATUS == "OK")
				{
					outPdfBuffer = System.Convert.FromBase64String(response.PDF_FILE);
					await _repo.ContractShareNhso.UpdateFMPDF(indata, fmtype, outPdfBuffer);
				}

				return Json(new ResultModelJson<FM_CONTRACT_TXX_Response>
				{
					Status = true,
					Result = response
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

		public async Task<IActionResult> FM_CONTRACT_T10(ParameterCondition indata, String fmtype = null)
		{
			try
			{
				indata.ContractTypeIdEn = SecurityRepo.Encrypt(indata.ContractTypeId);
				var data = await _repo.T10BuRepo.GetView(indata);
				var lookUp = data.CTVendor.GetLookUp;
				var indataVendor = data.InfoPartnersOfContract;
				var indataCon = data.InfoContract;
				var indataNhso = data.InfoContractNhso;
				var indataSigner = data.InfoSignerPartnersOfContract;
				var conDetail = data.InfoConDetail.ContractDetail10;
				var infoSignature = data.InfoAttachFileSignature;

				var FSignature = _repo.GeneralRepo.GetFSignature(infoSignature, indata);

				var response = await _repo.PDFAPIRepo.FM_CONTRACT_T10(new FM_CONTRACT_T10_Request()
				{
					ID = data.InfoContract.RefId ?? "....................",
					HEAD = data.ParameterCondition.ContractTypeFullName,
					F01 = data.InfoContract.ContractId != null ? data.InfoContract.ContractId : "....................",
					F03 = indataNhso.NhsoAddress.Header ?? " - ",
					F05 = indataNhso.NhsoAddress.Road ?? " - ",
					F06 = indataNhso.NhsoAddress.TumbonName ?? " - ",
					F07 = indataNhso.NhsoAddress.AmphurName ?? " - ",
					F08 = indataNhso.NhsoAddress.ChangwatName ?? " - ",

					F40 = !String.IsNullOrEmpty(indataCon.StartDateStr) ? int.Parse(indataCon.StartDateStr.Substring(0, 2)).ToString() : ".....",//String.Empty,
					F41 = !String.IsNullOrEmpty(indataCon.StartDateStr) ? GeneralUtils.getThaiMonth(int.Parse(indataCon.StartDateStr.Substring(3, 2))) : "....................",//String.Empty,
					F42 = !String.IsNullOrEmpty(indataCon.StartDateStr) ? indataCon.StartDateStr.Substring(6, 4) : "..........",//String.Empty,

					F43 = !String.IsNullOrEmpty(indataCon.EndDateStr) ? int.Parse(indataCon.EndDateStr.Substring(0, 2)).ToString() : ".....",//String.Empty,
					F44 = !String.IsNullOrEmpty(indataCon.EndDateStr) ? GeneralUtils.getThaiMonth(int.Parse(indataCon.EndDateStr.Substring(3, 2))) : "....................",//String.Empty,
					F45 = !String.IsNullOrEmpty(indataCon.EndDateStr) ? indataCon.EndDateStr.Substring(6, 4) : "..........",//String.Empty,

					//Footer Sign
					F71 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoSignerUser)?.SignerFullname ?? String.Empty,
					F72 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorSignerUser)?.UserFullname ?? String.Empty,
					//ผู้มีอำนาจลงนาม (สำนักงาน)
					F73 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoSignerUser)?.SignerFullname ?? String.Empty,
					F74 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoSignerUser)?.SignerPosition ?? String.Empty,
					//ผู้มีอำนาจลงนาม (คู่สัญญา)
					F75 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorSignerUser)?.UserFullname ?? String.Empty,
					F76 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorSignerUser)?.PositionName ?? String.Empty,
					//พยาน (สำนักงาน)
					F77 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoWitnessUser)?.SignerFullname ?? String.Empty,
					F78 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoWitnessUser)?.SignerPosition ?? String.Empty,
					//พยาน (คู่สัญญา)
					F79 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorWitnessUser)?.UserFullname ?? String.Empty,
					F70 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorWitnessUser)?.PositionName ?? String.Empty,

					//FSignature
					FSignature02 = FSignature.FSignature02,
					FSignature04 = FSignature.FSignature04,
					FSignature01 = FSignature.FSignature01,
					FSignature03 = FSignature.FSignature03,
					FSignaturefootnote01 = FSignature.FSignature01,
					FSignaturefootnote02 = FSignature.FSignature02
				});

				byte[] outPdfBuffer = null;

				if (response.RESP_STATUS == "OK")
				{
					outPdfBuffer = System.Convert.FromBase64String(response.PDF_FILE);
					await _repo.ContractShareNhso.UpdateFMPDF(indata, fmtype, outPdfBuffer);
				}

				return Json(new ResultModelJson<FM_CONTRACT_TXX_Response>
				{
					Status = true,
					Result = response
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

		public async Task<IActionResult> FM_CONTRACT_T11(ParameterCondition indata, String fmtype = null)
		{
			try
			{
				indata.ContractTypeIdEn = SecurityRepo.Encrypt(indata.ContractTypeId);
				var data = await _repo.T11BuRepo.GetView(indata);
				var lookUp = data.CTVendor.GetLookUp;
				var indataVendor = data.InfoPartnersOfContract;
				var indataCon = data.InfoContract;
				var indataNhso = data.InfoContractNhso;
				var indataSigner = data.InfoSignerPartnersOfContract;
				var conDetail = data.InfoConDetail.ContractDetail11;
				var infoSignature = data.InfoAttachFileSignature;

				var FSignature = _repo.GeneralRepo.GetFSignature(infoSignature, indata);

				var response = await _repo.PDFAPIRepo.FM_CONTRACT_T11(new FM_CONTRACT_T11_Request()
				{
					ID = data.InfoContract.RefId ?? "....................",
					HEAD = data.ParameterCondition.ContractTypeFullName,
					F01 = data.InfoContract.ContractId != null ? data.InfoContract.ContractId : "....................",
					F03 = indataNhso.NhsoAddress.Header ?? " - ",
					F04 = indataNhso.NhsoAddress.Address ?? " - ",
					F05 = indataNhso.NhsoAddress.Road ?? " - ",
					F06 = indataNhso.NhsoAddress.TumbonName ?? " - ",
					F07 = indataNhso.NhsoAddress.AmphurName ?? " - ",
					F08 = indataNhso.NhsoAddress.ChangwatName ?? " - ",

					F09 = !String.IsNullOrEmpty(indataCon.ContractDateStr) ? int.Parse(indataCon.ContractDateStr.Substring(0, 2)).ToString() : ".....",//String.Empty,
					F10 = !String.IsNullOrEmpty(indataCon.ContractDateStr) ? GeneralUtils.getThaiMonth(int.Parse(indataCon.ContractDateStr.Substring(3, 2))) : "....................",//String.Empty,
					F11 = !String.IsNullOrEmpty(indataCon.ContractDateStr) ? indataCon.ContractDateStr.Substring(6, 4) : "..........",//String.Empty,

					F12 = $"{indataSigner.NhsoSignerUser} ปฏิบัติงานแทนเลขาธิการสำนักงานหลักประกันสุขภาพแห่งชาติ",
					F29 = indataNhso.NhsoContractId ?? " - ",
					F30 = indataNhso.NhsoContractDateStr ?? " - ",
					F13 = indataVendor.VendorName ?? " - ",
					F20 = " - ",//จดทะเบียนเป็นนิติบุคคล ณ
					F14 = " - ",//เลขที่
					F15 = " - ",//ถนน
					F16 = " - ",//ตำบล
					F17 = " - ",//อำเภอ
					F18 = " - ",//จังหวัด
					F19 = lookUp.UserSmctSigner
					.FirstOrDefault(x => x.IdUserSmct == indataVendor.SmctMasterSigner.SmctMasterSignerDetail1.VendorSignerUser)
					?.UserFullname ?? " - ",
					F21 = " - ",//ชื่อบริษัท
					F22 = " - ",//เลขที่หนังสือลงทะเบียนบริษัท
					F23 = " - ",//ลงวันที่
					F24 = " - ",//เดือน
					F25 = " - ",//ปี พ.ศ.
					F26 = " - ",//และหนังสือมอบอำนาจลงวันที่
					F27 = " - ",//เดือน
					F28 = " - ",//ปี พ.ศ.

					F40 = conDetail.A1 ?? " - ",

					//วันที่เริ่ม
					F61 = !String.IsNullOrEmpty(indataCon.StartDateStr) ? int.Parse(indataCon.StartDateStr.Substring(0, 2)).ToString() : ".....",//String.Empty,
					F62 = !String.IsNullOrEmpty(indataCon.StartDateStr) ? GeneralUtils.getThaiMonth(int.Parse(indataCon.StartDateStr.Substring(3, 2))) : "....................",//String.Empty,
					F63 = !String.IsNullOrEmpty(indataCon.StartDateStr) ? indataCon.StartDateStr.Substring(6, 4) : "..........",//String.Empty,

					//วันที่สิ้นสุด
					F64 = !String.IsNullOrEmpty(indataCon.EndDateStr) ? int.Parse(indataCon.EndDateStr.Substring(0, 2)).ToString() : ".....",//String.Empty,
					F65 = !String.IsNullOrEmpty(indataCon.EndDateStr) ? GeneralUtils.getThaiMonth(int.Parse(indataCon.EndDateStr.Substring(3, 2))) : "....................",//String.Empty,
					F66 = !String.IsNullOrEmpty(indataCon.EndDateStr) ? indataCon.EndDateStr.Substring(6, 4) : "..........",//String.Empty,


					F42 = conDetail.A3 ?? " - ",
					F43 = conDetail.A4 ?? " - ",
					F44 = conDetail.A5 ?? " - ",
					F45 = conDetail.A6 ?? " - ",
					F46 = conDetail.A7 ?? " - ",
					F47 = conDetail.A8 ?? " - ",
					F48 = indataCon.Budget > 0 ? indataCon.Budget.ToString("#,##0.00") : " - ",
					F49 = GeneralUtils.ThaiBahtText(indataCon.Budget.ToString()),

					//ข้อมูลธนาคาร Verdor
					F51 = conDetail.A11 ?? " - ",
					F52 = conDetail.A12 ?? " - ",
					F53 = conDetail.A13 ?? " - ",
					F54 = conDetail.A14 ?? " - ",

					//ข้อมูลหลักประกัน
					F55 = " - ",
					F56 = " - ",
					F57 = " - ",

					//หักงวดที่ 1
					F58 = " - ",
					F59 = " - ",

					//Footer Sign
					F71 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoSignerUser)?.SignerFullname ?? String.Empty,
					F72 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorSignerUser)?.UserFullname ?? String.Empty,
					//ผู้มีอำนาจลงนาม (สำนักงาน)
					F73 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoSignerUser)?.SignerFullname ?? String.Empty,
					F74 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoSignerUser)?.SignerPosition ?? String.Empty,
					//ผู้มีอำนาจลงนาม (คู่สัญญา)
					F75 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorSignerUser)?.UserFullname ?? String.Empty,
					F76 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorSignerUser)?.PositionName ?? String.Empty,
					//พยาน (สำนักงาน)
					F77 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoWitnessUser)?.SignerFullname ?? String.Empty,
					F78 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoWitnessUser)?.SignerPosition ?? String.Empty,
					//พยาน (คู่สัญญา)
					F79 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorWitnessUser)?.UserFullname ?? String.Empty,
					F80 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorWitnessUser)?.PositionName ?? String.Empty,

					//FSignature
					FSignature02 = FSignature.FSignature02,
					FSignature04 = FSignature.FSignature04,
					FSignature01 = FSignature.FSignature01,
					FSignature03 = FSignature.FSignature03,
					FSignaturefootnote01 = FSignature.FSignature01,
					FSignaturefootnote02 = FSignature.FSignature02
				});

				byte[] outPdfBuffer = null;

				if (response.RESP_STATUS == "OK")
				{
					outPdfBuffer = System.Convert.FromBase64String(response.PDF_FILE);
					await _repo.ContractShareNhso.UpdateFMPDF(indata, fmtype, outPdfBuffer);
				}

				return Json(new ResultModelJson<FM_CONTRACT_TXX_Response>
				{
					Status = true,
					Result = response
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

		public async Task<IActionResult> FM_CONTRACT_T12(ParameterCondition indata, String fmtype = null)
		{
			try
			{
				indata.ContractTypeIdEn = SecurityRepo.Encrypt(indata.ContractTypeId);
				var data = await _repo.T12BuRepo.GetView(indata);
				var lookUp = data.CTVendor.GetLookUp;
				var indataCon = data.InfoContract;
				var indataVendor = data.InfoPartnersOfContract;
				var indataNhso = data.InfoContractNhso;
				var indataSigner = data.InfoSignerPartnersOfContract;
				var conDetail = data.InfoConDetail.ContractDetail12;
				var infoSignature = data.InfoAttachFileSignature;

				var FSignature = _repo.GeneralRepo.GetFSignature(infoSignature, indata);

				var response = await _repo.PDFAPIRepo.FM_CONTRACT_T12(new FM_CONTRACT_T12_Request()
				{
					ID = data.InfoContract.RefId ?? "....................",
					HEAD = data.ParameterCondition.ContractTypeFullName,
					F01 = data.InfoContract.ContractId != null ? data.InfoContract.ContractId : "....................",
					F03 = indataNhso.NhsoAddress.Header ?? " - ",
					F04 = indataNhso.NhsoAddress.Soi ?? " - ",
					F05 = indataNhso.NhsoAddress.Road ?? " - ",
					F06 = indataNhso.NhsoAddress.TumbonName ?? " - ",
					F07 = indataNhso.NhsoAddress.AmphurName ?? " - ",
					F08 = indataNhso.NhsoAddress.ChangwatName ?? " - ",

					F09 = !String.IsNullOrEmpty(indataCon.ContractDateStr) ? int.Parse(indataCon.ContractDateStr.Substring(0, 2)).ToString() : ".....",//String.Empty,
					F10 = !String.IsNullOrEmpty(indataCon.ContractDateStr) ? GeneralUtils.getThaiMonth(int.Parse(indataCon.ContractDateStr.Substring(3, 2))) : "....................",//String.Empty,
					F11 = !String.IsNullOrEmpty(indataCon.ContractDateStr) ? indataCon.ContractDateStr.Substring(6, 4) : "..........",//String.Empty,

					F12 = $"{indataSigner.NhsoSignerUser} ปฏิบัติงานแทนเลขาธิการสำนักงานหลักประกันสุขภาพแห่งชาติ",
					F20 = indataNhso.NhsoContractId ?? " - ",
					F21 = indataNhso.NhsoContractDateStr ?? " - ",
					F13 = indataVendor.VendorName ?? " - ",
					F14 = " - ",//เลขที่
					F15 = " - ",//ถนน
					F16 = " - ",//ตำบล
					F17 = " - ",//อำเภอ
					F18 = " - ",//จังหวัด

					F19 = lookUp.UserSmctSigner
					.FirstOrDefault(x => x.IdUserSmct == indataVendor.SmctMasterSigner.SmctMasterSignerDetail1.VendorSignerUser)
					?.UserFullname ?? " - ",
					F22 = " - ",//ตามคำสั่งที่
					F23 = " - ",//ลงวันที่
					F24 = " - ",//เดือน
					F25 = " - ",//ปี พ.ศ.

					F40 = conDetail.A1 ?? " - ",
					//วันที่เริ่ม
					F41 = !String.IsNullOrEmpty(indataCon.StartDateStr) ? int.Parse(indataCon.StartDateStr.Substring(0, 2)).ToString() : ".....",//String.Empty,
					F42 = !String.IsNullOrEmpty(indataCon.StartDateStr) ? GeneralUtils.getThaiMonth(int.Parse(indataCon.StartDateStr.Substring(3, 2))) : "....................",//String.Empty,
					F43 = !String.IsNullOrEmpty(indataCon.StartDateStr) ? indataCon.StartDateStr.Substring(6, 4) : "..........",//String.Empty,

					//วันที่สิ้นสุด
					F44 = !String.IsNullOrEmpty(indataCon.EndDateStr) ? int.Parse(indataCon.EndDateStr.Substring(0, 2)).ToString() : ".....",//String.Empty,
					F45 = !String.IsNullOrEmpty(indataCon.EndDateStr) ? GeneralUtils.getThaiMonth(int.Parse(indataCon.EndDateStr.Substring(3, 2))) : "....................",//String.Empty,
					F46 = !String.IsNullOrEmpty(indataCon.EndDateStr) ? indataCon.EndDateStr.Substring(6, 4) : "..........",//String.Empty,

					F48 = conDetail.A3 ?? " - ",
					F49 = conDetail.A4 ?? " - ",
					F50 = conDetail.A5 ?? " - ",
					F51 = conDetail.A6 ?? " - ",
					F52 = conDetail.A7 ?? " - ",
					F53 = conDetail.A8 ?? " - ",
					F54 = conDetail.A9 ?? " - ",

					F55 = indataCon.Budget > 0 ? indataCon.Budget.ToString("#,##0.00") : " - ",
					F56 = GeneralUtils.ThaiBahtText(indataCon.Budget.ToString()),

					//ข้อมูลธนาคาร Verdor
					F57 = conDetail.A13 ?? " - ",
					F58 = conDetail.A14 ?? " - ",
					F59 = conDetail.A15 ?? " - ",
					F60 = conDetail.A16 ?? " - ",

					//ข้อ9 แจ้งให้ทราบภาย...วัน
					F61 = " - ",

					//FSignature
					FSignature02 = FSignature.FSignature02,
					FSignature04 = FSignature.FSignature04,
					FSignature01 = FSignature.FSignature01,
					FSignature03 = FSignature.FSignature03,
					FSignaturefootnote01 = FSignature.FSignature01,
					FSignaturefootnote02 = FSignature.FSignature02
				});

				byte[] outPdfBuffer = null;

				if (response.RESP_STATUS == "OK")
				{
					outPdfBuffer = System.Convert.FromBase64String(response.PDF_FILE);
					await _repo.ContractShareNhso.UpdateFMPDF(indata, fmtype, outPdfBuffer);
				}

				return Json(new ResultModelJson<FM_CONTRACT_TXX_Response>
				{
					Status = true,
					Result = response
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

		public async Task<IActionResult> FM_CONTRACT_T13(ParameterCondition indata, String fmtype = null)
		{
			try
			{
				indata.ContractTypeIdEn = SecurityRepo.Encrypt(indata.ContractTypeId);
				var data = await _repo.T13BuRepo.GetView(indata);
				var lookUp = data.CTVendor.GetLookUp;
				var indataVendor = data.InfoPartnersOfContract;
				var indataReqApp = data.InfoRequestForApproval;
				var indataCon = data.InfoContract;
				var indataNhso = data.InfoContractNhso;
				var indataReqStation = data.ApprovalReqStation;
				var indataSigner = data.InfoSignerPartnersOfContract;
				var conDetail = data.InfoConDetail.ContractDetail13;
				var infoSignature = data.InfoAttachFileSignature;

				var FSignature = _repo.GeneralRepo.GetFSignature(infoSignature, indata);

				string D1 = !String.IsNullOrEmpty(indataCon.ContractDateStr) ? int.Parse(indataCon.ContractDateStr.Substring(0, 2)).ToString() : ".....";//String.Empty,
				string D2 = !String.IsNullOrEmpty(indataCon.ContractDateStr) ? GeneralUtils.getThaiMonth(int.Parse(indataCon.ContractDateStr.Substring(3, 2))) : "....................";//String.Empty,
				string D3 = !String.IsNullOrEmpty(indataCon.ContractDateStr) ? indataCon.ContractDateStr.Substring(6, 4) : "..........";//String.Empty,

				string P1 = ""; //ประเภทผู้ดำเนินการ 1 = กรณีดำเนินการจากส่วนกลาง, 2 = กรณีดำเนินการกับเขต
				if (conDetail.P1 == "1")
				{
					P1 = " ที่ สปสช.ส่วนกลาง";
				}
				else
				{
					P1 = " ที่ สปสช.เขต";
				}

				string P13 = ""; //( ) เป็นกรณี เบิกจ่ายตาม กฏ ระเบียบ ข้อบังคับ ประกาศ ข้อบังคับ มติ คำสั่ง หลักเกณฑ์ หรือแนวทางปฏิบัติ ที่คณะกรรมการหรือสำนักงานกำหนด
				string P14 = ""; //(/) เป็นกรณี เบิกจ่ายตามแผนงาน/โครการ/แนวทาง รวมเป็นเงินทั้งสิ้น 734,400 บาท (เจ็ดแสนสามหมื่นสี่พันสี่ร้อยบาทถ้วน) 
				if (conDetail.P6 == "1")
				{
					P13 = "( / ) เป็นกรณี เบิกจ่ายตาม กฏ ระเบียบ ข้อบังคับ ประกาศ ข้อบังคับ มติ คำสั่ง หลักเกณฑ์ หรือแนวทางปฏิบัติ ที่คณะกรรมการหรือสำนักงานกำหนด";
					P14 = "(   ) เป็นกรณี เบิกจ่ายตามแผนงาน/โครการ/แนวทาง รวมเป็นเงินทั้งสิ้น - บาท ( - )";
				}
				else
				{
					P13 = "(   ) เป็นกรณี เบิกจ่ายตาม กฏ ระเบียบ ข้อบังคับ ประกาศ ข้อบังคับ มติ คำสั่ง หลักเกณฑ์ หรือแนวทางปฏิบัติ ที่คณะกรรมการหรือสำนักงานกำหนด";
					P14 = $"( / ) เป็นกรณี เบิกจ่ายตามแผนงาน/โครการ/แนวทาง รวมเป็นเงินทั้งสิ้น {indataCon.Budget.ToString("#,##0.00")} บาท ({GeneralUtils.ThaiBahtText(indataCon.Budget.ToString())})";
				}

				var response = await _repo.PDFAPIRepo.FM_CONTRACT_T13(new FM_CONTRACT_T13_Request()
				{
					ID = data.InfoContract.RefId ?? "....................",
					HEAD = data.ParameterCondition.ContractTypeFullName,
					F01 = data.InfoContract.ContractId != null ? data.InfoContract.ContractId : "....................",
					F02 = string.Format("วันที่...{0}...เดือน...{1}...พ.ศ...{2}...", D1, D2, D3),

					F03 = string.Format("ตามหนังสือ{0} ที่ {1}", indataNhso.NhsoAddress.Header ?? " - ", conDetail.P2 ?? " - "),
					F04 = string.Format("ลงวันที่ {0}", conDetail.P3 ?? " - "),
					F05 = string.Format("ได้รับแนวทาง{0}", conDetail.P4 ?? " - "),
					F06 = conDetail.P5 ?? " - ",

					F07 = indataVendor.VendorName ?? "FALSE",
					F08 = indataReqStation.ContractName ?? "FALSE",
					F09 = "FALSE",
					F10 = "FALSE",
					F11 = "FALSE",
					F12 = "FALSE",

					F13 = P13,
					F14 = P14,

					F75 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoSignerUser)?.SignerFullname ?? String.Empty,
					F76 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoSignerUser)?.SignerPosition ?? String.Empty,

					F21 = D1,
					F22 = D2,
					F23 = D3,

					//FSignature
					FSignature01 = FSignature.FSignature01,
				});

				byte[] outPdfBuffer = null;

				if (response.RESP_STATUS == "OK")
				{
					outPdfBuffer = System.Convert.FromBase64String(response.PDF_FILE);
					await _repo.ContractShareNhso.UpdateFMPDF(indata, fmtype, outPdfBuffer);
				}

				return Json(new ResultModelJson<FM_CONTRACT_TXX_Response>
				{
					Status = true,
					Result = response
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

		//เงื่อนไขการจ่ายเงิน(งวดเดียว100%)
		public async Task<IActionResult> FM_PAY_P1(ParameterCondition indata, String fmtype = null)
		{
			try
			{
				indata.ContractTypeIdEn = SecurityRepo.Encrypt(indata.ContractTypeId);

				TAllMasterVendorView data = new TAllMasterVendorView();
				if (indata.ContractTypeId == "10") data = await _repo.T10BuRepo.GetView(indata);
				if (indata.ContractTypeId == "11") data = await _repo.T11BuRepo.GetView(indata);
				if (indata.ContractTypeId == "12") data = await _repo.T12BuRepo.GetView(indata);
				if (indata.ContractTypeId == "13") data = await _repo.T13BuRepo.GetView(indata);
				if (indata.ContractTypeId == "14") data = await _repo.T14BuRepo.GetView(indata);

				var lookUp = data.CTVendor.GetLookUp;
				var indataCon = data.InfoContract;
				var indataConstation = data.ContractStation;
				var indataSigner = data.InfoSignerPartnersOfContract;
				var payment = data.InfoConditionPayment;
				//var infoSignature = data.InfoAttachFileSignature;

				//var FSignature = _repo.GeneralRepo.GetFSignature(infoSignature, indata);

				var response = await _repo.PDFAPIRepo.FM_PAY_P1(new FM_PAY_P1_Request()
				{
					REQUEST_ID = indata.IdSmctMaster.ToUpper(),
					ID = data.InfoContract.RefId ?? "....................",
					HEAD = data.ParameterCondition.ContractTypeFullName,
					C_ID = data.InfoContract.ContractId != null ? data.InfoContract.ContractId : "....................",
					F01 = DateTime.Now.Day.ToString(),
					F02 = GeneralUtils.getThaiMonth(DateTime.Now.Month),
					F03 = GeneralUtils.getThaiYear(DateTime.Now.Year),
					Deptcode = indataConstation.DepartmentName ?? " - ",
					F04 = indataConstation.VendorName ?? " - ",
					F05 = indataCon.ContractTypeFullName ?? " - ",
					F06 = indataCon.Budget > 0 ? indataCon.Budget.ToString("#,##0.00") : "0",
					F07 = GeneralUtils.ThaiBahtText(indataCon.Budget.ToString()),
					F08 = string.Join(" ,", indataCon.Budgetcodes.Select(x => x.Budgetcode)),
					F09 = indataCon.Budget > 0 ? indataCon.Budget.ToString("#,##0.00") : "0",
					F10 = GeneralUtils.ThaiBahtText(indataCon.Budget.ToString()),
					F11 = payment.ContractPeriodDetail1,
					F12 = payment.PeriodP1Detail,
					SHOWREPORT = "1",
					DATA = _repo.PDFAPIRepo.DataTable2Base64_FM_PAY_P1(payment),
					//Footer Sign
					F71 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoSignerUser)?.SignerFullname ?? String.Empty,
					F72 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorSignerUser)?.UserFullname ?? String.Empty,
					//FSignaturefootnote01 = FSignature.
					//FSignaturefootnote02 =
				});

				byte[] outPdfBuffer = null;

				if (response.RESP_STATUS == "OK")
				{
					outPdfBuffer = System.Convert.FromBase64String(response.PDF_FILE);
					await _repo.ContractShareNhso.UpdateFMPDF(indata, fmtype, outPdfBuffer);
				}

				return Json(new ResultModelJson<FM_CONTRACT_TXX_Response>
				{
					Status = true,
					Result = response
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

		//เงื่อนไขการจ่ายเงิน(งวดเดียวตัดจ่ายหลายครั้ง)
		public async Task<IActionResult> FM_PAY_P2(ParameterCondition indata, String fmtype = null)
		{
			try
			{
				indata.ContractTypeIdEn = SecurityRepo.Encrypt(indata.ContractTypeId);

				TAllMasterVendorView data = new TAllMasterVendorView();
				if (indata.ContractTypeId == "10") data = await _repo.T10BuRepo.GetView(indata);
				if (indata.ContractTypeId == "11") data = await _repo.T11BuRepo.GetView(indata);
				if (indata.ContractTypeId == "12") data = await _repo.T12BuRepo.GetView(indata);
				if (indata.ContractTypeId == "13") data = await _repo.T13BuRepo.GetView(indata);
				if (indata.ContractTypeId == "14") data = await _repo.T14BuRepo.GetView(indata);

				var lookUp = data.CTVendor.GetLookUp;
				var indataCon = data.InfoContract;
				var indataConstation = data.ContractStation;
				var payment = data.InfoConditionPayment;
				var indataSigner = data.InfoSignerPartnersOfContract;

				var response = await _repo.PDFAPIRepo.FM_PAY_P2(new FM_PAY_P2_Request()
				{
					REQUEST_ID = indata.IdSmctMaster.ToUpper(),
					ID = data.InfoContract.RefId ?? "....................",
					HEAD = data.ParameterCondition.ContractTypeFullName,
					C_ID = data.InfoContract.ContractId != null ? data.InfoContract.ContractId : "....................",
					F01 = DateTime.Now.Day.ToString(),
					F02 = GeneralUtils.getThaiMonth(DateTime.Now.Month),
					F03 = GeneralUtils.getThaiYear(DateTime.Now.Year),
					Deptcode = indataConstation.DepartmentName ?? " - ",
					F04 = indataConstation.VendorName ?? " - ",
					F05 = indataCon.ContractTypeFullName ?? " - ",
					F06 = indataCon.Budget > 0 ? indataCon.Budget.ToString("#,##0.00") : "0",
					F07 = GeneralUtils.ThaiBahtText(indataCon.Budget.ToString()),
					F08 = string.Join(" ,", indataCon.Budgetcodes.Select(x => x.Budgetcode)),
					F09 = indataCon.Budget > 0 ? indataCon.Budget.ToString("#,##0.00") : "0",
					F10 = GeneralUtils.ThaiBahtText(indataCon.Budget.ToString()),
					F11 = payment.ContractPeriodDetail1,
					//Footer Sign
					F71 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoSignerUser)?.SignerFullname ?? String.Empty,
					F72 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorSignerUser)?.UserFullname ?? String.Empty,
				});

				byte[] outPdfBuffer = null;

				if (response.RESP_STATUS == "OK")
				{
					outPdfBuffer = System.Convert.FromBase64String(response.PDF_FILE);
					await _repo.ContractShareNhso.UpdateFMPDF(indata, fmtype, outPdfBuffer);
				}

				return Json(new ResultModelJson<FM_CONTRACT_TXX_Response>
				{
					Status = true,
					Result = response
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

		//เงื่อนไขการจ่ายเงิน(ตัดจ่ายหลายงวด)
		public async Task<IActionResult> FM_PAY_P3(ParameterCondition indata, String fmtype = null)
		{
			try
			{
				indata.ContractTypeIdEn = SecurityRepo.Encrypt(indata.ContractTypeId);

				TAllMasterVendorView data = new TAllMasterVendorView();
				if (indata.ContractTypeId == "10") data = await _repo.T10BuRepo.GetView(indata);
				if (indata.ContractTypeId == "11") data = await _repo.T11BuRepo.GetView(indata);
				if (indata.ContractTypeId == "12") data = await _repo.T12BuRepo.GetView(indata);
				if (indata.ContractTypeId == "13") data = await _repo.T13BuRepo.GetView(indata);
				if (indata.ContractTypeId == "14") data = await _repo.T14BuRepo.GetView(indata);

				var lookUp = data.CTVendor.GetLookUp;
				var indataCon = data.InfoContract;
				var indataConstation = data.ContractStation;
				var indataSigner = data.InfoSignerPartnersOfContract;
				var payment = data.InfoConditionPayment;

				var response = await _repo.PDFAPIRepo.FM_PAY_P3(new FM_PAY_P3_Request()
				{
					REQUEST_ID = indata.IdSmctMaster.ToUpper(),
					ID = data.InfoContract.RefId ?? "....................",
					HEAD = data.ParameterCondition.ContractTypeFullName,
					C_ID = data.InfoContract.ContractId != null ? data.InfoContract.ContractId : "....................",
					F01 = DateTime.Now.Day.ToString(),
					F02 = GeneralUtils.getThaiMonth(DateTime.Now.Month),
					F03 = GeneralUtils.getThaiYear(DateTime.Now.Year),
					Deptcode = indataConstation.DepartmentName ?? " - ",
					F04 = indataConstation.VendorName ?? " - ",
					F05 = indataCon.ContractTypeFullName ?? " - ",
					F06 = indataCon.Budget > 0 ? indataCon.Budget.ToString("#,##0.00") : "0",
					F07 = GeneralUtils.ThaiBahtText(indataCon.Budget.ToString()),
					F08 = string.Join(" ,", indataCon.Budgetcodes.Select(x => x.Budgetcode)),
					F09 = payment.PeriodList.Count.ToString(),
					SHOWREPORT = "Y",
					SHOW1 = payment.PeriodList.Count >= 1 ? "TRUE" : "",
					SHOW2 = payment.PeriodList.Count >= 2 ? "TRUE" : "",
					SHOW3 = payment.PeriodList.Count >= 3 ? "TRUE" : "",
					SHOW4 = payment.PeriodList.Count >= 4 ? "TRUE" : "",
					SHOW5 = payment.PeriodList.Count >= 5 ? "TRUE" : "",
					SHOW6 = payment.PeriodList.Count >= 6 ? "TRUE" : "",
					SHOW7 = payment.PeriodList.Count >= 7 ? "TRUE" : "",
					SHOW8 = payment.PeriodList.Count >= 8 ? "TRUE" : "",
					SHOW9 = payment.PeriodList.Count >= 9 ? "TRUE" : "",
					SHOW10 = payment.PeriodList.Count >= 10 ? "TRUE" : "",
					SHOW11 = payment.PeriodList.Count >= 11 ? "TRUE" : "",
					SHOW12 = payment.PeriodList.Count >= 12 ? "TRUE" : "",
					S1 = payment.PeriodList.Count >= 1 ? $"งวดที่ 1{_repo.PDFAPIRepo.GetPeriodDetailToAPI(payment, 0)}" : "",
					S2 = payment.PeriodList.Count >= 2 ? $"งวดที่ 2{_repo.PDFAPIRepo.GetPeriodDetailToAPI(payment, 1)}" : "",
					S3 = payment.PeriodList.Count >= 3 ? $"งวดที่ 3{_repo.PDFAPIRepo.GetPeriodDetailToAPI(payment, 2)}" : "",
					S4 = payment.PeriodList.Count >= 4 ? $"งวดที่ 4{_repo.PDFAPIRepo.GetPeriodDetailToAPI(payment, 3)}" : "",
					S5 = payment.PeriodList.Count >= 5 ? $"งวดที่ 5{_repo.PDFAPIRepo.GetPeriodDetailToAPI(payment, 4)}" : "",
					S6 = payment.PeriodList.Count >= 6 ? $"งวดที่ 6{_repo.PDFAPIRepo.GetPeriodDetailToAPI(payment, 5)}" : "",
					S7 = payment.PeriodList.Count >= 7 ? $"งวดที่ 7{_repo.PDFAPIRepo.GetPeriodDetailToAPI(payment, 6)}" : "",
					S8 = payment.PeriodList.Count >= 8 ? $"งวดที่ 8{_repo.PDFAPIRepo.GetPeriodDetailToAPI(payment, 7)}" : "",
					S9 = payment.PeriodList.Count >= 9 ? $"งวดที่ 9{_repo.PDFAPIRepo.GetPeriodDetailToAPI(payment, 8)}" : "",
					S10 = payment.PeriodList.Count >= 10 ? $"งวดที่ 10{_repo.PDFAPIRepo.GetPeriodDetailToAPI(payment, 9)}" : "",
					S11 = payment.PeriodList.Count >= 11 ? $"งวดที่ 11{_repo.PDFAPIRepo.GetPeriodDetailToAPI(payment, 10)}" : "",
					S12 = payment.PeriodList.Count >= 12 ? $"งวดที่ 12{_repo.PDFAPIRepo.GetPeriodDetailToAPI(payment, 11)}" : "",
					DATA00 = payment.PeriodList.Count >= 1 ? _repo.PDFAPIRepo.DataTable2Base64_FM_PAY_P3(payment, 0) : "None",
					DATA01 = payment.PeriodList.Count >= 2 ? _repo.PDFAPIRepo.DataTable2Base64_FM_PAY_P3(payment, 1) : "None",
					DATA02 = payment.PeriodList.Count >= 3 ? _repo.PDFAPIRepo.DataTable2Base64_FM_PAY_P3(payment, 2) : "None",
					DATA03 = payment.PeriodList.Count >= 4 ? _repo.PDFAPIRepo.DataTable2Base64_FM_PAY_P3(payment, 3) : "None",
					DATA04 = payment.PeriodList.Count >= 5 ? _repo.PDFAPIRepo.DataTable2Base64_FM_PAY_P3(payment, 4) : "None",
					DATA05 = payment.PeriodList.Count >= 6 ? _repo.PDFAPIRepo.DataTable2Base64_FM_PAY_P3(payment, 5) : "None",
					DATA06 = payment.PeriodList.Count >= 7 ? _repo.PDFAPIRepo.DataTable2Base64_FM_PAY_P3(payment, 6) : "None",
					DATA07 = payment.PeriodList.Count >= 8 ? _repo.PDFAPIRepo.DataTable2Base64_FM_PAY_P3(payment, 7) : "None",
					DATA08 = payment.PeriodList.Count >= 9 ? _repo.PDFAPIRepo.DataTable2Base64_FM_PAY_P3(payment, 8) : "None",
					DATA09 = payment.PeriodList.Count >= 10 ? _repo.PDFAPIRepo.DataTable2Base64_FM_PAY_P3(payment, 9) : "None",
					DATA10 = payment.PeriodList.Count >= 11 ? _repo.PDFAPIRepo.DataTable2Base64_FM_PAY_P3(payment, 10) : "None",
					DATA11 = payment.PeriodList.Count >= 12 ? _repo.PDFAPIRepo.DataTable2Base64_FM_PAY_P3(payment, 11) : "None",
					//Footer Sign
					F71 = lookUp.NhsoSigner.FirstOrDefault(x => x.EmpId == indataSigner.NhsoSignerUser)?.SignerFullname ?? String.Empty,
					F72 = lookUp.UserSmctSigner.FirstOrDefault(x => x.IdUserSmct == indataSigner.VendorSignerUser)?.UserFullname ?? String.Empty,
				});

				byte[] outPdfBuffer = null;

				if (response.RESP_STATUS == "OK")
				{
					outPdfBuffer = System.Convert.FromBase64String(response.PDF_FILE);
					await _repo.ContractShareNhso.UpdateFMPDF(indata, fmtype, outPdfBuffer);
				}

				return Json(new ResultModelJson<FM_CONTRACT_TXX_Response>
				{
					Status = true,
					Result = response
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
