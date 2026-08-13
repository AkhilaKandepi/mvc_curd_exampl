using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entities.dbcontext
{
    public class CHILD_OF_DBCONTEXT : DbContext
    {
        public CHILD_OF_DBCONTEXT(DbContextOptions<CHILD_OF_DBCONTEXT> options) : base(options)
        {

        }
        public virtual DbSet<Country> Tbl_country { get; set; }
        public virtual DbSet<Person> Tbl_person { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().Property(temp => temp.BloodGroup).HasColumnName("bloodgroupname").HasColumnType("nvarchar(10)").HasDefaultValue("B+");
            //modelBuilder.Entity<Person>().HasCheckConstraint("checkperson", "len([PersonName])<10");
            modelBuilder.Entity<Person>().ToTable(t => t.HasCheckConstraint("con_personname", "LEN([PersonName]) BETWEEN 2 AND 10"));




        }

        public int sp_InsertPerson(Person person)
        {
            SqlParameter person_obj = new SqlParameter("@PersonID", person.PersonId);
            SqlParameter person_obj1 = new SqlParameter("@PersonName", person.PersonName);
            SqlParameter person_obj2 = new SqlParameter("@Email", person.PersonEmail);
            SqlParameter person_obj3 = new SqlParameter("@DateOfBirth", person.DateOfBirth);
            SqlParameter person_obj4 = new SqlParameter("@Gender", person.Gender);
            SqlParameter person_obj5 = new SqlParameter("@CountryID", person.CountryId);
            SqlParameter person_obj6 = new SqlParameter("@Address", person.Address);

            SqlParameter person_obj7 = new SqlParameter("@ReceiveNewsLetters",person.ReceiveNewsLetters);
            SqlParameter person_obj8 = new SqlParameter("Country", person.Country);
            SqlParameter person_obj9 = new SqlParameter(" @bloodgroupname", person.BloodGroup);



            List<SqlParameter> ListofSqlParamaters = new List<SqlParameter>();
            ListofSqlParamaters.Add(person_obj);
            ListofSqlParamaters.Add(person_obj1);
            ListofSqlParamaters.Add(person_obj2);
            ListofSqlParamaters.Add(person_obj3);
            ListofSqlParamaters.Add(person_obj4);
            ListofSqlParamaters.Add(person_obj5);
            ListofSqlParamaters.Add(person_obj6);
            ListofSqlParamaters.Add(person_obj7);
            ListofSqlParamaters.Add(person_obj8);
            ListofSqlParamaters.Add(person_obj9);
            return Database.ExecuteSqlRaw(
               "EXEC [dbo].[InsertPerson] @PersonID, @PersonName, @Email, @DateOfBirth, @Gender, @CountryID, @country, @Address, @ReceiveNewsLetters", "@bloodgroupname",ListofSqlParamaters);
        }




















        public async Task<List<Person>> Getallperson()
        {
            List<Person> getall= await Tbl_person.FromSqlRaw("Execute GetAllPersons").ToListAsync();

            return getall;
        }
    }
}

