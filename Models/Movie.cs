﻿namespace Moviesapi.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string Title { get; set; }

        public int Year { get; set; }

        public double Rate { get; set; }
        [MaxLength (255)]
        public string Storeline { get; set; }

        public byte[] Poster { get; set; }
        public byte GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
