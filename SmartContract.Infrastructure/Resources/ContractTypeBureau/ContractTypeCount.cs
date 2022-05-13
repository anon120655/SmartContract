using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.ContractTypeBureau
{
    public class ContractTypeCount
    {
        /// <summary>
        /// สัญญา
        /// </summary>
        public int ContractType1 { get; set; }
        /// <summary>
        /// ข้อตกลง
        /// </summary>
        public int ContractType2 { get; set; }
        /// <summary>
        /// หนังสือแสดงความจำนง
        /// </summary>
        public int ContractType3 { get; set; }
        /// <summary>
        /// โครงการ
        /// </summary>
        public int ContractType4 { get; set; }

        public int SumContractTypeCount()
        {
            return ContractType1 + ContractType2 + ContractType3 + ContractType4;
        }

    }
}
