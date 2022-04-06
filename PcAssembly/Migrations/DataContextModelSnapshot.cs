﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PcAssembly.Dal;

#nullable disable

namespace PcAssembly.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PcAssembly.Domain.Assembly", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CpuId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("Date");

                    b.Property<int>("GraphicCardId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CpuId");

                    b.HasIndex("GraphicCardId");

                    b.HasIndex("UserId");

                    b.ToTable("Assemblies");
                });

            modelBuilder.Entity("PcAssembly.Domain.Auth.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
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
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("About")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("Date");

                    b.HasKey("UserId");

                    b.ToTable("UsersProfiles");
                });

            modelBuilder.Entity("PcAssembly.Domain.Components.CPU", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Company")
                        .HasColumnType("int");

                    b.Property<int>("Cores")
                        .HasColumnType("int");

                    b.Property<int>("Family")
                        .HasColumnType("int");

                    b.Property<float>("Frequency")
                        .HasColumnType("real");

                    b.Property<int>("Generation")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PowerConsumption")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("float");

                    b.Property<int>("Socket")
                        .HasColumnType("int");

                    b.Property<int>("Threads")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CPUs");
                });

            modelBuilder.Entity("PcAssembly.Domain.Components.GraphicCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("About")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Company")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PowerConsumption")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("float");

                    b.Property<int>("SgRamSize")
                        .HasColumnType("int");

                    b.Property<int>("SgRamType")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GraphicCards");
                });

            modelBuilder.Entity("PcAssembly.Domain.SavedAssemblies", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("AssemblyId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "AssemblyId");

                    b.HasIndex("AssemblyId");

                    b.ToTable("SavedAssemblies");
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

                    b.HasOne("PcAssembly.Domain.Auth.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cpu");

                    b.Navigation("GraphicCard");

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
                        .HasForeignKey("AssemblyId")
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

            modelBuilder.Entity("PcAssembly.Domain.Assembly", b =>
                {
                    b.Navigation("SavedAssemblies");
                });

            modelBuilder.Entity("PcAssembly.Domain.Auth.User", b =>
                {
                    b.Navigation("SavedAssemblies");

                    b.Navigation("UserProfile")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
