using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Utils
{
    public static class ApprovalReqStatus
    {
        /// <summary>
        /// ยกเลิก
        /// </summary>
        public const String S0Cancel = "S0";
        /// <summary>
        /// รออนุมัติ
        /// </summary>
        public const String S1WaitApprove = "S1";
        /// <summary>
        /// ไม่อนุมัติ/ตีกลับ
        /// </summary>
        public const String S2UnApprove = "S2";
        /// <summary>
        /// อนุมัติ
        /// </summary>
        public const String S3Approve = "S3";

    }
}
