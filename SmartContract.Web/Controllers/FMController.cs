using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Resources.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Infrastructure.Wrapper;

namespace SmartContract.Web.Controllers
{

    public class FMController : Controller
    {
        private IRepositoryWrapper _repo;
        private readonly AppSettings _mySet;
        private readonly IWebHostEnvironment _env;

        public FMController(IRepositoryWrapper repo, IOptions<AppSettings> settings, IWebHostEnvironment env)
        {
            _repo = repo;
            _env = env;
            _mySet = settings.Value;
        }

        public IActionResult FM_403_02_01()
        {
            return View();
        }
        public IActionResult FM_403_02_02()
        {
            return View();
        }
        public IActionResult FM_403_02_03()
        {
            return View();
        }

        //หนังสือขออนุมัติ 
        public async Task<IActionResult> FM_APPROVAL_REQ(ParameterCondition indata)
        {
            TAllMasterVendorView response = new TAllMasterVendorView();

            if (indata.ContractTypeId == "11") response = await _repo.T11BuRepo.GetView(indata);
            if (indata.ContractTypeId == "12") response = await _repo.T12BuRepo.GetView(indata);
            if (indata.ContractTypeId == "13") response = await _repo.T13BuRepo.GetView(indata);
            if (indata.ContractTypeId == "14") response = await _repo.T14BuRepo.GetView(indata);
           
            return View(response);
        }

        //T01 นิติกรรม สัญญาให้บริการสาธารณสุข
        public async Task<IActionResult> FM_CONTRACT_T01(ParameterCondition indata)
        {
            var response = await _repo.T01BuRepo.GetView(indata);
            return View(response);
        }
        //T02 นิติกรรม ข้อตกลงให้บริการสาธารณสุขฯ
        public async Task<IActionResult> FM_CONTRACT_T02(ParameterCondition indata)
        {
            var response = await _repo.T02BuRepo.GetView(indata);
            return View(response);
        }
        //T03 นิติกรรม สัญญาให้บริการฯ(ศูนย์สำรองเตียง)
        public async Task<IActionResult> FM_CONTRACT_T03(ParameterCondition indata)
        {
            var response = await _repo.T03BuRepo.GetView(indata);
            return View(response);
        }
        //T04 นิติกรรม สัญญาให้บริการฯ(ศูนย์สำรองเตียง)เฉพาะด้าน
        public async Task<IActionResult> FM_CONTRACT_T04(ParameterCondition indata)
        {
            var response = await _repo.T04BuRepo.GetView(indata);
            return View(response);
        }
        //T05 นิติกรรม ข้อตกลงกองทุนฟื้นฟูฯจังหวัด
        public async Task<IActionResult> FM_CONTRACT_T05(ParameterCondition indata)
        {
            var response = await _repo.T05BuRepo.GetView(indata);
            return View(response);
        }
        //T06 นิติกรรม สัญญาให้บริการสาธารณสุขตามกิจกรรมบริการ
        public async Task<IActionResult> FM_CONTRACT_T06(ParameterCondition indata)
        {
            var response = await _repo.T06BuRepo.GetView(indata);
            return View(response);
        }
        //T07 นิติกรรม ข้อตกลงให้บริการฯตามกิจกรรมบริการ
        public async Task<IActionResult> FM_CONTRACT_T07(ParameterCondition indata)
        {
            var response = await _repo.T07BuRepo.GetView(indata);
            return View(response);
        }
        //T08 นิติกรรม สัญญาให้บริการสาธารณสุขตามกิจกรรมบริการ ไตเทียม
        public async Task<IActionResult> FM_CONTRACT_T08(ParameterCondition indata)
        {
            var response = await _repo.T08BuRepo.GetView(indata);
            return View(response);
        }
        //T09 นิติกรรม ข้อตกลงให้บริการฯตามกิจกรรมบริการ ไตเทียม
        public async Task<IActionResult> FM_CONTRACT_T09(ParameterCondition indata)
        {
            var response = await _repo.T09BuRepo.GetView(indata);
            return View(response);
        }
        //T10 นิติกรรม ข้อตกลง (อปท.)
        public async Task<IActionResult> FM_CONTRACT_T10(ParameterCondition indata)
        {
            var response = await _repo.T10BuRepo.GetView(indata);
            return View(response);
        }
        //T11 นิติกรรม สัญญาดำเนินงานตามโครงการ
        public async Task<IActionResult> FM_CONTRACT_T11(ParameterCondition indata)
        {
            var response = await _repo.T11BuRepo.GetView(indata);

            return View(response);
        }

