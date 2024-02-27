using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;

namespace API.Controllers.v1
{
	[ApiController]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiVersion("1.0")]
	public class DichVuChiTieuController : BaseController<DichVuChiTieu, IDichVuChiTieuBusiness>
	{
		private readonly IDichVuChiTieuBusiness _DichVuChiTieuBusiness;
		public DichVuChiTieuController(IDichVuChiTieuBusiness DichVuChiTieuBusiness) : base(DichVuChiTieuBusiness)
		{
			_DichVuChiTieuBusiness = DichVuChiTieuBusiness;
		}
		[HttpPost]
		[Route("GetByNam_ThangToListAsync")]
		public virtual async Task<List<DichVuChiTieu>> GetByNam_ThangToListAsync()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<DichVuChiTieu> result = new List<DichVuChiTieu>();
			DichVuChiTieu itemResult = new DichVuChiTieu();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _DichVuChiTieuBusiness.GetByNam_ThangToListAsync(baseParameter.Year.Value, baseParameter.Month.Value);					
				}
				else
				{
					baseParameter.APIMessage = GlobalHelper.APIErrorMessage;					
				}
			}
			catch (Exception ex)
			{
				baseParameter.APIMessage = ex.Message;				
			}
			if (result == null)
			{
				result = new List<DichVuChiTieu>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
	}
}

