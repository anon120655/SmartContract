using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Utils
{
    /// <summary>
    /// VendorLink Sation 
    /// </summary>
    public class VendorLinkStationStatusAll
    {
        /// <summary>
        /// สร้างข้อเสนอ
        /// </summary>
        public const String S1CreateProposal = "S1";
        /// <summary>
        /// ตรวจสอบ
        /// </summary>
        public const String S2Check = "S2";
        /// <summary>
        /// รหัสคู่สัญญา(สำเร็จ)
        /// </summary>
        public const String S3VendorSuccess = "S3";
        /// <summary>
        /// ยกเลิก
        /// </summary>
        public const String S4Cancel = "S4";
    }
}
