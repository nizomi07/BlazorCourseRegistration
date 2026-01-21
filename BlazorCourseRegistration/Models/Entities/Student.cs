using System.ComponentModel.DataAnnotations;

namespace BlazorCourseRegistration.Models.Entities;

public class Student
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Full Name is required")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; } = string.Empty;

    public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

    public int CourseId { get; set; }
    public Course? Course { get; set; }
}