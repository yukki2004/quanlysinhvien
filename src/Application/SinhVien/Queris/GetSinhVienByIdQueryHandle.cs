using WebApplication2.src.Domain.Entity;
using WebApplication2.src.Domain.Interface;
using WebApplication2.src.Application.SinhVien.Queris;
using WebApplication2.src.Application.SinhVien.DT0s;
namespace WebApplication2.src.Application.SinhVien.Queris
{
    public class GetSinhVienByIdQueryHandle
    {
        public readonly ISinhVien _sinhVienRepository;
        public GetSinhVienByIdQueryHandle(ISinhVien sinhVienRepository)
        {
            _sinhVienRepository = sinhVienRepository;
        }
        public async Task<SinhVienDTOs> Handle(GetSinhVienByIdQuery query)
        {
            var user = await _sinhVienRepository.GetSinhVienById(query.Id);
            if (user == null)
            {
                return null;
            }
            return new SinhVienDTOs
            {
                id = user.Id,
                MaSv = user.MaSinhVien,
                Hoten = user.HoTen,
                NgaySinh = user.NgaySinh,
                Sex = user.GioiTinh,
                DiaChi = user.DiaChi,
                Email = user.Email,
                SDT = user.SDT
            };

        }

    }
}
