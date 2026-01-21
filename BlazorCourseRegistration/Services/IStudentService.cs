using BlazorCourseRegistration.Models.Entities;

namespace BlazorCourseRegistration.Services;

public interface IStudentService
{
    Task<List<Student>> GetByCourseAsync(int courseId);
    Task RegisterAsync(Student student);
    Task<List<Student>> GetAllAsync();
    Task<Student?> GetByIdAsync(int id);
    Task UpdateAsync(Student student);
    Task DeleteAsync(int id);
}