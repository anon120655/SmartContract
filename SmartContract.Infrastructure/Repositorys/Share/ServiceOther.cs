using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Interfaces;
using SmartContract.Infrastructure.Interfaces.Share;
using SmartContract.Infrastructure.Resources.Guarantee;
using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Infrastructure.Resources.Share.ServiceOther;
using SmartContract.Infrastructure.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Repositorys.Share
{
	public class ServiceOther : IServiceOther
	{
		private IRepositoryWrapper _repo;
		private readonly IRepositoryBase _db;
		private readonly IMapper _mapper;
		private readonly IWebHostEnvironment _env;
		private readonly AppSettings _mySet;

		public ServiceOther(IRepositoryWrapper repo, IRepositoryBase db, IMapper mapper, IWebHostEnvironment env, IOptions<AppSettings> settings)
		{
			_repo = repo;
			_db = db;
			_env = env;
			_mapper = mapper;
			_mySet = settings.Value;
		}

		public async Task<PDFSigningByCADResponse> PDFSigningByCAD(PDFSigningByCADRequest request)
		{
			string UrlFull = $"{_mySet.CAGateways.DomainCA}{_mySet.CAGateways.UrlPDFSigningByCAD}";

			string jsonTxt = JsonConvert.SerializeObject(request);
			var response_api = await ServiceHttp.CallHttpPost(jsonTxt, UrlFull, null, null);
			var responseMap = JsonConvert.DeserializeObject<PDFSigningByCADResponse>(response_api);

			return responseMap;
		}

		public async Task<DDOPAAuthResponse> DDOPAAuth(DDOPAAuthRequest request)
		{

			string UrlFull = $"{_mySet.DDOPAs.DomainDDOPA}{_mySet.DDOPAs.UrlAuth}";

			UrlFull = $"{UrlFull}&response_type={_mySet.DDOPAs.response_type}";
			UrlFull = $"{UrlFull}&client_id={_mySet.DDOPAs.client_id}";
			UrlFull = $"{UrlFull}&redirect_uri={_mySet.DDOPAs.redirect_uri}";
			UrlFull = $"{UrlFull}&state={_mySet.DDOPAs.state}";
			if (!String.IsNullOrEmpty(request.scope))
				UrlFull = $"{UrlFull}&scope={request.scope}";

			var response_api = await ServiceHttp.CallHttpGet(UrlFull, null);
			var responseMap = JsonConvert.DeserializeObject<DDOPAAuthResponse>(response_api);

			return responseMap;
		}

		public async Task<DDOPATokenResponse> DDOPAToken(DDOPATokenRequest request)
		{

			string UrlFull = $"{_mySet.DDOPAs.DomainDDOPA}/{_mySet.DDOPAs.UrlToken}";
			request.grant_type = "authorization_code";
			request.redirect_uri = _mySet.DDOPAs.redirect_uri;

			var parameter = new List<ParameterHttp>() {
				 new ParameterHttp(){ name = "grant_type", value = "authorization_code" },
				 new ParameterHttp(){ name = "code", value = request.code },
				 new ParameterHttp(){ name = "redirect_uri", value = _mySet.DDOPAs.redirect_uri }
			};

			string jsonTxt = JsonConvert.SerializeObject(request);
			var response_api = await ServiceHttp.CallHttpPost(null, UrlFull, _mySet.DDOPAs.AuthorizationBasic, null, parameter, "application/x-www-form-urlencoded", true);
			var responseMap = JsonConvert.DeserializeObject<DDOPATokenResponse>(response_api);

			return responseMap;
		}

		//KTB
		public async Task<eLGAuthenResponse> eLGAuthen()
		{
			string UrlFull = $"{_mySet.eLGKTBs.UrlToken}";

			List<ParameterHttp> parameterList = new List<ParameterHttp>();
			parameterList.Add(new ParameterHttp() { name = "grant_type", value = "password" });
			parameterList.Add(new ParameterHttp() { name = "username", value = "EH001" });
			parameterList.Add(new ParameterHttp() { name = "password", value = "Password1" });

			var response_api = await ServiceHttp.CallHttpPost(null, UrlFull, _mySet.eLGKTBs.AuthorizationBasic, null, parameterList, "application/x-www-form-urlencoded", true);
			var responseMap = JsonConvert.DeserializeObject<eLGAuthenResponse>(response_api);

			return responseMap;
		}

		public async Task<eLGCreateResponse> eLGCreate(eLGCreateRequest request)
		{
			string UrlFull = $"{_mySet.eLGKTBs.UrlCreate}";

			request.channelId = "NHSO";
			request.beneficiaryRefNo = DateTime.Now.ToString("yyMMddHHmmss"); //เลขอ้างอิงระบบต้นทาง (Beneficiary)(YYMMDDHH24mmssSSS) 211205201021	
			request.transDate = DateTime.Now.ToString("yyyyMMdd"); //Transaction Date (YYYY-MM-DD) 20211205
			request.transTime = DateTime.Now.ToString("HH:mm:ss"); //Transaction Time (HH24:mm:ss) 23:59:59
																   //

			//**** ประเภทใบคำขอ appTypeId ****
			//1 - ขอออก
			//2 - ขอขยาย,ขอขยาย + เพิ่มหรือลด,ขอเพิ่ม,ขอลด
			//3 - ขอคืน
			//4 - ขอเคลม
			//5 - ขอเพิ่ม
			//6 - ขอลด
			//request.appTypeId = "1";
			//request.taxId = "1234455666789"; //เลขประจำตัวผู้เสียภาษีของลูกค้า
			//request.requesterNameTh = "ชื่อลูกค้าที่เป็นเจ้าของงาน"; //ชื่อลูกค้าที่เป็นเจ้าของงาน

			if (request.effectiveDateStart == null) throw new Exception("ระบุวันที่เริ่มค้ำประกัน");
			if (request.effectiveDateEnd == null) throw new Exception("ระบุวันที่เริ่มค้ำประกัน");

			var _effectiveDateStart = Utils.GeneralUtils.DateToEn(request.effectiveDateStart, "dd/MM/yyyy");
			var _effectiveDateEnd = Utils.GeneralUtils.DateToEn(request.effectiveDateEnd, "dd/MM/yyyy");

			request.effectiveDateStart = _effectiveDateStart.Value.ToString("yyyy-MM-dd"); //วันที่เริ่มค้ำประกัน (YYYY-MM-DD) 2022-02-05
			request.effectiveDateEnd = _effectiveDateEnd.Value.ToString("yyyy-MM-dd"); //วันที่สิ้นสุดค้ำประกัน (YYYY-MM-DD) 2022-12-05

			//request.lgNumber = "00019/200008/0203/63"; //เลขที่หนังสือค้ำประกัน
			//request.lgAmount = 10.1; //มูลค่าค้ำประกัน


			//**** ประเภทหนังสือค้ำประกัน guaranteeTypeId ****
			//1 ยื่นซอง
			//2 การรับเงินล่วงหน้า
			//3 การปฎิบัติตามสัญญา
			//5 การใช้กระแสไฟฟ้า
			//6 ค่าภาษีอากร 19 ทวิ
			//7 การซื้อสินค้า
			//8 สาธารณูปโภคเพื่อการจัดสรรที่ดิน
			//9 การรับเงินประกันผลงาน
			//request.guaranteeTypeId = "1";

			//**** ประเภทสัญญา  contractTypeId *****
			// กรณีปฎิบัติตามสัญญา guaranteeTypeId = 3 เป็น Required
			//1 สัญญาจ้าง
			//2 สัญญาซื้อขาย
			//3 สัญญาจะซื้อจะขาย
			//4 สัญญาเช่า
			//5 ใบเสนอราคา
			//6 ใบสั่งซื้อ
			//7 Purchase Order
			//8 เอกสารยืนยันการว่าจ้าง
			//99 อื่นๆ โปรดระบุ
			//request.contractTypeId = "1";

			//request.contractNo = "contractNo"; //เลขที่สัญญา
			//request.contractDate = "2022-02-05"; //สัญญาลงวันที่ (YYYY-MM-DD)
			//request.contractDetail = "contractDetail"; //รายละเอียดงานตามสัญญา
			//request.comment = ""; //หมายเหตุ
			//request.email = ""; //email ของลูกค้าสำหรับส่ง email ใบเสร็จ
			//request.sms = ""; //เบอร์โทรศัพท์ของลูกค้าสำหรับส่ง sms

			var data = await _repo.ServiceOther.eLGAuthen();
			string jsonTxt = JsonConvert.SerializeObject(request);
			var response_api = await ServiceHttp.CallHttpPost(jsonTxt, UrlFull, data.access_token);
			var responseMap = JsonConvert.DeserializeObject<eLGCreateResponse>(response_api);
			return responseMap;
		}

		public async Task<eLGDocumentSearchResponse> eLGDocumentSearch(eLGDocumentSearchRequest request)
		{
			string UrlFull = $"{_mySet.eLGKTBs.UrlSearch}";
			UrlFull = $"{UrlFull}/?lgNumber={request.lgNumber}";

			var data = await _repo.ServiceOther.eLGAuthen();
			var response_api = await ServiceHttp.CallHttpGet(UrlFull, data.access_token);
			var responseMap = JsonConvert.DeserializeObject<eLGDocumentSearchResponse>(response_api);
			return responseMap;
		}

	}
}
