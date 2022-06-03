using SmartContract.Infrastructure.Resources.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.ContractTypeBureau
{
    public class GuaranteeReportMain : SearchOptionGuarantee
    {
        public GuaranteeReportMain()
        {
            GetLookUp = new LookUpResource();
            GuaranteeReportView = new List<GuaranteeReportView>();
            GuaranteeLgReqStationRpt = new List<GuaranteeLgReqStationRpt>();
            GuaranteeLgReqStationDashboard = new List<GuaranteeLgReqStationRpt>();
        }

        public bool errorCheck { get; set; }
        public string errorMessage { get; set; }
        public LookUpResource GetLookUp { get; set; }
        public List<GuaranteeReportView> GuaranteeReportView { get; set; }
        public List<GuaranteeLgReqStationRpt> GuaranteeLgReqStationRpt { get; set; }
        public List<GuaranteeLgReqStationRpt> GuaranteeLgReqStationDashboard { get; set; }
    }
}
