using Microsoft.EntityFrameworkCore;

namespace DBOperationWithEFCore.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {
            
        }
    }
}
