using Microsoft.EntityFrameworkCore;
using PromartServices.Api.Customer.Model;

namespace PromartServices.Api.Customer.Persistence
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Client> Customer { get; set; }
    }
}
