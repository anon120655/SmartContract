
using SmartContract.Infrastructure.Resources.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.ContractTypeBureau.Information
{
    public class InfoAttachFileSignature
    {
        public InfoAttachFileSignature()
        {
            SmctMasterFile = new List<SmctMasterFileDTO>();
        }

        public List<SmctMasterFileDTO> SmctMasterFile { get; set; }


    }
}
