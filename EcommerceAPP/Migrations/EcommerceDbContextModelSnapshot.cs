﻿using EcommerceAPP.Data.DbContext;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;


namespace EcommerceAPP.Migrations
{
    [DbContext(typeof(EcommerceDbContext))]
    partial class EcommerceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);


            modelBuilder.Entity("EcommerceAPP.Data.Models.Category", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnType("nvarchar(25)");

                b.HasKey("Id");

                b.ToTable("Categories");
            });

            modelBuilder.Entity("EcommerceAPP.Data.Models.Order", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<DateTime>("Date")
                    .HasColumnType("datetime2");

                b.Property<bool>("OrderStatus")
                    .HasColumnType("bit");

                b.Property<int>("Quantity")
                    .HasColumnType("int");

                b.Property<decimal>("TotalPrice")
                    .HasColumnType("decimal(18,2)");

                b.Property<int>("UserId")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.HasIndex("UserId");

                b.ToTable("Orders");
            });

            modelBuilder.Entity("EcommerceAPP.Data.Models.OrderProduct", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<int>("OrderId")
                    .HasColumnType("int");

                b.Property<int>("ProductId")
                    .HasColumnType("int");

                b.Property<int>("Quantity")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.HasIndex("OrderId");

                b.HasIndex("ProductId");

                b.ToTable("OrderProducts");
            });

            modelBuilder.Entity("EcommerceAPP.Data.Models.Product", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<int>("CategoryId")
                    .HasColumnType("int");

                b.Property<string>("Description")
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnType("nvarchar(1000)");

                b.Property<string>("Image")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.Property<string>("Make")
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnType("nvarchar(25)");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<int>("Price")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.HasIndex("CategoryId");

                b.ToTable("Products");
            });

            modelBuilder.Entity("EcommerceAPP.Data.Models.User", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("Email")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<string>("Icon")
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnType("nvarchar(200)");

                b.Property<bool>("IsAdmin")
                    .HasColumnType("bit");

                b.Property<string>("Login")
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnType("nvarchar(30)");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnType("nvarchar(30)");

                b.Property<string>("Password")
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnType("nvarchar(30)");

                b.Property<string>("Surname")
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnType("nvarchar(30)");

                b.Property<int>("UserDetailId")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.HasIndex("Login")
                    .IsUnique();

                b.ToTable("Users");
            });

            modelBuilder.Entity("EcommerceAPP.Data.Models.UserDetail", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("Address")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.Property<string>("City")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.Property<string>("Country")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.Property<string>("PhoneNumber")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.Property<string>("PostalCode")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.Property<int>("UserId")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.HasIndex("UserId")
                    .IsUnique();

                b.ToTable("UserDetails");
            });

            modelBuilder.Entity("EcommerceAPP.Data.Models.UserPayment", b =>
            {
                b.Property<int>("ID")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("CVV")
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnType("nvarchar(3)");

                b.Property<string>("EXP")
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnType("nvarchar(5)");

                b.Property<string>("SixteenDigitCode")
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnType("nvarchar(16)");

                b.Property<int>("UserId")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.HasIndex("UserId");

                b.ToTable("UserPayments");
            });

            modelBuilder.Entity("EcommerceAPP.Data.Models.Order", b =>
            {
                b.HasOne("EcommerceAPP.Data.Models.User", "User")
                    .WithMany("Orders")
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                b.Navigation("User");
            });

            modelBuilder.Entity("EcommerceAPP.Data.Models.OrderProduct", b =>
            {
                b.HasOne("EcommerceAPP.Data.Models.Order", "Order")
                    .WithMany("OrderProducts")
                    .HasForeignKey("OrderId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("EcommerceAPP.Data.Models.Product", "Product")
                    .WithMany("OrderProducts")
                    .HasForeignKey("ProductId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Order");

                b.Navigation("Product");
            });

            modelBuilder.Entity("EcommerceAPP.Data.Models.Product", b =>
            {
                b.HasOne("EcommerceAPP.Data.Models.Category", "Category")
                    .WithMany("Products")
                    .HasForeignKey("CategoryId")
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                b.Navigation("Category");
            });

            modelBuilder.Entity("EcommerceAPP.Data.Models.UserDetail", b =>
            {
                b.HasOne("EcommerceAPP.Data.Models.User", "User")
                    .WithOne("UserDetail")
                    .HasForeignKey("EcommerceAPP.Data.Models.UserDetail", "UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("User");
            });

            modelBuilder.Entity("EcommerceAPP.Data.Models.UserPayment", b =>
            {
                b.HasOne("EcommerceAPP.Data.Models.User", "User")
                    .WithMany("UserPayments")
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                b.Navigation("User");
            });


            modelBuilder.Entity("EcommerceAPP.Data.Models.Category", b =>
            {
                b.Navigation("Products");
            });

            modelBuilder.Entity("EcommerceAPP.Data.Models.Order", b =>
            {
                b.Navigation("OrderProducts");
            });

            modelBuilder.Entity("EcommerceAPP.Data.Models.Product", b =>
            {

                b.Navigation("OrderProducts");
            });

            modelBuilder.Entity("EcommerceAPP.Data.Models.User", b =>
            {

                b.Navigation("Orders");

                b.Navigation("UserDetail")
                    .IsRequired();

                b.Navigation("UserPayments");
            });
#pragma warning restore 612, 618
        }
    }
}
