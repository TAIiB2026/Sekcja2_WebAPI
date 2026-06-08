using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
    public class PeopleContext : DbContext
    {
        public DbSet<PersonEntity> PeopleDbSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LAB01;Integrated Security=True;Trust Server Certificate=True"));
        }
    }
}
