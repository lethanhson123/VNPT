namespace API.Controllers.v1
{
	[ApiController]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiVersion("1.0")]
	public class DownloadController : BaseController<DoanhNghiep, IDoanhNghiepBusiness>
	{
		private readonly IWebHostEnvironment _WebHostEnvironment;
		private readonly IDoanhNghiepBusiness _DoanhNghiepBusiness;
		private readonly IHuyenBusiness _HuyenBusiness;
		private readonly IReportBusiness _ReportBusiness;

		public DownloadController(IWebHostEnvironment WebHostEnvironment
			, IDoanhNghiepBusiness DoanhNghiepBusiness
			, IHuyenBusiness HuyenBusiness
			, IReportBusiness ReportBusiness
			) : base(DoanhNghiepBusiness)
		{
			_WebHostEnvironment = WebHostEnvironment;
			_DoanhNghiepBusiness = DoanhNghiepBusiness;
			_HuyenBusiness = HuyenBusiness;
			_ReportBusiness = ReportBusiness;
		}
		[HttpGet]
		[Route("GetMonthToList")]
		public List<YearMonth> GetMonthToList()
		{
			var result = YearMonth.GetMonthToList();
			return result;
		}
		[HttpGet]
		[Route("GetYearToList")]
		public List<YearMonth> GetYearToList()
		{
			var result = YearMonth.GetYearToList();
			return result;
		}		
	}
}
