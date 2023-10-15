
namespace Business.Implement
{
    public class LoaiDichVuBusiness : BaseBusiness<LoaiDichVu, ILoaiDichVuRepository>, ILoaiDichVuBusiness
    {
        private readonly ILoaiDichVuRepository _LoaiDichVuRepository;
        public LoaiDichVuBusiness(ILoaiDichVuRepository LoaiDichVuRepository) : base(LoaiDichVuRepository)
        {
            _LoaiDichVuRepository = LoaiDichVuRepository;
        }
    }
}
