using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class EmployeePhone
    {
        public string EmpBureauid { get; set; }
        public string EmpId { get; set; }
        public string EmpThname { get; set; }
        public string EmpEnname { get; set; }
        public string EmpNickname { get; set; }
        public string EmpEmail { get; set; }
        public string EmpPosition { get; set; }
        public string EmpBureau { get; set; }
        public string EmpTele1 { get; set; }
        public string EmpTele2 { get; set; }
        public string EmpExt { get; set; }
        public string EmpFax { get; set; }
        public string EmpMobile1 { get; set; }
        public string EmpMobile2 { get; set; }
        public string EmpPicture { get; set; }
        public string EmpOrder { get; set; }
        public string Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime? ModDate { get; set; }
        public string ModUser { get; set; }
        public string EmpUser { get; set; }
        public string EmpPassword { get; set; }
        public string EmpLevel { get; set; }
        public string Convert { get; set; }
        public string WorkGroup { get; set; }
        public string JobDescription { get; set; }
        public string Pid { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string EmpOperlevel { get; set; }
        public string EmpEmail2 { get; set; }
        public string EmpBureauidOld { get; set; }
    }
}
