using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bravel.Web.Api.Model.Models
{
    public partial class BravelContext : DbContext
    {
        public BravelContext()
        {
        }

        public BravelContext(DbContextOptions<BravelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Application> Applications { get; set; } = null!;
        public virtual DbSet<Convocation> Convocations { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>(entity =>
            {
                entity.ToTable("Application");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApplicationDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FirstName).HasMaxLength(20);

                entity.Property(e => e.IdentityNumber).HasMaxLength(20);

                entity.Property(e => e.IsApproved).HasColumnName("isApproved");

                entity.Property(e => e.LastName).HasMaxLength(20);

                entity.HasOne(d => d.Convocation)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.ConvocationId)
                    .HasConstraintName("FK_Application_Convocation");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Application_User");
            });

            modelBuilder.Entity<Convocation>(entity =>
            {
                entity.ToTable("Convocation");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ConvocationStatus).HasMaxLength(50);

                entity.Property(e => e.Deadline).HasColumnType("date");

                entity.Property(e => e.DocumentTypes).HasMaxLength(100);

                entity.Property(e => e.OpeningDate).HasColumnType("date");

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.Convocations)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .HasConstraintName("FK__Convocati__Creat__398D8EEE");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("Permission");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.PermissioName)
                    .HasMaxLength(10)
                    .HasColumnName("permissioName");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Permissio__roleI__412EB0B6");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(10)
                    .HasColumnName("roleName");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("creationDate");

                entity.Property(e => e.DateOfbirth)
                    .HasColumnType("date")
                    .HasColumnName("dateOfbirth");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.LastLogin)
                    .HasColumnType("datetime")
                    .HasColumnName("lastLogin");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("passwordHash");

                entity.Property(e => e.RecoveryAnwser)
                    .HasMaxLength(50)
                    .HasColumnName("recoveryAnwser");

                entity.Property(e => e.RecoveryQuestion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("recoveryQuestion");

                entity.Property(e => e.RelationshipType)
                    .HasMaxLength(20)
                    .HasColumnName("relationshipType");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserName)
                    .HasMaxLength(10)
                    .HasColumnName("userName")
                    .IsFixedLength();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__User__roleId__46E78A0C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
