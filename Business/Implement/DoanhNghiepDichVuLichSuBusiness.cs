
namespace Business.Implement
{
    public class DoanhNghiepDichVuLichSuBusiness : BaseBusiness<DoanhNghiepDichVuLichSu, IDoanhNghiepDichVuLichSuRepository>, IDoanhNghiepDichVuLichSuBusiness
    {
        private readonly IDoanhNghiepDichVuLichSuRepository _DoanhNghiepDichVuLichSuRepository;
        public DoanhNghiepDichVuLichSuBusiness(IDoanhNghiepDichVuLichSuRepository DoanhNghiepDichVuLichSuRepository) : base(DoanhNghiepDichVuLichSuRepository)
        {
            _DoanhNghiepDichVuLichSuRepository = DoanhNghiepDichVuLichSuRepository;
        }
    }
}
