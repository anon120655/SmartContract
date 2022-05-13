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
    /// ข้อมูลฝ่ายคู่สัญญา
    /// </summary>
    public class InfoPartnersOfContract
    {
        public InfoPartnersOfContract()
        {
            SmctMasterSigner = new SmctMasterSignerDTO();
        }

        /// <summary>
        /// รายละเอียดคู่สัญญา
        /// </summary>
        //รหัสคู่สัญญา
        public string VendorId { get; set; }
        //ชื่อคู่สัญญา
        public string VendorName { get; set; }
        public CATMModel CATMs { get; set; }
        public string Moo { get; set; }
        public string ZipCpde { get; set; }
        public string TelephoneNumber { get; set; }
        public string TaxNumber { get; set; }
        public string VillageNo { get; set; }
        public string Building { get; set; }
        public string Soi { get; set; }
        public string Road { get; set; }
        public string TaxId { get; set; }


        public SmctMasterSignerDTO SmctMasterSigner { get; set; }
    }
}
