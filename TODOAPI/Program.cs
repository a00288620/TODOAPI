using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TodoAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create and configure the web host
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllers(); // Adds controllers to the app

            // Add Swagger services
            builder.Services.AddEndpointsApiExplorer(); // Adds basic API documentation support
            builder.Services.AddSwaggerGen(); // Adds Swagger generation

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(); // Enable Swagger middleware
                app.UseSwaggerUI(); // Enable Swagger UI in Development mode
            }

            app.UseHttpsRedirection(); // Redirect HTTP to HTTPS
            app.MapControllers();  // Map controller routes

            app.Run();
        }
    }
}
