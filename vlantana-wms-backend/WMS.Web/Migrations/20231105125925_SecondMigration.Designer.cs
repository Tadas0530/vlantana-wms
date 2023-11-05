﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using vlantana_wms_backend.Data;

#nullable disable

namespace vlantana_wms_backend.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231105125925_SecondMigration")]
    partial class SecondMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("vlantana_wms_backend.Models.Auth.UserCredentials", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ID");

                    b.ToTable("Credentials");
                });

            modelBuilder.Entity("vlantana_wms_backend.Models.Auth.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClientId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ClientId1")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId1");

                    b.ToTable("UserModels");
                });

            modelBuilder.Entity("vlantana_wms_backend.Models.Business.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("OrganizationName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ClientModels");
                });

            modelBuilder.Entity("vlantana_wms_backend.Models.Business.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("OrderModels");
                });

            modelBuilder.Entity("vlantana_wms_backend.Models.Business.Pallete", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateArrived")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateExported")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsDefective")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("OrderId");

                    b.ToTable("PalleteModels");
                });

            modelBuilder.Entity("vlantana_wms_backend.Models.Business.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("PalleteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("OrderId");

                    b.HasIndex("PalleteId");

                    b.ToTable("ProductModels");
                });

            modelBuilder.Entity("vlantana_wms_backend.Models.Auth.UserModel", b =>
                {
                    b.HasOne("vlantana_wms_backend.Models.Business.Client", "Client")
                        .WithMany("Users")
                        .HasForeignKey("ClientId1");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("vlantana_wms_backend.Models.Business.Order", b =>
                {
                    b.HasOne("vlantana_wms_backend.Models.Business.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("vlantana_wms_backend.Models.Business.Pallete", b =>
                {
                    b.HasOne("vlantana_wms_backend.Models.Business.Client", "Client")
                        .WithMany("Palletes")
                        .HasForeignKey("ClientId");

                    b.HasOne("vlantana_wms_backend.Models.Business.Order", "Order")
                        .WithMany("Palletes")
                        .HasForeignKey("OrderId");

                    b.Navigation("Client");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("vlantana_wms_backend.Models.Business.Product", b =>
                {
                    b.HasOne("vlantana_wms_backend.Models.Business.Client", "Client")
                        .WithMany("Products")
                        .HasForeignKey("ClientId");

                    b.HasOne("vlantana_wms_backend.Models.Business.Order", "Order")
                        .WithMany("Products")
                        .HasForeignKey("OrderId");

                    b.HasOne("vlantana_wms_backend.Models.Business.Pallete", "Pallete")
                        .WithMany("Products")
                        .HasForeignKey("PalleteId");

                    b.Navigation("Client");

                    b.Navigation("Order");

                    b.Navigation("Pallete");
                });

            modelBuilder.Entity("vlantana_wms_backend.Models.Business.Client", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Palletes");

                    b.Navigation("Products");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("vlantana_wms_backend.Models.Business.Order", b =>
                {
                    b.Navigation("Palletes");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("vlantana_wms_backend.Models.Business.Pallete", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
