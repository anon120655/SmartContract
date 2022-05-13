using SmartContract.Infrastructure.Resources.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.Share
{
    public class CommonModel
    {
        public bool errorCheck { get; set; }
        public string errorMessage { get; set; }
        public TObjectState ObjectState { get; set; }
        public string BtnSubmit { get; set; }
        public string DomainName { get; set; }
        public string ContentRootPath { get; set; }
        public string Titletxt { get; set; }
        public string ClassBtn { get; set; }
        public string UrlSignature { get; set; }
    }
}
