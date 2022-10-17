using IssueTrackingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace IssueTrackingApi.Data
{
    public class IssueDbContext : DbContext
    {
        public IssueDbContext(DbContextOptions<IssueDbContext> options)
            : base(options)
        {
        }

        public DbSet<Issue> Issues { get; set; }
    }
}
