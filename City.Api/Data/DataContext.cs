using City.Api.Core;
using Microsoft.EntityFrameworkCore;
namespace City.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<CityEntity> CityEntities { get; set; }



        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    //if (!options.IsConfigured)
        //    //{
        //    //    options.UseSqlServer("Server=(Localdb)\\MSSQLLocalDB;Database=CityApi-V2;Trusted_Connection=True;MultipleActiveResultSets=true");
        //    //}
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}


    }
}


        
    


 // 
