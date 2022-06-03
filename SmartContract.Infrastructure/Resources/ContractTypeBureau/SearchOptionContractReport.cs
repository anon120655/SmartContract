using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.ContractTypeBureau
{
    public class SearchOptionContractReport
    {
        public string Year { get; set; }
        public string Month { get; set; }
        public string ContractStatus { get; set; }
        public string FundType { get; set; }
        public string VendorId { get; set; }
        public string Budgetcode { get; set; }
    }
}
