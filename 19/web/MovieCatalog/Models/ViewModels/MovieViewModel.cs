using System.ComponentModel.DataAnnotations;

namespace MovieCatalog.Models.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название фильма обязательно")]
        [Display(Name = "Название")]
        [StringLength(100, MinimumLength = 1)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Жанр обязателен")]
        [Display(Name = "Жанр")]
        [StringLength(50)]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Год обязателен")]
        [Display(Name = "Год")]
        [Range(1888, 2100)]
        public int Year { get; set; }

        [Required(ErrorMessage = "Рейтинг обязателен")]
        [Display(Name = "Рейтинг")]
        [Range(1, 10)]
        public double Rating { get; set; }
    }
}
