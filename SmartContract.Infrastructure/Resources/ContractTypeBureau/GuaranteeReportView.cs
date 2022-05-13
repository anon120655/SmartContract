using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.ContractTypeBureau
{
    public class GuaranteeReportView
    {
        public string Dcode { get; set; }
        public string DnameNew { get; set; }
        public int NewCount { get; set; }
        public int ReNewCount { get; set; }
        public int ReturnCount { get; set; }
        public int ClaimCount { get; set; }

        public int SumByKetCount()
        {
            return NewCount + ReNewCount + ReturnCount + ClaimCount;
        }

    }
}
