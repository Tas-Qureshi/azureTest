using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
    {
    }//CUPT RAID
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//ENIAC SUCK
   {//ENIAC MORE LIKE SHITTIAC
       var configuration = new ConfigurationBuilder().AddUserSecrets<Program>().Build();//MFJFGJFJFJFJNFJISAJFLKASJDFKLSDKLFJKSDLFJKLDS
       optionsBuilder.UseSqlServer(configuration.GetSection("ConnectionStrings:DefaultConnection").Value);
   }

    public DbSet<Animal> Animals { get; set; } = default!;
 
}




