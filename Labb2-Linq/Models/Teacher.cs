using System.ComponentModel.DataAnnotations;

namespace Labb2_Linq.Models
{
    public class Teacher
    {
    
        public int TeacherId { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters")]
        [Display(Name = "Förnamn")]
        public string TeacherFirstName { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters")]
        [Display(Name = "Efternamn")]
        public string TeacherLastName { get; set; }

        public ICollection<TeacherCourse> TeacherCourses { get; set; }
    }
}

