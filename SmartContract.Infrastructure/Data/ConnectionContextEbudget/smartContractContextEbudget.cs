using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SmartContract.Infrastructure.Data.EntityFrameworkEbudget;

#nullable disable

namespace SmartContract.Infrastructure.Data.ConnectionContextEbudget
{
    public partial class smartContractContextEbudget : DbContext
    {
        public smartContractContextEbudget()
        {
        }

        public smartContractContextEbudget(DbContextOptions<smartContractContextEbudget> options)
            : base(options)
        {
        }

        public virtual DbSet<A> As { get; set; }
        public virtual DbSet<EcContract> EcContracts { get; set; }
        public virtual DbSet<EcContractVendor> EcContractVendors { get; set; }
        public virtual DbSet<EcContractVendorOwner> EcContractVendorOwners { get; set; }
        public virtual DbSet<EcContractVendorReq> EcContractVendorReqs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("EBUDGET_OWNER");

            modelBuilder.Entity<A>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("A");

                entity.Property(e => e.Test)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TEST")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<EcContract>(entity =>
            {
                entity.HasKey(e => e.No)
                    .HasName("EC_CONTRACT_PK");

                entity.ToTable("EC_CONTRACT");

                entity.HasIndex(e => e.Id, "EC_CONTRACT_UN1")
                    .IsUnique();

                entity.HasIndex(e => e.MasterNo, "EC_CONTRACT_UN2")
                    .IsUnique();

                entity.Property(e => e.No)
                    .HasPrecision(10)
                    .HasColumnName("NO");

                entity.Property(e => e.Budget)
                    .HasColumnType("NUMBER(18,2)")
                    .HasColumnName("BUDGET");

                entity.Property(e => e.ContractDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CONTRACT_DATE");

                entity.Property(e => e.ContractName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_NAME");

                entity.Property(e => e.ContractType)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_TYPE");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.CreatedUser)
                    .HasPrecision(10)
                    .HasColumnName("CREATED_USER");

                entity.Property(e => e.Deptcode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DEPTCODE");

                entity.Property(e => e.EditedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("EDITED_DATE");

                entity.Property(e => e.EditedUser)
                    .HasPrecision(10)
                    .HasColumnName("EDITED_USER");

                entity.Property(e => e.EndDate)
                    .HasColumnType("DATE")
                    .HasColumnName("END_DATE");

                entity.Property(e => e.GuaranteeDay)
                    .HasPrecision(5)
                    .HasColumnName("GUARANTEE_DAY");

                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.MasterNo)
                    .HasPrecision(10)
                    .HasColumnName("MASTER_NO");

                entity.Property(e => e.NhsoPmEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NHSO_PM_EMAIL");

                entity.Property(e => e.NhsoSignFname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NHSO_SIGN_FNAME");

                entity.Property(e => e.NhsoSignLname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NHSO_SIGN_LNAME");

                entity.Property(e => e.NhsoSignPositionId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NHSO_SIGN_POSITION_ID");

                entity.Property(e => e.NhsoSignTitleId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NHSO_SIGN_TITLE_ID");

                entity.Property(e => e.StartDate)
                    .HasColumnType("DATE")
                    .HasColumnName("START_DATE");

                entity.Property(e => e.SubContractType)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SUB_CONTRACT_TYPE");

                entity.Property(e => e.TypeContractVendor)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("TYPE_CONTRACT_VENDOR");

                entity.Property(e => e.TypeNo)
                    .HasPrecision(10)
                    .HasColumnName("TYPE_NO");

                entity.Property(e => e.Used)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USED")
                    .IsFixedLength(true);

                entity.Property(e => e.VendorApp1Doc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_APP1_DOC");

                entity.Property(e => e.VendorApp1Docdate)
                    .HasColumnType("DATE")
                    .HasColumnName("VENDOR_APP1_DOCDATE");

                entity.Property(e => e.VendorApp1Docno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_APP1_DOCNO");

                entity.Property(e => e.VendorApp2Doc1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_APP2_DOC1");

                entity.Property(e => e.VendorApp2Doc2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_APP2_DOC2");

                entity.Property(e => e.VendorApp2Docdate1)
                    .HasColumnType("DATE")
                    .HasColumnName("VENDOR_APP2_DOCDATE1");

                entity.Property(e => e.VendorApp2Docdate2)
                    .HasColumnType("DATE")
                    .HasColumnName("VENDOR_APP2_DOCDATE2");

                entity.Property(e => e.VendorApp2Docno1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_APP2_DOCNO1");

                entity.Property(e => e.VendorApp2Docno2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_APP2_DOCNO2");

                entity.Property(e => e.VendorApp2Fname1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_APP2_FNAME1");

                entity.Property(e => e.VendorApp2Fname2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_APP2_FNAME2");

                entity.Property(e => e.VendorApp2Fname3)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_APP2_FNAME3");

                entity.Property(e => e.VendorApp2Lname1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_APP2_LNAME1");

                entity.Property(e => e.VendorApp2Lname2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_APP2_LNAME2");

                entity.Property(e => e.VendorApp2Lname3)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_APP2_LNAME3");

                entity.Property(e => e.VendorApp2TitleId1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_APP2_TITLE_ID1");

                entity.Property(e => e.VendorApp2TitleId2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_APP2_TITLE_ID2");

                entity.Property(e => e.VendorApp2TitleId3)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_APP2_TITLE_ID3");

                entity.Property(e => e.VendorApproveType)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_APPROVE_TYPE");

                entity.Property(e => e.VendorSignFname1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_SIGN_FNAME1");

                entity.Property(e => e.VendorSignFname2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_SIGN_FNAME2");

                entity.Property(e => e.VendorSignFname3)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_SIGN_FNAME3");

                entity.Property(e => e.VendorSignLname1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_SIGN_LNAME1");

                entity.Property(e => e.VendorSignLname2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_SIGN_LNAME2");

                entity.Property(e => e.VendorSignLname3)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_SIGN_LNAME3");

                entity.Property(e => e.VendorSignPosition1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_SIGN_POSITION1");

                entity.Property(e => e.VendorSignPosition2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_SIGN_POSITION2");

                entity.Property(e => e.VendorSignPosition3)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_SIGN_POSITION3");

                entity.Property(e => e.VendorSignTitleId1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_SIGN_TITLE_ID1");

                entity.Property(e => e.VendorSignTitleId2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_SIGN_TITLE_ID2");

                entity.Property(e => e.VendorSignTitleId3)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_SIGN_TITLE_ID3");
            });

            modelBuilder.Entity<EcContractVendor>(entity =>
            {
                entity.HasKey(e => e.No)
                    .HasName("EC_CONTRACT_VENDOR_PK");

                entity.ToTable("EC_CONTRACT_VENDOR");

                entity.HasIndex(e => new { e.ContractNo, e.VendorId }, "EC_CONTRACT_VENDOR_UN1")
                    .IsUnique();

                entity.Property(e => e.No)
                    .HasPrecision(10)
                    .HasColumnName("NO");

                entity.Property(e => e.ContractNo)
                    .HasPrecision(10)
                    .HasColumnName("CONTRACT_NO");

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

                entity.Property(e => e.Type)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");

                entity.Property(e => e.Used)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USED")
                    .IsFixedLength(true);

                entity.Property(e => e.VendorId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_ID");

                entity.HasOne(d => d.ContractNoNavigation)
                    .WithMany(p => p.EcContractVendors)
                    .HasForeignKey(d => d.ContractNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EC_CONTRACT_VENDOR_FK1");
            });

            modelBuilder.Entity<EcContractVendorOwner>(entity =>
            {
                entity.HasKey(e => e.No)
                    .HasName("EC_CONTRACT_VENDOR_OWNER_PK");

                entity.ToTable("EC_CONTRACT_VENDOR_OWNER");

                entity.Property(e => e.No)
                    .HasPrecision(10)
                    .HasColumnName("NO");

                entity.Property(e => e.Building)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("BUILDING");

                entity.Property(e => e.Catm)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CATM");

                entity.Property(e => e.ContractNo)
                    .HasPrecision(10)
                    .HasColumnName("CONTRACT_NO");

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

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fax)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FAX");

                entity.Property(e => e.HouseNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HOUSE_NUMBER");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MOBILE");

                entity.Property(e => e.Moo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MOO");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

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

                entity.Property(e => e.Sp7)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SP7");

                entity.Property(e => e.Sp7Date)
                    .HasColumnType("DATE")
                    .HasColumnName("SP7_DATE");

                entity.Property(e => e.Used)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USED")
                    .IsFixedLength(true);

                entity.HasOne(d => d.ContractNoNavigation)
                    .WithMany(p => p.EcContractVendorOwners)
                    .HasForeignKey(d => d.ContractNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EC_CONTRACT_VENDOR_OWNER_FK1");
            });

            modelBuilder.Entity<EcContractVendorReq>(entity =>
            {
                entity.HasKey(e => e.No)
                    .HasName("EC_CONTRACT_VENDOR_REQ_PK");

                entity.ToTable("EC_CONTRACT_VENDOR_REQ");

                entity.HasIndex(e => e.Id, "EC_CONTRACT_VENDOR_REQ_UN1")
                    .IsUnique();

                entity.HasIndex(e => e.VendorId, "EC_CONTRACT_VENDOR_REQ_UN2")
                    .IsUnique();

                entity.Property(e => e.No)
                    .HasPrecision(10)
                    .HasColumnName("NO");

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

                entity.Property(e => e.ContractNo)
                    .HasPrecision(10)
                    .HasColumnName("CONTRACT_NO");

                entity.Property(e => e.ContractorName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACTOR_NAME");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("COST_CENTER");

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

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID");

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
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.TaxId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TAX_ID");

                entity.Property(e => e.Used)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USED")
                    .IsFixedLength(true);

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

                entity.HasOne(d => d.ContractNoNavigation)
                    .WithMany(p => p.EcContractVendorReqs)
                    .HasForeignKey(d => d.ContractNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EC_CONTRACT_VENDOR_REQ_FK1");
            });

            modelBuilder.HasSequence("AATEST_SEQ");

            modelBuilder.HasSequence("BATCH_SEQ");

            modelBuilder.HasSequence("DEPT_SEQ");

            modelBuilder.HasSequence("EC_SEQ");

            modelBuilder.HasSequence("EF_SEQ");

            modelBuilder.HasSequence("EM_SEQ");

            modelBuilder.HasSequence("INSERT_ID_AUTO");

            modelBuilder.HasSequence("NEWRELEASES_SEQ");

            modelBuilder.HasSequence("POSTLOG_WB_ID_SEQ");

            modelBuilder.HasSequence("POST_WB_ID_SEQ");

            modelBuilder.HasSequence("QUESTION_ID");

            modelBuilder.HasSequence("RECNO_SEQ");

            modelBuilder.HasSequence("REPLY_ID");

            modelBuilder.HasSequence("REPLY_WB_ID_SEQ");

            modelBuilder.HasSequence("SEQ_E_CON_DATASET_PRIVATE_SPC");

            modelBuilder.HasSequence("SEQ_NO");

            modelBuilder.HasSequence("SYSTEM_LOG_SEQ");

            modelBuilder.HasSequence("TRAN_ID2_SEQ");

            modelBuilder.HasSequence("WF_SEQ");

            modelBuilder.HasSequence("WORKFLOW_ID_SEQ");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
