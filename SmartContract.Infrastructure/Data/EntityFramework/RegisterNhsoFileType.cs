using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class RegisterNhsoFileType
    {
        public RegisterNhsoFileType()
        {
            RegisterNhsoFiles = new HashSet<RegisterNhsoFile>();
        }

        public string IdRegisterNhsoFileType { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public bool Used { get; set; }
        public string FileTypeId { get; set; }
        public string FileTypeName { get; set; }
        public string FileTypeGroup { get; set; }
        public string FileTypeParentId { get; set; }

        public virtual UserSmct CreateUserNavigation { get; set; }
        public virtual UserSmct EditUserNavigation { get; set; }
        public virtual ICollection<RegisterNhsoFile> RegisterNhsoFiles { get; set; }
    }
}
