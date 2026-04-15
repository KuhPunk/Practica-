using Microsoft.EntityFrameworkCore;
using MovieCatalog.Data;
using MovieCatalog.Models;

namespace MovieCatalog.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Movies.Any())
            {
                return; // База данных уже содержит данные
            }

            var movies = new Movie[]
            {
                new Movie { Title = "Интерстеллар", Genre = "Научная фантастика", Year = 2014, Rating = 8.7 },
                new Movie { Title = "Начало", Genre = "Боевик/Фантастика", Year = 2010, Rating = 8.8 },
                new Movie { Title = "Темный рыцарь", Genre = "Боевик/Драма", Year = 2008, Rating = 9.0 },
                new Movie { Title = "Побег из Шоушенка", Genre = "Драма", Year = 1994, Rating = 9.3 },
                new Movie { Title = "Криминальное чтиво", Genre = "Криминал", Year = 1994, Rating = 8.9 },
                new Movie { Title = "Матрица", Genre = "Научная фантастика", Year = 1999, Rating = 8.7 },
                new Movie { Title = "Зеленая миля", Genre = "Драма/Фэнтези", Year = 1999, Rating = 8.6 },
                new Movie { Title = "Бойцовский клуб", Genre = "Драма", Year = 1999, Rating = 8.8 }
            };

            foreach (Movie m in movies)
            {
                context.Movies.Add(m);
            }
            context.SaveChanges();
        }
    }
}
