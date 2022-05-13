using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.DTO
{
    public class ContractPeriodDetailDTO
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
        public byte PeriodNo { get; set; }
    }
}
