using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class ApprovalReq
    {
        public ApprovalReq()
        {
            ApprovalReqStations = new HashSet<ApprovalReqStation>();
        }

        public string IdApprovalReq { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public string IdSmctMaster { get; set; }
        public string ApprovalReqId { get; set; }
        public DateTime? ApprovalReqDate { get; set; }
        public string ContractName { get; set; }
        public string Reason { get; set; }
        public string CoordinatorUser { get; set; }
        public string CoordinatorFullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public bool Used { get; set; }
        public string Version { get; set; }
        public string Chairman { get; set; }
        public string Board1 { get; set; }
        public string Board2 { get; set; }
        public string Board3 { get; set; }
        public string Board4 { get; set; }
        public string Board5 { get; set; }
        public string ApprovalReqUser { get; set; }
        public string ApprovalReqUserPos { get; set; }
        public string Status { get; set; }
        public string StatusCheckMail { get; set; }

        public virtual UserSmct CreateUserNavigation { get; set; }
        public virtual UserSmct EditUserNavigation { get; set; }
        public virtual SmctMaster IdSmctMasterNavigation { get; set; }
        public virtual ICollection<ApprovalReqStation> ApprovalReqStations { get; set; }
    }
}
