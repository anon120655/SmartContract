using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Utils
{
    public enum PermissionRole
    {
        /// <summary>
        /// System Admin
        /// </summary>
        SystemAdmin = 01,
        /// <summary>
        /// ผู้ดูแลระบบ ส่วนกลาง
        /// </summary>
        CentralAdmin = 02,
        /// <summary>
        /// ผู้ใช้งานทั่วไป ส่วนกลาง
        /// </summary>
        CentralUser = 03,
        /// <summary>
        /// ผู้มีอำนาจ สำนัก/กองทุนย่อย/เขต
        /// </summary>
        KetSigner = 04,
        /// <summary>
        /// เจ้าหน้าที่ สำนัก/กองทุนย่อย/เขต
        /// </summary>
        KetOfficer = 05,
        /// <summary>
        /// ผู้มีอำนาจ
        /// </summary>
        Signer1 = 06,
        /// <summary>
        /// ผู้รับมอบอำนาจ
        /// </summary>
        Signer2 = 07,
        /// <summary>
        /// ผู้ประสาน
        /// </summary>
        Coordinator = 08,
        /// <summary>
        /// ผู้ใช้งานทั่วไป
        /// </summary>
        User = 09
    }
}
