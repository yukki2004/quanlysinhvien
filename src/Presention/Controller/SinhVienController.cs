using Microsoft.AspNetCore.Mvc;
using WebApplication2.src.Application.SinhVien.Queris;
using WebApplication2.src.Application.SinhVien.DT0s;
using WebApplication2.src.Application.SinhVien.Command;


namespace WebApplication2.src.Presention.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class SinhVienController : ControllerBase
    {
        private readonly GetSinhVienByIdQueryHandle _getSinhVienByIdQueryHandle;
        private readonly GetSinhVienQuueryHandle _getSinhVienQuueryHandle;
        private readonly CreateSinhVienCommandHandle _createSinhVienCommandHandle;
        private readonly DeleteSinhVienCommandHandle _deleteSinhVienCommandHandle;
        public SinhVienController(GetSinhVienByIdQueryHandle getSinhVienByIdQueryHandle, GetSinhVienQuueryHandle getSinhVienQuueryHandle, CreateSinhVienCommandHandle createSinhVienCommandHandle, DeleteSinhVienCommandHandle deleteSinhVienCommandHandle)
        {
            _getSinhVienByIdQueryHandle = getSinhVienByIdQueryHandle;
            _getSinhVienQuueryHandle = getSinhVienQuueryHandle;
            _createSinhVienCommandHandle = createSinhVienCommandHandle;
            _deleteSinhVienCommandHandle = deleteSinhVienCommandHandle;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SinhVienDTOs>> GetSinhVienById(int id)
        {
            var result = await _getSinhVienByIdQueryHandle.Handle(new GetSinhVienByIdQuery { Id = id });
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<SinhVienDTOs>>> GetSinhVien()
        {
            var result = await _getSinhVienQuueryHandle.Handle();
            if (result == null || !result.Any())
            {
                return NotFound();
            }
            return Ok(result);

        }
        [HttpPost]
        public async Task<IActionResult> CreateSinhVien([FromBody] CreateSinhVienCommand createSinhVienCommand)
        {
            if (createSinhVienCommand == null)
            {
                return BadRequest("Invalid data.");
            }

            await _createSinhVienCommandHandle.Handle(createSinhVienCommand);
            return Ok("SinhVien created successfully.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSinhVien(int id)
        {
            await _deleteSinhVienCommandHandle.Handle(new DeleteSinhVienCommand { Id = id });
            return Ok("SinhVien deleted successfully.");

        }
    }
}
