using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class EmpBureau
    {
        public string EmpBuid { get; set; }
        public string EmpBudesc { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime? ModDate { get; set; }
        public string ModUser { get; set; }
        public string Permission { get; set; }
        public string EmpBuidO { get; set; }
    }
}
