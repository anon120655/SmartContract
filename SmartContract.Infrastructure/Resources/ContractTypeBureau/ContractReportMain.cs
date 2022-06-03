using SmartContract.Infrastructure.Resources.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.ContractTypeBureau
{
    public class ContractReportMain : SearchOptionGuarantee
    {
        public ContractReportMain()
        {
            GetLookUp = new LookUpResource();
            ContractReportView = new List<ContractReportView>();
            ContractReport01 = new List<ContractReport01>();
        }

        public bool errorCheck { get; set; }
        public string errorMessage { get; set; }
        public LookUpResource GetLookUp { get; set; }
        public List<ContractReportView> ContractReportView { get; set; }
        public List<ContractReport01> ContractReport01 { get; set; }
    }
}
