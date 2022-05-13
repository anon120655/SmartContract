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
        }

        public bool errorCheck { get; set; }
        public string errorMessage { get; set; }
        public LookUpResource GetLookUp { get; set; }
        public List<GuaranteeReportView> GuaranteeReportView { get; set; }
    }
}
