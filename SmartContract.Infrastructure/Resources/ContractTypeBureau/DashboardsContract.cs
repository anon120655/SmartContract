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
}
