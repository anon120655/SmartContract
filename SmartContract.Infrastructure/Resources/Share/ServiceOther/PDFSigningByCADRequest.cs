using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.Share.ServiceOther
{
    public class PDFSigningByCADRequest
    {
        public string workerName { get; set; }
        public string contentData { get; set; }
        public string certify { get; set; }
        public bool visibleSignature { get; set; }
        public int visibleSignaturePage { get; set; }
        public string visibleSignatureRectangle { get; set; }
        public string visibleSignatureImagePath { get; set; }
        public string reason { get; set; }
        public string location { get; set; }
        public string cad { get; set; }
    }
}
