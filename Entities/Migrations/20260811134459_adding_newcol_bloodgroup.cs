using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class adding_newcol_bloodgroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BloodGroup",
                table: "Tbl_person",
                newName: "BloodGroupType");

            migrationBuilder.AlterColumn<string>(
                name: "BloodGroupType",
                table: "Tbl_person",
                type: "varchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BloodGroupType",
                table: "Tbl_person",
                newName: "BloodGroup");

            migrationBuilder.AlterColumn<string>(
                name: "BloodGroup",
                table: "Tbl_person",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)");
        }
    }
}
