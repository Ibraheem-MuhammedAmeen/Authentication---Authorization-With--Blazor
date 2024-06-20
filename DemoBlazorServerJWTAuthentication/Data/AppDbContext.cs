using Microsoft.EntityFrameworkCore;
using DemoBlazorServerJWTAuthentication.Models;

namespace DemoBlazorServerJWTAuthentication.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }

        public DbSet<ApplicationUser> Users { get; set; }
    }
}
