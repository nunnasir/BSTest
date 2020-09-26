using BSTest.Framework.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSTest.Framework.Context
{
    public class BsTestContext : DbContext
    {
        private string _conncetionString;
        private string _migrationAssemblyName;

        public BsTestContext(string connectionString, string migrationAssemblyName)
        {
            _conncetionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _conncetionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }
            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Post>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Post);

            base.OnModelCreating(builder);
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
