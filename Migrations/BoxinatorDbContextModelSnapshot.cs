﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using boxinator.Models;

namespace boxinator.Migrations
{
    [DbContext(typeof(BoxinatorDbContext))]
    partial class BoxinatorDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("boxinator.Models.BoxType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("BoxType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Premium",
                            Weight = 8.0
                        });
                });

            modelBuilder.Entity("boxinator.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ZoneId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ZoneId");

                    b.ToTable("Country");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Finland",
                            ZoneId = 1
                        });
                });

            modelBuilder.Entity("boxinator.Models.Domain.Box", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BoxTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("ShipmentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BoxTypeId");

                    b.HasIndex("ShipmentId");

                    b.ToTable("Box");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BoxTypeId = 1,
                            Color = "(32,178,170)",
                            ShipmentId = 1
                        });
                });

            modelBuilder.Entity("boxinator.Models.Domain.Shipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("ReceiverName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("UserId");

                    b.ToTable("Shipment");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cost = 100.0,
                            CountryId = 1,
                            ReceiverName = "Petteri Smith",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("boxinator.Models.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountType = "REGISTERED_USER",
                            CountryId = 1,
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "awesomemartta@gs.com",
                            FirstName = "Martta",
                            LastName = "Johnsson",
                            PhoneNumber = "16064650210",
                            ZipCode = "610650"
                        });
                });

            modelBuilder.Entity("boxinator.Models.Domain.Zone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryMultiplier")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Zone");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryMultiplier = 100,
                            Name = "Europe"
                        });
                });

            modelBuilder.Entity("boxinator.Models.ShipmentStatusLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("ShipmentId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("ShipmentId");

                    b.ToTable("ShipmentStatusLog");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2021, 10, 7, 9, 54, 9, 921, DateTimeKind.Local).AddTicks(5204),
                            ShipmentId = 1,
                            Status = "CREATED"
                        });
                });

            modelBuilder.Entity("boxinator.Models.Country", b =>
                {
                    b.HasOne("boxinator.Models.Domain.Zone", "Zone")
                        .WithMany("Countries")
                        .HasForeignKey("ZoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Zone");
                });

            modelBuilder.Entity("boxinator.Models.Domain.Box", b =>
                {
                    b.HasOne("boxinator.Models.BoxType", "BoxType")
                        .WithMany("Boxes")
                        .HasForeignKey("BoxTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("boxinator.Models.Domain.Shipment", "Shipment")
                        .WithMany("Boxes")
                        .HasForeignKey("ShipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoxType");

                    b.Navigation("Shipment");
                });

            modelBuilder.Entity("boxinator.Models.Domain.Shipment", b =>
                {
                    b.HasOne("boxinator.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("boxinator.Models.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Country");

                    b.Navigation("User");
                });

            modelBuilder.Entity("boxinator.Models.Domain.User", b =>
                {
                    b.HasOne("boxinator.Models.Country", "Country")
                        .WithMany("Users")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("boxinator.Models.ShipmentStatusLog", b =>
                {
                    b.HasOne("boxinator.Models.Domain.Shipment", "Shipment")
                        .WithMany("ShipmentStatusLogs")
                        .HasForeignKey("ShipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shipment");
                });

            modelBuilder.Entity("boxinator.Models.BoxType", b =>
                {
                    b.Navigation("Boxes");
                });

            modelBuilder.Entity("boxinator.Models.Country", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("boxinator.Models.Domain.Shipment", b =>
                {
                    b.Navigation("Boxes");

                    b.Navigation("ShipmentStatusLogs");
                });

            modelBuilder.Entity("boxinator.Models.Domain.Zone", b =>
                {
                    b.Navigation("Countries");
                });
#pragma warning restore 612, 618
        }
    }
}
