using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.DTO
{
	public class GuaranteeLgReqDTO
    {
        public string IdGuaranteeLgReq { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public bool Used { get; set; }
        public string IdSmctMaster { get; set; }
        public string ChannelId { get; set; }
        public string BeneficiaryRefNo { get; set; }
        public string TransDate { get; set; }
        public string TransTime { get; set; }
        public string AppTypeId { get; set; }
        public string TaxId { get; set; }
        public string RequesterNameTh { get; set; }
        public string EffectiveDateStart { get; set; }
        public string EffectiveDateEnd { get; set; }
        public string LgNumber { get; set; }
        public decimal? LgAmount { get; set; }
        public string GuaranteeTypeId { get; set; }
        public string ContractTypeId { get; set; }
        public string ContractNo { get; set; }
        public string ContractDate { get; set; }
        public string ContractDetail { get; set; }
        public string Comments { get; set; }
        public string Email { get; set; }
        public string Sms { get; set; }
        public string LgStatus { get; set; }
        public string HospitalCode { get; set; }
        public string HospitalName { get; set; }
        public string LastupdateDate { get; set; }
        public string LastupdateTime { get; set; }
        public decimal? LgAmountInitial { get; set; }
    }
}
