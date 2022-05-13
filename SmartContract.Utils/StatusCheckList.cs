using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Utils
{
    public class StatusCheckList
    {
        /// <summary>
        /// ยกเลิก
        /// </summary>
        public const String S0Cancel = "S0";
        /// <summary>
        /// รอตรวจสอบ
        /// </summary>
        public const String S1WaitApprove = "S1";
        /// <summary>
        /// ตีกลับ
        /// </summary>
        public const String S2UnApprove = "S2";
        /// <summary>
        /// อนุมัติ
        /// </summary>
        public const String S3Approve = "S3";
    }
}
