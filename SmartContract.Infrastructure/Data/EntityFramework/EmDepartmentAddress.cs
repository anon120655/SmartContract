using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class EmDepartmentAddress
    {
        public int No { get; set; }
        public string Dcode { get; set; }
        public string ChangwatName { get; set; }
        public string AmphurName { get; set; }
        public string TumbonName { get; set; }
        public string MoobanName { get; set; }
        public string Moo { get; set; }
        public string Address { get; set; }
        public string Road { get; set; }
        public string Soi { get; set; }
        public string PostCode { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUser { get; set; }
        public DateTime EditedDate { get; set; }
        public int EditedUser { get; set; }
        public string Used { get; set; }
        public string Header { get; set; }
        public string Address0 { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
    }
}
