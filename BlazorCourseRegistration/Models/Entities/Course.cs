namespace BlazorCourseRegistration.Models.Entities;

public class Course
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Level { get; set; } = string.Empty;

    public int DurationInHours { get; set; }

    public List<Student> Students { get; set; } = new();
}