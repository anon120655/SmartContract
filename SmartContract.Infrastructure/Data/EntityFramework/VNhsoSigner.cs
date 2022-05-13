using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class VNhsoSigner
    {
        public string EmpId { get; set; }
        public string DepartmentCode { get; set; }
        public string SignerFullname { get; set; }
        public string SignerPosition { get; set; }
        public string SignerEmail { get; set; }
        public string SignerType { get; set; }
    }
}
