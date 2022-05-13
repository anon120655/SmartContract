using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class VNhsoZone
    {
        public string Region { get; set; }
        public string RegionName { get; set; }
        public string NhsoZone { get; set; }
        public string NhsoZonename { get; set; }
        public string ProvinceId { get; set; }
        public string ProvinceName { get; set; }
    }
}
