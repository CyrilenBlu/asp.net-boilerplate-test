using Abp.EntityFrameworkCore;
using blu.MyProject.Domain;
using Microsoft.EntityFrameworkCore;

namespace blu.MyProject.EntityFrameworkCore
{
    public class MyProjectDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...
        public DbSet<Person> People { get; set; }

        public MyProjectDbContext(DbContextOptions<MyProjectDbContext> options) 
            : base(options)
        {

        }
    }
}
