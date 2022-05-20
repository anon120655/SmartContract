using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class VGuaranteeLgContract
    {
        public string Budgetyear { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string RefId { get; set; }
        public DateTime RefDate { get; set; }
        public string ContractSignType { get; set; }
        public string ContractId { get; set; }
        public DateTime? ContractDate { get; set; }
        public string ContractName { get; set; }
        public string ContractTypeName { get; set; }
        public string VendorId { get; set; }
        public string VendorName { get; set; }
        public string LgNumber { get; set; }
        public DateTime? LgDate { get; set; }
        public DateTime? EffectiveDateStart { get; set; }
        public DateTime? EffectiveDateEnd { get; set; }
        public decimal LgAmountInitial { get; set; }
        public string Aaa { get; set; }
    }
}
