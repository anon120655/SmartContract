using System;
using SmartContract.Utils;
namespace SmartContract.Infrastructure.Resources.ContractTypeVendor
{
    public class ParameterCondition
    {
        public string Menu { get; set; }
        public string MenuEn { get; set; }
        public string IdSmctMaster { get; set; }
        public string Style { get; set; }
        public string SigningTypeEn { get; set; }
        public string SigningType { get; set; }
        public string State { get; set; }
        public string Station { get; set; }
        public string StationEn { get; set; }
        public string StatusReq { get; set; }
        public string StationReq { get; set; }
        public string ItemStatusCurr { get; set; }
        public string IdContract { get; set; }
        public string IdContractType { get; set; } //GUID..
        public string ContractIdSelectEn { get; set; } //เลขที่สัญญา
        public string ContractTypeId { get; set; } //TXX T01...
        public string ContractTypeIdEn { get; set; } //TXX T01...        
        public string ContractName { get; set; }//ชื่อโครงการ
        public string ContractTypeFullName { get; set; } //สัญญาให้บริการ....
        public string ContractStyleCode { get; set; } //SXX S41...
        public string ContractStyleFullName { get; set; }
        public string PeriodType { get; set; }
        public string Idvl { get; set; } //ตัวเดียวกันกับ IdUserSmct
        public string VendorWitnessStatus { get; set; }//สถานะ พยาน(ฝ่ายหน่วยบริการ)
        public string NhsoWitnessStatus { get; set; }//สถานะ พยาน(ฝ่าย สปสช.)


        //pass to PDF
        public string DepartmentCodeCurr { get; set; }
        public string VendorIdCurr { get; set; }
        public string IdUserSmctCurr { get; set; }
        public int VersionNo { get; set; } = 1;
        public bool IsPDF { get; set; }
        //ผู้มีอำนาจ/พยาน
        public string SendmailType { get; set; }
        public bool IsSentMail { get; set; }
        public string SignatureData { get; set; }

        //Other
        public string IdRegisterNhso { get; set; }
        public string DepartmentCode { get; set; }
        public string BudgetYear { get; set; }
        public string Status { get; set; }
        public string Dname { get; set; }
        public string RefId { get; set; }
        public DateTime RefDate { get; set; }
        //G=ภาครัฐ P=เอกขน 
        public string Sector { get; set; }

        public string ContractSuccessType { get; set; }
        public string ContractSuccessTypeEn { get; set; }
        public string ContractGuaranteeType { get; set; }
        public string ContractGuaranteeTypeEn { get; set; }

        //CA Gateways
        public bool IsPDFSignByCA { get; set; }
        public string UserNameCA { get; set; }
        public string PasswordCA { get; set; }
        public string CadCA { get; set; }
        public string FileType { get; set; }

        //แสดงหน้าลงนามไว้
        public bool IsShowSign { get; set; } = false;

    }
}
