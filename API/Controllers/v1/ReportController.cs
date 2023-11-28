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
        [HttpPost]
        [Route("ReportDoanhNghiep001Async")]
        public virtual async Task<List<Report>> ReportDoanhNghiep001Async()
        {
            List<Report> result = new List<Report>();
            try
            {
                long doanhNghiepID = JsonConvert.DeserializeObject<long>(Request.Form["doanhNghiepID"]);
                int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
                int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
                result = await _ReportBusiness.ReportDoanhNghiep001Async(doanhNghiepID, year, month);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("ReportDoanhNghiep002Async")]
        public virtual async Task<List<Report>> ReportDoanhNghiep002Async()
        {
            List<Report> result = new List<Report>();
            try
            {
                long doanhNghiepID = JsonConvert.DeserializeObject<long>(Request.Form["doanhNghiepID"]);
                int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
                int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
                result = await _ReportBusiness.ReportDoanhNghiep002Async(doanhNghiepID, year, month);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("ReportDoanhNghiep003Async")]
        public virtual async Task<List<Report>> ReportDoanhNghiep003Async()
        {
            List<Report> result = new List<Report>();
            try
            {
                long doanhNghiepID = JsonConvert.DeserializeObject<long>(Request.Form["doanhNghiepID"]);
                int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
                int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
                result = await _ReportBusiness.ReportDoanhNghiep003Async(doanhNghiepID, year, month);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("ReportDoanhNghiep004Async")]
        public virtual async Task<List<Report>> ReportDoanhNghiep004Async()
        {
            List<Report> result = new List<Report>();
            try
            {
                long doanhNghiepID = JsonConvert.DeserializeObject<long>(Request.Form["doanhNghiepID"]);
                int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
                int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
                result = await _ReportBusiness.ReportDoanhNghiep004Async(doanhNghiepID, year, month);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("ReportVNPT001Async")]
        public virtual async Task<List<Report>> ReportVNPT001Async()
        {
            List<Report> result = new List<Report>();
            try
            {
                long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
                long xaID = JsonConvert.DeserializeObject<long>(Request.Form["xaID"]);
                string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
                int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
                int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
                result = await _ReportBusiness.ReportVNPT001Async(huyenID, xaID, searchString, year, month);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("ReportVNPT002Async")]
        public virtual async Task<List<Report>> ReportVNPT002Async()
        {
            List<Report> result = new List<Report>();
            try
            {
                long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
                long xaID = JsonConvert.DeserializeObject<long>(Request.Form["xaID"]);
                string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
                long loaiDichVuID = JsonConvert.DeserializeObject<long>(Request.Form["loaiDichVuID"]);
                int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
                int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
                result = await _ReportBusiness.ReportVNPT002Async(huyenID, xaID, searchString, loaiDichVuID, year, month);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("ReportVNPT003Async")]
        public virtual async Task<List<Report>> ReportVNPT003Async()
        {
            List<Report> result = new List<Report>();
            try
            {
                long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
                long xaID = JsonConvert.DeserializeObject<long>(Request.Form["xaID"]);
                string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
                long dichVuID = JsonConvert.DeserializeObject<long>(Request.Form["dichVuID"]);
                int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
                int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
                result = await _ReportBusiness.ReportVNPT003Async(huyenID, xaID, searchString, dichVuID, year, month);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("ReportVNPT004Async")]
        public virtual async Task<List<Report>> ReportVNPT004Async()
        {
            List<Report> result = new List<Report>();
            try
            {
                long phongBanID = JsonConvert.DeserializeObject<long>(Request.Form["phongBanID"]);                              
                int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);                
                result = await _ReportBusiness.ReportVNPT004Async(phongBanID, year);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("ReportVNPT005Async")]
        public virtual async Task<List<Report>> ReportVNPT005Async()
        {
            List<Report> result = new List<Report>();
            try
            {
                long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
                int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
                result = await _ReportBusiness.ReportVNPT005Async(nhanVienID, year);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
		[HttpPost]
		[Route("ReportCA001Async")]
		public virtual async Task<List<Report>> ReportCA001Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				result = await _ReportBusiness.ReportCA001Async(huyenID, year, month);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA002Async")]
		public virtual async Task<List<Report>> ReportCA002Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				result = await _ReportBusiness.ReportCA002Async(huyenID, year, month);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA003Async")]
		public virtual async Task<List<Report>> ReportCA003Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				result = await _ReportBusiness.ReportCA003Async(huyenID, year, month);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA004Async")]
		public virtual async Task<List<Report>> ReportCA004Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				result = await _ReportBusiness.ReportCA004Async(huyenID, year, month);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA005Async")]
		public virtual async Task<List<Report>> ReportCA005Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				result = await _ReportBusiness.ReportCA005Async(huyenID, year, month);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA006Async")]
		public virtual async Task<List<Report>> ReportCA006Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				result = await _ReportBusiness.ReportCA006Async(huyenID, year, month);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA007Async")]
		public virtual async Task<List<Report>> ReportCA007Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				result = await _ReportBusiness.ReportCA007Async(huyenID, year, month);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA101Async")]
		public virtual async Task<List<Report>> ReportCA101Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
				result = await _ReportBusiness.ReportCA101Async(huyenID, year, month, nhanVienID);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA102Async")]
		public virtual async Task<List<Report>> ReportCA102Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
				result = await _ReportBusiness.ReportCA102Async(huyenID, year, month, nhanVienID);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA103Async")]
		public virtual async Task<List<Report>> ReportCA103Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
				result = await _ReportBusiness.ReportCA103Async(huyenID, year, month, nhanVienID);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA104Async")]
		public virtual async Task<List<Report>> ReportCA104Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
				result = await _ReportBusiness.ReportCA104Async(huyenID, year, month, nhanVienID);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA105Async")]
		public virtual async Task<List<Report>> ReportCA105Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
				result = await _ReportBusiness.ReportCA105Async(huyenID, year, month, nhanVienID);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA106Async")]
		public virtual async Task<List<Report>> ReportCA106Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
				result = await _ReportBusiness.ReportCA106Async(huyenID, year, month, nhanVienID);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA107Async")]
		public virtual async Task<List<Report>> ReportCA107Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
				result = await _ReportBusiness.ReportCA107Async(huyenID, year, month, nhanVienID);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA201Async")]
		public virtual async Task<List<Report>> ReportCA201Async()
		{
			List<Report> result = new List<Report>();
			try
			{				
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);				
				result = await _ReportBusiness.ReportCA201Async(year, month);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA202Async")]
		public virtual async Task<List<Report>> ReportCA202Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				result = await _ReportBusiness.ReportCA202Async(year, month);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
	}
}
