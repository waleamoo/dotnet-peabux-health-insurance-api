using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HealthInsurance.DataAccess.Models;

public partial class HealthInsuranceContext : DbContext
{
    public HealthInsuranceContext()
    {
    }

    public HealthInsuranceContext(DbContextOptions<HealthInsuranceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Claim> Claims { get; set; }

    public virtual DbSet<ClaimStatus> ClaimStatuses { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Policy> Policies { get; set; }

    public virtual DbSet<PolicyHolder> PolicyHolders { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<StaffRole> StaffRoles { get; set; }

    public virtual DbSet<StaffRoleType> StaffRoleTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=HealthInsurance;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Claim>(entity =>
        {
            entity.HasKey(e => e.ClaimId).HasName("PK__Claim__EF2E139B7466F9DD");

            entity.ToTable("Claim");

            entity.Property(e => e.AmountOfExpenseToBeClaimed).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Expense).HasColumnType("ntext");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PolicyHolderId).HasMaxLength(100);
            entity.Property(e => e.TotalAmountOfExpense).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.ClaimStatus).WithMany(p => p.Claims)
                .HasForeignKey(d => d.ClaimStatusId)
                .HasConstraintName("FK__Claim__ClaimStat__5070F446");

            entity.HasOne(d => d.Company).WithMany(p => p.Claims)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__Claim__CompanyId__4E88ABD4");

            entity.HasOne(d => d.PolicyHolder).WithMany(p => p.Claims)
                .HasForeignKey(d => d.PolicyHolderId)
                .HasConstraintName("FK__Claim__PolicyHol__4F7CD00D");
        });

        modelBuilder.Entity<ClaimStatus>(entity =>
        {
            entity.HasKey(e => e.ClaimStatusId).HasName("PK__ClaimSta__CEFFA2A31DA8004D");

            entity.ToTable("ClaimStatus");

            entity.Property(e => e.ClaimStatus1)
                .HasMaxLength(50)
                .HasColumnName("ClaimStatus");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__Company__2D971CACB9F19F63");

            entity.ToTable("Company");

            entity.Property(e => e.CompanyAddress).HasMaxLength(100);
            entity.Property(e => e.CompanyName).HasMaxLength(50);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Policy>(entity =>
        {
            entity.HasKey(e => e.PolicyId).HasName("PK__Policy__2E1339A42706B697");

            entity.ToTable("Policy");

            entity.Property(e => e.PolicyId).HasMaxLength(100);
            entity.Property(e => e.Benefits).HasColumnType("ntext");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Discount).HasDefaultValue(0);
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PolicyType).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Company).WithMany(p => p.Policies)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__Policy__CompanyI__3F466844");
        });

        modelBuilder.Entity<PolicyHolder>(entity =>
        {
            entity.HasKey(e => e.PolicyHolderId).HasName("PK__PolicyHo__0549D02B19B920C2");

            entity.ToTable("PolicyHolder");

            entity.Property(e => e.PolicyHolderId).HasMaxLength(100);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PolicyHolderAddress).HasMaxLength(100);
            entity.Property(e => e.PolicyHolderName).HasMaxLength(50);
            entity.Property(e => e.PolicyHolderSurname).HasMaxLength(50);
            entity.Property(e => e.PolicyId).HasMaxLength(100);

            entity.HasOne(d => d.Company).WithMany(p => p.PolicyHolders)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__PolicyHol__Compa__44FF419A");

            entity.HasOne(d => d.Policy).WithMany(p => p.PolicyHolders)
                .HasForeignKey(d => d.PolicyId)
                .HasConstraintName("FK__PolicyHol__Polic__45F365D3");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__96D4AB178174A50E");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.StaffAddress).HasMaxLength(100);
            entity.Property(e => e.StaffEmail).HasDefaultValue("peabux@example.com");
            entity.Property(e => e.StaffName).HasMaxLength(50);
            entity.Property(e => e.StaffSurname).HasMaxLength(50);

            entity.HasOne(d => d.Company).WithMany(p => p.Staff)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__Staff__CompanyId__3A81B327");
        });

        modelBuilder.Entity<StaffRole>(entity =>
        {
            entity.HasKey(e => e.StaffRoleId).HasName("PK__StaffRol__10792C91602B3879");

            entity.ToTable("StaffRole");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.StaffRoleType).WithMany(p => p.StaffRoles)
                .HasForeignKey(d => d.StaffRoleTypeId)
                .HasConstraintName("FK__StaffRole__Staff__59063A47");
        });

        modelBuilder.Entity<StaffRoleType>(entity =>
        {
            entity.HasKey(e => e.StaffRoleTypeId).HasName("PK__StaffRol__2A9136E3E0B4435A");

            entity.ToTable("StaffRoleType");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.StaffRoleTitle).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
