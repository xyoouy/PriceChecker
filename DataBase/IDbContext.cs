using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataBase;

public interface IDbContext
{
    DbSet<Subscription> Subscriptions { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}