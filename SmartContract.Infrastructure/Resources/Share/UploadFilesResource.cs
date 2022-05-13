using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.Share
{
    public class UploadFilesResource
    {
        public UploadFilesResource()
        {
            Files = new List<IFormFile>();
        }

        public List<IFormFile> Files { get; set; }
        public string ContentRootPath { get; set; }
        public string SubDirectory { get; set; }
        public string FileNameServer { get; set; }
    }
}
