using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Utils
{   
    public static class SignerTypes
    {
        /// <summary>
        /// ผู้มีอำนาจด้วยตัวเอง
        /// </summary>
        public const String AuthBySelf = "S1";
        /// <summary>
        /// ผู้รับมอบอำนาจ
        /// </summary>
        public const String AuthReceive = "S2";
    }
}
