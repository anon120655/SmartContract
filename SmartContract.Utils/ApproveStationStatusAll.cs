using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Utils
{
    /// <summary>
    /// สถานะหนังสือขออนุมัติ
    /// </summary>
    public static class ApproveStationStatusAll
    {
        /// <summary>
        /// สร้างข้อเสนอ
        /// </summary>
        public const String S1CreateProposal = "S1";
        /// <summary>
        /// สร้างหนังสือขออนุมัติ
        /// </summary>
        public const String S2CreateApprove = "S2";
        /// <summary>
        /// พิจารณา(ผอ.)
        /// </summary>
        public const String S3Consider = "S3";
        /// <summary>
        /// อนุมัติ
        /// </summary>
        public const String S4Approve = "S4";
        /// <summary>
        /// ยกเลิก
        /// </summary>
        public const String S5Cancel = "S5";
    }
}
