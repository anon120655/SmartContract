using Microsoft.AspNetCore.Http;
using SmartContract.Infrastructure.Resources.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Interfaces.ContractTypeVendor
{
    public interface ICTVendorCondition
    {
        string ParameterURL(Pager indata);
        Task<DashboardMain> GetDashboardAll(SearchOptionCTV Condition = null);
        Task<Dashboards> GetDashboard(SearchOptionCTV Condition = null);
        PaginationView<List<ContractStationDTO>> GetTracking(int? page, int pageSize, SearchOptionCTV condition = null);
        Task<CTVendorMasterView> InitialData(CTVendorMasterView resource);
        string SetUrlRedirect(CTVendorMasterView indata);
        Task<CTVendorMasterView> GetContractCondition(String style, String sector = null);
        CTVendorMasterView SetContractCondition(CTVendorMasterView indata);
        Task<string> REFRunning();
    }
}
