
namespace Business.Implement
{
    public class LoaiDoanhNghiepThanhVienBusiness : BaseBusiness<LoaiDoanhNghiepThanhVien, ILoaiDoanhNghiepThanhVienRepository>, ILoaiDoanhNghiepThanhVienBusiness
    {
        private readonly ILoaiDoanhNghiepThanhVienRepository _LoaiDoanhNghiepThanhVienRepository;
        public LoaiDoanhNghiepThanhVienBusiness(ILoaiDoanhNghiepThanhVienRepository LoaiDoanhNghiepThanhVienRepository) : base(LoaiDoanhNghiepThanhVienRepository)
        {
            _LoaiDoanhNghiepThanhVienRepository = LoaiDoanhNghiepThanhVienRepository;
        }
    }
}