        //T12 นิติกรรม ข้อตกลงดำเนินการตามโครงการ
        public async Task<IActionResult> FM_CONTRACT_T12(ParameterCondition indata)
        {
            var response = await _repo.T12BuRepo.GetView(indata);
            return View(response);
        }
        //T13 นิติกรรม หนังสือแสดงความจำนง
        public async Task<IActionResult> FM_CONTRACT_T13(ParameterCondition indata)
        {
            var response = await _repo.T13BuRepo.GetView(indata);
            return View(response);
        }
        //T14 นิติกรรม โครงการ
        public async Task<IActionResult> FM_CONTRACT_T14(ParameterCondition indata)
        {
            var response = await _repo.T14BuRepo.GetView(indata);
            return View(response);
        }
        //
        //เงื่อนไขการจ่ายเงิน(งวดเดียว100%)
        public async Task<IActionResult> FM_PAY_P1(ParameterCondition indata)
        {
            TAllMasterVendorView response = new TAllMasterVendorView();
            if (indata.ContractTypeId == "10") response = await _repo.T10BuRepo.GetView(indata);
            if (indata.ContractTypeId == "11") response = await _repo.T11BuRepo.GetView(indata);
            if (indata.ContractTypeId == "12") response = await _repo.T12BuRepo.GetView(indata);
            if (indata.ContractTypeId == "13") response = await _repo.T13BuRepo.GetView(indata);
            if (indata.ContractTypeId == "14") response = await _repo.T14BuRepo.GetView(indata);

            return View(response);
        }

        //เงื่อนไขการจ่ายเงิน(งวดเดียวตัดจ่ายหลายครั้ง)
        public async Task<IActionResult> FM_PAY_P2(ParameterCondition indata)
        {
            TAllMasterVendorView response = new TAllMasterVendorView();
            if (indata.ContractTypeId == "10") response = await _repo.T10BuRepo.GetView(indata);
            if (indata.ContractTypeId == "11") response = await _repo.T11BuRepo.GetView(indata);
            if (indata.ContractTypeId == "12") response = await _repo.T12BuRepo.GetView(indata);
            if (indata.ContractTypeId == "13") response = await _repo.T13BuRepo.GetView(indata);
            if (indata.ContractTypeId == "14") response = await _repo.T14BuRepo.GetView(indata);
            return View(response);
        }

        //เงื่อนไขการจ่ายเงิน(ตัดจ่ายหลายงวด)
        public async Task<IActionResult> FM_PAY_P3(ParameterCondition indata)
        {
            TAllMasterVendorView response = new TAllMasterVendorView();
            if (indata.ContractTypeId == "10") response = await _repo.T10BuRepo.GetView(indata);
            if (indata.ContractTypeId == "11") response = await _repo.T11BuRepo.GetView(indata);
            if (indata.ContractTypeId == "12") response = await _repo.T12BuRepo.GetView(indata);
            if (indata.ContractTypeId == "13") response = await _repo.T13BuRepo.GetView(indata);
            if (indata.ContractTypeId == "14") response = await _repo.T14BuRepo.GetView(indata);
            return View(response);
        }

        public async Task<IActionResult> Footer(ParameterCondition indata)
        {
            var response = new TAllMasterVendorView()
            {
                ParameterCondition = indata
            };

            response.CTVendor.GetLookUp = new LookUpResource()
            {
                UserSmctSigner = await _repo.MasterData.UserSmctSigner(),
                NhsoSigner = await _repo.MasterData.NhsoSigner()
            };

            response = await _repo.ContractShareNhso.ViewInfoContract(response);
            response = await _repo.ContractShare.ViewMasterSigners(response);

            return View(response);
        }

    }
}
