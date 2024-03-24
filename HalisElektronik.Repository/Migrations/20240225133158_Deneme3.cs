using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HalisElektronik.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Deneme3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "MainId",
                table: "FeaturetteMain",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MainId",
                table: "ContainerMarketing",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MainId",
                table: "CarouselMain",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CarouselMain_MainClass_MainId",
                table: "CarouselMain",
                column: "MainId",
                principalTable: "MainClass",
                principalColumn: "MainId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContainerMarketing_MainClass_MainId",
                table: "ContainerMarketing",
                column: "MainId",
                principalTable: "MainClass",
                principalColumn: "MainId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeaturetteMain_MainClass_MainId",
                table: "FeaturetteMain",
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

            migrationBuilder.AlterColumn<int>(
                name: "MainId",
                table: "FeaturetteMain",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MainId",
                table: "ContainerMarketing",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MainId",
                table: "CarouselMain",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
        }
    }
}
