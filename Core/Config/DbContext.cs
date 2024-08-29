using Microsoft.EntityFrameworkCore;
using TodoApi.Core.Domain.Entities;

namespace TodoApi.Core.Config
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}