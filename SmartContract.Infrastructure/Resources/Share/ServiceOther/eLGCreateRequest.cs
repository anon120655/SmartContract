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
        public decimal lgAmount { get; set; }
        public string guaranteeTypeId { get; set; }
        public string contractTypeId { get; set; }
        public string contractNo { get; set; }
        public string contractDate { get; set; }
        public string contractDetail { get; set; }
        public string comment { get; set; }
        public string email { get; set; }
        public string sms { get; set; }

        
        public string guranteeTypeDesc { get; set; }
        public string contractTypeDesc { get; set; }
        public string hospitalCode { get; set; }
        public string hospitalName { get; set; }
        public decimal LgAmountInitial { get; set; }     
        
        public string LgStatusName { get; set; }

    }
}
