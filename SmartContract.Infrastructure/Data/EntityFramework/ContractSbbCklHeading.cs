using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class ContractSbbCklHeading
    {
        public ContractSbbCklHeading()
        {
            ContractSbbCklDetails = new HashSet<ContractSbbCklDetail>();
        }

        public string IdContractSbbCklHeading { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public bool Used { get; set; }
        public string IdContractType { get; set; }
        public string L1Item { get; set; }
        public string L2Item { get; set; }
        public string L3Item { get; set; }
        public string DetailItem { get; set; }
        public string FCb { get; set; }

        public virtual UserSmct CreateUserNavigation { get; set; }
        public virtual UserSmct EditUserNavigation { get; set; }
        public virtual ContractType IdContractTypeNavigation { get; set; }
        public virtual ICollection<ContractSbbCklDetail> ContractSbbCklDetails { get; set; }
    }
}
