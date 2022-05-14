using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class Contract
    {
        public Contract()
        {
            ContractDetail01s = new HashSet<ContractDetail01>();
            ContractDetail02s = new HashSet<ContractDetail02>();
            ContractDetail03s = new HashSet<ContractDetail03>();
            ContractDetail04s = new HashSet<ContractDetail04>();
            ContractDetail05s = new HashSet<ContractDetail05>();
            ContractDetail06s = new HashSet<ContractDetail06>();
            ContractDetail07s = new HashSet<ContractDetail07>();
            ContractDetail08s = new HashSet<ContractDetail08>();
            ContractDetail09s = new HashSet<ContractDetail09>();
            ContractDetail10s = new HashSet<ContractDetail10>();
            ContractDetail11s = new HashSet<ContractDetail11>();
            ContractDetail12s = new HashSet<ContractDetail12>();
            ContractDetail13s = new HashSet<ContractDetail13>();
            ContractDetail14s = new HashSet<ContractDetail14>();
            ContractExtends = new HashSet<ContractExtend>();
            ContractPeriodDetails = new HashSet<ContractPeriodDetail>();
            ContractPeriods = new HashSet<ContractPeriod>();
            ContractPlans = new HashSet<ContractPlan>();
            ContractSbbCkls = new HashSet<ContractSbbCkl>();
            ContractStationGuarantees = new HashSet<ContractStationGuarantee>();
            ContractStationSuccesses = new HashSet<ContractStationSuccess>();
            ContractStations = new HashSet<ContractStation>();
            ContractVendors = new HashSet<ContractVendor>();
            GuaranteeLgReqStations = new HashSet<GuaranteeLgReqStation>();
        }

        public string IdContract { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public string IdSmctMaster { get; set; }
        public string IdContractType { get; set; }
        public string ContractId { get; set; }
        public DateTime? ContractDate { get; set; }
        public string ContractName { get; set; }
        public decimal Budget { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Used { get; set; }
        public string Version { get; set; }
        public int GuaranteeDay { get; set; }
        public string PayVendorType { get; set; }
        public string ContractMainId { get; set; }

        public virtual UserSmct CreateUserNavigation { get; set; }
        public virtual UserSmct EditUserNavigation { get; set; }
        public virtual ContractType IdContractTypeNavigation { get; set; }
        public virtual SmctMaster IdSmctMasterNavigation { get; set; }
        public virtual ICollection<ContractDetail01> ContractDetail01s { get; set; }
        public virtual ICollection<ContractDetail02> ContractDetail02s { get; set; }
        public virtual ICollection<ContractDetail03> ContractDetail03s { get; set; }
        public virtual ICollection<ContractDetail04> ContractDetail04s { get; set; }
        public virtual ICollection<ContractDetail05> ContractDetail05s { get; set; }
        public virtual ICollection<ContractDetail06> ContractDetail06s { get; set; }
        public virtual ICollection<ContractDetail07> ContractDetail07s { get; set; }
        public virtual ICollection<ContractDetail08> ContractDetail08s { get; set; }
        public virtual ICollection<ContractDetail09> ContractDetail09s { get; set; }
        public virtual ICollection<ContractDetail10> ContractDetail10s { get; set; }
        public virtual ICollection<ContractDetail11> ContractDetail11s { get; set; }
        public virtual ICollection<ContractDetail12> ContractDetail12s { get; set; }
        public virtual ICollection<ContractDetail13> ContractDetail13s { get; set; }
        public virtual ICollection<ContractDetail14> ContractDetail14s { get; set; }
        public virtual ICollection<ContractExtend> ContractExtends { get; set; }
        public virtual ICollection<ContractPeriodDetail> ContractPeriodDetails { get; set; }
        public virtual ICollection<ContractPeriod> ContractPeriods { get; set; }
        public virtual ICollection<ContractPlan> ContractPlans { get; set; }
        public virtual ICollection<ContractSbbCkl> ContractSbbCkls { get; set; }
        public virtual ICollection<ContractStationGuarantee> ContractStationGuarantees { get; set; }
        public virtual ICollection<ContractStationSuccess> ContractStationSuccesses { get; set; }
        public virtual ICollection<ContractStation> ContractStations { get; set; }
        public virtual ICollection<ContractVendor> ContractVendors { get; set; }
        public virtual ICollection<GuaranteeLgReqStation> GuaranteeLgReqStations { get; set; }
    }
}
