using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string SiteUpdate { get; set; } = $"1.1.18.20220519";
        public string ServerSite { get; set; }
        public string SubDomainServer { get; set; }
        public EmailSetting EmailSetting { get; set; }
        public CAGateway CAGateways { get; set; }
        public IAM IAMs { get; set; }
        public CheckCard CheckCards { get; set; }
        public DDOPA DDOPAs { get; set; }
        public FTP FTPs { get; set; }
        public PdfService PdfService { get; set; }
        public eLGKTB eLGKTBs { get; set; }
    }

    public class EmailSetting
    {
        public string SenderName { get; set; }
        public string Sender { get; set; }
        public string Password { get; set; }
        public string MailServer { get; set; }
        public int MailPort { get; set; }
        public bool IsSentMail { get; set; }
        public string DefualtMail { get; set; }
    }

    public class CAGateway
    {
        public string Certify { get; set; }
        public bool VisibleSignature { get; set; }
        public string WorkerName { get; set; }
        public string DomainCA { get; set; }
        public string UrlPDFSigningByCAD { get; set; }
    }

    public class IAM
    {
        public string DomainIAM { get; set; }
        public string domainName { get; set; }
        public string UrlAuthenAndUserInfo { get; set; }
    }
    public class CheckCard
    {
        public string DomainCard { get; set; }
        public bool IsEnable { get; set; }
    }

    public class DDOPA
    {
        public string DomainDDOPA { get; set; }
        public string response_type { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string ApiKey { get; set; }
		public string AuthorizationBasic { get; set; }
		public string redirect_uri { get; set; }
        public string state { get; set; }
        public string UrlAuth { get; set; }
        public string UrlToken { get; set; }
        public string UrlIntrospect { get; set; }
    }

    public class FTP
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class PdfService
    {
        public string UrlSMCT_API { get; set; }
    }

    public class eLGKTB
    {
        public string AuthorizationBasic { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string UrlToken { get; set; }
        public string UrlCreate { get; set; }
        public string UrlSearch { get; set; }
    }

}
