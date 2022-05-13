using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class LmHtitle
    {
        public string CreateUid { get; set; }
        public DateTime CreateDatetime { get; set; }
        public string UpdateUid { get; set; }
        public DateTime UpdateDatetime { get; set; }
        public string Used { get; set; }
        public string Remarks { get; set; }
        public string HtitleId { get; set; }
        public string HtitleName { get; set; }
        public string ShortName { get; set; }
    }
}
