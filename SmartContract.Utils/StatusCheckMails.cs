using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Utils
{
    public class StatusCheckMails
    {
        /// <summary>
        /// ส่งเมลผู้ขออนุมัติ
        /// </summary>
        public const String M11SentMail = "M11";
        /// <summary>
        /// ส่งเมลผู้ขออนุมัติสำเร็จ
        /// </summary>
        public const String M12SentMail = "M12";
        /// <summary>
        /// ส่งเมลผู้อนุมัติ(ผอ.)
        /// </summary>
        public const String M21SentMail = "M21";
        /// <summary>
        /// ส่งเมลผู้อนุมัติ(ผอ.)สำเร็จ
        /// </summary>
        public const String M22SentMail = "M22";
    }
}
