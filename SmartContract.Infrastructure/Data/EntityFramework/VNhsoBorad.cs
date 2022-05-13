using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class VNhsoBorad
    {
        public string EmpId { get; set; }
        public string DepartmentCode { get; set; }
        public string BoradFullname { get; set; }
        public string BoradPosition { get; set; }
        public string BoradEmail { get; set; }
        public string BureauId { get; set; }
        public string BureauName { get; set; }
        public string BoradType { get; set; }
    }
}
