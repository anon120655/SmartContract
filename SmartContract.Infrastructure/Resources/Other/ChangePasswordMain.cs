using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.Other
{
    public class ChangePasswordMain
    {
        public bool errorCheck { get; set; }
        public string errorMessage { get; set; }
        public string IdUserSmct { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordConfirm { get; set; }
    }
}
