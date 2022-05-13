using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class UserSmctLog
    {
        public string IdUserSmctLog { get; set; }
        public DateTime CreateDate { get; set; }
        public string IdUserSmct { get; set; }
        public string IpAddress { get; set; }

        public virtual UserSmct IdUserSmctNavigation { get; set; }
    }
}
