using SmartContract.Infrastructure.Resources.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.Share;
using System;
using System.Collections.Generic;

namespace SmartContract.Infrastructure.Resources.Registers
{
    public class TrackingRegCheckMain
    {
        public bool errorCheck { get; set; }
        public string errorMessage { get; set; }
        public DashboardCheck Dashboard { get; set; }
        public PaginationView<List<TrackingRegCheckView>> TrackingResource { get; set; }
    }
}
