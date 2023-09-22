
namespace Business.Implement
{
    public class LoaiDoanhNghiepBusiness : BaseBusiness<LoaiDoanhNghiep, ILoaiDoanhNghiepRepository>, ILoaiDoanhNghiepBusiness
    {
        private readonly ILoaiDoanhNghiepRepository _LoaiDoanhNghiepRepository;
        public LoaiDoanhNghiepBusiness(ILoaiDoanhNghiepRepository LoaiDoanhNghiepRepository) : base(LoaiDoanhNghiepRepository)
        {
            _LoaiDoanhNghiepRepository = LoaiDoanhNghiepRepository;
        }
    }
}
