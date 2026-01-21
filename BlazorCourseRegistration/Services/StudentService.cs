using BlazorCourseRegistration.Data;
using BlazorCourseRegistration.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorCourseRegistration.Services;

public class StudentService : IStudentService
{
    private readonly ApplicationDbContext _context;

    public StudentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Student>> GetByCourseAsync(int courseId)
    {
        return await _context.Students
            .Where(s => s.CourseId == courseId)
            .ToListAsync();
    }

    public async Task RegisterAsync(Student student)
    {
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Student>> GetAllAsync()
    {
        return await _context.Students
            .Include(s => s.Course)
            .ToListAsync();
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        return await _context.Students.FindAsync(id);
    }

    public async Task UpdateAsync(Student student)
    {
        _context.Students.Update(student);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null) return;

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
    }
}