
namespace Business.Implement
{
    public class NhanVienBusiness : BaseBusiness<NhanVien, INhanVienRepository>, INhanVienBusiness
    {
        private readonly INhanVienRepository _NhanVienRepository;
        public NhanVienBusiness(INhanVienRepository NhanVienRepository) : base(NhanVienRepository)
        {
            _NhanVienRepository = NhanVienRepository;
        }
    }
}
