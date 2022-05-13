using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.Share
{
    public class ApproveGenConModel
    {
        public bool Approve { get; set; }
        public bool UnApproveVendor { get; set; }
        public bool UnApproveNhso { get; set; }
        public string Remark { get; set; }
    }
}
