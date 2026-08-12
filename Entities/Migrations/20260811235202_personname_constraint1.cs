using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class personname_constraint1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "con_personname",
                table: "Tbl_person");

            migrationBuilder.AddCheckConstraint(
                name: "con_personname",
                table: "Tbl_person",
                sql: "LEN([PersonName]) BETWEEN 2 AND 10");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "con_personname",
                table: "Tbl_person");

            migrationBuilder.AddCheckConstraint(
                name: "con_personname",
                table: "Tbl_person",
                sql: "LEN([PersonName]) BETWEEN 0 AND 10");
        }
    }
}
