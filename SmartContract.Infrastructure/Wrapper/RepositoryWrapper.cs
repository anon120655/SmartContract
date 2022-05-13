using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using SmartContract.Infrastructure.Data.ConnectionContext;
using SmartContract.Infrastructure.Data.ConnectionContextEbudget;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Interfaces;
using SmartContract.Infrastructure.Interfaces.Authenticate;
using SmartContract.Infrastructure.Interfaces.ContractTypeBureau;
using SmartContract.Infrastructure.Interfaces.ContractTypeBureau.TMaster;
using SmartContract.Infrastructure.Interfaces.ContractTypeVendor;
using SmartContract.Infrastructure.Interfaces.ContractTypeVendor.TMaster;
using SmartContract.Infrastructure.Interfaces.PDFAPI;
using SmartContract.Infrastructure.Interfaces.Share;
using SmartContract.Infrastructure.Repositorys;
using SmartContract.Infrastructure.Repositorys.Authenticate;
using SmartContract.Infrastructure.Repositorys.ContractTypeBureau;
using SmartContract.Infrastructure.Repositorys.ContractTypeBureau.TMaster;
using SmartContract.Infrastructure.Repositorys.ContractTypeVendor;
using SmartContract.Infrastructure.Repositorys.ContractTypeVendor.TMaster;
using SmartContract.Infrastructure.Repositorys.PDFAPI;
using SmartContract.Infrastructure.Repositorys.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        public smartContractContext Context { get; }
        //public smartContractContextEbudget ContextEb { get; }
        private IDbContextTransaction transaction;
        private bool _isDisposed;
        private readonly IHttpContextAccessor _httpcontextacc;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;


        public RepositoryWrapper(smartContractContext _context, /*smartContractContextEbudget _contextEb,*/ IOptions<AppSettings> settings, IMapper mapper,
                                                    IHttpContextAccessor httpcontextaccessor, HttpClient httpClient, IWebHostEnvironment env)
        {
            this.Context = _context;
            //this.ContextEb = _contextEb;
            _httpcontextacc = httpcontextaccessor;
            _env = env;
            _mapper = mapper;

            _db = new RepositoryBase(this);
            GeneralRepo = new GeneralRepo(this, _env, settings);
            UserService = new UserService(this, _db, _env, _mapper, settings, _httpcontextacc);
            Registers = new Registers(this, _db, _env, _mapper, settings);
            emailSender = new EmailSender(this, _db, settings, _httpcontextacc);
            UploadFiles = new UploadFiles(this, settings);

            ContractShare = new ContractShare(this, _db, _mapper, _env, settings);
            ContractShareNhso = new ContractShareNhso(this, _db, _mapper, _env, settings);
            CTVendorCondition = new CTVendorCondition(this, _env, _mapper, settings, _httpcontextacc);
            CTVendorCondition2 = new CTVendorCondition2(this, _env, _mapper, settings, _httpcontextacc);
            MasterData = new MasterData(this, _db, _mapper, settings);
            T01Repo = new T01Repo(this, _db, _mapper, _env, settings);
            T02Repo = new T02Repo(this, _db, _mapper, _env, settings);
            T03Repo = new T03Repo(this, _db, _mapper, _env, settings);
            T04Repo = new T04Repo(this, _db, _mapper, _env, settings);
            T05Repo = new T05Repo(this, _db, _mapper, _env, settings);
            T06Repo = new T06Repo(this, _db, _mapper, _env, settings);
            T07Repo = new T07Repo(this, _db, _mapper, _env, settings);
            T08Repo = new T08Repo(this, _db, _mapper, _env, settings);
            T09Repo = new T09Repo(this, _db, _mapper, _env, settings);
            T10Repo = new T10Repo(this, _db, _mapper, _env, settings);
            T11Repo = new T11Repo(this, _db, _mapper, _env, settings);
            T12Repo = new T12Repo(this, _db, _mapper, _env, settings);
            T13Repo = new T13Repo(this, _db, _mapper, _env, settings);
            T14Repo = new T14Repo(this, _db, _mapper, _env, settings);

            ContractRepo = new ContractRepo(this, _db, _mapper, _env, settings);
            GuaranteeRepo = new GuaranteeRepo(this, _db, _mapper, _env, settings);
            T01BuRepo = new T01BuRepo(this, _db, _mapper, _env, settings);
            T02BuRepo = new T02BuRepo(this, _db, _mapper, _env, settings);
            T03BuRepo = new T03BuRepo(this, _db, _mapper, _env, settings);
            T04BuRepo = new T04BuRepo(this, _db, _mapper, _env, settings);
            T05BuRepo = new T05BuRepo(this, _db, _mapper, _env, settings);
            T06BuRepo = new T06BuRepo(this, _db, _mapper, _env, settings);
            T07BuRepo = new T07BuRepo(this, _db, _mapper, _env, settings);
            T08BuRepo = new T08BuRepo(this, _db, _mapper, _env, settings);
            T09BuRepo = new T09BuRepo(this, _db, _mapper, _env, settings);
            T10BuRepo = new T10BuRepo(this, _db, _mapper, _env, settings);
            T11BuRepo = new T11BuRepo(this, _db, _mapper, _env, settings);
            T12BuRepo = new T12BuRepo(this, _db, _mapper, _env, settings);
            T13BuRepo = new T13BuRepo(this, _db, _mapper, _env, settings);
            T14BuRepo = new T14BuRepo(this, _db, _mapper, _env, settings);

            ServiceOther = new ServiceOther(this, _db, _mapper, _env, settings);
            SoapService = new SoapService(this, _db, _mapper, _env, settings);
            OtherRepo = new OtherRepo(this, _db, _mapper, settings);
            PDFAPIRepo = new PDFAPIRepo(this, _db, _mapper, _env, settings);
        }

        public IRepositoryBase _db { get; }
        public IGeneralRepo GeneralRepo { get; }
        public IUserService UserService { get; }
        public IRegisters Registers { get; }
        public IEmailSender emailSender { get; }
        public IUploadFiles UploadFiles { get; }
        public IContractShare ContractShare { get; }
        public IContractShareNhso ContractShareNhso { get; }
        public ICTVendorCondition CTVendorCondition { get; }
        public ICTVendorCondition2 CTVendorCondition2 { get; }
        public IMasterData MasterData { get; }
        public IT01Repo T01Repo { get; }
        public IT02Repo T02Repo { get; }
        public IT03Repo T03Repo { get; }
        public IT04Repo T04Repo { get; }
        public IT05Repo T05Repo { get; }
        public IT06Repo T06Repo { get; }
        public IT07Repo T07Repo { get; }
        public IT08Repo T08Repo { get; }
        public IT09Repo T09Repo { get; }
        public IT10Repo T10Repo { get; }
        public IT11Repo T11Repo { get; }
        public IT12Repo T12Repo { get; }
        public IT13Repo T13Repo { get; }
        public IT14Repo T14Repo { get; }

        public IContractRepo ContractRepo { get; }
        public IGuaranteeRepo GuaranteeRepo { get; }
        public IT01BuRepo T01BuRepo { get; }
        public IT02BuRepo T02BuRepo { get; }
        public IT03BuRepo T03BuRepo { get; }
        public IT04BuRepo T04BuRepo { get; }
        public IT05BuRepo T05BuRepo { get; }
        public IT06BuRepo T06BuRepo { get; }
        public IT07BuRepo T07BuRepo { get; }
        public IT08BuRepo T08BuRepo { get; }
        public IT09BuRepo T09BuRepo { get; }
        public IT10BuRepo T10BuRepo { get; }
        public IT11BuRepo T11BuRepo { get; }
        public IT12BuRepo T12BuRepo { get; }
        public IT13BuRepo T13BuRepo { get; }
        public IT14BuRepo T14BuRepo { get; }

        public IServiceOther ServiceOther { get; }
        public ISoapService SoapService { get; }
        public IOtherRepo OtherRepo { get; }
        public IPDFAPIRepo PDFAPIRepo { get; }

        public IDbContextTransaction BeginTransaction()
        {
            transaction = Context.Database.BeginTransaction();
            return transaction;
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }

        //Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
                return;

            if (disposing)
            {
                Context.Dispose();
                //ContextEb.Dispose();
            }

            _isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
