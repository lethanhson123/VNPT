
namespace Business.Implement
{
    public class LoaiTrangThaiBusiness : BaseBusiness<LoaiTrangThai, ILoaiTrangThaiRepository>, ILoaiTrangThaiBusiness
    {
        private readonly ILoaiTrangThaiRepository _LoaiTrangThaiRepository;
        public LoaiTrangThaiBusiness(ILoaiTrangThaiRepository LoaiTrangThaiRepository) : base(LoaiTrangThaiRepository)
        {
            _LoaiTrangThaiRepository = LoaiTrangThaiRepository;
        }
    }
}
