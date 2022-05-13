using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class ContractGuarantee
    {
        public ContractGuarantee()
        {
            ContractGuaranteeDetails = new HashSet<ContractGuaranteeDetail>();
        }

        public string IdContractGuarantee { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public string IdSmctMaster { get; set; }
        public string Type { get; set; }
        public string GuaranteeExceptDoc { get; set; }
        public string GuaranteeType { get; set; }
        public bool Used { get; set; }

        public virtual UserSmct CreateUserNavigation { get; set; }
        public virtual UserSmct EditUserNavigation { get; set; }
        public virtual SmctMaster IdSmctMasterNavigation { get; set; }
        public virtual ICollection<ContractGuaranteeDetail> ContractGuaranteeDetails { get; set; }
    }
}
