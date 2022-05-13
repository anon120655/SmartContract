using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class LkProvince
    {
        public decimal? Seq { get; set; }
        public string ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public string Countryzone { get; set; }
        public string MophZone { get; set; }
        public string NhsoZone { get; set; }
        public string NhsoZonename { get; set; }
        public string RegionName { get; set; }
        public string Region { get; set; }
        public string NhsoZoneold { get; set; }
        public string DdcZone { get; set; }
    }
}
