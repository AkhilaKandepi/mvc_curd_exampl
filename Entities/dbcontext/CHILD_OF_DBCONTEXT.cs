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
    }
}

