using Microsoft.EntityFrameworkCore.Migrations;

namespace WinFormsShop.Migrations
{
    public partial class AddParentcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "tblCategories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblCategories_ParentId",
                table: "tblCategories",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblCategories_tblCategories_ParentId",
                table: "tblCategories",
                column: "ParentId",
                principalTable: "tblCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblCategories_tblCategories_ParentId",
                table: "tblCategories");

            migrationBuilder.DropIndex(
                name: "IX_tblCategories_ParentId",
                table: "tblCategories");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "tblCategories");
        }
    }
}
