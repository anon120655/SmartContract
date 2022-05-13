using Microsoft.AspNetCore.Http;
using SmartContract.Infrastructure.Resources.ContractTypeBureau;
using SmartContract.Infrastructure.Resources.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Interfaces.ContractTypeBureau.TMaster
{
   public interface IT02BuRepo
    {
        Task<TAllMasterVendorView> InitialData(TAllMasterVendorView indata);
        Task<TAllMasterVendorView> GetView(ParameterCondition indata);

        //สร้างนิติกรรม
        void ValidateContract(TAllMasterVendorView indata);
        Task<TAllMasterVendorView> UpdateAsyncContract(TAllMasterVendorView indata);
    }
}
