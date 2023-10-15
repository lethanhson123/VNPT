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
            List<Report> result = new List<Report>();
            try
            {
                long doanhNghiepID = JsonConvert.DeserializeObject<long>(Request.Form["doanhNghiepID"]);                
                result = await _ReportBusiness.Report001Async(doanhNghiepID);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("Report002Async")]
        public virtual async Task<List<Report>> Report002Async()
        {
            List<Report> result = new List<Report>();
            try
            {
                long doanhNghiepID = JsonConvert.DeserializeObject<long>(Request.Form["doanhNghiepID"]);
                result = await _ReportBusiness.Report002Async(doanhNghiepID);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("Report003Async")]
        public virtual async Task<List<Report>> Report003Async()
        {
            List<Report> result = new List<Report>();
            try
            {
                long doanhNghiepID = JsonConvert.DeserializeObject<long>(Request.Form["doanhNghiepID"]);
                result = await _ReportBusiness.Report003Async(doanhNghiepID);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("Report004Async")]
        public virtual async Task<List<Report>> Report004Async()
        {
            List<Report> result = new List<Report>();
            try
            {
                long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
                long xaID = JsonConvert.DeserializeObject<long>(Request.Form["xaID"]);
                string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
                result = await _ReportBusiness.Report004Async(huyenID, xaID, searchString);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
    }
}
