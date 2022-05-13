using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.Share.ServiceOther
{
    public class DDOPATokenRequest
    {
		public string grant_type { get; set; }
		public string code { get; set; }
		public string redirect_uri { get; set; }
	}
}
