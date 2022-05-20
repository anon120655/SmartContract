using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SmartContract.Infrastructure.Data.EntityFramework;

#nullable disable

namespace SmartContract.Infrastructure.Data.ConnectionContext
{
    public partial class smartContractContext : DbContext
    {
        public smartContractContext()
        {
        }

        public smartContractContext(DbContextOptions<smartContractContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApprovalReq> ApprovalReqs { get; set; }
        public virtual DbSet<ApprovalReqStation> ApprovalReqStations { get; set; }
        public virtual DbSet<BudgetcodeView> BudgetcodeViews { get; set; }
        public virtual DbSet<BudgetcodeViewTab> BudgetcodeViewTabs { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<ContractDetail01> ContractDetail01s { get; set; }
        public virtual DbSet<ContractDetail02> ContractDetail02s { get; set; }
        public virtual DbSet<ContractDetail03> ContractDetail03s { get; set; }
        public virtual DbSet<ContractDetail04> ContractDetail04s { get; set; }
        public virtual DbSet<ContractDetail05> ContractDetail05s { get; set; }
        public virtual DbSet<ContractDetail06> ContractDetail06s { get; set; }
        public virtual DbSet<ContractDetail07> ContractDetail07s { get; set; }
        public virtual DbSet<ContractDetail08> ContractDetail08s { get; set; }
        public virtual DbSet<ContractDetail09> ContractDetail09s { get; set; }
        public virtual DbSet<ContractDetail10> ContractDetail10s { get; set; }
        public virtual DbSet<ContractDetail11> ContractDetail11s { get; set; }
        public virtual DbSet<ContractDetail12> ContractDetail12s { get; set; }
        public virtual DbSet<ContractDetail13> ContractDetail13s { get; set; }
        public virtual DbSet<ContractDetail14> ContractDetail14s { get; set; }
        public virtual DbSet<ContractExtend> ContractExtends { get; set; }
        public virtual DbSet<ContractGuarantee> ContractGuarantees { get; set; }
        public virtual DbSet<ContractGuaranteeDetail> ContractGuaranteeDetails { get; set; }
        public virtual DbSet<ContractPeriod> ContractPeriods { get; set; }
        public virtual DbSet<ContractPeriodDetail> ContractPeriodDetails { get; set; }
        public virtual DbSet<ContractPlan> ContractPlans { get; set; }
        public virtual DbSet<ContractSbbCkl> ContractSbbCkls { get; set; }
        public virtual DbSet<ContractSbbCklDetail> ContractSbbCklDetails { get; set; }
        public virtual DbSet<ContractSbbCklHeading> ContractSbbCklHeadings { get; set; }
        public virtual DbSet<ContractStation> ContractStations { get; set; }
        public virtual DbSet<ContractStationGuarantee> ContractStationGuarantees { get; set; }
        public virtual DbSet<ContractStationSuccess> ContractStationSuccesses { get; set; }
        public virtual DbSet<ContractStyle> ContractStyles { get; set; }
        public virtual DbSet<ContractType> ContractTypes { get; set; }
        public virtual DbSet<ContractVendor> ContractVendors { get; set; }
        public virtual DbSet<EContractViewRpt1Mo> EContractViewRpt1Mos { get; set; }
        public virtual DbSet<EContractWebUser> EContractWebUsers { get; set; }
        public virtual DbSet<EmDepartmentAddress> EmDepartmentAddresses { get; set; }
        public virtual DbSet<EmStatus> EmStatuses { get; set; }
        public virtual DbSet<EmTitle> EmTitles { get; set; }
        public virtual DbSet<EmUser> EmUsers { get; set; }
        public virtual DbSet<EmUserRigth> EmUserRigths { get; set; }
        public virtual DbSet<EmUserRole> EmUserRoles { get; set; }
        public virtual DbSet<EmUserType> EmUserTypes { get; set; }
        public virtual DbSet<EmpBureau> EmpBureaus { get; set; }
        public virtual DbSet<EmployeePhone> EmployeePhones { get; set; }
        public virtual DbSet<GuaranteeLgReq> GuaranteeLgReqs { get; set; }
        public virtual DbSet<GuaranteeLgReqStation> GuaranteeLgReqStations { get; set; }
        public virtual DbSet<LOrgOther> LOrgOthers { get; set; }
        public virtual DbSet<LkAmphur> LkAmphurs { get; set; }
        public virtual DbSet<LkBank> LkBanks { get; set; }
        public virtual DbSet<LkCatm> LkCatms { get; set; }
        public virtual DbSet<LkDepartment> LkDepartments { get; set; }
        public virtual DbSet<LkDistrict> LkDistricts { get; set; }
        public virtual DbSet<LkProvince> LkProvinces { get; set; }
        public virtual DbSet<LmHospital> LmHospitals { get; set; }
        public virtual DbSet<LmHtitle> LmHtitles { get; set; }
        public virtual DbSet<LogSendmail> LogSendmails { get; set; }
        public virtual DbSet<RSmctRpt1> RSmctRpt1s { get; set; }
        public virtual DbSet<RSmctRpt2> RSmctRpt2s { get; set; }
        public virtual DbSet<RegisterNhso> RegisterNhsos { get; set; }
        public virtual DbSet<RegisterNhsoFile> RegisterNhsoFiles { get; set; }
        public virtual DbSet<RegisterNhsoFileType> RegisterNhsoFileTypes { get; set; }
        public virtual DbSet<SmctMaster> SmctMasters { get; set; }
        public virtual DbSet<SmctMasterFile> SmctMasterFiles { get; set; }
        public virtual DbSet<SmctMasterFileType> SmctMasterFileTypes { get; set; }
        public virtual DbSet<SmctMasterSendmail> SmctMasterSendmails { get; set; }
        public virtual DbSet<SmctMasterSigner> SmctMasterSigners { get; set; }
        public virtual DbSet<SmctMasterSignerDetail1> SmctMasterSignerDetail1s { get; set; }
        public virtual DbSet<SmctMasterSignerDetail2> SmctMasterSignerDetail2s { get; set; }
        public virtual DbSet<UserDdopa> UserDdopas { get; set; }
        public virtual DbSet<UserLevel> UserLevels { get; set; }
        public virtual DbSet<UserLevel2> UserLevel2s { get; set; }
        public virtual DbSet<UserRight> UserRights { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserSmct> UserSmcts { get; set; }
        public virtual DbSet<UserSmctLog> UserSmctLogs { get; set; }
        public virtual DbSet<UserSmctSigner> UserSmctSigners { get; set; }
        public virtual DbSet<UserSmctSignerFile> UserSmctSignerFiles { get; set; }
        public virtual DbSet<UserSmctVendor> UserSmctVendors { get; set; }
        public virtual DbSet<VDFiBankVendor> VDFiBankVendors { get; set; }
        public virtual DbSet<VGuaranteeLgContract> VGuaranteeLgContracts { get; set; }
        public virtual DbSet<VMasterVendor> VMasterVendors { get; set; }
        public virtual DbSet<VMasterVendorV1> VMasterVendorV1s { get; set; }
        public virtual DbSet<VNhsoBorad> VNhsoBorads { get; set; }
        public virtual DbSet<VNhsoBorad1> VNhsoBorad1s { get; set; }
        public virtual DbSet<VNhsoDepartmentAddress> VNhsoDepartmentAddresses { get; set; }
        public virtual DbSet<VNhsoEmployeeAll> VNhsoEmployeeAlls { get; set; }
        public virtual DbSet<VNhsoServiceUnit> VNhsoServiceUnits { get; set; }
        public virtual DbSet<VNhsoSigner> VNhsoSigners { get; set; }
        public virtual DbSet<VNhsoZone> VNhsoZones { get; set; }
        public virtual DbSet<VSmctBudgetcode> VSmctBudgetcodes { get; set; }
        public virtual DbSet<VSmctContract> VSmctContracts { get; set; }
        public virtual DbSet<VSmctContractPeriod> VSmctContractPeriods { get; set; }
        public virtual DbSet<VendorLinkReq> VendorLinkReqs { get; set; }
        public virtual DbSet<VendorLinkReqApprove> VendorLinkReqApproves { get; set; }
        public virtual DbSet<VendorLinkReqStation> VendorLinkReqStations { get; set; }
        public virtual DbSet<ViewAttachFile> ViewAttachFiles { get; set; }
        public virtual DbSet<ViewAttachfileConfigItem> ViewAttachfileConfigItems { get; set; }
        public virtual DbSet<ViewHraRegister> ViewHraRegisters { get; set; }
        public virtual DbSet<ViewRequestRegister> ViewRequestRegisters { get; set; }
        public virtual DbSet<ViewStandardRegister> ViewStandardRegisters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SMCT_OWNER");

            modelBuilder.Entity<ApprovalReq>(entity =>
            {
                entity.HasKey(e => e.IdApprovalReq);

                entity.ToTable("APPROVAL_REQ");

                entity.HasIndex(e => new { e.IdSmctMaster, e.Used }, "APPROVAL_REQ_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdApprovalReq)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_APPROVAL_REQ")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.ApprovalReqDate)
                    .HasColumnType("DATE")
                    .HasColumnName("APPROVAL_REQ_DATE");

                entity.Property(e => e.ApprovalReqId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APPROVAL_REQ_ID");

                entity.Property(e => e.ApprovalReqUser)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("APPROVAL_REQ_USER");

                entity.Property(e => e.ApprovalReqUserPos)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("APPROVAL_REQ_USER_POS");

                entity.Property(e => e.Board1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BOARD1");

                entity.Property(e => e.Board2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BOARD2");

                entity.Property(e => e.Board3)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("BOARD3");

                entity.Property(e => e.Board4)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("BOARD4");

                entity.Property(e => e.Board5)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("BOARD5");

                entity.Property(e => e.Chairman)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CHAIRMAN");

                entity.Property(e => e.ContractName)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_NAME");

                entity.Property(e => e.CoordinatorFullname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("COORDINATOR_FULLNAME");

                entity.Property(e => e.CoordinatorUser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("COORDINATOR_USER");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fax)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FAX");

                entity.Property(e => e.IdSmctMaster)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_SMCT_MASTER");

                entity.Property(e => e.Phone)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("REASON");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.StatusCheckMail)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("STATUS_CHECK_MAIL");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("VERSION");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.ApprovalReqCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("APPROVAL_REQ_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.ApprovalReqEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("APPROVAL_REQ_FK2");

                entity.HasOne(d => d.IdSmctMasterNavigation)
                    .WithMany(p => p.ApprovalReqs)
                    .HasForeignKey(d => d.IdSmctMaster)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("APPROVAL_REQ_FK3");
            });

            modelBuilder.Entity<ApprovalReqStation>(entity =>
            {
                entity.HasKey(e => e.IdApprovalReqStation)
                    .HasName("SYS_C00386186");

                entity.ToTable("APPROVAL_REQ_STATION");

                entity.HasIndex(e => new { e.IdSmctMaster, e.Used }, "APPROVAL_REQ_STATION_UQ1")
                    .IsUnique();

                entity.HasIndex(e => new { e.IdApprovalReq, e.Used }, "APPROVAL_REQ_STATION_UQ2")
                    .IsUnique();

                entity.Property(e => e.IdApprovalReqStation)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_APPROVAL_REQ_STATION")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.ApprovalReqDate)
                    .HasColumnType("DATE")
                    .HasColumnName("APPROVAL_REQ_DATE");

                entity.Property(e => e.ApprovalReqId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("APPROVAL_REQ_ID");

                entity.Property(e => e.Budgetyear)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("BUDGETYEAR");

                entity.Property(e => e.ContractName)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_NAME");

                entity.Property(e => e.ContractSignType)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_SIGN_TYPE");

                entity.Property(e => e.ContractStyleCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_STYLE_CODE");

                entity.Property(e => e.ContractStyleFullName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_STYLE_FULL_NAME");

                entity.Property(e => e.ContractTypeId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE_ID");

                entity.Property(e => e.ContractTypeName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE_NAME");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.CreateUserDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATE_USER_DATE");

                entity.Property(e => e.CreateUserFullname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER_FULLNAME");

                entity.Property(e => e.DepartmentCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_CODE");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_NAME");

                entity.Property(e => e.DirectorRemark)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("DIRECTOR_REMARK");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.EditUserDate)
                    .HasColumnType("DATE")
                    .HasColumnName("EDIT_USER_DATE");

                entity.Property(e => e.EditUserFullname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER_FULLNAME");

                entity.Property(e => e.FRetarn)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("F_RETARN");

                entity.Property(e => e.IdApprovalReq)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_APPROVAL_REQ");

                entity.Property(e => e.IdSmctMaster)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_SMCT_MASTER");

                entity.Property(e => e.ItemApproveDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ITEM_APPROVE_DATE");

                entity.Property(e => e.ItemApproveUser)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ITEM_APPROVE_USER");

                entity.Property(e => e.ItemBeginDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ITEM_BEGIN_DATE");

                entity.Property(e => e.ItemBeginUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ITEM_BEGIN_USER");

                entity.Property(e => e.ItemStatusCurr)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ITEM_STATUS_CURR");

                entity.Property(e => e.ItemStatusPrev)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ITEM_STATUS_PREV");

                entity.Property(e => e.OfficerReamrk)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("OFFICER_REAMRK");

                entity.Property(e => e.RefDate)
                    .HasColumnType("DATE")
                    .HasColumnName("REF_DATE");

                entity.Property(e => e.RefId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("REF_ID");

                entity.Property(e => e.StationApproveDate)
                    .HasColumnType("DATE")
                    .HasColumnName("STATION_APPROVE_DATE");

                entity.Property(e => e.StationApproveUser)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("STATION_APPROVE_USER");

                entity.Property(e => e.StationBeginDate)
                    .HasColumnType("DATE")
                    .HasColumnName("STATION_BEGIN_DATE");

                entity.Property(e => e.StationBeginUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("STATION_BEGIN_USER");

                entity.Property(e => e.StationStatusCurr)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATION_STATUS_CURR");

                entity.Property(e => e.StationStatusPrev)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATION_STATUS_PREV");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.Property(e => e.VendorId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_ID");

                entity.Property(e => e.VendorName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_NAME");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.ApprovalReqStationCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("APPROVAL_REQ_STATION_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.ApprovalReqStationEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("APPROVAL_REQ_STATION_FK2");

                entity.HasOne(d => d.IdApprovalReqNavigation)
                    .WithMany(p => p.ApprovalReqStations)
                    .HasForeignKey(d => d.IdApprovalReq)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("APPROVAL_REQ_STATION_FK4");

                entity.HasOne(d => d.IdSmctMasterNavigation)
                    .WithMany(p => p.ApprovalReqStations)
                    .HasForeignKey(d => d.IdSmctMaster)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("APPROVAL_REQ_STATION_FK3");
            });

            modelBuilder.Entity<BudgetcodeView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("BUDGETCODE_VIEW");

                entity.Property(e => e.Budgetcode)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("BUDGETCODE");

                entity.Property(e => e.Budgetyear)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("BUDGETYEAR");

                entity.Property(e => e.Remain)
                    .HasColumnType("NUMBER")
                    .HasColumnName("REMAIN");
            });

            modelBuilder.Entity<BudgetcodeViewTab>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BUDGETCODE_VIEW_TAB");

                entity.Property(e => e.Budgetcode)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("BUDGETCODE");

                entity.Property(e => e.Remain)
                    .HasColumnType("NUMBER")
                    .HasColumnName("REMAIN");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.HasKey(e => e.IdContract);

                entity.ToTable("CONTRACT");

                entity.Property(e => e.IdContract)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.Budget)
                    .HasColumnType("NUMBER(18,2)")
                    .HasColumnName("BUDGET");

                entity.Property(e => e.ContractDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CONTRACT_DATE");

                entity.Property(e => e.ContractId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_ID");

                entity.Property(e => e.ContractMainId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_MAIN_ID");

                entity.Property(e => e.ContractName)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_NAME");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.EndDate)
                    .HasColumnType("DATE")
                    .HasColumnName("END_DATE");

                entity.Property(e => e.GuaranteeDay)
                    .HasPrecision(10)
                    .HasColumnName("GUARANTEE_DAY");

                entity.Property(e => e.IdContractType)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_TYPE");

                entity.Property(e => e.IdSmctMaster)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_SMCT_MASTER");

                entity.Property(e => e.PayVendorType)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PAY_VENDOR_TYPE");

                entity.Property(e => e.StartDate)
                    .HasColumnType("DATE")
                    .HasColumnName("START_DATE");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("VERSION");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.ContractCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.ContractEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_FK2");

                entity.HasOne(d => d.IdContractTypeNavigation)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.IdContractType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_FK4");

                entity.HasOne(d => d.IdSmctMasterNavigation)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.IdSmctMaster)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_FK3");
            });

            modelBuilder.Entity<ContractDetail01>(entity =>
            {
                entity.HasKey(e => e.IdContractDetail01);

                entity.ToTable("CONTRACT_DETAIL01");

                entity.HasIndex(e => new { e.IdContract, e.Used }, "CONTRACT_DETAIL01_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdContractDetail01)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_DETAIL01")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.IdContract)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT");

                entity.Property(e => e.P1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P10)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P11)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P12)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P13)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P14)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P15)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P16)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P17)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P18)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P19)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P2)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P20)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P21)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P22)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P23)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P24)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P25)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P26)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P27)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P28)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P29)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P3)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P30)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P31)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P32)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P33)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P34)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P35)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P36)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P37)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P38)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P39)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P4)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P40)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P41)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P42)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P43)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P44)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P45)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P46)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P47)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P48)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P49)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P5)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P50)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P51)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P52)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P53)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P54)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P55)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P56)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P57)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P6)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P7)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P8)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P9)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.ContractDetail01CreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL01_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.ContractDetail01EditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL01_FK2");

                entity.HasOne(d => d.IdContractNavigation)
                    .WithMany(p => p.ContractDetail01s)
                    .HasForeignKey(d => d.IdContract)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL01_FK3");
            });

            modelBuilder.Entity<ContractDetail02>(entity =>
            {
                entity.HasKey(e => e.IdContractDetail02);

                entity.ToTable("CONTRACT_DETAIL02");

                entity.HasIndex(e => new { e.IdContract, e.Used }, "CONTRACT_DETAIL02_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdContractDetail02)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_DETAIL02")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.A1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.A10)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.A11)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.A12)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.A13)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.A14)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.A15)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.A16)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.A17)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.A18)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.A19)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.A2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.A20)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.A21)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.A3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.A4)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.A5)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.A6)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.A7)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.A8)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.A9)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.IdContract)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT");

                entity.Property(e => e.P1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P10)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P11)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P12)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P13)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P14)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P15)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P16)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P17)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P18)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P19)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P2)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P20)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P21)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P22)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P23)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P24)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P25)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P26)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P27)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P28)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P29)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P3)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P30)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P31)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P32)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P33)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P34)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P35)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P36)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P37)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P38)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P39)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P4)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P40)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P41)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P42)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P43)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P44)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P45)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P46)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P47)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P48)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P49)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P5)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P50)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P51)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P52)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P53)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P54)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P55)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P56)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P57)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P58)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P59)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P6)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P60)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P61)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P62)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P63)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P64)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P65)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P66)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P7)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P8)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P9)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.ContractDetail02CreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL02_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.ContractDetail02EditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL02_FK2");

                entity.HasOne(d => d.IdContractNavigation)
                    .WithMany(p => p.ContractDetail02s)
                    .HasForeignKey(d => d.IdContract)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL02_FK3");
            });

            modelBuilder.Entity<ContractDetail03>(entity =>
            {
                entity.HasKey(e => e.IdContractDetail03);

                entity.ToTable("CONTRACT_DETAIL03");

                entity.HasIndex(e => new { e.IdContract, e.Used }, "CONTRACT_DETAIL03_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdContractDetail03)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_DETAIL03")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.IdContract)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT");

                entity.Property(e => e.P1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P3)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.ContractDetail03CreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL03_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.ContractDetail03EditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL03_FK2");

                entity.HasOne(d => d.IdContractNavigation)
                    .WithMany(p => p.ContractDetail03s)
                    .HasForeignKey(d => d.IdContract)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL03_FK3");
            });

            modelBuilder.Entity<ContractDetail04>(entity =>
            {
                entity.HasKey(e => e.IdContractDetail04);

                entity.ToTable("CONTRACT_DETAIL04");

                entity.HasIndex(e => new { e.IdContract, e.Used }, "CONTRACT_DETAIL04_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdContractDetail04)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_DETAIL04")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.IdContract)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT");

                entity.Property(e => e.P1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P3)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.ContractDetail04CreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL04_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.ContractDetail04EditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL04_FK2");

                entity.HasOne(d => d.IdContractNavigation)
                    .WithMany(p => p.ContractDetail04s)
                    .HasForeignKey(d => d.IdContract)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL04_FK3");
            });

            modelBuilder.Entity<ContractDetail05>(entity =>
            {
                entity.HasKey(e => e.IdContractDetail05);

                entity.ToTable("CONTRACT_DETAIL05");

                entity.HasIndex(e => new { e.IdContract, e.Used }, "CONTRACT_DETAIL05_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdContractDetail05)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_DETAIL05")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.IdContract)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT");

                entity.Property(e => e.P1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P2)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.ContractDetail05CreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL05_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.ContractDetail05EditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL05_FK2");

                entity.HasOne(d => d.IdContractNavigation)
                    .WithMany(p => p.ContractDetail05s)
                    .HasForeignKey(d => d.IdContract)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL05_FK3");
            });

            modelBuilder.Entity<ContractDetail06>(entity =>
            {
                entity.HasKey(e => e.IdContractDetail06);

                entity.ToTable("CONTRACT_DETAIL06");

                entity.HasIndex(e => new { e.IdContract, e.Used }, "CONTRACT_DETAIL06_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdContractDetail06)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_DETAIL06")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.IdContract)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT");

                entity.Property(e => e.P1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P2)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P4)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P5)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P6)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P7)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.ContractDetail06CreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL06_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.ContractDetail06EditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL06_FK2");

                entity.HasOne(d => d.IdContractNavigation)
                    .WithMany(p => p.ContractDetail06s)
                    .HasForeignKey(d => d.IdContract)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL06_FK3");
            });

            modelBuilder.Entity<ContractDetail07>(entity =>
            {
                entity.HasKey(e => e.IdContractDetail07);

                entity.ToTable("CONTRACT_DETAIL07");

                entity.HasIndex(e => new { e.IdContract, e.Used }, "CONTRACT_DETAIL07_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdContractDetail07)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_DETAIL07")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.IdContract)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT");

                entity.Property(e => e.P1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P2)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P4)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P5)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P6)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P7)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.ContractDetail07CreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL07_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.ContractDetail07EditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL07_FK2");

                entity.HasOne(d => d.IdContractNavigation)
                    .WithMany(p => p.ContractDetail07s)
                    .HasForeignKey(d => d.IdContract)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL07_FK3");
            });

            modelBuilder.Entity<ContractDetail08>(entity =>
            {
                entity.HasKey(e => e.IdContractDetail08);

                entity.ToTable("CONTRACT_DETAIL08");

                entity.HasIndex(e => new { e.IdContract, e.Used }, "CONTRACT_DETAIL08_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdContractDetail08)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_DETAIL08")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.IdContract)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT");

                entity.Property(e => e.P1)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P3)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P4)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P5)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P6)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.ContractDetail08CreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL08_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.ContractDetail08EditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL08_FK2");

                entity.HasOne(d => d.IdContractNavigation)
                    .WithMany(p => p.ContractDetail08s)
                    .HasForeignKey(d => d.IdContract)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL08_FK3");
            });

            modelBuilder.Entity<ContractDetail09>(entity =>
            {
                entity.HasKey(e => e.IdContractDetail09);

                entity.ToTable("CONTRACT_DETAIL09");

                entity.HasIndex(e => new { e.IdContract, e.Used }, "CONTRACT_DETAIL09_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdContractDetail09)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_DETAIL09")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.IdContract)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT");

                entity.Property(e => e.P1)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P3)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P4)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P5)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P6)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.ContractDetail09CreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL09_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.ContractDetail09EditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL09_FK2");

                entity.HasOne(d => d.IdContractNavigation)
                    .WithMany(p => p.ContractDetail09s)
                    .HasForeignKey(d => d.IdContract)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL09_FK3");
            });

            modelBuilder.Entity<ContractDetail10>(entity =>
            {
                entity.HasKey(e => e.IdContractDetail10);

                entity.ToTable("CONTRACT_DETAIL10");

                entity.HasIndex(e => new { e.IdContract, e.Used }, "CONTRACT_DETAIL10_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdContractDetail10)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_DETAIL10")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.IdContract)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT");

                entity.Property(e => e.P1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.ContractDetail10CreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL10_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.ContractDetail10EditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL10_FK2");

                entity.HasOne(d => d.IdContractNavigation)
                    .WithMany(p => p.ContractDetail10s)
                    .HasForeignKey(d => d.IdContract)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL10_FK3");
            });

            modelBuilder.Entity<ContractDetail11>(entity =>
            {
                entity.HasKey(e => e.IdContractDetail11);

                entity.ToTable("CONTRACT_DETAIL11");

                entity.HasIndex(e => new { e.IdContract, e.Used }, "CONTRACT_DETAIL11_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdContractDetail11)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_DETAIL11")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.A1)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.A10)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.A11)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.A12)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.A13)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.A14)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.A15)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.A16)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.A17)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.A2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.A3)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.A4)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.A5)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.A6)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.A7)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.A8)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.A9)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.IdContract)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT");

                entity.Property(e => e.P1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P4)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P5)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P6)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P7)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.ContractDetail11CreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL11_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.ContractDetail11EditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL11_FK2");

                entity.HasOne(d => d.IdContractNavigation)
                    .WithMany(p => p.ContractDetail11s)
                    .HasForeignKey(d => d.IdContract)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL11_FK3");
            });

            modelBuilder.Entity<ContractDetail12>(entity =>
            {
                entity.HasKey(e => e.IdContractDetail12);

                entity.ToTable("CONTRACT_DETAIL12");

                entity.HasIndex(e => new { e.IdContract, e.Used }, "CONTRACT_DETAIL12_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdContractDetail12)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_DETAIL12")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.A1)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.A10)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.A11)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.A12)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.A13)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.A14)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.A15)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.A16)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.A2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.A3)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.A4)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.A5)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.A6)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.A7)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.A8)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.A9)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.IdContract)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT");

                entity.Property(e => e.P1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P3)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P4)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P5)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P6)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.ContractDetail12CreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL12_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.ContractDetail12EditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL12_FK2");

                entity.HasOne(d => d.IdContractNavigation)
                    .WithMany(p => p.ContractDetail12s)
                    .HasForeignKey(d => d.IdContract)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL12_FK3");
            });

            modelBuilder.Entity<ContractDetail13>(entity =>
            {
                entity.HasKey(e => e.IdContractDetail13);

                entity.ToTable("CONTRACT_DETAIL13");

                entity.HasIndex(e => new { e.IdContract, e.Used }, "CONTRACT_DETAIL13_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdContractDetail13)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_DETAIL13")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.IdContract)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT");

                entity.Property(e => e.P1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.P3)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P4)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P5)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P6)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.ContractDetail13CreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL13_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.ContractDetail13EditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL13_FK2");

                entity.HasOne(d => d.IdContractNavigation)
                    .WithMany(p => p.ContractDetail13s)
                    .HasForeignKey(d => d.IdContract)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL13_FK3");
            });

            modelBuilder.Entity<ContractDetail14>(entity =>
            {
                entity.HasKey(e => e.IdContractDetail14);

                entity.ToTable("CONTRACT_DETAIL14");

                entity.HasIndex(e => new { e.IdContract, e.Used }, "CONTRACT_DETAIL14_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdContractDetail14)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_DETAIL14")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.IdContract)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT");

                entity.Property(e => e.P1)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.P10)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.P11)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.P12)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.P13)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.P14)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.P15)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.P16)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.P17)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P18)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P19)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.P2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.P20)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.P21)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.P22)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.P23)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.P24)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.P25)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.P26)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.P27)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P28)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.P29)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.P3)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.P30)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.P31)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.P32)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P33)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.P34)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.P35)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.P36)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.P4)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.P5)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.P6)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P7)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P8)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.P9)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.ContractDetail14CreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL14_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.ContractDetail14EditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL14_FK2");

                entity.HasOne(d => d.IdContractNavigation)
                    .WithMany(p => p.ContractDetail14s)
                    .HasForeignKey(d => d.IdContract)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_DETAIL14_FK3");
            });

            modelBuilder.Entity<ContractExtend>(entity =>
            {
                entity.HasKey(e => e.IdContractExtend);

                entity.ToTable("CONTRACT_EXTEND");

                entity.Property(e => e.IdContractExtend)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_EXTEND")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.ExtendEndDateCurr)
                    .HasColumnType("DATE")
                    .HasColumnName("EXTEND_END_DATE_CURR");

                entity.Property(e => e.ExtendEndDatePrev)
                    .HasColumnType("DATE")
                    .HasColumnName("EXTEND_END_DATE_PREV");

                entity.Property(e => e.ExtendNo)
                    .HasPrecision(10)
                    .HasColumnName("EXTEND_NO");

                entity.Property(e => e.ExtendStartDateCurr)
                    .HasColumnType("DATE")
                    .HasColumnName("EXTEND_START_DATE_CURR");

                entity.Property(e => e.ExtendStartDatePrev)
                    .HasColumnType("DATE")
                    .HasColumnName("EXTEND_START_DATE_PREV");

                entity.Property(e => e.IdContract)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.ContractExtendCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_EXTEND_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.ContractExtendEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_EXTEND_FK2");

                entity.HasOne(d => d.IdContractNavigation)
                    .WithMany(p => p.ContractExtends)
                    .HasForeignKey(d => d.IdContract)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_EXTEND_FK3");
            });

            modelBuilder.Entity<ContractGuarantee>(entity =>
            {
                entity.HasKey(e => e.IdContractGuarantee);

                entity.ToTable("CONTRACT_GUARANTEE");

                entity.Property(e => e.IdContractGuarantee)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_GUARANTEE")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.GuaranteeExceptDoc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GUARANTEE_EXCEPT_DOC");

                entity.Property(e => e.GuaranteeType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GUARANTEE_TYPE");

                entity.Property(e => e.IdSmctMaster)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_SMCT_MASTER");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.ContractGuaranteeCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_GUARANTEE_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.ContractGuaranteeEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_GUARANTEE_FK2");

                entity.HasOne(d => d.IdSmctMasterNavigation)
                    .WithMany(p => p.ContractGuarantees)
                    .HasForeignKey(d => d.IdSmctMaster)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_GUARANTEE_FK3");
            });

            modelBuilder.Entity<ContractGuaranteeDetail>(entity =>
            {
                entity.HasKey(e => e.IdContractGuaranteeDetail);

                entity.ToTable("CONTRACT_GUARANTEE_DETAIL");

                entity.Property(e => e.IdContractGuaranteeDetail)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_GUARANTEE_DETAIL")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER(18,2)")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.BankId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("BANK_ID");

                entity.Property(e => e.CashierDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CASHIER_DATE");

                entity.Property(e => e.CashierId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CASHIER_ID");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.GuaranteeDocDate)
                    .HasColumnType("DATE")
                    .HasColumnName("GUARANTEE_DOC_DATE");

                entity.Property(e => e.GuaranteeDocEndDate)
                    .HasColumnType("DATE")
                    .HasColumnName("GUARANTEE_DOC_END_DATE");

                entity.Property(e => e.GuaranteeDocId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GUARANTEE_DOC_ID");

                entity.Property(e => e.GuaranteeDocStartDate)
                    .HasColumnType("DATE")
                    .HasColumnName("GUARANTEE_DOC_START_DATE");

                entity.Property(e => e.IdContractGuarantee)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_GUARANTEE");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.ContractGuaranteeDetailCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_GUARANTEE_DETAIL_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.ContractGuaranteeDetailEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_GUARANTEE_DETAIL_FK2");

                entity.HasOne(d => d.IdContractGuaranteeNavigation)
                    .WithMany(p => p.ContractGuaranteeDetails)
                    .HasForeignKey(d => d.IdContractGuarantee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_GUARANTEE_DETAIL_FK3");
            });

            modelBuilder.Entity<ContractPeriod>(entity =>
            {
                entity.HasKey(e => e.IdContractPeriod);

                entity.ToTable("CONTRACT_PERIOD");

                entity.HasIndex(e => new { e.IdContract, e.Used, e.PeriodNo, e.PeriodBudgetcode, e.PeriodVendorId }, "CONTRACT_PERIOD_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdContractPeriod)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_PERIOD")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.IdContract)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT");

                entity.Property(e => e.PeriodBudgetcode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PERIOD_BUDGETCODE");

                entity.Property(e => e.PeriodDueDate)
                    .HasColumnType("DATE")
                    .HasColumnName("PERIOD_DUE_DATE");

                entity.Property(e => e.PeriodEndDate)
                    .HasColumnType("DATE")
                    .HasColumnName("PERIOD_END_DATE");

                entity.Property(e => e.PeriodNo)
                    .HasPrecision(10)
                    .HasColumnName("PERIOD_NO");

                entity.Property(e => e.PeriodP1Detail)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("PERIOD_P1_DETAIL");

                entity.Property(e => e.PeriodPercent)
                    .HasColumnType("NUMBER(19,3)")
                    .HasColumnName("PERIOD_PERCENT");

                entity.Property(e => e.PeriodStartDate)
                    .HasColumnType("DATE")
                    .HasColumnName("PERIOD_START_DATE");

                entity.Property(e => e.PeriodType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PERIOD_TYPE");

                entity.Property(e => e.PeriodVendorId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PERIOD_VENDOR_ID");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.ContractPeriodCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_PERIOD_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.ContractPeriodEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_PERIOD_FK2");

                entity.HasOne(d => d.IdContractNavigation)
                    .WithMany(p => p.ContractPeriods)
                    .HasForeignKey(d => d.IdContract)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_PERIOD_FK3");
            });

            modelBuilder.Entity<ContractPeriodDetail>(entity =>
            {
                entity.HasKey(e => e.IdContractPeriodDetail);

                entity.ToTable("CONTRACT_PERIOD_DETAIL");

                entity.Property(e => e.IdContractPeriodDetail)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_PERIOD_DETAIL")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.ContractPeriodDetail1)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_PERIOD_DETAIL");

                entity.Property(e => e.ContractPeriodDetailNo)
                    .HasPrecision(2)
                    .HasColumnName("CONTRACT_PERIOD_DETAIL_NO");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.IdContract)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT");

                entity.Property(e => e.PeriodNo)
                    .HasPrecision(10)
                    .HasColumnName("PERIOD_NO");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.ContractPeriodDetailCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_PERIOD_DETAIL_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.ContractPeriodDetailEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_PERIOD_DETAIL_FK2");

                entity.HasOne(d => d.IdContractNavigation)
                    .WithMany(p => p.ContractPeriodDetails)
                    .HasForeignKey(d => d.IdContract)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_PERIOD_DETAIL_FK3");
            });

            modelBuilder.Entity<ContractPlan>(entity =>
            {
                entity.HasKey(e => e.IdContractPlan);

                entity.ToTable("CONTRACT_PLAN");

                entity.HasIndex(e => new { e.IdContract, e.Used, e.Budgetcode }, "CONTRACT_PLAN_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdContractPlan)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_PLAN")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.Budget)
                    .HasColumnType("NUMBER(18,2)")
                    .HasColumnName("BUDGET");

                entity.Property(e => e.Budgetcode)
                    .IsRequired()
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("BUDGETCODE");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.IdContract)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT");

                entity.Property(e => e.Planno)
                    .HasPrecision(10)
                    .HasColumnName("PLANNO");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.ContractPlanCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_PLAN_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.ContractPlanEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_PLAN_FK2");

                entity.HasOne(d => d.IdContractNavigation)
                    .WithMany(p => p.ContractPlans)
                    .HasForeignKey(d => d.IdContract)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_PLAN_FK3");
            });

            modelBuilder.Entity<ContractSbbCkl>(entity =>
            {
                entity.HasKey(e => e.IdContractSbbCkl);

                entity.ToTable("CONTRACT_SBB_CKL");

                entity.HasIndex(e => new { e.Used, e.ChecklistId }, "CONTRACT_SBB_CKL_UQ2")
                    .IsUnique();

                entity.Property(e => e.IdContractSbbCkl)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_SBB_CKL")
                    .HasDefaultValueSql("sys_guid()");

                entity.Property(e => e.ChecklistDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CHECKLIST_DATE");

                entity.Property(e => e.ChecklistId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CHECKLIST_ID");

                entity.Property(e => e.ChecklistUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CHECKLIST_USER");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.IdContract)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT");

                entity.Property(e => e.Remark)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("REMARK");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.ChecklistUserNavigation)
                    .WithMany(p => p.ContractSbbCklChecklistUserNavigations)
                    .HasForeignKey(d => d.ChecklistUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_SBB_CKL_FK4");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.ContractSbbCklCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_SBB_CKL_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.ContractSbbCklEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_SBB_CKL_FK2");

                entity.HasOne(d => d.IdContractNavigation)
                    .WithMany(p => p.ContractSbbCkls)
                    .HasForeignKey(d => d.IdContract)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_SBB_CKL_FK3");
            });

            modelBuilder.Entity<ContractSbbCklDetail>(entity =>
            {
                entity.HasKey(e => e.IdContractSbbCklDetail);

                entity.ToTable("CONTRACT_SBB_CKL_DETAIL");

                entity.Property(e => e.IdContractSbbCklDetail)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_SBB_CKL_DETAIL")
                    .HasDefaultValueSql("sys_guid()");

                entity.Property(e => e.C1).HasPrecision(1);

                entity.Property(e => e.C2).HasPrecision(1);

                entity.Property(e => e.C3).HasPrecision(1);

                entity.Property(e => e.CDetail)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("C_DETAIL");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.IdContractSbbCkl)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_SBB_CKL");

                entity.Property(e => e.IdContractSbbCklHeading)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_SBB_CKL_HEADING");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.ContractSbbCklDetailCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_SBB_CKL_DETAIL_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.ContractSbbCklDetailEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_SBB_CKL_DETAIL_FK2");

                entity.HasOne(d => d.IdContractSbbCklNavigation)
                    .WithMany(p => p.ContractSbbCklDetails)
                    .HasForeignKey(d => d.IdContractSbbCkl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_SBB_CKL_DETAIL_FK3");

                entity.HasOne(d => d.IdContractSbbCklHeadingNavigation)
                    .WithMany(p => p.ContractSbbCklDetails)
                    .HasForeignKey(d => d.IdContractSbbCklHeading)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_SBB_CKL_DETAIL_FK4");
            });

            modelBuilder.Entity<ContractSbbCklHeading>(entity =>
            {
                entity.HasKey(e => e.IdContractSbbCklHeading);

                entity.ToTable("CONTRACT_SBB_CKL_HEADING");

                entity.Property(e => e.IdContractSbbCklHeading)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_SBB_CKL_HEADING")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.DetailItem)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("DETAIL_ITEM");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.FCb)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("F_CB");

                entity.Property(e => e.IdContractType)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_TYPE");

                entity.Property(e => e.L1Item)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("L1_ITEM");

                entity.Property(e => e.L2Item)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("L2_ITEM");

                entity.Property(e => e.L3Item)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("L3_ITEM");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.ContractSbbCklHeadingCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_SBB_CKL_HEADING_FK2");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.ContractSbbCklHeadingEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_SBB_CKL_HEADING_FK3");

                entity.HasOne(d => d.IdContractTypeNavigation)
                    .WithMany(p => p.ContractSbbCklHeadings)
                    .HasForeignKey(d => d.IdContractType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_SBB_CKL_HEADING_FK1");
            });

            modelBuilder.Entity<ContractStation>(entity =>
            {
                entity.HasKey(e => e.IdContractStation);

                entity.ToTable("CONTRACT_STATION");

                entity.HasIndex(e => new { e.IdSmctMaster, e.Used }, "CONTRACT_STATION_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdContractStation)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_STATION")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.Budgetyear)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("BUDGETYEAR");

                entity.Property(e => e.ContractDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CONTRACT_DATE");

                entity.Property(e => e.ContractId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_ID");

                entity.Property(e => e.ContractName)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_NAME");

                entity.Property(e => e.ContractSignType)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_SIGN_TYPE");

                entity.Property(e => e.ContractStyleCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_STYLE_CODE");

                entity.Property(e => e.ContractStyleFullName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_STYLE_FULL_NAME");

                entity.Property(e => e.ContractTypeId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE_ID");

                entity.Property(e => e.ContractTypeName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE_NAME");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.CreateUserDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATE_USER_DATE");

                entity.Property(e => e.CreateUserFullname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER_FULLNAME");

                entity.Property(e => e.DepartmentCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_CODE");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_NAME");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.EditUserDate)
                    .HasColumnType("DATE")
                    .HasColumnName("EDIT_USER_DATE");

                entity.Property(e => e.EditUserFullname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER_FULLNAME");

                entity.Property(e => e.FRetarn)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("F_RETARN");

                entity.Property(e => e.FVendorlink)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("F_VENDORLINK");

                entity.Property(e => e.IdContract)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT");

                entity.Property(e => e.IdSmctMaster)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_SMCT_MASTER");

                entity.Property(e => e.ItemApproveDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ITEM_APPROVE_DATE");

                entity.Property(e => e.ItemApproveUser)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ITEM_APPROVE_USER");

                entity.Property(e => e.ItemBeginDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ITEM_BEGIN_DATE");

                entity.Property(e => e.ItemBeginUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ITEM_BEGIN_USER");

                entity.Property(e => e.ItemStatusCurr)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ITEM_STATUS_CURR");

                entity.Property(e => e.ItemStatusPrev)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ITEM_STATUS_PREV");

                entity.Property(e => e.KetRemark)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("KET_REMARK");

                entity.Property(e => e.RefDate)
                    .HasColumnType("DATE")
                    .HasColumnName("REF_DATE");

                entity.Property(e => e.RefId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("REF_ID");

                entity.Property(e => e.SbbRemark)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("SBB_REMARK");

                entity.Property(e => e.StationApproveDate)
                    .HasColumnType("DATE")
                    .HasColumnName("STATION_APPROVE_DATE");

                entity.Property(e => e.StationApproveUser)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("STATION_APPROVE_USER");

                entity.Property(e => e.StationBeginDate)
                    .HasColumnType("DATE")
                    .HasColumnName("STATION_BEGIN_DATE");

                entity.Property(e => e.StationBeginUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("STATION_BEGIN_USER");

                entity.Property(e => e.StationStatusCurr)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATION_STATUS_CURR");

                entity.Property(e => e.StationStatusPrev)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATION_STATUS_PREV");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.Property(e => e.VendorId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_ID");

                entity.Property(e => e.VendorName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_NAME");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.ContractStationCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_STATION_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.ContractStationEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_STATION_FK2");

                entity.HasOne(d => d.IdContractNavigation)
                    .WithMany(p => p.ContractStations)
                    .HasForeignKey(d => d.IdContract)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_STATION_FK4");

                entity.HasOne(d => d.IdSmctMasterNavigation)
                    .WithMany(p => p.ContractStations)
                    .HasForeignKey(d => d.IdSmctMaster)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_STATION_FK3");
            });

            modelBuilder.Entity<ContractStationGuarantee>(entity =>
            {
                entity.HasKey(e => e.IdContractStationGuarantee);

                entity.ToTable("CONTRACT_STATION_GUARANTEE");

                entity.Property(e => e.IdContractStationGuarantee)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_STATION_GUARANTEE")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.Budgetyear)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("BUDGETYEAR");

                entity.Property(e => e.ContractDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CONTRACT_DATE");

                entity.Property(e => e.ContractGuaranteeCreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CONTRACT_GUARANTEE_CREATE_DATE");

                entity.Property(e => e.ContractGuaranteeCreateUser)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_GUARANTEE_CREATE_USER");

                entity.Property(e => e.ContractGuaranteeEditDate)
                    .HasPrecision(6)
                    .HasColumnName("CONTRACT_GUARANTEE_EDIT_DATE");

                entity.Property(e => e.ContractGuaranteeEditUser)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_GUARANTEE_EDIT_USER");

                entity.Property(e => e.ContractGuaranteeFFile)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_GUARANTEE_F_FILE");

                entity.Property(e => e.ContractGuaranteeRemark)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_GUARANTEE_REMARK");

                entity.Property(e => e.ContractGuaranteeRemarkKet)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_GUARANTEE_REMARK_KET");

                entity.Property(e => e.ContractGuaranteeStatus)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_GUARANTEE_STATUS");

                entity.Property(e => e.ContractGuaranteeType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_GUARANTEE_TYPE");

                entity.Property(e => e.ContractId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_ID");

                entity.Property(e => e.ContractName)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_NAME");

                entity.Property(e => e.ContractSignType)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_SIGN_TYPE");

                entity.Property(e => e.ContractStatus)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_STATUS");

                entity.Property(e => e.ContractStyleCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_STYLE_CODE");

                entity.Property(e => e.ContractStyleFullName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_STYLE_FULL_NAME");

                entity.Property(e => e.ContractTypeId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE_ID");

                entity.Property(e => e.ContractTypeName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE_NAME");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.CreateUserDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATE_USER_DATE");

                entity.Property(e => e.CreateUserFullname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER_FULLNAME");

                entity.Property(e => e.DepartmentCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_CODE");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_NAME");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.EditUserDate)
                    .HasColumnType("DATE")
                    .HasColumnName("EDIT_USER_DATE");

                entity.Property(e => e.EditUserFullname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER_FULLNAME");

                entity.Property(e => e.FRetarn)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("F_RETARN");

                entity.Property(e => e.FVendorlink)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("F_VENDORLINK");

                entity.Property(e => e.IdContract)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT");

                entity.Property(e => e.IdSmctMaster)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_SMCT_MASTER");

                entity.Property(e => e.ItemApproveDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ITEM_APPROVE_DATE");

                entity.Property(e => e.ItemApproveUser)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ITEM_APPROVE_USER");

                entity.Property(e => e.ItemBeginDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ITEM_BEGIN_DATE");

                entity.Property(e => e.ItemBeginUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ITEM_BEGIN_USER");

                entity.Property(e => e.ItemStatusCurr)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ITEM_STATUS_CURR");

                entity.Property(e => e.ItemStatusPrev)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ITEM_STATUS_PREV");

                entity.Property(e => e.KetRemark)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("KET_REMARK");

                entity.Property(e => e.RefDate)
                    .HasColumnType("DATE")
                    .HasColumnName("REF_DATE");

                entity.Property(e => e.RefId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("REF_ID");

                entity.Property(e => e.SbbRemark)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("SBB_REMARK");

                entity.Property(e => e.StationApproveDate)
                    .HasColumnType("DATE")
                    .HasColumnName("STATION_APPROVE_DATE");

                entity.Property(e => e.StationApproveUser)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("STATION_APPROVE_USER");

                entity.Property(e => e.StationBeginDate)
                    .HasColumnType("DATE")
                    .HasColumnName("STATION_BEGIN_DATE");

                entity.Property(e => e.StationBeginUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("STATION_BEGIN_USER");

                entity.Property(e => e.StationStatusCurr)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATION_STATUS_CURR");

                entity.Property(e => e.StationStatusPrev)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATION_STATUS_PREV");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.Property(e => e.VendorId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_ID");

                entity.Property(e => e.VendorName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_NAME");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.ContractStationGuaranteeCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_STATION_GUARANTE_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.ContractStationGuaranteeEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_STATION_GUARANTE_FK2");

                entity.HasOne(d => d.IdContractNavigation)
                    .WithMany(p => p.ContractStationGuarantees)
                    .HasForeignKey(d => d.IdContract)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_STATION_GUARANTE_FK4");

                entity.HasOne(d => d.IdSmctMasterNavigation)
                    .WithMany(p => p.ContractStationGuarantees)
                    .HasForeignKey(d => d.IdSmctMaster)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_STATION_GUARANTE_FK3");
            });

            modelBuilder.Entity<ContractStationSuccess>(entity =>
            {
                entity.HasKey(e => e.IdContractStationSuccess);

                entity.ToTable("CONTRACT_STATION_SUCCESS");

                entity.Property(e => e.IdContractStationSuccess)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_STATION_SUCCESS")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.Budgetyear)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("BUDGETYEAR");

                entity.Property(e => e.ContractDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CONTRACT_DATE");

                entity.Property(e => e.ContractId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_ID");

                entity.Property(e => e.ContractName)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_NAME");

                entity.Property(e => e.ContractSignType)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_SIGN_TYPE");

                entity.Property(e => e.ContractStatus)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_STATUS");

                entity.Property(e => e.ContractStyleCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_STYLE_CODE");

                entity.Property(e => e.ContractStyleFullName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_STYLE_FULL_NAME");

                entity.Property(e => e.ContractSuccessCreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CONTRACT_SUCCESS_CREATE_DATE");

                entity.Property(e => e.ContractSuccessCreateUser)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_SUCCESS_CREATE_USER");

                entity.Property(e => e.ContractSuccessEditDate)
                    .HasPrecision(6)
                    .HasColumnName("CONTRACT_SUCCESS_EDIT_DATE");

                entity.Property(e => e.ContractSuccessEditUser)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_SUCCESS_EDIT_USER");

                entity.Property(e => e.ContractSuccessFFile)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_SUCCESS_F_FILE");

                entity.Property(e => e.ContractSuccessRemark)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_SUCCESS_REMARK");

                entity.Property(e => e.ContractSuccessRemarkKet)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_SUCCESS_REMARK_KET");

                entity.Property(e => e.ContractSuccessStatus)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_SUCCESS_STATUS");

                entity.Property(e => e.ContractSuccessType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_SUCCESS_TYPE");

                entity.Property(e => e.ContractTypeId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE_ID");

                entity.Property(e => e.ContractTypeName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE_NAME");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.CreateUserDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATE_USER_DATE");

                entity.Property(e => e.CreateUserFullname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER_FULLNAME");

                entity.Property(e => e.DepartmentCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_CODE");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_NAME");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.EditUserDate)
                    .HasColumnType("DATE")
                    .HasColumnName("EDIT_USER_DATE");

                entity.Property(e => e.EditUserFullname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER_FULLNAME");

                entity.Property(e => e.FRetarn)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("F_RETARN");

                entity.Property(e => e.FVendorlink)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("F_VENDORLINK");

                entity.Property(e => e.IdContract)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT");

                entity.Property(e => e.IdSmctMaster)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_SMCT_MASTER");

                entity.Property(e => e.ItemApproveDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ITEM_APPROVE_DATE");

                entity.Property(e => e.ItemApproveUser)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ITEM_APPROVE_USER");

                entity.Property(e => e.ItemBeginDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ITEM_BEGIN_DATE");

                entity.Property(e => e.ItemBeginUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ITEM_BEGIN_USER");

                entity.Property(e => e.ItemStatusCurr)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ITEM_STATUS_CURR");

                entity.Property(e => e.ItemStatusPrev)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ITEM_STATUS_PREV");

                entity.Property(e => e.KetRemark)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("KET_REMARK");

                entity.Property(e => e.RefDate)
                    .HasColumnType("DATE")
                    .HasColumnName("REF_DATE");

                entity.Property(e => e.RefId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("REF_ID");

                entity.Property(e => e.SbbRemark)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("SBB_REMARK");

                entity.Property(e => e.StationApproveDate)
                    .HasColumnType("DATE")
                    .HasColumnName("STATION_APPROVE_DATE");

                entity.Property(e => e.StationApproveUser)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("STATION_APPROVE_USER");

                entity.Property(e => e.StationBeginDate)
                    .HasColumnType("DATE")
                    .HasColumnName("STATION_BEGIN_DATE");

                entity.Property(e => e.StationBeginUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("STATION_BEGIN_USER");

                entity.Property(e => e.StationStatusCurr)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATION_STATUS_CURR");

                entity.Property(e => e.StationStatusPrev)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATION_STATUS_PREV");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.Property(e => e.VendorId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_ID");

                entity.Property(e => e.VendorName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_NAME");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.ContractStationSuccessCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_STATION_SUCCESS_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.ContractStationSuccessEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_STATION_SUCCESS_FK2");

                entity.HasOne(d => d.IdContractNavigation)
                    .WithMany(p => p.ContractStationSuccesses)
                    .HasForeignKey(d => d.IdContract)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_STATION_SUCCESS_FK4");

                entity.HasOne(d => d.IdSmctMasterNavigation)
                    .WithMany(p => p.ContractStationSuccesses)
                    .HasForeignKey(d => d.IdSmctMaster)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_STATION_SUCCESS_FK3");
            });

            modelBuilder.Entity<ContractStyle>(entity =>
            {
                entity.HasKey(e => e.IdContractStyle);

                entity.ToTable("CONTRACT_STYLE");

                entity.HasIndex(e => new { e.ContractStyleCode, e.Used }, "CONTRACT_STYLE_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdContractStyle)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_STYLE")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.ContractStyleCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_STYLE_CODE");

                entity.Property(e => e.ContractStyleFullName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_STYLE_FULL_NAME");

                entity.Property(e => e.ContractStyleShortName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_STYLE_SHORT_NAME");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.ContractStyleCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_STYLE_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.ContractStyleEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_STYLE_FK2");
            });

            modelBuilder.Entity<ContractType>(entity =>
            {
                entity.HasKey(e => e.IdContractType);

                entity.ToTable("CONTRACT_TYPE");

                entity.HasIndex(e => new { e.ContractTypeId, e.Used }, "CONTRACT_TYPE_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdContractType)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_TYPE")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.ContractTypeFullName)
                    .IsRequired()
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE_FULL_NAME");

                entity.Property(e => e.ContractTypeGroup)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE_GROUP");

                entity.Property(e => e.ContractTypeId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE_ID");

                entity.Property(e => e.ContractTypeIdOld)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE_ID_OLD");

                entity.Property(e => e.ContractTypeShortName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE_SHORT_NAME");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.FApprovalReq)
                    .HasPrecision(1)
                    .HasColumnName("F_APPROVAL_REQ");

                entity.Property(e => e.FContract)
                    .HasPrecision(1)
                    .HasColumnName("F_CONTRACT");

                entity.Property(e => e.FPay)
                    .HasPrecision(1)
                    .HasColumnName("F_PAY");

                entity.Property(e => e.Fm)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FM");

                entity.Property(e => e.GpType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GP_TYPE");

                entity.Property(e => e.IdContractStyle)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_STYLE");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.ContractTypeCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_TYPE_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.ContractTypeEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_TYPE_FK2");

                entity.HasOne(d => d.IdContractStyleNavigation)
                    .WithMany(p => p.ContractTypes)
                    .HasForeignKey(d => d.IdContractStyle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_TYPE_FK3");
            });

            modelBuilder.Entity<ContractVendor>(entity =>
            {
                entity.HasKey(e => e.IdContractVendor);

                entity.ToTable("CONTRACT_VENDOR");

                entity.HasIndex(e => new { e.IdContract, e.Used, e.VendorId }, "CONTRACT_VENDOR_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdContractVendor)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT_VENDOR")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.IdContract)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.Property(e => e.VendorId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_ID");

                entity.Property(e => e.VendorType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_TYPE");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.ContractVendorCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_VENDOR_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.ContractVendorEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_VENDOR_FK2");

                entity.HasOne(d => d.IdContractNavigation)
                    .WithMany(p => p.ContractVendors)
                    .HasForeignKey(d => d.IdContract)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRACT_VENDOR_FK3");
            });

            modelBuilder.Entity<EContractViewRpt1Mo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("E_CONTRACT_VIEW_RPT1_MO");

                entity.Property(e => e.Budget)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BUDGET");

                entity.Property(e => e.Budgetcode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BUDGETCODE");

                entity.Property(e => e.Budgetyear)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("BUDGETYEAR");

                entity.Property(e => e.ContractDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CONTRACT_DATE");

                entity.Property(e => e.ContractId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_ID");

                entity.Property(e => e.ContractName)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_NAME");

                entity.Property(e => e.ContractNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_NO");

                entity.Property(e => e.Deptcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DEPTCODE");

                entity.Property(e => e.EditUser)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER")
                    .IsFixedLength(true);

                entity.Property(e => e.EndDate)
                    .HasColumnType("DATE")
                    .HasColumnName("END_DATE");

                entity.Property(e => e.FFile)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("F_FILE");

                entity.Property(e => e.FReturn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("F_RETURN");

                entity.Property(e => e.OrderBudget)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ORDER_BUDGET");

                entity.Property(e => e.OrderDetail)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("ORDER_DETAIL");

                entity.Property(e => e.OrderNo)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ORDER_NO");

                entity.Property(e => e.OrderPay)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ORDER_PAY");

                entity.Property(e => e.Remark)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("REMARK");

                entity.Property(e => e.Reserve1)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RESERVE1");

                entity.Property(e => e.SourceType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SOURCE_TYPE")
                    .IsFixedLength(true);

                entity.Property(e => e.StartDate)
                    .HasColumnType("DATE")
                    .HasColumnName("START_DATE");

                entity.Property(e => e.TypeGroup)
                    .HasMaxLength(19)
                    .IsUnicode(false)
                    .HasColumnName("TYPE_GROUP");

                entity.Property(e => e.TypeId)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TYPE_ID");

                entity.Property(e => e.TypeName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TYPE_NAME");

                entity.Property(e => e.VendorId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_ID");
            });

            modelBuilder.Entity<EContractWebUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("E_CONTRACT_WEB_USER");

                entity.Property(e => e.Byuser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BYUSER");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Deptcode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("DEPTCODE");

                entity.Property(e => e.EditDate)
                    .HasColumnType("DATE")
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fax)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FAX");

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FNAME");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LNAME");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MOBILE");

                entity.Property(e => e.Pid)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("PID");

                entity.Property(e => e.Pwd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PWD");

                entity.Property(e => e.Tel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TEL");

                entity.Property(e => e.Ulevel)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ULEVEL");

                entity.Property(e => e.Upermission)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("UPERMISSION");

                entity.Property(e => e.Used)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USED");

                entity.Property(e => e.Userid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERID");
            });

            modelBuilder.Entity<EmDepartmentAddress>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EM_DEPARTMENT_ADDRESS");

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Address0)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS0");

                entity.Property(e => e.Address1)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS1");

                entity.Property(e => e.Address2)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS2");

                entity.Property(e => e.Address3)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS3");

                entity.Property(e => e.Address4)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS4");

                entity.Property(e => e.AmphurName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("AMPHUR_NAME");

                entity.Property(e => e.ChangwatName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CHANGWAT_NAME");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.CreatedUser)
                    .HasPrecision(10)
                    .HasColumnName("CREATED_USER");

                entity.Property(e => e.Dcode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("DCODE");

                entity.Property(e => e.EditedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("EDITED_DATE");

                entity.Property(e => e.EditedUser)
                    .HasPrecision(10)
                    .HasColumnName("EDITED_USER");

                entity.Property(e => e.Header)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("HEADER");

                entity.Property(e => e.Moo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MOO");

                entity.Property(e => e.MoobanName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MOOBAN_NAME");

                entity.Property(e => e.No)
                    .HasPrecision(10)
                    .HasColumnName("NO");

                entity.Property(e => e.Phone)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.PostCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("POST_CODE");

                entity.Property(e => e.Road)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ROAD");

                entity.Property(e => e.Soi)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SOI");

                entity.Property(e => e.TumbonName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TUMBON_NAME");

                entity.Property(e => e.Used)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USED")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<EmStatus>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EM_STATUS");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.CreatedUser)
                    .HasPrecision(10)
                    .HasColumnName("CREATED_USER");

                entity.Property(e => e.Drescription)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DRESCRIPTION");

                entity.Property(e => e.EditedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("EDITED_DATE");

                entity.Property(e => e.EditedUser)
                    .HasPrecision(10)
                    .HasColumnName("EDITED_USER");

                entity.Property(e => e.FieldName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FIELD_NAME");

                entity.Property(e => e.No)
                    .HasPrecision(10)
                    .HasColumnName("NO");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.TableName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TABLE_NAME");

                entity.Property(e => e.Used)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USED")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<EmTitle>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EM_TITLE");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CODE");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.CreatedUser)
                    .HasPrecision(10)
                    .HasColumnName("CREATED_USER");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.EditedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("EDITED_DATE");

                entity.Property(e => e.EditedUser)
                    .HasPrecision(10)
                    .HasColumnName("EDITED_USER");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.No)
                    .HasPrecision(10)
                    .HasColumnName("NO");

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SHORT_NAME");

                entity.Property(e => e.Used)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USED")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<EmUser>(entity =>
            {
                entity.HasKey(e => e.No);

                entity.ToTable("EM_USER");

                entity.HasIndex(e => e.Username, "UNQ2_EM_USER")
                    .IsUnique();

                entity.Property(e => e.No)
                    .HasPrecision(10)
                    .ValueGeneratedNever()
                    .HasColumnName("NO");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.CreatedUser)
                    .HasPrecision(10)
                    .HasColumnName("CREATED_USER");

                entity.Property(e => e.EditedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("EDITED_DATE");

                entity.Property(e => e.EditedUser)
                    .HasPrecision(10)
                    .HasColumnName("EDITED_USER");

                entity.Property(e => e.Pwd)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PWD");

                entity.Property(e => e.Remark)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("REMARK");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.TypeNo)
                    .HasPrecision(10)
                    .HasColumnName("TYPE_NO");

                entity.Property(e => e.Used)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USED")
                    .IsFixedLength(true);

                entity.Property(e => e.Userid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERID");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");
            });

            modelBuilder.Entity<EmUserRigth>(entity =>
            {
                entity.HasKey(e => e.No);

                entity.ToTable("EM_USER_RIGTHS");

                entity.Property(e => e.No)
                    .HasPrecision(10)
                    .ValueGeneratedNever()
                    .HasColumnName("NO");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.CreatedUser)
                    .HasPrecision(10)
                    .HasColumnName("CREATED_USER");

                entity.Property(e => e.EditedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("EDITED_DATE");

                entity.Property(e => e.EditedUser)
                    .HasPrecision(10)
                    .HasColumnName("EDITED_USER");

                entity.Property(e => e.Permission)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PERMISSION");

                entity.Property(e => e.RoleNo)
                    .HasPrecision(10)
                    .HasColumnName("ROLE_NO");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Used)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USED")
                    .IsFixedLength(true);

                entity.Property(e => e.UserNo)
                    .HasPrecision(10)
                    .HasColumnName("USER_NO");

                entity.HasOne(d => d.CreatedUserNavigation)
                    .WithMany(p => p.EmUserRigthCreatedUserNavigations)
                    .HasForeignKey(d => d.CreatedUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK3_EM_USER_RIGTHS");

                entity.HasOne(d => d.EditedUserNavigation)
                    .WithMany(p => p.EmUserRigthEditedUserNavigations)
                    .HasForeignKey(d => d.EditedUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK4_EM_USER_RIGTHS");

                entity.HasOne(d => d.UserNoNavigation)
                    .WithMany(p => p.EmUserRigthUserNoNavigations)
                    .HasForeignKey(d => d.UserNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK1_EM_USER_RIGTHS");
            });

            modelBuilder.Entity<EmUserRole>(entity =>
            {
                entity.HasKey(e => e.No);

                entity.ToTable("EM_USER_ROLE");

                entity.Property(e => e.No)
                    .HasPrecision(10)
                    .ValueGeneratedNever()
                    .HasColumnName("NO");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.CreatedUser)
                    .HasPrecision(10)
                    .HasColumnName("CREATED_USER");

                entity.Property(e => e.Drescription)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DRESCRIPTION");

                entity.Property(e => e.EditedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("EDITED_DATE");

                entity.Property(e => e.EditedUser)
                    .HasPrecision(10)
                    .HasColumnName("EDITED_USER");

                entity.Property(e => e.GroupCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GROUP_CODE");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Used)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USED")
                    .IsFixedLength(true);

                entity.HasOne(d => d.CreatedUserNavigation)
                    .WithMany(p => p.EmUserRoleCreatedUserNavigations)
                    .HasForeignKey(d => d.CreatedUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK1_EM_USER_ROLE");

                entity.HasOne(d => d.EditedUserNavigation)
                    .WithMany(p => p.EmUserRoleEditedUserNavigations)
                    .HasForeignKey(d => d.EditedUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK2_EM_USER_ROLE");
            });

            modelBuilder.Entity<EmUserType>(entity =>
            {
                entity.HasKey(e => e.No);

                entity.ToTable("EM_USER_TYPE");

                entity.Property(e => e.No)
                    .HasPrecision(10)
                    .ValueGeneratedNever()
                    .HasColumnName("NO");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.CreatedUser)
                    .HasPrecision(10)
                    .HasColumnName("CREATED_USER");

                entity.Property(e => e.Drescription)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DRESCRIPTION");

                entity.Property(e => e.EditedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("EDITED_DATE");

                entity.Property(e => e.EditedUser)
                    .HasPrecision(10)
                    .HasColumnName("EDITED_USER");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Used)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USED")
                    .IsFixedLength(true);

                entity.HasOne(d => d.CreatedUserNavigation)
                    .WithMany(p => p.EmUserTypeCreatedUserNavigations)
                    .HasForeignKey(d => d.CreatedUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK1_EM_USER_TYPE");

                entity.HasOne(d => d.EditedUserNavigation)
                    .WithMany(p => p.EmUserTypeEditedUserNavigations)
                    .HasForeignKey(d => d.EditedUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK2_EM_USER_TYPE");
            });

            modelBuilder.Entity<EmpBureau>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EMP_BUREAU");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EmpBudesc)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("EMP_BUDESC");

                entity.Property(e => e.EmpBuid)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EMP_BUID");

                entity.Property(e => e.EmpBuidO)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EMP_BUID_O");

                entity.Property(e => e.ModDate)
                    .HasColumnType("DATE")
                    .HasColumnName("MOD_DATE");

                entity.Property(e => e.ModUser)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MOD_USER");

                entity.Property(e => e.Permission)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PERMISSION");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");
            });

            modelBuilder.Entity<EmployeePhone>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EMPLOYEE_PHONE");

                entity.Property(e => e.Convert)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CONVERT");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EmpBureau)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("EMP_BUREAU");

                entity.Property(e => e.EmpBureauid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EMP_BUREAUID");

                entity.Property(e => e.EmpBureauidOld)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EMP_BUREAUID_OLD");

                entity.Property(e => e.EmpEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMP_EMAIL");

                entity.Property(e => e.EmpEmail2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMP_EMAIL2");

                entity.Property(e => e.EmpEnname)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("EMP_ENNAME");

                entity.Property(e => e.EmpExt)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EMP_EXT");

                entity.Property(e => e.EmpFax)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMP_FAX");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EMP_ID");

                entity.Property(e => e.EmpLevel)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EMP_LEVEL");

                entity.Property(e => e.EmpMobile1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMP_MOBILE1");

                entity.Property(e => e.EmpMobile2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMP_MOBILE2");

                entity.Property(e => e.EmpNickname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMP_NICKNAME");

                entity.Property(e => e.EmpOperlevel)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EMP_OPERLEVEL");

                entity.Property(e => e.EmpOrder)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("EMP_ORDER");

                entity.Property(e => e.EmpPassword)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EMP_PASSWORD");

                entity.Property(e => e.EmpPicture)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("EMP_PICTURE");

                entity.Property(e => e.EmpPosition)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("EMP_POSITION");

                entity.Property(e => e.EmpTele1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMP_TELE1");

                entity.Property(e => e.EmpTele2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMP_TELE2");

                entity.Property(e => e.EmpThname)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("EMP_THNAME");

                entity.Property(e => e.EmpUser)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EMP_USER");

                entity.Property(e => e.Fname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FNAME");

                entity.Property(e => e.JobDescription)
                    .IsUnicode(false)
                    .HasColumnName("JOB_DESCRIPTION");

                entity.Property(e => e.Lname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LNAME");

                entity.Property(e => e.ModDate)
                    .HasColumnType("DATE")
                    .HasColumnName("MOD_DATE");

                entity.Property(e => e.ModUser)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MOD_USER");

                entity.Property(e => e.Pid)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("PID");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.WorkGroup)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("WORK_GROUP");
            });

            modelBuilder.Entity<GuaranteeLgReq>(entity =>
            {
                entity.HasKey(e => e.IdGuaranteeLgReq)
                    .HasName("GUARANTEE_LG_REQ_PK");

                entity.ToTable("GUARANTEE_LG_REQ");

                entity.Property(e => e.IdGuaranteeLgReq)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_GUARANTEE_LG_REQ")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.AppTypeId)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("APP_TYPE_ID");

                entity.Property(e => e.BeneficiaryRefNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("BENEFICIARY_REF_NO");

                entity.Property(e => e.ChannelId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CHANNEL_ID");

                entity.Property(e => e.Comments)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("COMMENTS");

                entity.Property(e => e.ContractDate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_DATE");

                entity.Property(e => e.ContractDetail)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_DETAIL");

                entity.Property(e => e.ContractNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_NO");

                entity.Property(e => e.ContractTypeId)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE_ID");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.EffectiveDateEnd)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EFFECTIVE_DATE_END");

                entity.Property(e => e.EffectiveDateStart)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EFFECTIVE_DATE_START");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.GuaranteeTypeId)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GUARANTEE_TYPE_ID");

                entity.Property(e => e.HospitalCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("HOSPITAL_CODE");

                entity.Property(e => e.HospitalName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("HOSPITAL_NAME");

                entity.Property(e => e.IdSmctMaster)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_SMCT_MASTER");

                entity.Property(e => e.LastupdateDate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LASTUPDATE_DATE");

                entity.Property(e => e.LastupdateTime)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("LASTUPDATE_TIME");

                entity.Property(e => e.LgAmount)
                    .HasColumnType("NUMBER(17,2)")
                    .HasColumnName("LG_AMOUNT");

                entity.Property(e => e.LgAmountInitial)
                    .HasColumnType("NUMBER(17,2)")
                    .HasColumnName("LG_AMOUNT_INITIAL");

                entity.Property(e => e.LgNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LG_NUMBER");

                entity.Property(e => e.LgStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LG_STATUS");

                entity.Property(e => e.RequesterNameTh)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("REQUESTER_NAME_TH");

                entity.Property(e => e.Sms)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SMS");

                entity.Property(e => e.TaxId)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("TAX_ID");

                entity.Property(e => e.TransDate)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TRANS_DATE");

                entity.Property(e => e.TransTime)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("TRANS_TIME");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.GuaranteeLgReqCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GUARANTEE_LG_REQ_FK2");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.GuaranteeLgReqEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GUARANTEE_LG_REQ_FK3");

                entity.HasOne(d => d.IdSmctMasterNavigation)
                    .WithMany(p => p.GuaranteeLgReqs)
                    .HasForeignKey(d => d.IdSmctMaster)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GUARANTEE_LG_REQ_FK1");
            });

            modelBuilder.Entity<GuaranteeLgReqStation>(entity =>
            {
                entity.HasKey(e => e.IdGuaranteeLgReqStation)
                    .HasName("GUARANTEE_LG_REQ_STATION_PK");

                entity.ToTable("GUARANTEE_LG_REQ_STATION");

                entity.Property(e => e.IdGuaranteeLgReqStation)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_GUARANTEE_LG_REQ_STATION")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.AppTypeId)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("APP_TYPE_ID");

                entity.Property(e => e.Budgetyear)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("BUDGETYEAR");

                entity.Property(e => e.ContractDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CONTRACT_DATE");

                entity.Property(e => e.ContractId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_ID");

                entity.Property(e => e.ContractName)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_NAME");

                entity.Property(e => e.ContractTypeDesc)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE_DESC");

                entity.Property(e => e.ContractTypeId)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE_ID");

                entity.Property(e => e.ContractTypeName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE_NAME");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.DepartmentCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_CODE");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_NAME");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.EffectiveDateEnd)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EFFECTIVE_DATE_END");

                entity.Property(e => e.EffectiveDateStart)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EFFECTIVE_DATE_START");

                entity.Property(e => e.GuaranteeTypeDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GUARANTEE_TYPE_DESC");

                entity.Property(e => e.GuaranteeTypeId)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GUARANTEE_TYPE_ID");

                entity.Property(e => e.IdContract)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_CONTRACT");

                entity.Property(e => e.IdGuaranteeLgReq)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_GUARANTEE_LG_REQ");

                entity.Property(e => e.IdSmctMaster)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_SMCT_MASTER");

                entity.Property(e => e.LgAmount)
                    .HasColumnType("NUMBER(17,2)")
                    .HasColumnName("LG_AMOUNT");

                entity.Property(e => e.LgAmountInitial)
                    .HasColumnType("NUMBER(17,2)")
                    .HasColumnName("LG_AMOUNT_INITIAL");

                entity.Property(e => e.LgNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LG_NUMBER");

                entity.Property(e => e.LgStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LG_STATUS");

                entity.Property(e => e.RefDate)
                    .HasColumnType("DATE")
                    .HasColumnName("REF_DATE");

                entity.Property(e => e.RefId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("REF_ID");

                entity.Property(e => e.RequesterNameTh)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("REQUESTER_NAME_TH");

                entity.Property(e => e.TaxId)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("TAX_ID");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.GuaranteeLgReqStationCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GUARANTEE_LG_REQ_STATION_FK4");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.GuaranteeLgReqStationEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GUARANTEE_LG_REQ_STATION_FK5");

                entity.HasOne(d => d.IdContractNavigation)
                    .WithMany(p => p.GuaranteeLgReqStations)
                    .HasForeignKey(d => d.IdContract)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GUARANTEE_LG_REQ_STATION_FK2");

                entity.HasOne(d => d.IdGuaranteeLgReqNavigation)
                    .WithMany(p => p.GuaranteeLgReqStations)
                    .HasForeignKey(d => d.IdGuaranteeLgReq)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GUARANTEE_LG_REQ_STATION_FK3");

                entity.HasOne(d => d.IdSmctMasterNavigation)
                    .WithMany(p => p.GuaranteeLgReqStations)
                    .HasForeignKey(d => d.IdSmctMaster)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GUARANTEE_LG_REQ_STATION_FK1");
            });

            modelBuilder.Entity<LOrgOther>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("L_ORG_OTHER");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNT_ID");

                entity.Property(e => e.AccountName)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNT_NAME");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.BankB)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BANK_B");

                entity.Property(e => e.BankId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("BANK_ID");

                entity.Property(e => e.Byuser)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("BYUSER");

                entity.Property(e => e.Catm)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CATM");

                entity.Property(e => e.ContractorName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACTOR_NAME");

                entity.Property(e => e.ContractorPid)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACTOR_PID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fax)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FAX");

                entity.Property(e => e.HospDmis)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("HOSP_DMIS");

                entity.Property(e => e.Inserted)
                    .HasColumnType("DATE")
                    .HasColumnName("INSERTED");

                entity.Property(e => e.Lastupdate)
                    .HasColumnType("DATE")
                    .HasColumnName("LASTUPDATE");

                entity.Property(e => e.MinstId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MINST_ID");

                entity.Property(e => e.MinstName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MINST_NAME");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MOBILE");

                entity.Property(e => e.OrgType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ORG_TYPE");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.PostCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("POST_CODE");

                entity.Property(e => e.ProvinceId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PROVINCE_ID");

                entity.Property(e => e.Remark)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REMARK");

                entity.Property(e => e.ReqNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("REQ_NO");

                entity.Property(e => e.Road)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROAD");

                entity.Property(e => e.Seq)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SEQ");

                entity.Property(e => e.Soi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SOI");

                entity.Property(e => e.TId)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("T_ID");

                entity.Property(e => e.Used)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("USED");

                entity.Property(e => e.VendorId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_ID");

                entity.Property(e => e.VendorName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_NAME");
            });

            modelBuilder.Entity<LkAmphur>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("LK_AMPHUR");

                entity.Property(e => e.AmphurId)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("AMPHUR_ID");

                entity.Property(e => e.Available)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVAILABLE");

                entity.Property(e => e.Code)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CODE");

                entity.Property(e => e.Gyear)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GYEAR");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.ProvinceId)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PROVINCE_ID");
            });

            modelBuilder.Entity<LkBank>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("LK_BANK");

                entity.Property(e => e.BankId)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("BANK_ID");

                entity.Property(e => e.BankName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("BANK_NAME");
            });

            modelBuilder.Entity<LkCatm>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("LK_CATM");

                entity.Property(e => e.AmphurName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("AMPHUR_NAME");

                entity.Property(e => e.Catm)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CATM");

                entity.Property(e => e.ChangwatName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CHANGWAT_NAME");

                entity.Property(e => e.Moo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("MOO");

                entity.Property(e => e.MoobanName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("MOOBAN_NAME");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Seq)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SEQ");

                entity.Property(e => e.TumbonName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("TUMBON_NAME");
            });

            modelBuilder.Entity<LkDepartment>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("LK_DEPARTMENT");

                entity.Property(e => e.BureauId)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("BUREAU_ID");

                entity.Property(e => e.Dcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DCODE");

                entity.Property(e => e.DcodeShort)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DCODE_SHORT");

                entity.Property(e => e.Dename)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DENAME");

                entity.Property(e => e.Display)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DISPLAY");

                entity.Property(e => e.Dname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DNAME");

                entity.Property(e => e.DnameNew)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DNAME_NEW");

                entity.Property(e => e.EmpBuid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EMP_BUID");

                entity.Property(e => e.LogDate)
                    .HasColumnType("DATE")
                    .HasColumnName("LOG_DATE");

                entity.Property(e => e.LogUser)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LOG_USER");

                entity.Property(e => e.NhsoZone)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("NHSO_ZONE")
                    .IsFixedLength(true);

                entity.Property(e => e.Orderno)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ORDERNO");

                entity.Property(e => e.ProvinceId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PROVINCE_ID");

                entity.Property(e => e.Status)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Subject)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SUBJECT");
            });

            modelBuilder.Entity<LkDistrict>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("LK_DISTRICT");

                entity.Property(e => e.AmphurId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("AMPHUR_ID");

                entity.Property(e => e.Available)
                    .HasPrecision(2)
                    .HasColumnName("AVAILABLE");

                entity.Property(e => e.Code)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CODE");

                entity.Property(e => e.DistrictId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("DISTRICT_ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.ProvinceId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("PROVINCE_ID");
            });

            modelBuilder.Entity<LkProvince>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("LK_PROVINCE");

                entity.Property(e => e.Countryzone)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRYZONE");

                entity.Property(e => e.DdcZone)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("DDC_ZONE");

                entity.Property(e => e.MophZone)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("MOPH_ZONE");

                entity.Property(e => e.NhsoZone)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("NHSO_ZONE")
                    .IsFixedLength(true);

                entity.Property(e => e.NhsoZonename)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NHSO_ZONENAME");

                entity.Property(e => e.NhsoZoneold)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("NHSO_ZONEOLD");

                entity.Property(e => e.ProvinceId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("PROVINCE_ID");

                entity.Property(e => e.ProvinceName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PROVINCE_NAME");

                entity.Property(e => e.Region)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("REGION");

                entity.Property(e => e.RegionName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("REGION_NAME");

                entity.Property(e => e.Seq)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SEQ");
            });

            modelBuilder.Entity<LmHospital>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("LM_HOSPITAL");

                entity.Property(e => e.AccName)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("ACC_NAME");

                entity.Property(e => e.AccNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ACC_NO");

                entity.Property(e => e.Address)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.BankB)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BANK_B");

                entity.Property(e => e.BankId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("BANK_ID");

                entity.Property(e => e.Bed)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("BED");

                entity.Property(e => e.Catm)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CATM");

                entity.Property(e => e.ContractorName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACTOR_NAME");

                entity.Property(e => e.ContractorPid)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACTOR_PID");

                entity.Property(e => e.CreateDatetime)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATE_DATETIME");

                entity.Property(e => e.CreateUid)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_UID");

                entity.Property(e => e.CrossProvince)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CROSS_PROVINCE");

                entity.Property(e => e.Datein)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEIN");

                entity.Property(e => e.Datein2)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEIN2");

                entity.Property(e => e.Dateout)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEOUT");

                entity.Property(e => e.Dateout2)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEOUT2");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FHcap)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("F_HCAP");

                entity.Property(e => e.FHreserve)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("F_HRESERVE");

                entity.Property(e => e.FHsss)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("F_HSSS");

                entity.Property(e => e.FInclusive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("F_INCLUSIVE");

                entity.Property(e => e.FStatus)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("F_STATUS");

                entity.Property(e => e.FUc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("F_UC");

                entity.Property(e => e.Fax)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FAX");

                entity.Property(e => e.Hclass)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("HCLASS");

                entity.Property(e => e.Hcode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("HCODE");

                entity.Property(e => e.Hcode9)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("HCODE9");

                entity.Property(e => e.HcodeOld)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("HCODE_OLD");

                entity.Property(e => e.HcodeSss)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("HCODE_SSS");

                entity.Property(e => e.Hfund)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("HFUND");

                entity.Property(e => e.Hid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("HID");

                entity.Property(e => e.Hlevel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("HLEVEL");

                entity.Property(e => e.Hmodel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("HMODEL");

                entity.Property(e => e.Hname)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("HNAME");

                entity.Property(e => e.HospDmis)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("HOSP_DMIS");

                entity.Property(e => e.Hrib)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("HRIB");

                entity.Property(e => e.Htitle)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("HTITLE");

                entity.Property(e => e.Htype)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("HTYPE");

                entity.Property(e => e.LogDate)
                    .HasColumnType("DATE")
                    .HasColumnName("LOG_DATE");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MOBILE");

                entity.Property(e => e.Moo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MOO");

                entity.Property(e => e.PostCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("POST_CODE");

                entity.Property(e => e.ProvinceId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("PROVINCE_ID");

                entity.Property(e => e.Remarks)
                    .IsUnicode(false)
                    .HasColumnName("REMARKS");

                entity.Property(e => e.ReqNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("REQ_NO");

                entity.Property(e => e.Road)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ROAD");

                entity.Property(e => e.Soi)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("SOI");

                entity.Property(e => e.Subtype)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SUBTYPE");

                entity.Property(e => e.Tel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TEL");

                entity.Property(e => e.TumbonName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TUMBON_NAME");

                entity.Property(e => e.UpdateDatetime)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATE_DATETIME");

                entity.Property(e => e.UpdateUid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_UID");

                entity.Property(e => e.Used)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USED");

                entity.Property(e => e.VendorId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_ID");

                entity.Property(e => e.Website)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WEBSITE");

                entity.Property(e => e.Weight)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("WEIGHT");
            });

            modelBuilder.Entity<LmHtitle>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("LM_HTITLE");

                entity.Property(e => e.CreateDatetime)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATE_DATETIME");

                entity.Property(e => e.CreateUid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_UID");

                entity.Property(e => e.HtitleId)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("HTITLE_ID");

                entity.Property(e => e.HtitleName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("HTITLE_NAME");

                entity.Property(e => e.Remarks)
                    .IsUnicode(false)
                    .HasColumnName("REMARKS");

                entity.Property(e => e.ShortName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SHORT_NAME");

                entity.Property(e => e.UpdateDatetime)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATE_DATETIME");

                entity.Property(e => e.UpdateUid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_UID");

                entity.Property(e => e.Used)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USED");
            });

            modelBuilder.Entity<LogSendmail>(entity =>
            {
                entity.HasKey(e => e.Emailid)
                    .HasName("SYS_C00389275");

                entity.ToTable("LOG_SENDMAIL");

                entity.Property(e => e.Emailid)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EMAILID")
                    .HasDefaultValueSql("sys_guid()");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.Emailto)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMAILTO");

                entity.Property(e => e.IsCompleted)
                    .HasPrecision(1)
                    .HasColumnName("IS_COMPLETED");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.PkId)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("PK_ID");

                entity.Property(e => e.RefId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("REF_ID");

                entity.Property(e => e.StatusMessage)
                    .IsUnicode(false)
                    .HasColumnName("STATUS_MESSAGE");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(450)
                    .IsUnicode(false)
                    .HasColumnName("SUBJECT");

                entity.Property(e => e.Template)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("TEMPLATE");
            });

            modelBuilder.Entity<RSmctRpt1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("R_SMCT_RPT1");

                entity.Property(e => e.Budgetyear)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("BUDGETYEAR");

                entity.Property(e => e.ContractDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CONTRACT_DATE");

                entity.Property(e => e.ContractId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_ID");

                entity.Property(e => e.ContractPeriodBudget)
                    .HasColumnType("NUMBER(18,2)")
                    .HasColumnName("CONTRACT_PERIOD_BUDGET");

                entity.Property(e => e.ContractPeriodBudgetcode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_PERIOD_BUDGETCODE");

                entity.Property(e => e.ContractPeriodNo)
                    .HasPrecision(2)
                    .HasColumnName("CONTRACT_PERIOD_NO");

                entity.Property(e => e.ContractPeriodPay)
                    .HasColumnType("NUMBER(18,2)")
                    .HasColumnName("CONTRACT_PERIOD_PAY");

                entity.Property(e => e.ContractPeriodRemain)
                    .HasColumnType("NUMBER(18,2)")
                    .HasColumnName("CONTRACT_PERIOD_REMAIN");

                entity.Property(e => e.ContractPeriodVendorId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_PERIOD_VENDOR_ID");

                entity.Property(e => e.ContractTypeGroup)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE_GROUP");

                entity.Property(e => e.ContractTypeId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE_ID");

                entity.Property(e => e.ContractTypeName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE_NAME");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.DepartmentCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_CODE");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_NAME");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EndDate)
                    .HasColumnType("DATE")
                    .HasColumnName("END_DATE");

                entity.Property(e => e.FFile)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("F_FILE");

                entity.Property(e => e.FundTypeCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FUND_TYPE_CODE");

                entity.Property(e => e.FundTypeName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FUND_TYPE_NAME");

                entity.Property(e => e.IdRSmctRpt1)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_R_SMCT_RPT1")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.RefDate)
                    .HasColumnType("DATE")
                    .HasColumnName("REF_DATE");

                entity.Property(e => e.RefId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("REF_ID");

                entity.Property(e => e.StartDate)
                    .HasColumnType("DATE")
                    .HasColumnName("START_DATE");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.StatusType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS_TYPE");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.Property(e => e.VendorId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_ID");

                entity.Property(e => e.VendorName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_NAME");

                entity.Property(e => e.YyyymmAt)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("YYYYMM_AT");
            });

            modelBuilder.Entity<RSmctRpt2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("R_SMCT_RPT2");

                entity.Property(e => e.Budgetyear)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("BUDGETYEAR");

                entity.Property(e => e.ContractDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CONTRACT_DATE");

                entity.Property(e => e.ContractId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_ID");

                entity.Property(e => e.ContractPeriodBudget)
                    .HasColumnType("NUMBER(18,2)")
                    .HasColumnName("CONTRACT_PERIOD_BUDGET");

                entity.Property(e => e.ContractPeriodBudgetcode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_PERIOD_BUDGETCODE");

                entity.Property(e => e.ContractPeriodNo)
                    .HasPrecision(2)
                    .HasColumnName("CONTRACT_PERIOD_NO");

                entity.Property(e => e.ContractPeriodPay)
                    .HasColumnType("NUMBER(18,2)")
                    .HasColumnName("CONTRACT_PERIOD_PAY");

                entity.Property(e => e.ContractPeriodRemain)
                    .HasColumnType("NUMBER(18,2)")
                    .HasColumnName("CONTRACT_PERIOD_REMAIN");

                entity.Property(e => e.ContractPeriodVendorId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_PERIOD_VENDOR_ID");

                entity.Property(e => e.ContractTypeGroup)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE_GROUP");

                entity.Property(e => e.ContractTypeId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE_ID");

                entity.Property(e => e.ContractTypeName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE_NAME");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.DepartmentCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_CODE");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_NAME");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EndDate)
                    .HasColumnType("DATE")
                    .HasColumnName("END_DATE");

                entity.Property(e => e.FFile)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("F_FILE");

                entity.Property(e => e.FundTypeCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FUND_TYPE_CODE");

                entity.Property(e => e.FundTypeName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FUND_TYPE_NAME");

                entity.Property(e => e.IdRSmctRpt2)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_R_SMCT_RPT2")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.RefDate)
                    .HasColumnType("DATE")
                    .HasColumnName("REF_DATE");

                entity.Property(e => e.RefId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("REF_ID");

                entity.Property(e => e.StartDate)
                    .HasColumnType("DATE")
                    .HasColumnName("START_DATE");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.StatusType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS_TYPE");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.Property(e => e.VendorId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_ID");

                entity.Property(e => e.VendorName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_NAME");

                entity.Property(e => e.YyyymmAt)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("YYYYMM_AT");
            });

            modelBuilder.Entity<RegisterNhso>(entity =>
            {
                entity.HasKey(e => e.IdRegisterNhso);

                entity.ToTable("REGISTER_NHSO");

                entity.HasIndex(e => e.RegisterNo, "REGISTER_NHSO_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdRegisterNhso)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_REGISTER_NHSO")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.Building)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BUILDING");

                entity.Property(e => e.Catm)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CATM");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_NAME");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.DepartmentCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_CODE");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fax)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FAX");

                entity.Property(e => e.Hcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("HCODE");

                entity.Property(e => e.Moo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MOO");

                entity.Property(e => e.Phone)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.PostCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("POST_CODE");

                entity.Property(e => e.ProvinceId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PROVINCE_ID");

                entity.Property(e => e.RegisterAt)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("REGISTER_AT");

                entity.Property(e => e.RegisterNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("REGISTER_NO");

                entity.Property(e => e.RegisterType)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("REGISTER_TYPE");

                entity.Property(e => e.Remark)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REMARK");

                entity.Property(e => e.Road)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ROAD");

                entity.Property(e => e.Soi)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SOI");

                entity.Property(e => e.Sp7)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SP7");

                entity.Property(e => e.Sp7Date)
                    .HasColumnType("DATE")
                    .HasColumnName("SP7_DATE");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.TaxId)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("TAX_ID");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.Property(e => e.VendorId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_ID");

                entity.Property(e => e.VendorName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_NAME");

                entity.Property(e => e.VillageNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VILLAGE_NO");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.RegisterNhsoCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("REGISTER_NHSO_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.RegisterNhsoEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("REGISTER_NHSO_FK2");
            });

            modelBuilder.Entity<RegisterNhsoFile>(entity =>
            {
                entity.HasKey(e => e.IdRegisterNhsoFile);

                entity.ToTable("REGISTER_NHSO_FILE");

                entity.Property(e => e.IdRegisterNhsoFile)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_REGISTER_NHSO_FILE")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.IdRegisterNhso)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_REGISTER_NHSO");

                entity.Property(e => e.IdRegisterNhsoFileType)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_REGISTER_NHSO_FILE_TYPE");

                entity.Property(e => e.PathFolder)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PATH_FOLDER");

                entity.Property(e => e.RegisterFileFtp)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REGISTER_FILE_FTP");

                entity.Property(e => e.RegisterFileName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REGISTER_FILE_NAME");

                entity.Property(e => e.RegisterFileNo)
                    .HasColumnType("NUMBER")
                    .HasColumnName("REGISTER_FILE_NO");

                entity.Property(e => e.RegisterFileType)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("REGISTER_FILE_TYPE");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.RegisterNhsoFileCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("REGISTER_NHSO_FILE_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.RegisterNhsoFileEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("REGISTER_NHSO_FILE_FK2");

                entity.HasOne(d => d.IdRegisterNhsoNavigation)
                    .WithMany(p => p.RegisterNhsoFiles)
                    .HasForeignKey(d => d.IdRegisterNhso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("REGISTER_NHSO_FILE_FK3");

                entity.HasOne(d => d.IdRegisterNhsoFileTypeNavigation)
                    .WithMany(p => p.RegisterNhsoFiles)
                    .HasForeignKey(d => d.IdRegisterNhsoFileType)
                    .HasConstraintName("REGISTER_NHSO_FILE_FK4");
            });

            modelBuilder.Entity<RegisterNhsoFileType>(entity =>
            {
                entity.HasKey(e => e.IdRegisterNhsoFileType);

                entity.ToTable("REGISTER_NHSO_FILE_TYPE");

                entity.HasIndex(e => new { e.Used, e.FileTypeId }, "REGISTER_NHSO_FILE_TYPE_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdRegisterNhsoFileType)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_REGISTER_NHSO_FILE_TYPE")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.FileTypeGroup)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FILE_TYPE_GROUP");

                entity.Property(e => e.FileTypeId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FILE_TYPE_ID");

                entity.Property(e => e.FileTypeName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FILE_TYPE_NAME");

                entity.Property(e => e.FileTypeParentId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FILE_TYPE_PARENT_ID");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.RegisterNhsoFileTypeCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("REGISTER_NHSO_FILE_TYPE_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.RegisterNhsoFileTypeEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("REGISTER_NHSO_FILE_TYPE_FK2");
            });

            modelBuilder.Entity<SmctMaster>(entity =>
            {
                entity.HasKey(e => e.IdSmctMaster);

                entity.ToTable("SMCT_MASTER");

                entity.HasIndex(e => new { e.RefId, e.Used }, "SMCT_MASTER_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdSmctMaster)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_SMCT_MASTER")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.Budgetyear)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("BUDGETYEAR");

                entity.Property(e => e.ContractSignType)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_SIGN_TYPE");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.DepartmentCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_CODE");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.FVendorlink)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("F_VENDORLINK");

                entity.Property(e => e.IdRegisterNhso)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_REGISTER_NHSO");

                entity.Property(e => e.RefDate)
                    .HasColumnType("DATE")
                    .HasColumnName("REF_DATE");

                entity.Property(e => e.RefId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("REF_ID");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.SmctMasterCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SMCT_MASTER_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.SmctMasterEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SMCT_MASTER_FK2");

                entity.HasOne(d => d.IdRegisterNhsoNavigation)
                    .WithMany(p => p.SmctMasters)
                    .HasForeignKey(d => d.IdRegisterNhso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SMCT_MASTER_FK3");
            });

            modelBuilder.Entity<SmctMasterFile>(entity =>
            {
                entity.HasKey(e => e.IdSmctMasterFile);

                entity.ToTable("SMCT_MASTER_FILE");

                entity.HasIndex(e => new { e.IdSmctMaster, e.Used, e.FileNo, e.FileType }, "SMCT_MASTER_FILE_UK1")
                    .IsUnique();

                entity.Property(e => e.IdSmctMasterFile)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_SMCT_MASTER_FILE")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.FileFtp)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FILE_FTP");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FILE_NAME");

                entity.Property(e => e.FileNo)
                    .HasColumnType("NUMBER")
                    .HasColumnName("FILE_NO");

                entity.Property(e => e.FileType)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("FILE_TYPE");

                entity.Property(e => e.IdSmctMaster)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_SMCT_MASTER");

                entity.Property(e => e.IdSmctMasterFileType)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_SMCT_MASTER_FILE_TYPE");

                entity.Property(e => e.PathFolder)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PATH_FOLDER");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.SmctMasterFileCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SMCT_MASTER_FILE_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.SmctMasterFileEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SMCT_MASTER_FILE_FK2");

                entity.HasOne(d => d.IdSmctMasterNavigation)
                    .WithMany(p => p.SmctMasterFiles)
                    .HasForeignKey(d => d.IdSmctMaster)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SMCT_MASTER_FILE_FK3");

                entity.HasOne(d => d.IdSmctMasterFileTypeNavigation)
                    .WithMany(p => p.SmctMasterFiles)
                    .HasForeignKey(d => d.IdSmctMasterFileType)
                    .HasConstraintName("SMCT_MASTER_FILE_FK4");
            });

            modelBuilder.Entity<SmctMasterFileType>(entity =>
            {
                entity.HasKey(e => e.IdSmctMasterFileType);

                entity.ToTable("SMCT_MASTER_FILE_TYPE");

                entity.HasIndex(e => new { e.FileTypeId, e.Used }, "SMCT_MASTER_FILE_TYPE_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdSmctMasterFileType)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_SMCT_MASTER_FILE_TYPE")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.ContractTypeId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE_ID");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.FileTypeGroup)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FILE_TYPE_GROUP");

                entity.Property(e => e.FileTypeId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FILE_TYPE_ID");

                entity.Property(e => e.FileTypeName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FILE_TYPE_NAME");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.SmctMasterFileTypeCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SMCT_MASTER_FILE_TYPE_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.SmctMasterFileTypeEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SMCT_MASTER_FILE_TYPE_FK2");
            });

            modelBuilder.Entity<SmctMasterSendmail>(entity =>
            {
                entity.HasKey(e => e.IdSmctMasterSendmail)
                    .HasName("SMCT_MASTER_SENDMAIL_PK");

                entity.ToTable("SMCT_MASTER_SENDMAIL");

                entity.Property(e => e.IdSmctMasterSendmail)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_SMCT_MASTER_SENDMAIL")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.IdSmctMaster)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_SMCT_MASTER");

                entity.Property(e => e.SendmailCc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SENDMAIL_CC");

                entity.Property(e => e.SendmailDate)
                    .HasPrecision(6)
                    .HasColumnName("SENDMAIL_DATE");

                entity.Property(e => e.SendmailDetail)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("SENDMAIL_DETAIL");

                entity.Property(e => e.SendmailFr)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SENDMAIL_FR");

                entity.Property(e => e.SendmailSubject)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SENDMAIL_SUBJECT");

                entity.Property(e => e.SendmailTo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SENDMAIL_TO");

                entity.Property(e => e.SendmailType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SENDMAIL_TYPE");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.SmctMasterSendmailCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SMCT_MASTER_SENDMAIL_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.SmctMasterSendmailEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SMCT_MASTER_SENDMAIL_FK2");

                entity.HasOne(d => d.IdSmctMasterNavigation)
                    .WithMany(p => p.SmctMasterSendmails)
                    .HasForeignKey(d => d.IdSmctMaster)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SMCT_MASTER_SENDMAIL_FK3");
            });

            modelBuilder.Entity<SmctMasterSigner>(entity =>
            {
                entity.HasKey(e => e.IdSmctMasterSigner);

                entity.ToTable("SMCT_MASTER_SIGNER");

                entity.HasIndex(e => new { e.Used, e.IdSmctMaster }, "SMCT_MASTER_SIGNER_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdSmctMasterSigner)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_SMCT_MASTER_SIGNER")
                    .HasDefaultValueSql("sys_guid()");

                entity.Property(e => e.ContractSignerType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_SIGNER_TYPE");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.IdSmctMaster)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_SMCT_MASTER");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.SmctMasterSignerCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SMCT_MASTER_SIGNER_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.SmctMasterSignerEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SMCT_MASTER_SIGNER_FK2");

                entity.HasOne(d => d.IdSmctMasterNavigation)
                    .WithMany(p => p.SmctMasterSigners)
                    .HasForeignKey(d => d.IdSmctMaster)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SMCT_MASTER_SIGNER_FK3");
            });

            modelBuilder.Entity<SmctMasterSignerDetail1>(entity =>
            {
                entity.HasKey(e => e.IdSmctMasterSignerDetail1)
                    .HasName("PK_SMCT_MASTER_SIGNER_D1");

                entity.ToTable("SMCT_MASTER_SIGNER_DETAIL1");

                entity.HasIndex(e => new { e.Used, e.IdSmctMasterSigner }, "SMCT_MASTER_SIGNER_D1_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdSmctMasterSignerDetail1)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_SMCT_MASTER_SIGNER_DETAIL1")
                    .HasDefaultValueSql("sys_guid()");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.IdSmctMasterSigner)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_SMCT_MASTER_SIGNER");

                entity.Property(e => e.NhsoContractDate)
                    .HasColumnType("DATE")
                    .HasColumnName("NHSO_CONTRACT_DATE");

                entity.Property(e => e.NhsoContractId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NHSO_CONTRACT_ID");

                entity.Property(e => e.NhsoFootnoteUser1)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("NHSO_FOOTNOTE_USER1");

                entity.Property(e => e.NhsoFootnoteUser2)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("NHSO_FOOTNOTE_USER2");

                entity.Property(e => e.NhsoFootnoteUser3)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("NHSO_FOOTNOTE_USER3");

                entity.Property(e => e.NhsoSignerUser)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("NHSO_SIGNER_USER");

                entity.Property(e => e.NhsoWitnessStatus)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NHSO_WITNESS_STATUS");

                entity.Property(e => e.NhsoWitnessUser)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("NHSO_WITNESS_USER");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.Property(e => e.VendorFootnoteUser1)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_FOOTNOTE_USER1");

                entity.Property(e => e.VendorFootnoteUser2)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_FOOTNOTE_USER2");

                entity.Property(e => e.VendorFootnoteUser3)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_FOOTNOTE_USER3");

                entity.Property(e => e.VendorSignerUser)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_SIGNER_USER");

                entity.Property(e => e.VendorWitnessStatus)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_WITNESS_STATUS");

                entity.Property(e => e.VendorWitnessUser)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_WITNESS_USER");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.SmctMasterSignerDetail1CreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SMCT_MASTER_SIGNER_D1_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.SmctMasterSignerDetail1EditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SMCT_MASTER_SIGNER_D1_FK2");

                entity.HasOne(d => d.IdSmctMasterSignerNavigation)
                    .WithMany(p => p.SmctMasterSignerDetail1s)
                    .HasForeignKey(d => d.IdSmctMasterSigner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SMCT_MASTER_SIGNER_D1_FK3");
            });

            modelBuilder.Entity<SmctMasterSignerDetail2>(entity =>
            {
                entity.HasKey(e => e.IdSmctMasterSignerDetail2)
                    .HasName("PK_SMCT_MASTER_SIGNER_D2");

                entity.ToTable("SMCT_MASTER_SIGNER_DETAIL2");

                entity.HasIndex(e => new { e.Used, e.IdSmctMasterSigner }, "SMCT_MASTER_SIGNER_D2_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdSmctMasterSignerDetail2)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_SMCT_MASTER_SIGNER_DETAIL2")
                    .HasDefaultValueSql("sys_guid()");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.IdSmctMasterSigner)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_SMCT_MASTER_SIGNER");

                entity.Property(e => e.NhsoKetApprovalUser)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("NHSO_KET_APPROVAL_USER");

                entity.Property(e => e.NhsoKetCheckerUser)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("NHSO_KET_CHECKER_USER");

                entity.Property(e => e.NhsoKetProposalUser)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("NHSO_KET_PROPOSAL_USER");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.SmctMasterSignerDetail2CreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SMCT_MASTER_SIGNER_D2_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.SmctMasterSignerDetail2EditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SMCT_MASTER_SIGNER_D2_FK2");

                entity.HasOne(d => d.IdSmctMasterSignerNavigation)
                    .WithMany(p => p.SmctMasterSignerDetail2s)
                    .HasForeignKey(d => d.IdSmctMasterSigner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SMCT_MASTER_SIGNER_D2_FK3");
            });

            modelBuilder.Entity<UserDdopa>(entity =>
            {
                entity.HasKey(e => e.IdDdopa)
                    .HasName("USER_DDOPA_PK");

                entity.ToTable("USER_DDOPA");

                entity.Property(e => e.IdDdopa)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_DDOPA")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CODE");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.Error)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ERROR");

                entity.Property(e => e.ErrorDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ERROR_DESCRIPTION");

                entity.Property(e => e.ErrorUri)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ERROR_URI");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("STATE");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");
            });

            modelBuilder.Entity<UserLevel>(entity =>
            {
                entity.HasKey(e => e.IdUserLevel);

                entity.ToTable("USER_LEVEL");

                entity.HasIndex(e => new { e.Used, e.UserLevelCode }, "USER_LEVEL_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdUserLevel)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_USER_LEVEL")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FULL_NAME");

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SHORT_NAME");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.Property(e => e.UserLevelCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USER_LEVEL_CODE");
            });

            modelBuilder.Entity<UserLevel2>(entity =>
            {
                entity.HasKey(e => e.IdUserLevel)
                    .HasName("PK2_USER_LEVEL");

                entity.ToTable("USER_LEVEL2");

                entity.HasIndex(e => new { e.Used, e.UserLevelCode }, "USER_LEVEL2_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdUserLevel)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_USER_LEVEL")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FULL_NAME");

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SHORT_NAME");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.Property(e => e.UserLevelCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USER_LEVEL_CODE");
            });

            modelBuilder.Entity<UserRight>(entity =>
            {
                entity.HasKey(e => e.IdUserRights);

                entity.ToTable("USER_RIGHTS");

                entity.HasIndex(e => new { e.IdUserSmct, e.IdUserRole, e.Used }, "USER_RIGHTS_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdUserRights)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_USER_RIGHTS")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("NULL ");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE")
                    .HasDefaultValueSql("NULL ");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.IdUserRole)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_USER_ROLE");

                entity.Property(e => e.IdUserSmct)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_USER_SMCT");

                entity.Property(e => e.Remark)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REMARK");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.UserRightCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USER_RIGHTS_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.UserRightEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USER_RIGHTS_FK2");

                entity.HasOne(d => d.IdUserRoleNavigation)
                    .WithMany(p => p.UserRights)
                    .HasForeignKey(d => d.IdUserRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USER_RIGHTS_FK4");

                entity.HasOne(d => d.IdUserSmctNavigation)
                    .WithMany(p => p.UserRightIdUserSmctNavigations)
                    .HasForeignKey(d => d.IdUserSmct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USER_RIGHTS_FK3");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.IdUserRole);

                entity.ToTable("USER_ROLE");

                entity.HasIndex(e => new { e.UserRoleCode, e.Used }, "USER_ROLE_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdUserRole)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_USER_ROLE")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FULL_NAME");

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SHORT_NAME");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.Property(e => e.UserRoleCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USER_ROLE_CODE");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.UserRoleCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USER_ROLE_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.UserRoleEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USER_ROLE_FK2");
            });

            modelBuilder.Entity<UserSmct>(entity =>
            {
                entity.HasKey(e => e.IdUserSmct);

                entity.ToTable("USER_SMCT");

                entity.HasIndex(e => new { e.Username, e.Used }, "USER_SMCT_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdUserSmct)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_USER_SMCT")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.Birthday)
                    .HasColumnType("DATE")
                    .HasColumnName("BIRTHDAY");

                entity.Property(e => e.Cid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CID");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.DepartmentCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_CODE");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.IdUserLevel)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_USER_LEVEL");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.PositionName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("POSITION_NAME");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.Property(e => e.UserFullname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USER_FULLNAME");

                entity.Property(e => e.UserType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USER_TYPE");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.InverseCreateUserNavigation)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USER_SMCT_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.InverseEditUserNavigation)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USER_SMCT_FK2");

                entity.HasOne(d => d.IdUserLevelNavigation)
                    .WithMany(p => p.UserSmcts)
                    .HasForeignKey(d => d.IdUserLevel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USER_SMCT_FK3");
            });

            modelBuilder.Entity<UserSmctLog>(entity =>
            {
                entity.HasKey(e => e.IdUserSmctLog)
                    .HasName("SYS_C00384994");

                entity.ToTable("USER_SMCT_LOG");

                entity.Property(e => e.IdUserSmctLog)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_USER_SMCT_LOG")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.IdUserSmct)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_USER_SMCT");

                entity.Property(e => e.IpAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IP_ADDRESS");

                entity.HasOne(d => d.IdUserSmctNavigation)
                    .WithMany(p => p.UserSmctLogs)
                    .HasForeignKey(d => d.IdUserSmct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ID_USER_SMCT_FK1");
            });

            modelBuilder.Entity<UserSmctSigner>(entity =>
            {
                entity.HasKey(e => e.IdUserSmctSigner);

                entity.ToTable("USER_SMCT_SIGNER");

                entity.HasIndex(e => new { e.IdUserSmct, e.Used }, "USER_SMCT_SIGNER_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdUserSmctSigner)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_USER_SMCT_SIGNER")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.IdUserSmct)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_USER_SMCT");

                entity.Property(e => e.Signer1DocDate)
                    .HasColumnType("DATE")
                    .HasColumnName("SIGNER1_DOC_DATE");

                entity.Property(e => e.Signer1DocName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SIGNER1_DOC_NAME");

                entity.Property(e => e.Signer1DocNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SIGNER1_DOC_NO");

                entity.Property(e => e.Signer1Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SIGNER1_NAME");

                entity.Property(e => e.Signer1User)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("SIGNER1_USER");

                entity.Property(e => e.Signer2DocDate)
                    .HasColumnType("DATE")
                    .HasColumnName("SIGNER2_DOC_DATE");

                entity.Property(e => e.Signer2DocName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SIGNER2_DOC_NAME");

                entity.Property(e => e.Signer2DocNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SIGNER2_DOC_NO");

                entity.Property(e => e.Signer2EndDate)
                    .HasColumnType("DATE")
                    .HasColumnName("SIGNER2_END_DATE");

                entity.Property(e => e.Signer2PoaDocDate)
                    .HasColumnType("DATE")
                    .HasColumnName("SIGNER2_POA_DOC_DATE");

                entity.Property(e => e.Signer2PoaDocNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SIGNER2_POA_DOC_NO");

                entity.Property(e => e.Signer2PoaSigner1Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SIGNER2_POA_SIGNER1_NAME");

                entity.Property(e => e.Signer2PoaSigner1User)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("SIGNER2_POA_SIGNER1_USER");

                entity.Property(e => e.Signer2StartDate)
                    .HasColumnType("DATE")
                    .HasColumnName("SIGNER2_START_DATE");

                entity.Property(e => e.SignerType)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("SIGNER_TYPE");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.UserSmctSignerCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USER_SMCT_SIGNER_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.UserSmctSignerEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USER_SMCT_SIGNER_FK2");

                entity.HasOne(d => d.IdUserSmctNavigation)
                    .WithMany(p => p.UserSmctSignerIdUserSmctNavigations)
                    .HasForeignKey(d => d.IdUserSmct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USER_SMCT_SIGNER_FK3");

                entity.HasOne(d => d.Signer1UserNavigation)
                    .WithMany(p => p.UserSmctSignerSigner1UserNavigations)
                    .HasForeignKey(d => d.Signer1User)
                    .HasConstraintName("USER_SMCT_SIGNER_FK4");

                entity.HasOne(d => d.Signer2PoaSigner1UserNavigation)
                    .WithMany(p => p.UserSmctSignerSigner2PoaSigner1UserNavigations)
                    .HasForeignKey(d => d.Signer2PoaSigner1User)
                    .HasConstraintName("USER_SMCT_SIGNER_FK5");
            });

            modelBuilder.Entity<UserSmctSignerFile>(entity =>
            {
                entity.HasKey(e => e.IdUserSmctSignerFile);

                entity.ToTable("USER_SMCT_SIGNER_FILE");

                entity.HasIndex(e => new { e.IdUserSmctSigner, e.Used, e.SignerFileNo }, "USER_SMCT_SIGNER_FILE_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdUserSmctSignerFile)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_USER_SMCT_SIGNER_FILE")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.IdUserSmctSigner)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_USER_SMCT_SIGNER");

                entity.Property(e => e.PathFolder)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PATH_FOLDER");

                entity.Property(e => e.SignerFileFtp)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SIGNER_FILE_FTP");

                entity.Property(e => e.SignerFileName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SIGNER_FILE_NAME");

                entity.Property(e => e.SignerFileNo)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SIGNER_FILE_NO");

                entity.Property(e => e.SignerFileType)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("SIGNER_FILE_TYPE");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.UserSmctSignerFileCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USER_SMCT_SIGNER_FILE_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.UserSmctSignerFileEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USER_SMCT_SIGNER_FILE_FK2");

                entity.HasOne(d => d.IdUserSmctSignerNavigation)
                    .WithMany(p => p.UserSmctSignerFiles)
                    .HasForeignKey(d => d.IdUserSmctSigner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USER_SMCT_SIGNER_FILE_FK3");
            });

            modelBuilder.Entity<UserSmctVendor>(entity =>
            {
                entity.HasKey(e => e.IdUserSmctVendor);

                entity.ToTable("USER_SMCT_VENDOR");

                entity.HasIndex(e => new { e.IdUserSmct, e.Used }, "USER_SMCT_VENDOR_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdUserSmctVendor)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_USER_SMCT_VENDOR")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.Hcode)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("HCODE");

                entity.Property(e => e.IdRegisterNhso)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_REGISTER_NHSO");

                entity.Property(e => e.IdUserSmct)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_USER_SMCT");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.Property(e => e.VendorId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_ID");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.UserSmctVendorCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USER_SMCT_VENDOR_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.UserSmctVendorEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USER_SMCT_VENDOR_FK2");

                entity.HasOne(d => d.IdRegisterNhsoNavigation)
                    .WithMany(p => p.UserSmctVendors)
                    .HasForeignKey(d => d.IdRegisterNhso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USER_SMCT_VENDOR_FK4");

                entity.HasOne(d => d.IdUserSmctNavigation)
                    .WithMany(p => p.UserSmctVendorIdUserSmctNavigations)
                    .HasForeignKey(d => d.IdUserSmct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USER_SMCT_VENDOR_FK3");
            });

            modelBuilder.Entity<VDFiBankVendor>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_D_FI_BANK_VENDOR");

                entity.Property(e => e.BanksAccName)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("BANKS_ACC_NAME");

                entity.Property(e => e.BanksAccNo)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("BANKS_ACC_NO");

                entity.Property(e => e.BanksBranch)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("BANKS_BRANCH");

                entity.Property(e => e.BanksCode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("BANKS_CODE");

                entity.Property(e => e.BanksName)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("BANKS_NAME");

                entity.Property(e => e.VendorId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_ID");

                entity.Property(e => e.VendorName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_NAME");
            });

            modelBuilder.Entity<VGuaranteeLgContract>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_GUARANTEE_LG_CONTRACT");

                entity.Property(e => e.Aaa)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("AAA");

                entity.Property(e => e.Budgetyear)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("BUDGETYEAR");

                entity.Property(e => e.ContractDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CONTRACT_DATE");

                entity.Property(e => e.ContractId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_ID");

                entity.Property(e => e.ContractName)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_NAME");

                entity.Property(e => e.ContractSignType)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_SIGN_TYPE");

                entity.Property(e => e.ContractTypeName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE_NAME");

                entity.Property(e => e.DepartmentCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_CODE");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_NAME");

                entity.Property(e => e.EffectiveDateEnd)
                    .HasColumnType("DATE")
                    .HasColumnName("EFFECTIVE_DATE_END");

                entity.Property(e => e.EffectiveDateStart)
                    .HasColumnType("DATE")
                    .HasColumnName("EFFECTIVE_DATE_START");

                entity.Property(e => e.LgAmountInitial)
                    .HasColumnType("NUMBER(18,2)")
                    .HasColumnName("LG_AMOUNT_INITIAL");

                entity.Property(e => e.LgDate)
                    .HasColumnType("DATE")
                    .HasColumnName("LG_DATE");

                entity.Property(e => e.LgNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LG_NUMBER");

                entity.Property(e => e.RefDate)
                    .HasColumnType("DATE")
                    .HasColumnName("REF_DATE");

                entity.Property(e => e.RefId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("REF_ID");

                entity.Property(e => e.VendorId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_ID");

                entity.Property(e => e.VendorName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_NAME");
            });

            modelBuilder.Entity<VMasterVendor>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_MASTER_VENDOR");

                entity.Property(e => e.Building)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BUILDING");

                entity.Property(e => e.Catm)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CATM");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_NAME");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fax)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FAX");

                entity.Property(e => e.Hcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("HCODE");

                entity.Property(e => e.Moo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MOO");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.PostCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("POST_CODE");

                entity.Property(e => e.ProvinceId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PROVINCE_ID");

                entity.Property(e => e.RegisterAt)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REGISTER_AT");

                entity.Property(e => e.Road)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROAD");

                entity.Property(e => e.Soi)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("SOI");

                entity.Property(e => e.Sp7)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SP7");

                entity.Property(e => e.Sp7Date)
                    .HasColumnType("DATE")
                    .HasColumnName("SP7_DATE");

                entity.Property(e => e.TaxId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TAX_ID");

                entity.Property(e => e.VendorId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_ID");

                entity.Property(e => e.VendorName)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_NAME");

                entity.Property(e => e.VendorType)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_TYPE")
                    .IsFixedLength(true);

                entity.Property(e => e.VillageNo)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("VILLAGE_NO");
            });

            modelBuilder.Entity<VMasterVendorV1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_MASTER_VENDOR_V1");

                entity.Property(e => e.Building)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BUILDING");

                entity.Property(e => e.Catm)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CATM");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_NAME");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fax)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FAX");

                entity.Property(e => e.Hcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("HCODE");

                entity.Property(e => e.Moo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MOO");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.PostCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("POST_CODE");

                entity.Property(e => e.ProvinceId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PROVINCE_ID");

                entity.Property(e => e.RegisterAt)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REGISTER_AT");

                entity.Property(e => e.Road)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ROAD");

                entity.Property(e => e.Soi)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("SOI");

                entity.Property(e => e.Sp7)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SP7");

                entity.Property(e => e.Sp7Date)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SP7_DATE");

                entity.Property(e => e.TaxId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TAX_ID");

                entity.Property(e => e.VendorId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_ID");

                entity.Property(e => e.VendorName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_NAME");

                entity.Property(e => e.VendorType)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_TYPE")
                    .IsFixedLength(true);

                entity.Property(e => e.VillageNo)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("VILLAGE_NO");
            });

            modelBuilder.Entity<VNhsoBorad>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_NHSO_BORAD");

                entity.Property(e => e.BoradEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BORAD_EMAIL");

                entity.Property(e => e.BoradFullname)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("BORAD_FULLNAME");

                entity.Property(e => e.BoradPosition)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BORAD_POSITION");

                entity.Property(e => e.BoradType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("BORAD_TYPE")
                    .IsFixedLength(true);

                entity.Property(e => e.BureauId)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("BUREAU_ID");

                entity.Property(e => e.BureauName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BUREAU_NAME");

                entity.Property(e => e.DepartmentCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_CODE");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EMP_ID");
            });

            modelBuilder.Entity<VNhsoBorad1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_NHSO_BORAD1");

                entity.Property(e => e.BoradEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BORAD_EMAIL");

                entity.Property(e => e.BoradFullname)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("BORAD_FULLNAME");

                entity.Property(e => e.BoradPosition)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BORAD_POSITION");

                entity.Property(e => e.BoradType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("BORAD_TYPE")
                    .IsFixedLength(true);

                entity.Property(e => e.DepartmentCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_CODE")
                    .IsFixedLength(true);

                entity.Property(e => e.EmpId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EMP_ID");
            });

            modelBuilder.Entity<VNhsoDepartmentAddress>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_NHSO_DEPARTMENT_ADDRESS");

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Address0)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS0");

                entity.Property(e => e.Address1)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS1");

                entity.Property(e => e.Address2)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS2");

                entity.Property(e => e.Address3)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS3");

                entity.Property(e => e.Address4)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS4");

                entity.Property(e => e.AmphurName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("AMPHUR_NAME");

                entity.Property(e => e.ChangwatName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CHANGWAT_NAME");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.CreatedUser)
                    .HasPrecision(10)
                    .HasColumnName("CREATED_USER");

                entity.Property(e => e.Dcode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("DCODE");

                entity.Property(e => e.EditedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("EDITED_DATE");

                entity.Property(e => e.EditedUser)
                    .HasPrecision(10)
                    .HasColumnName("EDITED_USER");

                entity.Property(e => e.Header)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("HEADER");

                entity.Property(e => e.Moo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MOO");

                entity.Property(e => e.MoobanName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MOOBAN_NAME");

                entity.Property(e => e.No)
                    .HasPrecision(10)
                    .HasColumnName("NO");

                entity.Property(e => e.Phone)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.PostCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("POST_CODE");

                entity.Property(e => e.Road)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ROAD");

                entity.Property(e => e.Soi)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SOI");

                entity.Property(e => e.TumbonName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TUMBON_NAME");

                entity.Property(e => e.Used)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USED")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<VNhsoEmployeeAll>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_NHSO_EMPLOYEE_ALL");

                entity.Property(e => e.BureauId)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("BUREAU_ID");

                entity.Property(e => e.BureauIndex)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("BUREAU_INDEX");

                entity.Property(e => e.BureauName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BUREAU_NAME");

                entity.Property(e => e.BureauSeq)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BUREAU_SEQ");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.EmpDepartmentCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("EMP_DEPARTMENT_CODE")
                    .IsFixedLength(true);

                entity.Property(e => e.EmpFullname)
                    .HasMaxLength(207)
                    .IsUnicode(false)
                    .HasColumnName("EMP_FULLNAME");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("EMP_ID");

                entity.Property(e => e.EmpPosition)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMP_POSITION");

                entity.Property(e => e.EmpStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EMP_STATUS")
                    .IsFixedLength(true);

                entity.Property(e => e.LvlName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LVL_NAME");

                entity.Property(e => e.LvlSql)
                    .HasColumnType("NUMBER")
                    .HasColumnName("LVL_SQL");

                entity.Property(e => e.MemberPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MEMBER_PASSWORD");

                entity.Property(e => e.MemberUsername)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("MEMBER_USERNAME");

                entity.Property(e => e.MissionId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MISSION_ID");

                entity.Property(e => e.PersonCellphone)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PERSON_CELLPHONE");

                entity.Property(e => e.PersonCellphoneNhso)
                    .IsUnicode(false)
                    .HasColumnName("PERSON_CELLPHONE_NHSO");

                entity.Property(e => e.PersonEmail)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PERSON_EMAIL");

                entity.Property(e => e.PersonEnFname)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PERSON_EN_FNAME");

                entity.Property(e => e.PersonEnLname)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PERSON_EN_LNAME");

                entity.Property(e => e.PersonFax)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PERSON_FAX");

                entity.Property(e => e.PersonImage)
                    .IsUnicode(false)
                    .HasColumnName("PERSON_IMAGE");

                entity.Property(e => e.PersonNhsoMail)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("PERSON_NHSO_MAIL");

                entity.Property(e => e.PersonPhone)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PERSON_PHONE");

                entity.Property(e => e.PersonPhoneNhso)
                    .IsUnicode(false)
                    .HasColumnName("PERSON_PHONE_NHSO");

                entity.Property(e => e.PersonThFname)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PERSON_TH_FNAME");

                entity.Property(e => e.PersonThFullname)
                    .IsUnicode(false)
                    .HasColumnName("PERSON_TH_FULLNAME");

                entity.Property(e => e.PersonThLname)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PERSON_TH_LNAME");

                entity.Property(e => e.PessonRefix)
                    .IsUnicode(false)
                    .HasColumnName("PESSON_REFIX");

                entity.Property(e => e.Pid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PID");

                entity.Property(e => e.PstnName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PSTN_NAME");

                entity.Property(e => e.PstnSeq)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PSTN_SEQ");

                entity.Property(e => e.PstnTypeName)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("PSTN_TYPE_NAME");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.WgpName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("WGP_NAME");

                entity.Property(e => e.WkldName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WKLD_NAME");
            });

            modelBuilder.Entity<VNhsoServiceUnit>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_NHSO_SERVICE_UNIT");

                entity.Property(e => e.Building)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BUILDING");

                entity.Property(e => e.Catm)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CATM");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_NAME");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fax)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FAX");

                entity.Property(e => e.Hcode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("HCODE");

                entity.Property(e => e.Moo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MOO");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.PostCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("POST_CODE");

                entity.Property(e => e.ProvinceId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("PROVINCE_ID");

                entity.Property(e => e.RegisterAt)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REGISTER_AT");

                entity.Property(e => e.Road)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ROAD");

                entity.Property(e => e.Soi)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("SOI");

                entity.Property(e => e.Sp7)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SP7");

                entity.Property(e => e.Sp7Date)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SP7_DATE");

                entity.Property(e => e.TaxId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TAX_ID");

                entity.Property(e => e.VendorId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_ID");

                entity.Property(e => e.VendorName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_NAME");

                entity.Property(e => e.VendorType)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_TYPE")
                    .IsFixedLength(true);

                entity.Property(e => e.VillageNo)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("VILLAGE_NO");
            });

            modelBuilder.Entity<VNhsoSigner>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_NHSO_SIGNER");

                entity.Property(e => e.DepartmentCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_CODE")
                    .IsFixedLength(true);

                entity.Property(e => e.EmpId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EMP_ID");

                entity.Property(e => e.SignerEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SIGNER_EMAIL");

                entity.Property(e => e.SignerFullname)
                    .HasMaxLength(207)
                    .IsUnicode(false)
                    .HasColumnName("SIGNER_FULLNAME");

                entity.Property(e => e.SignerPosition)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SIGNER_POSITION");

                entity.Property(e => e.SignerType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SIGNER_TYPE")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<VNhsoZone>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_NHSO_ZONE");

                entity.Property(e => e.NhsoZone)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("NHSO_ZONE")
                    .IsFixedLength(true);

                entity.Property(e => e.NhsoZonename)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NHSO_ZONENAME");

                entity.Property(e => e.ProvinceId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("PROVINCE_ID");

                entity.Property(e => e.ProvinceName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PROVINCE_NAME");

                entity.Property(e => e.Region)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("REGION");

                entity.Property(e => e.RegionName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("REGION_NAME");
            });

            modelBuilder.Entity<VSmctBudgetcode>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_SMCT_BUDGETCODE");

                entity.Property(e => e.BudgetA)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BUDGET_A");

                entity.Property(e => e.BudgetC)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BUDGET_C");

                entity.Property(e => e.Budgetcode)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("BUDGETCODE");
            });

            modelBuilder.Entity<VSmctContract>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_SMCT_CONTRACT");

                entity.Property(e => e.ContractDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CONTRACT_DATE");

                entity.Property(e => e.ContractId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_ID");

                entity.Property(e => e.ContractName)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_NAME");

                entity.Property(e => e.ContractTypeFullName)
                    .IsRequired()
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE_FULL_NAME");

                entity.Property(e => e.ContractTypeId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE_ID");

                entity.Property(e => e.ContractTypeShortName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE_SHORT_NAME");

                entity.Property(e => e.DepartmentCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_CODE");
            });

            modelBuilder.Entity<VSmctContractPeriod>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_SMCT_CONTRACT_PERIODS");

                entity.Property(e => e.ContractDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CONTRACT_DATE");

                entity.Property(e => e.ContractId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_ID");

                entity.Property(e => e.ContractName)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_NAME");

                entity.Property(e => e.ContractTypeFullName)
                    .IsRequired()
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE_FULL_NAME");

                entity.Property(e => e.ContractTypeId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE_ID");

                entity.Property(e => e.ContractTypeShortName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE_SHORT_NAME");

                entity.Property(e => e.DepartmentCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_CODE");

                entity.Property(e => e.PeriodBudget)
                    .HasColumnType("NUMBER(19,3)")
                    .HasColumnName("PERIOD_BUDGET");

                entity.Property(e => e.PeriodBudgetcode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PERIOD_BUDGETCODE");

                entity.Property(e => e.PeriodDueDate)
                    .HasColumnType("DATE")
                    .HasColumnName("PERIOD_DUE_DATE");

                entity.Property(e => e.PeriodEndDate)
                    .HasColumnType("DATE")
                    .HasColumnName("PERIOD_END_DATE");

                entity.Property(e => e.PeriodNo)
                    .HasPrecision(10)
                    .HasColumnName("PERIOD_NO");

                entity.Property(e => e.PeriodStartDate)
                    .HasColumnType("DATE")
                    .HasColumnName("PERIOD_START_DATE");

                entity.Property(e => e.PeriodVendorId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PERIOD_VENDOR_ID");
            });

            modelBuilder.Entity<VendorLinkReq>(entity =>
            {
                entity.HasKey(e => e.IdVendorLinkReq);

                entity.ToTable("VENDOR_LINK_REQ");

                entity.HasIndex(e => new { e.IdSmctMaster, e.Used }, "VENDOR_LINK_REQ_UQ1")
                    .IsUnique();

                entity.HasIndex(e => new { e.ReqId, e.Used, e.Version }, "VENDOR_LINK_REQ_UQ2")
                    .IsUnique();

                entity.Property(e => e.IdVendorLinkReq)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_VENDOR_LINK_REQ")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.Building)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BUILDING");

                entity.Property(e => e.Catm)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CATM");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_NAME");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fax)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FAX");

                entity.Property(e => e.Hcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("HCODE");

                entity.Property(e => e.IdSmctMaster)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_SMCT_MASTER");

                entity.Property(e => e.Moo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MOO");

                entity.Property(e => e.Phone)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.PostCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("POST_CODE");

                entity.Property(e => e.ProvinceId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PROVINCE_ID");

                entity.Property(e => e.RegisterAt)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("REGISTER_AT");

                entity.Property(e => e.ReqId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("REQ_ID");

                entity.Property(e => e.Road)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ROAD");

                entity.Property(e => e.Soi)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SOI");

                entity.Property(e => e.Sp7)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SP7");

                entity.Property(e => e.Sp7Date)
                    .HasColumnType("DATE")
                    .HasColumnName("SP7_DATE");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.TaxId)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("TAX_ID");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.Property(e => e.VendorId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_ID");

                entity.Property(e => e.VendorName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_NAME");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("VERSION");

                entity.Property(e => e.VillageNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VILLAGE_NO");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.VendorLinkReqCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("VENDOR_LINK_REQ_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.VendorLinkReqEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("VENDOR_LINK_REQ_FK2");

                entity.HasOne(d => d.IdSmctMasterNavigation)
                    .WithMany(p => p.VendorLinkReqs)
                    .HasForeignKey(d => d.IdSmctMaster)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("VENDOR_LINK_REQ_FK3");
            });

            modelBuilder.Entity<VendorLinkReqApprove>(entity =>
            {
                entity.HasKey(e => e.IdVendorLinkReqApprove);

                entity.ToTable("VENDOR_LINK_REQ_APPROVE");

                entity.Property(e => e.IdVendorLinkReqApprove)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_VENDOR_LINK_REQ_APPROVE")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.AccName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ACC_NAME");

                entity.Property(e => e.AccNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ACC_NO");

                entity.Property(e => e.ApproveDate)
                    .HasColumnType("DATE")
                    .HasColumnName("APPROVE_DATE");

                entity.Property(e => e.ApproveUser)
                    .HasPrecision(10)
                    .HasColumnName("APPROVE_USER");

                entity.Property(e => e.BankBrnInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("BANK_BRN_IND");

                entity.Property(e => e.BankId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("BANK_ID");

                entity.Property(e => e.BranchId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_ID");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.Building)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BUILDING");

                entity.Property(e => e.CardId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CARD_ID");

                entity.Property(e => e.CardType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CARD_TYPE");

                entity.Property(e => e.Catm)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CATM");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_NAME");

                entity.Property(e => e.ContractorName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACTOR_NAME");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("COST_CENTER");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Enaccadr1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENACCADR1");

                entity.Property(e => e.Enaccadr2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENACCADR2");

                entity.Property(e => e.Enaccadr3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENACCADR3");

                entity.Property(e => e.Enaccname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENACCNAME");

                entity.Property(e => e.Fax)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FAX");

                entity.Property(e => e.HouseNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HOUSE_NUMBER");

                entity.Property(e => e.IdSmctMaster)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_SMCT_MASTER");

                entity.Property(e => e.IdVendorLinkReq)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_VENDOR_LINK_REQ");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MOBILE");

                entity.Property(e => e.Moo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MOO");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.PostCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("POST_CODE");

                entity.Property(e => e.ProvinceId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("PROVINCE_ID");

                entity.Property(e => e.Road)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROAD");

                entity.Property(e => e.SearchTerm)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SEARCH_TERM");

                entity.Property(e => e.Soi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SOI");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.TaxId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TAX_ID");

                entity.Property(e => e.VendorId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_ID");

                entity.Property(e => e.VendorName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_NAME");

                entity.Property(e => e.VendorType)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_TYPE");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.VendorLinkReqApproveCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("VENDOR_LINK_REQ_APPROVE_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.VendorLinkReqApproveEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("VENDOR_LINK_REQ_APPROVE_FK2");

                entity.HasOne(d => d.IdSmctMasterNavigation)
                    .WithMany(p => p.VendorLinkReqApproves)
                    .HasForeignKey(d => d.IdSmctMaster)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("VENDOR_LINK_REQ_APPROVE_FK3");

                entity.HasOne(d => d.IdVendorLinkReqNavigation)
                    .WithMany(p => p.VendorLinkReqApproves)
                    .HasForeignKey(d => d.IdVendorLinkReq)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("VENDOR_LINK_REQ_APPROVE_FK4");
            });

            modelBuilder.Entity<VendorLinkReqStation>(entity =>
            {
                entity.HasKey(e => e.IdVendorLinkReqStation);

                entity.ToTable("VENDOR_LINK_REQ_STATION");

                entity.HasIndex(e => new { e.IdSmctMaster, e.Used }, "VENDOR_LINK_REQ_STATION_UQ1")
                    .IsUnique();

                entity.Property(e => e.IdVendorLinkReqStation)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_VENDOR_LINK_REQ_STATION")
                    .HasDefaultValueSql("sys_guid() ");

                entity.Property(e => e.ApprovalReqDate)
                    .HasColumnType("DATE")
                    .HasColumnName("APPROVAL_REQ_DATE");

                entity.Property(e => e.ApprovalReqId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("APPROVAL_REQ_ID");

                entity.Property(e => e.Budgetyear)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("BUDGETYEAR");

                entity.Property(e => e.ContractName)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_NAME");

                entity.Property(e => e.ContractSignType)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_SIGN_TYPE");

                entity.Property(e => e.ContractStyleCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_STYLE_CODE");

                entity.Property(e => e.ContractStyleFullName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_STYLE_FULL_NAME");

                entity.Property(e => e.ContractTypeId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE_ID");

                entity.Property(e => e.ContractTypeName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE_NAME");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER");

                entity.Property(e => e.CreateUserDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATE_USER_DATE");

                entity.Property(e => e.CreateUserFullname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER_FULLNAME");

                entity.Property(e => e.DepartmentCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_CODE");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_NAME");

                entity.Property(e => e.EditDate)
                    .HasPrecision(6)
                    .HasColumnName("EDIT_DATE");

                entity.Property(e => e.EditUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER");

                entity.Property(e => e.EditUserDate)
                    .HasColumnType("DATE")
                    .HasColumnName("EDIT_USER_DATE");

                entity.Property(e => e.EditUserFullname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_USER_FULLNAME");

                entity.Property(e => e.FRetarn)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("F_RETARN");

                entity.Property(e => e.IdSmctMaster)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_SMCT_MASTER");

                entity.Property(e => e.IdVendorLinkReq)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ID_VENDOR_LINK_REQ");

                entity.Property(e => e.ItemApproveDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ITEM_APPROVE_DATE");

                entity.Property(e => e.ItemApproveUser)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ITEM_APPROVE_USER");

                entity.Property(e => e.ItemBeginDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ITEM_BEGIN_DATE");

                entity.Property(e => e.ItemBeginUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ITEM_BEGIN_USER");

                entity.Property(e => e.ItemStatusCurr)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ITEM_STATUS_CURR");

                entity.Property(e => e.ItemStatusPrev)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ITEM_STATUS_PREV");

                entity.Property(e => e.KetRemark)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("KET_REMARK");

                entity.Property(e => e.RefDate)
                    .HasColumnType("DATE")
                    .HasColumnName("REF_DATE");

                entity.Property(e => e.RefId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("REF_ID");

                entity.Property(e => e.SbbRemark)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("SBB_REMARK");

                entity.Property(e => e.StationApproveDate)
                    .HasColumnType("DATE")
                    .HasColumnName("STATION_APPROVE_DATE");

                entity.Property(e => e.StationApproveUser)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("STATION_APPROVE_USER");

                entity.Property(e => e.StationBeginDate)
                    .HasColumnType("DATE")
                    .HasColumnName("STATION_BEGIN_DATE");

                entity.Property(e => e.StationBeginUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("STATION_BEGIN_USER");

                entity.Property(e => e.StationStatusCurr)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATION_STATUS_CURR");

                entity.Property(e => e.StationStatusPrev)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATION_STATUS_PREV");

                entity.Property(e => e.Used)
                    .HasPrecision(1)
                    .HasColumnName("USED");

                entity.Property(e => e.VendorId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_ID");

                entity.Property(e => e.VendorName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_NAME");

                entity.HasOne(d => d.CreateUserNavigation)
                    .WithMany(p => p.VendorLinkReqStationCreateUserNavigations)
                    .HasForeignKey(d => d.CreateUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("VENDOR_LINK_REQ_STATION_FK1");

                entity.HasOne(d => d.EditUserNavigation)
                    .WithMany(p => p.VendorLinkReqStationEditUserNavigations)
                    .HasForeignKey(d => d.EditUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("VENDOR_LINK_REQ_STATION_FK2");

                entity.HasOne(d => d.IdSmctMasterNavigation)
                    .WithMany(p => p.VendorLinkReqStations)
                    .HasForeignKey(d => d.IdSmctMaster)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("VENDOR_LINK_REQ_STATION_FK3");

                entity.HasOne(d => d.IdVendorLinkReqNavigation)
                    .WithMany(p => p.VendorLinkReqStations)
                    .HasForeignKey(d => d.IdVendorLinkReq)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("VENDOR_LINK_REQ_STATION_FK4");
            });

            modelBuilder.Entity<ViewAttachFile>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIEW_ATTACH_FILE");

                entity.Property(e => e.ContentType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CONTENT_TYPE");

                entity.Property(e => e.CreatedDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.CreatedId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.FileName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FILE_NAME");

                entity.Property(e => e.FilePath)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FILE_PATH");

                entity.Property(e => e.FileSize)
                    .HasPrecision(19)
                    .HasColumnName("FILE_SIZE");

                entity.Property(e => e.FileType)
                    .HasPrecision(10)
                    .HasColumnName("FILE_TYPE");

                entity.Property(e => e.Id)
                    .HasPrecision(19)
                    .HasColumnName("ID");

                entity.Property(e => e.LastupdatedDate)
                    .HasPrecision(6)
                    .HasColumnName("LASTUPDATED_DATE");

                entity.Property(e => e.LastupdatedId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("LASTUPDATED_ID");

                entity.Property(e => e.OriginalFileName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ORIGINAL_FILE_NAME");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("UUID");
            });

            modelBuilder.Entity<ViewAttachfileConfigItem>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIEW_ATTACHFILE_CONFIG_ITEM");

                entity.Property(e => e.DisplayText)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("DISPLAY_TEXT");

                entity.Property(e => e.Id)
                    .HasPrecision(10)
                    .HasColumnName("ID");

                entity.Property(e => e.ParentId)
                    .HasPrecision(10)
                    .HasColumnName("PARENT_ID");
            });

            modelBuilder.Entity<ViewHraRegister>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIEW_HRA_REGISTER");

                entity.Property(e => e.Building)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BUILDING");

                entity.Property(e => e.Catm)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CATM");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_NAME");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fax)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FAX");

                entity.Property(e => e.Hcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("HCODE");

                entity.Property(e => e.Moo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MOO");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.PostCode)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("POST_CODE");

                entity.Property(e => e.ProvinceId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PROVINCE_ID");

                entity.Property(e => e.RegisterAt)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REGISTER_AT");

                entity.Property(e => e.Road)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ROAD");

                entity.Property(e => e.Soi)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SOI");

                entity.Property(e => e.Sp7)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SP7");

                entity.Property(e => e.Sp7Date)
                    .HasColumnType("DATE")
                    .HasColumnName("SP7_DATE");

                entity.Property(e => e.TaxId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TAX_ID");

                entity.Property(e => e.VendorId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_ID");

                entity.Property(e => e.VendorName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_NAME");

                entity.Property(e => e.VendorType)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_TYPE")
                    .IsFixedLength(true);

                entity.Property(e => e.VillageNo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("VILLAGE_NO");
            });

            modelBuilder.Entity<ViewRequestRegister>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIEW_REQUEST_REGISTER");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.ApproveFromRegisterDate)
                    .HasPrecision(6)
                    .HasColumnName("APPROVE_FROM_REGISTER_DATE");

                entity.Property(e => e.Catm)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CATM");

                entity.Property(e => e.Checkdocument)
                    .HasPrecision(1)
                    .HasColumnName("CHECKDOCUMENT");

                entity.Property(e => e.CommentDocument)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("COMMENT_DOCUMENT");

                entity.Property(e => e.CommentNhsoApprove)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("COMMENT_NHSO_APPROVE");

                entity.Property(e => e.CommentZoneApprove)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("COMMENT_ZONE_APPROVE");

                entity.Property(e => e.CreatedDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.CreatedId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_ID");

                entity.Property(e => e.EffectiveDate)
                    .HasColumnType("DATE")
                    .HasColumnName("EFFECTIVE_DATE");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.ExecutiveGovernment)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EXECUTIVE_GOVERNMENT");

                entity.Property(e => e.ExecutiveInformation)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EXECUTIVE_INFORMATION");

                entity.Property(e => e.ExistingHospital)
                    .HasColumnType("NUMBER(19,2)")
                    .HasColumnName("EXISTING_HOSPITAL");

                entity.Property(e => e.Fax)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FAX");

                entity.Property(e => e.FileProblemOther)
                    .HasPrecision(19)
                    .HasColumnName("FILE_PROBLEM_OTHER");

                entity.Property(e => e.FileProblemOtherName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FILE_PROBLEM_OTHER_NAME");

                entity.Property(e => e.FillerEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FILLER_EMAIL");

                entity.Property(e => e.FillerName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FILLER_NAME");

                entity.Property(e => e.FillerPhone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FILLER_PHONE");

                entity.Property(e => e.FstatusId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FSTATUS_ID");

                entity.Property(e => e.Hcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("HCODE");

                entity.Property(e => e.Hname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("HNAME");

                entity.Property(e => e.HofftypeId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("HOFFTYPE_ID");

                entity.Property(e => e.HofftypeOther)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("HOFFTYPE_OTHER");

                entity.Property(e => e.HsubtypeId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("HSUBTYPE_ID");

                entity.Property(e => e.HtypeId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("HTYPE_ID");

                entity.Property(e => e.Id)
                    .HasPrecision(19)
                    .HasColumnName("ID");

                entity.Property(e => e.JuristicName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("JURISTIC_NAME");

                entity.Property(e => e.LackDocument)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LACK_DOCUMENT");

                entity.Property(e => e.LastupdatedDate)
                    .HasPrecision(6)
                    .HasColumnName("LASTUPDATED_DATE");

                entity.Property(e => e.LastupdatedId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("LASTUPDATED_ID");

                entity.Property(e => e.Moo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MOO");

                entity.Property(e => e.NetworkId)
                    .HasPrecision(19)
                    .HasColumnName("NETWORK_ID");

                entity.Property(e => e.NhsoApproveStatus)
                    .HasPrecision(1)
                    .HasColumnName("NHSO_APPROVE_STATUS");

                entity.Property(e => e.Note)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NOTE");

                entity.Property(e => e.NotificationRegisterStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NOTIFICATION_REGISTER_STATUS");

                entity.Property(e => e.NotifyNhsoApproveComment)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NOTIFY_NHSO_APPROVE_COMMENT");

                entity.Property(e => e.NotifyNhsoApproveStatus)
                    .HasPrecision(1)
                    .HasColumnName("NOTIFY_NHSO_APPROVE_STATUS");

                entity.Property(e => e.PostCode)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("POST_CODE");

                entity.Property(e => e.ProvinceId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PROVINCE_ID");

                entity.Property(e => e.RegisterConfirmDate)
                    .HasPrecision(6)
                    .HasColumnName("REGISTER_CONFIRM_DATE");

                entity.Property(e => e.RegistrationNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REGISTRATION_NUMBER");

                entity.Property(e => e.RequestType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REQUEST_TYPE");

                entity.Property(e => e.Road)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ROAD");

                entity.Property(e => e.Soi)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SOI");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Step)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("STEP");

                entity.Property(e => e.TaxNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TAX_NUMBER");

                entity.Property(e => e.Tel)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TEL");

                entity.Property(e => e.TypeId)
                    .HasColumnType("NUMBER(19,2)")
                    .HasColumnName("TYPE_ID");

                entity.Property(e => e.UuidChar)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("UUID_CHAR");

                entity.Property(e => e.Website)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("WEBSITE");

                entity.Property(e => e.ZoneApproveStatus)
                    .HasPrecision(1)
                    .HasColumnName("ZONE_APPROVE_STATUS");
            });

            modelBuilder.Entity<ViewStandardRegister>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIEW_STANDARD_REGISTER");

                entity.Property(e => e.AssistThaiMedicineFullTime)
                    .HasPrecision(10)
                    .HasColumnName("ASSIST_THAI_MEDICINE_FULL_TIME");

                entity.Property(e => e.AssistThaiMedicinePartTime)
                    .HasPrecision(10)
                    .HasColumnName("ASSIST_THAI_MEDICINE_PART_TIME");

                entity.Property(e => e.AuthrorizedPerson)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("AUTHRORIZED_PERSON");

                entity.Property(e => e.CHHaBedOpen)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("C_H_HA_BED_OPEN");

                entity.Property(e => e.CHHaExpireDate)
                    .HasColumnType("DATE")
                    .HasColumnName("C_H_HA_EXPIRE_DATE");

                entity.Property(e => e.CHHaLevel)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("C_H_HA_LEVEL");

                entity.Property(e => e.CHHaPassDate)
                    .HasColumnType("DATE")
                    .HasColumnName("C_H_HA_PASS_DATE");

                entity.Property(e => e.CIso15189)
                    .HasPrecision(1)
                    .HasColumnName("C_ISO_15189");

                entity.Property(e => e.CIso15189ExpireDate)
                    .HasColumnType("DATE")
                    .HasColumnName("C_ISO_15189_EXPIRE_DATE");

                entity.Property(e => e.CIso15189PassDate)
                    .HasColumnType("DATE")
                    .HasColumnName("C_ISO_15189_PASS_DATE");

                entity.Property(e => e.CLa)
                    .HasPrecision(1)
                    .HasColumnName("C_LA");

                entity.Property(e => e.CLaExpireDate)
                    .HasColumnType("DATE")
                    .HasColumnName("C_LA_EXPIRE_DATE");

                entity.Property(e => e.CLaPassDate)
                    .HasColumnType("DATE")
                    .HasColumnName("C_LA_PASS_DATE");

                entity.Property(e => e.CQHBedOpen)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("C_Q_H_BED_OPEN");

                entity.Property(e => e.CQHExpireDate)
                    .HasColumnType("DATE")
                    .HasColumnName("C_Q_H_EXPIRE_DATE");

                entity.Property(e => e.CQHPassDate)
                    .HasColumnType("DATE")
                    .HasColumnName("C_Q_H_PASS_DATE");

                entity.Property(e => e.CSp7ExpireDate)
                    .HasColumnType("DATE")
                    .HasColumnName("C_SP7_EXPIRE_DATE");

                entity.Property(e => e.CSp7No)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("C_SP7_NO");

                entity.Property(e => e.CSp7PassDate)
                    .HasColumnType("DATE")
                    .HasColumnName("C_SP7_PASS_DATE");

                entity.Property(e => e.CSp9ExpireDate)
                    .HasColumnType("DATE")
                    .HasColumnName("C_SP9_EXPIRE_DATE");

                entity.Property(e => e.CSp9No)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("C_SP9_NO");

                entity.Property(e => e.CSp9PassDate)
                    .HasColumnType("DATE")
                    .HasColumnName("C_SP9_PASS_DATE");

                entity.Property(e => e.CStandard)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("C_STANDARD");

                entity.Property(e => e.CStandardExpireDate)
                    .HasColumnType("DATE")
                    .HasColumnName("C_STANDARD_EXPIRE_DATE");

                entity.Property(e => e.CStandardPassDate)
                    .HasColumnType("DATE")
                    .HasColumnName("C_STANDARD_PASS_DATE");

                entity.Property(e => e.CTrtAmountBedIcu)
                    .HasPrecision(10)
                    .HasColumnName("C_TRT_AMOUNT_BED_ICU");

                entity.Property(e => e.CTrtBedIcu)
                    .HasPrecision(1)
                    .HasColumnName("C_TRT_BED_ICU");

                entity.Property(e => e.CTrtBedOpenStation)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("C_TRT_BED_OPEN_STATION");

                entity.Property(e => e.CTrtExpireDate)
                    .HasColumnType("DATE")
                    .HasColumnName("C_TRT_EXPIRE_DATE");

                entity.Property(e => e.CTrtPassDate)
                    .HasColumnType("DATE")
                    .HasColumnName("C_TRT_PASS_DATE");

                entity.Property(e => e.CTrtSubUnitStation)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("C_TRT_SUB_UNIT_STATION");

                entity.Property(e => e.HaLevel3expireDate)
                    .HasColumnType("DATE")
                    .HasColumnName("HA_LEVEL3EXPIRE_DATE");

                entity.Property(e => e.HaLevel3passDate)
                    .HasColumnType("DATE")
                    .HasColumnName("HA_LEVEL3PASS_DATE");

                entity.Property(e => e.Id)
                    .HasPrecision(19)
                    .HasColumnName("ID");

                entity.Property(e => e.InfoLicenseKy1AllowDate)
                    .HasColumnType("DATE")
                    .HasColumnName("INFO_LICENSE_KY1_ALLOW_DATE");

                entity.Property(e => e.InfoLicenseKy1ExpireDate)
                    .HasColumnType("DATE")
                    .HasColumnName("INFO_LICENSE_KY1_EXPIRE_DATE");

                entity.Property(e => e.IsHaLevel3)
                    .HasPrecision(1)
                    .HasColumnName("IS_HA_LEVEL3");

                entity.Property(e => e.IsIso)
                    .HasPrecision(1)
                    .HasColumnName("IS_ISO");

                entity.Property(e => e.IsJci)
                    .HasPrecision(1)
                    .HasColumnName("IS_JCI");

                entity.Property(e => e.IsTqm)
                    .HasPrecision(1)
                    .HasColumnName("IS_TQM");

                entity.Property(e => e.IsoExpireDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ISO_EXPIRE_DATE");

                entity.Property(e => e.IsoPassDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ISO_PASS_DATE");

                entity.Property(e => e.JciExpireDate)
                    .HasColumnType("DATE")
                    .HasColumnName("JCI_EXPIRE_DATE");

                entity.Property(e => e.JciPassDate)
                    .HasColumnType("DATE")
                    .HasColumnName("JCI_PASS_DATE");

                entity.Property(e => e.RehabilitationAllowDate)
                    .HasColumnType("DATE")
                    .HasColumnName("REHABILITATION_ALLOW_DATE");

                entity.Property(e => e.RehabilitationExpireDate)
                    .HasColumnType("DATE")
                    .HasColumnName("REHABILITATION_EXPIRE_DATE");

                entity.Property(e => e.RequestRegisterId)
                    .HasPrecision(19)
                    .HasColumnName("REQUEST_REGISTER_ID");

                entity.Property(e => e.TqmExpireDate)
                    .HasColumnType("DATE")
                    .HasColumnName("TQM_EXPIRE_DATE");

                entity.Property(e => e.TqmPassDate)
                    .HasColumnType("DATE")
                    .HasColumnName("TQM_PASS_DATE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
