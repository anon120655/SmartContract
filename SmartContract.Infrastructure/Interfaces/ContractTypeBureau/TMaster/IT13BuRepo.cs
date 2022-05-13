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
   public interface IT13BuRepo
    {
        Task<TAllMasterVendorView> InitialData(TAllMasterVendorView indata);
        Task<TAllMasterVendorView> GetView(ParameterCondition indata);

        //หนังสือขออนุมัติ
        void ValidateBookReq(TAllMasterVendorView indata);
        Task<TAllMasterVendorView> UpdateAsyncBookReq(TAllMasterVendorView indata);

        //สร้างนิติกรรม
        void ValidateContract(TAllMasterVendorView indata);
        Task<TAllMasterVendorView> UpdateAsyncContract(TAllMasterVendorView indata);

    }
}
