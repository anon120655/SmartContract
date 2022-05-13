using Microsoft.EntityFrameworkCore.Storage;
using SmartContract.Infrastructure.Data.ConnectionContext;
using SmartContract.Infrastructure.Data.ConnectionContextEbudget;
using SmartContract.Infrastructure.Interfaces;
using SmartContract.Infrastructure.Interfaces.Authenticate;
using SmartContract.Infrastructure.Interfaces.ContractTypeBureau;
using SmartContract.Infrastructure.Interfaces.ContractTypeBureau.TMaster;
using SmartContract.Infrastructure.Interfaces.ContractTypeVendor;
using SmartContract.Infrastructure.Interfaces.ContractTypeVendor.TMaster;
using SmartContract.Infrastructure.Interfaces.PDFAPI;
using SmartContract.Infrastructure.Interfaces.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Wrapper
{
    public interface IRepositoryWrapper
    {
        smartContractContext Context { get; }
        //smartContractContextEbudget ContextEb { get; }
        IDbContextTransaction BeginTransaction();
        void Commit();
        Task SaveAsync();

        //Repository 
        IRepositoryBase _db { get; }
        IGeneralRepo GeneralRepo { get; }
        IUserService UserService { get; }
        IRegisters Registers { get; }
        IEmailSender emailSender { get; }
        IUploadFiles UploadFiles { get; }
        IContractShare ContractShare { get; }
        IContractShareNhso ContractShareNhso { get; }
        ICTVendorCondition CTVendorCondition { get; }
        ICTVendorCondition2 CTVendorCondition2 { get; }
        IMasterData MasterData { get; }
        IT01Repo T01Repo { get; }
        IT02Repo T02Repo { get; }
        IT03Repo T03Repo { get; }
        IT04Repo T04Repo { get; }
        IT05Repo T05Repo { get; }
        IT06Repo T06Repo { get; }
        IT07Repo T07Repo { get; }
        IT08Repo T08Repo { get; }
        IT09Repo T09Repo { get; }
        IT10Repo T10Repo { get; }
        IT11Repo T11Repo { get; }
        IT12Repo T12Repo { get; }
        IT13Repo T13Repo { get; }
        IT14Repo T14Repo { get; }

        IContractRepo ContractRepo { get; }
        IGuaranteeRepo GuaranteeRepo { get; }
        IT01BuRepo T01BuRepo { get; }
        IT02BuRepo T02BuRepo { get; }
        IT03BuRepo T03BuRepo { get; }
        IT04BuRepo T04BuRepo { get; }
        IT05BuRepo T05BuRepo { get; }
        IT06BuRepo T06BuRepo { get; }
        IT07BuRepo T07BuRepo { get; }
        IT08BuRepo T08BuRepo { get; }
        IT09BuRepo T09BuRepo { get; }
        IT10BuRepo T10BuRepo { get; }
        IT11BuRepo T11BuRepo { get; }
        IT12BuRepo T12BuRepo { get; }
        IT13BuRepo T13BuRepo { get; }
        IT14BuRepo T14BuRepo { get; }

        IServiceOther ServiceOther { get; }
        ISoapService SoapService { get; }
        IOtherRepo OtherRepo { get; }

        //PDFAPI
        IPDFAPIRepo PDFAPIRepo { get; }

    }
}
