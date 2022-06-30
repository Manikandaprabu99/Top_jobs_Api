using Microsoft.EntityFrameworkCore;
using PostJob.Api.Models.Entities;

namespace PostJob.Api.Data
{
    public class ApiDbContext : DbContext

    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ApiDbContext(DbContextOptions options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
        }


        public DbSet<Post> Posts{ get; set; }
        public DbSet<User> UserDetails { get; set; }
    }
}
