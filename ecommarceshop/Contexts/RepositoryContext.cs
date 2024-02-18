using ecommarceshop.Models;
using Microsoft.EntityFrameworkCore;
using ecommarceshop.Models;

namespace ecommarceshop.Contexts
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }
        public DbSet<Register> Users { get; set; }


    }
}