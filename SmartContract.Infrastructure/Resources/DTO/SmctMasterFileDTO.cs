using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.DTO
{
    public class SmctMasterFileDTO
    {
        public string IdSmctMasterFile { get; set; }
        public string IdSmctMaster { get; set; }
        public string FileType { get; set; }
        public string FileName { get; set; }
        public string FileFtp { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public decimal FileNo { get; set; }
        public bool Used { get; set; }
        public string PathFolder { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
