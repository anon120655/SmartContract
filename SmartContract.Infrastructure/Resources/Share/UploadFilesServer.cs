using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.Share
{
    public class UploadFilesServer
    {
        public UploadFilesServer()
        {

        }

        public Guid UploadFileId { get; set; }
        public int FileTypeId { get; set; }
        public string FileName { get; set; }
        public string FileComment { get; set; }
        public string FileNameServer { get; set; }
        public long FileSize { get; set; }
        public string FileFolder { get; set; }

    }
}
