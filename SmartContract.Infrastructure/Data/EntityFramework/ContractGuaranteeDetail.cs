using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class ContractGuaranteeDetail
    {
        public string IdContractGuaranteeDetail { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public string IdContractGuarantee { get; set; }
        public decimal Amount { get; set; }
        public string BankId { get; set; }
        public string CashierId { get; set; }
        public DateTime? CashierDate { get; set; }
        public string GuaranteeDocId { get; set; }
        public DateTime? GuaranteeDocDate { get; set; }
        public DateTime? GuaranteeDocStartDate { get; set; }
        public DateTime? GuaranteeDocEndDate { get; set; }
        public bool Used { get; set; }

        public virtual UserSmct CreateUserNavigation { get; set; }
        public virtual UserSmct EditUserNavigation { get; set; }
        public virtual ContractGuarantee IdContractGuaranteeNavigation { get; set; }
    }
}
