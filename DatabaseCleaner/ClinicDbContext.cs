using DatabaseCleaner.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseCleaner;

public partial class ClinicDbContext : DbContext
{
    public ClinicDbContext() { }

    public ClinicDbContext(DbContextOptions<ClinicDbContext> options)
        : base(options) { }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Office> Offices { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Photo> Photos { get; set; }

    public virtual DbSet<Receptionist> Receptionists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity
                .HasIndex(e => e.IsDeleted, "IX_Accounts_IsDeleted")
                .HasFilter("([IsDeleted]=(0))");

            entity.HasIndex(e => e.PhotoId, "IX_Accounts_PhotoId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Photo).WithMany(p => p.Accounts).HasForeignKey(d => d.PhotoId);
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasIndex(e => e.DoctorId, "IX_Appointments_DoctorId");

            entity
                .HasIndex(e => e.IsDeleted, "IX_Appointments_IsDeleted")
                .HasFilter("([IsDeleted]=(0))");

            entity.HasIndex(e => e.PatientId, "IX_Appointments_PatientId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Price).HasColumnType("decimal(10, 3)");

            entity
                .HasOne(d => d.Doctor)
                .WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity
                .HasOne(d => d.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity
                .HasIndex(e => e.DateOfBirth, "IX_DOCTORS_LASTNAME")
                .HasFilter("([IsDeleted]=(0))");

            entity.HasIndex(e => e.AccountId, "IX_Doctors_AccountId");

            entity.HasIndex(e => e.OfficeId, "IX_Doctors_OfficeId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Account).WithMany(p => p.Doctors).HasForeignKey(d => d.AccountId);

            entity.HasOne(d => d.Office).WithMany(p => p.Doctors).HasForeignKey(d => d.OfficeId);
        });

        modelBuilder.Entity<Office>(entity =>
        {
            entity
                .HasIndex(e => e.IsDeleted, "IX_Offices_IsDeleted")
                .HasFilter("([IsDeleted]=(0))");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasIndex(e => e.AccountId, "IX_Patients_AccountId");

            entity
                .HasIndex(e => e.IsDeleted, "IX_Patients_IsDeleted")
                .HasFilter("([IsDeleted]=(0))");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Account).WithMany(p => p.Patients).HasForeignKey(d => d.AccountId);
        });

        modelBuilder.Entity<Photo>(entity =>
        {
            entity.HasIndex(e => e.Id, "IX_Photos_AccountId").HasFilter("([IsDeleted]=(0))");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Receptionist>(entity =>
        {
            entity.HasIndex(e => e.AccountId, "IX_Receptionists_AccountId");

            entity
                .HasIndex(e => e.IsDeleted, "IX_Receptionists_IsDeleted")
                .HasFilter("([IsDeleted]=(0))");

            entity.HasIndex(e => e.OfficeId, "IX_Receptionists_OfficeId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity
                .HasOne(d => d.Account)
                .WithMany(p => p.Receptionists)
                .HasForeignKey(d => d.AccountId);

            entity
                .HasOne(d => d.Office)
                .WithMany(p => p.Receptionists)
                .HasForeignKey(d => d.OfficeId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
