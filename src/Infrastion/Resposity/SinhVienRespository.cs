using Microsoft.EntityFrameworkCore;
using WebApplication2.src.Domain.Entity;
using WebApplication2.src.Domain.Interface;
using WebApplication2.src.Infrastion.Data;
namespace WebApplication2.src.Infrastion.Resposity
{
    public class SinhVienRespository : ISinhVien
    {
        private readonly AppDataContext _context;
        public SinhVienRespository(AppDataContext context)
        {
            _context = context;
        }
        public async Task<List<SinhVien>> GetSinhVien()
        {
            return await _context.SinhVien.ToListAsync();
        }
        public async Task<SinhVien> GetSinhVienById(int id)
        {
            return await _context.SinhVien.FindAsync(id);
        }

        public async Task CreateSinhVien(SinhVien sinhVien)
        {
            await _context.SinhVien.AddAsync(sinhVien);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSinhVienById(int id)
        {
            var sinhVien = await _context.SinhVien.FindAsync(id);
         
            if (sinhVien != null)
            {
                _context.SinhVien.Remove(sinhVien);
                await _context.SaveChangesAsync();
            }
        }


    }
}
