using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Infrastructure.Resources.Share.ServiceOther;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.Guarantee
{
	public class ELGCreateMain : CommonModel
	{
		public ELGCreateMain()
		{
			Request = new eLGCreateRequest();
		}

		public eLGCreateRequest Request { get; set; }
	}
}
