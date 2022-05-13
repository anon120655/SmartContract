using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.Share.ServiceOther
{
    public class DDOPAAuthRequest
    {
        public string redirect_uri { get; set; }
        public string scope { get; set; }
        public string state { get; set; }
    }
}
