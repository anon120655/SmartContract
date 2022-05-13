using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.DTO
{
    public class ContractStationGuaranteeDTO
    {
        public string IdContractStationGuarantee { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public string IdSmctMaster { get; set; }
        public string IdContract { get; set; }
        public string Budgetyear { get; set; }
        public string DepartmentCode { get; set; }
        public string FVendorlink { get; set; }
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
        public string ContractSignType { get; set; }
        public string ContractId { get; set; }
        public DateTime? ContractDate { get; set; }
        public string ContractName { get; set; }
        public string ContractTypeName { get; set; }
        public string CreateUserFullname { get; set; }
        public DateTime CreateUserDate { get; set; }
        public string EditUserFullname { get; set; }
        public DateTime EditUserDate { get; set; }
        public string VendorId { get; set; }
        public string VendorName { get; set; }
        public bool Used { get; set; }
        public string DepartmentName { get; set; }
        public string ContractTypeId { get; set; }
        public string ContractStyleCode { get; set; }
        public string ContractStyleFullName { get; set; }
        public string KetRemark { get; set; }
        public string SbbRemark { get; set; }
        public string ContractGuaranteeType { get; set; }
        public string ContractGuaranteeStatus { get; set; }
        public string ContractGuaranteeRemark { get; set; }
        public string ContractGuaranteeFFile { get; set; }
        public string ContractGuaranteeCreateUser { get; set; }
        public DateTime ContractGuaranteeCreateDate { get; set; }
        public string ContractGuaranteeEditUser { get; set; }
        public DateTime ContractGuaranteeEditDate { get; set; }
        public string ContractGuaranteeRemarkKet { get; set; }
        public string ContractStatus { get; set; }
    }
}
