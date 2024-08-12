using Microsoft.AspNetCore.Mvc.Rendering;

namespace Labb2_Linq.Models
{
    public class SelectNewTeacherCourseVM
    {
        public int? CourseId { get; set; }
        public Course? Course { get; set; }

        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }

        public int? NewTeacherId { get; set; }
        public Teacher? NewTeacher { get; set; }
        public SelectList? NewTeacherList { get; set; }
    }
}
