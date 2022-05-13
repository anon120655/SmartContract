using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class ViewStandardRegister
    {
        public long Id { get; set; }
        public int? AssistThaiMedicineFullTime { get; set; }
        public int? AssistThaiMedicinePartTime { get; set; }
        public int? CTrtAmountBedIcu { get; set; }
        public string AuthrorizedPerson { get; set; }
        public string CHHaBedOpen { get; set; }
        public DateTime? CHHaExpireDate { get; set; }
        public string CHHaLevel { get; set; }
        public DateTime? CHHaPassDate { get; set; }
        public bool? CIso15189 { get; set; }
        public DateTime? CIso15189ExpireDate { get; set; }
        public DateTime? CIso15189PassDate { get; set; }
        public bool? CLa { get; set; }
        public DateTime? CLaExpireDate { get; set; }
        public DateTime? CLaPassDate { get; set; }
        public string CStandard { get; set; }
        public DateTime? CStandardExpireDate { get; set; }
        public DateTime? CStandardPassDate { get; set; }
        public string CTrtBedOpenStation { get; set; }
        public DateTime? CTrtExpireDate { get; set; }
        public DateTime? CTrtPassDate { get; set; }
        public string CTrtSubUnitStation { get; set; }
        public string CQHBedOpen { get; set; }
        public DateTime? CQHExpireDate { get; set; }
        public DateTime? CQHPassDate { get; set; }
        public DateTime? CSp7ExpireDate { get; set; }
        public string CSp7No { get; set; }
        public DateTime? CSp7PassDate { get; set; }
        public DateTime? CSp9ExpireDate { get; set; }
        public string CSp9No { get; set; }
        public DateTime? CSp9PassDate { get; set; }
        public bool? CTrtBedIcu { get; set; }
        public DateTime? InfoLicenseKy1AllowDate { get; set; }
        public DateTime? InfoLicenseKy1ExpireDate { get; set; }
        public DateTime? RehabilitationAllowDate { get; set; }
        public DateTime? RehabilitationExpireDate { get; set; }
        public DateTime? HaLevel3expireDate { get; set; }
        public DateTime? HaLevel3passDate { get; set; }
        public DateTime? IsoExpireDate { get; set; }
        public DateTime? IsoPassDate { get; set; }
        public DateTime? JciExpireDate { get; set; }
        public DateTime? JciPassDate { get; set; }
        public DateTime? TqmExpireDate { get; set; }
        public DateTime? TqmPassDate { get; set; }
        public bool? IsHaLevel3 { get; set; }
        public bool? IsIso { get; set; }
        public bool? IsJci { get; set; }
        public bool? IsTqm { get; set; }
        public long? RequestRegisterId { get; set; }
    }
}
