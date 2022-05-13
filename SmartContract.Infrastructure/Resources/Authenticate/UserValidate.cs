using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.Authenticate
{
    public class UserValidate
    {

    }

    public class UserLogin
    {
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string UrlDDOPA { get; set; }
        public string StateRandom { get; set; }
        public string ServerSite { get; set; }
    }

    public class DDOPALogin
    {
        public string code { get; set; }
        public string state { get; set; }
        public string error { get; set; }
        public string error_description { get; set; }
        public string error_uri { get; set; }
    }


}
