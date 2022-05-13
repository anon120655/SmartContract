using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.ContractTypeVendor
{
    public class Dashboards
    {
        public string Style { get; set; }
        public int AllCount { get; set; }
        public int DraftCount { get; set; }
        public int ReqAppCount { get; set; }
        public int ContractCount { get; set; }
        public int Sign2Count { get; set; }
        public int GenContractIdCount { get; set; }
        public int BindingCount { get; set; }
        public int CancelCount { get; set; }

        public int SumCount()
        {
            return DraftCount + ReqAppCount + ContractCount + Sign2Count + GenContractIdCount + BindingCount + CancelCount;
        }

    }
}
