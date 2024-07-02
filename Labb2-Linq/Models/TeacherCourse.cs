using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb2_Linq.Models
{
    public class TeacherCourse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [ForeignKey("Teacher")]
        public int FkTeacherId { get; set; }
        public Teacher Teacher{ get; set; }

        [ForeignKey("Course")]
        public int FkCourseId { get; set; }
        public Course Course { get; set; }
    }
}
