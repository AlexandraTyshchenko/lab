using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using WebApplication1.dbContext;
using WebApplication1.Interfaces;
using WebApplication1.Mapper;
using WebApplication1.Middleware;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Context>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IScheduleCreator, ScheduleCreator>();
builder.Services.AddScoped<IGroupCreator, GroupCreator>();


var mapperConfig = new MapperConfig();
builder.Services.AddAutoMapper(cfg => cfg.AddProfile(mapperConfig));
builder.Services.AddScoped<IGroupGetter, GroupGetter>();
builder.Services.AddScoped<IStudentsGetter, StudentsGetter>();
builder.Services.AddScoped<IStudentCreator, StudentCreator>();
builder.Services.AddScoped<IStudentDeletter,StudentDeletter>();
builder.Services.AddScoped<ITeacherCreator, TeacherCreator>();
builder.Services.AddScoped<ITeachersGetter, TeacherGetter>();
builder.Services.AddScoped<ISubjectCreator, SubjectCreator>();
builder.Services.AddScoped<ISubjectsGetter, SubjectsGetter>();
var app = builder.Build();
app.UseCors(options => options
    .AllowAnyHeader()
    .AllowAnyMethod()
    .WithOrigins("http://localhost:4200") // <-- Set your Angular app's origin
    .AllowCredentials());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
