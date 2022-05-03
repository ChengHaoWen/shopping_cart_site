using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebEr.Models
{
    public partial class ErContext : DbContext
    {
        public ErContext()
        {
        }

        public ErContext(DbContextOptions<ErContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TMember> TMember { get; set; }
        public virtual DbSet<TOrder> TOrder { get; set; }
        public virtual DbSet<TOrderDetail> TOrderDetail { get; set; }
        public virtual DbSet<TProduct> TProduct { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Er;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TMember>(entity =>
            {
                entity.HasKey(e => e.FId);

                entity.ToTable("tMember");

                entity.Property(e => e.FId).HasColumnName("fId");

                entity.Property(e => e.FEmail)
                    .HasColumnName("fEmail")
                    .HasMaxLength(50);

                entity.Property(e => e.FName)
                    .HasColumnName("fName")
                    .HasMaxLength(50);

                entity.Property(e => e.FPwd)
                    .HasColumnName("fPwd")
                    .HasMaxLength(50);

                entity.Property(e => e.FUserId)
                    .HasColumnName("fUserId")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TOrder>(entity =>
            {
                entity.HasKey(e => e.FId);

                entity.ToTable("tOrder");

                entity.Property(e => e.FId).HasColumnName("fId");

                entity.Property(e => e.FAddress)
                    .HasColumnName("fAddress")
                    .HasMaxLength(50);

                entity.Property(e => e.FDate)
                    .HasColumnName("fDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FEmail)
                    .HasColumnName("fEmail")
                    .HasMaxLength(50);

                entity.Property(e => e.FOrderGuid)
                    .HasColumnName("fOrderGuid")
                    .HasMaxLength(50);

                entity.Property(e => e.FReceiver)
                    .HasColumnName("fReceiver")
                    .HasMaxLength(50);

                entity.Property(e => e.FUserId)
                    .HasColumnName("fUserId")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TOrderDetail>(entity =>
            {
                entity.HasKey(e => e.FId);

                entity.ToTable("tOrderDetail");

                entity.Property(e => e.FId).HasColumnName("fId");

                entity.Property(e => e.FIsApproved)
                    .HasColumnName("fIsApproved")
                    .HasMaxLength(10);

                entity.Property(e => e.FName)
                    .HasColumnName("fName")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.FOrderGuid)
                    .HasColumnName("fOrderGuid")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.FPid)
                    .HasColumnName("fPId")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.FPrice).HasColumnName("fPrice");

                entity.Property(e => e.FQty).HasColumnName("fQty");

                entity.Property(e => e.FUserId)
                    .HasColumnName("fUserId")
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TProduct>(entity =>
            {
                entity.HasKey(e => e.FId)
                    .HasName("PK_tProduct_1");

                entity.ToTable("tProduct");

                entity.Property(e => e.FId).HasColumnName("fId");

                entity.Property(e => e.FImg)
                    .HasColumnName("fImg")
                    .HasMaxLength(50);

                entity.Property(e => e.FName)
                    .HasColumnName("fName")
                    .HasMaxLength(50);

                entity.Property(e => e.FPid)
                    .IsRequired()
                    .HasColumnName("fPId")
                    .HasMaxLength(50);

                entity.Property(e => e.FPrice).HasColumnName("fPrice");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
