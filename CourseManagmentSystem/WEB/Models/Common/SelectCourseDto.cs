namespace WEB.Models.Common
{
    public class SelectCourseDto
    {
        public string UserId { get; set; }
        public List<SelectCourseItemDto> SelectedCourses { get; set; }
    }
}
