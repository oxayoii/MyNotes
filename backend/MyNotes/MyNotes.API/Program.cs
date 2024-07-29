using Microsoft.EntityFrameworkCore;
using MyNotes.API.Controllers;
using MyNotes.Application.Services;
using MyNotes.Infrastructure;
using MyNotes.Infrastructure.Repositories;

namespace MyNotes.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<MyNotesContext>(
                options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("MyNotes.API")));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IMyNotesRepository, MyNotesRepository>();
            builder.Services.AddScoped<IMyNotesService, MyNotesService>();
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("http://localhost:5173");
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            app.UseCors();

            app.MapControllers();

            app.Run();
        }
    }
}
