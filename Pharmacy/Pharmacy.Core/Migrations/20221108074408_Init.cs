using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharmacy.Core.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brend",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brend", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductLine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CatalogId = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Catalog_CatalogId",
                        column: x => x.CatalogId,
                        principalTable: "Catalog",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<float>(type: "real", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    TypeOfDelivery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Payment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_OrderAddress_AddressId",
                        column: x => x.AddressId,
                        principalTable: "OrderAddress",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Medicaments",
                columns: table => new
                {
                    MedicamentsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductLineId = table.Column<int>(type: "int", nullable: true),
                    BrendId = table.Column<int>(type: "int", nullable: true),
                    ReleaseForm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dosage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicaments", x => x.MedicamentsId);
                    table.ForeignKey(
                        name: "FK_Medicaments_Brend_BrendId",
                        column: x => x.BrendId,
                        principalTable: "Brend",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Medicaments_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Medicaments_ProductLine_ProductLineId",
                        column: x => x.ProductLineId,
                        principalTable: "ProductLine",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    SubCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.SubCategoryId);
                    table.ForeignKey(
                        name: "FK_SubCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Total = table.Column<float>(type: "real", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    detailsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_OrderDetails_detailsId",
                        column: x => x.detailsId,
                        principalTable: "OrderDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicamentsId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    OrderDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Medicaments_MedicamentsId",
                        column: x => x.MedicamentsId,
                        principalTable: "Medicaments",
                        principalColumn: "MedicamentsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_OrderDetails_OrderDetailsId",
                        column: x => x.OrderDetailsId,
                        principalTable: "OrderDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoryMedicaments",
                columns: table => new
                {
                    MedicamentsId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoryMedicaments", x => new { x.MedicamentsId, x.SubCategoryId });
                    table.ForeignKey(
                        name: "FK_SubCategoryMedicaments_Medicaments_MedicamentsId",
                        column: x => x.MedicamentsId,
                        principalTable: "Medicaments",
                        principalColumn: "MedicamentsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubCategoryMedicaments_SubCategory_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategory",
                        principalColumn: "SubCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b4949472-1f1e-4810-90af-ae61fa308e1b", "a71807a5-302e-4d51-8e78-ef3253e4865c", "User", "USER" },
                    { "ecde7c2d-7e5a-459e-b912-aabf22fb2cdd", "4036d256-d0b6-4783-8c5e-41c1e8ae71a7", "Manager", "MANAGER" },
                    { "fc056ad0-997b-4966-948d-d6a667444fc6", "68909fb2-12fb-4d8c-9892-4712aed16f20", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "34976306-79f9-48d6-96c1-283464e2e54e", 0, "c71c2fed-b6b4-41f3-b67e-d6f0fb639241", "user@pharmacy.com", true, null, null, false, null, "USER@PHARMACY.COM", "USER@PHARMACY.COM", "AQAAAAEAACcQAAAAEKYVSgnaGBb1QrodVATzn3IumrwavgkTOS0Qz38Y/LFbcz3C607wuefsEygq3AZgOg==", null, false, "248fee51-8610-4908-a5eb-c027ef350871", false, "user@pharmacy.com" },
                    { "7006e163-71c7-4ff3-8074-befac77edec3", 0, "38e55e01-0c19-439e-b172-5a35a2ff2303", "manager@pharmacy.com", true, null, null, false, null, "MANAGER@PHARMACY.COM", "MANAGER@PHARMACY.COM", "AQAAAAEAACcQAAAAECTGUOvpmP0RFASzILx4QJzcj3bCAsCQc4L9I4k/5YiQySv35wNlZ6A/rOJjol12rQ==", null, false, "3ac08b93-0451-407c-8716-746c2e23c1bf", false, "manager@pharmacy.com" },
                    { "eb882a65-da1d-4479-ad40-29c0ec243f1a", 0, "04d29e45-4478-4a91-a29f-2579a5a326a0", "admin@pharmacy.com", true, null, null, false, null, "ADMIN@PHARMACY.COM", "ADMIN@PHARMACY.COM", "AQAAAAEAACcQAAAAEOEQd9ukk1s1KLommr4Kxtz1jVrP7hBBEB+kSZTng+AWGtR5orcY3wZwaqaoyprUgQ==", null, false, "b4294965-e050-449d-94e0-7c5612f7fbc5", false, "admin@pharmacy.com" }
                });

            migrationBuilder.InsertData(
                table: "Catalog",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Лікарські засоби" },
                    { 2, "Краса та догляд" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CatalogId", "Image", "Name" },
                values: new object[,]
                {
                    { 1, null, null, "Застуда і грип" },
                    { 2, null, null, "Серцево-судинна система" },
                    { 3, null, null, "Кровотворення та кров" }
                });

            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "MedicamentsId", "BrendId", "Code", "CountryId", "Description", "Dosage", "Image", "Name", "Price", "ProductLineId", "ReleaseForm" },
                values: new object[] { 1, null, "4882", null, null, "", "C:\\Users\\Admin\\Documents\\GitHub\\Pharmacy_online\\Pharmacy\\Pharmacy.UI\\wwwroot\\img\\catalogue\\jonas-jaeken-VyIj995OXNQ-unsplash.jpg", "Синупрет табл. в/о №50", 125.62f, null, "таблетки для внутрішнього застосування" });

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "SubCategoryId", "CategoryId", "Name" },
                values: new object[] { 1, null, "Від кашлю" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "b4949472-1f1e-4810-90af-ae61fa308e1b", "34976306-79f9-48d6-96c1-283464e2e54e" },
                    { "ecde7c2d-7e5a-459e-b912-aabf22fb2cdd", "7006e163-71c7-4ff3-8074-befac77edec3" },
                    { "b4949472-1f1e-4810-90af-ae61fa308e1b", "eb882a65-da1d-4479-ad40-29c0ec243f1a" },
                    { "fc056ad0-997b-4966-948d-d6a667444fc6", "eb882a65-da1d-4479-ad40-29c0ec243f1a" }
                });

            migrationBuilder.InsertData(
                table: "SubCategoryMedicaments",
                columns: new[] { "MedicamentsId", "SubCategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Category_CatalogId",
                table: "Category",
                column: "CatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicaments_BrendId",
                table: "Medicaments",
                column: "BrendId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicaments_CountryId",
                table: "Medicaments",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicaments_ProductLineId",
                table: "Medicaments",
                column: "ProductLineId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_detailsId",
                table: "Order",
                column: "detailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_userId",
                table: "Order",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_AddressId",
                table: "OrderDetails",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_MedicamentsId",
                table: "OrderItems",
                column: "MedicamentsId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderDetailsId",
                table: "OrderItems",
                column: "OrderDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryId",
                table: "SubCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryMedicaments_SubCategoryId",
                table: "SubCategoryMedicaments",
                column: "SubCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "SubCategoryMedicaments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Medicaments");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropTable(
                name: "OrderAddress");

            migrationBuilder.DropTable(
                name: "Brend");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "ProductLine");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Catalog");
        }
    }
}
