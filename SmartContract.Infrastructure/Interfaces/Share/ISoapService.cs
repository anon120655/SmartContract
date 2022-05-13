using ServiceIAMAuthentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Interfaces.Share
{
    public interface ISoapService
    {
        Task<AuthenticationClient> GetInstanceAsync();
        Task<authenAndUserInfoResponse> authenAndUserInfoAsync(authenWSRequest Request);


        Task<ServiceCheckCard.CheckCardServiceSoapClient> GetInstanceCheckCardAsync();
        Task<ServiceCheckCard.CardStatusOut> CheckCardByLaserAsync(string PID, string FirstName, string LastName, string BirthDay, string Laser);
    }
}
