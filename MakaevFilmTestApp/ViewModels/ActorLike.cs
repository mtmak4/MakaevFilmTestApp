using MakaevFilmTestApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MakaevFilmTestApp.ViewModels
{
    public class ActorLike
    {
        public int Id { get; set; }
        
        public int ActorId { get; set; }
        [NotMapped]
        public Actor Actor { get; set; }
        public string UserId { get; set; }
        public bool Like { get; set; }
    }
}
