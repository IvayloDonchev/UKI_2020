using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace CreateDatabase.Data
{
    using Models;
    public class QuestionsDbContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answers> Answers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(@"Server=DELL_IT\SQLEXPRESS; Database=QuestionsForTest; Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }

}
