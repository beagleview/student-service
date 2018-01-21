using Microsoft.EntityFrameworkCore;

namespace StdService.Models
{
    public class StdServiceContext : DbContext
    {
        public StdServiceContext(DbContextOptions<StdServiceContext> options) : base(options){

        }
        public DbSet<Student> Students {get; set;}
    }
}