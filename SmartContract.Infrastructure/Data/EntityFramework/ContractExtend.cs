using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class ContractExtend
    {
        public string IdContractExtend { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public bool Used { get; set; }
        public string IdContract { get; set; }
        public string Status { get; set; }
        public int ExtendNo { get; set; }
        public DateTime ExtendStartDatePrev { get; set; }
        public DateTime ExtendEndDatePrev { get; set; }
        public DateTime? ExtendStartDateCurr { get; set; }
        public DateTime? ExtendEndDateCurr { get; set; }

        public virtual UserSmct CreateUserNavigation { get; set; }
        public virtual UserSmct EditUserNavigation { get; set; }
        public virtual Contract IdContractNavigation { get; set; }
    }
}
