using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFrameworkEbudget
{
    public partial class EcContract
    {
        public EcContract()
        {
            EcContractVendorOwners = new HashSet<EcContractVendorOwner>();
            EcContractVendorReqs = new HashSet<EcContractVendorReq>();
            EcContractVendors = new HashSet<EcContractVendor>();
        }

        public int No { get; set; }
        public int MasterNo { get; set; }
        public string Id { get; set; }
        public string Deptcode { get; set; }
        public int TypeNo { get; set; }
        public string TypeContractVendor { get; set; }
        public string ContractType { get; set; }
        public DateTime? ContractDate { get; set; }
        public string ContractName { get; set; }
        public decimal? Budget { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string NhsoSignTitleId { get; set; }
        public string NhsoSignFname { get; set; }
        public string NhsoSignLname { get; set; }
        public string NhsoSignPositionId { get; set; }
        public string NhsoPmEmail { get; set; }
        public string VendorSignTitleId1 { get; set; }
        public string VendorSignFname1 { get; set; }
        public string VendorSignLname1 { get; set; }
        public string VendorSignPosition1 { get; set; }
        public string VendorSignTitleId2 { get; set; }
        public string VendorSignFname2 { get; set; }
        public string VendorSignLname2 { get; set; }
        public string VendorSignPosition2 { get; set; }
        public string VendorSignTitleId3 { get; set; }
        public string VendorSignFname3 { get; set; }
        public string VendorSignLname3 { get; set; }
        public string VendorSignPosition3 { get; set; }
        public string VendorApproveType { get; set; }
        public string VendorApp1Doc { get; set; }
        public string VendorApp1Docno { get; set; }
        public DateTime? VendorApp1Docdate { get; set; }
        public string VendorApp2Doc1 { get; set; }
        public string VendorApp2Docno1 { get; set; }
        public DateTime? VendorApp2Docdate1 { get; set; }
        public string VendorApp2Doc2 { get; set; }
        public string VendorApp2Docno2 { get; set; }
        public DateTime? VendorApp2Docdate2 { get; set; }
        public string VendorApp2TitleId1 { get; set; }
        public string VendorApp2Fname1 { get; set; }
        public string VendorApp2Lname1 { get; set; }
        public string VendorApp2TitleId2 { get; set; }
        public string VendorApp2Fname2 { get; set; }
        public string VendorApp2Lname2 { get; set; }
        public string VendorApp2TitleId3 { get; set; }
        public string VendorApp2Fname3 { get; set; }
        public string VendorApp2Lname3 { get; set; }
        public string SubContractType { get; set; }
        public short? GuaranteeDay { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUser { get; set; }
        public DateTime EditedDate { get; set; }
        public int EditedUser { get; set; }
        public string Used { get; set; }

        public virtual ICollection<EcContractVendorOwner> EcContractVendorOwners { get; set; }
        public virtual ICollection<EcContractVendorReq> EcContractVendorReqs { get; set; }
        public virtual ICollection<EcContractVendor> EcContractVendors { get; set; }
    }
}
