using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.ContractTypeVendor.Information
{
    /// <summary>  
    /// ข้อมูลผู้ลงนาม
    /// </summary>
    public class InfoSignerPartnersOfContract
    {
        public InfoSignerPartnersOfContract()
        {
            FootNotes = new List<FootNoteModel>();
            FootNotesNhso = new List<FootNoteNhsoModel>();
        }

        //ผู้มีอำนาจลงนาม (คู่สัญญา)
        public string VendorSignerUser { get; set; }
        public string VendorSignerUserFullName { get; set; }
        //พยาน (ฝ่ายคู่สัญญา)
        public string VendorWitnessUser { get; set; }
        public string VendorWitnessStatus { get; set; }
        //Foot Note (ฝ่ายคู่สัญญา) 
        public List<FootNoteModel> FootNotes { get; set; }


        //ผู้มีอำนาจลงนาม (ฝ่ายสำนักงาน) 
        public string NhsoSignerUser { get; set; }
        //พยาน (ฝ่ายสำนักงาน) 
        public string NhsoWitnessUser { get; set; }
        public string NhsoWitnessStatus { get; set; }
        //Foot Note (ฝ่ายสำนักงาน)
        public List<FootNoteNhsoModel> FootNotesNhso { get; set; }

        public class FootNoteModel
        {
            public string IdUserSmct { get; set; }
            public string UserFullname { get; set; }
        }

        public class FootNoteNhsoModel
        {
            public string EmpId { get; set; }
            public string SignerFullname { get; set; }
        }

    }

   
}
