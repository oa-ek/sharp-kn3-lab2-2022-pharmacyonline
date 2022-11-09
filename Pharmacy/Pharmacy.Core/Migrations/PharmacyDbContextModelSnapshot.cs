﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pharmacy.Core;

#nullable disable

namespace Pharmacy.Core.Migrations
{
    [DbContext(typeof(PharmacyDbContext))]
    partial class PharmacyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

                    b.HasData(
                        new
                        {
                            Id = "fc056ad0-997b-4966-948d-d6a667444fc6",
                            ConcurrencyStamp = "68909fb2-12fb-4d8c-9892-4712aed16f20",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "b4949472-1f1e-4810-90af-ae61fa308e1b",
                            ConcurrencyStamp = "a71807a5-302e-4d51-8e78-ef3253e4865c",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "ecde7c2d-7e5a-459e-b912-aabf22fb2cdd",
                            ConcurrencyStamp = "4036d256-d0b6-4783-8c5e-41c1e8ae71a7",
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

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

                    b.HasData(
                        new
                        {
                            UserId = "eb882a65-da1d-4479-ad40-29c0ec243f1a",
                            RoleId = "fc056ad0-997b-4966-948d-d6a667444fc6"
                        },
                        new
                        {
                            UserId = "eb882a65-da1d-4479-ad40-29c0ec243f1a",
                            RoleId = "b4949472-1f1e-4810-90af-ae61fa308e1b"
                        },
                        new
                        {
                            UserId = "34976306-79f9-48d6-96c1-283464e2e54e",
                            RoleId = "b4949472-1f1e-4810-90af-ae61fa308e1b"
                        },
                        new
                        {
                            UserId = "7006e163-71c7-4ff3-8074-befac77edec3",
                            RoleId = "ecde7c2d-7e5a-459e-b912-aabf22fb2cdd"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Pharmacy.Core.Brend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brend");
                });

            modelBuilder.Entity("Pharmacy.Core.Catalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Catalog");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Лікарські засоби"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Краса та догляд"
                        });
                });

            modelBuilder.Entity("Pharmacy.Core.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CatalogId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CatalogId");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Застуда і грип"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Серцево-судинна система"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Кровотворення та кров"
                        });
                });

            modelBuilder.Entity("Pharmacy.Core.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Pharmacy.Core.Medicaments", b =>
                {
                    b.Property<int>("MedicamentsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicamentsId"), 1L, 1);

                    b.Property<int?>("BrendId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dosage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int?>("ProductLineId")
                        .HasColumnType("int");

                    b.Property<string>("ReleaseForm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MedicamentsId");

                    b.HasIndex("BrendId");

                    b.HasIndex("CountryId");

                    b.HasIndex("ProductLineId");

                    b.ToTable("Medicaments");

                    b.HasData(
                        new
                        {
                            MedicamentsId = 1,
                            Code = "4882",
                            Dosage = "",
                            Image = "C:\\Users\\Admin\\Documents\\GitHub\\Pharmacy_online\\Pharmacy\\Pharmacy.UI\\wwwroot\\img\\catalogue\\jonas-jaeken-VyIj995OXNQ-unsplash.jpg",
                            Name = "Синупрет табл. в/о №50",
                            Price = 125.62f,
                            ReleaseForm = "таблетки для внутрішнього застосування"
                        });
                });

            modelBuilder.Entity("Pharmacy.Core.Order", b =>
                {
                    b.Property<string>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Total")
                        .HasColumnType("real");

                    b.Property<int?>("detailsId")
                        .HasColumnType("int");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OrderId");

                    b.HasIndex("detailsId");

                    b.HasIndex("userId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Pharmacy.Core.OrderAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrderAddress");
                });

            modelBuilder.Entity("Pharmacy.Core.OrderDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Payment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Total")
                        .HasColumnType("real");

                    b.Property<string>("TypeOfDelivery")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Pharmacy.Core.OrderItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MedicamentsId")
                        .HasColumnType("int");

                    b.Property<int>("OrderDetailsId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedicamentsId");

                    b.HasIndex("OrderDetailsId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Pharmacy.Core.ProductLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductLine");
                });

            modelBuilder.Entity("Pharmacy.Core.SubCategory", b =>
                {
                    b.Property<int>("SubCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubCategoryId"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubCategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategory");

                    b.HasData(
                        new
                        {
                            SubCategoryId = 1,
                            Name = "Від кашлю"
                        });
                });

            modelBuilder.Entity("Pharmacy.Core.SubCategoryMedicaments", b =>
                {
                    b.Property<int>("MedicamentsId")
                        .HasColumnType("int");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.HasKey("MedicamentsId", "SubCategoryId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("SubCategoryMedicaments");

                    b.HasData(
                        new
                        {
                            MedicamentsId = 1,
                            SubCategoryId = 1
                        });
                });

            modelBuilder.Entity("Pharmacy.Core.User", b =>
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

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

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

                    b.HasData(
                        new
                        {
                            Id = "eb882a65-da1d-4479-ad40-29c0ec243f1a",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "04d29e45-4478-4a91-a29f-2579a5a326a0",
                            Email = "admin@pharmacy.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@PHARMACY.COM",
                            NormalizedUserName = "ADMIN@PHARMACY.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEOEQd9ukk1s1KLommr4Kxtz1jVrP7hBBEB+kSZTng+AWGtR5orcY3wZwaqaoyprUgQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b4294965-e050-449d-94e0-7c5612f7fbc5",
                            TwoFactorEnabled = false,
                            UserName = "admin@pharmacy.com"
                        },
                        new
                        {
                            Id = "34976306-79f9-48d6-96c1-283464e2e54e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c71c2fed-b6b4-41f3-b67e-d6f0fb639241",
                            Email = "user@pharmacy.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@PHARMACY.COM",
                            NormalizedUserName = "USER@PHARMACY.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEKYVSgnaGBb1QrodVATzn3IumrwavgkTOS0Qz38Y/LFbcz3C607wuefsEygq3AZgOg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "248fee51-8610-4908-a5eb-c027ef350871",
                            TwoFactorEnabled = false,
                            UserName = "user@pharmacy.com"
                        },
                        new
                        {
                            Id = "7006e163-71c7-4ff3-8074-befac77edec3",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "38e55e01-0c19-439e-b172-5a35a2ff2303",
                            Email = "manager@pharmacy.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "MANAGER@PHARMACY.COM",
                            NormalizedUserName = "MANAGER@PHARMACY.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAECTGUOvpmP0RFASzILx4QJzcj3bCAsCQc4L9I4k/5YiQySv35wNlZ6A/rOJjol12rQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "3ac08b93-0451-407c-8716-746c2e23c1bf",
                            TwoFactorEnabled = false,
                            UserName = "manager@pharmacy.com"
                        });
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
                    b.HasOne("Pharmacy.Core.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Pharmacy.Core.User", null)
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

                    b.HasOne("Pharmacy.Core.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Pharmacy.Core.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pharmacy.Core.Category", b =>
                {
                    b.HasOne("Pharmacy.Core.Catalog", "Catalog")
                        .WithMany("Category")
                        .HasForeignKey("CatalogId");

                    b.Navigation("Catalog");
                });

            modelBuilder.Entity("Pharmacy.Core.Medicaments", b =>
                {
                    b.HasOne("Pharmacy.Core.Brend", "Brend")
                        .WithMany()
                        .HasForeignKey("BrendId");

                    b.HasOne("Pharmacy.Core.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("Pharmacy.Core.ProductLine", "ProductLine")
                        .WithMany()
                        .HasForeignKey("ProductLineId");

                    b.Navigation("Brend");

                    b.Navigation("Country");

                    b.Navigation("ProductLine");
                });

            modelBuilder.Entity("Pharmacy.Core.Order", b =>
                {
                    b.HasOne("Pharmacy.Core.OrderDetails", "details")
                        .WithMany()
                        .HasForeignKey("detailsId");

                    b.HasOne("Pharmacy.Core.User", "user")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("details");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Pharmacy.Core.OrderDetails", b =>
                {
                    b.HasOne("Pharmacy.Core.OrderAddress", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Pharmacy.Core.OrderItems", b =>
                {
                    b.HasOne("Pharmacy.Core.Medicaments", "medicaments")
                        .WithMany()
                        .HasForeignKey("MedicamentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pharmacy.Core.OrderDetails", null)
                        .WithMany("orderItems")
                        .HasForeignKey("OrderDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("medicaments");
                });

            modelBuilder.Entity("Pharmacy.Core.SubCategory", b =>
                {
                    b.HasOne("Pharmacy.Core.Category", "Category")
                        .WithMany("SubCategory")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Pharmacy.Core.SubCategoryMedicaments", b =>
                {
                    b.HasOne("Pharmacy.Core.Medicaments", "Medicaments")
                        .WithMany("SubCategories")
                        .HasForeignKey("MedicamentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pharmacy.Core.SubCategory", "SubCategory")
                        .WithMany("Medicaments")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicaments");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("Pharmacy.Core.Catalog", b =>
                {
                    b.Navigation("Category");
                });

            modelBuilder.Entity("Pharmacy.Core.Category", b =>
                {
                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("Pharmacy.Core.Medicaments", b =>
                {
                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("Pharmacy.Core.OrderDetails", b =>
                {
                    b.Navigation("orderItems");
                });

            modelBuilder.Entity("Pharmacy.Core.SubCategory", b =>
                {
                    b.Navigation("Medicaments");
                });
#pragma warning restore 612, 618
        }
    }
}
