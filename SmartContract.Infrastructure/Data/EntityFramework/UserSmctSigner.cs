using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class UserSmctSigner
    {
        public UserSmctSigner()
        {
            UserSmctSignerFiles = new HashSet<UserSmctSignerFile>();
        }

        public string IdUserSmctSigner { get; set; }
        public string IdUserSmct { get; set; }
        public string SignerType { get; set; }
        public string Signer1DocName { get; set; }
        public string Signer1DocNo { get; set; }
        public DateTime? Signer1DocDate { get; set; }
        public string Signer2PoaDocNo { get; set; }
        public DateTime? Signer2PoaDocDate { get; set; }
        public string Signer2PoaSigner1User { get; set; }
        public string Signer2PoaSigner1Name { get; set; }
        public string Signer2DocName { get; set; }
        public string Signer2DocNo { get; set; }
        public DateTime? Signer2DocDate { get; set; }
        public DateTime? Signer2StartDate { get; set; }
        public DateTime? Signer2EndDate { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public bool Used { get; set; }
        public string Signer1User { get; set; }
        public string Signer1Name { get; set; }

        public virtual UserSmct CreateUserNavigation { get; set; }
        public virtual UserSmct EditUserNavigation { get; set; }
        public virtual UserSmct IdUserSmctNavigation { get; set; }
        public virtual UserSmct Signer1UserNavigation { get; set; }
        public virtual UserSmct Signer2PoaSigner1UserNavigation { get; set; }
        public virtual ICollection<UserSmctSignerFile> UserSmctSignerFiles { get; set; }
    }
}
