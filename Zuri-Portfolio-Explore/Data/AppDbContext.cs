using Microsoft.EntityFrameworkCore;

namespace Zuri_Portfolio_Explore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {

        }

    }
}
