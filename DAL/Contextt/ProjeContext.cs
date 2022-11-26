using DAL.Entities;
using DAL.Map;
using System.Data.Entity;

namespace DAL.Contextt
{
    public class ProjeContext : DbContext
    {
        public ProjeContext()
        {
            /*  Database.Connection.ConnectionString = "server=DESKTOP-PAHPBA7;Database=MovieDB;uid=sa;pwd=123456";/* */

            Database.Connection.ConnectionString = "server=DESKTOP-PAHPBA7;database=MovieDB;Trusted_Connection=true;";
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Saloon> Saloons { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Week> Weeks { get; set; }
        public DbSet<MovieCategory> MovieCategories { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieCategory>().HasKey(x => new
            {
                x.MovieId,
                x.CategoryId
            });

            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new MovieMap());
            modelBuilder.Configurations.Add(new WeekMap());
            modelBuilder.Configurations.Add(new SaloonMap());
            modelBuilder.Configurations.Add(new SessionMap());
            modelBuilder.Configurations.Add(new AppUserMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
