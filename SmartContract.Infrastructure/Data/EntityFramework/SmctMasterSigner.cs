using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class SmctMasterSigner
    {
        public SmctMasterSigner()
        {
            SmctMasterSignerDetail1s = new HashSet<SmctMasterSignerDetail1>();
            SmctMasterSignerDetail2s = new HashSet<SmctMasterSignerDetail2>();
        }

        public string IdSmctMasterSigner { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public bool Used { get; set; }
        public string IdSmctMaster { get; set; }
        public string ContractSignerType { get; set; }

        public virtual UserSmct CreateUserNavigation { get; set; }
        public virtual UserSmct EditUserNavigation { get; set; }
        public virtual SmctMaster IdSmctMasterNavigation { get; set; }
        public virtual ICollection<SmctMasterSignerDetail1> SmctMasterSignerDetail1s { get; set; }
        public virtual ICollection<SmctMasterSignerDetail2> SmctMasterSignerDetail2s { get; set; }
    }
}
