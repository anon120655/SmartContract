using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class VendorLinkReq
    {
        public VendorLinkReq()
        {
            VendorLinkReqApproves = new HashSet<VendorLinkReqApprove>();
            VendorLinkReqStations = new HashSet<VendorLinkReqStation>();
        }

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
        public DateTime? Sp7Date { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public string Moo { get; set; }
        public bool Used { get; set; }
        public string Version { get; set; }

        public virtual UserSmct CreateUserNavigation { get; set; }
        public virtual UserSmct EditUserNavigation { get; set; }
        public virtual SmctMaster IdSmctMasterNavigation { get; set; }
        public virtual ICollection<VendorLinkReqApprove> VendorLinkReqApproves { get; set; }
        public virtual ICollection<VendorLinkReqStation> VendorLinkReqStations { get; set; }
    }
}
