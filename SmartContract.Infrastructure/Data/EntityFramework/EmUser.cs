using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class EmUser
    {
        public EmUser()
        {
            EmUserRigthCreatedUserNavigations = new HashSet<EmUserRigth>();
            EmUserRigthEditedUserNavigations = new HashSet<EmUserRigth>();
            EmUserRigthUserNoNavigations = new HashSet<EmUserRigth>();
            EmUserRoleCreatedUserNavigations = new HashSet<EmUserRole>();
            EmUserRoleEditedUserNavigations = new HashSet<EmUserRole>();
            EmUserTypeCreatedUserNavigations = new HashSet<EmUserType>();
            EmUserTypeEditedUserNavigations = new HashSet<EmUserType>();
        }

        public int No { get; set; }
        public string Userid { get; set; }
        public string Username { get; set; }
        public string Pwd { get; set; }
        public int TypeNo { get; set; }
        public string Status { get; set; }
        public string Remark { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUser { get; set; }
        public DateTime EditedDate { get; set; }
        public int EditedUser { get; set; }
        public string Used { get; set; }

        public virtual ICollection<EmUserRigth> EmUserRigthCreatedUserNavigations { get; set; }
        public virtual ICollection<EmUserRigth> EmUserRigthEditedUserNavigations { get; set; }
        public virtual ICollection<EmUserRigth> EmUserRigthUserNoNavigations { get; set; }
        public virtual ICollection<EmUserRole> EmUserRoleCreatedUserNavigations { get; set; }
        public virtual ICollection<EmUserRole> EmUserRoleEditedUserNavigations { get; set; }
        public virtual ICollection<EmUserType> EmUserTypeCreatedUserNavigations { get; set; }
        public virtual ICollection<EmUserType> EmUserTypeEditedUserNavigations { get; set; }
    }
}
