using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class ContractType
    {
        public ContractType()
        {
            ContractSbbCklHeadings = new HashSet<ContractSbbCklHeading>();
            Contracts = new HashSet<Contract>();
        }

        public string IdContractType { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public string ContractTypeId { get; set; }
        public string ContractTypeShortName { get; set; }
        public string ContractTypeFullName { get; set; }
        public string IdContractStyle { get; set; }
        public string Fm { get; set; }
        public string ContractTypeIdOld { get; set; }
        public bool Used { get; set; }
        public string GpType { get; set; }
        public bool FApprovalReq { get; set; }
        public bool FContract { get; set; }
        public bool FPay { get; set; }
        public string ContractTypeGroup { get; set; }

        public virtual UserSmct CreateUserNavigation { get; set; }
        public virtual UserSmct EditUserNavigation { get; set; }
        public virtual ContractStyle IdContractStyleNavigation { get; set; }
        public virtual ICollection<ContractSbbCklHeading> ContractSbbCklHeadings { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
