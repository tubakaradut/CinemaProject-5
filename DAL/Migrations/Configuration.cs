namespace DAL.Migrations
{
    using Core.Enum;
    using DAL.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Contextt.ProjeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DAL.Contextt.ProjeContext context)
        {
            //Kategori ekleme

            List<Category> categories = new List<Category>()
            {
                new Category{CategoryName="Bilim Kurgu"},
                new Category{CategoryName="Aksiyon"},
                new Category{CategoryName="Romantik Komedi"},
                new Category{CategoryName="Korku"},
                new Category{CategoryName="Drama"},
                new Category{CategoryName="Gerilim"},
                new Category{CategoryName="Macera"},
                new Category{CategoryName="Suç"},
                new Category{CategoryName="Fantastik"},
                new Category{CategoryName="Sanat"},

            };

            if (!context.Categories.Any())
            {
                foreach (var category in categories)
                {
                    context.Categories.Add(category);
                    context.SaveChanges();
                }

            }

            //film ekleme
            List<Movie> movies = new List<Movie>()
            {
                new Movie
                {MovieName="Ucuz Roman",
                 Description="The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemp",
                 Duration=75},
                //suç,aksiyon

                new Movie{MovieName="Esaretin Bedeli",Description="Esaretin Bedeli, Frank Darabont'un senaryosunu yazdığı ve yönettiği, başrollerinde Tim Robbins ve Morgan Freeman'ın yer aldığı 1994 yapımı Amerikan dram filmidir",Duration=190},
                //dram
                 new Movie{MovieName="Fakat Müzeyyen Bu Derin bir Tutku",Description="ask,tutku filmidir",Duration=100},
                //dram

            };

            if (!context.Movies.Any())
            {
                foreach (var movie in movies)
                {
                    context.Movies.Add(movie);
                    context.SaveChanges();
                }
            }

            //film-kategori ekleme

            List<MovieCategory> movieCategories = new List<MovieCategory>()
            {
                new MovieCategory{MovieId=1,CategoryId=2},
                new MovieCategory{MovieId=1,CategoryId=8},
                new MovieCategory{MovieId=2,CategoryId=5},
              
            };
            if (!context.MovieCategories.Any())
            {
                foreach (var movieCategory in movieCategories)
                {
                    context.MovieCategories.Add(movieCategory);
                    context.SaveChanges();
                }

            }

            //Salon Ekleme
            List<Saloon> saloons = new List<Saloon>()
            {
                new Saloon{SaloonName="A",Capacity=50},
                new Saloon{SaloonName="B",Capacity=70},
                new Saloon{SaloonName="C",Capacity=40},
                new Saloon{SaloonName="D",Capacity=80},
                new Saloon{SaloonName="E",Capacity=20}
            };

            if (!context.Saloons.Any())
            {
                foreach (var saloon in saloons)
                {
                    context.Saloons.Add(saloon);
                    context.SaveChanges();
                }

            };

            //Sessions seans ekleme tekrar bakılacak

            List<Session> sessions = new List<Session>()
            {
                new Session{Duration="17:00"},
                new Session{Duration="20:00"},
                new Session{Duration="22:00"},

            };

            if (!context.Sessions.Any())
            {
                foreach (var session in sessions)
                {
                    context.Sessions.Add(session);
                    context.SaveChanges();
                }

            }

            //hafta ekleme

            List<Week> weeks = new List<Week>()
            {
                new Week{WeekName="1.Hafta",FirstDay=DateTime.Now,LastDay=DateTime.Now.AddDays(14)},
                new Week{WeekName="2.Hafta",FirstDay=DateTime.Now.AddDays(14),LastDay=DateTime.Now.AddDays(28)},
               
            };

            if (!context.Weeks.Any())
            {
                foreach (var week in weeks)
                {
                    context.Weeks.Add(week);
                    context.SaveChanges();
                }

            }

            //gösterim ekleme

            List<Theater> theaters = new List<Theater>()
            {
                new Theater{MovieId=1,SessionId=1,SaloonId=1,WeekId=1},
                new Theater{MovieId=2,SessionId=2,SaloonId=2,WeekId=2},
              
            };


            if (!context.Theaters.Any())
            {
                foreach (var theater in theaters)
                {
                    context.Theaters.Add(theater);
                    context.SaveChanges();
                }
            }

            //AppUser
            List<AppUser> appUsers = new List<AppUser>()
            {
                new AppUser{Firstname="Tuba",Lastname="Buğday",Username="tubik",Email="karadut.tuba@gmail.com",Address=null,Password="1234"/*,ActivationCode=Guid.NewGuid(),IsActive=true*/,Role=Core.Enum.AppUserRole.Admin,CreatedDate=DateTime.Now,DataStatus=DataStatus.Active}
            };

            if (!context.AppUsers.Any(x=>/*x.IsActive &&*/ x.Role == AppUserRole.Admin))
            {
                foreach (var appUser in appUsers)
                {
                    context.AppUsers.Add(appUser);
                    context.SaveChanges();
                }

            }

        }
    }
}

