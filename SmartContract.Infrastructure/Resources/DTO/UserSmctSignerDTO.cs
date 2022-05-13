using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.DTO
{
    public class UserSmctSignerDTO
    {
        public string IdUserSmctSigner { get; set; }
        public string IdUserSmct { get; set; }
        public string SignerType { get; set; }
        public string Signer1DocName { get; set; }
        public string Signer1DocNo { get; set; }
        public DateTime? Signer1DocDate { get; set; }
        public string Signer1DocDateStr { get; set; }
        public string Signer2PoaDocNo { get; set; }
        public DateTime? Signer2PoaDocDate { get; set; }
        public string Signer2PoaDocDateStr { get; set; }
        public string Signer2PoaSigner1User { get; set; }
        public string Signer2PoaSigner1Name { get; set; }
        public string Signer2DocName { get; set; }
        public string Signer2DocNo { get; set; }
        public DateTime? Signer2DocDate { get; set; }
        public string Signer2DocDateStr { get; set; }
        public DateTime? Signer2StartDate { get; set; }
        public string Signer2StartDateStr { get; set; }
        public DateTime? Signer2EndDate { get; set; }
        public string Signer2EndDateStr { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public bool Used { get; set; }
        public string Signer1User { get; set; }
        public string Signer1Name { get; set; }
        public IList<UserSmctSignerFileDTO> UserSmctSignerFiles { get; set; }



    }
}
