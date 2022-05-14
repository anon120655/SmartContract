using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.Share.ServiceOther
{
    public class eLGDocumentSearchResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<Result> result { get; set; }

        public class Result
        {
            public string lastUpdateDate { get; set; }
            public string lastUpdateTime { get; set; }
            public string lgStatus { get; set; }
            public string hospitalCode { get; set; }
            public string hospitalName { get; set; }
            public string taxId { get; set; }
            public string requesterNameTh { get; set; }
            public string effectiveDateStart { get; set; }
            public string effectiveDateEnd { get; set; }
            public string lgNumber { get; set; }
            public decimal lgAmount { get; set; }
            public string guaranteeTypeId { get; set; }
            public string guranteeTypeDesc { get; set; }
            public string contractTypeId { get; set; }
            public string contractTypeDesc { get; set; }
            public string contractNo { get; set; }
            public object contractDate { get; set; }
            public string contractDetail { get; set; }
            public string comment { get; set; }
            public string accountNo { get; set; }
        }

    }
}
