﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PcAssembly.Dal;

#nullable disable

namespace PcAssembly.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220523174836_RatingKey")]
    partial class RatingKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "01a43e9c-36d0-4dcb-ae74-8204c4368dff",
                            ConcurrencyStamp = "4a293180-2c3a-42ad-adfd-75371f22d62b",
                            Name = "Viewer",
                            NormalizedName = "VIEWER"
                        },
                        new
                        {
                            Id = "574d292a-92e4-47af-b8cb-87acfe6a8c25",
                            ConcurrencyStamp = "43b65a82-0fdc-49a9-9c90-93475125037b",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PcAssembly.Domain.Assembly", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("CoolersCount")
                        .HasColumnType("int");

                    b.Property<Guid>("CpuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("Date");

                    b.Property<Guid>("GraphicCardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("MotherboardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("PowerSupplyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CpuId");

                    b.HasIndex("GraphicCardId");

                    b.HasIndex("MotherboardId");

                    b.HasIndex("PowerSupplyId");

                    b.HasIndex("RamId");

                    b.HasIndex("UserId");

                    b.ToTable("Assemblies");
                });

            modelBuilder.Entity("PcAssembly.Domain.Auth.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("PcAssembly.Domain.Auth.UserProfile", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("About")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("Date");

                    b.HasKey("UserId");

                    b.ToTable("UsersProfiles");
                });

            modelBuilder.Entity("PcAssembly.Domain.Components.Component", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InfoAbout")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("PowerConsumption")
                        .HasColumnType("int");

                    b.Property<double?>("Price")
                        .IsConcurrencyToken()
                        .HasColumnType("float");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("PcAssembly.Domain.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("PcAssembly.Domain.RatedByUserAssembly", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("AssemblyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "AssemblyId");

                    b.HasIndex("AssemblyId");

                    b.ToTable("RatedByUserAssemblies");
                });

            modelBuilder.Entity("PcAssembly.Domain.SavedAssemblies", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "Id");

                    b.HasIndex("Id");

                    b.ToTable("SavedAssemblies");
                });

            modelBuilder.Entity("PcAssembly.Domain.Components.CPU", b =>
                {
                    b.HasBaseType("PcAssembly.Domain.Components.Component");

                    b.Property<int?>("Cores")
                        .HasColumnType("int");

                    b.Property<string>("Family")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<float?>("Frequency")
                        .HasColumnType("real");

                    b.Property<string>("Generation")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Socket")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int?>("Threads")
                        .HasColumnType("int");

                    b.ToTable("CPUs", (string)null);
                });

            modelBuilder.Entity("PcAssembly.Domain.Components.GraphicCard", b =>
                {
                    b.HasBaseType("PcAssembly.Domain.Components.Component");

                    b.Property<int?>("SgRamSize")
                        .HasColumnType("int");

                    b.Property<string>("SgRamType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("GraphicCards", (string)null);
                });

            modelBuilder.Entity("PcAssembly.Domain.Components.Motherboard", b =>
                {
                    b.HasBaseType("PcAssembly.Domain.Components.Component");

                    b.Property<string>("Chipset")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("FormFactor")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("RamSlots")
                        .HasColumnType("int");

                    b.Property<string>("RamType")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Socket")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.ToTable("Motherboards", (string)null);
                });

            modelBuilder.Entity("PcAssembly.Domain.Components.PowerSupply", b =>
                {
                    b.HasBaseType("PcAssembly.Domain.Components.Component");

                    b.Property<int?>("Power")
                        .IsRequired()
                        .HasColumnType("int");

                    b.ToTable("PowerSupplyes", (string)null);
                });

            modelBuilder.Entity("PcAssembly.Domain.Components.Ram", b =>
                {
                    b.HasBaseType("PcAssembly.Domain.Components.Component");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("RamSize")
                        .HasColumnType("int");

                    b.Property<string>("RamType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Rams", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PcAssembly.Domain.Auth.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PcAssembly.Domain.Auth.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PcAssembly.Domain.Auth.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PcAssembly.Domain.Auth.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PcAssembly.Domain.Assembly", b =>
                {
                    b.HasOne("PcAssembly.Domain.Components.CPU", "Cpu")
                        .WithMany()
                        .HasForeignKey("CpuId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PcAssembly.Domain.Components.GraphicCard", "GraphicCard")
                        .WithMany()
                        .HasForeignKey("GraphicCardId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PcAssembly.Domain.Components.Motherboard", "Motherboard")
                        .WithMany()
                        .HasForeignKey("MotherboardId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PcAssembly.Domain.Components.PowerSupply", "PowerSupply")
                        .WithMany()
                        .HasForeignKey("PowerSupplyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PcAssembly.Domain.Components.Ram", "Ram")
                        .WithMany()
                        .HasForeignKey("RamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PcAssembly.Domain.Auth.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Cpu");

                    b.Navigation("GraphicCard");

                    b.Navigation("Motherboard");

                    b.Navigation("PowerSupply");

                    b.Navigation("Ram");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PcAssembly.Domain.Auth.UserProfile", b =>
                {
                    b.HasOne("PcAssembly.Domain.Auth.User", "User")
                        .WithOne("UserProfile")
                        .HasForeignKey("PcAssembly.Domain.Auth.UserProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PcAssembly.Domain.RatedByUserAssembly", b =>
                {
                    b.HasOne("PcAssembly.Domain.Assembly", "Assembly")
                        .WithMany()
                        .HasForeignKey("AssemblyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PcAssembly.Domain.Auth.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assembly");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PcAssembly.Domain.SavedAssemblies", b =>
                {
                    b.HasOne("PcAssembly.Domain.Assembly", "Assembly")
                        .WithMany("SavedAssemblies")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PcAssembly.Domain.Auth.User", "User")
                        .WithMany("SavedAssemblies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Assembly");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PcAssembly.Domain.Components.CPU", b =>
                {
                    b.HasOne("PcAssembly.Domain.Components.Component", null)
                        .WithOne()
                        .HasForeignKey("PcAssembly.Domain.Components.CPU", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PcAssembly.Domain.Components.GraphicCard", b =>
                {
                    b.HasOne("PcAssembly.Domain.Components.Component", null)
                        .WithOne()
                        .HasForeignKey("PcAssembly.Domain.Components.GraphicCard", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PcAssembly.Domain.Components.Motherboard", b =>
                {
                    b.HasOne("PcAssembly.Domain.Components.Component", null)
                        .WithOne()
                        .HasForeignKey("PcAssembly.Domain.Components.Motherboard", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PcAssembly.Domain.Components.PowerSupply", b =>
                {
                    b.HasOne("PcAssembly.Domain.Components.Component", null)
                        .WithOne()
                        .HasForeignKey("PcAssembly.Domain.Components.PowerSupply", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PcAssembly.Domain.Components.Ram", b =>
                {
                    b.HasOne("PcAssembly.Domain.Components.Component", null)
                        .WithOne()
                        .HasForeignKey("PcAssembly.Domain.Components.Ram", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PcAssembly.Domain.Assembly", b =>
                {
                    b.Navigation("SavedAssemblies");
                });

            modelBuilder.Entity("PcAssembly.Domain.Auth.User", b =>
                {
                    b.Navigation("SavedAssemblies");

                    b.Navigation("UserProfile");
                });
#pragma warning restore 612, 618
        }
    }
}
