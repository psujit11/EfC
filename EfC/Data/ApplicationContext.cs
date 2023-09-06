using EfC.Models;
using Microsoft.EntityFrameworkCore;

namespace EfC.Data
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) :base (options)
        {
            
        }
        public DbSet<Employees> Employees { get; set; }
    }
}
