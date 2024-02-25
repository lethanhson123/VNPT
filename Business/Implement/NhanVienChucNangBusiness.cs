
namespace Business.Implement
{
    public class NhanVienChucNangBusiness : BaseBusiness<NhanVienChucNang, INhanVienChucNangRepository>, INhanVienChucNangBusiness
    {
        private readonly INhanVienChucNangRepository _NhanVienChucNangRepository;
        public NhanVienChucNangBusiness(INhanVienChucNangRepository NhanVienChucNangRepository) : base(NhanVienChucNangRepository)
        {
            _NhanVienChucNangRepository = NhanVienChucNangRepository;
        }
    }
}
