using System.ComponentModel.DataAnnotations;

namespace Labb2_Linq.Models
{
    public class Class
    {
        public int ClassId { get; set; }

        [StringLength(10, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 10 characters")]
        [Display(Name = "Klass")]
        public string ClassName { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
