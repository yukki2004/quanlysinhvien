using WebApplication2.src.Application.SinhVien.Command;
using WebApplication2.src.Domain.Entity;
namespace WebApplication2.src.Domain.Interface
{
    public interface ISinhVien
    {
        Task<List<SinhVien>> GetSinhVien();
        Task<SinhVien> GetSinhVienById(int id);
        Task CreateSinhVien(SinhVien sinhVien);
        Task DeleteSinhVienById(int id);
        
    }
}
