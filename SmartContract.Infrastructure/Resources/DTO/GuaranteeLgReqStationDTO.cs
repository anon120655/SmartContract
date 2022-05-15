using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.DTO
{
	public class GuaranteeLgReqStationDTO
	{
        public string IdGuaranteeLgReqStation { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public bool Used { get; set; }
        public string IdSmctMaster { get; set; }
        public string IdContract { get; set; }
        public string IdGuaranteeLgReq { get; set; }
        public string AppTypeId { get; set; }
        public string Budgetyear { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string RefId { get; set; }
        public DateTime RefDate { get; set; }
        public string ContractId { get; set; }
        public DateTime ContractDate { get; set; }
        public string ContractName { get; set; }
        public string ContractTypeName { get; set; }
        public string TaxId { get; set; }
        public string RequesterNameTh { get; set; }
        public string LgNumber { get; set; }
        public string EffectiveDateStart { get; set; }
        public string EffectiveDateEnd { get; set; }
        public decimal? LgAmount { get; set; }
        public string GuaranteeTypeId { get; set; }
        public string GuaranteeTypeDesc { get; set; }
        public string ContractTypeId { get; set; }
        public string ContractTypeDesc { get; set; }
        public decimal? LgAmountInitial { get; set; }
        public string LgStatus { get; set; }
    }
}
