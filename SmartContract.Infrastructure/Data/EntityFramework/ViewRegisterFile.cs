using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class ViewRegisterFile
    {
        public long RegisterId { get; set; }
        public long FileId { get; set; }
        public int FileTypeId { get; set; }
    }
}
