﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using car_management_api;

#nullable disable

namespace car_management_api.Migrations
{
    [DbContext(typeof(DatabasebContext))]
    partial class DatabasebContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("CarGarage", b =>
                {
                    b.Property<int>("CarsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GaragesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CarsId", "GaragesId");

                    b.HasIndex("GaragesId");

                    b.ToTable("CarGarage");
                });

            modelBuilder.Entity("car_management_api.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductionYear")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("car_management_api.Models.Garage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Garages");
                });

            modelBuilder.Entity("car_management_api.Models.Maintenance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CarName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("GarageId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("GarageName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ScheduledDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ServiceType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("GarageId");

                    b.ToTable("Maintenances");
                });

            modelBuilder.Entity("CarGarage", b =>
                {
                    b.HasOne("car_management_api.Models.Car", null)
                        .WithMany()
                        .HasForeignKey("CarsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("car_management_api.Models.Garage", null)
                        .WithMany()
                        .HasForeignKey("GaragesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("car_management_api.Models.Maintenance", b =>
                {
                    b.HasOne("car_management_api.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("car_management_api.Models.Garage", "Garage")
                        .WithMany()
                        .HasForeignKey("GarageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Garage");
                });
#pragma warning restore 612, 618
        }
    }
}
