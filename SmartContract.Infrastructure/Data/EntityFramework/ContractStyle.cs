using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class ContractStyle
    {
        public ContractStyle()
        {
            ContractTypes = new HashSet<ContractType>();
        }

        public string IdContractStyle { get; set; }
        public string ContractStyleCode { get; set; }
        public string ContractStyleShortName { get; set; }
        public string ContractStyleFullName { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public bool Used { get; set; }

        public virtual UserSmct CreateUserNavigation { get; set; }
        public virtual UserSmct EditUserNavigation { get; set; }
        public virtual ICollection<ContractType> ContractTypes { get; set; }
    }
}
