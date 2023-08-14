using Microsoft.EntityFrameworkCore;

namespace DataBase;

public class DbInitializer
{
    public static void Initialize(DbContext context)
    {
        context.Database.EnsureCreated();
    }
}