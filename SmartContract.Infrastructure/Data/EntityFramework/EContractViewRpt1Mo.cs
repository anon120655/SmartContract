using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class EContractViewRpt1Mo
    {
        public string Budgetyear { get; set; }
        public string Deptcode { get; set; }
        public string ContractNo { get; set; }
        public string ContractId { get; set; }
        public string TypeId { get; set; }
        public string TypeName { get; set; }
        public string TypeGroup { get; set; }
        public string VendorId { get; set; }
        public string Budgetcode { get; set; }
        public string ContractName { get; set; }
        public decimal? Budget { get; set; }
        public decimal? OrderNo { get; set; }
        public decimal? OrderBudget { get; set; }
        public decimal? OrderPay { get; set; }
        public string OrderDetail { get; set; }
        public string Remark { get; set; }
        public string FFile { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string FReturn { get; set; }
        public decimal? Reserve1 { get; set; }
        public DateTime? ContractDate { get; set; }
        public string EditUser { get; set; }
        public string SourceType { get; set; }
    }
}
