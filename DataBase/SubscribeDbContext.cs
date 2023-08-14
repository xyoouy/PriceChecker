using DataBase.Configurations;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataBase;

public class SubscribeDbContext : DbContext, IDbContext 
{
    public DbSet<Subscription> Subscriptions { get; set; }
    
    public SubscribeDbContext(DbContextOptions<SubscribeDbContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new SubscriptionConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}