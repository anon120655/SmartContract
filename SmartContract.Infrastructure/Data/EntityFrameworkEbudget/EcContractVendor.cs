using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFrameworkEbudget
{
    public partial class EcContractVendor
    {
        public int No { get; set; }
        public int ContractNo { get; set; }
        public string Type { get; set; }
        public string VendorId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUser { get; set; }
        public DateTime EditedDate { get; set; }
        public int EditedUser { get; set; }
        public string Used { get; set; }

        public virtual EcContract ContractNoNavigation { get; set; }
    }
}
