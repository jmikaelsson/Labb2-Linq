using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb2_Linq.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters")]
        [Display(Name = "Förnamn")]
        public string StudentFirstName { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters")]
        [Display(Name = "Efternamn")]
        public string StudentLastName { get; set; }

        [ForeignKey("Class")]
        public int FkClassId { get; set; }
        public Class Class { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
