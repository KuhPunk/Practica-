using System.ComponentModel.DataAnnotations;

namespace MovieCatalog.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название фильма обязательно")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Длина названия должна быть от 1 до 100 символов")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Жанр обязателен")]
        [StringLength(50, ErrorMessage = "Длина жанра не должна превышать 50 символов")]
        public string Genre { get; set; }

        [Range(1888, 2100, ErrorMessage = "Год должен быть в диапазоне от 1888 до 2100")]
        public int Year { get; set; }

        [Range(1, 10, ErrorMessage = "Рейтинг должен быть от 1 до 10")]
        public double Rating { get; set; }
    }
}
