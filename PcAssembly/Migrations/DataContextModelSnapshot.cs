﻿// <auto-generated />
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalPrice")
                        .IsConcurrencyToken()
                        .HasColumnType("float");

                    b.Property<int>("cpuId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("cpuId");

                    b.ToTable("Assemblies");
                });

            modelBuilder.Entity("PcAssembly.Domain.Component", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ManufacturerInfoId")
                        .HasColumnType("int");

                    b.Property<int>("PowerConsumption")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerInfoId")
                        .IsUnique();

                    b.ToTable("Component");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Component");
                });

            modelBuilder.Entity("PcAssembly.Domain.ManufacturerInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Company")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Price")
                        .IsConcurrencyToken()
                        .HasColumnType("float");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ManufacturerInfos");
                });

            modelBuilder.Entity("PcAssembly.Domain.CPU", b =>
                {
                    b.HasBaseType("PcAssembly.Domain.Component");

                    b.Property<int>("Cores")
                        .HasColumnType("int");

                    b.Property<int>("Family")
                        .HasColumnType("int");

                    b.Property<float>("Frequency")
                        .HasColumnType("real");

                    b.Property<int>("Generation")
                        .HasColumnType("int");

                    b.Property<int>("Socket")
                        .HasColumnType("int");

                    b.Property<int>("Threads")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("CPU");
                });

            modelBuilder.Entity("PcAssembly.Domain.Assembly", b =>
                {
                    b.HasOne("PcAssembly.Domain.CPU", "Cpu")
                        .WithMany()
                        .HasForeignKey("cpuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cpu");
                });

            modelBuilder.Entity("PcAssembly.Domain.Component", b =>
                {
                    b.HasOne("PcAssembly.Domain.ManufacturerInfo", "ManufacturerInfo")
                        .WithMany()
                        .HasForeignKey("ManufacturerInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ManufacturerInfo");
                });
#pragma warning restore 612, 618
        }
    }
}