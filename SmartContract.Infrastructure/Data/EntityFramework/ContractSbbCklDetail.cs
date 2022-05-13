using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class ContractSbbCklDetail
    {
        public string IdContractSbbCklDetail { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public bool Used { get; set; }
        public string IdContractSbbCkl { get; set; }
        public string IdContractSbbCklHeading { get; set; }
        public bool C1 { get; set; }
        public bool C2 { get; set; }
        public bool C3 { get; set; }
        public string CDetail { get; set; }

        public virtual UserSmct CreateUserNavigation { get; set; }
        public virtual UserSmct EditUserNavigation { get; set; }
        public virtual ContractSbbCklHeading IdContractSbbCklHeadingNavigation { get; set; }
        public virtual ContractSbbCkl IdContractSbbCklNavigation { get; set; }
    }
}
