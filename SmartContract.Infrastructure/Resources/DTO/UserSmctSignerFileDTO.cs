using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.DTO
{
   public class UserSmctSignerFileDTO
    {
        public string IdUserSmctSignerFile { get; set; }
        public string IdUserSmctSigner { get; set; }
        public string SignerFileType { get; set; }
        public string SignerFileName { get; set; }
        public string SignerFileFtp { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public decimal SignerFileNo { get; set; }
        public bool Used { get; set; }
        public string PathFolder { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
