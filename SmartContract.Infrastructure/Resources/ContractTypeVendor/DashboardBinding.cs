using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.ContractTypeVendor
{
    public class DashboardBinding
    {
        public string SuccessType { get; set; }
        public int S1WaitApproveCount { get; set; }
        public int S2UnApproveCount { get; set; }
        public int S3ApproveCount { get; set; }
        public int S0CancelCount { get; set; }

        public int SumCount()
        {
            return S1WaitApproveCount + S2UnApproveCount + S3ApproveCount + S0CancelCount;
        }
    }
}
