using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Moviesapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private List<string> _allowedExtenstions = new List<string> { ".jpg",".png"};
        private long _maxAllowedPosterSize = 5242880;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm]MovieDto dto)
        {
            if(!_allowedExtenstions.Contains(Path.GetExtension(dto.Poster.FileName.ToLower()))) 
                return BadRequest("only jpg and png images are allowed!");

            if (dto.Poster.Length > _maxAllowedPosterSize)
                return BadRequest("max allowed size is 5MB!");

            var isValidGenre = await _context.Genres.AnyAsync(g => g.Id == dto.GenreId);
            if (!isValidGenre)
            {
                return BadRequest("invalid genre id!");
            }
            bvxbvx
            using var dataStream = new MemoryStream();
            await dto.Poster.CopyToAsync(dataStream);
            var movie = new Movie()
            {
                GenreId = dto.GenreId,
                Title = dto.Title,
                Poster = dataStream.ToArray(),
                Rate = dto.Rate,
                Storeline = dto.Storeline,
                Year = dto.Year,
            };
            await _context.AddAsync(movie);
            _context.SaveChangesAsync();
            return (Ok(movie));
            

        }
    }
}
