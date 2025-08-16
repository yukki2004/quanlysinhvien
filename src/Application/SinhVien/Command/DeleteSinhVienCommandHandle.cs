using WebApplication2.src.Domain.Entity;
using WebApplication2.src.Domain.Interface;
namespace WebApplication2.src.Application.SinhVien.Command
{
    public class DeleteSinhVienCommandHandle
    {
        public readonly ISinhVien _deletesinhvien;
        public DeleteSinhVienCommandHandle(ISinhVien deletesinhvien)
        {
            _deletesinhvien = deletesinhvien;
        }
        public async Task Handle(DeleteSinhVienCommand id)
        {
            await _deletesinhvien.DeleteSinhVienById(id.Id);
        }
    }
}
