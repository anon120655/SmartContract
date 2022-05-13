using Microsoft.AspNetCore.Http;
using SmartContract.Infrastructure.Data.EntityFramework;
using SmartContract.Infrastructure.Resources.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Interfaces.Share
{
    public interface IContractShare
    {
        string SetUrlRedirect(TAllMasterVendorView indata);

        //Validate
        void ValidateGuaranteeContract(TAllMasterVendorView indata);

        Task<TAllMasterVendorView> ViewInfoContract(TAllMasterVendorView indata);
        Task<TAllMasterVendorView> ViewRequestForApproval(TAllMasterVendorView indata);
        Task<TAllMasterVendorView> ViewGuaranteeContract(TAllMasterVendorView indata);
        Task<TAllMasterVendorView> ViewInfoPartnersOfContract(TAllMasterVendorView indata, String VendorId);
        Task<TAllMasterVendorView> ViewMasterSigners(TAllMasterVendorView indata);
        Task<TAllMasterVendorView> ViewMasterFiles(TAllMasterVendorView indata);
        Task<TAllMasterVendorView> ViewApprovalReqStation(TAllMasterVendorView indata);
        Task<TAllMasterVendorView> ViewContractStation(TAllMasterVendorView indata);
        Task<TAllMasterVendorView> ViewVendorLinkReq(TAllMasterVendorView indata);

        Task<SmctMaster> InsertSmctMaster(TAllMasterVendorView indata);
        Task<SmctMasterSigner> InsertMasterSigners(TAllMasterVendorView indata);
        Task<SmctMasterFile> InsertInfoAttachDraftContract(TAllMasterVendorView indata, String ContractTypeId);
        Task<ApprovalReqStation> InsertApprovalReqStation(TAllMasterVendorView indata);
        Task<ContractStation> InsertContractStation(TAllMasterVendorView indata);
        Task<VendorLinkReq> InsertVendorLinkReq(TAllMasterVendorView indata);

        Task<SmctMaster> UpdateSmctMaster(TAllMasterVendorView indata);
        Task UpdateMasterSigners(TAllMasterVendorView indata);
        Task UpdateGuaranteeContract(TAllMasterVendorView indata);
        Task UpdateInfoAttachDraftContract(TAllMasterVendorView indata, String ContractTypeId);
        Task UpdateApprovalReqStation(TAllMasterVendorView indata);
        Task<ContractStation> UpdateContractStation(TAllMasterVendorView indata);
        Task<VendorLinkReq> UpdateVendorLinkReq(TAllMasterVendorView indata);
        Task UpdateSigner(TAllMasterVendorView indata);
        Task UpdateRequestBinding(TAllMasterVendorView indata);

        //Update เฉพาะส่วนของ Station รวม
        Task UpdateStatusApproveReq(ParameterStatusStation indata);
        Task UpdateStatusContract(ParameterStatusStation indata);
        Task UpdateStatusVendorLink(ParameterStatusStation indata);


        //ElectronicSignature
        Task<ResourceEmail> GetSentMailSignature(TAllMasterVendorView indata, string htmlBody);
        string SetUrlSignature(TAllMasterVendorView indata);
        Task<List<SmctMasterSendmailDTO>> GetSignature(ParameterCondition indata);
        Task<TAllMasterVendorView> UpdateSignature(TAllMasterVendorView indata);
        Task SignatureUploadfile(IFormFile FormFile, TAllMasterVendorView indata);
        Task<bool> CheckSignature(string idSmctMaster, string SendmailType);

    }
}
