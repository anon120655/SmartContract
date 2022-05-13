using Microsoft.AspNetCore.Http;
using SmartContract.Infrastructure.Repositorys.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Interfaces.ContractTypeVendor.TMaster
{
    public interface IT14Repo
    {
        IEnumerable<ContractStationDTO> GetList(SearchOptionCTV Condition = null);
        Task<TAllMasterVendorView> InitialData(TAllMasterVendorView indata);
        Task<TAllMasterVendorView> GetView(ParameterCondition indata);
        void Validate(TAllMasterVendorView indata);
        Task<TAllMasterVendorView> CreateAsync(TAllMasterVendorView indata);
        Task<TAllMasterVendorView> UpdateAsync(TAllMasterVendorView indata);
        Task<TAllMasterVendorView> DeleteAsync(TAllMasterVendorView indata);
    }
}
