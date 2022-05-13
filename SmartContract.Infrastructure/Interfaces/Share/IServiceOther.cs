using SmartContract.Infrastructure.Resources.Guarantee;
using SmartContract.Infrastructure.Resources.Share.ServiceOther;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Interfaces.Share
{
	public interface IServiceOther
	{
		Task<PDFSigningByCADResponse> PDFSigningByCAD(PDFSigningByCADRequest request);

		//DDOPA
		Task<DDOPAAuthResponse> DDOPAAuth(DDOPAAuthRequest request);
		Task<DDOPATokenResponse> DDOPAToken(DDOPATokenRequest request);

		//KTB
		Task<eLGAuthenResponse> eLGAuthen();
		Task<eLGCreateResponse> eLGCreate(eLGCreateRequest request);
		Task<eLGDocumentSearchResponse> eLGDocumentSearch(eLGDocumentSearchRequest request);
	}
}
