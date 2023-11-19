using System.ComponentModel.DataAnnotations.Schema;

namespace CourseAPI.Models
{
    public class UserCourseMapping
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
