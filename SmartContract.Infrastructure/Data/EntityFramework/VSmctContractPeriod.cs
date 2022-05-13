using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class VSmctContractPeriod
    {
        public string ContractId { get; set; }
        public string ContractTypeId { get; set; }
        public string ContractTypeShortName { get; set; }
        public string ContractTypeFullName { get; set; }
        public string ContractName { get; set; }
        public DateTime? ContractDate { get; set; }
        public string DepartmentCode { get; set; }
        public int PeriodNo { get; set; }
        public string PeriodBudgetcode { get; set; }
        public string PeriodVendorId { get; set; }
        public DateTime? PeriodStartDate { get; set; }
        public DateTime? PeriodEndDate { get; set; }
        public DateTime? PeriodDueDate { get; set; }
        public decimal? PeriodBudget { get; set; }
    }
}
