using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class UserLevel2
    {
        public string IdUserLevel { get; set; }
        public string UserLevelCode { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public bool Used { get; set; }
    }
}
