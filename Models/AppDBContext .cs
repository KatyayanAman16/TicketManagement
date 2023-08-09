using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TicketManagementSystem.Models;

namespace TicketManagementSystem.Models
{
    public class AppDBContext : IdentityDbContext
    {
        private readonly DbContextOptions _options;

        public AppDBContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<TicketManagementSystem.Models.Register>? Register { get; set; }

        public DbSet<TicketManagementSystem.Models.Login>? Login { get; set; }
    }
}
