using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.Share
{
    public class ApproveModel
    {
        public bool Approve { get; set; }
        public bool UnApprove { get; set; }
        public bool UnApproveCheck { get; set; }
        public string Remark { get; set; }
        public string UserNameCA { get; set; }
        public string PasswordCA { get; set; }
    }
}
