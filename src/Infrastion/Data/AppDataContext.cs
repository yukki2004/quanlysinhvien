using Microsoft.EntityFrameworkCore;
using System;
using WebApplication2.src.Domain.Entity;
namespace WebApplication2.src.Infrastion.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) { }
        public DbSet<SinhVien> SinhVien => Set<SinhVien>();
    }
}
