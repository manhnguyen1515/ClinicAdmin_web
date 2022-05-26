using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ClinicAdmin_web.ViewModels;

#nullable disable

namespace ClinicAdmin_web.Models
{
    public partial class ClinicAdminWebContext : DbContext
    {
        public ClinicAdminWebContext()
        {
        }

        public ClinicAdminWebContext(DbContextOptions<ClinicAdminWebContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<DayReport> DayReports { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }
        public virtual DbSet<PrescriptionMedicine> PrescriptionMedicines { get; set; }
        public virtual DbSet<Regulation> Regulations { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UnitMedicine> UnitMedicines { get; set; }
        public virtual DbSet<UsageMedicine> UsageMedicines { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-JINADF1\\MANH;Initial Catalog=ClinicAdminWeb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointment");

                entity.Property(e => e.AppointmentDay)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Appointment_fk0");
            });

            modelBuilder.Entity<DayReport>(entity =>
            {
                entity.ToTable("DayReport");

                entity.Property(e => e.DayReport1)
                    .HasColumnType("date")
                    .HasColumnName("DayReport")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_at");

                entity.HasOne(d => d.Prescription)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.PrescriptionId)
                    .HasConstraintName("Invoice_fk0");
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.ToTable("Medicine");

                entity.Property(e => e.DrugName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.ToTable("Prescription");

                entity.Property(e => e.Diagnose).HasMaxLength(255);

                entity.Property(e => e.Doctor).HasMaxLength(255);

                entity.Property(e => e.MedicalExamDay)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MedicalHistory).HasMaxLength(255);

                entity.Property(e => e.Note).HasMaxLength(255);

                entity.Property(e => e.Staff).HasMaxLength(255);

                entity.Property(e => e.Symptom).HasMaxLength(255);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("Prescription_fk2");
            });

            modelBuilder.Entity<PrescriptionMedicine>(entity =>
            {
                entity.ToTable("Prescription_Medicine");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.PrescriptionMedicines)
                    .HasForeignKey(d => d.MedicineId)
                    .HasConstraintName("Prescription_Medicine_fk1");

                entity.HasOne(d => d.Prescription)
                    .WithMany(p => p.PrescriptionMedicines)
                    .HasForeignKey(d => d.PrescriptionId)
                    .HasConstraintName("Prescription_Medicine_fk0");

                entity.HasOne(d => d.UnitNavigation)
                    .WithMany(p => p.PrescriptionMedicines)
                    .HasForeignKey(d => d.Unit)
                    .HasConstraintName("Prescription_Medicine_fk2");

                entity.HasOne(d => d.UsageNavigation)
                    .WithMany(p => p.PrescriptionMedicines)
                    .HasForeignKey(d => d.Usage)
                    .HasConstraintName("Prescription_Medicine_fk3");
            });

            modelBuilder.Entity<Regulation>(entity =>
            {
                entity.ToTable("Regulation");

                entity.Property(e => e.Datatypes).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.Value).HasMaxLength(255);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<UnitMedicine>(entity =>
            {
                entity.ToTable("UnitMedicine");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<UsageMedicine>(entity =>
            {
                entity.ToTable("UsageMedicine");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.Username, "UQ__User__536C85E4B0321201")
                    .IsUnique();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("User_fk0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<ClinicAdmin_web.ViewModels.LoginViewModel> LoginViewModel { get; set; }
    }
}
