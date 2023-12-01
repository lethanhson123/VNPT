
namespace Business.Implement
{
    public class DanhMucGoiCuocBusiness : BaseBusiness<DanhMucGoiCuoc, IDanhMucGoiCuocRepository>, IDanhMucGoiCuocBusiness
    {
        private readonly IDanhMucGoiCuocRepository _DanhMucGoiCuocRepository;
        public DanhMucGoiCuocBusiness(IDanhMucGoiCuocRepository DanhMucGoiCuocRepository) : base(DanhMucGoiCuocRepository)
        {
            _DanhMucGoiCuocRepository = DanhMucGoiCuocRepository;
        }
    }
}
