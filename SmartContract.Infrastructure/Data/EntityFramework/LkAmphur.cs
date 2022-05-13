using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class LkAmphur
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string ProvinceId { get; set; }
        public string AmphurId { get; set; }
        public decimal? Gyear { get; set; }
        public decimal? Available { get; set; }
    }
}
