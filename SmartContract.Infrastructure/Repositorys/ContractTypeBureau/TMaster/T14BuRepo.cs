using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Interfaces;
using SmartContract.Infrastructure.Interfaces.ContractTypeBureau.TMaster;
using SmartContract.Infrastructure.Resources.ContractTypeBureau;
using SmartContract.Infrastructure.Resources.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Enum;
using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Infrastructure.Wrapper;
using SmartContract.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartContract.Infrastructure.Data.EntityFramework;
using Microsoft.AspNetCore.Http;
using SmartContract.Infrastructure.Resources.ContractTypeBureau.Information;

namespace SmartContract.Infrastructure.Repositorys.ContractTypeBureau.TMaster
{
    public class T14BuRepo : IT14BuRepo
    {
        private IRepositoryWrapper _repo;
        private readonly IRepositoryBase _db;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly AppSettings _mySet;

        public T14BuRepo(IRepositoryWrapper repo, IRepositoryBase db, IMapper mapper, IWebHostEnvironment env, IOptions<AppSettings> settings)
        {
            _repo = repo;
            _db = db;
            _env = env;
            _mapper = mapper;
            _mySet = settings.Value;
        }

        public async Task<TAllMasterVendorView> InitialData(TAllMasterVendorView indata)
        {
            var departmentCode = _repo.UserService.GetDepartmentCode();
            indata.CTVendor.GetLookUp = new LookUpResource()
            {
                SubDomainServer = _mySet.SubDomainServer,
                LKProvinces = await _repo.MasterData.LKProvinces(),
                BankInfos = _repo.MasterData.BankInfos(),
                MasterVendors = await _repo.MasterData.MasterVendor(),
                UserSmctSigner = await _repo.MasterData.UserSmctSigner(),
                Coordinators = await _repo.MasterData.Coordinators(),
                BudgetcodeList = await _repo.MasterData.BudgetcodeList(IsCurrentYear: true),
                CommitteeList = await _repo.MasterData.CommitteeList(),
                NhsoSigner = await _repo.MasterData.NhsoSigner(departmentCode),
                VNhsoEmployeeAll = await _repo.MasterData.VNhsoEmployeeAll(departmentCode: departmentCode)
            };

            string idSmctMaster = indata.ParameterCondition.IdSmctMaster;

            //ข้อมูลฝ่ายคู่สัญญา
            var smctMasters = await _repo.Context.SmctMasters.Include(x => x.IdRegisterNhsoNavigation).Where(x => x.IdSmctMaster == idSmctMaster && x.Used).FirstOrDefaultAsync();
            indata = await _repo.ContractShare.ViewInfoPartnersOfContract(indata, smctMasters.IdRegisterNhsoNavigation.VendorId);

            return indata;
        }

        public async Task<TAllMasterVendorView> GetView(ParameterCondition indata)
        {
            TAllMasterVendorView response = new TAllMasterVendorView()
            {
                ParameterCondition = indata
            };

            await this.InitialData(response);

            //ข้อมูลนิติกรรมสัญญา
            response = await _repo.ContractShareNhso.ViewInfoContract(response);

            //ข้อมูลฝ่าย สปสช. (ผู้มีอำนาจลงนาม)
            response = await _repo.ContractShareNhso.ViewMasterSignerNhso(response);

            //ข้อมูลผู้ลงนาม
            response = await _repo.ContractShare.ViewMasterSigners(response);

            //หนังสือขออนุมัติ
            if (indata.StationReq == ApproveStationStatusAll.S2CreateApprove || indata.StationReq == ApproveStationStatusAll.S3Consider || indata.IsPDF)
            {
                response = await _repo.ContractShareNhso.ViewRequestForApproval(response);
                response = await _repo.ContractShare.ViewApprovalReqStation(response);
            }

            if (indata.IsSentMail || indata.Station != ContractStationStatusAll.S5Signing2 || indata.IsPDF)
            {
                //เงื่อนไขการจ่ายเงิน
                response = await _repo.ContractShareNhso.ViewConditionPayment(response);

                //ข้อมูลรายละเอียดนิติกรรมสัญญา
                response = await this.ViewContractDetail(response);
            }

            if (indata.Station == ContractStationStatusAll.S6ContractNumber)
            {
                response = await _repo.ContractShareNhso.ViewCheckList(response);
            }

            //รายละเอียดไฟล์แนบ
            response = await _repo.ContractShare.ViewMasterFiles(response);

            response = await _repo.ContractShare.ViewContractStation(response);

            return response;
        }

