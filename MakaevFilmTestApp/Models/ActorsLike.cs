using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakaevFilmTestApp.Models
{
    public class ActorsLike
    {
        public int Id { get; set; }
        public int ActorId { get; set; }
        public string UserId { get; set; }
    }
}
