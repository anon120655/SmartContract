using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class LkDepartment
    {
        public string Dcode { get; set; }
        public string Dname { get; set; }
        public string Dename { get; set; }
        public string LogUser { get; set; }
        public DateTime? LogDate { get; set; }
        public string Status { get; set; }
        public string Subject { get; set; }
        public string DnameNew { get; set; }
        public string ProvinceId { get; set; }
        public string NhsoZone { get; set; }
        public string DcodeShort { get; set; }
        public string EmpBuid { get; set; }
        public decimal? Orderno { get; set; }
        public string BureauId { get; set; }
        public string Display { get; set; }
    }
}
