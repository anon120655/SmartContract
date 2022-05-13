using SmartContract.Infrastructure.Resources.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.ContractTypeBureau.Information
{
    /// <summary>
    /// เงื่อนไขการจ่ายเงิน
    /// </summary>
    public class InfoConditionPayment
    {
        public InfoConditionPayment()
        {
            PeriodList = new List<PeriodModel>();
            P1Budgetcode = new List<ContractPeriodDTO>();
        }

        //ประเภทงวดงาน
        //P1 = จ่ายงวดเดียว 100%
        //P2 = งวดเดียวตัดจ่ายหลายครั้ง(มี 1 งวด แต่หลาย row)
        //P3 = ตัดจ่ายหลายงวด (มีงวดที่ 1 - n)
        public string PeriodType { get; set; }
        //รายละเอียดกรณีจ่ายงวดเดียว 100%
        public decimal? PeriodPercent { get; set; }
        public string PeriodP1Detail { get; set; }
        public string ContractPeriodDetail1 { get; set; }

        //กรณีแบ่งจ่ายหลายงวด
        public string PaymentSelect { get; set; }

        //กรณีเงินงวดเดียวจ่ายครั้งเดียว 100% แต่มีหลายรหัสงบ ให้ User ระบุยอดเงินแต่ละรหัสเอง ถ้า 1 รหัส ไม่ต้องแสดง
        public List<ContractPeriodDTO> P1Budgetcode { get; set; }


        public List<PeriodModel> PeriodList { get; set; }

    }

    public class PeriodModel
    {
        public int PeriodNo { get; set; }
        public List<ContractPeriodDTO> ContractPeriod { get; set; }
        public List<ContractPeriodDetailDTO> ContractPeriodDetail { get; set; }
    }

   

}
