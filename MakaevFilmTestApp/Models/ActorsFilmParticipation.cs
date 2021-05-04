using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakaevFilmTestApp.Models
{
    public class ActorsFilmParticipation
    {
        public int Id { get; set; }
        public int ActorId { get; set; }
        public int FilmId { get; set; }
    }
}
