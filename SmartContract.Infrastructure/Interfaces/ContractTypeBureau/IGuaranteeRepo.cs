using SmartContract.Infrastructure.Data.EntityFramework;
using SmartContract.Infrastructure.Resources.ContractTypeBureau;
using SmartContract.Infrastructure.Resources.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Guarantee;
using SmartContract.Infrastructure.Resources.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Interfaces.ContractTypeBureau
{
    public interface IGuaranteeRepo
    {

        Task<ELGCreateMain> GetView(ParameterCreate indata);

        Task<DashboardLG> GetDashboardLG();
        IQueryable<GuaranteeLgReqStation> GetListLG(SearchOptionLG condition = null);
        PaginationView<List<GuaranteeLgReqStationDTO>> GetTrackingLG(int? page, int pageSize, SearchOptionLG condition = null);

        string SetUrlRedirect(TAllMasterVendorView indata);
        IQueryable<VGuaranteeLgContract> GetListSearchLG(SearchOptionLG condition = null);
        PaginationView<List<VGuaranteeLgContract>> GetTrackingSearchLG(int? page, int pageSize, SearchOptionLG condition = null);


        void Validate(TAllMasterVendorView indata);
        Task<TAllMasterVendorView> UpdateReNewAsync(TAllMasterVendorView indata);
        Task<TAllMasterVendorView> UpdateReturnAsync(TAllMasterVendorView indata);
        Task<TAllMasterVendorView> UpdateClaimAsync(TAllMasterVendorView indata);

        Task<List<GuaranteeReportView>> GuaranteeReportView(SearchOptionGuarantee Condition = null);

    }
}
