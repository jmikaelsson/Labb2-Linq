using System.ComponentModel.DataAnnotations;

namespace Labb2_Linq.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 20 characters")]
        [Display(Name = "Kurs")]
        public string CourseName { get; set; }

       public ICollection<TeacherCourse> TeacherCourses { get; set; } = [];
       public ICollection<StudentCourse> StudentCourses { get; set; } = [];
    }
}
