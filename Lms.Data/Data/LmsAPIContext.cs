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

        public DbSet<Tournament> Tournament { get; set; } = default!;

        public DbSet<Game> Game { get; set; } = default!;
    }
}
