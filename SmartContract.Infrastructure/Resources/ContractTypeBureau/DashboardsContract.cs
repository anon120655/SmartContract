using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.ContractTypeBureau
{
    public class DashboardsContract
    {
        public int S1DraftCount { get; set; }
        public int S2BookRequestApprovalCount { get; set; }
        public int S3SetVendorCount { get; set; }
        public int S4CreateContractCount { get; set; }
        public int S5Signing2Count { get; set; }
        public int S6ContractNumberCount { get; set; }
        public int S7BindingCount { get; set; }
        public int S8CancelCount { get; set; }

        public int SumCount()
        {
            return S1DraftCount
                + S2BookRequestApprovalCount
                + S3SetVendorCount
                + S4CreateContractCount
                + S5Signing2Count
                + S6ContractNumberCount
                + S7BindingCount
                + S8CancelCount;
        }
    }
    public class ContractStationSuccessDashboard
    {
        public string Dcode { get; set; }
        public string DnameNew { get; set; }
        public int EditCount1 { get; set; }
        public int EditCount2 { get; set; }
        public int EditCount3 { get; set; }
        public int EditCount4 { get; set; }
        public int CancelCount1 { get; set; }
        public int CancelCount2 { get; set; }
        public int CancelCount3 { get; set; }
        public int CancelCount4 { get; set; }
        public int ExpandCount1 { get; set; }
        public int ExpandCount2 { get; set; }
        public int ExpandCount3 { get; set; }
        public int ExpandCount4 { get; set; }
        public int CloseProjectCount1 { get; set; }
        public int CloseProjectCount2 { get; set; }
        public int CloseProjectCount3 { get; set; }
        public int CloseProjectCount4 { get; set; }
        public int TerminateCount1 { get; set; }
        public int TerminateCount2 { get; set; }
        public int TerminateCount3 { get; set; }
        public int TerminateCount4 { get; set; }
        public int SumByKetCount()
        {
            return EditCount1 + EditCount2 + EditCount3 + EditCount4 +
                CancelCount1 + CancelCount2 + CancelCount3 + CancelCount4 +
                ExpandCount1 + ExpandCount2 + ExpandCount3 + ExpandCount4 +
                CloseProjectCount1 + CloseProjectCount2 + CloseProjectCount3 + CloseProjectCount4 +
                TerminateCount1 + TerminateCount2 + TerminateCount3 + TerminateCount4;
        }

    }
}
