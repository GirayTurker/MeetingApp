using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DBContext : DbContext
{
    public DBContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<AppUser> Users {get; set;}
}
