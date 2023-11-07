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

// Создайте экземпляр MapperConfig и зарегистрируйте его в AutoMapper
var mapperConfig = new MapperConfig(builder.Services.BuildServiceProvider().GetService<Context>());
builder.Services.AddAutoMapper(cfg => cfg.AddProfile(mapperConfig));
builder.Services.AddScoped<IGroupGetter, GroupGetter>();
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var app = builder.Build();
app.UseCors(options => options
      .AllowAnyHeader()
      .AllowAnyMethod()
      .WithOrigins(builder.Configuration.GetSection("Urls:FrontEndUrl").Value)
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
