using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class VSmctContract
    {
        public string ContractId { get; set; }
        public string ContractTypeId { get; set; }
        public string ContractTypeShortName { get; set; }
        public string ContractTypeFullName { get; set; }
        public string ContractName { get; set; }
        public DateTime? ContractDate { get; set; }
        public string DepartmentCode { get; set; }
    }
}
