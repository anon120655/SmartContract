using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.Share.ServiceOther
{
	public class eLGCreateRequest
	{
        public string channelId { get; set; }
        public string beneficiaryRefNo { get; set; }
        public string transDate { get; set; }
        public string transTime { get; set; }
        public string appTypeId { get; set; }
        public string taxId { get; set; }
        public string requesterNameTh { get; set; }
        public string effectiveDateStart { get; set; }
        public string effectiveDateEnd { get; set; }
        public string lgNumber { get; set; }
        public double lgAmount { get; set; }
        public string guaranteeTypeId { get; set; }
        public string contractTypeId { get; set; }
        public string contractNo { get; set; }
        public string contractDate { get; set; }
        public string contractDetail { get; set; }
        public string comment { get; set; }
        public string email { get; set; }
        public string sms { get; set; }
    }
}
