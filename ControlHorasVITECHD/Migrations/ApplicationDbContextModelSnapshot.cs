﻿// <auto-generated />
using System;
using ControlHorasVITECHD.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControlHorasVITECHD.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ControlHorasVITECHD.Model.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ControlHorasVITECHD.Model.Clients", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("NID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("TypePer");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("ControlHorasVITECHD.Model.Hours", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("HoursTime");

                    b.Property<int>("IdTask");

                    b.Property<string>("IdUser");

                    b.Property<int>("Status");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.HasIndex("IdTask");

                    b.HasIndex("IdUser");

                    b.ToTable("Hours");
                });

            modelBuilder.Entity("ControlHorasVITECHD.Model.Proyects", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Hours");

                    b.Property<int>("IdClient");

                    b.Property<DateTime>("InitialDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("IdClient");

                    b.ToTable("Proyects");
                });

            modelBuilder.Entity("ControlHorasVITECHD.Model.Tasks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Detail");

                    b.Property<int>("EstimatedHours");

                    b.Property<int>("IdProyect");

                    b.Property<string>("IdUser");

                    b.Property<int>("TaskNumber");

                    b.HasKey("Id");

                    b.HasIndex("IdProyect");

                    b.HasIndex("IdUser");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedName");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.HasKey("UserId", "LoginProvider", "ProviderKey");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("ControlHorasVITECHD.Model.Hours", b =>
                {
                    b.HasOne("ControlHorasVITECHD.Model.Tasks", "Tasks")
                        .WithMany("Hours")
                        .HasForeignKey("IdTask")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ControlHorasVITECHD.Model.ApplicationUser", "Users")
                        .WithMany("Hours")
                        .HasForeignKey("IdUser");
                });

            modelBuilder.Entity("ControlHorasVITECHD.Model.Proyects", b =>
                {
                    b.HasOne("ControlHorasVITECHD.Model.Clients", "Clients")
                        .WithMany("Proyects")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ControlHorasVITECHD.Model.Tasks", b =>
                {
                    b.HasOne("ControlHorasVITECHD.Model.Proyects", "Proyects")
                        .WithMany("Tasks")
                        .HasForeignKey("IdProyect")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ControlHorasVITECHD.Model.ApplicationUser", "Users")
                        .WithMany("Tasks")
                        .HasForeignKey("IdUser");
                });
#pragma warning restore 612, 618
        }
    }
}
