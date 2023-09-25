using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyReadingList.WebAPI.Models
{
    public class MyReadingApiContext : DbContext
    {
        public MyReadingApiContext(DbContextOptions<MyReadingApiContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>().HasKey(b => b.Id);
            base.OnModelCreating(builder);
        }

    }
}
