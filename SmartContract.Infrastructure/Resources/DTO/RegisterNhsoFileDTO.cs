using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.DTO
{
    public class RegisterNhsoFileDTO
    {
        public string IdRegisterNhsoFile { get; set; }
        public string IdRegisterNhso { get; set; }
        public string RegisterFileType { get; set; }
        public string RegisterFileName { get; set; }
        public string RegisterFileFtp { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public decimal RegisterFileNo { get; set; }
        public bool Used { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
