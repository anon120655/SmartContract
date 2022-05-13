using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class UserRight
    {
        public string IdUserRights { get; set; }
        public string IdUserSmct { get; set; }
        public string IdUserRole { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public bool Used { get; set; }
        public string Remark { get; set; }

        public virtual UserSmct CreateUserNavigation { get; set; }
        public virtual UserSmct EditUserNavigation { get; set; }
        public virtual UserRole IdUserRoleNavigation { get; set; }
        public virtual UserSmct IdUserSmctNavigation { get; set; }
    }
}
