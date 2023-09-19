using Microsoft.EntityFrameworkCore;

namespace CQRS.API.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Name = "Ahmet",
                    Surname = "CENG",
                    Age = 15,
                    Id = 1
                },
                  new Student()
                  {
                      Name = "Mehmet",
                      Surname = "Emin",
                      Age = 21,
                      Id = 2
                  },
                    new Student()
                    {
                        Name = "Sadık",
                        Surname = "KARA",
                        Age = 14,
                        Id = 3
                    }
                );
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Student> Students { get; set; }
    }
}
