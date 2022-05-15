using SmartContract.Infrastructure.Data.EntityFramework;
using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Guarantee;
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
        public SearchOptionLG Condition { get; set; }
       
        //Search
        public PaginationView<List<VGuaranteeLgContract>> VGuaranteeLgContract { get; set; }
        //Dashboard        
        public DashboardLG Dashboard { get; set; }
        //Tracking        
        public PaginationView<List<GuaranteeLgReqStationDTO>> TrackingStation { get; set; }

    }
}
