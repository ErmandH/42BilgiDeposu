using Ecole42Entity.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecole42Entity.MainContext
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProjectFunction> ProjectFunctions { get; set; }
        public DbSet<ProjectUsefulLink> ProjectUsefulLinks { get; set; }
        public DbSet<UsefulLink> UsefulLinks { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerQuestion> AnswerQuestions { get; set; }
    }
}
