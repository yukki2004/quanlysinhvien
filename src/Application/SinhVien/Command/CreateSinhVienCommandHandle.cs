
using WebApplication2.src.Domain.Entity;
using WebApplication2.src.Domain.Interface;

namespace WebApplication2.src.Application.SinhVien.Command
{
    public class CreateSinhVienCommandHandle
    {
        public readonly ISinhVien _sinhvienRespository;
        public CreateSinhVienCommandHandle(ISinhVien sinhvienRespository)
        {
            _sinhvienRespository = sinhvienRespository;
        }
        public async Task Handle(CreateSinhVienCommand createSinhVienCommand)
        {
            var newsinhvien = new Domain.Entity.SinhVien
            {
                DiaChi = createSinhVienCommand.DiaChi,
                Email = createSinhVienCommand.Email,
                GioiTinh = createSinhVienCommand.GioiTinh,
                HoTen = createSinhVienCommand.HoTen,
                MaSinhVien = createSinhVienCommand.MaSv,
                NgaySinh = createSinhVienCommand.NgaySinh,
                SDT = createSinhVienCommand.SDT
            };
            await _sinhvienRespository.CreateSinhVien(newsinhvien);
        }
    }
}
