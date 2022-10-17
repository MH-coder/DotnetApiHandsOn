using IssueTrackingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace IssueTrackingApi.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
