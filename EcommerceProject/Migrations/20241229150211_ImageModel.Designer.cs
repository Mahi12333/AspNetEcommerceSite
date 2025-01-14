﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EcommerceProject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241229150211_ImageModel")]
    partial class ImageModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApplicationUserModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

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

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

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

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "38a9d2ce-b568-4574-a675-9dca224953ba",
                            CreatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(3590),
                            Email = "mahitoshgiri287@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAIAAYagAAAAECSTyLdRjAYnMQB9UJQ2/upUVKc0GZ+uQiURAfF6SGvhENXJ7Coa9OVwgwR/r6v0tg==",
                            PhoneNumberConfirmed = false,
                            RefreshToken = "SomeDummyTokenValue3543564",
                            RoleId = "B993F718-51B6-4FBE-9F17-037FA1585827",
                            SecurityStamp = "433760df-e061-44dd-a81c-bd499270fe16",
                            Slug = "admin-user",
                            TwoFactorEnabled = false,
                            UpdatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(3598),
                            UserName = "adminUser"
                        });
                });

            modelBuilder.Entity("EcommerceProject.Areas.Admin.Models.CategoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EcommerceProject.Areas.Admin.Models.CustomRoleModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "B993F718-51B6-4FBE-9F17-037FA1585827",
                            CreatedAt = new DateTime(2024, 12, 29, 15, 2, 8, 913, DateTimeKind.Utc).AddTicks(4467),
                            Name = "Admin",
                            Slug = "admin",
                            UpdatedAt = new DateTime(2024, 12, 29, 15, 2, 8, 913, DateTimeKind.Utc).AddTicks(4469)
                        },
                        new
                        {
                            Id = "C0CF4D0F-9BC6-4B70-BAED-2CA10F1AAA30",
                            CreatedAt = new DateTime(2024, 12, 29, 15, 2, 8, 913, DateTimeKind.Utc).AddTicks(4478),
                            Name = "Subadmin",
                            Slug = "subadmin",
                            UpdatedAt = new DateTime(2024, 12, 29, 15, 2, 8, 913, DateTimeKind.Utc).AddTicks(4479)
                        },
                        new
                        {
                            Id = "5482176B-6706-476D-A273-1EA9AD5AD217",
                            CreatedAt = new DateTime(2024, 12, 29, 15, 2, 8, 913, DateTimeKind.Utc).AddTicks(4487),
                            Name = "Supersubadmin",
                            Slug = "supersubadmin",
                            UpdatedAt = new DateTime(2024, 12, 29, 15, 2, 8, 913, DateTimeKind.Utc).AddTicks(4488)
                        });
                });

            modelBuilder.Entity("EcommerceProject.Areas.Admin.Models.ImageModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("filename")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("EcommerceProject.Areas.Admin.Models.OtpModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<string>("Otp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Otps");
                });

            modelBuilder.Entity("EcommerceProject.Areas.Admin.Models.PermissionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("PermissionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(3968),
                            PermissionName = "Create Product",
                            UpdatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(3970)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(3984),
                            PermissionName = "Edit Product",
                            UpdatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(3985)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(3988),
                            PermissionName = "Delete Product",
                            UpdatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(3989)
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(3992),
                            PermissionName = "View Orders",
                            UpdatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(3992)
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(3995),
                            PermissionName = "View User",
                            UpdatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(3996)
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4013),
                            PermissionName = "Access Admin Dashboard",
                            UpdatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4013)
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4016),
                            PermissionName = "Edit User",
                            UpdatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4017)
                        },
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4020),
                            PermissionName = "Delete User",
                            UpdatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4020)
                        },
                        new
                        {
                            Id = 9,
                            CreatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4023),
                            PermissionName = "Create Category",
                            UpdatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4023)
                        },
                        new
                        {
                            Id = 10,
                            CreatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4028),
                            PermissionName = "Edit Category",
                            UpdatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4029)
                        },
                        new
                        {
                            Id = 11,
                            CreatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4032),
                            PermissionName = "Delete Category",
                            UpdatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4033)
                        },
                        new
                        {
                            Id = 12,
                            CreatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4035),
                            PermissionName = "Create Subcategory",
                            UpdatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4036)
                        },
                        new
                        {
                            Id = 13,
                            CreatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4039),
                            PermissionName = "Edit Subcategory",
                            UpdatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4039)
                        },
                        new
                        {
                            Id = 14,
                            CreatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4391),
                            PermissionName = "Delete Subcategory",
                            UpdatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4421)
                        },
                        new
                        {
                            Id = 15,
                            CreatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4424),
                            PermissionName = "Create User",
                            UpdatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4425)
                        },
                        new
                        {
                            Id = 16,
                            CreatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4427),
                            PermissionName = "View Category",
                            UpdatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4428)
                        },
                        new
                        {
                            Id = 17,
                            CreatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4430),
                            PermissionName = "View Subcategory",
                            UpdatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4431)
                        },
                        new
                        {
                            Id = 18,
                            CreatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4438),
                            PermissionName = "View Product",
                            UpdatedAt = new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4439)
                        });
                });

            modelBuilder.Entity("EcommerceProject.Areas.Admin.Models.ProductModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("OriginalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Sizes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EcommerceProject.Areas.Admin.Models.SubCategoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("EcommerceProject.Areas.Admin.Models.UserPermissionModel", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.Property<int>("PermissionId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("UserId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("UserPermissions");

                    b.HasData(
                        new
                        {
                            UserId = "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45",
                            PermissionId = 1
                        },
                        new
                        {
                            UserId = "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45",
                            PermissionId = 2
                        },
                        new
                        {
                            UserId = "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45",
                            PermissionId = 3
                        },
                        new
                        {
                            UserId = "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45",
                            PermissionId = 4
                        },
                        new
                        {
                            UserId = "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45",
                            PermissionId = 5
                        },
                        new
                        {
                            UserId = "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45",
                            PermissionId = 6
                        },
                        new
                        {
                            UserId = "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45",
                            PermissionId = 7
                        },
                        new
                        {
                            UserId = "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45",
                            PermissionId = 8
                        },
                        new
                        {
                            UserId = "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45",
                            PermissionId = 9
                        },
                        new
                        {
                            UserId = "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45",
                            PermissionId = 10
                        },
                        new
                        {
                            UserId = "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45",
                            PermissionId = 11
                        },
                        new
                        {
                            UserId = "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45",
                            PermissionId = 12
                        },
                        new
                        {
                            UserId = "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45",
                            PermissionId = 13
                        },
                        new
                        {
                            UserId = "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45",
                            PermissionId = 14
                        },
                        new
                        {
                            UserId = "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45",
                            PermissionId = 15
                        },
                        new
                        {
                            UserId = "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45",
                            PermissionId = 16
                        },
                        new
                        {
                            UserId = "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45",
                            PermissionId = 17
                        },
                        new
                        {
                            UserId = "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45",
                            PermissionId = 18
                        });
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

            modelBuilder.Entity("ApplicationUserModel", b =>
                {
                    b.HasOne("EcommerceProject.Areas.Admin.Models.CustomRoleModel", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("EcommerceProject.Areas.Admin.Models.ImageModel", b =>
                {
                    b.HasOne("EcommerceProject.Areas.Admin.Models.ProductModel", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EcommerceProject.Areas.Admin.Models.ProductModel", b =>
                {
                    b.HasOne("EcommerceProject.Areas.Admin.Models.CategoryModel", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EcommerceProject.Areas.Admin.Models.SubCategoryModel", "SubCategory")
                        .WithMany("Products")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("EcommerceProject.Areas.Admin.Models.SubCategoryModel", b =>
                {
                    b.HasOne("EcommerceProject.Areas.Admin.Models.CategoryModel", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EcommerceProject.Areas.Admin.Models.UserPermissionModel", b =>
                {
                    b.HasOne("EcommerceProject.Areas.Admin.Models.PermissionModel", "Permission")
                        .WithMany("UserPermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationUserModel", "User")
                        .WithMany("UserPermissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("EcommerceProject.Areas.Admin.Models.CustomRoleModel", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ApplicationUserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ApplicationUserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("EcommerceProject.Areas.Admin.Models.CustomRoleModel", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationUserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ApplicationUserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApplicationUserModel", b =>
                {
                    b.Navigation("UserPermissions");
                });

            modelBuilder.Entity("EcommerceProject.Areas.Admin.Models.CategoryModel", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("EcommerceProject.Areas.Admin.Models.PermissionModel", b =>
                {
                    b.Navigation("UserPermissions");
                });

            modelBuilder.Entity("EcommerceProject.Areas.Admin.Models.ProductModel", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("EcommerceProject.Areas.Admin.Models.SubCategoryModel", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
