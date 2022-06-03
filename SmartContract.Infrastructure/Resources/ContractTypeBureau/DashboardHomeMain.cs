using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.ContractTypeBureau
{
    public class DashboardHomeMain
    {
        public bool errorCheck { get; set; }
        public string errorMessage { get; set; }
        public PaginationView<List<ContractStationDTO>> ContractList { get; set; }
        public ContractTypeCount ContractTypeCount { get; set; }
        public List<ContractStationSuccessDashboard> ContractStationSuccessDashboard { get; set; }
        public List<GuaranteeLgReqStationDashboard> GuaranteeLgReqStation { get; set; }
        public List<GuaranteeLgReqStationRpt> GuaranteeLgReqStationDashboard { get; set; }
    }
}
