using SmartContract.Infrastructure.Resources.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Interfaces.Share
{
    public interface IEmailSender
    {
        Task SendEmail(ResourceEmail resource);
        Task LogSendEmail(ResourceEmail resource);
    }
}
