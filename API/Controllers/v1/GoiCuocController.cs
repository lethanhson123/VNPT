namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class GoiCuocController : BaseController<GoiCuoc, IGoiCuocBusiness>
    {
        private readonly IGoiCuocBusiness _GoiCuocBusiness;
        public GoiCuocController(IGoiCuocBusiness GoiCuocBusiness) : base(GoiCuocBusiness)
        {
            _GoiCuocBusiness = GoiCuocBusiness;
        }
    }
}
