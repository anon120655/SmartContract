using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.ContractTypeBureau
{
    public class TrackingGuaranteeMain
    {
        public TrackingGuaranteeMain()
        {

        }

        public bool errorCheck { get; set; }
        public string errorMessage { get; set; }
        public LookUpResource GetLookUp { get; set; }
        public SearchOptionStation Condition { get; set; }
        //ออกใหม่
        public PaginationView<List<ContractStationGuaranteeDTO>> TrackingGuaranteeNew { get; set; }

    }
}
