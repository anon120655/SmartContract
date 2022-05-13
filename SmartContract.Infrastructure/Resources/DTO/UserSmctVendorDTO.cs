using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.DTO
{
   public class UserSmctVendorDTO
    {
        public string IdUserSmctVendor { get; set; }
        public string IdUserSmct { get; set; }
        public string Hcode { get; set; }
        public string VendorId { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public bool Used { get; set; }
    }
}
