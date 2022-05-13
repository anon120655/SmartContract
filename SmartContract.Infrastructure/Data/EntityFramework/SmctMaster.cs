using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class SmctMaster
    {
        public SmctMaster()
        {
            ApprovalReqStations = new HashSet<ApprovalReqStation>();
            ApprovalReqs = new HashSet<ApprovalReq>();
            ContractGuarantees = new HashSet<ContractGuarantee>();
            ContractStationGuarantees = new HashSet<ContractStationGuarantee>();
            ContractStationSuccesses = new HashSet<ContractStationSuccess>();
            ContractStations = new HashSet<ContractStation>();
            Contracts = new HashSet<Contract>();
            SmctMasterFiles = new HashSet<SmctMasterFile>();
            SmctMasterSendmails = new HashSet<SmctMasterSendmail>();
            SmctMasterSigners = new HashSet<SmctMasterSigner>();
            VendorLinkReqStations = new HashSet<VendorLinkReqStation>();
            VendorLinkReqs = new HashSet<VendorLinkReq>();
        }

        public string IdSmctMaster { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public string RefId { get; set; }
        public DateTime RefDate { get; set; }
        public string Budgetyear { get; set; }
        public string DepartmentCode { get; set; }
        public string FVendorlink { get; set; }
        public string ContractSignType { get; set; }
        public string IdRegisterNhso { get; set; }
        public bool Used { get; set; }

        public virtual UserSmct CreateUserNavigation { get; set; }
        public virtual UserSmct EditUserNavigation { get; set; }
        public virtual RegisterNhso IdRegisterNhsoNavigation { get; set; }
        public virtual ICollection<ApprovalReqStation> ApprovalReqStations { get; set; }
        public virtual ICollection<ApprovalReq> ApprovalReqs { get; set; }
        public virtual ICollection<ContractGuarantee> ContractGuarantees { get; set; }
        public virtual ICollection<ContractStationGuarantee> ContractStationGuarantees { get; set; }
        public virtual ICollection<ContractStationSuccess> ContractStationSuccesses { get; set; }
        public virtual ICollection<ContractStation> ContractStations { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<SmctMasterFile> SmctMasterFiles { get; set; }
        public virtual ICollection<SmctMasterSendmail> SmctMasterSendmails { get; set; }
        public virtual ICollection<SmctMasterSigner> SmctMasterSigners { get; set; }
        public virtual ICollection<VendorLinkReqStation> VendorLinkReqStations { get; set; }
        public virtual ICollection<VendorLinkReq> VendorLinkReqs { get; set; }
    }
}
