using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using ServiceCheckCard;
using ServiceIAMAuthentication;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Interfaces;
using SmartContract.Infrastructure.Interfaces.Share;
using SmartContract.Infrastructure.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Repositorys.Share
{
    public class SoapService : ISoapService
    {
        private IRepositoryWrapper _repo;
        private readonly IRepositoryBase _db;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly AppSettings _mySet;

        public SoapService(IRepositoryWrapper repo, IRepositoryBase db, IMapper mapper, IWebHostEnvironment env, IOptions<AppSettings> settings)
        {
            _repo = repo;
            _db = db;
            _env = env;
            _mapper = mapper;
            _mySet = settings.Value;
        }

        public async Task<AuthenticationClient> GetInstanceAsync()
        {
            EndpointAddress endpointAddress;
            BasicHttpBinding basicHttpBinding;

            endpointAddress = new EndpointAddress($"{_mySet.IAMs.DomainIAM}{_mySet.IAMs.UrlAuthenAndUserInfo}");

            basicHttpBinding =
                new BasicHttpBinding(endpointAddress.Uri.Scheme.ToLower() == "http" ?
                            BasicHttpSecurityMode.None : BasicHttpSecurityMode.Transport);

            //Please set the time accordingly, this is only for demo
            basicHttpBinding.OpenTimeout = TimeSpan.MaxValue;
            basicHttpBinding.CloseTimeout = TimeSpan.MaxValue;
            basicHttpBinding.ReceiveTimeout = TimeSpan.MaxValue;
            basicHttpBinding.SendTimeout = TimeSpan.MaxValue;

            return await Task.Run(() => new AuthenticationClient(basicHttpBinding, endpointAddress));
        }

        public async Task<authenAndUserInfoResponse> authenAndUserInfoAsync(authenWSRequest Request)
        {
            var client = await this.GetInstanceAsync();
            var responseApi = await client.authenAndUserInfoAsync(Request);

            return responseApi;
        }

        public async Task<CheckCardServiceSoapClient> GetInstanceCheckCardAsync()
        {
            EndpointAddress endpointAddress;
            BasicHttpBinding basicHttpBinding;

            endpointAddress = new EndpointAddress($"{_mySet.CheckCards.DomainCard}/CheckCardStatus/CheckCardService.asmx?wsdl");

            basicHttpBinding =
                new BasicHttpBinding(endpointAddress.Uri.Scheme.ToLower() == "http" ?
                            BasicHttpSecurityMode.None : BasicHttpSecurityMode.Transport);

            //Please set the time accordingly, this is only for demo
            basicHttpBinding.OpenTimeout = TimeSpan.MaxValue;
            basicHttpBinding.CloseTimeout = TimeSpan.MaxValue;
            basicHttpBinding.ReceiveTimeout = TimeSpan.MaxValue;
            basicHttpBinding.SendTimeout = TimeSpan.MaxValue;

            return await Task.Run(() => new CheckCardServiceSoapClient(basicHttpBinding, endpointAddress));
        }

        public async Task<CardStatusOut> CheckCardByLaserAsync(string PID, string FirstName, string LastName, string BirthDay, string Laser)
        {
            var client = await this.GetInstanceCheckCardAsync();
            var responseApi = await client.CheckCardByLaserAsync(PID, FirstName,  LastName,  BirthDay,  Laser);

            return responseApi;
        }
    }
}
