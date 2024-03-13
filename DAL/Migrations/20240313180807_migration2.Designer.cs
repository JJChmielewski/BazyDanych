﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(WebShopContext))]
    [Migration("20240313180807_migration2")]
    partial class migration2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Model.BasketPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId1")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProductId1")
                        .IsUnique()
                        .HasFilter("[ProductId1] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1")
                        .IsUnique()
                        .HasFilter("[UserId1] IS NOT NULL");

                    b.ToTable("BasketPositions");
                });

            modelBuilder.Entity("Model.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId1")
                        .HasColumnType("int");

                    b.Property<bool>("isPayed")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Model.OrderPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId")
                        .IsUnique()
                        .HasFilter("[ProductId] IS NOT NULL");

                    b.ToTable("OrderPositions");
                });

            modelBuilder.Entity("Model.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Model.ProductGroup", b =>
                {
                    b.Property<int>("ProductGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductGroupId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("ProductGroupId");

                    b.HasIndex("ParentId");

                    b.ToTable("ProductGroups");
                });

            modelBuilder.Entity("Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserGroupId")
                        .HasColumnType("int");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("UserGroupId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Model.UserGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserGroups");
                });

            modelBuilder.Entity("Model.BasketPosition", b =>
                {
                    b.HasOne("Model.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Model.Product", null)
                        .WithOne("BasketPosition")
                        .HasForeignKey("Model.BasketPosition", "ProductId1");

                    b.HasOne("Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Model.User", null)
                        .WithOne("BasketPosition")
                        .HasForeignKey("Model.BasketPosition", "UserId1");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Model.Order", b =>
                {
                    b.HasOne("Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Model.User", null)
                        .WithMany("Orders")
                        .HasForeignKey("UserId1");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Model.OrderPosition", b =>
                {
                    b.HasOne("Model.Order", "Order")
                        .WithMany("OrderPositions")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Model.Product", "Product")
                        .WithOne("OrderPosition")
                        .HasForeignKey("Model.OrderPosition", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Model.Product", b =>
                {
                    b.HasOne("Model.ProductGroup", "ProductGroup")
                        .WithMany("Products")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("ProductGroup");
                });

            modelBuilder.Entity("Model.ProductGroup", b =>
                {
                    b.HasOne("Model.ProductGroup", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Model.User", b =>
                {
                    b.HasOne("Model.UserGroup", "UserGroup")
                        .WithMany("Users")
                        .HasForeignKey("UserGroupId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("UserGroup");
                });

            modelBuilder.Entity("Model.Order", b =>
                {
                    b.Navigation("OrderPositions");
                });

            modelBuilder.Entity("Model.Product", b =>
                {
                    b.Navigation("BasketPosition");

                    b.Navigation("OrderPosition");
                });

            modelBuilder.Entity("Model.ProductGroup", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Model.User", b =>
                {
                    b.Navigation("BasketPosition");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Model.UserGroup", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
