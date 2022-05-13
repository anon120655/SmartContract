using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class EmUserRigth
    {
        public int No { get; set; }
        public int UserNo { get; set; }
        public int RoleNo { get; set; }
        public string Permission { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUser { get; set; }
        public DateTime EditedDate { get; set; }
        public int EditedUser { get; set; }
        public string Used { get; set; }

        public virtual EmUser CreatedUserNavigation { get; set; }
        public virtual EmUser EditedUserNavigation { get; set; }
        public virtual EmUser UserNoNavigation { get; set; }
    }
}
