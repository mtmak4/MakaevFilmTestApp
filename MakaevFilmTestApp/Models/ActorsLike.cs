using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MakaevFilmTestApp.Models
{
    public class ActorsLike
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ActorFK")]
        public int ActorId { get; set; }
        public string UserId { get; set; }
    }
}
