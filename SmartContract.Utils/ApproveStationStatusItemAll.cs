using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Utils
{
    public class ApproveStationStatusItemAll
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
        /// ถูกตีกลับแก้ไข
        /// </summary>
        public const String S13Reject = "S13";
        /// <summary>
        /// ยกเลิกข้อมูล
        /// </summary>
        public const String S10Cancel = "S10";
        /// <summary>
        /// รอสร้างหนังสือขออนุมัติ
        /// </summary>
        public const String S21WaitBookRequestApproval = "S21";
        /// <summary>
        /// บันทึกส่งต่อขออนุมัติ
        /// </summary>
        public const String S22SaveForwardApproval = "S22";
        /// <summary>
        /// ตีกลับแก้ไข
        /// </summary>
        public const String S23Reject = "S23";
        /// <summary>
        /// รออนุมัติ
        /// </summary>
        public const String S31WaitApproval = "S31";
        /// <summary>
        /// อนุมัติ
        /// </summary>
        public const String S32Approval = "S32";
        /// <summary>
        /// ตีกลับแก้ไข
        /// </summary>
        public const String S33Reject = "S33";
        /// <summary>
        /// อนุมัติ
        /// </summary>
        public const String S41Approve = "S41";
        /// <summary>
        /// ยกเลิกข้อมูลโดย คู่สัญญา
        /// </summary>
        public const String S51CancelVendor = "S51";
        /// <summary>
        /// ยกเลิกข้อมูลโดย สปสช.เขต
        /// </summary>
        public const String S52CancelNhso = "S52";
        /// <summary>
        /// ยกเลิกข้อมูลโดย สปสช.ส่วนกลาง
        /// </summary>
        public const String S53CancelCentral = "S53";
    }
}
