using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Other;
using SmartContract.Infrastructure.Resources.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.ContractTypeVendor
{
    public class TrackingCTVendorMain
    {
        public bool errorCheck { get; set; }
        public string errorMessage { get; set; }
        public Dashboards Dashboards { get; set; }
        public DashboardMain DashboardMain { get; set; }
        public PaginationView<List<ContractStationDTO>> TrackingResource { get; set; }
    }
}
