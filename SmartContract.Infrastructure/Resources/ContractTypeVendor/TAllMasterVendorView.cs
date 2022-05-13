using SmartContract.Infrastructure.Repositorys.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.ContractTypeBureau.Information;
using SmartContract.Infrastructure.Resources.ContractTypeVendor.Information;
using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Share;
using System.Collections.Generic;

namespace SmartContract.Infrastructure.Resources.ContractTypeVendor
{
    public class TAllMasterVendorView : CommonModel
    {
        public TAllMasterVendorView()
        {
            CTVendor = new CTVendorMasterView();
            InfoContract = new InfoContract();
            InfoRequestForApproval = new InfoRequestForApproval();
            InfoGuaranteeContract = new InfoGuaranteeContract();
            InfoPartnersOfContract = new InfoPartnersOfContract();
            InfoSignerPartnersOfContract = new InfoSignerPartnersOfContract();
            InfoAttachDraftContract = new InfoAttachDraftContract();
            InfoAttachDraftContractAppReq = new InfoAttachDraftContract();
            InfoAttachFileRealVersion = new InfoAttachFileRealVersion();
            InfoRequestBinding = new InfoRequestBinding();
            InfoContractNhso = new InfoContractNhso();
            InfoConDetail = new InfotractDetail();
            InfoConditionPayment = new InfoConditionPayment();
            InfoAttachFileSignature = new InfoAttachFileSignature();
            InfoFMPDF = new InfoFMPDF();
            CheckListMain = new ContractSbbCklMain();
            MasterSendmail = new List<SmctMasterSendmailDTO>();
            ApproveProposal = new ApproveModel();
            ApproveContract = new ApproveModel();
            ApproveGenContract = new ApproveGenConModel();
        }

        public ParameterCondition ParameterCondition { get; set; }
        public CTVendorMasterView CTVendor { get; set; }
        public InfoContract InfoContract { get; set; }
        /// <summary>  
        /// ข้อมูลขออนุมัติดำเนินการ
        /// </summary>
        public InfoRequestForApproval InfoRequestForApproval { get; set; }
        /// <summary>  
        /// ข้อมูลหลักประกันสัญญา
        /// </summary>
        public InfoGuaranteeContract InfoGuaranteeContract { get; set; }
        /// <summary>  
        /// ข้อมูลฝ่ายคู่สัญญา
        /// </summary>
        public InfoPartnersOfContract InfoPartnersOfContract { get; set; }
        /// <summary>  
        /// ข้อมูลผู้ลงนาม
        /// </summary>
        public InfoSignerPartnersOfContract InfoSignerPartnersOfContract { get; set; }
        public InfoAttachDraftContract InfoAttachDraftContract { get; set; }

        public ContractStationDTO ContractStation { get; set; }
        public ApprovalReqStationDTO ApprovalReqStation { get; set; }
        /// <summary>
        /// ข้อมูลฝ่าย สปสช.
        /// </summary>
        public InfoContractNhso InfoContractNhso { get; set; }
        /// <summary>
        /// ข้อมูลรายละเอียดนิติกรรมสัญญา
        /// </summary>
        public InfotractDetail InfoConDetail { get; set; }

        /// <summary>
        /// เงื่อนไขการจ่ายเงิน
        /// </summary>
        public InfoConditionPayment InfoConditionPayment { get; set; }
        /// <summary>
        /// ไฟล์แนบจากเขต
        /// </summary>
        public InfoAttachDraftContract InfoAttachDraftContractAppReq { get; set; }
        /// <summary>
        /// รายละเอียดแนบไฟล์แสกน นิติกรรมสัญญา(ฉบับจริง)
        /// </summary>
        public InfoAttachFileRealVersion InfoAttachFileRealVersion { get; set; }
        /// <summary>
        /// เอกสารขอแก้ไข(ผูกพัน)
        /// </summary>
        public InfoRequestBinding InfoRequestBinding { get; set; }
        /// <summary>
        /// รายละเอียดไฟล์ ลงนาม Electronic
        /// </summary>
        public InfoAttachFileSignature InfoAttachFileSignature { get; set; }

        /// <summary>
        /// เอกสาร Render PDF
        /// </summary>
        public InfoFMPDF InfoFMPDF { get; set; }


        public ApproveModel ApproveProposal { get; set; }
        public ApproveModel ApproveReq { get; set; }
        public ApproveModel ApproveContract { get; set; }
        public ApproveGenConModel ApproveGenContract { get; set; }
        public ApproveModel ApproveBinding { get; set; }

        //Electronic Signature
        public List<SmctMasterSendmailDTO> MasterSendmail { get; set; }
        public ResourceEmail ResourceEmail { get; set; }


        //CheckList
        public ContractSbbCklMain CheckListMain { get; set; }

    }
}
