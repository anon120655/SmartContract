using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Utils
{
    public static class ContractStationStatusItemAll
    {
        /// <summary>
        /// บันทึกร่าง
        /// </summary>
        public const String S11Draft = "S11";
        /// <summary>
        /// บันทึกส่งต่อ
        /// </summary>
        public const String S12SaveForward = "S12";
        /// <summary>
        /// ตีกลับแก้ไข
        /// </summary>
        public const String S13Reject = "S13";
        /// <summary>
        /// ยกเลิกข้อมูล
        /// </summary>
        public const String S10Cancel = "S10";
        /// <summary>
        /// รออนุมัติ
        /// </summary>
        public const String S21WaitApproval = "S21";
        /// <summary>
        /// อนุมัติส่งต่อ
        /// </summary>
        public const String S22ApprovalForward = "S22";
        /// <summary>
        /// ตีกลับแก้ไข
        /// </summary>
        public const String S23Reject = "S23";
        /// <summary>
        /// รอกำหนดรหัส
        /// </summary>
        public const String S31WaitSetVendor = "S31";
        /// <summary>
        /// กำหนดรหัสและส่งต่อ
        /// </summary>
        public const String S31SetVendorForward = "S32";
        /// <summary>
        /// ตีกลับแก้ไข
        /// </summary>
        public const String S33Reject = "S33";
        /// <summary>
        /// รอ สปสช.เขต สร้างนิติกรรมสัญญา
        /// </summary>
        public const String S41WaitNhsoCreateContract = "S41";
        /// <summary>
        /// สปสช.เขต บันทึกส่งต่อ
        /// </summary>
        public const String S42NhsoSaveForward = "S42";
        /// <summary>
        /// สปสช.เขต ตีกลับแก้ไข
        /// </summary>
        public const String S43NhsoReject = "S43";
        /// <summary>
        /// รอลงนาม 2 ฝ่าย
        /// </summary>
        public const String S51WaitSigning2 = "S51";
        /// <summary>
        /// รอลงนามฝ่ายคู่สัญญา
        /// </summary>
        public const String S52WaitSigningVendor = "S52";
        /// <summary>
        /// รอลงนามฝ่าย สปสช
        /// </summary>
        public const String S53WaitSigningNhso = "S53";
        /// <summary>
        /// ลงนามครบ 2 ฝ่าย(ลงนาม electronic)
        /// </summary>
        public const String S54Signing2ElectronicSuccess = "S54";
        /// <summary>
        /// ลงนามครบ 2 ฝ่ายและแนบไฟล์(ฉบับจริง)(ลงนามจริงในเอกสาร)
        /// </summary>
        public const String S55Signing2PaperSuccess = "S55";
        /// <summary>
        /// รอ สปสช.ส่วนกลาง ตรวจสอบอนุมัติ
        /// </summary>
        public const String S61WaitNhsoCentralCheckApproval = "S61";
        /// <summary>
        /// สปสช.ส่วนกลาง ตรวจสอบบันทึก CheckList
        /// </summary>
        public const String S62NhsoCentralCheckList = "S62";
        /// <summary>
        /// สปสช.ส่วนกลาง อนุมัติส่งต่อ(ออกเลขที่สัญญา)
        /// </summary>
        public const String S63NhsoCentralContractId = "S63";
        /// <summary>
        /// ตีกลับแก้ไขไปที่ คู่สัญญา
        /// </summary>
        public const String S641RejectToVendor = "S641";
        /// <summary>
        /// ตีกลับแก้ไขไปที่ สปสช.เขต
        /// </summary>
        public const String S642RejectToVendorNhso = "S642";
        /// <summary>
        /// ตีกลับแก้ไขไปที่ คู่สัญญาและสปสช.เขต
        /// </summary>
        public const String S643RejectToVendorVendorNhso = "S643";
        /// <summary>
        /// ผูกพันนิติกรรมสัญญา(ลงนาม Electronic)
        /// </summary>
        public const String S71BindingElectronic = "S71";
        /// <summary>
        /// ผูกพันนิติกรรมสัญญา(ลงนามจริงในเอกสาร)
        /// </summary>
        public const String S72BindingPaper = "S72";
        /// <summary>
        /// ยกเลิกข้อมูลโดย คู่สัญญา
        /// </summary>
        public const String S81CancelVendor = "S81";
        /// <summary>
        /// ยกเลิกข้อมูลโดย สปสช.เขต
        /// </summary>
        public const String S82CancelNhso = "S82";
        /// <summary>
        /// ยกเลิกข้อมูลโดย สปสช.ส่วนกลาง
        /// </summary>
        public const String S83CancelCentral = "S83";


    }
}
