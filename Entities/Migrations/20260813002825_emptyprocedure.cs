using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class emptyprocedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string data = "CREATE PROCEDURE GetAllPersons AS BEGIN SELECT* FROM Tbl_person END";
            migrationBuilder.Sql(data);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string data = "DROP procedure GetAllPersons";
            migrationBuilder.Sql(data);

        }
    }
}
