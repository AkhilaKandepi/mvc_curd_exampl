using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class Newcodechanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_person_Tbl_country_CountryId",
                table: "Tbl_person");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_person_CountryId",
                table: "Tbl_person");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Tbl_person");

            migrationBuilder.AddColumn<Guid>(
                name: "CountryID",
                table: "Tbl_person",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_person_CountryID",
                table: "Tbl_person",
                column: "CountryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_person_Tbl_country_CountryID",
                table: "Tbl_person",
                column: "CountryID",
                principalTable: "Tbl_country",
                principalColumn: "Countyid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_person_Tbl_country_CountryID",
                table: "Tbl_person");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_person_CountryID",
                table: "Tbl_person");

            migrationBuilder.DropColumn(
                name: "CountryID",
                table: "Tbl_person");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Tbl_person",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
