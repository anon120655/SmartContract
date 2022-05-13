using SmartContract.Infrastructure.Data.EntityFramework;
using SmartContract.Infrastructure.Resources.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.Share
{
    /// <summary>
    /// ข้อมูล master data 
    /// </summary>
    public class LookUpResource
    {
        public LookUpResource()
        {
            BudgetYears = new List<BudgetYearModel>();
            Months = new List<MonthModel>();
            ContractTypes = new List<ContractType>();
            BankInfos = new List<LkBank>();
            NhsoZones = new List<VNhsoZone>();
            ServiceUnits = new List<VNhsoServiceUnitDTO>();
            MasterVendors = new List<VMasterVendorDTO>();
            UserSmctSigner = new List<UserSmctDTO>();
            Coordinators = new List<UserSmctDTO>();
            CommitteeList = new List<VNhsoBoradDTO>();
            BudgetcodeList = new List<BudgetcodeViewDTO>();
            VNhsoEmployeeAll = new List<VNhsoEmployeeAll>();
            LkDepartmentList = new List<LkDepartment>();
            ProvincesUnderNHSOList = new List<VNhsoZone>();
        }

        public string SubDomainServer { get; set; }
        //ปีงบประมาณ
        public IList<BudgetYearModel> BudgetYears { get; set; }
        public IList<MonthModel> Months { get; set; }

        //ประเภทนิติกรรมสัญญา
        public IList<ContractType> ContractTypes { get; set; }
        //ธนาคาร
        public List<LkBank> BankInfos { get; set; }
        //ผู้มีอำนาจลงนาม
        public IList<UserSmctDTO> UserSmctSigner { get; set; }
        //ผู้มีอำนาจลงนาม(สปสช.)
        public IList<VNhsoSigner> NhsoSigner { get; set; }
        //
        public IList<VNhsoEmployeeAll> VNhsoEmployeeAll { get; set; }
        //ผู้ประสานงาน
        public IList<UserSmctDTO> Coordinators { get; set; }
        /// <summary>
        /// NhsoZone
        /// </summary>

        public IEnumerable<VNhsoZone> NhsoZones { get; set; }
        //หน่วยบริการ
        public IEnumerable<VNhsoServiceUnitDTO> ServiceUnits { get; set; }
        //หน่วยบริการ
        public IEnumerable<VMasterVendorDTO> MasterVendors { get; set; }
        /// <summary>
        /// จังหวัด
        /// </summary>
        public IEnumerable<LkProvince> LKProvinces { get; set; }
        /// <summary>
        /// อำเภอ
        /// </summary>
        public IEnumerable<LkAmphur> LkAmphurs { get; set; }
        /// <summary>
        /// ตำบล
        /// </summary>
        public IEnumerable<LkDistrict> LkDistricts { get; set; }
        /// <summary>
        /// บทบาทผู้เข้าใช้งาน
        /// </summary>
        public IEnumerable<UserRole> UserRoles { get; set; }
        /// <summary>
        /// ระดับผู้เข้าใช้งาน
        /// </summary>
        public IEnumerable<UserLevel> UserLevels { get; set; }
        /// <summary>
        /// คณะกรรมการ
        /// </summary>
        public IEnumerable<VNhsoBoradDTO> CommitteeList { get; set; }
        /// <summary>
        /// รหัสงบประมาณ
        /// </summary>
        public IEnumerable<BudgetcodeViewDTO> BudgetcodeList { get; set; }
        /// <summary>
        /// ข้อมูลธนาคารใน tab รายละเอียดนิติกรรม
        /// </summary>
        public IEnumerable<VDFiBankVendor> VDFiBankVendorList { get; set; }
        /// <summary>
        /// สำนัก
        /// </summary>
        public IEnumerable<LkDepartment> LkDepartmentList { get; set; }
        /// <summary>
        /// จังหวัดสังกัดภายใต้ สปสช.เขต
        /// </summary>
        public IEnumerable<VNhsoZone> ProvincesUnderNHSOList { get; set; }

    }
}
