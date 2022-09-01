using DevPace.CORE.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CORE.DAL.Context
{
    public class DevPaceContext : DbContext
    {
        public DevPaceContext() { }

        public DevPaceContext(DbContextOptions<DevPaceContext> optionsBuilder) 
            :base(optionsBuilder)
        {

        }

        public virtual DbSet<Customer> Customer { get; set; }
    }
}
