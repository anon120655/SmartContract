using SmartContract.Infrastructure.Data.EntityFramework;
using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Guarantee;
using SmartContract.Infrastructure.Resources.Registers;
using SmartContract.Infrastructure.Resources.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Interfaces.Share
{
    public interface IMasterData
    {
        List<BudgetYearModel> BudgetYear(int Range = 6);
        List<MonthModel> GetMonths();
        Task<IList<ContractType>> ContractTypes(String contractTypeId = null);
        List<LkBank> BankInfos();
        List<AuthoritySign> AuthoritySigns();
        Task<IList<UserSmctDTO>> Coordinators();
        Task<IEnumerable<VNhsoZone>> NhsoZones(String NhsoZone = null); 
        Task<IEnumerable<VMasterVendorDTO>> MasterVendor(String vendorId = null, String hcode = null, String nhsoZone = null);
        Task<IEnumerable<ViewHraRegisterDTO>> ServiceUnits(String vendorId = null, String hcode = null, String nhsoZone = null);
        Task<IEnumerable<LkDepartment>> LKDepartments(String dcode = null);
        Task<IEnumerable<LkProvince>> LKProvinces(String provinceId = null);
        Task<IEnumerable<LkAmphur>> LKAmphurs(String provinceId = null);
        Task<IEnumerable<LkDistrict>> LKDistricts(String code = null);
        Task<IEnumerable<LkCatm>> LKCatm(String catm = null);
        Task<IEnumerable<LmHospital>> LMHospitals();
        Task<IEnumerable<LmHtitle>> LMHtitles(String htitleId = null);
        /// <summary>
        /// ผู้มีอำนาจลงนาม
        /// </summary>
        Task<IList<UserSmctDTO>> UserSmctSigner(String IdUserSmct = null, string IdRegisterNhso = null);
        Task<IEnumerable<VNhsoBoradDTO>> CommitteeList(string departmentCode = null);
        Task<IEnumerable<BudgetcodeViewDTO>> BudgetcodeList(string budgetcode = null, bool? IsCurrentYear = null);
        Task<IList<VNhsoSigner>> NhsoSigner(String departmentCode = null);
        Task<IList<VNhsoEmployeeAll>> VNhsoEmployeeAll(String EmpId = null, String departmentCode = null);
        Task<IList<VDFiBankVendor>> VDFiBankVendorList(String vl_vendor_id);
        Task<IList<VNhsoZone>> ProvincesUnderNHSO();
        //ไฟล์เอกสารจากระบบสมัคร
        Task<IEnumerable<FileSystemDTO>> GetAttachSystem(String hcode = null);

        //LG หลักประกันสัญญา
        IEnumerable<AppTypeModel> GetAppTypeList(string AppTypeId = null);
        IEnumerable<AppTypeModel> LgStatus(string status = null);
        IEnumerable<AppTypeModel> GetContractTypeList(string Id = null);
        IEnumerable<AppTypeModel> GetGuaranteeTypeList(string Id = null);


    }
}
