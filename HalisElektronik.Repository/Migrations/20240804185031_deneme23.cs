using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HalisElektronik.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class deneme23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8"),
                    Discriminator = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8"),
                    Discriminator = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8"),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "BlogsTag",
                columns: table => new
                {
                    BlogsTagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BlogsTagName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogsTag", x => x.BlogsTagId);
                })
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8"),
                    CategoryDescription = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                })
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    EntityType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "Information",
                columns: table => new
                {
                    InfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HeaderTitle = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    HeaderDescription = table.Column<string>(type: "varchar(2500)", maxLength: 2500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    InfoTitle = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    InfoBody = table.Column<string>(type: "varchar(2500)", maxLength: 2500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    InfoMapsUrl = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Information", x => x.InfoId);
                })
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
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
                })
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
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
                })
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
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
                })
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8"),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
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
                })
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8"),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
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
                })
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<double>(type: "double", nullable: true),
                    IsStock = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Date_Of_Adjustment = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId");
                })
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    BlogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BlogTitle = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    BlogAltTitle = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    BlogDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    BlogsTagId = table.Column<int>(type: "int", nullable: true),
                    Date_Time = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.BlogId);
                    table.ForeignKey(
                        name: "FK_Blog_BlogsTag_BlogsTagId",
                        column: x => x.BlogsTagId,
                        principalTable: "BlogsTag",
                        principalColumn: "BlogsTagId");
                    table.ForeignKey(
                        name: "FK_Blog_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "CarouselMain",
                columns: table => new
                {
                    CarouselMainId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    BtnTitle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    BtnUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    ImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarouselMain", x => x.CarouselMainId);
                    table.ForeignKey(
                        name: "FK_CarouselMain_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "ContainerMarketing",
                columns: table => new
                {
                    ContainerMarketingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    ImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContainerMarketing", x => x.ContainerMarketingId);
                    table.ForeignKey(
                        name: "FK_ContainerMarketing_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "FeaturetteMain",
                columns: table => new
                {
                    FeaturetteMainId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    ImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeaturetteMain", x => x.FeaturetteMainId);
                    table.ForeignKey(
                        name: "FK_FeaturetteMain_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "SocialMedia",
                columns: table => new
                {
                    SocialMediaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8"),
                    Link = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8"),
                    ImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedia", x => x.SocialMediaId);
                    table.ForeignKey(
                        name: "FK_SocialMedia_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImage_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blog_BlogsTagId",
                table: "Blog",
                column: "BlogsTagId");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_ImageId",
                table: "Blog",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_CarouselMain_ImageId",
                table: "CarouselMain",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ContainerMarketing_ImageId",
                table: "ContainerMarketing",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_FeaturetteMain_ImageId",
                table: "FeaturetteMain",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductId",
                table: "ProductImage",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedia_ImageId",
                table: "SocialMedia",
                column: "ImageId");
        }

        /// <inheritdoc />
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
                name: "Blog");

            migrationBuilder.DropTable(
                name: "CarouselMain");

            migrationBuilder.DropTable(
                name: "ContainerMarketing");

            migrationBuilder.DropTable(
                name: "FeaturetteMain");

            migrationBuilder.DropTable(
                name: "Information");

            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.DropTable(
                name: "SocialMedia");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BlogsTag");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
