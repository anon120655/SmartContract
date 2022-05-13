using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.DTO
{
    public class SmctMasterSignerDTO
    {
        public SmctMasterSignerDTO()
        {
            SmctMasterSignerDetail1 = new SmctMasterSignerDetail1DTO();
        }

        public string IdSmctMasterSigner { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public bool Used { get; set; }
        public string IdSmctMaster { get; set; }
        public string ContractSignerType { get; set; }
        public SmctMasterSignerDetail1DTO SmctMasterSignerDetail1 { get; set; }
    }
}
