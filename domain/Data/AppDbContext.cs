using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Agent> Agents { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
}