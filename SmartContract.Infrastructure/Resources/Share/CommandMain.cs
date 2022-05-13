using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.Share
{
    public class CommandMain
    {
        public string StringSql { get; set; }
        public int rowsUpdated { get; set; }
        public string ResponseMessage { get; set; }
        public string ErrorMessage { get; set; }
		public string ConnectionString { get; set; }
	}
}
