HEAD
﻿// Data/AppDbContext.cs
using DBConnectionG3.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DBConnectionG3.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Event> Events => Set<Event>();
=======
﻿using DBConnectionG3.Models;
using Microsoft.EntityFrameworkCore;

namespace DBConnectionG3.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
       
        public DbSet<Guest> Guests => Set<Guest>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>(g =>
            {
                g.HasKey(x => x.Id);
                g.Property(x => x.FullName).IsRequired().HasMaxLength(200);
                g.Property(x => x.Confirmed).IsRequired();
            });
        }
    }
DBConnectionG3/guest
}
