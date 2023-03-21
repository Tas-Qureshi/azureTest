using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
       var configuration = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
       optionsBuilder.UseSqlServer(configuration.GetSection("ConnectionStrings:DefaultConnection").Value);
   }

    public DbSet<Animal> Animals { get; set; } = default!;
 
}




