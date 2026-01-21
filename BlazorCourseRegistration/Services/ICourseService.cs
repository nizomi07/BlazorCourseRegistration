using BlazorCourseRegistration.Models.Entities;

namespace BlazorCourseRegistration.Services;

public interface ICourseService
{
        Task<List<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);
        Task CreateAsync(Course course);
        Task DeleteAsync(int id);
}