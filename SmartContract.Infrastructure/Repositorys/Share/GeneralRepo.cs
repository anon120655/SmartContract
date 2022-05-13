using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Interfaces.Share;
using SmartContract.Infrastructure.Resources.ContractTypeBureau.Information;
using SmartContract.Infrastructure.Resources.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.Enum;
using SmartContract.Infrastructure.Resources.Other;
using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Infrastructure.Wrapper;
using SmartContract.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Repositorys.Share
{
	public class GeneralRepo : IGeneralRepo
	{

		private IRepositoryWrapper _repo;
		private readonly IWebHostEnvironment _env;
		private readonly AppSettings _mySet;

		public GeneralRepo(IRepositoryWrapper repo, IWebHostEnvironment env, IOptions<AppSettings> settings)
		{
			_repo = repo;
			_env = env;
			_mySet = settings.Value;
		}

		public TObjectState SetState(string state)
		{
			if (state == null)
				return TObjectState.Create;

			var _State = SecurityRepo.Decrypt(state);

			if (int.Parse(_State) == (int)TObjectState.View)
			{
				return TObjectState.View;
			}
			else if (int.Parse(_State) == (int)TObjectState.Create)
			{
				return TObjectState.Create;
			}
			else if (int.Parse(_State) == (int)TObjectState.Update)
			{
				return TObjectState.Update;
			}
			else if (int.Parse(_State) == (int)TObjectState.Delete)
			{
				return TObjectState.Delete;
			}
			else
			{
				return TObjectState.View;
			}
		}

		public string SetParameteragination(string Style, Pager pager)
		{
			String style = Style.ToUpperInvariant();
			if (ContractUtils.ConditionContractType().ContainsKey(style))
			{
				return _repo.CTVendorCondition.ParameterURL(pager);
			}

			return String.Empty;
		}

		public CATMModel GetCATM(string catm)
		{
			CATMModel CATMModel = new CATMModel();

			if (catm != null)
			{
				if (catm.Length >= 2)
				{
					CATMModel.ProvinceId = catm.Substring(0, 2) + "00";
					CATMModel.ProvinceName = _repo.Context.LkProvinces
														  .FirstOrDefault(x => x.ProvinceId == CATMModel.ProvinceId)?.ProvinceName
														  ?? String.Empty;
					CATMModel.ProvinceId = CATMModel.ProvinceId.Substring(0, 2);
				}
				if (catm.Length >= 4)
				{
					CATMModel.AmphurId = catm.Substring(2, 2);
					CATMModel.AmphurName = _repo.Context.LkAmphurs
														  .FirstOrDefault(x => x.ProvinceId == CATMModel.ProvinceId
														  && x.AmphurId == CATMModel.AmphurId)?.Name
														  ?? String.Empty;
				}
				if (catm.Length >= 6)
				{
					CATMModel.DistrictId = catm.Substring(4, 2);
					CATMModel.DistrictName = _repo.Context.LkDistricts
														  .FirstOrDefault(x => x.ProvinceId == CATMModel.ProvinceId
														  && x.AmphurId == CATMModel.AmphurId
														  && x.DistrictId == CATMModel.DistrictId)?.Name
														  ?? String.Empty;
				}
			}


			return CATMModel;
		}

		public CAModels GetAuthCAFix(string _PasswordCA)
		{
			CAModels response = new CAModels();

			if (_mySet.ServerSite == "UAT")
			{
				if (_PasswordCA == "9999")
				{
					response.UserNameCA = "pitima.b";
					response.PasswordCA = "Testiamws1";
				}
				if (_PasswordCA == "8888")
				{
					response.UserNameCA = "anuchit.c";
					response.PasswordCA = "Testiamws1";
				}
			}

			if (_mySet.ServerSite == "PRO")
			{
				if (_PasswordCA == "9999")
				{
					response.UserNameCA = "pitima.b";
					response.PasswordCA = "kMy93817";
				}
				if (_PasswordCA == "8888")
				{
					response.UserNameCA = "patay.k";
					response.PasswordCA = "Tayka@12";
				}
				if (_PasswordCA == "7777")
				{
					response.UserNameCA = "kanittha.k";
					response.PasswordCA = "Ying@1111";
				}
				if (_PasswordCA == "6666")
				{
					response.UserNameCA = "nuttawan.b";
					response.PasswordCA = "Nut@2520";
				}
			}

			return response;
		}

		public FSignatureModel GetFSignature(InfoAttachFileSignature model, ParameterCondition indata)
		{
			FSignatureModel response = new FSignatureModel();
			String pathFolder = String.Empty;
			if (model != null && model.SmctMasterFile != null && model.SmctMasterFile.Count > 0)
			{
				//F5=หน่วยริการ : ผู้มีอำนาจลงนาม SN11
				var file = model.SmctMasterFile.FirstOrDefault(x => x.FileType == "F5"); //
				if (file != null)
				{
					pathFolder = $"Signature/T{indata.ContractTypeId}/{file.PathFolder}";
					response.FSignature02 = _repo.GeneralRepo.GetBase64FTPImage(pathFolder, file.FileFtp);
				}
				//F4=หน่วยริการ : พยานลงนาม SN12
				file = model.SmctMasterFile.FirstOrDefault(x => x.FileType == "F4");
				if (file != null)
				{
					pathFolder = $"Signature/T{indata.ContractTypeId}/{file.PathFolder}";
					response.FSignature04 = _repo.GeneralRepo.GetBase64FTPImage(pathFolder, file.FileFtp);
				}
				//F7=สปสช : ผู้มีอำนาจลงนาม SN21
				file = model.SmctMasterFile.FirstOrDefault(x => x.FileType == "F7");
				if (file != null)
				{
					pathFolder = $"Signature/T{indata.ContractTypeId}/{file.PathFolder}";
					response.FSignature01 = _repo.GeneralRepo.GetBase64FTPImage(pathFolder, file.FileFtp);
				}
				//F6=สปสช : พยานลงนาม SN22
				file = model.SmctMasterFile.FirstOrDefault(x => x.FileType == "F6");
				if (file != null)
				{
					pathFolder = $"Signature/T{indata.ContractTypeId}/{file.PathFolder}";
					response.FSignature03 = _repo.GeneralRepo.GetBase64FTPImage(pathFolder, file.FileFtp);
				}
				//F13=หนังสือ
				file = model.SmctMasterFile.FirstOrDefault(x => x.FileType == "F13");
				if (file != null)
				{
					pathFolder = $"Signature/T{indata.ContractTypeId}/{file.PathFolder}";
					response.FSignature01APPREQ = _repo.GeneralRepo.GetBase64FTPImage(pathFolder, file.FileFtp);
				}
			}

			return response;
		}

		public string GetBase64FTPImage(string PathFolder, string FileFtp)
		{
			try
			{
				String PathFTP = @$"ftp://{_mySet.FTPs.UserName}@{_mySet.FTPs.Host}//ebudget//Smct//{PathFolder}//{FileFtp}";

				FtpWebRequest request = (FtpWebRequest)WebRequest.Create(PathFTP);
				request.Method = WebRequestMethods.Ftp.DownloadFile;
				request.Credentials = new NetworkCredential(_mySet.FTPs.UserName, _mySet.FTPs.Password);

				FtpWebResponse response = (FtpWebResponse)request.GetResponse();

				Stream responseStream = response.GetResponseStream();
				StreamReader reader = new StreamReader(responseStream);
				var strBase64 = this.ConvertToBase64(responseStream);
				return strBase64;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public string ConvertToBase64(Stream stream)
		{
			byte[] bytes;
			using (var memoryStream = new MemoryStream())
			{
				stream.CopyTo(memoryStream);
				bytes = memoryStream.ToArray();
			}

			string base64 = Convert.ToBase64String(bytes);
			return base64;
		}

	}
}
