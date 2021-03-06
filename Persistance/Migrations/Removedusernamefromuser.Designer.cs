﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(PackagesOfFutureDbContext))]
    [Migration("20210109174337_Removed username from user")]
    partial class Removedusernamefromuser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Persistance.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseAndFlatNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Persistance.Entities.Drone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Range")
                        .HasColumnType("int");

                    b.Property<int?>("SortingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SortingId");

                    b.ToTable("Drones");
                });

            modelBuilder.Entity("Persistance.Entities.Package", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("DeliveryAddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<double>("Length")
                        .HasColumnType("float");

                    b.Property<int>("ReceiveAddressId")
                        .HasColumnType("int");

                    b.Property<int?>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int?>("SortingId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.Property<double>("Width")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryAddressId");

                    b.HasIndex("ReceiveAddressId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("SortingId");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("Persistance.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Persistance.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Persistance.Entities.Sorting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sortings");
                });

            modelBuilder.Entity("Persistance.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Persistance.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SortingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SortingId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Persistance.Entities.Address", b =>
                {
                    b.HasOne("Persistance.Entities.User", null)
                        .WithMany("Addresses")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Persistance.Entities.Drone", b =>
                {
                    b.HasOne("Persistance.Entities.Sorting", "Sorting")
                        .WithMany("Drones")
                        .HasForeignKey("SortingId");

                    b.Navigation("Sorting");
                });

            modelBuilder.Entity("Persistance.Entities.Package", b =>
                {
                    b.HasOne("Persistance.Entities.Address", "DeliveryAddress")
                        .WithMany("PackagesDelivered")
                        .HasForeignKey("DeliveryAddressId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Persistance.Entities.Payment", "Payment")
                        .WithOne("Package")
                        .HasForeignKey("Persistance.Entities.Package", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persistance.Entities.Address", "ReceiveAddress")
                        .WithMany("PackagesReceived")
                        .HasForeignKey("ReceiveAddressId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Persistance.Entities.Service", "Service")
                        .WithMany("Packages")
                        .HasForeignKey("ServiceId");

                    b.HasOne("Persistance.Entities.Sorting", "Sorting")
                        .WithMany("Packages")
                        .HasForeignKey("SortingId");

                    b.Navigation("DeliveryAddress");

                    b.Navigation("Payment");

                    b.Navigation("ReceiveAddress");

                    b.Navigation("Service");

                    b.Navigation("Sorting");
                });

            modelBuilder.Entity("Persistance.Entities.Vehicle", b =>
                {
                    b.HasOne("Persistance.Entities.Sorting", "Sorting")
                        .WithMany("Vehicles")
                        .HasForeignKey("SortingId");

                    b.Navigation("Sorting");
                });

            modelBuilder.Entity("Persistance.Entities.Address", b =>
                {
                    b.Navigation("PackagesDelivered");

                    b.Navigation("PackagesReceived");
                });

            modelBuilder.Entity("Persistance.Entities.Payment", b =>
                {
                    b.Navigation("Package");
                });

            modelBuilder.Entity("Persistance.Entities.Service", b =>
                {
                    b.Navigation("Packages");
                });

            modelBuilder.Entity("Persistance.Entities.Sorting", b =>
                {
                    b.Navigation("Drones");

                    b.Navigation("Packages");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Persistance.Entities.User", b =>
                {
                    b.Navigation("Addresses");
                });
#pragma warning restore 612, 618
        }
    }
}
