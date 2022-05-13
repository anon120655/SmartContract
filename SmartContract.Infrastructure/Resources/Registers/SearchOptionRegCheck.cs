using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.Registers
{
    public class SearchOptionRegCheck
    {
        public string Style { get; set; }
        public string Sector { get; set; }
        public string VendorId { get; set; }
        public string Status { get; set; }
        /// <summary>
        /// P=Profile
        /// </summary>
        public string Type { get; set; }
    }
}
