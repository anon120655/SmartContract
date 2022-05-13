using SmartContract.Infrastructure.Resources.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.ContractTypeVendor.Information
{
    /// <summary>  
    /// ข้อมูลขออนุมัติดำเนินการ
    /// </summary>
    public class InfoRequestForApproval
    {
        public InfoRequestForApproval()
        {
            Committees = new List<VNhsoBoradDTO>();
        }

        //ชื่อโครงการ
        public string ContractName { get; set; }
        //เหตุผลความจำเป็น
        public string Reason { get; set; }
        //เลขที่หนังสือขออนุมัติดำเนินการ
        public string ApprovalReqId { get; set; }
        //วันที่หนังสือขออนุมัติดำเนินการ
        public DateTime? ApprovalReqDate { get; set; }
        public string ApprovalReqDateStr { get; set; }
        //ผู้ประสานงาน
        public string CoordinatorUserSelect { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        /// <summary>
        /// ประธานกรรมการ
        /// </summary>
        public string ApprovalReqUserChairm { get; set; }

        /// <summary>
        /// คณะกรรมการ
        /// </summary>
        public List<VNhsoBoradDTO> Committees { get; set; }
        /// <summary>
        /// ลงชื่อผู้ขออนุมัติ
        /// </summary>
        public string ApprovalReqUser { get; set; }
        /// <summary>
        /// ตำแหน่ง
        /// </summary>
        public string ApprovalReqUserPos { get; set; }

    }
}
