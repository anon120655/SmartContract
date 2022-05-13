using SmartContract.Infrastructure.Resources.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.ContractTypeVendor.Information
{
    /// <summary>  
    /// ข้อมูลหลักประกันสัญญา
    /// </summary>
    public class InfoGuaranteeContract
    {
        public InfoGuaranteeContract()
        {
            CashierChequeDesc = new List<CashierChequeDescription>();
            BookGuaranteeDesc = new List<BookGuaranteeDescription>();
        }

        public LookUpResource GetLookUp { get; set; }
        //หักจากเงินโอนงวดที่ 1
        //public bool DeductedTransfer1 { get; set; }
        public decimal? DeductedAmountMoney { get; set; }

        //ประเภทหลักประกัน เงินสด,แคชเชียร์เช็ค,หนังสือค้ำประกัน
        public int GuaranteeTypeSelected { get; set; }
        public bool GuaranteeType1 { get; set; } = false;
        public bool GuaranteeType2 { get; set; } = false;
        public bool GuaranteeType3 { get; set; } = false;
        public bool GuaranteeType4 { get; set; } = false;
        //จำนวนเงิน(เงินสด)
        public string IdContractGuaranteeDetail { get; set; }
        public decimal? AmountMoney { get; set; }

        //แคชเชียร์เช็ค
        public List<CashierChequeDescription> CashierChequeDesc { get; set; }
        //หนังสือค้ำประกัน
        public List<BookGuaranteeDescription> BookGuaranteeDesc { get; set; }

    }

    public class CashierChequeDescription
    {
        public string IdContractGuaranteeDetail { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string CheckNumber { get; set; }
        public DateTime? Date { get; set; }
        public string DateStr { get; set; }
        public decimal? AmountMoney { get; set; }
    }

    public class BookGuaranteeDescription
    {
        public string IdContractGuaranteeDetail { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string BookNumber { get; set; }
        public DateTime? StartDate { get; set; }
        public string StartDateStr { get; set; }
        public DateTime? EndDate { get; set; }
        public string EndDateStr { get; set; }
        public decimal? AmountMoney { get; set; }
    }

}
