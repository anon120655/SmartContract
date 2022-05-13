using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class ContractPeriod
    {
        public string IdContractPeriod { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public string IdContract { get; set; }
        public string PeriodType { get; set; }
        public int PeriodNo { get; set; }
        public string PeriodBudgetcode { get; set; }
        public string PeriodVendorId { get; set; }
        public DateTime? PeriodStartDate { get; set; }
        public DateTime? PeriodEndDate { get; set; }
        public DateTime? PeriodDueDate { get; set; }
        public decimal? PeriodPercent { get; set; }
        public string PeriodP1Detail { get; set; }
        public bool Used { get; set; }

        public virtual UserSmct CreateUserNavigation { get; set; }
        public virtual UserSmct EditUserNavigation { get; set; }
        public virtual Contract IdContractNavigation { get; set; }
    }
}
