using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Utils
{
    public class ContractGuaranteeTypes
    {
        /// <summary>
        /// ออกใหม่
        /// </summary>
        public const String T1_NEW = "T1";
        /// <summary>
        /// ต่ออายุ
        /// </summary>
        public const String T2_RENEW = "T2";
        /// <summary>
        /// คืน
        /// </summary>
        public const String T3_RETURN = "T3";
        /// <summary>
        /// คลม/ยึด
        /// </summary>
        public const String T4_CLAIM = "T4";      
    }
}
