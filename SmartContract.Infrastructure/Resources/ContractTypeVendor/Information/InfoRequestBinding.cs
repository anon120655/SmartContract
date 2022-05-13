using SmartContract.Infrastructure.Resources.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.ContractTypeVendor.Information
{
    public class InfoRequestBinding
    {
        public InfoRequestBinding()
        {
            SmctMasterFile = new SmctMasterFileDTO();
        }

        public string ContractSuccessStatus { get; set; }
        public string ContractSuccessRemark { get; set; }
        public string ContractSuccessRemarkKet { get; set; }
        /// <summary>  
        /// เอกสารขอแก้ไข(ผูกพัน)
        /// </summary>     
        public SmctMasterFileDTO SmctMasterFile { get; set; }
    }
}
