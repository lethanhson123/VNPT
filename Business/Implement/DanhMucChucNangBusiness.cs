
namespace Business.Implement
{
    public class DanhMucChucNangBusiness : BaseBusiness<DanhMucChucNang, IDanhMucChucNangRepository>, IDanhMucChucNangBusiness
    {
        private readonly IDanhMucChucNangRepository _DanhMucChucNangRepository;
        public DanhMucChucNangBusiness(IDanhMucChucNangRepository DanhMucChucNangRepository) : base(DanhMucChucNangRepository)
        {
            _DanhMucChucNangRepository = DanhMucChucNangRepository;
        }
    }
}
