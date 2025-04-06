using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Delivery_Management.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<DeliveyAppDbContext>(options =>
                // options.UseSqlite(builder.Configuration.GetConnectionString("DeliveyAppDbContext") ?? throw new InvalidOperationException("Connection string 'DeliveyAppDbContext' not found.")));
                //options.sql

                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DeliveyAppDbContextSQLServer")
                    ?? throw new InvalidOperationException("Connection string 'DeliveyAppDbContext' not found.")));
            // Add services to the container.
            builder.Services
                .AddControllers()
                .AddNewtonsoftJson(
                    options =>
                    options.SerializerSettings.ReferenceLoopHandling
                    = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    );

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            // if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}




