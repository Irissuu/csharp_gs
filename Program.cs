using FlowGuard.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore;

namespace FlowGuard
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("OracleDB");
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseOracle(connectionString));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
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
