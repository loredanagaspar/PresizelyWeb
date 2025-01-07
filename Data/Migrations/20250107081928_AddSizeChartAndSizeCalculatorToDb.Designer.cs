﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PresizelyWeb.Data;

#nullable disable

namespace PresizelyWeb.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250107081928_AddSizeChartAndSizeCalculatorToDb")]
    partial class AddSizeChartAndSizeCalculatorToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PresizelyWeb.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("PresizelyWeb.Data.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "T-Shirts"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Shirts"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Jeans"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Trousers"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Jackets"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Sweaters"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Hoodies"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Shorts"
                        });
                });

            modelBuilder.Entity("PresizelyWeb.Data.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("OrderHeaderId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrderHeaderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("PresizelyWeb.Data.OrderHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("OrderTotal")
                        .HasColumnType("float");

                    b.Property<string>("PaymentIntentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SessionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrderHeader");
                });

            modelBuilder.Entity("PresizelyWeb.Data.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsTop")
                        .HasColumnType("bit");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SizeChartJson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialTag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Color = "White",
                            Description = "A comfortable plain white T-shirt.",
                            ImageUrl = "/lib/images/product/T-shirt1.png",
                            IsTop = true,
                            Material = "Cotton",
                            Name = "Plain White T-Shirt",
                            Price = 12.99m,
                            Size = "S,M,L,XL",
                            SizeChartJson = "{\r\n                \"S\": { \"BustMin\": 80, \"BustMax\": 90, \"WaistMin\": 60, \"WaistMax\": 70, \"SleeveMin\": 50, \"SleeveMax\": 55 },\r\n                \"M\": { \"BustMin\": 90, \"BustMax\": 100, \"WaistMin\": 70, \"WaistMax\": 80, \"SleeveMin\": 55, \"SleeveMax\": 60 },\r\n                \"L\": { \"BustMin\": 100, \"BustMax\": 110, \"WaistMin\": 80, \"WaistMax\": 90, \"SleeveMin\": 60, \"SleeveMax\": 65 },\r\n                \"XL\": { \"BustMin\": 110, \"BustMax\": 120, \"WaistMin\": 90, \"WaistMax\": 100, \"SleeveMin\": 65, \"SleeveMax\": 70 }\r\n            }",
                            SpecialTag = "Casual Wear",
                            Stock = 50
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Color = "Black",
                            Description = "A stylish graphic T-shirt.",
                            ImageUrl = "/lib/images/product/T-Shirt2.png",
                            IsTop = true,
                            Material = "Cotton",
                            Name = "Graphic T-Shirt",
                            Price = 15.99m,
                            Size = "S,M,L,XL",
                            SizeChartJson = "{\r\n                \"S\": { \"BustMin\": 80, \"BustMax\": 90, \"WaistMin\": 60, \"WaistMax\": 70, \"SleeveMin\": 50, \"SleeveMax\": 55 },\r\n                \"M\": { \"BustMin\": 90, \"BustMax\": 100, \"WaistMin\": 70, \"WaistMax\": 80, \"SleeveMin\": 55, \"SleeveMax\": 60 },\r\n                \"L\": { \"BustMin\": 100, \"BustMax\": 110, \"WaistMin\": 80, \"WaistMax\": 90, \"SleeveMin\": 60, \"SleeveMax\": 65 },\r\n                \"XL\": { \"BustMin\": 110, \"BustMax\": 120, \"WaistMin\": 90, \"WaistMax\": 100, \"SleeveMin\": 65, \"SleeveMax\": 70 }\r\n            }",
                            SpecialTag = "Trendy",
                            Stock = 40
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Color = "Blue",
                            Description = "Perfect for office and formal events.",
                            ImageUrl = "/lib/images/product/Shirt1.png",
                            IsTop = true,
                            Material = "Polyester",
                            Name = "Formal Shirt",
                            Price = 29.99m,
                            Size = "S,M,L,XL",
                            SizeChartJson = "{\r\n                \"S\": { \"BustMin\": 85, \"BustMax\": 95, \"WaistMin\": 65, \"WaistMax\": 75, \"SleeveMin\": 52, \"SleeveMax\": 57 },\r\n                \"M\": { \"BustMin\": 95, \"BustMax\": 105, \"WaistMin\": 75, \"WaistMax\": 85, \"SleeveMin\": 57, \"SleeveMax\": 62 },\r\n                \"L\": { \"BustMin\": 105, \"BustMax\": 115, \"WaistMin\": 85, \"WaistMax\": 95, \"SleeveMin\": 62, \"SleeveMax\": 67 },\r\n                \"XL\": { \"BustMin\": 115, \"BustMax\": 125, \"WaistMin\": 95, \"WaistMax\": 105, \"SleeveMin\": 67, \"SleeveMax\": 72 }\r\n            }",
                            SpecialTag = "Formal",
                            Stock = 30
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Color = "Red",
                            Description = "A comfortable casual shirt with checkered design.",
                            ImageUrl = "/lib/images/product/Shirt2.png",
                            IsTop = true,
                            Material = "Cotton",
                            Name = "Casual Check Shirt",
                            Price = 25.99m,
                            Size = "S,M,L,XL",
                            SizeChartJson = "{\r\n                \"S\": { \"BustMin\": 85, \"BustMax\": 95, \"WaistMin\": 65, \"WaistMax\": 75, \"SleeveMin\": 52, \"SleeveMax\": 57 },\r\n                \"M\": { \"BustMin\": 95, \"BustMax\": 105, \"WaistMin\": 75, \"WaistMax\": 85, \"SleeveMin\": 57, \"SleeveMax\": 62 },\r\n                \"L\": { \"BustMin\": 105, \"BustMax\": 115, \"WaistMin\": 85, \"WaistMax\": 95, \"SleeveMin\": 62, \"SleeveMax\": 67 },\r\n                \"XL\": { \"BustMin\": 115, \"BustMax\": 125, \"WaistMin\": 95, \"WaistMax\": 105, \"SleeveMin\": 67, \"SleeveMax\": 72 }\r\n            }",
                            SpecialTag = "Casual",
                            Stock = 35
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            Color = "Blue",
                            Description = "Classic blue denim jeans.",
                            ImageUrl = "/lib/images/product/Jeans1.png",
                            IsTop = false,
                            Material = "Denim",
                            Name = "Blue Denim Jeans",
                            Price = 39.99m,
                            Size = "32,34,36,38",
                            SizeChartJson = "{\r\n                \"32\": { \"WaistMin\": 76, \"WaistMax\": 81, \"HipsMin\": 91, \"HipsMax\": 96, \"InseamMin\": 75, \"InseamMax\": 80 },\r\n                \"34\": { \"WaistMin\": 82, \"WaistMax\": 87, \"HipsMin\": 97, \"HipsMax\": 102, \"InseamMin\": 75, \"InseamMax\": 80 },\r\n                \"36\": { \"WaistMin\": 88, \"WaistMax\": 93, \"HipsMin\": 103, \"HipsMax\": 108, \"InseamMin\": 76, \"InseamMax\": 81 },\r\n                \"38\": { \"WaistMin\": 94, \"WaistMax\": 99, \"HipsMin\": 109, \"HipsMax\": 114, \"InseamMin\": 76, \"InseamMax\": 81 }\r\n            }",
                            SpecialTag = "Everyday Wear",
                            Stock = 60
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            Color = "Black",
                            Description = "Stylish black skinny jeans.",
                            ImageUrl = "/lib/images/product/Jeans2.png",
                            IsTop = false,
                            Material = "Denim",
                            Name = "Black Skinny Jeans",
                            Price = 42.99m,
                            Size = "32,34,36,38",
                            SizeChartJson = "{\r\n                     \"32\": { \"WaistMin\": 76, \"WaistMax\": 81, \"HipsMin\": 91, \"HipsMax\": 96, \"InseamMin\": 75, \"InseamMax\": 80 },\r\n                       \"34\": { \"WaistMin\": 82, \"WaistMax\": 87, \"HipsMin\": 97, \"HipsMax\": 102, \"InseamMin\": 75, \"InseamMax\": 80 },\r\n                      \"36\": { \"WaistMin\": 88, \"WaistMax\": 93, \"HipsMin\": 103, \"HipsMax\": 108, \"InseamMin\": 76, \"InseamMax\": 81 },\r\n                      \"38\": { \"WaistMin\": 94, \"WaistMax\": 99, \"HipsMin\": 109, \"HipsMax\": 114, \"InseamMin\": 76, \"InseamMax\": 81 }\r\n                   }",
                            SpecialTag = "Trendy",
                            Stock = 45
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 4,
                            Color = "Khaki",
                            Description = "Smart casual chino trousers.",
                            ImageUrl = "/lib/images/product/Trousers1.png",
                            IsTop = false,
                            Material = "Cotton",
                            Name = "Chino Trousers",
                            Price = 34.99m,
                            Size = "32,34,36,38",
                            SizeChartJson = "{\r\n                        \"32\": { \"WaistMin\": 76, \"WaistMax\": 81, \"HipsMin\": 91, \"HipsMax\": 96, \"InseamMin\": 75, \"InseamMax\": 80 },\r\n                        \"34\": { \"WaistMin\": 82, \"WaistMax\": 87, \"HipsMin\": 97, \"HipsMax\": 102, \"InseamMin\": 75, \"InseamMax\": 80 },\r\n                        \"36\": { \"WaistMin\": 88, \"WaistMax\": 93, \"HipsMin\": 103, \"HipsMax\": 108, \"InseamMin\": 76, \"InseamMax\": 81 },\r\n                        \"38\": { \"WaistMin\": 94, \"WaistMax\": 99, \"HipsMin\": 109, \"HipsMax\": 114, \"InseamMin\": 76, \"InseamMax\": 81 }\r\n                     }",
                            SpecialTag = "Smart Casual",
                            Stock = 25
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 4,
                            Color = "Grey",
                            Description = "Elegant trousers for formal occasions.",
                            ImageUrl = "/lib/images/product/Trousers2.png",
                            IsTop = false,
                            Material = "Polyester",
                            Name = "Formal Trousers",
                            Price = 49.99m,
                            Size = "32,34,36,38",
                            SizeChartJson = "{\r\n                       \"32\": { \"WaistMin\": 76, \"WaistMax\": 81, \"HipsMin\": 91, \"HipsMax\": 96, \"InseamMin\": 75, \"InseamMax\": 80 },\r\n                       \"34\": { \"WaistMin\": 82, \"WaistMax\": 87, \"HipsMin\": 97, \"HipsMax\": 102, \"InseamMin\": 75, \"InseamMax\": 80 },\r\n                       \"36\": { \"WaistMin\": 88, \"WaistMax\": 93, \"HipsMin\": 103, \"HipsMax\": 108, \"InseamMin\": 76, \"InseamMax\": 81 },\r\n                        \"38\": { \"WaistMin\": 94, \"WaistMax\": 99, \"HipsMin\": 109, \"HipsMax\": 114, \"InseamMin\": 76, \"InseamMax\": 81 }\r\n                   }",
                            SpecialTag = "Formal",
                            Stock = 20
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 5,
                            Color = "Black",
                            Description = "A premium leather jacket for stylish outings.",
                            ImageUrl = "/lib/images/product/Jacket1.png",
                            IsTop = true,
                            Material = "Leather",
                            Name = "Leather Jacket",
                            Price = 99.99m,
                            Size = "S,M",
                            SizeChartJson = "{\r\n                          \"S\": { \"BustMin\": 85, \"BustMax\": 95, \"WaistMin\": 65, \"WaistMax\": 75, \"SleeveMin\": 55, \"SleeveMax\": 60 },\r\n                          \"M\": { \"BustMin\": 95, \"BustMax\": 105, \"WaistMin\": 75, \"WaistMax\": 85, \"SleeveMin\": 60, \"SleeveMax\": 65 },\r\n                          \"L\": { \"BustMin\": 105, \"BustMax\": 115, \"WaistMin\": 85, \"WaistMax\": 95, \"SleeveMin\": 65, \"SleeveMax\": 70 },\r\n                          \"XL\": { \"BustMin\": 115, \"BustMax\": 125, \"WaistMin\": 95, \"WaistMax\": 105, \"SleeveMin\": 70, \"SleeveMax\": 75 }\r\n                       }",
                            SpecialTag = "Premium",
                            Stock = 15
                        });
                });

            modelBuilder.Entity("PresizelyWeb.Data.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("ShoppingCart");
                });

            modelBuilder.Entity("PresizelyWeb.Data.SizeCalculator", b =>
                {
                    b.Property<int?>("Bust")
                        .HasColumnType("int");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int?>("Hips")
                        .HasColumnType("int");

                    b.Property<int?>("Inseam")
                        .HasColumnType("int");

                    b.Property<string>("RecommendedSize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SleeveLength")
                        .HasColumnType("int");

                    b.Property<int?>("Waist")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.ToTable("SizeCalculator");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PresizelyWeb.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PresizelyWeb.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PresizelyWeb.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PresizelyWeb.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PresizelyWeb.Data.OrderDetail", b =>
                {
                    b.HasOne("PresizelyWeb.Data.OrderHeader", "OrderHeader")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PresizelyWeb.Data.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderHeader");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PresizelyWeb.Data.Product", b =>
                {
                    b.HasOne("PresizelyWeb.Data.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PresizelyWeb.Data.ShoppingCart", b =>
                {
                    b.HasOne("PresizelyWeb.Data.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PresizelyWeb.Data.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PresizelyWeb.Data.OrderHeader", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
