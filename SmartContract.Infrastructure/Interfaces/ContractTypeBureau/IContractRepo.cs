using SmartContract.Infrastructure.Data.EntityFramework;
using SmartContract.Infrastructure.Repositorys.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.ContractTypeBureau;
using SmartContract.Infrastructure.Resources.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Interfaces.ContractTypeBureau
{
    public interface IContractRepo
    {
        Task<DashboardHomeMain> GetDashboardHome();

        Task<DashboardsReqApp> GetDashboardReqApp();
        IEnumerable<ApprovalReqStationDTO> GetListReqApprove(SearchOptionStation condition = null);
        PaginationView<List<ApprovalReqStationDTO>> GetTrackingBookReqApprove(int? page, int pageSize, SearchOptionStation condition = null);


        Task<DashboardsContract> GetDashboardsContract();
        IEnumerable<ContractStationDTO> GetListContract(SearchOptionStation condition = null);
        PaginationView<List<ContractStationDTO>> GetTrackingContract(int? page, int pageSize, SearchOptionStation condition = null);

        Task<DashboardsVendorLink> GetDashboardVendorLink(SearchOptionStation Condition);
        IEnumerable<VendorLinkReqStationDTO> GetListVendorLink(SearchOptionStation condition = null);
        PaginationView<List<VendorLinkReqStationDTO>> GetTrackingVendorLink(int? page, int pageSize, SearchOptionStation condition = null);

        string ParameterSearchOptionStation(Pager resource);
        Task<DashboardBinding> GetDashboardBinding(SearchOptionStation Condition);
        IEnumerable<ContractStationSuccessDTO> GetListSuccess(SearchOptionStation condition = null);
        Task<List<ContractStationSuccessDashboard>> ContractStationSuccessDashboard();
        PaginationView<List<ContractStationSuccessDTO>> GetTrackingBinding(int? page, int pageSize, SearchOptionStation condition = null);
        Task<List<ContractReport01>> ContractReport01(SearchOptionContractReport Condition = null);

    }
}
