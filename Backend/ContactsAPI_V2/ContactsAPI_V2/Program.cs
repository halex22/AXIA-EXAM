
using ContactsAPI_V2.Model;
using ContactsAPI_V2.Services;
using ContactsAPI_V2.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContactsAPI_V2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ContactsDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IContactService, ContactService>();
            builder.Services.AddScoped<IGroupService, GroupSerice>();

            builder.Services.AddCors(options =>
                options.AddPolicy("AllowAllOrigins",
                    builder => builder.AllowAnyOrigin()
                                        .AllowAnyMethod()
                                        .AllowAnyHeader()
                                        )
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("AllowAllOrigins");
            app.MapControllers();

            app.Run();
        }
    }
}
