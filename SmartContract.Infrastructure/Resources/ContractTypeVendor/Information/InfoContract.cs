using SmartContract.Infrastructure.Resources.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.ContractTypeVendor.Information
{
    /// <summary>  
    /// ข้อมูลนิติกรรมสัญญา
    /// </summary>
    public class InfoContract
    {
        public InfoContract()
        {
            Budgetcodes = new List<BudgetcodeViewDTO>();
        }

        //สำนัก/กองทุนย่อย/เขต
        public string BureauSubFundCounty { get; set; }
        //ประเภทนิติกรรมสัญญา
        public string ContractTypeFullName { get; set; }
        //รูปแบบการลงนาม (Electronic,กระดาษ)
        public string SigningType { get; set; }
        public string RefId { get; set; }
        public DateTime RefDate { get; set; }
        public string ContractId { get; set; }
        public DateTime? ContractDate { get; set; }
        public string ContractDateStr { get; set; }

        

        


        //รูปแบบนิติกรรมสัญญา
        public string PayVendorType { get; set; }
        //รูปแบบนิติกรรมสัญญา : จ่ายตรงคู่สัญา*
        public bool PayVendorTypeD { get; set; }
        //รูปแบบนิติกรรมสัญญา : จ่ายไม่ตรงคู่สัญา*
        public bool PayVendorTypeI { get; set; }
        //รหัสงบประมาณ
        public List<BudgetcodeViewDTO> Budgetcodes { get; set; }
        //งบประมาณในการดำเนินการ
        public decimal Budget { get; set; }
        //วันที่เริ่มต้นสัญญา 
        public DateTime? StartDate { get; set; }
        public string StartDateStr { get; set; }
        //วันที่สิ้นสุดสัญญา
        public DateTime? EndDate { get; set; }
        public string EndDateStr { get; set; }
        //ระยะเวลารับประกันผลงาน
        public string GuaranteeDay { get; set; }


    }
}
