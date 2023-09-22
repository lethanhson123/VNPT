
namespace Business.Implement
{
    public class DoanhNghiepThanhVienBusiness : BaseBusiness<DoanhNghiepThanhVien, IDoanhNghiepThanhVienRepository>, IDoanhNghiepThanhVienBusiness
    {
        private readonly IDoanhNghiepThanhVienRepository _DoanhNghiepThanhVienRepository;
        public DoanhNghiepThanhVienBusiness(IDoanhNghiepThanhVienRepository DoanhNghiepThanhVienRepository) : base(DoanhNghiepThanhVienRepository)
        {
            _DoanhNghiepThanhVienRepository = DoanhNghiepThanhVienRepository;
        }
    }
}
