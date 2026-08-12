using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class changedbloodgrouptypeinsert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BloodGroupType",
                table: "Tbl_person",
                newName: "bloodgroupname");

            migrationBuilder.AlterColumn<string>(
                name: "bloodgroupname",
                table: "Tbl_person",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: "B+",
                oldClrType: typeof(string),
                oldType: "varchar(10)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "bloodgroupname",
                table: "Tbl_person",
                newName: "BloodGroupType");

            migrationBuilder.AlterColumn<string>(
                name: "BloodGroupType",
                table: "Tbl_person",
                type: "varchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldDefaultValue: "B+");
        }
    }
}
