using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class ContractPeriodDetail
    {
        public string IdContractPeriodDetail { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public string IdContract { get; set; }
        public byte ContractPeriodDetailNo { get; set; }
        public string ContractPeriodDetail1 { get; set; }
        public bool Used { get; set; }
        public int PeriodNo { get; set; }

        public virtual UserSmct CreateUserNavigation { get; set; }
        public virtual UserSmct EditUserNavigation { get; set; }
        public virtual Contract IdContractNavigation { get; set; }
    }
}
