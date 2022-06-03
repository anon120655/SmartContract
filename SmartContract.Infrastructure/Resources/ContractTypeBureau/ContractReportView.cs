using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.ContractTypeBureau
{
    public class ContractReportView
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

    public class ContractReport01
    {
        public string Dcode { get; set; }
        public string DnameNew { get; set; }
        public int GroupType1Count { get; set; }
        public int GroupType2Count { get; set; }
        public int GroupType3Count { get; set; }
        public int GroupType4Count { get; set; }

        public int SumByKetCount()
        {
            return GroupType1Count + GroupType2Count + GroupType3Count + GroupType4Count;
        }

    }
}
