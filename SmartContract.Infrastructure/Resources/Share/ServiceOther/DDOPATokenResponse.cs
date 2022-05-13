using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.Share.ServiceOther
{
    public class DDOPATokenResponse
    {
        public int expire_in { get; set; }
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string token_type { get; set; }
        public string scope { get; set; }
        public string pid { get; set; }
        public string th_fullname { get; set; }
        public string en_fullname { get; set; }
        public string dob { get; set; }
        public string address { get; set; }
        public string th_fname { get; set; }
        public string en_fname { get; set; }
        public string th_lname { get; set; }
        public string en_lname { get; set; }
        public string th_mname { get; set; }
        public string en_mname { get; set; }
        public string sex { get; set; }
    }
}
