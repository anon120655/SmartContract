using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.DTO
{
   public class ContractSbbCklHeadingDTO
    {
        public string IdContractSbbCklHeading { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public bool Used { get; set; }
        public string IdContractType { get; set; }
        public string L1Item { get; set; }
        public string L2Item { get; set; }
        public string L3Item { get; set; }
        public string DetailItem { get; set; }
        public string FCb { get; set; }
        public List<ContractSbbCklDetailDTO> ContractSbbCklDetail { get; set; }
    }
}
