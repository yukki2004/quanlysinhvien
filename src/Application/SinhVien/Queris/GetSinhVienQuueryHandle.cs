using WebApplication2.src.Application.SinhVien.DT0s;
using WebApplication2.src.Domain.Interface;

namespace WebApplication2.src.Application.SinhVien.Queris
{
    public class GetSinhVienQuueryHandle
    {
        public readonly ISinhVien _sinhVienRepository;
        public GetSinhVienQuueryHandle(ISinhVien sinhVienRepository)
        {
            _sinhVienRepository = sinhVienRepository;
        }
        public async Task<List<SinhVienDTOs>> Handle()
        {
            var sinhVienList = await _sinhVienRepository.GetSinhVien();
            if (sinhVienList == null || !sinhVienList.Any())
            {
                return new List<SinhVienDTOs>();
            }
            var dtoList = sinhVienList.Select(sv => new SinhVienDTOs
            {
                id = sv.Id,
                Hoten = sv.HoTen,
                MaSv = sv.MaSinhVien,
                NgaySinh = sv.NgaySinh
            }).ToList();

            return dtoList;
        }
    }
}
