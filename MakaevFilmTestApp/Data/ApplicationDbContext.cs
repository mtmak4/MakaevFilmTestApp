using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MakaevFilmTestApp.Models;
using MakaevFilmTestApp.ViewModels;

namespace MakaevFilmTestApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MakaevFilmTestApp.Models.Film> Films { get; set; }
       
        public DbSet<MakaevFilmTestApp.Models.Actor> Actors { get; set; }
       
        public DbSet<MakaevFilmTestApp.ViewModels.ActorLike> ActorLike { get; set; }
       
        public DbSet<MakaevFilmTestApp.Models.ActorsFilmParticipation> ActorsFilmParticipation { get; set; }
       


    }
}
