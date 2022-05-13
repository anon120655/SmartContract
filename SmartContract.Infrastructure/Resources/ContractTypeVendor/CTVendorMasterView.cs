using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.ContractTypeVendor
{

    public class CTVendorMasterView
    {
        public CTVendorMasterView()
        {
            GetLookUp = new LookUpResource();
            ConditionType = new ConditionType();
            ContractStationSuccess = new List<ContractStationSuccessDTO>();
        }

        public LookUpResource GetLookUp { get; set; }
        public ConditionType ConditionType { get; set; }
        public List<ContractStationSuccessDTO> ContractStationSuccess { get; set; }
        public string Style { get; set; }
        //P=Private(เอกชน) G=Government(รัฐ)
        public string Sector { get; set; }

    }
}
