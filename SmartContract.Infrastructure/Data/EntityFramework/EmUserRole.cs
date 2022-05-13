using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class EmUserRole
    {
        public int No { get; set; }
        public string Name { get; set; }
        public string GroupCode { get; set; }
        public string Drescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUser { get; set; }
        public DateTime EditedDate { get; set; }
        public int EditedUser { get; set; }
        public string Used { get; set; }

        public virtual EmUser CreatedUserNavigation { get; set; }
        public virtual EmUser EditedUserNavigation { get; set; }
    }
}
