﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core
{
    public static class PharmacyDbContextExtension
    {
        public static void Seed1(this ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<SubCategoryMedicaments>()
            .HasKey(bc => new { bc.MedicamentsId, bc.SubCategoryId });
            modelBuilder.Entity<SubCategoryMedicaments>()
                .HasOne(bc => bc.Medicaments)
                .WithMany(b => b.SubCategories)
                .HasForeignKey(bc => bc.MedicamentsId);
            modelBuilder.Entity<SubCategoryMedicaments>()
                .HasOne(bc => bc.SubCategory)
                .WithMany(c => c.Medicaments)
                .HasForeignKey(bc => bc.SubCategoryId);
        }
        /*public static void Seed1(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Medicaments>()
                        .HasMany<SubCategory>(s => s.SubCategory)
                        .WithMany(c => c.Medicaments)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("MedicamentRefId");
                            cs.MapRightKey("SubCategoryRefId");
                            cs.ToTable("SubCategoryMedicaments");
                        });
        modelBuilder.Entity<SubCategoryMedicaments>()
        .HasKey(bc => new { bc.MedicamentsId, bc.SubCategoryId });
            modelBuilder.Entity<SubCategoryMedicaments>()
                .HasOne(bc => bc.Medicaments)
                .WithMany(b => b.SubCategoryMedicaments)
                .HasForeignKey(bc => bc.MedicamentsId);
            modelBuilder.Entity<SubCategoryMedicaments>()
                .HasOne(bc => bc.SubCategory)
                .WithMany(c => c.SubCategoryMedicaments)
                .HasForeignKey(bc => bc.SubCategoryId);

        }*/

        public static void Seed(this ModelBuilder builder)
        {
            string ADMIN_ROLE_ID = Guid.NewGuid().ToString();
            string USER_ROLE_ID = Guid.NewGuid().ToString();
            

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = ADMIN_ROLE_ID,
                    Name = "Admin",
                    NormalizedName="ADMIN"
                },
                new IdentityRole
                {
                    Id = USER_ROLE_ID,
                    Name = "User",
                    NormalizedName = "USER"
                });

            string ADMIN_ID = Guid.NewGuid().ToString();
            string USER_ID = Guid.NewGuid().ToString();

            var admin = new User
            {
                Id = ADMIN_ID,
                UserName = "admin@pharmacy.com",
                Email = "admin@pharmacy.com",
                EmailConfirmed = true,
                NormalizedEmail = "admin@pharmacy.com".ToUpper(),
                NormalizedUserName = "admin@pharmacy.com".ToUpper()
            };
            var user = new User
            {
                Id = USER_ID,
                UserName = "user@pharmacy.com",
                Email = "user@pharmacy.com",
                EmailConfirmed = true,
                NormalizedEmail = "user@pharmacy.com".ToUpper(),
                NormalizedUserName = "user@pharmacy.com".ToUpper()
            };

            
               
            PasswordHasher<User> hasher = new PasswordHasher<User>();
            admin.PasswordHash = hasher.HashPassword(admin, "admin111");
            user.PasswordHash = hasher.HashPassword(user, "user111");


            builder.Entity<User>().HasData(admin, user);

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = ADMIN_ID,
                },
                new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = ADMIN_ID,
                },
                new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = USER_ID,
                });




            var catalog1 = new Catalog
            {
                Id = 1,
                Name = "Лікарські засоби",
                
            };
            var catalog2 = new Catalog
            {
                Id = 2,
                Name = "Краса та догляд",
            };
            builder.Entity<Catalog>().HasData(catalog1, catalog2);

            builder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Застуда і грип",
                },
                new Category
                {
                    Id = 2,
                    Name = "Серцево-судинна система",
                },
                new Category
                {
                    Id = 3,
                    Name = "Кровотворення та кров",
                }
                );

            var subCategory1 = new SubCategory
            {
                SubCategoryId = 1,
                Name = "Від кашлю",
            };
            builder.Entity<SubCategory>().HasData(subCategory1);
           


            var medicaments = new Medicaments
            {
                MedicamentsId = 1,
                Name = "Синупрет табл. в/о №50",
                Code = "4882",
                Dosage = "",
                Price = (float)125.62,
                ReleaseForm = "таблетки для внутрішнього застосування",
                Image = "https://i.apteka24.ua/products/8986bcef-7cf8-4894-854a-825e8f724920.jpeg",                
            };
            var SubCategoryMedicaments = new SubCategoryMedicaments
            {
                MedicamentsId = medicaments.MedicamentsId,
                SubCategoryId = subCategory1.SubCategoryId,
                Medicaments = null,
                SubCategory = null,              
            };
            //medicaments.SubCategories = new List<SubCategoryMedicaments> { SubCategoryMedicaments };
                builder.Entity<Medicaments>().HasData(medicaments);
            builder.Entity<SubCategoryMedicaments>().HasData(SubCategoryMedicaments);

        }
    }
}
