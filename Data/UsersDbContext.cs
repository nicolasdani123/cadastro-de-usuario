using Microsoft.EntityFrameworkCore;
using WebApplication1.Dto;

namespace WebApplication1.Data
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options) { }

        
        DbSet<User> users { get; set; }
    }
}