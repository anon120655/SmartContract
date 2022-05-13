using SmartContract.Infrastructure.Resources.ContractTypeBureau.Information;
using SmartContract.Infrastructure.Resources.ContractTypeVendor.Information;
using SmartContract.Infrastructure.Resources.PDFAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Interfaces.PDFAPI
{
    public interface IPDFAPIRepo
    {
        Task<FM_CONTRACT_TXX_Response> FM_APPROVAL_REQ(FM_APPROVAL_REQ_Request request);
        Task<FM_CONTRACT_TXX_Response> FM_CONTRACT_T01(FM_CONTRACT_T01_Request request);
        Task<FM_CONTRACT_TXX_Response> FM_CONTRACT_T02(FM_CONTRACT_T02_Request request);
        Task<FM_CONTRACT_TXX_Response> FM_CONTRACT_T03(FM_CONTRACT_T03_Request request);
        Task<FM_CONTRACT_TXX_Response> FM_CONTRACT_T04(FM_CONTRACT_T04_Request request);
        Task<FM_CONTRACT_TXX_Response> FM_CONTRACT_T05(FM_CONTRACT_T05_Request request);
        Task<FM_CONTRACT_TXX_Response> FM_CONTRACT_T06(FM_CONTRACT_T06_Request request);
        Task<FM_CONTRACT_TXX_Response> FM_CONTRACT_T07(FM_CONTRACT_T07_Request request);
        Task<FM_CONTRACT_TXX_Response> FM_CONTRACT_T08(FM_CONTRACT_T08_Request request);
        Task<FM_CONTRACT_TXX_Response> FM_CONTRACT_T09(FM_CONTRACT_T09_Request request);
        Task<FM_CONTRACT_TXX_Response> FM_CONTRACT_T10(FM_CONTRACT_T10_Request request);
        Task<FM_CONTRACT_TXX_Response> FM_CONTRACT_T11(FM_CONTRACT_T11_Request request);
        Task<FM_CONTRACT_TXX_Response> FM_CONTRACT_T12(FM_CONTRACT_T12_Request request);
        Task<FM_CONTRACT_TXX_Response> FM_CONTRACT_T13(FM_CONTRACT_T13_Request request);
        Task<FM_CONTRACT_TXX_Response> FM_PAY_P1(FM_PAY_P1_Request request);
        Task<FM_CONTRACT_TXX_Response> FM_PAY_P2(FM_PAY_P2_Request request);
        Task<FM_CONTRACT_TXX_Response> FM_PAY_P3(FM_PAY_P3_Request request);
        string DataTable2Base64_FM_PAY_P1(InfoConditionPayment InfoConditionPayment);
        string DataTable2Base64_FM_PAY_P3(InfoConditionPayment InfoConditionPayment,int PeriodNo);
        string GetPeriodDetailToAPI(InfoConditionPayment payment, int index);
        string DataTable2Base64_APPROVAL_REQ(InfoContract InfoContract);
    }
}
