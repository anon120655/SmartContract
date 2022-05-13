using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.DTO
{
    public class VendorLinkReqDTO
    {
        public string IdVendorLinkReq { get; set; }
        public string IdSmctMaster { get; set; }
        public string ReqId { get; set; }
        public string Hcode { get; set; }
        public string VendorId { get; set; }
        public string VendorName { get; set; }
        public string RegisterAt { get; set; }
        public string CompanyName { get; set; }
        public string ProvinceId { get; set; }
        public string Catm { get; set; }
        public string VillageNo { get; set; }
        public string Building { get; set; }
        public string TaxId { get; set; }
        public string Soi { get; set; }
        public string Road { get; set; }
        public string PostCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Sp7 { get; set; }
        public DateTime Sp7Date { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public string Moo { get; set; }
        public bool Used { get; set; }
        public string Version { get; set; }
        public virtual ICollection<VendorLinkReqStationDTO> VendorLinkReqStations { get; set; }
    }
}
