using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.MySQL
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
        .UseMySql(@"Server=localhost;database=ef;uid=root;pwd=EaseSource;");
    }
    public class Blog
    {
        public int BlogId { get; set; }
        public string String { get; set; }
        public DateTime DateTime { get; set; }

    }
}
