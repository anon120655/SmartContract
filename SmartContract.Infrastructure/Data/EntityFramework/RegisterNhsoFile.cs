using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class RegisterNhsoFile
    {
        public string IdRegisterNhsoFile { get; set; }
        public string IdRegisterNhso { get; set; }
        public string RegisterFileType { get; set; }
        public string RegisterFileName { get; set; }
        public string RegisterFileFtp { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public decimal RegisterFileNo { get; set; }
        public bool Used { get; set; }
        public string IdRegisterNhsoFileType { get; set; }
        public string PathFolder { get; set; }

        public virtual UserSmct CreateUserNavigation { get; set; }
        public virtual UserSmct EditUserNavigation { get; set; }
        public virtual RegisterNhsoFileType IdRegisterNhsoFileTypeNavigation { get; set; }
        public virtual RegisterNhso IdRegisterNhsoNavigation { get; set; }
    }
}
