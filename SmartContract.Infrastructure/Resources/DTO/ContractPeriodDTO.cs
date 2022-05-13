using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.DTO
{
    public class ContractPeriodDTO
    {
        public ContractPeriodDTO()
        {
        }

        public string IdContractPeriod { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public string IdContract { get; set; }
        public string PeriodType { get; set; }
        public byte PeriodNo { get; set; }
        public string PeriodBudgetcode { get; set; }
        public string PeriodVendorId { get; set; }
        public string PeriodVendorName { get; set; }
        public DateTime? PeriodStartDate { get; set; }
        public DateTime? PeriodEndDate { get; set; }
        public DateTime? PeriodDueDate { get; set; }
        public decimal? PeriodPercent { get; set; }
        public string PeriodP1Detail { get; set; }
        public bool Used { get; set; }

    }
}
