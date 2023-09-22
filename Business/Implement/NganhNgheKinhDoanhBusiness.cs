
namespace Business.Implement
{
    public class NganhNgheKinhDoanhBusiness : BaseBusiness<NganhNgheKinhDoanh, INganhNgheKinhDoanhRepository>, INganhNgheKinhDoanhBusiness
    {
        private readonly INganhNgheKinhDoanhRepository _NganhNgheKinhDoanhRepository;
        public NganhNgheKinhDoanhBusiness(INganhNgheKinhDoanhRepository NganhNgheKinhDoanhRepository) : base(NganhNgheKinhDoanhRepository)
        {
            _NganhNgheKinhDoanhRepository = NganhNgheKinhDoanhRepository;
        }
    }
}
