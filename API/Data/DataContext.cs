using API.Entities;
using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Rider> Riders { get; set; }
    public DbSet<Bike> Bikes { get; set; }
    public DbSet<AppUser> Users { get; set; }

    public DbSet<RiderBikeAssociation> RiderBikeAssociations { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}