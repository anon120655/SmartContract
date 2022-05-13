using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Utils
{
    /// <summary>
    /// Contract Sation 
    /// </summary>
    public class ContractStationStatusAll
    {
        /// <summary>
        /// สร้าง(ร่าง)นิติกรรม
        /// </summary>
        public const String S1Draft = "S1";
        /// <summary>
        /// หนังสือขออนุมัติ
        /// </summary>
        public const String S2BookRequestApproval = "S2";
        /// <summary>
        /// กำหนดรหัสคู่สัญญา
        /// </summary>
        public const String S3SetVendor = "S3";
        /// <summary>
        /// สร้างนิติกรรมสัญญา
        /// </summary>
        public const String S4CreateContract = "S4";
        /// <summary>
        /// ลงนาม 2 ฝ่าย
        /// </summary>
        public const String S5Signing2 = "S5";
        /// <summary>
        /// ออกเลขที่สัญญา
        /// </summary>
        public const String S6ContractNumber = "S6";
        /// <summary>
        /// ผูกพัน
        /// </summary>
        public const String S7Binding = "S7";
        /// <summary>
        /// ยกเลิก
        /// </summary>
        public const String S8Cancel = "S8";
    }
}
