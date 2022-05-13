using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class RSmctRpt1
    {
        public string IdRSmctRpt1 { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public bool Used { get; set; }
        public string YyyymmAt { get; set; }
        public string Budgetyear { get; set; }
        public string StatusType { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string RefId { get; set; }
        public DateTime RefDate { get; set; }
        public string ContractId { get; set; }
        public DateTime ContractDate { get; set; }
        public string ContractTypeId { get; set; }
        public string ContractTypeName { get; set; }
        public string ContractTypeGroup { get; set; }
        public string VendorId { get; set; }
        public string VendorName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string FundTypeCode { get; set; }
        public string FundTypeName { get; set; }
        public byte? ContractPeriodNo { get; set; }
        public string ContractPeriodBudgetcode { get; set; }
        public string ContractPeriodVendorId { get; set; }
        public decimal? ContractPeriodBudget { get; set; }
        public decimal? ContractPeriodPay { get; set; }
        public decimal? ContractPeriodRemain { get; set; }
        public string FFile { get; set; }
    }
}
