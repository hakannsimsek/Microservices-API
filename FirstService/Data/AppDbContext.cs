﻿using FirstService.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Platform> Platforms { get; set; }
    }
}