        private async Task<TAllMasterVendorView> ViewContractDetail(TAllMasterVendorView indata)
        {
            var _IdContract = indata.ParameterCondition.IdContract;
            var idSmctMaster = indata.ParameterCondition.IdSmctMaster;
            var contractDetail = await _repo.Context.ContractDetail14s.Where(x => x.IdContract == _IdContract && x.Used).FirstOrDefaultAsync();
            if (contractDetail != null)
            {
                indata.InfoConDetail.ContractDetail14 = _mapper.Map<ContractDetail14DTO>(contractDetail);
                if (contractDetail.P6 != null)
                {
                    indata.InfoConDetail.ContractDetail14.CATMs = _repo.GeneralRepo.GetCATM(contractDetail.P6);
                    if (indata.InfoConDetail.ContractDetail14.CATMs != null)
                    {
                        indata.InfoConDetail.ContractDetail14.P6_ProvinceId_Catm = indata.InfoConDetail.ContractDetail14.CATMs.ProvinceId;
                        indata.InfoConDetail.ContractDetail14.P6_AmphurId_Catm = indata.InfoConDetail.ContractDetail14.CATMs.AmphurId;
                        indata.InfoConDetail.ContractDetail14.P6_DistrictId_Catm = indata.InfoConDetail.ContractDetail14.CATMs.DistrictId;
                    }
                }
                var smctMasterFiles = await _repo.Context.SmctMasterFiles.FirstOrDefaultAsync(x => x.IdSmctMaster == idSmctMaster && x.FileType == "F8" && x.Used);
                if (smctMasterFiles != null)
                {
                    indata.InfoConDetail.ContractDetail14.IdSmctMasterFile = smctMasterFiles.IdSmctMasterFile;
                    indata.InfoConDetail.ContractDetail14.FileName = smctMasterFiles.FileName;
                    indata.InfoConDetail.ContractDetail14.FileFtp = smctMasterFiles.FileFtp;
                }
            }

            return indata;
        }

        public void ValidateBookReq(TAllMasterVendorView indata)
        {
            int btnSubmit = int.Parse(indata.BtnSubmit);

            if (btnSubmit == (int)ButtonState.Forward)
            {
                if (!indata.InfoContract.PayVendorTypeD && !indata.InfoContract.PayVendorTypeI)
                    throw new Exception("ระบุ รูปแบบนิติกรรมสัญญา");
                if (indata.InfoContract.Budgetcodes == null || indata.InfoContract.Budgetcodes.Count == 0)
                {
                    throw new Exception("ระบุ รหัสงบประมาณ");
                }
                else
                {
                    foreach (var item in indata.InfoContract.Budgetcodes)
                    {
                        if (String.IsNullOrEmpty(item.Budgetcode))
                            throw new Exception("ระบุ รหัสงบประมาณไม่ครบ");
                    }
                }
                if (indata.InfoContract.Budget == 0)
                    throw new Exception("ระบุ งบประมาณในการดำเนินการ");
                if (string.IsNullOrEmpty(indata.InfoContract.StartDateStr))
                    throw new Exception("ระบุ วันที่เริ่มต้นสัญญา");
                if (string.IsNullOrEmpty(indata.InfoContract.EndDateStr))
                    throw new Exception("ระบุ วันที่สิ้นสุดสัญญา");
                if (string.IsNullOrEmpty(indata.InfoContract.GuaranteeDay))
                    throw new Exception("ระบุ ระยะเวลารับประกันผลงาน");

                if (string.IsNullOrEmpty(indata.InfoRequestForApproval.ApprovalReqUserChairm))
                    throw new Exception("ระบุ ประธานกรรมการ");
                if (indata.InfoRequestForApproval.Committees == null || indata.InfoRequestForApproval.Committees.Count == 0)
                {
                    throw new Exception("ระบุ กรรมการ");
                }
                else
                {
                    foreach (var item in indata.InfoRequestForApproval.Committees)
                    {
                        if (String.IsNullOrEmpty(item.EmpId))
                            throw new Exception("ระบุ กรรมการไม่ครบ");
                    }
                }

                if (string.IsNullOrEmpty(indata.InfoRequestForApproval.ApprovalReqUser))
                    throw new Exception("ระบุ ลงชื่อผู้ขออนุมัติ");
                if (string.IsNullOrEmpty(indata.InfoRequestForApproval.ApprovalReqUserPos))
                    throw new Exception("ระบุตำแหน่ง");

            }

        }

