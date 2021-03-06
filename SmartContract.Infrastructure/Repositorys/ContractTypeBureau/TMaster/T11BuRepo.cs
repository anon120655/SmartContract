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
	public class T11BuRepo : IT11BuRepo
	{
		private IRepositoryWrapper _repo;
		private readonly IRepositoryBase _db;
		private readonly IMapper _mapper;
		private readonly IWebHostEnvironment _env;
		private readonly AppSettings _mySet;

		public T11BuRepo(IRepositoryWrapper repo, IRepositoryBase db, IMapper mapper, IWebHostEnvironment env, IOptions<AppSettings> settings)
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
			if (indata.StationReq == ApproveStationStatusAll.S2CreateApprove || indata.StationReq == ApproveStationStatusAll.S3Consider || indata.IsPDF || indata.IsSentMail)
			{
				response = await _repo.ContractShareNhso.ViewRequestForApproval(response);
				response = await _repo.ContractShare.ViewApprovalReqStation(response);
			}

			if (indata.IsSentMail || indata.Station != ContractStationStatusAll.S5Signing2 || indata.IsPDF)
			{
				//ข้อมูลหลักประกันสัญญา
				response = await _repo.ContractShare.ViewGuaranteeContract(response);

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
			var contractDetail = await _repo.Context.ContractDetail11s.Where(x => x.IdContract == _IdContract && x.Used).FirstOrDefaultAsync();
			if (contractDetail != null)
			{
				indata.InfoConDetail.ContractDetail11 = contractDetail;
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

			if (String.IsNullOrEmpty(indata.InfoContractNhso.EmpId))
				throw new Exception("ระบุ ผู้มีอำนาจลงนาม ฝ่าย สปสช.");

			//ข้อมูลหลักประกันสัญญา
			_repo.ContractShare.ValidateGuaranteeContract(indata);

			//ข้อมูลผู้ลงนาม
			if (String.IsNullOrEmpty(indata.InfoSignerPartnersOfContract.NhsoWitnessUser))
				throw new Exception("ระบุ พยาน (ฝ่ายสำนักงาน)");
			if (indata.InfoSignerPartnersOfContract.FootNotesNhso == null || indata.InfoSignerPartnersOfContract.FootNotesNhso.Count == 0)
			{
				throw new Exception("ระบุ Foot Note (ฝ่ายสำนักงาน)");
			}
			else
			{
				foreach (var item in indata.InfoSignerPartnersOfContract.FootNotesNhso)
				{
					if (String.IsNullOrEmpty(item.EmpId))
						throw new Exception("ระบุ Foot Note (ฝ่ายสำนักงาน)ไม่ครบถ้วน");
				}
			}

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

				//กรณีทำหลักประกันสัญญา
				await _repo.ContractShare.UpdateGuaranteeContract(indata);

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
			String idSmctMaster = indata.ParameterCondition.IdSmctMaster;
			String idUserSmct = _repo.UserService.GetIdUserSmct();

			var _Contract = await _repo.Context.Contracts.Where(x => x.IdSmctMaster == idSmctMaster && x.Used).FirstOrDefaultAsync();
			if (_Contract != null)
			{
				var _ContractDetail = indata.InfoConDetail.ContractDetail11;
				var contractDetail = await _repo.Context.ContractDetail11s.Where(x => x.IdContract == _Contract.IdContract && x.Used).FirstOrDefaultAsync();
				if (contractDetail != null)
				{
					//contractDetail.P1 = _ContractDetail.P1;
					//contractDetail.P2 = _ContractDetail.P2;
					//contractDetail.P3 = _ContractDetail.P3;
					//contractDetail.P4 = _ContractDetail.P4;
					//contractDetail.P5 = _ContractDetail.P5;
					//contractDetail.P6 = _ContractDetail.P6;
					//contractDetail.P7 = _ContractDetail.P7;
					contractDetail.A1 = _ContractDetail.A1;
					contractDetail.A2 = _ContractDetail.A2;
					contractDetail.A3 = _ContractDetail.A3;
					contractDetail.A4 = _ContractDetail.A4;
					contractDetail.A5 = _ContractDetail.A5;
					contractDetail.A6 = _ContractDetail.A6;
					contractDetail.A7 = _ContractDetail.A7;
					contractDetail.A8 = _ContractDetail.A8;
					contractDetail.A9 = _ContractDetail.A9;
					contractDetail.A10 = _ContractDetail.A10;
					contractDetail.A11 = _ContractDetail.A11;
					contractDetail.A12 = _ContractDetail.A12;
					contractDetail.A13 = _ContractDetail.A13;
					contractDetail.A14 = _ContractDetail.A14;
					contractDetail.A15 = _ContractDetail.A15;
					contractDetail.A16 = _ContractDetail.A16;
					contractDetail.A17 = _ContractDetail.A17;
					contractDetail.EditUser = idUserSmct;
					contractDetail.EditDate = DateTime.Now;
					_db.Update(contractDetail);
					await _db.SaveAsync();
				}
				else
				{
					contractDetail = _ContractDetail;
					contractDetail.IdContract = _Contract.IdContract;
					contractDetail.CreateUser = idUserSmct;
					contractDetail.CreateDate = DateTime.Now;
					contractDetail.EditUser = idUserSmct;
					contractDetail.EditDate = DateTime.Now;
					contractDetail.Used = true;
					await _db.InsterAsync(contractDetail);
					await _db.SaveAsync();
				}
			}
		}

	}
}
