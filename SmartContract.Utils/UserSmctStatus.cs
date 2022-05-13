using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Utils
{
    public static class UserSmctStatus
    {
        /// <summary>
        /// ยกเลิก
        /// </summary>
        public const String Cancel = "S0";
        /// <summary>
        /// รอใช้งาน
        /// </summary>
        public const String WaitUse = "S1";
        /// <summary>
        /// ไม่ใช้งาน
        /// </summary>
        public const String NotUse = "S2";
        /// <summary>
        /// ใช้งาน
        /// </summary>
        public const String Used = "S3";

    }
}
