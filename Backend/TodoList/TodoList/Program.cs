
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TodoList.Mode;
using TodoList.Services;
using TodoList.Services.Interfaces;

namespace TodoList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<TodoDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
                options.SwaggerDoc("v3", new OpenApiInfo
                {
                    Title = "Todo Axia Exam API in C#",
                    Version = "v3",
                    Description = "API to handle your daily todo necessities"
                })
            );

            builder.Services.AddScoped<ITodoService, TodoService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v3/swagger.json", "Todo Axia Exam API v3");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
