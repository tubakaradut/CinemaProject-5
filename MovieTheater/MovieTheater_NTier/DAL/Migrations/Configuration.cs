namespace DAL.Migrations
{
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
                new Category{Id=1,CategoryName="Bilim Kurgu"},
                new Category{Id=2,CategoryName="Aksiyon"},
                new Category{Id=3,CategoryName="Romantik Komedi"},
                new Category{Id=4,CategoryName="Korku"},
                new Category{Id=5,CategoryName="Drama"},
                new Category{Id=6,CategoryName="Gerilim"},
                new Category{Id=7,CategoryName="Macera"},
                new Category{Id=8,CategoryName="Suç"},
                new Category{Id=9,CategoryName="Fantastik"},
                new Category{Id=10,CategoryName="Sanat"},

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
                new Movie{Id=1,MovieName="Ucuz Roman",Description="The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemp",Duraction=75},
                //suç,aksiyon

                new Movie{Id=2,MovieName="Esaretin Bedeli",Description="Esaretin Bedeli, Frank Darabont'un senaryosunu yazdığı ve yönettiği, başrollerinde Tim Robbins ve Morgan Freeman'ın yer aldığı 1994 yapımı Amerikan dram filmidir",Duraction=190},
                //dram

                new Movie{Id=3,MovieName="Parazit",Description="Parazit, yönetmenliği ve senaristliği Bong Joon-ho tarafından yapılan 2019 çıkışlı Güney Kore kara komedi, gerilim filmidir. Filmin senaryosu yönetmen Bong Joon-ho ve Han Jin-won ile birlikte yazılmıştır. Başlıca oyuncuları Song Kang-ho, Lee Sun-kyun, Cho Yeo-jeong, Choi Woo-shik ve Park So-dam'dır.",Duraction=180},
                //gerilim,dram

                new Movie{Id=4,MovieName="Uzaydan Gelen Fırtına",Description="Dünyadaki iklim değişikliği, insan ırkını tehdit eder hale gelince ülkeler bir araya gelerek Dutch Boy adı verilen bir iklim kontrol sistemi oluşturmuştur. Dünyanın her yerini saran uydulardan oluşan bu sistem doğal afetleri önleme ve hava durumunu kontrol etme görevini 2 yıl başarıyla sürdürdükten sonra yaşanan teknik bir arıza, her şeyi alt üst eder. Dünyanın bir manyetik fırtına sonucunda yok olmasını önlemek için birilerinin uzaya giderek uydulardaki sorunu çözmesi gerekecektir.",Duraction=109}
                //bilimkurgu
               

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
                new MovieCategory{MovieId=3,CategoryId=5},
                new MovieCategory{MovieId=3,CategoryId=6},
                new MovieCategory{MovieId=4,CategoryId=1},
                new MovieCategory{MovieId=4,CategoryId=2}

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
                new Saloon{Id=1,SaloonName="A",Capacity=50},
                new Saloon{Id=2,SaloonName="B",Capacity=70},
                new Saloon{Id=3,SaloonName="C",Capacity=40},
                new Saloon{Id=4,SaloonName="D",Capacity=80},
                new Saloon{Id=5,SaloonName="E",Capacity=20}
            };

            if (!context.Saloons.Any())
            {
                foreach (var saloon in saloons)
                {
                    context.Saloons.Add(saloon);
                    context.SaveChanges();
                }

            }

            //Sessions seans ekleme tekrar bakılacak

            List<Session> sessions = new List<Session>()
            {
                new Session{Id=1,Duraction=DateTime.Now.AddHours(2)},
                new Session{Id=2,Duraction=DateTime.Now.AddHours(4)},
                new Session{Id=3,Duraction=DateTime.Now.AddHours(6)}

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

            //List<Week> weeks = new List<Week>()
            //{
            //    new Week{Id=1,FirstDay=DateTime.Now,LastDay=DateTime.Now.AddDays(14)},
            //    new Week{Id=2,FirstDay=DateTime.Now.AddDays(1),LastDay=DateTime.Now.AddDays(15)},
            //    new Week{Id=3,FirstDay=DateTime.Now.AddDays(2),LastDay=DateTime.Now.AddDays(16)},
            //    new Week{Id=4,FirstDay=DateTime.Now.AddDays(3),LastDay=DateTime.Now.AddDays(17)},
            //    new Week{Id=5,FirstDay=DateTime.Now.AddDays(4),LastDay=DateTime.Now.AddDays(18)},

            //};

            //if (!context.Weeks.Any())
            //{
            //    foreach (var week in weeks)
            //    {
            //        context.Weeks.Add(week);
            //        context.SaveChanges();
            //    }

            //}

            //gösterim ekleme

            //List<Theater> theaters = new List<Theater>()
            //{
            //    new Theater{MovieId=1,SessionId=1,SalonId=1,WeekId=1},
            //    new Theater{MovieId=2,SessionId=2,SalonId=2,WeekId=2},
            //    new Theater{MovieId=3,SessionId=3,SalonId=3,WeekId=3},
            //    new Theater{MovieId=4,SessionId=1,SalonId=4,WeekId=4},

            //    new Theater{MovieId=1,SessionId=2,SalonId=5,WeekId=5},
            //    new Theater{MovieId=2,SessionId=1,SalonId=4,WeekId=2},
            //    new Theater{MovieId=3,SessionId=3,SalonId=2,WeekId=4},
            //    new Theater{MovieId=4,SessionId=2,SalonId=1,WeekId=1}
            //};


            //if (!context.Theaters.Any())
            //{
            //    foreach (var theater in theaters)
            //    {
            //        context.Theaters.Add(theater);
            //        context.SaveChanges();
            //    }

            //}

        }
    }
}
