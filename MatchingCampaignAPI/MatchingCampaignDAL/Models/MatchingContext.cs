using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MatchingCampaignDAL.Models
{
    public partial class MatchingContext : DbContext
    {
        public MatchingContext()
        {
        }

        public MatchingContext(DbContextOptions<MatchingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CreditCard> CreditCards { get; set; } = null!;
        public virtual DbSet<Donation> Donations { get; set; } = null!;
        public virtual DbSet<Donor> Donors { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<ManagersAndCollector> ManagersAndCollectors { get; set; } = null!;
        public virtual DbSet<Matching> Matchings { get; set; } = null!;
        public virtual DbSet<PermissionsT> PermissionsTs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\RAndN\\MatchingCampaignAPI\\MatchingCampaignDAL\\DB\\MatchingDB.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditCard>(entity =>
            {
                entity.ToTable("CreditCard");

                entity.Property(e => e.CreditNumber).HasMaxLength(16);

                entity.Property(e => e.Cvv)
                    .HasMaxLength(3)
                    .HasColumnName("CVV");

                entity.Property(e => e.Idnumber)
                    .HasMaxLength(10)
                    .HasColumnName("IDNumber");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Validity).HasColumnType("date");
            });

            modelBuilder.Entity<Donation>(entity =>
            {
                entity.Property(e => e.CreditCardId).HasColumnName("CreditCardID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DonorId).HasColumnName("DonorID");

                entity.Property(e => e.Inscription).HasMaxLength(80);

                entity.Property(e => e.ThrowCollectorName).HasMaxLength(50);

                entity.HasOne(d => d.CreditCard)
                    .WithMany(p => p.Donations)
                    .HasForeignKey(d => d.CreditCardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Donations__Credi__6C190EBB");

                entity.HasOne(d => d.Donor)
                    .WithMany(p => p.Donations)
                    .HasForeignKey(d => d.DonorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Donations__Donor__6D0D32F4");
            });

            modelBuilder.Entity<Donor>(entity =>
            {
                entity.Property(e => e.Adress).HasMaxLength(50);

                entity.Property(e => e.DonorName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Anonymous')");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("EMail");

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.GroupName).HasMaxLength(50);
            });

            modelBuilder.Entity<ManagersAndCollector>(entity =>
            {
                entity.HasIndex(e => e.Password, "UQ__tmp_ms_x__87909B1525F2AAF0")
                    .IsUnique();

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(11);

                entity.Property(e => e.PermissionsId).HasColumnName("PermissionsID");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.ManagersAndCollectors)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK__ManagersA__Group__6EF57B66");

                entity.HasOne(d => d.Permissions)
                    .WithMany(p => p.ManagersAndCollectors)
                    .HasForeignKey(d => d.PermissionsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ManagersA__Permi__6FE99F9F");
            });

            modelBuilder.Entity<Matching>(entity =>
            {
                entity.ToTable("Matching");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CompanyName).HasMaxLength(30);

                entity.Property(e => e.EndDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<PermissionsT>(entity =>
            {
                entity.ToTable("PermissionsT");

                entity.Property(e => e.Job).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
