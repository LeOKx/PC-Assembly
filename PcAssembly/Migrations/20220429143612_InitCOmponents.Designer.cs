﻿// <auto-generated />
using System;
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
    [Migration("20220429143612_InitCOmponents")]
    partial class InitCOmponents
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

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
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PcAssembly.Domain.Auth.UserProfile", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

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
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

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

            modelBuilder.Entity("PcAssembly.Domain.SavedAssemblies", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

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
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("FormFactor")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int?>("RamSlots")
                        .IsRequired()
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

                    b.Property<int>("RamSize")
                        .HasColumnType("int");

                    b.Property<string>("RamType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Rams", (string)null);
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
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PcAssembly.Domain.Components.PowerSupply", "PowerSupply")
                        .WithMany()
                        .HasForeignKey("PowerSupplyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PcAssembly.Domain.Components.Ram", "Ram")
                        .WithMany()
                        .HasForeignKey("RamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PcAssembly.Domain.Auth.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
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
