using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HalisElektronik.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class deneme2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MainId",
                table: "SocialMedia",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MainClass",
                columns: table => new
                {
                    MainId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainClass", x => x.MainId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedia_MainId",
                table: "SocialMedia",
                column: "MainId");

            migrationBuilder.CreateIndex(
                name: "IX_FeaturetteMain_MainId",
                table: "FeaturetteMain",
                column: "MainId");

            migrationBuilder.CreateIndex(
                name: "IX_ContainerMarketing_MainId",
                table: "ContainerMarketing",
                column: "MainId");

            migrationBuilder.CreateIndex(
                name: "IX_CarouselMain_MainId",
                table: "CarouselMain",
                column: "MainId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarouselMain_MainClass_MainId",
                table: "CarouselMain",
                column: "MainId",
                principalTable: "MainClass",
                principalColumn: "MainId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContainerMarketing_MainClass_MainId",
                table: "ContainerMarketing",
                column: "MainId",
                principalTable: "MainClass",
                principalColumn: "MainId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeaturetteMain_MainClass_MainId",
                table: "FeaturetteMain",
                column: "MainId",
                principalTable: "MainClass",
                principalColumn: "MainId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMedia_MainClass_MainId",
                table: "SocialMedia",
                column: "MainId",
                principalTable: "MainClass",
                principalColumn: "MainId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarouselMain_MainClass_MainId",
                table: "CarouselMain");

            migrationBuilder.DropForeignKey(
                name: "FK_ContainerMarketing_MainClass_MainId",
                table: "ContainerMarketing");

            migrationBuilder.DropForeignKey(
                name: "FK_FeaturetteMain_MainClass_MainId",
                table: "FeaturetteMain");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialMedia_MainClass_MainId",
                table: "SocialMedia");

            migrationBuilder.DropTable(
                name: "MainClass");

            migrationBuilder.DropIndex(
                name: "IX_SocialMedia_MainId",
                table: "SocialMedia");

            migrationBuilder.DropIndex(
                name: "IX_FeaturetteMain_MainId",
                table: "FeaturetteMain");

            migrationBuilder.DropIndex(
                name: "IX_ContainerMarketing_MainId",
                table: "ContainerMarketing");

            migrationBuilder.DropIndex(
                name: "IX_CarouselMain_MainId",
                table: "CarouselMain");

            migrationBuilder.DropColumn(
                name: "MainId",
                table: "SocialMedia");
        }
    }
}
