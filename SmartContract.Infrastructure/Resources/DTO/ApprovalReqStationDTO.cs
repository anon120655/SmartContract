using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.DTO
{
    public class ApprovalReqStationDTO
    {
        public ApprovalReqStationDTO()
        {
            MasterVendor = new VMasterVendorDTO();
        }

        public string IdApprovalReqStation { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public string IdSmctMaster { get; set; }
        public string IdApprovalReq { get; set; }
        public string Budgetyear { get; set; }
        public string DepartmentCode { get; set; }
        public string FRetarn { get; set; }
        public string StationStatusPrev { get; set; }
        public string StationStatusCurr { get; set; }
        public DateTime StationBeginDate { get; set; }
        public string StationBeginUser { get; set; }
        public DateTime? StationApproveDate { get; set; }
        public string StationApproveUser { get; set; }
        public string ItemStatusPrev { get; set; }
        public string ItemStatusCurr { get; set; }
        public DateTime ItemBeginDate { get; set; }
        public string ItemBeginUser { get; set; }
        public DateTime? ItemApproveDate { get; set; }
        public string ItemApproveUser { get; set; }
        public string RefId { get; set; }
        public DateTime RefDate { get; set; }
        public string ApprovalReqId { get; set; }
        public DateTime? ApprovalReqDate { get; set; }
        public string ContractName { get; set; }
        public string ContractTypeName { get; set; }
        public string CreateUserFullname { get; set; }
        public DateTime CreateUserDate { get; set; }
        public string EditUserFullname { get; set; }
        public DateTime EditUserDate { get; set; }
        public string ContractSignType { get; set; }
        public string VendorId { get; set; }
        public string VendorName { get; set; }
        public bool Used { get; set; }
        public string DepartmentName { get; set; }
        public string ContractTypeId { get; set; }
        public string ContractStyleCode { get; set; }
        public string ContractStyleFullName { get; set; }
        public string OfficerReamrk { get; set; }
        public string DirectorRemark { get; set; }
        public string StatusCheckMail { get; set; }
        public VMasterVendorDTO MasterVendor { get; set; }
    }
}
