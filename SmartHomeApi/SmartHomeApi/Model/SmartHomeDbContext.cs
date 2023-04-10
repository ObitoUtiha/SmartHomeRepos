using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SmartHomeApi.Model
{
    public partial class SmartHomeDbContext : DbContext
    {
        public SmartHomeDbContext()
        {
        }

        public SmartHomeDbContext(DbContextOptions<SmartHomeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActivityHistory> ActivityHistories { get; set; } = null!;
        public virtual DbSet<Device> Devices { get; set; } = null!;
        public virtual DbSet<DeviceInRoom> DeviceInRooms { get; set; } = null!;
        public virtual DbSet<Home> Homes { get; set; } = null!;
        public virtual DbSet<Manufacturer> Manufacturers { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserInHome> UserInHomes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=CERFER\\SQLEXPRESS;Database=SmartHomeDb;User id=sa;password=111;encrypt=false");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Cyrillic_General_100_CI_AS");

            modelBuilder.Entity<ActivityHistory>(entity =>
            {
                entity.ToTable("ActivityHistory");

                entity.Property(e => e.DateOfInclusion).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.DeviceInRoom)
                    .WithMany(p => p.ActivityHistories)
                    .HasForeignKey(d => d.DeviceInRoomId)
                    .HasConstraintName("FK_ActivityHistory_DeviceInRoom");

                entity.HasOne(d => d.UserInHome)
                    .WithMany(p => p.ActivityHistories)
                    .HasForeignKey(d => d.UserInHomeId)
                    .HasConstraintName("FK_ActivityHistory_UserInHome");
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.HasKey(e => e.DevicesId);

                entity.Property(e => e.DevicesId).ValueGeneratedNever();

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Devices)
                    .HasForeignKey(d => d.ManufacturerId)
                    .HasConstraintName("FK_Devices_Manufacturer");
            });

            modelBuilder.Entity<DeviceInRoom>(entity =>
            {
                entity.ToTable("DeviceInRoom");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.DeviceInRooms)
                    .HasForeignKey(d => d.DeviceId)
                    .HasConstraintName("FK_DeviceInRoom_Devices");

                entity.HasOne(d => d.DeviceNavigation)
                    .WithMany(p => p.DeviceInRooms)
                    .HasForeignKey(d => d.DeviceId)
                    .HasConstraintName("FK_DeviceInRoom_Room");
            });

            modelBuilder.Entity<Home>(entity =>
            {
                entity.ToTable("Home");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.FullAddress).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.OwnerNavigation)
                    .WithMany(p => p.Homes)
                    .HasForeignKey(d => d.Owner)
                    .HasConstraintName("FK_Home_User");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.ToTable("Manufacturer");

                entity.Property(e => e.ManufacturerId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Home)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.HomeId)
                    .HasConstraintName("FK_Room_Home");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Login).HasMaxLength(150);

                entity.Property(e => e.NickName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(150);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_User_Role");
            });

            modelBuilder.Entity<UserInHome>(entity =>
            {
                entity.ToTable("UserInHome");

                entity.HasOne(d => d.Home)
                    .WithMany(p => p.UserInHomes)
                    .HasForeignKey(d => d.HomeId)
                    .HasConstraintName("FK_UserInHome_Home");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserInHomes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserInHome_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
