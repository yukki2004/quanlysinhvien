
using Microsoft.AspNetCore.Builder;
using WebApplication2.src.Infrastion.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication2.src.Domain.Interface;
using WebApplication2.src.Infrastion.Resposity;
using WebApplication2.src.Application.SinhVien.Command;
using WebApplication2.src.Application.SinhVien.Queris;
namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDataContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<ISinhVien, SinhVienRespository>();
            builder.Services.AddScoped<GetSinhVienByIdQueryHandle>();
            builder.Services.AddScoped<GetSinhVienQuueryHandle>();
            builder.Services.AddScoped<CreateSinhVienCommandHandle>();
            builder.Services.AddScoped<DeleteSinhVienCommandHandle>();
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
       
