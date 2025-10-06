// Data/AppDbContext.cs
using DBConnectionG3.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DBConnectionG3.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Event> Events => Set<Event>();
}
