using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.DTO
{
    public class SmctMasterSendmailDTO
    {
        public string IdSmctMasterSendmail { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public bool Used { get; set; }
        public string SendmailType { get; set; }
        public string SendmailFr { get; set; }
        public string SendmailTo { get; set; }
        public string SendmailCc { get; set; }
        public string SendmailSubject { get; set; }
        public string SendmailDetail { get; set; }
        public DateTime SendmailDate { get; set; }
        public string IdSmctMaster { get; set; }
    }
}
