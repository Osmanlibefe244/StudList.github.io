using Microsoft.EntityFrameworkCore;

namespace StudList.Models
{
    public class ApplContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public ApplContext(DbContextOptions<ApplContext> options)
            : base(options)
        {
           //Database.EnsureDeleted();
           Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                    new Student { Id = 1, Name = "Азиз", Surname = "Алибеков", MidName = "Кадирбекович", SubjectId= 4, Grade=5},
                    new Student { Id = 2, Name = "Магомед", Surname = "Умедов", MidName = "Нариманович", SubjectId = 3, Grade = 4 },
                    new Student { Id = 3, Name = "Айдин", Surname = "Магомедов", MidName = "Сулейманович", SubjectId = 1, Grade = 3 },
                    new Student { Id = 4, Name = "Амирхан", Surname = "Магомедов", MidName = "Шахбанович", SubjectId = 2, Grade = 2 },
                    new Student { Id = 5, Name = "Ахмед", Surname = "Магомедов", MidName = "Умудович", SubjectId = 5, Grade = 2 }
            );
            modelBuilder.Entity<Subject>().HasData(
                    new Subject { Id = 1, Name = "Дагестанская литература" },
                    new Subject { Id = 2, Name = "Аварская литература" },
                    new Subject { Id = 3, Name = "Биология" },
                    new Subject { Id = 4, Name = "Химия" },
                    new Subject { Id = 5, Name = "КСЕ" }

            );
        }
    }
}
