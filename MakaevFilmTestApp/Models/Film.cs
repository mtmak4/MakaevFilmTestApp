using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakaevFilmTestApp.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string FilmTitle { get; set; }
        public string FilmDescription { get; set; }
        public DateTime DateProduction { get; set; }
        public int Rate { get; set; }
    }
}
