using SmartContract.Infrastructure.Resources.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.ContractTypeBureau
{
    public class TrackingContractMain
    {
        public TrackingContractMain()
        {
            Condition = new SearchOptionStation();
            DashboardsReqApp = new DashboardsReqApp();
            DashboardsContract = new DashboardsContract();
            DashboardsVendorLink = new DashboardsVendorLink();
            DashboardBinding = new DashboardBinding();
        }

        public bool errorCheck { get; set; }
        public string errorMessage { get; set; }
        public SearchOptionStation Condition { get; set; }

        //หนังสือขออนุมัติ
        public DashboardsReqApp DashboardsReqApp { get; set; }
        public PaginationView<List<ApprovalReqStationDTO>> TrackingResourceApp { get; set; }
        //สร้างนิติกรรมสัญญา
        public DashboardsContract DashboardsContract { get; set; }
        public PaginationView<List<ContractStationDTO>> TrackingContractResource { get; set; }
        //กำหนดรหัสคู่สัญญา
        public DashboardsVendorLink DashboardsVendorLink { get; set; }
        public PaginationView<List<VendorLinkReqStationDTO>> TrackingVendorLinkResource { get; set; }
        //แก้ไขนิติกรรมหลังผูกพัน
        public DashboardBinding DashboardBinding { get; set; }
        public PaginationView<List<ContractStationSuccessDTO>> TrackingSuccess { get; set; }
    }
}
