using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class RegisterNhso
    {
        public RegisterNhso()
        {
            RegisterNhsoFiles = new HashSet<RegisterNhsoFile>();
            SmctMasters = new HashSet<SmctMaster>();
            UserSmctVendors = new HashSet<UserSmctVendor>();
        }

        public string IdRegisterNhso { get; set; }
        public string RegisterNo { get; set; }
        public string RegisterType { get; set; }
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
        public string DepartmentCode { get; set; }
        public string Remark { get; set; }

        public virtual UserSmct CreateUserNavigation { get; set; }
        public virtual UserSmct EditUserNavigation { get; set; }
        public virtual ICollection<RegisterNhsoFile> RegisterNhsoFiles { get; set; }
        public virtual ICollection<SmctMaster> SmctMasters { get; set; }
        public virtual ICollection<UserSmctVendor> UserSmctVendors { get; set; }
    }
}
