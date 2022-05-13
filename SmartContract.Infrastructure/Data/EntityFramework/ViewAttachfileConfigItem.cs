using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class ViewAttachfileConfigItem
    {
        public int Id { get; set; }
        public string DisplayText { get; set; }
        public int? ParentId { get; set; }
    }
}
