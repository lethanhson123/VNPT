namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DoanhNghiepDichVuLichSuController : BaseController<DoanhNghiepDichVuLichSu, IDoanhNghiepDichVuLichSuBusiness>
    {
        private readonly IDoanhNghiepDichVuLichSuBusiness _DoanhNghiepDichVuLichSuBusiness;
        public DoanhNghiepDichVuLichSuController(IDoanhNghiepDichVuLichSuBusiness DoanhNghiepDichVuLichSuBusiness) : base(DoanhNghiepDichVuLichSuBusiness)
        {
            _DoanhNghiepDichVuLichSuBusiness = DoanhNghiepDichVuLichSuBusiness;
        }
        [HttpPost]
        [Route("GetByDoanhNghiepIDAndYearAndMonthToListAsync")]
        public virtual async Task<List<DoanhNghiepDichVuLichSu>> GetByDoanhNghiepIDAndYearAndMonthToListAsync()
        {           
			BaseParameter baseParameter = new BaseParameter();
			List<DoanhNghiepDichVuLichSu> result = new List<DoanhNghiepDichVuLichSu>();
			DoanhNghiepDichVuLichSu itemResult = new DoanhNghiepDichVuLichSu();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _DoanhNghiepDichVuLichSuBusiness.GetByDoanhNghiepIDAndYearAndMonthToListAsync(baseParameter.DoanhNghiepID.Value, baseParameter.Year.Value, baseParameter.Month.Value);
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
				result = new List<DoanhNghiepDichVuLichSu>();
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
