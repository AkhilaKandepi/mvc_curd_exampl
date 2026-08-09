using Microsoft.EntityFrameworkCore;
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
        public DbSet<Country> Tbl_country { get; set; }
        public DbSet<Person> Tbl_person { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

