using System.ComponentModel.DataAnnotations;

namespace CourseAPI.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public ICollection<UserCourseMapping> Users { get; set; }
    }
}
