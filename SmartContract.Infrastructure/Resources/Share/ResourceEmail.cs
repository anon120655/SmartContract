using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.Share
{
    public class ResourceEmail
    {
        public ResourceEmail()
        {
            Builder = new BodyBuilder();
        }

        public string SenderName { get; set; }
        public string Sender { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string MailServer { get; set; }
        public int MailPort { get; set; }
        public BodyBuilder Builder { get; set; }
        public List<string> CcList { get; set; }
        public string Template { get; set; }
        public bool IsCompleted { get; set; }
        public string StatusMessage { get; set; }
        public string PkId { get; set; }
        public string RefId { get; set; }

    }
}
