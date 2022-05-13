using SmartContract.Infrastructure.Resources.ContractTypeBureau.Information;
using SmartContract.Infrastructure.Resources.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.Enum;
using SmartContract.Infrastructure.Resources.Other;
using SmartContract.Infrastructure.Resources.Share;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Interfaces.Share
{
	public interface IGeneralRepo
	{
		TObjectState SetState(string state);
		String SetParameteragination(String Style, Pager pager);
		CATMModel GetCATM(string catm);
		CAModels GetAuthCAFix(string _PasswordCA);
		FSignatureModel GetFSignature(InfoAttachFileSignature model, ParameterCondition indata);
		String GetBase64FTPImage(String PathFolder, String FileFtp);
		string ConvertToBase64(Stream stream);

	}
}
