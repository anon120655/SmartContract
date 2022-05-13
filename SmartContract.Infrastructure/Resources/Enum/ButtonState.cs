using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.Enum
{
    public enum ButtonState
    {
        Draft = 0,//ร่าง
        Forward = 1,//บันทึกส่งต่อ
        Cancel = 2,//ยกเลิกข้อมูล
        Signer = 3,//ลงนาม2ฝ่าย
        SignerWitness = 4,//พยาน
        SignerAttachFile = 41,//แนบไฟล์ฉบับจริง
        GenContractId = 5,//ออกเลขที่สัญญา
        T0_CANCEL = 70, //ยกเลิกดำเนินการ ที่ทำไว้ก่อนหน้า กรณีอยู่สถานะ(รออนุมัติ,ตีกลับแก้ไข)
        T1_EDIT = 71, //แก้ไขข้อมูลสัญญา
        T2_CANCEL = 72, //ยกเลิกข้อมูลสัญญา
        T3_EXPAND = 73, //ขยายสัญญา
        T4_CLOSEPROJECT = 74, //ปิดโครงการ
        T5_TERMINATE = 75, //ยุติสัญญา
    }
}
