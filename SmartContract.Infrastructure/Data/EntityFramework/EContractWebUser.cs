using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class EContractWebUser
    {
        public string Userid { get; set; }
        public string Pwd { get; set; }
        public string Deptcode { get; set; }
        public string Ulevel { get; set; }
        public string Upermission { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Tel { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Used { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? EditDate { get; set; }
        public string Byuser { get; set; }
        public string Pid { get; set; }
    }
}
