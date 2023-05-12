﻿using Microsoft.EntityFrameworkCore;

namespace ConferencePlanner.GraphQL.Data
{
    public class ApplicationDbContext : DbContext
    {
        private IConfiguration Configuration { get; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {
            this.Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(this.Configuration.GetConnectionString("ConferencePlanner"));
        }

        public DbSet<Speaker> Speakers { get; set; }
    }
}