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
    public interface IGuaranteeRepo
    {
        string SetUrlRedirect(TAllMasterVendorView indata);
        IEnumerable<ContractStationGuaranteeDTO> GetList(SearchOptionStation condition = null);
        PaginationView<List<ContractStationGuaranteeDTO>> GetTrackingGuaranteeNew(int? page, int pageSize, SearchOptionStation condition = null);


        void Validate(TAllMasterVendorView indata);
        Task<TAllMasterVendorView> UpdateReNewAsync(TAllMasterVendorView indata);
        Task<TAllMasterVendorView> UpdateReturnAsync(TAllMasterVendorView indata);
        Task<TAllMasterVendorView> UpdateClaimAsync(TAllMasterVendorView indata);

        Task<List<GuaranteeReportView>> GuaranteeReportView(SearchOptionGuarantee Condition = null);

    }
}
