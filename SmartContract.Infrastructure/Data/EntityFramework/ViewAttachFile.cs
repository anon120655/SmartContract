using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class ViewAttachFile
    {
        public long Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedId { get; set; }
        public DateTime? LastupdatedDate { get; set; }
        public string LastupdatedId { get; set; }
        public string ContentType { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string OriginalFileName { get; set; }
        public long? FileSize { get; set; }
        public string Uuid { get; set; }
        public int? FileType { get; set; }
    }
}
