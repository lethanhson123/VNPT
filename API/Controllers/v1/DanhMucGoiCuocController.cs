namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DanhMucGoiCuocController : BaseController<DanhMucGoiCuoc, IDanhMucGoiCuocBusiness>
    {
        private readonly IDanhMucGoiCuocBusiness _DanhMucGoiCuocBusiness;
        public DanhMucGoiCuocController(IDanhMucGoiCuocBusiness DanhMucGoiCuocBusiness) : base(DanhMucGoiCuocBusiness)
        {
            _DanhMucGoiCuocBusiness = DanhMucGoiCuocBusiness;
        }
    }
}
