using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class LOrgOther
    {
        public decimal Seq { get; set; }
        public string Used { get; set; }
        public DateTime Inserted { get; set; }
        public DateTime Lastupdate { get; set; }
        public string Byuser { get; set; }
        public string Remark { get; set; }
        public string VendorId { get; set; }
        public string VendorName { get; set; }
        public string ProvinceId { get; set; }
        public string OrgType { get; set; }
        public string Address { get; set; }
        public string AccountId { get; set; }
        public string AccountName { get; set; }
        public string BankId { get; set; }
        public string ContractorName { get; set; }
        public string ContractorPid { get; set; }
        public string Phone { get; set; }
        public string HospDmis { get; set; }
        public string TId { get; set; }
        public string Fax { get; set; }
        public string Road { get; set; }
        public string Soi { get; set; }
        public string Catm { get; set; }
        public string PostCode { get; set; }
        public string BankB { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string ReqNo { get; set; }
        public string MinstId { get; set; }
        public string MinstName { get; set; }
    }
}
