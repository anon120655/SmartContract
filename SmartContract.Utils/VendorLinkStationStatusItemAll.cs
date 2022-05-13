using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Utils
{
    public static class VendorLinkStationStatusItemAll
    {
        /// <summary>
        /// บันทึกร่าง
        /// </summary>
        public const String S11Draft = "S11";
        /// <summary>
        /// บันทึกส่งต่อ
        /// </summary>
        public const String S12SaveForward = "S12";
        /// <summary>
        /// ตีกลับแก้ไข
        /// </summary>
        public const String S13Reject = "S13";
        /// <summary>
        /// ยกเลิกข้อมูล
        /// </summary>
        public const String S10Cancel = "S10";
        /// <summary>
        /// รอตรวจสอบ
        /// </summary>
        public const String S21WaitCheck = "S21";
        /// <summary>
        /// ออกรหัสคู่สัญญา
        /// </summary>
        public const String S22GenVendor = "S22";
        /// <summary>
        /// ตีกลับคู่สัญญาแก้ไข
        /// </summary>
        public const String S23Reject = "S23";
        /// <summary>
        /// กำหนดรหัสคู่สัญญาสำเร็จ
        /// </summary>
        public const String S31GenVendorSuccess = "S31";
        /// <summary>
        /// ยกเลิกข้อมูลโดย คู่สัญญา
        /// </summary>
        public const String S41CancalVendor = "S41";
        /// <summary>
        /// ยกเลิกข้อมูลโดย สปสช.เขต
        /// </summary>
        public const String S41CancalVendorKet = "S42";
        /// <summary>
        /// ยกเลิกข้อมูลโดย ส่วนกลาง
        /// </summary>
        public const String S41CancalVendorCentral = "S43";
    }
}
