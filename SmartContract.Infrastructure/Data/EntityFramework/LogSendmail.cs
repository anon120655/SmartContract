using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class LogSendmail
    {
        public string Emailid { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public string Template { get; set; }
        public string Emailto { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsCompleted { get; set; }
        public string StatusMessage { get; set; }
        public string PkId { get; set; }
        public string RefId { get; set; }
    }
}
