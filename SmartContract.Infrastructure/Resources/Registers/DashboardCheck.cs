using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.Registers
{
    public class DashboardCheck
    {
        /// <summary>
        /// ยกเลิก
        /// </summary>
        public int CancelCount { get; set; }
        /// <summary>
        /// รอใช้งาน
        /// </summary>
        public int WaitUse { get; set; }
        /// <summary>
        /// ไม่ใช้งาน
        /// </summary>
        public int NotUse { get; set; }
        /// <summary>
        /// ใช้งาน
        /// </summary>
        public int Used { get; set; }

        public int SumCount()
        {
            return CancelCount + WaitUse + NotUse + Used;
        }

    }
}
