using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class SmctMasterFile
    {
        public string IdSmctMasterFile { get; set; }
        public string IdSmctMaster { get; set; }
        public string FileType { get; set; }
        public string FileName { get; set; }
        public string FileFtp { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public decimal FileNo { get; set; }
        public bool Used { get; set; }
        public string IdSmctMasterFileType { get; set; }
        public string PathFolder { get; set; }

        public virtual UserSmct CreateUserNavigation { get; set; }
        public virtual UserSmct EditUserNavigation { get; set; }
        public virtual SmctMasterFileType IdSmctMasterFileTypeNavigation { get; set; }
        public virtual SmctMaster IdSmctMasterNavigation { get; set; }
    }
}
