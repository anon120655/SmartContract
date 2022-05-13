﻿using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Interfaces;
using SmartContract.Infrastructure.Interfaces.ContractTypeBureau;
using SmartContract.Infrastructure.Resources.ContractTypeBureau;
using SmartContract.Infrastructure.Resources.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Infrastructure.Wrapper;
using SmartContract.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Repositorys.ContractTypeBureau
{
    public class GuaranteeRepo : IGuaranteeRepo
    {

        private IRepositoryWrapper _repo;
        private readonly IRepositoryBase _db;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly AppSettings _mySet;

        public GuaranteeRepo(IRepositoryWrapper repo, IRepositoryBase db, IMapper mapper, IWebHostEnvironment env, IOptions<AppSettings> settings)
        {
            _repo = repo;
            _db = db;
            _env = env;
            _mapper = mapper;
            _mySet = settings.Value;
        }

        public string SetUrlRedirect(TAllMasterVendorView indata)
        {
            String UrlRedirect = String.Empty;

            UrlRedirect = $"{_mySet.SubDomainServer}/Guarantee/Tracking?Menuen={indata.ParameterCondition.ContractGuaranteeTypeEn}";

            return UrlRedirect;
        }

        public IEnumerable<ContractStationGuaranteeDTO> GetList(SearchOptionStation condition = null)
        {
            var response = new List<ContractStationGuaranteeDTO>();

            var contractStationGuarantees = _repo.Context.ContractStationGuarantees.Where(x => x.Used).OrderByDescending(x => x.ContractGuaranteeEditDate);

            if (condition != null)
            {
                if (!String.IsNullOrEmpty(condition.MenuEn))
                {
                    String _Menu = SecurityRepo.Decrypt(condition.MenuEn);
                    contractStationGuarantees = contractStationGuarantees.Where(x => x.ContractGuaranteeType == _Menu).OrderByDescending(x => x.ContractGuaranteeEditDate);
                }
            }

            response = _mapper.Map<List<ContractStationGuaranteeDTO>>(contractStationGuarantees);

            return response;
        }

        public PaginationView<List<ContractStationGuaranteeDTO>> GetTrackingGuaranteeNew(int? page, int pageSize, SearchOptionStation condition = null)
        {
            IEnumerable<ContractStationGuaranteeDTO> queryMap = null;

            queryMap = this.GetList(condition);

            var pager = new Pager(queryMap.Count(), page, pageSize, condition);
            pager.UrlAction = $"{_mySet.SubDomainServer}/{condition.PathUrlAction}";

            var itemss = queryMap.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);

            var response = new PaginationView<List<ContractStationGuaranteeDTO>>()
            {
                Items = itemss.ToList(),
                Pager = pager
            };

            return response;
        }

        public void Validate(TAllMasterVendorView indata)
        {
            //ข้อมูลหลักประกันสัญญา
            _repo.ContractShare.ValidateGuaranteeContract(indata);
        }

        public async Task<TAllMasterVendorView> UpdateReNewAsync(TAllMasterVendorView indata)
        {
            using (var _transaction = _repo.BeginTransaction())
            {
                var _ParameterCon = indata.ParameterCondition;

                await _repo.ContractShare.UpdateGuaranteeContract(indata);

                var contractStationGuarantees = _repo.Context.ContractStationGuarantees.FirstOrDefault(x => x.IdSmctMaster == _ParameterCon.IdSmctMaster);
                contractStationGuarantees.ContractGuaranteeType = SecurityRepo.Decrypt(indata.ParameterCondition.ContractGuaranteeTypeEn);
                contractStationGuarantees.ContractGuaranteeEditUser = _ParameterCon.IdUserSmctCurr;
                contractStationGuarantees.ContractGuaranteeEditDate = DateTime.Now;
                _db.Update(contractStationGuarantees);
                await _db.SaveAsync();

                _transaction.Commit();

                return indata;
            }
        }

        public async Task<TAllMasterVendorView> UpdateReturnAsync(TAllMasterVendorView indata)
        {
            using (var _transaction = _repo.BeginTransaction())
            {
                var _ParameterCon = indata.ParameterCondition;

                await _repo.ContractShare.UpdateGuaranteeContract(indata);

                var contractStationGuarantees = _repo.Context.ContractStationGuarantees.FirstOrDefault(x => x.IdSmctMaster == _ParameterCon.IdSmctMaster);
                contractStationGuarantees.ContractGuaranteeType = SecurityRepo.Decrypt(indata.ParameterCondition.ContractGuaranteeTypeEn);
                contractStationGuarantees.ContractGuaranteeEditUser = _ParameterCon.IdUserSmctCurr;
                contractStationGuarantees.ContractGuaranteeEditDate = DateTime.Now;
                _db.Update(contractStationGuarantees);
                await _db.SaveAsync();

                _transaction.Commit();

                return indata;
            }
        }

        public async Task<TAllMasterVendorView> UpdateClaimAsync(TAllMasterVendorView indata)
        {
            using (var _transaction = _repo.BeginTransaction())
            {
                var _ParameterCon = indata.ParameterCondition;

                await _repo.ContractShare.UpdateGuaranteeContract(indata);

                _transaction.Commit();

                return indata;
            }
        }

        public async Task<List<GuaranteeReportView>> GuaranteeReportView(SearchOptionGuarantee Condition = null)
        {
            List<GuaranteeReportView> response = new List<GuaranteeReportView>();

            string[] Dcodes = { "03000", "03100", "03200", "03300", "03400", "03500", "03600", "03700", "03800", "03900", "04000", "04100", "04200" };

            var StationGuarantees = _repo.Context.ContractStationGuarantees.Where(x => x.Used);

            if (Condition != null)
            {
                if (!String.IsNullOrEmpty(Condition.Year))
                    StationGuarantees = StationGuarantees.Where(x => x.Budgetyear == Condition.Year);
                if (!String.IsNullOrEmpty(Condition.Month))
                {
                    int _Month = int.Parse(Condition.Month);
                    StationGuarantees = StationGuarantees.Where(x => x.ContractGuaranteeEditDate.Month == _Month);
                }
            }


            var LkDepartments = _repo.Context.LkDepartments.Where(x => x.Display == "Y" && x.Dcode != null && Dcodes.Contains(x.Dcode)).OrderBy(x => x.Dcode).ToList();
            foreach (var item in LkDepartments)
            {
                var queryCount = await StationGuarantees.Where(x => x.DepartmentCode == item.Dcode).GroupBy(s => s.ContractGuaranteeType)
                        .Select(grp => new
                        {
                            ContractGuaranteeType = grp.Key,
                            ContractGuaranteeTypeCount = grp.Count()
                        }).ToListAsync();

                response.Add(new Resources.ContractTypeBureau.GuaranteeReportView()
                {
                    Dcode = item.Dcode,
                    DnameNew = item.DnameNew,
                    NewCount = queryCount.FirstOrDefault(x => x.ContractGuaranteeType == ContractGuaranteeTypes.T1_NEW)?.ContractGuaranteeTypeCount ?? 0,
                    ReNewCount = queryCount.FirstOrDefault(x => x.ContractGuaranteeType == ContractGuaranteeTypes.T2_RENEW)?.ContractGuaranteeTypeCount ?? 0,
                    ReturnCount = queryCount.FirstOrDefault(x => x.ContractGuaranteeType == ContractGuaranteeTypes.T3_RETURN)?.ContractGuaranteeTypeCount ?? 0,
                    ClaimCount = queryCount.FirstOrDefault(x => x.ContractGuaranteeType == ContractGuaranteeTypes.T4_CLAIM)?.ContractGuaranteeTypeCount ?? 0
                });
            }

            return response;
        }

    }
}
