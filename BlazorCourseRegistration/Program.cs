using BlazorCourseRegistration.Components;
using BlazorCourseRegistration.Data;
using BlazorCourseRegistration.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IStudentService, StudentService>();

var app = builder.Build();

// using (var scope1 = app.Services.CreateScope())
// {
//     var db = scope1.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//
//     if (!db.Courses.Any())
//     {
//         db.Courses.AddRange(
//             new Course { Title = "C# Basics", Description = "Intro to C#", Level = "Beginner", DurationInHours = 40 },
//             new Course { Title = "ASP.NET Core", Description = "Web APIs & MVC", Level = "Intermediate", DurationInHours = 60 },
//             new Course { Title = "Blazor", Description = "Full-stack Blazor", Level = "Advanced", DurationInHours = 50 }
//         );
//
//         db.SaveChanges();
//     }
// }


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}


using var scope = app.Services.CreateScope();
await using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
await dbContext.Database.GetInfrastructure().GetService<IMigrator>()!.MigrateAsync();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();