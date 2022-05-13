using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Utils
{
    public static class GuaranteeTypes
    {
        /// <summary>
        /// เงินสด
        /// </summary>
        public const String Cash = "G1";
        /// <summary>
        /// แคชเชียร์เช็ค
        /// </summary>
        public const String CashierCheck = "G2";
        /// <summary>
        /// หนังสือค้ำประกัน
        /// </summary>
        public const String BookGuarantee = "G3";
        /// <summary>
        /// หักจากเงินโอนงวดที่ 1
        /// </summary>
        public const String DeductedTransfer1 = "G4";
    }
}
