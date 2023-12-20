using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace BuildCompanyAPI.Models;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brigade> Brigades { get; set; }

    public virtual DbSet<Client> Clients { get; set; }


    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localDB)\\MSSQLLocalDB;Initial Catalog=Andp;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brigade>(entity =>
        {
            entity.HasKey(e => e.IdBrigade).HasName("PK__Brigades__9CF7221015068E46");

            entity.Property(e => e.IdBrigade).HasColumnName("id_brigade");
            entity.Property(e => e.IdWorker).HasColumnName("id_worker");

            entity.HasOne(d => d.IdWorkerNavigation).WithMany(p => p.Brigades)
                .HasForeignKey(d => d.IdWorker)
                .HasConstraintName("FK_Brigades_Workers");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("PK__Clients__6EC2B6C032FB5550");

            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.Adress)
                .HasMaxLength(255)
                .HasColumnName("adress");
            entity.Property(e => e.Balance).HasColumnName("balance");
            entity.Property(e => e.Firstname)
                .HasMaxLength(255)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(255)
                .HasColumnName("lastname");
            entity.Property(e => e.Number)
                .HasMaxLength(255)
                .HasColumnName("number");
            entity.Property(e => e.Surname)
                .HasMaxLength(255)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("PK__Orders__DD5B8F3F356D117D");

            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.Date)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("date");
            entity.Property(e => e.IdBrigade).HasColumnName("id_brigade");
            entity.Property(e => e.IdClient).HasColumnName("id_client");

            entity.HasOne(d => d.IdBrigadeNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdBrigade)
                .HasConstraintName("FK_Orders_Brigades");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("FK_Orders_Clients");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.IdWorker).HasName("PK__Workers__F3638D7C0FDD84BB");

            entity.Property(e => e.IdWorker).HasColumnName("id_worker");
            entity.Property(e => e.Adress)
                .HasMaxLength(255)
                .HasColumnName("adress");
            entity.Property(e => e.Firstname)
                .HasMaxLength(255)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(255)
                .HasColumnName("lastname");
            entity.Property(e => e.Number)
                .HasMaxLength(255)
                .HasColumnName("number");
            entity.Property(e => e.Post)
                .HasMaxLength(255)
                .HasColumnName("post");
            entity.Property(e => e.Surname)
                .HasMaxLength(255)
                .HasColumnName("surname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
