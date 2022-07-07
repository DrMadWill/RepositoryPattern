using Microsoft.EntityFrameworkCore.Migrations;

namespace Student.DataAccess.Migrations
{
    public partial class AddColumnCodeToTableFamily : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Families",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Families_Code",
                table: "Families",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Families_Code",
                table: "Families");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Families");
        }
    }
}
