using Data.Model;

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ReportController : BaseController<Report, IReportBusiness>
    {
        private readonly IReportBusiness _ReportBusiness;
        public ReportController(IReportBusiness ReportBusiness) : base(ReportBusiness)
        {
            _ReportBusiness = ReportBusiness;
        }
        [HttpPost]
        [Route("Report001Async")]
        public virtual async Task<List<Report>> Report001Async()
        {
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.Report001Async(baseParameter.DoanhNghiepID.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
        [HttpPost]
        [Route("Report002Async")]
        public virtual async Task<List<Report>> Report002Async()
        {
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.Report002Async(baseParameter.DoanhNghiepID.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
        [HttpPost]
        [Route("Report003Async")]
        public virtual async Task<List<Report>> Report003Async()
        {
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.Report003Async(baseParameter.DoanhNghiepID.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
        [HttpPost]
        [Route("Report004Async")]
        public virtual async Task<List<Report>> Report004Async()
        {
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.Report004Async(baseParameter.HuyenID.Value, baseParameter.XaID.Value, baseParameter.SearchString);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
        [HttpPost]
        [Route("ReportDoanhNghiep001Async")]
        public virtual async Task<List<Report>> ReportDoanhNghiep001Async()
        {
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportDoanhNghiep001Async(baseParameter.DoanhNghiepID.Value, baseParameter.Year.Value, baseParameter.Month.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
        [HttpPost]
        [Route("ReportDoanhNghiep002Async")]
        public virtual async Task<List<Report>> ReportDoanhNghiep002Async()
        {
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportDoanhNghiep002Async(baseParameter.DoanhNghiepID.Value, baseParameter.Year.Value, baseParameter.Month.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
        [HttpPost]
        [Route("ReportDoanhNghiep003Async")]
        public virtual async Task<List<Report>> ReportDoanhNghiep003Async()
        {
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportDoanhNghiep003Async(baseParameter.DoanhNghiepID.Value, baseParameter.Year.Value, baseParameter.Month.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
        [HttpPost]
        [Route("ReportDoanhNghiep004Async")]
        public virtual async Task<List<Report>> ReportDoanhNghiep004Async()
        {
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportDoanhNghiep004Async(baseParameter.DoanhNghiepID.Value, baseParameter.Year.Value, baseParameter.Month.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
        [HttpPost]
        [Route("ReportVNPT001Async")]
        public virtual async Task<List<Report>> ReportVNPT001Async()
        {
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportVNPT001Async(baseParameter.HuyenID.Value, baseParameter.XaID.Value, baseParameter.SearchString, baseParameter.Year.Value, baseParameter.Month.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
        [HttpPost]
        [Route("ReportVNPT002Async")]
        public virtual async Task<List<Report>> ReportVNPT002Async()
        {
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportVNPT002Async(baseParameter.HuyenID.Value, baseParameter.XaID.Value, baseParameter.SearchString, baseParameter.LoaiDichVuID.Value, baseParameter.Year.Value, baseParameter.Month.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
        [HttpPost]
        [Route("ReportVNPT003Async")]
        public virtual async Task<List<Report>> ReportVNPT003Async()
        {
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportVNPT003Async(baseParameter.HuyenID.Value, baseParameter.XaID.Value, baseParameter.SearchString, baseParameter.DichVuID.Value, baseParameter.Year.Value, baseParameter.Month.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
        [HttpPost]
        [Route("ReportVNPT004Async")]
        public virtual async Task<List<Report>> ReportVNPT004Async()
        {
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportVNPT004Async(baseParameter.PhongBanID.Value, baseParameter.Year.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
        [HttpPost]
        [Route("ReportVNPT005Async")]
        public virtual async Task<List<Report>> ReportVNPT005Async()
        {
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportVNPT005Async(baseParameter.NhanVienID.Value, baseParameter.Year.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA001Async")]
		public virtual async Task<List<Report>> ReportCA001Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA001Async(baseParameter.HuyenID.Value, baseParameter.Year.Value, baseParameter.Month.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA002Async")]
		public virtual async Task<List<Report>> ReportCA002Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA002Async(baseParameter.HuyenID.Value, baseParameter.Year.Value, baseParameter.Month.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA003Async")]
		public virtual async Task<List<Report>> ReportCA003Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA003Async(baseParameter.HuyenID.Value, baseParameter.Year.Value, baseParameter.Month.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA004Async")]
		public virtual async Task<List<Report>> ReportCA004Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA004Async(baseParameter.HuyenID.Value, baseParameter.Year.Value, baseParameter.Month.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA005Async")]
		public virtual async Task<List<Report>> ReportCA005Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA005Async(baseParameter.HuyenID.Value, baseParameter.Year.Value, baseParameter.Month.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA006Async")]
		public virtual async Task<List<Report>> ReportCA006Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA006Async(baseParameter.HuyenID.Value, baseParameter.Year.Value, baseParameter.Month.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA007Async")]
		public virtual async Task<List<Report>> ReportCA007Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA007Async(baseParameter.HuyenID.Value, baseParameter.Year.Value, baseParameter.Month.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA101Async")]
		public virtual async Task<List<Report>> ReportCA101Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA101Async(baseParameter.HuyenID.Value, baseParameter.Year.Value, baseParameter.Month.Value, baseParameter.NhanVienID.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA102Async")]
		public virtual async Task<List<Report>> ReportCA102Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA102Async(baseParameter.HuyenID.Value, baseParameter.Year.Value, baseParameter.Month.Value, baseParameter.NhanVienID.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA103Async")]
		public virtual async Task<List<Report>> ReportCA103Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA103Async(baseParameter.HuyenID.Value, baseParameter.Year.Value, baseParameter.Month.Value, baseParameter.NhanVienID.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA104Async")]
		public virtual async Task<List<Report>> ReportCA104Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA104Async(baseParameter.HuyenID.Value, baseParameter.Year.Value, baseParameter.Month.Value, baseParameter.NhanVienID.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA105Async")]
		public virtual async Task<List<Report>> ReportCA105Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA105Async(baseParameter.HuyenID.Value, baseParameter.Year.Value, baseParameter.Month.Value, baseParameter.NhanVienID.Value, baseParameter.HetHan.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA106Async")]
		public virtual async Task<List<Report>> ReportCA106Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA106Async(baseParameter.HuyenID.Value, baseParameter.Year.Value, baseParameter.Month.Value, baseParameter.NhanVienID.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA107Async")]
		public virtual async Task<List<Report>> ReportCA107Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA107Async(baseParameter.HuyenID.Value, baseParameter.Year.Value, baseParameter.Month.Value, baseParameter.NhanVienID.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA108Async")]
		public virtual async Task<List<Report>> ReportCA108Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA108Async(baseParameter.HuyenID.Value, baseParameter.Year.Value, baseParameter.Month.Value, baseParameter.NhanVienID.Value, baseParameter.IsKetLuan.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA201Async")]
		public virtual async Task<Report> ReportCA201Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			Report result = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);						
				
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA201Async(baseParameter.Year.Value, baseParameter.Month.Value);
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
			return result;
		}
		[HttpPost]
		[Route("ReportCA202Async")]
		public virtual async Task<List<Report>> ReportCA202Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA202Async(baseParameter.Year.Value, baseParameter.Month.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA203Async")]
		public virtual async Task<List<Report>> ReportCA203Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA203Async(baseParameter.Year.Value, baseParameter.Month.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA204Async")]
		public virtual async Task<List<Report>> ReportCA204Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA204Async(baseParameter.Year.Value, baseParameter.Month.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA205Async")]
		public virtual async Task<List<Report>> ReportCA205Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA205Async(baseParameter.Year.Value, baseParameter.Month.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA206Async")]
		public virtual async Task<List<Report>> ReportCA206Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA206Async(baseParameter.Year.Value, baseParameter.Month.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA207Async")]
		public virtual async Task<List<Report>> ReportCA207Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA207Async(baseParameter.Year.Value, baseParameter.Month.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA305Async")]
		public virtual async Task<List<Report>> ReportCA305Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA305Async(baseParameter.HuyenID.Value, baseParameter.Year.Value, baseParameter.Month.Value, baseParameter.NhanVienID.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA306Async")]
		public virtual async Task<List<Report>> ReportCA306Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA306Async(baseParameter.HuyenID.Value, baseParameter.Year.Value, baseParameter.Month.Value, baseParameter.NhanVienID.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA307Async")]
		public virtual async Task<List<Report>> ReportCA307Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA307Async(baseParameter.HuyenID.Value, baseParameter.Year.Value, baseParameter.Month.Value, baseParameter.NhanVienID.Value, baseParameter.HetHan.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA308Async")]
		public virtual async Task<List<Report>> ReportCA308Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA308Async(baseParameter.HuyenID.Value, baseParameter.Year.Value, baseParameter.Month.Value, baseParameter.NhanVienID.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA401Async")]
		public virtual async Task<List<Report>> ReportCA401Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA401Async(baseParameter.HuyenID.Value, baseParameter.Year.Value, baseParameter.Month.Value, baseParameter.NhanVienID.Value, baseParameter.IsSmartCA.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA402Async")]
		public virtual async Task<List<Report>> ReportCA402Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA402Async(baseParameter.HuyenID.Value, baseParameter.Year.Value, baseParameter.Month.Value, baseParameter.NhanVienID.Value, baseParameter.IsSmartCA.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA403Async")]
		public virtual async Task<List<Report>> ReportCA403Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA403Async(baseParameter.HuyenID.Value, baseParameter.Year.Value, baseParameter.Month.Value, baseParameter.NhanVienID.Value, baseParameter.IsSmartCA.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA404Async")]
		public virtual async Task<List<Report>> ReportCA404Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA404Async(baseParameter.HuyenID.Value, baseParameter.Year.Value, baseParameter.Month.Value, baseParameter.NhanVienID.Value, baseParameter.IsSmartCA.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA405Async")]
		public virtual async Task<List<Report>> ReportCA405Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA405Async(baseParameter.HuyenID.Value, baseParameter.Year.Value, baseParameter.Month.Value, baseParameter.NhanVienID.Value, baseParameter.HetHan.Value, baseParameter.IsSmartCA.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA406Async")]
		public virtual async Task<List<Report>> ReportCA406Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA406Async(baseParameter.HuyenID.Value, baseParameter.Year.Value, baseParameter.Month.Value, baseParameter.NhanVienID.Value, baseParameter.IsSmartCA.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA407Async")]
		public virtual async Task<List<Report>> ReportCA407Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA407Async(baseParameter.HuyenID.Value, baseParameter.Year.Value, baseParameter.Month.Value, baseParameter.NhanVienID.Value, baseParameter.IsSmartCA.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA408Async")]
		public virtual async Task<List<Report>> ReportCA408Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA408Async(baseParameter.HuyenID.Value, baseParameter.Year.Value, baseParameter.Month.Value, baseParameter.NhanVienID.Value, baseParameter.IsKetLuan.Value, baseParameter.IsSmartCA.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA501Async")]
		public virtual async Task<Report> ReportCA501Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			Report result = new Report();			
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA501Async(baseParameter.Year.Value, baseParameter.Month.Value, baseParameter.IsSmartCA.Value);
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
			result.Description = baseParameter.APIMessage;
			return result;
		}
		[HttpPost]
		[Route("ReportCA502Async")]
		public virtual async Task<List<Report>> ReportCA502Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA502Async(baseParameter.Year.Value, baseParameter.Month.Value, baseParameter.IsSmartCA.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA503Async")]
		public virtual async Task<List<Report>> ReportCA503Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA503Async(baseParameter.Year.Value, baseParameter.Month.Value, baseParameter.IsSmartCA.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA504Async")]
		public virtual async Task<List<Report>> ReportCA504Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA504Async(baseParameter.Year.Value, baseParameter.Month.Value, baseParameter.IsSmartCA.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA505Async")]
		public virtual async Task<List<Report>> ReportCA505Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA505Async(baseParameter.Year.Value, baseParameter.Month.Value, baseParameter.IsSmartCA.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA506Async")]
		public virtual async Task<List<Report>> ReportCA506Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA506Async(baseParameter.Year.Value, baseParameter.Month.Value, baseParameter.IsSmartCA.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA507Async")]
		public virtual async Task<List<Report>> ReportCA507Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA507Async(baseParameter.Year.Value, baseParameter.Month.Value, baseParameter.IsSmartCA.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA605Async")]
		public virtual async Task<List<Report>> ReportCA605Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA605Async(baseParameter.HuyenID.Value, baseParameter.Year.Value, baseParameter.Month.Value, baseParameter.NhanVienID.Value, baseParameter.IsSmartCA.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA606Async")]
		public virtual async Task<List<Report>> ReportCA606Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA606Async(baseParameter.HuyenID.Value, baseParameter.Year.Value, baseParameter.Month.Value, baseParameter.NhanVienID.Value, baseParameter.IsSmartCA.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA607Async")]
		public virtual async Task<List<Report>> ReportCA607Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA607Async(baseParameter.HuyenID.Value, baseParameter.Year.Value, baseParameter.Month.Value, baseParameter.NhanVienID.Value, baseParameter.HetHan.Value, baseParameter.IsSmartCA.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA608Async")]
		public virtual async Task<List<Report>> ReportCA608Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA608Async(baseParameter.HuyenID.Value, baseParameter.Year.Value, baseParameter.Month.Value, baseParameter.NhanVienID.Value, baseParameter.IsSmartCA.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCASearchStringToListAsync")]
		public virtual async Task<List<Report>> ReportCASearchStringToListAsync()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCASearchStringToListAsync(baseParameter.SearchString);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportVNPT1001ToListAsync")]
		public virtual async Task<List<Report>> ReportVNPT1001ToListAsync()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportVNPT1001ToListAsync();
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportVNPT1002ToListAsync")]
		public virtual async Task<List<Report>> ReportVNPT1002ToListAsync()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportVNPT1002ToListAsync();
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}

		[HttpPost]
		[Route("ReportCA201_001Async")]
		public virtual async Task<Report> ReportCA201_001Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			Report result = new Report();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA201_001Async(baseParameter.Year.Value, baseParameter.Month.Value, baseParameter.NhanVienID.Value);
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
			result.Description = baseParameter.APIMessage;
			return result;
		}
		[HttpPost]
		[Route("ReportCA501_001Async")]
		public virtual async Task<Report> ReportCA501_001Async()
		{
			BaseParameter baseParameter = new BaseParameter();
			Report result = new Report();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCA501_001Async(baseParameter.Year.Value, baseParameter.Month.Value, baseParameter.NhanVienID.Value, baseParameter.IsSmartCA.Value);
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
			result.Description = baseParameter.APIMessage;
			return result;
		}

		[HttpPost]
		[Route("ReportCACapBu101ToListAsync")]
		public virtual async Task<List<Report>> ReportCACapBu101ToListAsync()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCACapBu101ToListAsync();
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCACapBu102ToListAsync")]
		public virtual async Task<List<Report>> ReportCACapBu102ToListAsync()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCACapBu102ToListAsync();
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCACapBu103ToListAsync")]
		public virtual async Task<List<Report>> ReportCACapBu103ToListAsync()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCACapBu103ToListAsync();
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCACapBu201ToListAsync")]
		public virtual async Task<List<Report>> ReportCACapBu201ToListAsync()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCACapBu201ToListAsync(baseParameter.IsSmartCA.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCACapBu202ToListAsync")]
		public virtual async Task<List<Report>> ReportCACapBu202ToListAsync()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCACapBu202ToListAsync(baseParameter.IsSmartCA.Value);
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
				result = new List<Report>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCACapBu203ToListAsync")]
		public virtual async Task<List<Report>> ReportCACapBu203ToListAsync()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Report> result = new List<Report>();
			Report itemResult = new Report();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _ReportBusiness.ReportCACapBu203ToListAsync(baseParameter.IsSmartCA.Value);
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
				result = new List<Report>();
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
