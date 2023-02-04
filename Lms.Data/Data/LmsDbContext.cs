using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lms.Core.Entities;

namespace Lms.Data.Data
{
    public class LmsDataContext : DbContext
    {
        public LmsDataContext (DbContextOptions<LmsDataContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Games { get; set; } = default!;
        public DbSet<Tournament> Tournaments { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
            .HasOne(g => g.Tournament)
            .WithMany(t => t.Games)
            .HasForeignKey(g => g.TournamentId)
                        .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
