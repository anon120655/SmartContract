using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.DTO
{
    public class SmctMasterSignerDetail1DTO
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
        public string VendorSignerUser { get; set; } //ผู้มีอำนาจด้วยตัวเอง
        public string VendorSignerUser2 { get; set; } //ผู้รับมอบอำนาจ
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
    }
}
