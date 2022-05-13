using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.Share
{
    public class FileListModel
    {
        public string FileId { get; set; }
        public Guid? UploadFileId { get; set; }
        public string Filename { get; set; }
        public DateTime CreateDateFile { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
