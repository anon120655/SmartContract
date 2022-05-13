using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class UserSmctSignerFile
    {
        public string IdUserSmctSignerFile { get; set; }
        public string IdUserSmctSigner { get; set; }
        public string SignerFileType { get; set; }
        public string SignerFileName { get; set; }
        public string SignerFileFtp { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public decimal SignerFileNo { get; set; }
        public bool Used { get; set; }
        public string PathFolder { get; set; }

        public virtual UserSmct CreateUserNavigation { get; set; }
        public virtual UserSmct EditUserNavigation { get; set; }
        public virtual UserSmctSigner IdUserSmctSignerNavigation { get; set; }
    }
}
