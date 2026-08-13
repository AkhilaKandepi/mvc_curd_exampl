using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class alter_storeprocedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp_insertperson = @"
           alter PROCEDURE[dbo].[InsertPerson]
            (
            @PersonID uniqueidentifier,
             
             @PersonName nvarchar(40), 
             @Email nvarchar(50),
             @DateOfBirth datetime2(7), 
             @Gender varchar(10), 
             @CountryID uniqueidentifier, 
             @Country nvarchar(100) ,
             @Address nvarchar(1000), 
             @ReceiveNewsLetters bit,
             @bloodgroupname nvarchar(10)
            )
            AS 
            BEGIN
              INSERT INTO[dbo].Tbl_person
              (
                  PersonID, 
                  PersonName, 
                  PersonEmail, 
                  DateOfBirth, 
                  Gender, 
                  CountryID, 
                  Country, 
                  Address, 
                  ReceiveNewsLetters,
                  bloodgroupname
              ) 
            VALUES
            (

            @PersonID,
            @PersonName, 
            @Email, 
            @DateOfBirth,
            @Gender, 
            @CountryID, 
            @Country, 
            @Address, 
            @ReceiveNewsLetters,
            @bloodgroupname

             );

             END";
            migrationBuilder.Sql(sp_insertperson);


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Drop procedure [dbo].[InsertPerson]");

        }
    }
}
