using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.Other
{
    public class SearchMain : OtherSearchOption
    {
        public SearchMain()
        {
            GetLookUp = new LookUpResource();
            SearchResource = new PaginationView<List<ContractStationDTO>>();
        }

        public bool errorCheck { get; set; }
        public string errorMessage { get; set; }
        public LookUpResource GetLookUp { get; set; }
        public PaginationView<List<ContractStationDTO>> SearchResource { get; set; }
    }
}
