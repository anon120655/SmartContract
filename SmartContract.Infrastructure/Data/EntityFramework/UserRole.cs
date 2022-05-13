using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class UserRole
    {
        public UserRole()
        {
            UserRights = new HashSet<UserRight>();
        }

        public string IdUserRole { get; set; }
        public string UserRoleCode { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public bool Used { get; set; }

        public virtual UserSmct CreateUserNavigation { get; set; }
        public virtual UserSmct EditUserNavigation { get; set; }
        public virtual ICollection<UserRight> UserRights { get; set; }
    }
}
