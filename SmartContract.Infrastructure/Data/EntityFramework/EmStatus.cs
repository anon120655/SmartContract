using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class EmStatus
    {
        public int No { get; set; }
        public string TableName { get; set; }
        public string FieldName { get; set; }
        public string Status { get; set; }
        public string Drescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUser { get; set; }
        public DateTime EditedDate { get; set; }
        public int EditedUser { get; set; }
        public string Used { get; set; }
    }
}
