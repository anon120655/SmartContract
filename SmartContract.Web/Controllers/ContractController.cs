using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SmartContract.Web.Controllers
{
   
    public class ContractController : Controller
    {
        #region แก้ไขข้อมูลสัญญา
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult EditTracking()
        {
            return View();
        }
        public IActionResult EditReport()
        {
            return View();
        }
        public IActionResult EditReport_Detail()
        {
            return View();
        }
        public IActionResult EditContract()
        {
            return View();
        }
        #endregion

        #region ยกเลิกข้อมูลสัญญา
        public IActionResult Cancel()
        {
            return View();
        }
        public IActionResult CancelTracking()
        {
            return View();
        }
        public IActionResult CancelReport()
        {
            return View();
        }
        public IActionResult CancelReportDetail()
        {
            return View();
        }
        public IActionResult CancelContract()
        {
            return View();
        }
        #endregion

        #region ขยายสัญญา
        public IActionResult Extend()
        {
            return View();
        }
        public IActionResult ExtendTracking()
        {
            return View();
        }
        public IActionResult ExtendReport()
        {
            return View();
        }
        public IActionResult ExtendReportDetail()
        {
            return View();
        }
        public IActionResult ExtendContract()
        {
            return View();
        }
        #endregion

        #region ปิดโครงการ
        public IActionResult CloseProject()
        {
            return View();
        }
        public IActionResult CloseProjectTracking()
        {
            return View();
        }
        public IActionResult CloseProjectReport()
        {
            return View();
        }
        public IActionResult CloseProjectReportDetail()
        {
            return View();
        }
        public IActionResult CloseProjectContract()
        {
            return View();
        }
        #endregion

        #region ยุติสัญญา
        public IActionResult Terminate()
        {
            return View();
        }
        public IActionResult TerminateTracking()
        {
            return View();
        }
        public IActionResult TerminateReport()
        {
            return View();
        }
        public IActionResult TerminateReportDetail()
        {
            return View();
        }
        public IActionResult TerminateContract()
        {
            return View();
        }
        #endregion

        #region แนบไฟล์
        public IActionResult AttachFile()
        {
            return View();
        }
        public IActionResult AttachFileSuccess()
        {
            return View();
        }
        public IActionResult AttachFileDocument()
        {
            return View();
        }
        #endregion
    }
}
