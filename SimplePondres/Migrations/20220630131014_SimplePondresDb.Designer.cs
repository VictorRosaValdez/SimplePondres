﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimplePondres.Dal;

#nullable disable

namespace SimplePondres.Migrations
{
    [DbContext(typeof(SimplePondresDbContext))]
    [Migration("20220630131014_SimplePondresDb")]
    partial class SimplePondresDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SimplePondres.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyId"), 1L, 1);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("CompanyPhoneNumber")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("CompanyId");

                    b.ToTable("Company");

                    b.HasData(
                        new
                        {
                            CompanyId = 1,
                            CompanyName = "Package solutions",
                            CompanyPhoneNumber = 310401574,
                            Email = "package@solutions.com"
                        },
                        new
                        {
                            CompanyId = 2,
                            CompanyName = "Het thuiszorg BV",
                            CompanyPhoneNumber = 310401575,
                            Email = "ana@thuiszorg.nl"
                        });
                });

            modelBuilder.Entity("SimplePondres.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("ExternalReference")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ExtraRequirements")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("TimeOfDelivery")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ProductId");

                    b.ToTable("Order");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            Adress = "Molenlaan 5",
                            CompanyId = 2,
                            ExternalReference = "Customer 1",
                            ExtraRequirements = "Please deliver the order at the warehouse",
                            ProductId = 3,
                            State = "Created",
                            TimeOfDelivery = new DateTime(2022, 6, 30, 15, 10, 14, 512, DateTimeKind.Local).AddTicks(1799)
                        },
                        new
                        {
                            OrderId = 2,
                            Adress = "Sonseweg 7",
                            CompanyId = 2,
                            ExternalReference = "Customer 2",
                            ExtraRequirements = "No extra requirements",
                            ProductId = 3,
                            State = "Picked",
                            TimeOfDelivery = new DateTime(2022, 6, 30, 15, 10, 14, 512, DateTimeKind.Local).AddTicks(1837)
                        },
                        new
                        {
                            OrderId = 3,
                            Adress = "Planetelaan 1",
                            CompanyId = 1,
                            ExternalReference = "Customer 3",
                            ExtraRequirements = "No extra requirements",
                            ProductId = 1,
                            State = "Delivered",
                            TimeOfDelivery = new DateTime(2022, 6, 30, 15, 10, 14, 512, DateTimeKind.Local).AddTicks(1840)
                        });
                });

            modelBuilder.Entity("SimplePondres.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ExternalReference")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ProductId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Description = "This is a wonderful card",
                            ExternalReference = "Pondres simple card",
                            Name = "Simple card",
                            Stock = 5,
                            Type = "Card"
                        },
                        new
                        {
                            ProductId = 2,
                            Description = "The best bord ever",
                            ExternalReference = "Pondres amazing bord",
                            Name = "Amazing bord",
                            Stock = 0,
                            Type = "Bord"
                        },
                        new
                        {
                            ProductId = 3,
                            Description = "Magic paper",
                            ExternalReference = "Pondres paper",
                            Name = "Paper",
                            Stock = 10,
                            Type = "Print Paper"
                        });
                });

            modelBuilder.Entity("SimplePondres.Models.Order", b =>
                {
                    b.HasOne("SimplePondres.Models.Company", null)
                        .WithMany("Order")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SimplePondres.Models.Product", null)
                        .WithMany("Order")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SimplePondres.Models.Company", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("SimplePondres.Models.Product", b =>
                {
                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
