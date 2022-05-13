using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Utils
{
    public class ContractSuccessTypes
    {
        /// <summary>
        /// ข้อมูลสถานะปกติ
        /// </summary>
        public const String TA_NORMAL = "TA";
        /// <summary>
        /// แก้ไขข้อมูลสัญญา
        /// </summary>
        public const String T1_EDIT = "T1";
        /// <summary>
        /// ยกเลิกข้อมูลสัญญา
        /// </summary>
        public const String T2_CANCEL = "T2";
        /// <summary>
        /// ขยายสัญญา
        /// </summary>
        public const String T3_EXPAND = "T3";
        /// <summary>
        /// ปิดโครงการ
        /// </summary>
        public const String T4_CLOSEPROJECT = "T4";
        /// <summary>
        /// ยุติสัญญา
        /// </summary>
        public const String T5_TERMINATE = "T5";
    }
}
