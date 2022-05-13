using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFrameworkEbudget
{
    public partial class EcContractVendorReq
    {
        public int No { get; set; }
        public int ContractNo { get; set; }
        public string Id { get; set; }
        public string VendorType { get; set; }
        public string VendorId { get; set; }
        public string VendorName { get; set; }
        public string CompanyName { get; set; }
        public string ProvinceId { get; set; }
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
        public string ContractorName { get; set; }
        public string AccName { get; set; }
        public string AccNo { get; set; }
        public string BankId { get; set; }
        public string BranchName { get; set; }
        public string BranchId { get; set; }
        public string CardType { get; set; }
        public string CardId { get; set; }
        public string SearchTerm { get; set; }
        public string CostCenter { get; set; }
        public string TaxId { get; set; }
        public DateTime? ApproveDate { get; set; }
        public int? ApproveUser { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUser { get; set; }
        public DateTime EditedDate { get; set; }
        public int EditedUser { get; set; }
        public string Used { get; set; }
        public string Enaccname { get; set; }
        public string Enaccadr1 { get; set; }
        public string Enaccadr2 { get; set; }
        public string Enaccadr3 { get; set; }
        public string BankBrnInd { get; set; }

        public virtual EcContract ContractNoNavigation { get; set; }
    }
}
