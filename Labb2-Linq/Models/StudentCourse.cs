using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb2_Linq.Models
{
    public class StudentCourse
    {
        [ForeignKey("Student")]
        public int FkStudentId { get; set; }
        public Student Student { get; set; }


        [ForeignKey("Course")]
        public int FkCourseId { get; set; }
        public Course Course { get; set; }
    }
}
