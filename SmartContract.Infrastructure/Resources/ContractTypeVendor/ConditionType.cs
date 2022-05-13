using SmartContract.Infrastructure.Resources.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.ContractTypeVendor
{
    /// <summary>  
    ///  เงื่อนไขการสร้าง(ร่าง)นิติกรรม
    /// </summary>
    public class ConditionType
    {
        public ConditionType()
        {

        }

        //สำนัก/กองทุนย่อย/เขต
        public string BureauSubFundCounty { get; set; }
        //คู่สัญญา
        public string ContractTypeSelected { get; set; }
        public string ContractIdSelected { get; set; }
        //รูปแบบการลงนาม (Electronic,กระดาษ)
        public bool SigningElectronic { get; set; }
        public bool SigningPaper { get; set; }
        //รหัสคู่สัญญา
        public bool CounterpartyCodeD { get; set; }
        public bool CounterpartyCodeN { get; set; }
    }
}
