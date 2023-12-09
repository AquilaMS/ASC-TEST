using ASC_TEST.Models;
using Microsoft.EntityFrameworkCore;

namespace ASC_TEST.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
