using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class ViewRequestRegister
    {
        public long Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedId { get; set; }
        public DateTime? LastupdatedDate { get; set; }
        public string LastupdatedId { get; set; }
        public string Address { get; set; }
        public DateTime? ApproveFromRegisterDate { get; set; }
        public string Status { get; set; }
        public bool? Checkdocument { get; set; }
        public string CommentDocument { get; set; }
        public string CommentZoneApprove { get; set; }
        public string CommentNhsoApprove { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public string Email { get; set; }
        public string ExecutiveGovernment { get; set; }
        public string ExecutiveInformation { get; set; }
        public string Fax { get; set; }
        public string FileProblemOtherName { get; set; }
        public string FillerEmail { get; set; }
        public string FillerName { get; set; }
        public string FillerPhone { get; set; }
        public string FstatusId { get; set; }
        public string Hcode { get; set; }
        public string Hname { get; set; }
        public string HofftypeOther { get; set; }
        public string JuristicName { get; set; }
        public string LackDocument { get; set; }
        public string Moo { get; set; }
        public long? NetworkId { get; set; }
        public bool? NhsoApproveStatus { get; set; }
        public string Note { get; set; }
        public string NotificationRegisterStatus { get; set; }
        public string NotifyNhsoApproveComment { get; set; }
        public bool? NotifyNhsoApproveStatus { get; set; }
        public string PostCode { get; set; }
        public DateTime? RegisterConfirmDate { get; set; }
        public string RegistrationNumber { get; set; }
        public string RequestType { get; set; }
        public string Road { get; set; }
        public string Soi { get; set; }
        public string Step { get; set; }
        public string TaxNumber { get; set; }
        public string Tel { get; set; }
        public decimal? TypeId { get; set; }
        public string UuidChar { get; set; }
        public string Website { get; set; }
        public bool? ZoneApproveStatus { get; set; }
        public string Catm { get; set; }
        public decimal? ExistingHospital { get; set; }
        public long? FileProblemOther { get; set; }
        public string HofftypeId { get; set; }
        public string HsubtypeId { get; set; }
        public string HtypeId { get; set; }
        public string ProvinceId { get; set; }
    }
}
