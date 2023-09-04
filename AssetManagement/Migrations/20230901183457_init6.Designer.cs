﻿// <auto-generated />
using AssetManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AssetManagement.Migrations
{
    [DbContext(typeof(SeatManagementDbContext))]
    [Migration("20230901183457_init6")]
    partial class init6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AssetManagement.Model.Allocation", b =>
                {
                    b.Property<int>("AllocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AllocationId"), 1L, 1);

                    b.Property<int>("AssetId")
                        .HasColumnType("int");

                    b.Property<int>("AssetLookupId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("AllocationId");

                    b.HasIndex("AssetLookupId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Allocations");
                });

            modelBuilder.Entity("AssetManagement.Model.Amenity", b =>
                {
                    b.Property<int>("AmenityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AmenityId"), 1L, 1);

                    b.Property<string>("AmenityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AmenityId");

                    b.ToTable("Amenitys");
                });

            modelBuilder.Entity("AssetManagement.Model.AssetLookup", b =>
                {
                    b.Property<int>("AssetLookupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssetLookupId"), 1L, 1);

                    b.Property<string>("AssetType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AssetLookupId");

                    b.ToTable("AssetLookups");
                });

            modelBuilder.Entity("AssetManagement.Model.BuildingLookup", b =>
                {
                    b.Property<int>("BuildingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BuildingId"), 1L, 1);

                    b.Property<string>("BuildingAbbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BuildingName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BuildingId");

                    b.ToTable("BuildingLookups");
                });

            modelBuilder.Entity("AssetManagement.Model.Cabin", b =>
                {
                    b.Property<int>("CabinId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CabinId"), 1L, 1);

                    b.Property<string>("CabinName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FacilityId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAssigned")
                        .HasColumnType("bit");

                    b.HasKey("CabinId");

                    b.HasIndex("FacilityId");

                    b.ToTable("Cabins");
                });

            modelBuilder.Entity("AssetManagement.Model.CityLookup", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"), 1L, 1);

                    b.Property<string>("CityAbbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.ToTable("CityLookups");
                });

            modelBuilder.Entity("AssetManagement.Model.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"), 1L, 1);

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("AssetManagement.Model.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("AssetManagement.Model.Facility", b =>
                {
                    b.Property<int>("FacilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FacilityId"), 1L, 1);

                    b.Property<int>("BuildingId")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("FacilityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.HasKey("FacilityId");

                    b.HasIndex("BuildingId");

                    b.ToTable("Facilities");
                });

            modelBuilder.Entity("AssetManagement.Model.MeetingRoom", b =>
                {
                    b.Property<int>("RoomID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomID"), 1L, 1);

                    b.Property<int>("Chairs")
                        .HasColumnType("int");

                    b.Property<int>("FacilityId")
                        .HasColumnType("int");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomID");

                    b.HasIndex("FacilityId");

                    b.ToTable("MeetingRooms");
                });

            modelBuilder.Entity("AssetManagement.Model.RoomToAmenityMap", b =>
                {
                    b.Property<int>("RAMapId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RAMapId"), 1L, 1);

                    b.Property<int>("AmenityId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("RAMapId");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomToAmenityMaps");
                });

            modelBuilder.Entity("AssetManagement.Model.Seat", b =>
                {
                    b.Property<int>("SeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeatId"), 1L, 1);

                    b.Property<int>("FacilityId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAssigned")
                        .HasColumnType("bit");

                    b.Property<string>("SeatName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SeatId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("AssetManagement.Model.Allocation", b =>
                {
                    b.HasOne("AssetManagement.Model.AssetLookup", "AssetLookup")
                        .WithMany()
                        .HasForeignKey("AssetLookupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssetManagement.Model.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssetLookup");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("AssetManagement.Model.Cabin", b =>
                {
                    b.HasOne("AssetManagement.Model.Facility", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Facility");
                });

            modelBuilder.Entity("AssetManagement.Model.Employee", b =>
                {
                    b.HasOne("AssetManagement.Model.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("AssetManagement.Model.Facility", b =>
                {
                    b.HasOne("AssetManagement.Model.BuildingLookup", "BuildingLookup")
                        .WithMany()
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BuildingLookup");
                });

            modelBuilder.Entity("AssetManagement.Model.MeetingRoom", b =>
                {
                    b.HasOne("AssetManagement.Model.Facility", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Facility");
                });

            modelBuilder.Entity("AssetManagement.Model.RoomToAmenityMap", b =>
                {
                    b.HasOne("AssetManagement.Model.MeetingRoom", "MeetingRoom")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MeetingRoom");
                });
#pragma warning restore 612, 618
        }
    }
}
