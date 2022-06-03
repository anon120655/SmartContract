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

    public class GuaranteeLgReqStationRpt
    {
        public string Dcode { get; set; }
        public string DnameNew { get; set; }
        public int NewCount { get; set; }
        public int ReNewCount { get; set; }
        public int ReturnCount { get; set; }
        public int ClaimCount { get; set; }
        public int DisCount { get; set; }

        public int SumByKetCount()
        {
            return NewCount + ReNewCount + ReturnCount + ClaimCount + DisCount;
        }

    }
    public class GuaranteeLgReqStationDashboard
    {
        public string Dcode { get; set; }
        public string DnameNew { get; set; }
        public int NewCount1 { get; set; }
        public int NewCount2 { get; set; }
        public int NewCount3 { get; set; }
        public int NewCount4 { get; set; }
        public int ReNewCount1 { get; set; }
        public int ReNewCount2 { get; set; }
        public int ReNewCount3 { get; set; }
        public int ReNewCount4 { get; set; }
        public int ReturnCount1 { get; set; }
        public int ReturnCount2 { get; set; }
        public int ReturnCount3 { get; set; }
        public int ReturnCount4 { get; set; }
        public int ClaimCount1 { get; set; }
        public int ClaimCount2 { get; set; }
        public int ClaimCount3 { get; set; }
        public int ClaimCount4 { get; set; }
        public int DisCount1 { get; set; }
        public int DisCount2 { get; set; }
        public int DisCount3 { get; set; }
        public int DisCount4 { get; set; }
        public int SumByKetCount()
        {
            return NewCount1 + NewCount2 + NewCount3 + NewCount4 + 
                ReNewCount1 + ReNewCount2 + ReNewCount3 + ReNewCount4 + 
                ReturnCount1 + ReturnCount2 + ReturnCount3 + ReturnCount4 + 
                ClaimCount1 + ClaimCount2 + ClaimCount3 + ClaimCount4 + 
                DisCount1 + DisCount2 + DisCount3 + DisCount4;
        }

    }
}
