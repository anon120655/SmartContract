using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class VDFiBankVendor
    {
        public string VendorId { get; set; }
        public string VendorName { get; set; }
        public string BanksCode { get; set; }
        public string BanksName { get; set; }
        public string BanksBranch { get; set; }
        public string BanksAccNo { get; set; }
        public string BanksAccName { get; set; }
    }
}
