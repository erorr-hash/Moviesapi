﻿namespace Moviesapi.Dtos
{
    public class MovieDto
    {
        [MaxLength(255)]
        public string Title { get; set; }

        public int Year { get; set; }

        public double Rate { get; set; }
        [MaxLength(255)]
        public string Storeline { get; set; }


        public IFormFile Poster { get; set; }
        public byte GenreId { get; set; }
    }
}
