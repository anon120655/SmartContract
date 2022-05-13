using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Utils
{
    public static class GuaranteeFormatTypes
    {
        /// <summary>
        /// มีหลักประกัน : หักจากงวดที่1
        /// </summary>
        public const String HaveGuaranteeY1 = "T1";
        /// <summary>
        /// มีหลักประกัน : ไม่หักจากงวดที่1
        /// </summary>
        public const String HaveGuaranteeN1 = "T2";
        /// <summary>
        /// ยกเว้นหลักประกันสัญญา
        /// </summary>
        public const String Except = "T3";
    }
}
