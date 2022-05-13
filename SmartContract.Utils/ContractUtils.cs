using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Utils
{
    public static class ContractUtils
    {
        public static ContractPropertiesModel PropertiesVendor(String _Style)
        {
            var Properties = new List<ContractPropertiesModel>()
            {
                new ContractPropertiesModel()
                {
                    Style ="S1",
                    Name = "สัญญาให้บริการสาธารณสุขฯ",
                    Color = "#ffcd56cc"
                },
                 new ContractPropertiesModel()
                {
                    Style ="S2",
                    Name = "สัญญาให้บริการฯตามกิจกรรมบริการ",
                    Color = "#36a2ebcc"
                },
                 new ContractPropertiesModel()
                {
                    Style ="S41",
                    Name = "สัญญาดำเนินการตามโครงการ",
                    Color = "#ff6384cc"
                },
                 new ContractPropertiesModel()
                {
                    Style ="S42",
                    Name = "หนังสือแสดงความจำนงตอบรับการดำเนินการ",
                    Color = "#ee82eecc"
                }
            };

            return Properties.Where(x => x.Style == _Style).Select(x => x).FirstOrDefault();
        }

        public static ContractPropertiesModel PropertiesVendor2(String _Style)
        {
            var Properties = new List<ContractPropertiesModel>()
            {
                new ContractPropertiesModel()
                {
                    Style ="S1",
                    Name = "ข้อตกลงให้บริการสาธารณสุขฯ",
                    Color = "#ffcd56cc"
                },
                 new ContractPropertiesModel()
                {
                    Style ="S2",
                    Name = "ข้อตกลงให้บริการฯตามกิจกรรมบริการ",
                    Color = "#36a2ebcc"
                },
                 new ContractPropertiesModel()
                {
                    Style ="S3",
                    Name = "ข้อตกลง อปท.",
                    Color = "#7fffd4"
                },
                 new ContractPropertiesModel()
                {
                    Style ="S41",
                    Name = "ข้อตกลงดำเนินการตามโครงการ",
                    Color = "#ff6384cc"
                },
                 new ContractPropertiesModel()
                {
                    Style ="S42",
                    Name = "หนังสือแสดงความจำนงตอบรับการดำเนินการ",
                    Color = "#ee82eecc"
                },
                 new ContractPropertiesModel()
                {
                    Style ="S43",
                    Name = "โครงการ",
                    Color = "#ffa05c"
                }
            };

            return Properties.Where(x => x.Style == _Style).Select(x => x).FirstOrDefault();
        }

        public static SmctStatusProperties SmctStatusProperties(String _Status)
        {
            var Properties = new List<SmctStatusProperties>()
            {
                new SmctStatusProperties()
                {
                    Status ="S0",
                    Name = "ยกเลิก"
                },
                 new SmctStatusProperties()
                {
                    Status ="S1",
                    Name = "รอใช้งาน",
                    Description = "รอใช้งาน"
                },
                 new SmctStatusProperties()
                {
                    Status ="S2",
                    Name = "ไม่อนุมัติ",
                    Description = "ไม่อนุมัติ/ตีกลับ"
                },
                 new SmctStatusProperties()
                {
                     Status ="S3",
                    Name = "ใช้งาน",
                    Description = "อนุมัติ"
                }
            };

            return Properties.Where(x => x.Status == _Status).Select(x => x).FirstOrDefault();
        }

        public static Dictionary<string, string> ConditionContractType()
        {
            return new Dictionary<string, string>(){
                    {"S1", "T01"},
                    {"S2", "T13"},
                    {"S41", "T11"}, //03 -> 11
                    {"S42", "T15"}
                };
        }

        public static Dictionary<string, string> ConditionContractType2()
        {
            return new Dictionary<string, string>(){
                    {"S1", "T02"},
                    {"S2", "T16"},
                    {"S3", "T18"},
                    {"S41", "T04"},
                    {"S42", "T15"},
                    {"S43", "T20"}
                };
        }

        public static SigningTypesModel SigningTypes(String _Type)
        {
            var Properties = new List<SigningTypesModel>()
            {
                new SigningTypesModel()
                {
                    Type ="E",
                    Name = "Electronic",
                    Description = "ลงนาม Electronic"
                },
                 new SigningTypesModel()
                {
                    Type ="P",
                    Name = "Paper",
                    Description = "ลงนามจริงในเอกสาร"
                }
            };

            return Properties.Where(x => x.Type == _Type).Select(x => x).FirstOrDefault();
        }

        public static SigningTypesModel SignerTypes(String _Type)
        {
            var Properties = new List<SigningTypesModel>()
            {
                new SigningTypesModel()
                {
                    Type ="S1",
                    Name = "AuthBySelf",
                    Description = "ผู้มีอำนาจด้วยตัวเอง"
                },
                 new SigningTypesModel()
                {
                    Type ="S2",
                    Name = "AuthReceive",
                    Description = "ผู้รับมอบอำนาจ"
                }
            };

            return Properties.Where(x => x.Type == _Type).Select(x => x).FirstOrDefault();
        }

        public static ContractSationProperties ApproveReqSations(String _Status, String Item = null)
        {
            var Properties = new List<ContractSationProperties>()
            {
                new ContractSationProperties()
                {
                    Status ="S1",
                    Name = "สร้างข้อเสนอ",
                    Color = "#ffc107",
                    SationItem = new List<ContractSationItemProperties>(){
                        new ContractSationItemProperties()
                        {
                            Status ="S11",
                            Name = "บันทึกร่าง"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S12",
                            Name = "บันทึกส่งต่อ"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S13",
                            Name = "ตีกลับแก้ไข"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S10",
                            Name = "ยกเลิกข้อมูล"
                        }
                    }
                },
                 new ContractSationProperties()
                {
                    Status ="S2",
                    Name = "สร้างหนังสือ<br />ขออนุมัติ",
                    Color = "#17a2b8",
                    SationItem = new List<ContractSationItemProperties>(){
                        new ContractSationItemProperties()
                        {
                            Status ="S21",
                            Name = "รอสร้างหนังสือขออนุมัติ"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S22",
                            Name = "บันทึกส่งต่อขออนุมัติ"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S23",
                            Name = "ตีกลับแก้ไข"
                        }
                    }
                },
                 new ContractSationProperties()
                {
                    Status ="S3",
                    Name = "พิจารณา(ผอ.)",
                    Color = "#007bff",
                    SationItem = new List<ContractSationItemProperties>(){
                        new ContractSationItemProperties()
                        {
                            Status ="S31",
                            Name = "รออนุมัติ"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S32",
                            Name = "อนุมัติ"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S33",
                            Name = "ตีกลับแก้ไข"
                        }
                    }
                },
                 new ContractSationProperties()
                {
                    Status ="S4",
                    Name = "อนุมัติ",
                    Color = "#28a745",
                    SationItem = new List<ContractSationItemProperties>(){
                        new ContractSationItemProperties()
                        {
                            Status ="S41",
                            Name = "อนุมัติ"
                        }
                    }
                },
                 new ContractSationProperties()
                {
                    Status ="S5",
                    Name = "ยกเลิก",
                    Color = "#17a2b8",
                    SationItem = new List<ContractSationItemProperties>(){
                        new ContractSationItemProperties()
                        {
                            Status ="S51",
                            Name = "ยกเลิกข้อมูลโดย คู่สัญญา"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S52",
                            Name = "ยกเลิกข้อมูลโดย สปสช.เขต"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S53",
                            Name = "ยกเลิกข้อมูลโดย สปสช.ส่วนกลาง"
                        }
                    }
                },

            };

            return Properties.Where(x => x.Status == _Status).Select(x => x).FirstOrDefault();
        }

        public static ContractSationProperties VendorLinkReqSations(String _Status, String Item = null)
        {
            var Properties = new List<ContractSationProperties>()
            {
                new ContractSationProperties()
                {
                    Status ="S1",
                    Name = "สร้างข้อเสนอ",
                    Color = "#ffc107",
                    SationItem = new List<ContractSationItemProperties>(){
                        new ContractSationItemProperties()
                        {
                            Status ="S11",
                            Name = "บันทึกร่าง"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S12",
                            Name = "บันทึกส่งต่อ"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S13",
                            Name = "ตีกลับแก้ไข"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S10",
                            Name = "ยกเลิกข้อมูล"
                        }
                    }
                },
                new ContractSationProperties()
                {
                    Status ="S2",
                    Name = "ตรวจสอบ",
                    Color = "#17a2b8",
                    SationItem = new List<ContractSationItemProperties>(){
                        new ContractSationItemProperties()
                        {
                            Status ="S21",
                            Name = "รอตรวจสอบ"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S22",
                            Name = "ออกรหัสคู่สัญญา"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S23",
                            Name = "ตีกลับคู่สัญญาแก้ไข"
                        }
                    }
                },
                new ContractSationProperties()
                {
                    Status ="S3",
                    Name = "รหัสคู่สัญญา(สำเร็จ)",
                    Color = "#28a745",
                    SationItem = new List<ContractSationItemProperties>(){
                        new ContractSationItemProperties()
                        {
                            Status ="S31",
                            Name = "กำหนดรหัสคู่สัญญาสำเร็จ"
                        }
                    }
                },
                new ContractSationProperties()
                {
                    Status ="S4",
                    Name = "ยกเลิก",
                    Color = "#17a2b8",
                    SationItem = new List<ContractSationItemProperties>(){
                        new ContractSationItemProperties()
                        {
                            Status ="S41",
                            Name = "ยกเลิกข้อมูลโดย คู่สัญญา"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S42",
                            Name = "ยกเลิกข้อมูลโดย สปสช.เขต"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S43",
                            Name = "ยกเลิกข้อมูลโดย สปสช.ส่วนกลาง"
                        }
                    }
                },

            };

            return Properties.Where(x => x.Status == _Status).Select(x => x).FirstOrDefault();
        }

        public static ContractSationProperties ContractSations(String _Status, String Item = null)
        {
            var Properties = new List<ContractSationProperties>()
            {
                new ContractSationProperties()
                {
                    Status ="S1",
                    Name = "สร้าง(ร่าง)นิติกรรม",
                    Color = "#ffc107",
                    SationItem = new List<ContractSationItemProperties>(){
                        new ContractSationItemProperties()
                        {
                            Status ="S11",
                            Name = "บันทึกร่าง"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S12",
                            Name = "บันทึกส่งต่อ"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S13",
                            Name = "ตีกลับแก้ไข"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S10",
                            Name = "ยกเลิกข้อมูล"
                        }
                    }
                },
                 new ContractSationProperties()
                {
                    Status ="S2",
                    Name = "หนังสือขออนุมัติ",
                    Color = "#28a745",
                    SationItem = new List<ContractSationItemProperties>(){
                        new ContractSationItemProperties()
                        {
                            Status ="S21",
                            Name = "รออนุมัติ"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S22",
                            Name = "อนุมัติส่งต่อ"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S23",
                            Name = "ตีกลับแก้ไข"
                        }
                    }
                },
                 new ContractSationProperties()
                {
                    Status ="S3",
                    Name = "กำหนดรหัสคู่สัญญา",
                    Color = "#ff4ad0fa",
                    SationItem = new List<ContractSationItemProperties>(){
                        new ContractSationItemProperties()
                        {
                            Status ="S31",
                            Name = "รอกำหนดรหัส"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S32",
                            Name = "กำหนดรหัสและส่งต่อ"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S33",
                            Name = "ตีกลับแก้ไข"
                        }
                    }
                },
                 new ContractSationProperties()
                {
                    Status ="S4",
                    Name = "สร้างนิติกรรมสัญญา",
                    Color = "#17a2b8",
                    SationItem = new List<ContractSationItemProperties>(){
                        new ContractSationItemProperties()
                        {
                            Status ="S41",
                            Name = "รอ สปสช.เขต สร้างนิติกรรมสัญญา"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S42",
                            Name = "สปสช.เขต บันทึกส่งต่อ"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S43",
                            Name = "สปสช.เขต ตีกลับแก้ไข"
                        }
                    }
                },
                 new ContractSationProperties()
                {
                     Status ="S5",
                    Name = "ลงนาม 2 ฝ่าย",
                    Color = "#343a40",
                    SationItem = new List<ContractSationItemProperties>(){
                        new ContractSationItemProperties()
                        {
                            Status ="S51",
                            Name = "รอลงนาม 2 ฝ่าย"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S52",
                            Name = "รอลงนามฝ่ายคู่สัญญา"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S53",
                            Name = "รอลงนามฝ่าย สปสช"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S54",
                            Name = "ลงนามครบ 2 ฝ่าย"
                        }
                    }
                },
                 new ContractSationProperties()
                {
                    Status ="S6",
                    Name = "ออกเลขที่สัญญา",
                    Description = "ออกเลขที่สัญญา",
                    Color = "#007bff",
                    SationItem = new List<ContractSationItemProperties>(){
                        new ContractSationItemProperties()
                        {
                            Status ="S61",
                            Name = "รอ สปสช.ส่วนกลาง ตรวจสอบอนุมัติ"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S62",
                            Name = "สปสช.ส่วนกลาง ตรวจสอบบันทึก CheckList"
                        }, new ContractSationItemProperties()
                        {
                            Status ="S63",
                            Name = "สปสช.ส่วนกลาง อนุมัติส่งต่อ(แนบไฟล์/ออกเลขที่สัญญา)"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S641",
                            Name = "ตีกลับแก้ไขไปที่ คู่สัญญา"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S642",
                            Name = "ตีกลับแก้ไขไปที่ สปสช.เขต"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S643",
                            Name = "ตีกลับแก้ไขไปที่ คู่สัญญาและสปสช.เขต"
                        }
                    }
                }, new ContractSationProperties()
                {
                    Status ="S7",
                    Name = "ผูกพัน",
                    Description = "ผูกพัน",
                    Color = "#0fd03c",
                    SationItem = new List<ContractSationItemProperties>(){
                        new ContractSationItemProperties()
                        {
                            Status ="S71",
                            Name = "ผูกพันนิติกรรมสัญญา(ลงนาม Electronic)"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S72",
                            Name = "ผูกพันนิติกรรมสัญญา(ลงนามจริงในเอกสาร)"
                        }
                    }
                },
                 new ContractSationProperties()
                {
                     Status ="S8",
                    Name = "ยกเลิก",
                    Description = "ยกเลิก",
                    Color = "#dc3545",
                    SationItem = new List<ContractSationItemProperties>(){
                        new ContractSationItemProperties()
                        {
                            Status ="S81",
                            Name = "ยกเลิกข้อมูลโดย คู่สัญญา"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S82",
                            Name = "ยกเลิกข้อมูลโดย สปสช.เขต"
                        },
                        new ContractSationItemProperties()
                        {
                            Status ="S83",
                            Name = "ยกเลิกข้อมูลโดย สปสช.ส่วนกลาง"
                        }
                    }
                }
            };

            return Properties.Where(x => x.Status == _Status).Select(x => x).FirstOrDefault();
        }

        public static IndexBindingPropertites BindingPropertite(String _Code)
        {
            var Properties = new List<IndexBindingPropertites>()
            {
                new IndexBindingPropertites()
                {
                    Code = ContractSuccessTypes.T1_EDIT,
                    MenuFullName ="แก้ไขข้อมูลสัญญา",
                    ButtonName = "บันทึกแก้ไข",
                    Color = "#fea266",
                    ButtonState = 71
                },
                 new IndexBindingPropertites()
                {
                    Code = ContractSuccessTypes.T2_CANCEL,
                    MenuFullName ="ยกเลิกข้อมูลสัญญา",
                    ButtonName = "บันทึกยกเลิก",
                    Color = "#fcacac",
                    ButtonState = 72
                },
                 new IndexBindingPropertites()
                {
                    Code = ContractSuccessTypes.T3_EXPAND,
                    MenuFullName ="ขยายสัญญา",
                    ButtonName = "บันทึกขยายสัญญา",
                    Color = "#81bcfc",
                    ButtonState = 73
                },
                 new IndexBindingPropertites()
                {
                    Code = ContractSuccessTypes.T4_CLOSEPROJECT,
                    MenuFullName ="ปิดโครงการ",
                    ButtonName = "บันทึกปิดโครงการ",
                    Color = "#fcbdc3",
                    ButtonState = 74
                },
                 new IndexBindingPropertites()
                {
                    Code = ContractSuccessTypes.T5_TERMINATE,
                    MenuFullName ="ยุติสัญญา",
                    ButtonName = "บันทึกยุติสัญญา",
                    Color = "#fcbdc3",
                    ButtonState = 75
                }
            };

            return Properties.Where(x => x.Code == _Code).Select(x => x).FirstOrDefault();

        }

        public static SmctStatusProperties StatusBindingPropertites(String _Status)
        {
            var Properties = new List<SmctStatusProperties>()
            {
                new SmctStatusProperties()
                {
                    Status ="S0",
                    Name = "ยกเลิก",
                    Name2 = "ยกเลิก",
                    Color ="#343a40",
                    Color2 ="#343a40"
                },
                 new SmctStatusProperties()
                {
                    Status ="S1",
                    Name = "รออนุมัติ",
                    Name2 = "รอดำเนินการ",
                    Color ="#ffc107",
                    Color2 ="#ffa707"
                },
                 new SmctStatusProperties()
                {
                    Status ="S2",
                    Name = "ไม่อนุมัติ",
                    Name2 = "ไม่อนุมัติ",
                    Color ="#dc3545",
                    Color2 ="#dc3545"
                },
                 new SmctStatusProperties()
                {
                    Status ="S3",
                    Name = "อนุมัติ",
                    Name2 = "อนุมัติ",
                    Color ="#28a745",
                    Color2 ="#28a745"
                }
            };

            return Properties.Where(x => x.Status == _Status).Select(x => x).FirstOrDefault();
        }

        public static IndexBindingPropertites GuaranteePropertite(String _Code)
        {
            var Properties = new List<IndexBindingPropertites>()
            {
                new IndexBindingPropertites()
                {
                    Code = ContractGuaranteeTypes.T1_NEW,
                    MenuFullName ="หน้าติดตาม",
                    ButtonName = "บันทึกออกใหม่",
                    Color = "#fea266",
                    ButtonState = 71
                },
                 new IndexBindingPropertites()
                {
                    Code = ContractGuaranteeTypes.T2_RENEW,
                    MenuFullName ="ต่ออายุ",
                    ButtonName = "บันทึกต่ออายุ",
                    Color = "#81bcfc",
                    ButtonState = 73
                },
                 new IndexBindingPropertites()
                {
                    Code = ContractGuaranteeTypes.T3_RETURN,
                    MenuFullName ="คืน",
                    ButtonName = "บันทึกคืน",
                    Color = "#fcbdc3",
                    ButtonState = 74
                },
                 new IndexBindingPropertites()
                {
                    Code = ContractGuaranteeTypes.T4_CLAIM,
                    MenuFullName ="เคลม/ยึด",
                    ButtonName = "บันทึกเคลม/ยึด",
                    Color = "#fcbdc3",
                    ButtonState = 75
                }
            };

            return Properties.Where(x => x.Code == _Code).Select(x => x).FirstOrDefault();

        }

        public class SigningTypesModel
        {
            public string Type { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public class ContractPropertiesModel
        {
            public string Style { get; set; }
            public string Name { get; set; }
            public string FullName { get; set; }
            public string Color { get; set; }
            public string Action { get; set; }
        }

    }
}


/*
  OLD -> NEW
  01 -> 01 S1  สัญญาให้บริการสาธารณสุขฯ
  02 -> 02 S1  ข้อตกลงให้บริการสาธารณสุขฯ
  11 -> 03 S1  สัญญาให้บริการฯ(ศูนย์สำรองเตียง)
     -> 04 S1  สัญญาให้บริการฯ(ศูนย์สำรองเตียง)เฉพาะด้าน
  12 -> 05 S1  ข้อตกลงกองทุนฟื้นฟูฯจังหวัด
  13 -> 06 S2  สัญญาให้บริการฯตามกิจกรรมบริการ
  16 -> 07 S2  ข้อตกลงให้บริการฯตามกิจกรรมบริการ
  23 -> 08 S2  สัญญาให้บริการฯตามกิจกรรมบริการ ไตเทียม
  22 -> 09 S2  ข้อตกลงให้บริการฯตามกิจกรรมบริการ ไตเทียม
  18 -> 10 S3  ข้อตกลง (อปท.)
  03 -> 11 S41 สัญญาดำเนินการตามโครงการ
  04 -> 12 S41 ข้อตกลงดำเนินการตามโครงการ
  15 -> 13 S42 หนังสือแสดงความจำนงฯ
  20 -> 14 S43 โครงการ
*/


