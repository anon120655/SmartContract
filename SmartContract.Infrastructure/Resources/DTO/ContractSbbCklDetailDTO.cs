using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.DTO
{
    public class ContractSbbCklDetailDTO
    {
        public string IdContractSbbCklDetail { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public bool Used { get; set; }
        public string IdContractSbbCkl { get; set; }
        public string IdContractSbbCklHeading { get; set; }
        public string DetailItem { get; set; }
        public string FCb { get; set; }
        public bool C1 { get; set; }
        public bool C2 { get; set; }
        public bool C3 { get; set; }
        public string CDetail { get; set; }
    }
}
