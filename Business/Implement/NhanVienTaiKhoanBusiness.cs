
namespace Business.Implement
{
    public class NhanVienTaiKhoanBusiness : BaseBusiness<NhanVienTaiKhoan, INhanVienTaiKhoanRepository>, INhanVienTaiKhoanBusiness
    {
        private readonly INhanVienTaiKhoanRepository _NhanVienTaiKhoanRepository;
        public NhanVienTaiKhoanBusiness(INhanVienTaiKhoanRepository NhanVienTaiKhoanRepository) : base(NhanVienTaiKhoanRepository)
        {
            _NhanVienTaiKhoanRepository = NhanVienTaiKhoanRepository;
        }
    }
}
