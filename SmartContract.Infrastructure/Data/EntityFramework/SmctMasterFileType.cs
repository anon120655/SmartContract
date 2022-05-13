using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class SmctMasterFileType
    {
        public SmctMasterFileType()
        {
            SmctMasterFiles = new HashSet<SmctMasterFile>();
        }

        public string IdSmctMasterFileType { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public bool Used { get; set; }
        public string FileTypeId { get; set; }
        public string FileTypeName { get; set; }
        public string FileTypeGroup { get; set; }
        public string ContractTypeId { get; set; }

        public virtual UserSmct CreateUserNavigation { get; set; }
        public virtual UserSmct EditUserNavigation { get; set; }
        public virtual ICollection<SmctMasterFile> SmctMasterFiles { get; set; }
    }
}
