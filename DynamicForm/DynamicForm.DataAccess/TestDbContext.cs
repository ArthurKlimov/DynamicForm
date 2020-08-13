using DynamicForm.DataAccess.Configurations;
using DynamicForm.DataAccess.Domain;
using Microsoft.EntityFrameworkCore;

namespace DynamicForm.DataAccess
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Submission> Submissions { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new SubmissionConfiguration());
            modelBuilder.ApplyConfiguration(new FieldConfiguration());
        }
    }
}
