using SmartContract.Infrastructure.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.ContractTypeBureau.Information
{
    /// <summary>
    /// ข้อมูลฝ่าย สปสช.
    /// </summary>
    public class InfoContractNhso
    {
        public InfoContractNhso()
        {

        }

        public VNhsoDepartmentAddress NhsoAddress { get; set; }
        /// <summary>
        /// ผู้มีอำนาจลงนาม สปสช
        /// </summary>
        public string EmpId { get; set; }
        public string SignerPosition { get; set; }
        public string SignerEmail { get; set; }
        public string NhsoWitnessStatus { get; set; }
        public string VendorWitnessStatus { get; set; }

        //คำสั่งสำนักงานหลักประกันสุขภาพแห่งชาติ ที่
        public string NhsoContractId { get; set; }
        public DateTime? NhsoContractDate { get; set; }
        public string NhsoContractDateStr { get; set; }

    }
}
