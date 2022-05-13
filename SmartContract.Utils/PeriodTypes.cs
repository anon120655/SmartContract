using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Utils
{
    public static class PeriodTypes
    {
        /// <summary>
        /// P1 = จ่ายงวดเดียว 100%
        /// </summary>
        public const String PayOne100 = "P1";
        /// <summary>
        /// P2 = งวดเดียวตัดจ่ายหลายครั้ง(มี 1 งวด แต่หลาย row)
        /// </summary>
        public const String PayOneMutiRow = "P2";
        /// <summary>
        /// P3 = ตัดจ่ายหลายงวด (มีงวดที่ 1 - n)
        /// </summary>
        public const String PayMutiToN = "P3";
    }
}
