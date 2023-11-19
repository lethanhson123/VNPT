
namespace Business.Implement
{
    public class DoanhNghiepDichVuCABusiness : BaseBusiness<DoanhNghiepDichVuCA, IDoanhNghiepDichVuCARepository>, IDoanhNghiepDichVuCABusiness
    {
        private readonly IDoanhNghiepDichVuCARepository _DoanhNghiepDichVuCARepository;
        public DoanhNghiepDichVuCABusiness(IDoanhNghiepDichVuCARepository DoanhNghiepDichVuCARepository) : base(DoanhNghiepDichVuCARepository)
        {
            _DoanhNghiepDichVuCARepository = DoanhNghiepDichVuCARepository;
        }
    }
}
