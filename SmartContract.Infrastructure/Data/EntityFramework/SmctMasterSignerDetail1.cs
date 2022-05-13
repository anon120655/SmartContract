using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class SmctMasterSignerDetail1
    {
        public string IdSmctMasterSignerDetail1 { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public bool Used { get; set; }
        public string IdSmctMasterSigner { get; set; }
        public string NhsoSignerUser { get; set; }
        public string NhsoWitnessUser { get; set; }
        public string VendorSignerUser { get; set; }
        public string VendorWitnessUser { get; set; }
        public string NhsoFootnoteUser1 { get; set; }
        public string NhsoFootnoteUser2 { get; set; }
        public string NhsoFootnoteUser3 { get; set; }
        public string VendorFootnoteUser1 { get; set; }
        public string VendorFootnoteUser2 { get; set; }
        public string VendorFootnoteUser3 { get; set; }
        public string NhsoWitnessStatus { get; set; }
        public string VendorWitnessStatus { get; set; }
        public string NhsoContractId { get; set; }
        public DateTime? NhsoContractDate { get; set; }

        public virtual UserSmct CreateUserNavigation { get; set; }
        public virtual UserSmct EditUserNavigation { get; set; }
        public virtual SmctMasterSigner IdSmctMasterSignerNavigation { get; set; }
    }
}
