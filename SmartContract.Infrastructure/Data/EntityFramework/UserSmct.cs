using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class UserSmct
    {
        public UserSmct()
        {
            ApprovalReqCreateUserNavigations = new HashSet<ApprovalReq>();
            ApprovalReqEditUserNavigations = new HashSet<ApprovalReq>();
            ApprovalReqStationCreateUserNavigations = new HashSet<ApprovalReqStation>();
            ApprovalReqStationEditUserNavigations = new HashSet<ApprovalReqStation>();
            ContractCreateUserNavigations = new HashSet<Contract>();
            ContractDetail01CreateUserNavigations = new HashSet<ContractDetail01>();
            ContractDetail01EditUserNavigations = new HashSet<ContractDetail01>();
            ContractDetail02CreateUserNavigations = new HashSet<ContractDetail02>();
            ContractDetail02EditUserNavigations = new HashSet<ContractDetail02>();
            ContractDetail03CreateUserNavigations = new HashSet<ContractDetail03>();
            ContractDetail03EditUserNavigations = new HashSet<ContractDetail03>();
            ContractDetail04CreateUserNavigations = new HashSet<ContractDetail04>();
            ContractDetail04EditUserNavigations = new HashSet<ContractDetail04>();
            ContractDetail05CreateUserNavigations = new HashSet<ContractDetail05>();
            ContractDetail05EditUserNavigations = new HashSet<ContractDetail05>();
            ContractDetail06CreateUserNavigations = new HashSet<ContractDetail06>();
            ContractDetail06EditUserNavigations = new HashSet<ContractDetail06>();
            ContractDetail07CreateUserNavigations = new HashSet<ContractDetail07>();
            ContractDetail07EditUserNavigations = new HashSet<ContractDetail07>();
            ContractDetail08CreateUserNavigations = new HashSet<ContractDetail08>();
            ContractDetail08EditUserNavigations = new HashSet<ContractDetail08>();
            ContractDetail09CreateUserNavigations = new HashSet<ContractDetail09>();
            ContractDetail09EditUserNavigations = new HashSet<ContractDetail09>();
            ContractDetail10CreateUserNavigations = new HashSet<ContractDetail10>();
            ContractDetail10EditUserNavigations = new HashSet<ContractDetail10>();
            ContractDetail11CreateUserNavigations = new HashSet<ContractDetail11>();
            ContractDetail11EditUserNavigations = new HashSet<ContractDetail11>();
            ContractDetail12CreateUserNavigations = new HashSet<ContractDetail12>();
            ContractDetail12EditUserNavigations = new HashSet<ContractDetail12>();
            ContractDetail13CreateUserNavigations = new HashSet<ContractDetail13>();
            ContractDetail13EditUserNavigations = new HashSet<ContractDetail13>();
            ContractDetail14CreateUserNavigations = new HashSet<ContractDetail14>();
            ContractDetail14EditUserNavigations = new HashSet<ContractDetail14>();
            ContractEditUserNavigations = new HashSet<Contract>();
            ContractExtendCreateUserNavigations = new HashSet<ContractExtend>();
            ContractExtendEditUserNavigations = new HashSet<ContractExtend>();
            ContractGuaranteeCreateUserNavigations = new HashSet<ContractGuarantee>();
            ContractGuaranteeDetailCreateUserNavigations = new HashSet<ContractGuaranteeDetail>();
            ContractGuaranteeDetailEditUserNavigations = new HashSet<ContractGuaranteeDetail>();
            ContractGuaranteeEditUserNavigations = new HashSet<ContractGuarantee>();
            ContractPeriodCreateUserNavigations = new HashSet<ContractPeriod>();
            ContractPeriodDetailCreateUserNavigations = new HashSet<ContractPeriodDetail>();
            ContractPeriodDetailEditUserNavigations = new HashSet<ContractPeriodDetail>();
            ContractPeriodEditUserNavigations = new HashSet<ContractPeriod>();
            ContractPlanCreateUserNavigations = new HashSet<ContractPlan>();
            ContractPlanEditUserNavigations = new HashSet<ContractPlan>();
            ContractSbbCklChecklistUserNavigations = new HashSet<ContractSbbCkl>();
            ContractSbbCklCreateUserNavigations = new HashSet<ContractSbbCkl>();
            ContractSbbCklDetailCreateUserNavigations = new HashSet<ContractSbbCklDetail>();
            ContractSbbCklDetailEditUserNavigations = new HashSet<ContractSbbCklDetail>();
            ContractSbbCklEditUserNavigations = new HashSet<ContractSbbCkl>();
            ContractSbbCklHeadingCreateUserNavigations = new HashSet<ContractSbbCklHeading>();
            ContractSbbCklHeadingEditUserNavigations = new HashSet<ContractSbbCklHeading>();
            ContractStationCreateUserNavigations = new HashSet<ContractStation>();
            ContractStationEditUserNavigations = new HashSet<ContractStation>();
            ContractStationGuaranteeCreateUserNavigations = new HashSet<ContractStationGuarantee>();
            ContractStationGuaranteeEditUserNavigations = new HashSet<ContractStationGuarantee>();
            ContractStationSuccessCreateUserNavigations = new HashSet<ContractStationSuccess>();
            ContractStationSuccessEditUserNavigations = new HashSet<ContractStationSuccess>();
            ContractStyleCreateUserNavigations = new HashSet<ContractStyle>();
            ContractStyleEditUserNavigations = new HashSet<ContractStyle>();
            ContractTypeCreateUserNavigations = new HashSet<ContractType>();
            ContractTypeEditUserNavigations = new HashSet<ContractType>();
            ContractVendorCreateUserNavigations = new HashSet<ContractVendor>();
            ContractVendorEditUserNavigations = new HashSet<ContractVendor>();
            GuaranteeLgReqCreateUserNavigations = new HashSet<GuaranteeLgReq>();
            GuaranteeLgReqEditUserNavigations = new HashSet<GuaranteeLgReq>();
            GuaranteeLgReqStationCreateUserNavigations = new HashSet<GuaranteeLgReqStation>();
            GuaranteeLgReqStationEditUserNavigations = new HashSet<GuaranteeLgReqStation>();
            InverseCreateUserNavigation = new HashSet<UserSmct>();
            InverseEditUserNavigation = new HashSet<UserSmct>();
            RegisterNhsoCreateUserNavigations = new HashSet<RegisterNhso>();
            RegisterNhsoEditUserNavigations = new HashSet<RegisterNhso>();
            RegisterNhsoFileCreateUserNavigations = new HashSet<RegisterNhsoFile>();
            RegisterNhsoFileEditUserNavigations = new HashSet<RegisterNhsoFile>();
            RegisterNhsoFileTypeCreateUserNavigations = new HashSet<RegisterNhsoFileType>();
            RegisterNhsoFileTypeEditUserNavigations = new HashSet<RegisterNhsoFileType>();
            SmctMasterCreateUserNavigations = new HashSet<SmctMaster>();
            SmctMasterEditUserNavigations = new HashSet<SmctMaster>();
            SmctMasterFileCreateUserNavigations = new HashSet<SmctMasterFile>();
            SmctMasterFileEditUserNavigations = new HashSet<SmctMasterFile>();
            SmctMasterFileTypeCreateUserNavigations = new HashSet<SmctMasterFileType>();
            SmctMasterFileTypeEditUserNavigations = new HashSet<SmctMasterFileType>();
            SmctMasterSendmailCreateUserNavigations = new HashSet<SmctMasterSendmail>();
            SmctMasterSendmailEditUserNavigations = new HashSet<SmctMasterSendmail>();
            SmctMasterSignerCreateUserNavigations = new HashSet<SmctMasterSigner>();
            SmctMasterSignerDetail1CreateUserNavigations = new HashSet<SmctMasterSignerDetail1>();
            SmctMasterSignerDetail1EditUserNavigations = new HashSet<SmctMasterSignerDetail1>();
            SmctMasterSignerDetail2CreateUserNavigations = new HashSet<SmctMasterSignerDetail2>();
            SmctMasterSignerDetail2EditUserNavigations = new HashSet<SmctMasterSignerDetail2>();
            SmctMasterSignerEditUserNavigations = new HashSet<SmctMasterSigner>();
            UserRightCreateUserNavigations = new HashSet<UserRight>();
            UserRightEditUserNavigations = new HashSet<UserRight>();
            UserRightIdUserSmctNavigations = new HashSet<UserRight>();
            UserRoleCreateUserNavigations = new HashSet<UserRole>();
            UserRoleEditUserNavigations = new HashSet<UserRole>();
            UserSmctLogs = new HashSet<UserSmctLog>();
            UserSmctSignerCreateUserNavigations = new HashSet<UserSmctSigner>();
            UserSmctSignerEditUserNavigations = new HashSet<UserSmctSigner>();
            UserSmctSignerFileCreateUserNavigations = new HashSet<UserSmctSignerFile>();
            UserSmctSignerFileEditUserNavigations = new HashSet<UserSmctSignerFile>();
            UserSmctSignerIdUserSmctNavigations = new HashSet<UserSmctSigner>();
            UserSmctSignerSigner1UserNavigations = new HashSet<UserSmctSigner>();
            UserSmctSignerSigner2PoaSigner1UserNavigations = new HashSet<UserSmctSigner>();
            UserSmctVendorCreateUserNavigations = new HashSet<UserSmctVendor>();
            UserSmctVendorEditUserNavigations = new HashSet<UserSmctVendor>();
            UserSmctVendorIdUserSmctNavigations = new HashSet<UserSmctVendor>();
            VendorLinkReqCreateUserNavigations = new HashSet<VendorLinkReq>();
            VendorLinkReqEditUserNavigations = new HashSet<VendorLinkReq>();
            VendorLinkReqStationCreateUserNavigations = new HashSet<VendorLinkReqStation>();
            VendorLinkReqStationEditUserNavigations = new HashSet<VendorLinkReqStation>();
        }

        public string IdUserSmct { get; set; }
        public string IdUserLevel { get; set; }
        public string DepartmentCode { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserFullname { get; set; }
        public string UserType { get; set; }
        public string Email { get; set; }
        public string Cid { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public string PositionName { get; set; }
        public bool Used { get; set; }
        public DateTime? Birthday { get; set; }

        public virtual UserSmct CreateUserNavigation { get; set; }
        public virtual UserSmct EditUserNavigation { get; set; }
        public virtual UserLevel IdUserLevelNavigation { get; set; }
        public virtual ICollection<ApprovalReq> ApprovalReqCreateUserNavigations { get; set; }
        public virtual ICollection<ApprovalReq> ApprovalReqEditUserNavigations { get; set; }
        public virtual ICollection<ApprovalReqStation> ApprovalReqStationCreateUserNavigations { get; set; }
        public virtual ICollection<ApprovalReqStation> ApprovalReqStationEditUserNavigations { get; set; }
        public virtual ICollection<Contract> ContractCreateUserNavigations { get; set; }
        public virtual ICollection<ContractDetail01> ContractDetail01CreateUserNavigations { get; set; }
        public virtual ICollection<ContractDetail01> ContractDetail01EditUserNavigations { get; set; }
        public virtual ICollection<ContractDetail02> ContractDetail02CreateUserNavigations { get; set; }
        public virtual ICollection<ContractDetail02> ContractDetail02EditUserNavigations { get; set; }
        public virtual ICollection<ContractDetail03> ContractDetail03CreateUserNavigations { get; set; }
        public virtual ICollection<ContractDetail03> ContractDetail03EditUserNavigations { get; set; }
        public virtual ICollection<ContractDetail04> ContractDetail04CreateUserNavigations { get; set; }
        public virtual ICollection<ContractDetail04> ContractDetail04EditUserNavigations { get; set; }
        public virtual ICollection<ContractDetail05> ContractDetail05CreateUserNavigations { get; set; }
        public virtual ICollection<ContractDetail05> ContractDetail05EditUserNavigations { get; set; }
        public virtual ICollection<ContractDetail06> ContractDetail06CreateUserNavigations { get; set; }
        public virtual ICollection<ContractDetail06> ContractDetail06EditUserNavigations { get; set; }
        public virtual ICollection<ContractDetail07> ContractDetail07CreateUserNavigations { get; set; }
        public virtual ICollection<ContractDetail07> ContractDetail07EditUserNavigations { get; set; }
        public virtual ICollection<ContractDetail08> ContractDetail08CreateUserNavigations { get; set; }
        public virtual ICollection<ContractDetail08> ContractDetail08EditUserNavigations { get; set; }
        public virtual ICollection<ContractDetail09> ContractDetail09CreateUserNavigations { get; set; }
        public virtual ICollection<ContractDetail09> ContractDetail09EditUserNavigations { get; set; }
        public virtual ICollection<ContractDetail10> ContractDetail10CreateUserNavigations { get; set; }
        public virtual ICollection<ContractDetail10> ContractDetail10EditUserNavigations { get; set; }
        public virtual ICollection<ContractDetail11> ContractDetail11CreateUserNavigations { get; set; }
        public virtual ICollection<ContractDetail11> ContractDetail11EditUserNavigations { get; set; }
        public virtual ICollection<ContractDetail12> ContractDetail12CreateUserNavigations { get; set; }
        public virtual ICollection<ContractDetail12> ContractDetail12EditUserNavigations { get; set; }
        public virtual ICollection<ContractDetail13> ContractDetail13CreateUserNavigations { get; set; }
        public virtual ICollection<ContractDetail13> ContractDetail13EditUserNavigations { get; set; }
        public virtual ICollection<ContractDetail14> ContractDetail14CreateUserNavigations { get; set; }
        public virtual ICollection<ContractDetail14> ContractDetail14EditUserNavigations { get; set; }
        public virtual ICollection<Contract> ContractEditUserNavigations { get; set; }
        public virtual ICollection<ContractExtend> ContractExtendCreateUserNavigations { get; set; }
        public virtual ICollection<ContractExtend> ContractExtendEditUserNavigations { get; set; }
        public virtual ICollection<ContractGuarantee> ContractGuaranteeCreateUserNavigations { get; set; }
        public virtual ICollection<ContractGuaranteeDetail> ContractGuaranteeDetailCreateUserNavigations { get; set; }
        public virtual ICollection<ContractGuaranteeDetail> ContractGuaranteeDetailEditUserNavigations { get; set; }
        public virtual ICollection<ContractGuarantee> ContractGuaranteeEditUserNavigations { get; set; }
        public virtual ICollection<ContractPeriod> ContractPeriodCreateUserNavigations { get; set; }
        public virtual ICollection<ContractPeriodDetail> ContractPeriodDetailCreateUserNavigations { get; set; }
        public virtual ICollection<ContractPeriodDetail> ContractPeriodDetailEditUserNavigations { get; set; }
        public virtual ICollection<ContractPeriod> ContractPeriodEditUserNavigations { get; set; }
        public virtual ICollection<ContractPlan> ContractPlanCreateUserNavigations { get; set; }
        public virtual ICollection<ContractPlan> ContractPlanEditUserNavigations { get; set; }
        public virtual ICollection<ContractSbbCkl> ContractSbbCklChecklistUserNavigations { get; set; }
        public virtual ICollection<ContractSbbCkl> ContractSbbCklCreateUserNavigations { get; set; }
        public virtual ICollection<ContractSbbCklDetail> ContractSbbCklDetailCreateUserNavigations { get; set; }
        public virtual ICollection<ContractSbbCklDetail> ContractSbbCklDetailEditUserNavigations { get; set; }
        public virtual ICollection<ContractSbbCkl> ContractSbbCklEditUserNavigations { get; set; }
        public virtual ICollection<ContractSbbCklHeading> ContractSbbCklHeadingCreateUserNavigations { get; set; }
        public virtual ICollection<ContractSbbCklHeading> ContractSbbCklHeadingEditUserNavigations { get; set; }
        public virtual ICollection<ContractStation> ContractStationCreateUserNavigations { get; set; }
        public virtual ICollection<ContractStation> ContractStationEditUserNavigations { get; set; }
        public virtual ICollection<ContractStationGuarantee> ContractStationGuaranteeCreateUserNavigations { get; set; }
        public virtual ICollection<ContractStationGuarantee> ContractStationGuaranteeEditUserNavigations { get; set; }
        public virtual ICollection<ContractStationSuccess> ContractStationSuccessCreateUserNavigations { get; set; }
        public virtual ICollection<ContractStationSuccess> ContractStationSuccessEditUserNavigations { get; set; }
        public virtual ICollection<ContractStyle> ContractStyleCreateUserNavigations { get; set; }
        public virtual ICollection<ContractStyle> ContractStyleEditUserNavigations { get; set; }
        public virtual ICollection<ContractType> ContractTypeCreateUserNavigations { get; set; }
        public virtual ICollection<ContractType> ContractTypeEditUserNavigations { get; set; }
        public virtual ICollection<ContractVendor> ContractVendorCreateUserNavigations { get; set; }
        public virtual ICollection<ContractVendor> ContractVendorEditUserNavigations { get; set; }
        public virtual ICollection<GuaranteeLgReq> GuaranteeLgReqCreateUserNavigations { get; set; }
        public virtual ICollection<GuaranteeLgReq> GuaranteeLgReqEditUserNavigations { get; set; }
        public virtual ICollection<GuaranteeLgReqStation> GuaranteeLgReqStationCreateUserNavigations { get; set; }
        public virtual ICollection<GuaranteeLgReqStation> GuaranteeLgReqStationEditUserNavigations { get; set; }
        public virtual ICollection<UserSmct> InverseCreateUserNavigation { get; set; }
        public virtual ICollection<UserSmct> InverseEditUserNavigation { get; set; }
        public virtual ICollection<RegisterNhso> RegisterNhsoCreateUserNavigations { get; set; }
        public virtual ICollection<RegisterNhso> RegisterNhsoEditUserNavigations { get; set; }
        public virtual ICollection<RegisterNhsoFile> RegisterNhsoFileCreateUserNavigations { get; set; }
        public virtual ICollection<RegisterNhsoFile> RegisterNhsoFileEditUserNavigations { get; set; }
        public virtual ICollection<RegisterNhsoFileType> RegisterNhsoFileTypeCreateUserNavigations { get; set; }
        public virtual ICollection<RegisterNhsoFileType> RegisterNhsoFileTypeEditUserNavigations { get; set; }
        public virtual ICollection<SmctMaster> SmctMasterCreateUserNavigations { get; set; }
        public virtual ICollection<SmctMaster> SmctMasterEditUserNavigations { get; set; }
        public virtual ICollection<SmctMasterFile> SmctMasterFileCreateUserNavigations { get; set; }
        public virtual ICollection<SmctMasterFile> SmctMasterFileEditUserNavigations { get; set; }
        public virtual ICollection<SmctMasterFileType> SmctMasterFileTypeCreateUserNavigations { get; set; }
        public virtual ICollection<SmctMasterFileType> SmctMasterFileTypeEditUserNavigations { get; set; }
        public virtual ICollection<SmctMasterSendmail> SmctMasterSendmailCreateUserNavigations { get; set; }
        public virtual ICollection<SmctMasterSendmail> SmctMasterSendmailEditUserNavigations { get; set; }
        public virtual ICollection<SmctMasterSigner> SmctMasterSignerCreateUserNavigations { get; set; }
        public virtual ICollection<SmctMasterSignerDetail1> SmctMasterSignerDetail1CreateUserNavigations { get; set; }
        public virtual ICollection<SmctMasterSignerDetail1> SmctMasterSignerDetail1EditUserNavigations { get; set; }
        public virtual ICollection<SmctMasterSignerDetail2> SmctMasterSignerDetail2CreateUserNavigations { get; set; }
        public virtual ICollection<SmctMasterSignerDetail2> SmctMasterSignerDetail2EditUserNavigations { get; set; }
        public virtual ICollection<SmctMasterSigner> SmctMasterSignerEditUserNavigations { get; set; }
        public virtual ICollection<UserRight> UserRightCreateUserNavigations { get; set; }
        public virtual ICollection<UserRight> UserRightEditUserNavigations { get; set; }
        public virtual ICollection<UserRight> UserRightIdUserSmctNavigations { get; set; }
        public virtual ICollection<UserRole> UserRoleCreateUserNavigations { get; set; }
        public virtual ICollection<UserRole> UserRoleEditUserNavigations { get; set; }
        public virtual ICollection<UserSmctLog> UserSmctLogs { get; set; }
        public virtual ICollection<UserSmctSigner> UserSmctSignerCreateUserNavigations { get; set; }
        public virtual ICollection<UserSmctSigner> UserSmctSignerEditUserNavigations { get; set; }
        public virtual ICollection<UserSmctSignerFile> UserSmctSignerFileCreateUserNavigations { get; set; }
        public virtual ICollection<UserSmctSignerFile> UserSmctSignerFileEditUserNavigations { get; set; }
        public virtual ICollection<UserSmctSigner> UserSmctSignerIdUserSmctNavigations { get; set; }
        public virtual ICollection<UserSmctSigner> UserSmctSignerSigner1UserNavigations { get; set; }
        public virtual ICollection<UserSmctSigner> UserSmctSignerSigner2PoaSigner1UserNavigations { get; set; }
        public virtual ICollection<UserSmctVendor> UserSmctVendorCreateUserNavigations { get; set; }
        public virtual ICollection<UserSmctVendor> UserSmctVendorEditUserNavigations { get; set; }
        public virtual ICollection<UserSmctVendor> UserSmctVendorIdUserSmctNavigations { get; set; }
        public virtual ICollection<VendorLinkReq> VendorLinkReqCreateUserNavigations { get; set; }
        public virtual ICollection<VendorLinkReq> VendorLinkReqEditUserNavigations { get; set; }
        public virtual ICollection<VendorLinkReqStation> VendorLinkReqStationCreateUserNavigations { get; set; }
        public virtual ICollection<VendorLinkReqStation> VendorLinkReqStationEditUserNavigations { get; set; }
    }
}
