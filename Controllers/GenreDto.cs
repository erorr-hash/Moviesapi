namespace Moviesapi.Controllers
{
    public class GenreDto
    {
        [MaxLength(100)]
        public String Name { get; set; }
    }
}