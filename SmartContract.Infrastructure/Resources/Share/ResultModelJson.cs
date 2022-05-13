using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.Share
{
    public class ResultModelJson<T> : CommonModel
    {
        public bool Status { get; set; } = false;
        public string UrlRedirect { get; set; }
        public T Result { get; set; }
        public string MessagError { get; set; }
        public string MessagDetail { get; set; }
    }
}
