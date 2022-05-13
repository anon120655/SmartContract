using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.DTO
{
    public class ContractSbbCklDTO
    {
        public ContractSbbCklDTO()
        {
            ContractSbbCklDetails = new List<ContractSbbCklDetailDTO>();
        }

        public string IdContractSbbCkl { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public bool Used { get; set; }
        public string IdContract { get; set; }
        public string ChecklistId { get; set; }
        public DateTime ChecklistDate { get; set; }
        public string ChecklistUser { get; set; }
        public string ChecklistUserFullname { get; set; }
        public string Remark { get; set; }
        public string Status { get; set; }
        public List<ContractSbbCklDetailDTO> ContractSbbCklDetails { get; set; }
    }
}
