using SmartContract.Infrastructure.Resources.Share;
using System;
using System.Collections.Generic;


namespace SmartContract.Infrastructure.Resources.DTO
{
    public class RegisterNhsoDTO : CommonModel
    {
        public string IdRegisterNhso { get; set; }
        public string RegisterNo { get; set; }
        public string RegisterType { get; set; }
        public string GPType { get; set; } //รัฐ/เอกชน 
        public string Hcode { get; set; }
        public string VendorId { get; set; }
        public string VendorName { get; set; }
        public string RegisterAt { get; set; }
        public string CompanyName { get; set; }
        //public string ProvinceIdLocation { get; set; }
        public string ProvinceNameLocation { get; set; }
        public string NhsoZone { get; set; }
        public string ProvinceId { get; set; }
        public string ProvinceIdCatm { get; set; }
        public string AmphurId { get; set; }
        public string DistrictId { get; set; }
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
        public string Sp7DateStr { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public string Moo { get; set; }
        public bool Used { get; set; }
        public CATMModel CATMs { get; set; }

        //U = ผู้เข้าใช้งาน S = หน่วยบริการ
        public string Approvetype { get; set; }
        //มีรหัสคู่สัญญาอยู่แล้ว=true
        public bool CheckRegister { get; set; }

        public IList<RegisterNhsoFileDTO> FileList { get; set; }


    }
}
