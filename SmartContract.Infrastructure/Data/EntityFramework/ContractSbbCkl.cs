using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class ContractSbbCkl
    {
        public ContractSbbCkl()
        {
            ContractSbbCklDetails = new HashSet<ContractSbbCklDetail>();
        }

        public string IdContractSbbCkl { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public bool Used { get; set; }
        public string IdContract { get; set; }
        public string ChecklistId { get; set; }
        public DateTime ChecklistDate { get; set; }
        public string ChecklistUser { get; set; }
        public string Remark { get; set; }
        public string Status { get; set; }

        public virtual UserSmct ChecklistUserNavigation { get; set; }
        public virtual UserSmct CreateUserNavigation { get; set; }
        public virtual UserSmct EditUserNavigation { get; set; }
        public virtual Contract IdContractNavigation { get; set; }
        public virtual ICollection<ContractSbbCklDetail> ContractSbbCklDetails { get; set; }
    }
}
