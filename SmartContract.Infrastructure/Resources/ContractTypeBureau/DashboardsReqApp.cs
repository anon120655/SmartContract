using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.ContractTypeBureau
{
    public class DashboardsReqApp
    {
        public int S1CreateProposalCount { get; set; }
        public int S2CreateApproveCount { get; set; }
        public int S3ConsiderCount { get; set; }
        public int S4ApproveCount { get; set; }
        public int S5CancelCount { get; set; }

        public int SumCount()
        {
            return S1CreateProposalCount + S2CreateApproveCount + S3ConsiderCount + S4ApproveCount + S5CancelCount;
        }

    }
}
