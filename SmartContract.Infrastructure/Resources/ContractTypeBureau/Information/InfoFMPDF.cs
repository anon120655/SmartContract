using SmartContract.Infrastructure.Resources.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.ContractTypeBureau.Information
{
    public class InfoFMPDF
    {
        public InfoFMPDF()
        {
            SmctMasterFile_APPROVAL = new SmctMasterFileDTO();
            SmctMasterFile_CONTRACT = new SmctMasterFileDTO();
            SmctMasterFile_PAY = new SmctMasterFileDTO();
        }
        public SmctMasterFileDTO SmctMasterFile_APPROVAL { get; set; }
        public SmctMasterFileDTO SmctMasterFile_CONTRACT { get; set; }
        public SmctMasterFileDTO SmctMasterFile_PAY { get; set; }
    }
}
