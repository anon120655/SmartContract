using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Utils
{
    public static class WitnessStatusAll
    {
        /// <summary>
        /// ไม่มีพยาน
        /// </summary>
        public const String W0NotWitness = "W0";
        /// <summary>
        /// มีพยาน ยังไม่ลงนามหรือลงนามยังไม่ครบทั้งหมด
        /// </summary>
        public const String W1WitnessUnsigned = "W1";
        /// <summary>
        /// มีพยาน ลงนามครบทั้งหมด
        /// </summary>
        public const String W2WitnessComplete = "W2";
    }
}
