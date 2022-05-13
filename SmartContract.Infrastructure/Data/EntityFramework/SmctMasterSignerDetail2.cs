using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class SmctMasterSignerDetail2
    {
        public string IdSmctMasterSignerDetail2 { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public bool Used { get; set; }
        public string IdSmctMasterSigner { get; set; }
        public string NhsoKetApprovalUser { get; set; }
        public string NhsoKetCheckerUser { get; set; }
        public string NhsoKetProposalUser { get; set; }

        public virtual UserSmct CreateUserNavigation { get; set; }
        public virtual UserSmct EditUserNavigation { get; set; }
        public virtual SmctMasterSigner IdSmctMasterSignerNavigation { get; set; }
    }
}
