using GraphQLPoc.Api.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLPoc.Api.Infrastructure.Persistence.Contexts
{
    public class PocDbContext : DbContext
    {
        public PocDbContext(DbContextOptions<PocDbContext> options) : base(options)
        {
        }

        public DbSet<Club> Clubs { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Ground> Grounds { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}