        public async Task<TAllMasterVendorView> UpdateAsyncBookReq(TAllMasterVendorView indata)
        {
            using (var _transaction = _repo.BeginTransaction())
            {
                int btnSubmit = int.Parse(indata.BtnSubmit);

                if (indata.ParameterCondition.DepartmentCodeCurr == null)
                    indata.ParameterCondition.DepartmentCodeCurr = _repo.UserService.GetDepartmentCode();

                if (indata.ParameterCondition.IdUserSmctCurr == null)
                    indata.ParameterCondition.IdUserSmctCurr = _repo.UserService.GetIdUserSmct();

                if (indata.ParameterCondition.VendorIdCurr == null)
                    indata.ParameterCondition.VendorIdCurr = _repo.UserService.GetVendorId();

                //ข้อมูลนิติกรรมสัญญา ,งบประมาณ
                await _repo.ContractShareNhso.UpdateReqAppContractBudgetCode(indata);

                //ข้อมูลขออนุมัติดำเนินการ ,ประธานกรรมการ ,กรรมการ
                await _repo.ContractShareNhso.UpdateReqAppChairmanBoard(indata);

                //ไฟล์แนบท้าย(ร่าง)นิติกรรม(สำนัก/กองทุนย่อย/เขต)
                await _repo.ContractShareNhso.UpdateReqAppAttachDraftContract(indata, $"T{indata.ParameterCondition.ContractTypeId}");

                //UPDATE STATION
                if (btnSubmit == (int)ButtonState.Forward)
                {
                    await _repo.ContractShareNhso.UpdateStatusBookReqMailStatus(indata);
                }

                indata = await _repo.ContractShare.ViewApprovalReqStation(indata);

                await _transaction.CommitAsync();

                return indata;
            }
        }

        public void ValidateContract(TAllMasterVendorView indata)
        {
            int btnSubmit = int.Parse(indata.BtnSubmit);

            //if (btnSubmit == (int)ButtonState.Forward)
            //{

            var _ConDetail = indata.InfoConDetail.ContractDetail14;
            if (_ConDetail == null)
                throw new Exception("ระบุ รายละเอียดนิติกรรมสัญญา ไม่ครบถ้วน");

            if (String.IsNullOrEmpty(_ConDetail.P1))
                throw new Exception("ระบุ ผู้รับผิดชอบโครงการ");
            if (String.IsNullOrEmpty(_ConDetail.P6_ProvinceId_Catm))
                throw new Exception("ระบุ จังหวัด");
            if (String.IsNullOrEmpty(_ConDetail.P6_AmphurId_Catm))
                throw new Exception("ระบุ อำเภอ");
            if (String.IsNullOrEmpty(_ConDetail.P6_DistrictId_Catm))
                throw new Exception("ระบุ ตำบล");
            if (String.IsNullOrEmpty(_ConDetail.P7))
                throw new Exception("ระบุ รหัสไปรษณีย์");

            if (String.IsNullOrEmpty(_ConDetail.P13))
                throw new Exception("ระบุ 1.หลักการและเหตุผล");

            if (String.IsNullOrEmpty(_ConDetail.P27))
                throw new Exception("ระบุ 14.ผู้เห็นชอบโครงการ");
            if (String.IsNullOrEmpty(_ConDetail.P32))
                throw new Exception("ระบุ 15.ผู้อนุมัติโครงการ");

            _repo.ContractShareNhso.ValidateConditionPayment(indata);
        }

        public async Task<TAllMasterVendorView> UpdateAsyncContract(TAllMasterVendorView indata)
        {
            using (var _transaction = _repo.BeginTransaction())
            {
                int btnSubmit = int.Parse(indata.BtnSubmit);
                String idSmctMaster = indata.ParameterCondition.IdSmctMaster;
                String idUserSmct = _repo.UserService.GetIdUserSmct();

                //ข้อมูลฝ่าย สปสช. (ผู้มีอำนาจลงนาม) ,ข้อมูลผู้ลงนาม
                await _repo.ContractShareNhso.UpdateMasterSigners(indata);

                //ข้อมูลรายละเอียดนิติกรรมสัญญา
                await this.UpdateContractDetail(indata);

                // เงื่อนไขการจ่ายเงิน
                await _repo.ContractShareNhso.UpdateConditionPayment(indata);

                //ไฟล์แนบท้าย(ร่าง)นิติกรรม(สำนัก/กองทุนย่อย/เขต)
                await _repo.ContractShareNhso.UpdateReqAppAttachDraftContract(indata, $"T{indata.ParameterCondition.ContractTypeId}");

                //UPDATE STATION
                if (btnSubmit == (int)ButtonState.Forward)
                {
                    await _repo.ContractShareNhso.UpdateStatusContract(indata);
                }
                if (btnSubmit == (int)ButtonState.T1_EDIT)
                {
                    await _repo.ContractShareNhso.UpdateRequestBinding(indata);
                }

                //ผู้บันทึกล่าสสุด
                await _repo.ContractShareNhso.UpdateContractEditLast(indata);

                _transaction.Commit();

                return indata;
            }
        }

