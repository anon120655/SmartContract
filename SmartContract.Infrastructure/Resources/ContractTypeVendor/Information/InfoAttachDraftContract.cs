using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.ContractTypeVendor.Information
{
    /// <summary>  
    /// ข้อมูลไฟล์แนบท้าย(ร่าง)นิติกรรม
    /// </summary>
    public class InfoAttachDraftContract
    {
        public InfoAttachDraftContract()
        {
            SmctMasterFile = new List<SmctMasterFileDTO>();
        }

        public List<SmctMasterFileDTO> SmctMasterFile { get; set; }

    }
}
