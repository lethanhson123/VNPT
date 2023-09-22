using System.Drawing;

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DownloadController : BaseController<DoanhNghiep, IDoanhNghiepBusiness>
    {
        private readonly IWebHostEnvironment _WebHostEnvironment;
        private readonly IDoanhNghiepBusiness _IDoanhNghiepBusiness;

        public DownloadController(IWebHostEnvironment WebHostEnvironment
            , IDoanhNghiepBusiness IDoanhNghiepBusiness            
            ) : base(IDoanhNghiepBusiness)
        {
            _WebHostEnvironment = WebHostEnvironment;
            _IDoanhNghiepBusiness = IDoanhNghiepBusiness;            
        }        
    }
}
