using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.PDFAPI
{
    public class FM_CONTRACT_TXX_Response
    {
        public object REQUEST_ID { get; set; }
        public string PDF_FILE { get; set; }
        public string RESP_STATUS { get; set; }
        public string RESP_MSG { get; set; }
    }
}
