using SmartContract.Infrastructure.Resources.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.DTO
{
    public class VMasterVendorDTO
    {
        public VMasterVendorDTO()
        {
            CATMs = new CATMModel();
        }

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
        public string Sp7Date { get; set; }
        public CATMModel CATMs { get; set; }
        public bool CheckRegister { get; set; } = false;
    }
}
