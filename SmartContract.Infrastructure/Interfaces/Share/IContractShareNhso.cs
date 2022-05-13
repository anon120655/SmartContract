using Microsoft.AspNetCore.Http;
using SmartContract.Infrastructure.Data.EntityFramework;
using SmartContract.Infrastructure.Resources.Authenticate;
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
    public interface IContractShareNhso
    {
        string SetUrlRedirectReqApprove(TAllMasterVendorView indata);
        string SetUrlRedirectContract(TAllMasterVendorView indata);

        //Validate
        void ValidateConditionPayment(TAllMasterVendorView indata);
        void ValidateEXPAND(TAllMasterVendorView indata);

        Task<TAllMasterVendorView> ViewInfoContract(TAllMasterVendorView indata);
        Task<TAllMasterVendorView> ViewRequestForApproval(TAllMasterVendorView indata);
        Task<TAllMasterVendorView> ViewMasterSignerNhso(TAllMasterVendorView indata);
        Task<TAllMasterVendorView> ViewConditionPayment(TAllMasterVendorView indata);

        //RequestApprove
        //ข้อมูลนิติกรรมสัญญา ,งบประมาณ  หนังสือขออนุมัติ
        Task UpdateReqAppContractBudgetCode(TAllMasterVendorView indata);
        Task UpdateReqAppAttachDraftContract(TAllMasterVendorView indata, String ContractTypeId);
        Task UpdateReqAppChairmanBoard(TAllMasterVendorView indata);
        Task UpdateStatusBookReqMailStatus(TAllMasterVendorView indata, bool? IsSuccess = null);
        Task UpdateStatusBookReq(TAllMasterVendorView indata);
        Task SignatureAppReqUploadfile(IFormFile FormFile, TAllMasterVendorView indata);
        //เลขที่หนังสือขออนุมัติดำเนินการ
        Task UpdateBookNumber(TAllMasterVendorView indata);
        Task<string> BookNumberRunning();

        //ContractAll
        Task UpdateInfoContract(TAllMasterVendorView indata);
        Task UpdateMasterSigners(TAllMasterVendorView indata);
        Task UpdateSigner(TAllMasterVendorView indata);
        Task UpdateConditionPayment(TAllMasterVendorView indata);
        Task<byte[]> PDFCAFile(byte[] outPdfBuffer, String Cad = null, String ImagePath = null, String SendmailType = null, int SignaturePage = 1);
        Task UpdateFMPDF(ParameterCondition indata, String fmtype, byte[] outPdfBuffer);

        //ออกเลขที่สัญญา
        Task UpdateContractNumber(TAllMasterVendorView indata);
        Task<string> ContractNumberRunning();

        //Other
        Task UpdateStatusContract(TAllMasterVendorView indata);
        Task UpdateContractEditLast(TAllMasterVendorView indata);

        //CheckList
        Task<TAllMasterVendorView> ViewCheckList(TAllMasterVendorView indata);
        Task UpdateCheckList(TAllMasterVendorView indata);
        Task<ContractSbbCklDTO> CheckListHistory(string ChecklistId, string IdContractType);

        //ขอแก้ไขหลังผูกพัน
        Task UpdateRequestBinding(TAllMasterVendorView indata);
        Task UpdateEXPAND(TAllMasterVendorView indata);

        Task ApproveVendorLink(RegisterMaster indata);

        Task<ResourceEmail> GetSentMailReqApp(TAllMasterVendorView indata, string htmlBody);
        Task<ResourceEmail> GetSentMainToConsider(TAllMasterVendorView indata, string htmlBody);
        Task<ResourceEmail> GetSentMailSigner(TAllMasterVendorView indata, string htmlBody);

    }
}
