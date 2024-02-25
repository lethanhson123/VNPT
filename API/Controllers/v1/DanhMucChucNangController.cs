namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DanhMucChucNangController : BaseController<DanhMucChucNang, IDanhMucChucNangBusiness>
    {
        private readonly IDanhMucChucNangBusiness _DanhMucChucNangBusiness;
        public DanhMucChucNangController(IDanhMucChucNangBusiness DanhMucChucNangBusiness) : base(DanhMucChucNangBusiness)
        {
            _DanhMucChucNangBusiness = DanhMucChucNangBusiness;
        }
    }
}