        private async Task UpdateContractDetail(TAllMasterVendorView indata)
        {
            var _ParameterCon = indata.ParameterCondition;
            String idSmctMaster = indata.ParameterCondition.IdSmctMaster;
            String idUserSmct = _repo.UserService.GetIdUserSmct();

            var _Contract = await _repo.Context.Contracts.Where(x => x.IdSmctMaster == idSmctMaster && x.Used).FirstOrDefaultAsync();
            if (_Contract != null)
            {
                var _ContractDetail = indata.InfoConDetail.ContractDetail14;

                if (_ContractDetail.P6_ProvinceId_Catm == "00000") _ContractDetail.P6_ProvinceId_Catm = "00";
                if (_ContractDetail.P6_AmphurId_Catm == "00000") _ContractDetail.P6_AmphurId_Catm = "00";
                if (_ContractDetail.P6_DistrictId_Catm == "00000") _ContractDetail.P6_DistrictId_Catm = "00";

                String _Catm = $"{_ContractDetail.P6_ProvinceId_Catm}{_ContractDetail.P6_AmphurId_Catm}{_ContractDetail.P6_DistrictId_Catm}{"00"}";

                var contractDetail = await _repo.Context.ContractDetail14s.Where(x => x.IdContract == _Contract.IdContract && x.Used).FirstOrDefaultAsync();
                if (contractDetail != null)
                {
                    _mapper.Map(_ContractDetail, contractDetail);
                    contractDetail.P6 = _Catm;
                    contractDetail.EditUser = idUserSmct;
                    contractDetail.EditDate = DateTime.Now;
                    _db.Update(contractDetail);
                    await _db.SaveAsync();
                }
                else
                {
                    contractDetail = _mapper.Map<ContractDetail14>(_ContractDetail);
                    contractDetail.P6 = _Catm;
                    contractDetail.IdContract = _Contract.IdContract;
                    contractDetail.CreateUser = idUserSmct;
                    contractDetail.CreateDate = DateTime.Now;
                    contractDetail.EditUser = idUserSmct;
                    contractDetail.EditDate = DateTime.Now;
                    contractDetail.Used = true;
                    await _db.InsterAsync(contractDetail);
                    await _db.SaveAsync();
                }

                //เอกสารเพิ่มเติม

                if (_ContractDetail != null && _ContractDetail.FormFile != null)
                {
                    var smctMasterFileRemove = _repo.Context.SmctMasterFiles.Where(x => x.IdSmctMaster == idSmctMaster && x.FileType == "F8").ToList();
                    if (smctMasterFileRemove.Count > 0)
                    {
                        _db.DeleteRange(smctMasterFileRemove);
                        await _repo.SaveAsync();
                    }

                    String thaiYear = GeneralUtils.getThaiYear(DateTime.Now.Year);
                    var fileFTP = _repo.UploadFiles.GenFileName(_ContractDetail.FormFile, _ParameterCon.RefId, $"FILE_{_ParameterCon.ContractTypeId}_Additional");

                    var smctMasterFile = _repo.Context.SmctMasterFiles.FirstOrDefault(x => x.IdSmctMaster == idSmctMaster && x.IdSmctMasterFile == _ContractDetail.IdSmctMasterFile);
                    if (smctMasterFile != null)
                    {
                        smctMasterFile.FileNo = 1;
                        smctMasterFile.EditUser = idUserSmct;
                        smctMasterFile.EditDate = DateTime.Now;
                        smctMasterFile.PathFolder = thaiYear;
                        _db.Update(smctMasterFile);
                        await _db.SaveAsync();
                    }
                    else
                    {
                        smctMasterFile = new SmctMasterFile()
                        {
                            IdSmctMaster = idSmctMaster,
                            FileType = "F8",
                            FileName = _ContractDetail.FormFile.FileName,
                            FileFtp = fileFTP,
                            CreateUser = idUserSmct,
                            EditUser = idUserSmct,
                            CreateDate = DateTime.Now,
                            EditDate = DateTime.Now,
                            FileNo = 1,
                            Used = true,
                            PathFolder = thaiYear
                        };
                        await _db.InsterAsync(smctMasterFile);
                        await _db.SaveAsync();
                    }

                    String PathFolder = $"Attach/T{_ParameterCon.ContractTypeId}/{thaiYear}";
                    this.HandleUploadfile(_ContractDetail.FormFile, fileFTP, PathFolder);
                }

            }
        }

        private void HandleUploadfile(IFormFile FormFile, String fileFTP, String folderName)
        {
            //UploadFilesResource saveFile = new UploadFilesResource()
            //{
            //    Files = new List<IFormFile> { FormFile },
            //    ContentRootPath = _env.ContentRootPath,
            //    SubDirectory = @$"wwwroot\files\{folderName}\",
            //    FileNameServer = fileFTP
            //};

            //await _repo.UploadFiles.SaveFile(saveFile);
            //return saveFile;
            _repo.UploadFiles.FTPSaveFile(FormFile, fileFTP, folderName);
        }

    }
}
