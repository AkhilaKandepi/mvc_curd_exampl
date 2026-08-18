using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class applayconstrainsts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tbl_person_CountryId",
                table: "Tbl_person",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_person_Tbl_country_CountryId",
                table: "Tbl_person",
                column: "CountryId",
                principalTable: "Tbl_country",
                principalColumn: "Countyid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_person_Tbl_country_CountryId",
                table: "Tbl_person");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_person_CountryId",
                table: "Tbl_person");
        }
    }
}
