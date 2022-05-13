using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFrameworkEbudget
{
    public partial class EcContractVendorOwner
    {
        public int No { get; set; }
        public int ContractNo { get; set; }
        public string Name { get; set; }
        public string Catm { get; set; }
        public string Moo { get; set; }
        public string HouseNumber { get; set; }
        public string Building { get; set; }
        public string PostCode { get; set; }
        public string Road { get; set; }
        public string Soi { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Sp7 { get; set; }
        public DateTime? Sp7Date { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUser { get; set; }
        public DateTime EditedDate { get; set; }
        public int EditedUser { get; set; }
        public string Used { get; set; }

        public virtual EcContract ContractNoNavigation { get; set; }
    }
}
