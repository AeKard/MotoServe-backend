using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

public partial class MotoServeContext : DbContext
{
    public MotoServeContext()
    {
    }

    public MotoServeContext(DbContextOptions<MotoServeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<AdminAccount> AdminAccounts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerAccount> CustomerAccounts { get; set; }

    public virtual DbSet<CustomerMotorcycle> CustomerMotorcycles { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<MaintenanceHistory> MaintenanceHistories { get; set; }

    public virtual DbSet<MaintenanceSchedule> MaintenanceSchedules { get; set; }

    public virtual DbSet<Mechanic> Mechanics { get; set; }

    public virtual DbSet<MechanicAccount> MechanicAccounts { get; set; }

    public virtual DbSet<PaymentTable> PaymentTables { get; set; }

    public virtual DbSet<Receptionist> Receptionists { get; set; }

    public virtual DbSet<ReceptionistAccount> ReceptionistAccounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=MotoServe;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.Property(e => e.AdminId)
                .ValueGeneratedNever()
                .HasColumnName("admin_id");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<AdminAccount>(entity =>
        {
            entity.ToTable("AdminAccount");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AdminId).HasColumnName("admin_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");

            entity.HasOne(d => d.Admin).WithMany(p => p.AdminAccounts)
                .HasForeignKey(d => d.AdminId)
                .HasConstraintName("FK_AdminAccount_Admins");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("customer_id");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.MotorcycleId).HasColumnName("motorcycle_id");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<CustomerAccount>(entity =>
        {
            entity.ToTable("CustomerAccount");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        modelBuilder.Entity<CustomerMotorcycle>(entity =>
        {
            entity.HasKey(e => e.MotorcycleId);

            entity.ToTable("CustomerMotorcycle");

            entity.Property(e => e.MotorcycleId)
                .ValueGeneratedNever()
                .HasColumnName("motorcycle_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.MotorBrand)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("motor_brand");
            entity.Property(e => e.MotorModel)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("motor_model");
            entity.Property(e => e.MotorStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("motor_status");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.ToTable("Inventory");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Material)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("material");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.TotalProfit)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_profit");
        });

        modelBuilder.Entity<MaintenanceHistory>(entity =>
        {
            entity.ToTable("MaintenanceHistory");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.MaintenanceId).HasColumnName("maintenance_id");
            entity.Property(e => e.MechanicId).HasColumnName("mechanic_id");
            entity.Property(e => e.MotorcycleId).HasColumnName("motorcycle_id");
            entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");
        });

        modelBuilder.Entity<MaintenanceSchedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId);

            entity.ToTable("MaintenanceSchedule");

            entity.Property(e => e.ScheduleId)
                .ValueGeneratedNever()
                .HasColumnName("schedule_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Time).HasColumnName("time");
        });

        modelBuilder.Entity<Mechanic>(entity =>
        {
            entity.Property(e => e.MechanicId)
                .ValueGeneratedNever()
                .HasColumnName("mechanic_id");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.MotorExpertise)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("motor_expertise");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone_number");
        });

        modelBuilder.Entity<MechanicAccount>(entity =>
        {
            entity.ToTable("MechanicAccount");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.MechanicId).HasColumnName("mechanic_id");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        modelBuilder.Entity<PaymentTable>(entity =>
        {
            entity.ToTable("PaymentTable");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Due).HasColumnName("due");
            entity.Property(e => e.Invoice)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("invoice");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("payment_status");
        });

        modelBuilder.Entity<Receptionist>(entity =>
        {
            entity.Property(e => e.ReceptionistId)
                .ValueGeneratedNever()
                .HasColumnName("receptionist_id");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<ReceptionistAccount>(entity =>
        {
            entity.ToTable("ReceptionistAccount");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.ReceptionistId).HasColumnName("receptionist_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
