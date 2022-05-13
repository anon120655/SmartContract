using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Interfaces;
using SmartContract.Infrastructure.Interfaces.PDFAPI;
using SmartContract.Infrastructure.Resources.ContractTypeBureau.Information;
using SmartContract.Infrastructure.Resources.ContractTypeVendor.Information;
using SmartContract.Infrastructure.Resources.PDFAPI;
using SmartContract.Infrastructure.Wrapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Repositorys.PDFAPI
{
	public class PDFAPIRepo : IPDFAPIRepo
	{
		private IRepositoryWrapper _repo;
		private readonly IRepositoryBase _db;
		private readonly IMapper _mapper;
		private readonly IWebHostEnvironment _env;
		private readonly AppSettings _mySet;

		public PDFAPIRepo(IRepositoryWrapper repo, IRepositoryBase db, IMapper mapper, IWebHostEnvironment env, IOptions<AppSettings> settings)
		{
			_repo = repo;
			_db = db;
			_env = env;
			_mapper = mapper;
			_mySet = settings.Value;
		}

		public async Task<FM_CONTRACT_TXX_Response> FM_APPROVAL_REQ(FM_APPROVAL_REQ_Request request)
		{
			string UrlFull = $"{_mySet.PdfService.UrlSMCT_API}/GET_FM_217_01_001";

			string jsonTxt = JsonConvert.SerializeObject(request);
			var response_api = await ServiceHttp.CallHttpPost(jsonTxt, UrlFull, null, null);
			var responseMap = JsonConvert.DeserializeObject<FM_CONTRACT_TXX_Response>(response_api);

			return responseMap;
		}

		public async Task<FM_CONTRACT_TXX_Response> FM_CONTRACT_T01(FM_CONTRACT_T01_Request request)
		{
			//string UrlFull = $"{_mySet.PdfService.UrlSMCT_API}/GET_FM_403_02_001";
			string UrlFull = $"{_mySet.PdfService.UrlSMCT_API}/GET_FM_7_71_2_001";

			string jsonTxt = JsonConvert.SerializeObject(request);
			var response_api = await ServiceHttp.CallHttpPost(jsonTxt, UrlFull, null, null);
			var responseMap = JsonConvert.DeserializeObject<FM_CONTRACT_TXX_Response>(response_api);

			return responseMap;
		}

		public async Task<FM_CONTRACT_TXX_Response> FM_CONTRACT_T02(FM_CONTRACT_T02_Request request)
		{

			//string UrlFull = $"{_mySet.PdfService.UrlSMCT_API}/GET_FM_403_02_003";
			string UrlFull = $"{_mySet.PdfService.UrlSMCT_API}/GET_FM_7_71_2_003";

			string jsonTxt = JsonConvert.SerializeObject(request);
			var response_api = await ServiceHttp.CallHttpPost(jsonTxt, UrlFull, null, null);
			var responseMap = JsonConvert.DeserializeObject<FM_CONTRACT_TXX_Response>(response_api);

			return responseMap;
		}

		public async Task<FM_CONTRACT_TXX_Response> FM_CONTRACT_T03(FM_CONTRACT_T03_Request request)
		{

			string UrlFull = $"{_mySet.PdfService.UrlSMCT_API}/GET_FM_403_02_002";

			string jsonTxt = JsonConvert.SerializeObject(request);
			var response_api = await ServiceHttp.CallHttpPost(jsonTxt, UrlFull, null, null);
			var responseMap = JsonConvert.DeserializeObject<FM_CONTRACT_TXX_Response>(response_api);

			return responseMap;
		}

		public async Task<FM_CONTRACT_TXX_Response> FM_CONTRACT_T04(FM_CONTRACT_T04_Request request)
		{

			string UrlFull = $"{_mySet.PdfService.UrlSMCT_API}/GET_FM_403_02_002";

			string jsonTxt = JsonConvert.SerializeObject(request);
			var response_api = await ServiceHttp.CallHttpPost(jsonTxt, UrlFull, null, null);
			var responseMap = JsonConvert.DeserializeObject<FM_CONTRACT_TXX_Response>(response_api);

			return responseMap;
		}

		public async Task<FM_CONTRACT_TXX_Response> FM_CONTRACT_T05(FM_CONTRACT_T05_Request request)
		{

			string UrlFull = $"{_mySet.PdfService.UrlSMCT_API}/GET_FM_403_02_012";

			string jsonTxt = JsonConvert.SerializeObject(request);
			var response_api = await ServiceHttp.CallHttpPost(jsonTxt, UrlFull, null, null);
			var responseMap = JsonConvert.DeserializeObject<FM_CONTRACT_TXX_Response>(response_api);

			return responseMap;
		}

		public async Task<FM_CONTRACT_TXX_Response> FM_CONTRACT_T06(FM_CONTRACT_T06_Request request)
		{

			string UrlFull = $"{_mySet.PdfService.UrlSMCT_API}/";

			string jsonTxt = JsonConvert.SerializeObject(request);
			var response_api = await ServiceHttp.CallHttpPost(jsonTxt, UrlFull, null, null);
			var responseMap = JsonConvert.DeserializeObject<FM_CONTRACT_TXX_Response>(response_api);

			return responseMap;
		}

		public async Task<FM_CONTRACT_TXX_Response> FM_CONTRACT_T07(FM_CONTRACT_T07_Request request)
		{

			string UrlFull = $"{_mySet.PdfService.UrlSMCT_API}/";

			string jsonTxt = JsonConvert.SerializeObject(request);
			var response_api = await ServiceHttp.CallHttpPost(jsonTxt, UrlFull, null, null);
			var responseMap = JsonConvert.DeserializeObject<FM_CONTRACT_TXX_Response>(response_api);

			return responseMap;
		}

		public async Task<FM_CONTRACT_TXX_Response> FM_CONTRACT_T08(FM_CONTRACT_T08_Request request)
		{

			string UrlFull = $"{_mySet.PdfService.UrlSMCT_API}/";

			string jsonTxt = JsonConvert.SerializeObject(request);
			var response_api = await ServiceHttp.CallHttpPost(jsonTxt, UrlFull, null, null);
			var responseMap = JsonConvert.DeserializeObject<FM_CONTRACT_TXX_Response>(response_api);

			return responseMap;
		}

		public async Task<FM_CONTRACT_TXX_Response> FM_CONTRACT_T09(FM_CONTRACT_T09_Request request)
		{

			string UrlFull = $"{_mySet.PdfService.UrlSMCT_API}/";

			string jsonTxt = JsonConvert.SerializeObject(request);
			var response_api = await ServiceHttp.CallHttpPost(jsonTxt, UrlFull, null, null);
			var responseMap = JsonConvert.DeserializeObject<FM_CONTRACT_TXX_Response>(response_api);

			return responseMap;
		}

		public async Task<FM_CONTRACT_TXX_Response> FM_CONTRACT_T10(FM_CONTRACT_T10_Request request)
		{

			string UrlFull = $"{_mySet.PdfService.UrlSMCT_API}/GET_FM_403_02_018";

			string jsonTxt = JsonConvert.SerializeObject(request);
			var response_api = await ServiceHttp.CallHttpPost(jsonTxt, UrlFull, null, null);
			var responseMap = JsonConvert.DeserializeObject<FM_CONTRACT_TXX_Response>(response_api);

			return responseMap;
		}

		public async Task<FM_CONTRACT_TXX_Response> FM_CONTRACT_T11(FM_CONTRACT_T11_Request request)
		{
			//string UrlFull = $"{_mySet.PdfService.UrlSMCT_API}/GET_FM_03_008";
			string UrlFull = $"{_mySet.PdfService.UrlSMCT_API}/GET_FM_7_71_0_008";

			string jsonTxt = JsonConvert.SerializeObject(request);
			var response_api = await ServiceHttp.CallHttpPost(jsonTxt, UrlFull, null, null);
			var responseMap = JsonConvert.DeserializeObject<FM_CONTRACT_TXX_Response>(response_api);

			return responseMap;
		}

		public async Task<FM_CONTRACT_TXX_Response> FM_CONTRACT_T12(FM_CONTRACT_T12_Request request)
		{
			//string UrlFull = $"{_mySet.PdfService.UrlSMCT_API}/GET_FM_03_009";
			string UrlFull = $"{_mySet.PdfService.UrlSMCT_API}/GET_FM_7_71_00_001";

			string jsonTxt = JsonConvert.SerializeObject(request);
			var response_api = await ServiceHttp.CallHttpPost(jsonTxt, UrlFull, null, null);
			var responseMap = JsonConvert.DeserializeObject<FM_CONTRACT_TXX_Response>(response_api);

			return responseMap;
		}

		public async Task<FM_CONTRACT_TXX_Response> FM_CONTRACT_T13(FM_CONTRACT_T13_Request request)
		{
			string UrlFull = $"{_mySet.PdfService.UrlSMCT_API}/GET_FM_403_02_006";

			string jsonTxt = JsonConvert.SerializeObject(request);
			var response_api = await ServiceHttp.CallHttpPost(jsonTxt, UrlFull, null, null);
			var responseMap = JsonConvert.DeserializeObject<FM_CONTRACT_TXX_Response>(response_api);

			return responseMap;
		}

		public async Task<FM_CONTRACT_TXX_Response> FM_PAY_P1(FM_PAY_P1_Request request)
		{
			string UrlFull = $"{_mySet.PdfService.UrlSMCT_API}/GET_FM_17_021_1";

			string jsonTxt = JsonConvert.SerializeObject(request);
			var response_api = await ServiceHttp.CallHttpPost(jsonTxt, UrlFull, null, null);
			var responseMap = JsonConvert.DeserializeObject<FM_CONTRACT_TXX_Response>(response_api);

			return responseMap;
		}

		public async Task<FM_CONTRACT_TXX_Response> FM_PAY_P2(FM_PAY_P2_Request request)
		{
			string UrlFull = $"{_mySet.PdfService.UrlSMCT_API}/GET_FM_17_021_2";

			string jsonTxt = JsonConvert.SerializeObject(request);
			var response_api = await ServiceHttp.CallHttpPost(jsonTxt, UrlFull, null, null);
			var responseMap = JsonConvert.DeserializeObject<FM_CONTRACT_TXX_Response>(response_api);

			return responseMap;
		}

		public async Task<FM_CONTRACT_TXX_Response> FM_PAY_P3(FM_PAY_P3_Request request)
		{
			string UrlFull = $"{_mySet.PdfService.UrlSMCT_API}/GET_FM_17_021_3";

			string jsonTxt = JsonConvert.SerializeObject(request);
			var response_api = await ServiceHttp.CallHttpPost(jsonTxt, UrlFull, null, null);
			var responseMap = JsonConvert.DeserializeObject<FM_CONTRACT_TXX_Response>(response_api);

			return responseMap;
		}

		public string DataTable2Base64_FM_PAY_P1(InfoConditionPayment InfoConditionPayment)
		{
			byte[] ObjectToByteArray;
			DataTable Dt = null;
			BinaryFormatter bf = new BinaryFormatter();
			MemoryStream ms = new MemoryStream();
			Dt = new DataTable();
			Dt.Columns.Add("ORDERNUMBER2", typeof(int));
			Dt.Columns.Add("CONTRACTORCODE2", typeof(string));
			Dt.Columns.Add("CONTRACT_ID2", typeof(string));
			Dt.Columns.Add("CONTRACT_ORDER2", typeof(int));
			Dt.Columns.Add("BUDGETCODE2", typeof(string));
			Dt.Columns.Add("PROJNO2", typeof(string));
			Dt.Columns.Add("PAY2", typeof(double));
			DataRow anyRow = null/* TODO Change to default(_) if this is not a reference type */;

			if (InfoConditionPayment.P1Budgetcode != null && InfoConditionPayment.P1Budgetcode.Count > 0)
			{
				foreach (var item in InfoConditionPayment.P1Budgetcode.Select((value, i) => (value, i)))
				{
					anyRow = Dt.NewRow();
					anyRow[0] = item.i + 1;
					anyRow[1] = item.value.PeriodVendorId;
					anyRow[2] = item.value.PeriodVendorName;
					anyRow[3] = 0;
					anyRow[4] = item.value.PeriodBudgetcode;
					anyRow[5] = "PROJNO2";
					anyRow[6] = item.value.PeriodPercent.HasValue ? item.value.PeriodPercent.Value : 0;
					Dt.Rows.Add(anyRow);
				}
			}

			//anyRow = Dt.NewRow();
			//anyRow[0] = 1;
			//anyRow[1] = "CONTRACTORCODE2";
			//anyRow[2] = "CONTRACT_ID2";
			//anyRow[3] = "CONTRACT_ORDER2";
			//anyRow[4] = "BUDGETCODE2";
			//anyRow[5] = "PROJNO2";
			//anyRow[6] = 123;
			//Dt.Rows.Add(anyRow);

			bf.Serialize(ms, Dt);
			ObjectToByteArray = ms.ToArray();
			var Result = Convert.ToBase64String(ObjectToByteArray);
			return Result;
		}

		public string DataTable2Base64_FM_PAY_P3(InfoConditionPayment InfoConditionPayment, int PeriodNo)
		{
			byte[] ObjectToByteArray;
			DataTable Dt = null;
			BinaryFormatter bf = new BinaryFormatter();
			MemoryStream ms = new MemoryStream();
			Dt = new DataTable();
			Dt.Columns.Add("Order_no", typeof(int));
			Dt.Columns.Add("Vendor_id", typeof(string));
			Dt.Columns.Add("Vendor_name", typeof(string));
			Dt.Columns.Add("Budgetcode", typeof(string));
			Dt.Columns.Add("Order_budget", typeof(double));
			DataRow anyRow = null/* TODO Change to default(_) if this is not a reference type */;

			if (InfoConditionPayment.PeriodList != null && InfoConditionPayment.PeriodList.Count > 0)
			{
				foreach (var item in InfoConditionPayment.PeriodList[PeriodNo].ContractPeriod.Select((value, i) => (value, i)))
				{
					anyRow = Dt.NewRow();
					anyRow[0] = item.i + 1;
					anyRow[1] = item.value.PeriodVendorId;
					anyRow[2] = item.value.PeriodVendorName;
					anyRow[3] = item.value.PeriodBudgetcode;
					anyRow[4] = item.value.PeriodPercent.HasValue ? item.value.PeriodPercent.Value : 0;
					Dt.Rows.Add(anyRow);
				}
			}

			bf.Serialize(ms, Dt);
			ObjectToByteArray = ms.ToArray();
			var Result = Convert.ToBase64String(ObjectToByteArray);
			return Result;
		}

		public string GetPeriodDetailToAPI(InfoConditionPayment payment, int index)
		{
			String SDetail = String.Empty;
			int No = 1;
			foreach (var item in payment.PeriodList[index].ContractPeriodDetail)
			{
				SDetail += $"\" + ChrW(10) + \"{No++}. {item.ContractPeriodDetail1}";
			}
			return SDetail;
		}

		public string DataTable2Base64_APPROVAL_REQ(InfoContract InfoContract)
		{

			byte[] ObjectToByteArray;
			DataTable Dt = null;
			BinaryFormatter bf = new BinaryFormatter();
			MemoryStream ms = new MemoryStream();
			Dt = new DataTable();
			Dt.Columns.Add("ORDERNUMBER", typeof(decimal));
			Dt.Columns.Add("BUDGETCODE", typeof(string));
			DataRow anyRow = null/* TODO Change to default(_) if this is not a reference type */;

			if (InfoContract.Budgetcodes != null && InfoContract.Budgetcodes.Count > 0)
			{
				foreach (var item in InfoContract.Budgetcodes.Select((value, i) => (value, i)))
				{
					anyRow = Dt.NewRow();
					anyRow[0] = item.value?.Remain ?? 0;
					anyRow[1] = item.value.Budgetcode;
					Dt.Rows.Add(anyRow);
				}
			}

			bf.Serialize(ms, Dt);
			ObjectToByteArray = ms.ToArray();
			var Result = Convert.ToBase64String(ObjectToByteArray);
			return Result;
		}


	}
}
