using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.DTO
{
    public class ContractSbbCklMain
    {
        public ContractSbbCklMain()
        {
            //ContractSbbCklHeading = new List<ContractSbbCklHeadingDTO>();
            ContractSbbCkl = new ContractSbbCklDTO();
            ContractSbbCklHistory = new List<ContractSbbCklDTO>();
        }

        //public List<ContractSbbCklHeadingDTO> ContractSbbCklHeading { get; set; }
        public ContractSbbCklDTO ContractSbbCkl { get; set; }
        public List<ContractSbbCklDTO> ContractSbbCklHistory { get; set; }
    }
}
