
using _3la_Kam_backend.Models;
using _3la_Kam_backend.Repositoris;
using _3la_Kam_backend.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace _3la_Kam_backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IProductRepo,productService>();
            builder.Services.AddScoped<ICategoryRipo, CategoryService>();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<context>();

            builder.Services.AddCors(options =>
            {

                options.AddPolicy("AllowAllOrigins",
                    policy =>
                    {
                        policy.AllowAnyOrigin() // Allow all origins
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
            });



            builder.Services.AddDbContext<context>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAllOrigins");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
