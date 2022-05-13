using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.Share.ServiceOther
{
	public class eLGCreateResponse
	{
		public string beneficiaryRefNo { get; set; }
		public string issuerRefNo { get; set; }
		public string respCode { get; set; }
		public string respDesc { get; set; }
		public string error { get; set; }
		public string error_description { get; set; }
	}
}
