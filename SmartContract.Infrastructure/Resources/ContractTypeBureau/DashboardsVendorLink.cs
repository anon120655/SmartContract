using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.ContractTypeBureau
{
    public class DashboardsVendorLink
    {
        public int S1CreateProposalCount { get; set; }
        public int S2CheckCount { get; set; }
        public int S3VendorSuccessCount { get; set; }
        public int S4CancelCount { get; set; }

        public int SumCount()
        {
            return S1CreateProposalCount + S2CheckCount + S3VendorSuccessCount + S4CancelCount;
        }
    }
}
