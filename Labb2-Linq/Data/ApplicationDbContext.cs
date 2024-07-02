using Labb2_Linq.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb2_Linq.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite keys for many-to-many relationships
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.FkStudentId, sc.FkCourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.FkStudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.FkCourseId);

            modelBuilder.Entity<TeacherCourse>()
                .HasKey(tc => new { tc.FkTeacherId, tc.FkCourseId });

            modelBuilder.Entity<TeacherCourse>()
                .HasOne(tc => tc.Teacher)
                .WithMany(t => t.TeacherCourses)
                .HasForeignKey(tc => tc.FkTeacherId);

            modelBuilder.Entity<TeacherCourse>()
                .HasOne(tc => tc.Course)
                .WithMany(c => c.TeacherCourses)
                .HasForeignKey(tc => tc.FkCourseId);

            // This line is used if using identity and if having an overridden OnModelCreating
            // base.OnModelCreating(modelBuilder);
        }


        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

    }
}
