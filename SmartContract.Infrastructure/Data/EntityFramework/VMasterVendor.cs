using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class VMasterVendor
    {
        public string VendorId { get; set; }
        public string VendorName { get; set; }
        public string VendorType { get; set; }
        public string Hcode { get; set; }
        public string CompanyName { get; set; }
        public string RegisterAt { get; set; }
        public string ProvinceId { get; set; }
        public string Catm { get; set; }
        public string VillageNo { get; set; }
        public string Moo { get; set; }
        public string Building { get; set; }
        public string Soi { get; set; }
        public string Road { get; set; }
        public string PostCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string TaxId { get; set; }
        public string Sp7 { get; set; }
        public DateTime? Sp7Date { get; set; }
    }
}
