﻿// <auto-generated />
using System;
using Alza.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Alza.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191021121801_AddProduct_Category_Mapping")]
    partial class AddProduct_Category_Mapping
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Alza.Data.Domain.Catalog.CategoryDataModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int?>("ParentCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Alza.Data.Domain.Catalog.ManufacturerDataModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Manufacturer");
                });

            modelBuilder.Entity("Alza.Data.Domain.Catalog.ProductCategoryDataModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("Product_Category_Mapping");
                });

            modelBuilder.Entity("Alza.Data.Domain.Catalog.ProductDataModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<int>("ManufacturerId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("PictureId");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("PictureId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Alza.Data.Domain.Media.PictureBinaryDataModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("BinaryData");

                    b.Property<int>("PictureId");

                    b.HasKey("Id");

                    b.HasIndex("PictureId")
                        .IsUnique();

                    b.ToTable("PictureBinary");
                });

            modelBuilder.Entity("Alza.Data.Domain.Media.PictureDataModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AltAttribute")
                        .HasMaxLength(300);

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("TitleAttribute")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.ToTable("Picture");
                });

            modelBuilder.Entity("Alza.Data.Domain.Catalog.CategoryDataModel", b =>
                {
                    b.HasOne("Alza.Data.Domain.Catalog.CategoryDataModel", "ParentCategory")
                        .WithMany()
                        .HasForeignKey("ParentCategoryId");
                });

            modelBuilder.Entity("Alza.Data.Domain.Catalog.ProductCategoryDataModel", b =>
                {
                    b.HasOne("Alza.Data.Domain.Catalog.CategoryDataModel", "Category")
                        .WithMany("CategoryProducts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Alza.Data.Domain.Catalog.ProductDataModel", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Alza.Data.Domain.Catalog.ProductDataModel", b =>
                {
                    b.HasOne("Alza.Data.Domain.Catalog.ManufacturerDataModel", "Manufacturer")
                        .WithMany("Products")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Alza.Data.Domain.Media.PictureDataModel", "Picture")
                        .WithMany("Products")
                        .HasForeignKey("PictureId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Alza.Data.Domain.Media.PictureBinaryDataModel", b =>
                {
                    b.HasOne("Alza.Data.Domain.Media.PictureDataModel", "Picture")
                        .WithOne("PictureBinary")
                        .HasForeignKey("Alza.Data.Domain.Media.PictureBinaryDataModel", "PictureId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
