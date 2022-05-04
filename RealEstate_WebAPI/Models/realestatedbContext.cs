using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RealEstate_WebAPI.Models
{
    public partial class realestatedbContext : DbContext
    {
        public realestatedbContext()
        {
        }

        public realestatedbContext(DbContextOptions<realestatedbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Auth> Auths { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Estate> Estates { get; set; } = null!;
        public virtual DbSet<EstateType> EstateTypes { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=realestatedb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auth>(entity =>
            {
                entity.ToTable("Auth");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");

                //entity.HasOne(d => d.IdNavigation)
                //    .WithOne(p => p.Auth)
                //    .HasForeignKey<Auth>(d => d.Id)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Auth_ToUser");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Postcode)
                    .HasMaxLength(5)
                    .HasColumnName("postcode")
                    .HasDefaultValueSql("((0))")
                    .IsFixedLength();


            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Estate>(entity =>
            {
                entity.ToTable("Estate");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.AgentId).HasColumnName("agent_id");

                entity.Property(e => e.BuildingSize)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("building_size");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.Comment)
                    .HasColumnType("text")
                    .HasColumnName("comment");

                entity.Property(e => e.Deposit)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("deposit");

                entity.Property(e => e.EstateTypeId).HasColumnName("estate_type_id");

                entity.Property(e => e.ForRent).HasColumnName("for_rent");

                entity.Property(e => e.ForSale).HasColumnName("for_sale");

                entity.Property(e => e.MinimumPrice).HasColumnName("minimum_price");

                entity.Property(e => e.OwnerId).HasColumnName("owner_id");

                entity.Property(e => e.PlotSize)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("plot_size");

                entity.Property(e => e.RentPrice).HasColumnName("rent_price");

                entity.Property(e => e.Rooms).HasColumnName("rooms");

                entity.Property(e => e.TargetPrice).HasColumnName("target_price");

                //entity.HasOne(d => d.Agent)
                //    .WithMany(p => p.EstateAgents)
                //    .HasForeignKey(d => d.AgentId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Estate_ToAgent");

                entity.HasOne(d => d.EstateType)
                    .WithMany(p => p.Estates)
                    .HasForeignKey(d => d.EstateTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Estate_ToEstate");

                //entity.HasOne(d => d.Owner)
                //    .WithMany(p => p.EstateOwners)
                //    .HasForeignKey(d => d.OwnerId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Estate_ToOwner");
            });

            modelBuilder.Entity<EstateType>(entity =>
            {
                entity.ToTable("EstateType");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.DateOfCreation)
                    .HasColumnType("datetime")
                    .HasColumnName("date_of_creation")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .HasColumnName("firstname")
                    .IsFixedLength();

                entity.Property(e => e.PhoneNr)
                    .HasMaxLength(16)
                    .HasColumnName("phone_nr")
                    .IsFixedLength();

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Ssn)
                    .HasMaxLength(15)
                    .HasColumnName("ssn");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .HasColumnName("surname")
                    .IsFixedLength();

                entity.Property(e => e.TaxNr)
                    .HasMaxLength(15)
                    .HasColumnName("tax_nr");


                //entity.HasOne(d => d.Role)
                //    .WithMany(p => p.Users)
                //    .HasForeignKey(d => d.RoleId)
                //    .HasConstraintName("FK_User_ToRole");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
