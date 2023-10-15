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
            List<DoanhNghiepDichVuLichSu> result = new List<DoanhNghiepDichVuLichSu>();
            try
            {
                long doanhNghiepID = JsonConvert.DeserializeObject<long>(Request.Form["doanhNghiepID"]);
                int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
                int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
                result = await _DoanhNghiepDichVuLichSuBusiness.GetByDoanhNghiepIDAndYearAndMonthToListAsync(doanhNghiepID, year, month);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }

            return result;
        }
    }
}
