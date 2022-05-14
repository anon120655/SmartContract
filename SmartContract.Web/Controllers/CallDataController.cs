using Microsoft.AspNetCore.Mvc;
using SmartContract.Infrastructure.Data.EntityFramework;
using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Registers;
using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Infrastructure.Resources.Share.ServiceOther;
using SmartContract.Infrastructure.Wrapper;
using SmartContract.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartContract.Web.Controllers
{
    public class CallDataController : Controller
    {
        private IRepositoryWrapper _repo;

        public CallDataController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> LKAmphurs(string provinceId = null)
        {
            try
            {
                var response = await _repo.MasterData.LKAmphurs(provinceId);
                return Json(new ResultModelJson<IEnumerable<LkAmphur>>
                {
                    Status = true,
                    Result = response
                });
            }
            catch (Exception ex)
            {
                return Json(new ResultModelJson<Boolean>
                {
                    Status = false,
                    MessagError = GeneralUtils.GetExMessage(ex)
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> LKDistricts(string code = null)
        {
            try
            {
                var response = await _repo.MasterData.LKDistricts(code);
                return Json(new ResultModelJson<IEnumerable<LkDistrict>>
                {
                    Status = true,
                    Result = response
                });
            }
            catch (Exception ex)
            {
                return Json(new ResultModelJson<Boolean>
                {
                    Status = false,
                    MessagError = GeneralUtils.GetExMessage(ex)
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> ServiceUnits(string hcode = null, String nhsoZone = null)
        {
            try
            {
                var response = await _repo.MasterData.ServiceUnits(hcode: hcode, nhsoZone: nhsoZone);
                return Json(new ResultModelJson<IEnumerable<ViewHraRegisterDTO>>
                {
                    Status = true,
                    Result = response
                });
            }
            catch (Exception ex)
            {
                return Json(new ResultModelJson<Boolean>
                {
                    Status = false,
                    MessagError = GeneralUtils.GetExMessage(ex)
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> MasterVendor(string vendorId = null, string hcode = null, String nhsoZone = null)
        {
            try
            {
                var response = await _repo.MasterData.MasterVendor(vendorId: vendorId, hcode: hcode, nhsoZone: nhsoZone);
                return Json(new ResultModelJson<IEnumerable<VMasterVendorDTO>>
                {
                    Status = true,
                    Result = response
                });
            }
            catch (Exception ex)
            {
                return Json(new ResultModelJson<Boolean>
                {
                    Status = false,
                    MessagError = GeneralUtils.GetExMessage(ex)
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetAttachSystem(string hcode = null)
        {
            try
            {
                var response = await _repo.MasterData.GetAttachSystem(hcode: hcode);
                return Json(new ResultModelJson<IEnumerable<FileSystemDTO>>
                {
                    Status = true,
                    Result = response
                });
            }
            catch (Exception ex)
            {
                return Json(new ResultModelJson<Boolean>
                {
                    Status = false,
                    MessagError = GeneralUtils.GetExMessage(ex)
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CheckListHistory(string ChecklistId, string IdContractType)
        {
            try
            {
                var response = await _repo.ContractShareNhso.CheckListHistory(ChecklistId, IdContractType);
                return Json(new ResultModelJson<ContractSbbCklDTO>
                {
                    Status = true,
                    Result = response
                });
            }
            catch (Exception ex)
            {
                return Json(new ResultModelJson<Boolean>
                {
                    Status = false,
                    MessagError = GeneralUtils.GetExMessage(ex)
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> CheckSignature(string idSmctMaster, string SendmailType)
        {
            try
            {
                var response = await _repo.ContractShare.CheckSignature(idSmctMaster, SendmailType);
                return Json(new ResultModelJson<bool>
                {
                    Status = true,
                    Result = response
                });
            }
            catch (Exception ex)
            {
                return Json(new ResultModelJson<Boolean>
                {
                    Status = false,
                    MessagError = GeneralUtils.GetExMessage(ex)
                });
            }
        }


        [HttpPost]
        public async Task<IActionResult> eLGDocumentSearch(string lgNumber)
        {
            try
            {
                var response = await _repo.ServiceOther.eLGDocumentSearch(new eLGDocumentSearchRequest()
                {                    
                    lgNumber = lgNumber
                });

                return Json(new ResultModelJson<eLGDocumentSearchResponse>
                {
                    Status = true,
                    Result = response
                });
            }
            catch (Exception ex)
            {
                return Json(new ResultModelJson<Boolean>
                {
                    Status = false,
                    MessagError = GeneralUtils.GetExMessage(ex)
                });
            }




        }

    }
}
