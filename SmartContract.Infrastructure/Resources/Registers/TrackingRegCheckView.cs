using SmartContract.Infrastructure.Resources.Share;
using System;

namespace SmartContract.Infrastructure.Resources.Registers
{
    public class TrackingRegCheckView
    {
        public string IdRegisterNhso { get; set; }
        public string IdUserSmct { get; set; }
        public string RegisterNo { get; set; }
        public string RegisterType { get; set; }
        public string VendorId { get; set; }
        public string VendorName { get; set; }
        //VendorType รัฐ=H1+ O1 , เอกชน= H2+O2
        public string VendorType { get; set; }
        public string ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public string Catm { get; set; }
        public CATMModel CATMs { get; set; }
        public string VillageNo { get; set; }
        public string Building { get; set; }
        public string TaxId { get; set; }
        public string Soi { get; set; }
        public string Moo { get; set; }
        public string Road { get; set; }
        public string PostCode { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }
        public string Username { get; set; }
        public string UserFullname { get; set; }
        public string PositionName { get; set; }
        public string CreateUser { get; set; }
        public string UserFullnameCreate { get; set; }
        public string Status { get; set; }
        public string SignerType { get; set; }
    }
}
