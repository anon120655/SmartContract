using SmartContract.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.Share
{
    public class ParameterStatusStation
    {
        public string IdSmctMaster { get; set; }
        public string Status { get; set; }
        public string StationStatusPrev { get; set; }
        public string StationStatusCurr { get; set; }
        public string ItemStatusPrev { get; set; }
        public string ItemStatusCurr { get; set; }
        public string FRetarn { get; set; } = F_RETARN.NEW;
        //หนังสือขออนุมัติ
        public string OfficerReamrk { get; set; }
        public string DirectorRemark { get; set; }
        //เขต
        public string KetRemark { get; set; }
        //ส่วนกลาง
        public string SbbRemark { get; set; }

        //กำหนดรหัสคู่สัญญา
        public string VendorId { get; set; }
        public string VendorName { get; set; }
    }
}
