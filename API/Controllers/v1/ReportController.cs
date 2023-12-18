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
				int hetHan = JsonConvert.DeserializeObject<int>(Request.Form["hetHan"]);
				result = await _ReportBusiness.ReportCA105Async(huyenID, year, month, nhanVienID, hetHan);
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
		[Route("ReportCA108Async")]
		public virtual async Task<List<Report>> ReportCA108Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
				bool isKetLuan = JsonConvert.DeserializeObject<bool>(Request.Form["isKetLuan"]);
				result = await _ReportBusiness.ReportCA108Async(huyenID, year, month, nhanVienID, isKetLuan);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA201Async")]
		public virtual async Task<Report> ReportCA201Async()
		{
			Report result = new Report();
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
		[HttpPost]
		[Route("ReportCA203Async")]
		public virtual async Task<List<Report>> ReportCA203Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				result = await _ReportBusiness.ReportCA203Async(year, month);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA204Async")]
		public virtual async Task<List<Report>> ReportCA204Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				result = await _ReportBusiness.ReportCA204Async(year, month);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA205Async")]
		public virtual async Task<List<Report>> ReportCA205Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				result = await _ReportBusiness.ReportCA205Async(year, month);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA206Async")]
		public virtual async Task<List<Report>> ReportCA206Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				result = await _ReportBusiness.ReportCA206Async(year, month);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA207Async")]
		public virtual async Task<List<Report>> ReportCA207Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				result = await _ReportBusiness.ReportCA207Async(year, month);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA305Async")]
		public virtual async Task<List<Report>> ReportCA305Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
				result = await _ReportBusiness.ReportCA305Async(huyenID, year, month, nhanVienID);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA306Async")]
		public virtual async Task<List<Report>> ReportCA306Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
				result = await _ReportBusiness.ReportCA306Async(huyenID, year, month, nhanVienID);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA307Async")]
		public virtual async Task<List<Report>> ReportCA307Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
				int hetHan = JsonConvert.DeserializeObject<int>(Request.Form["hetHan"]);
				result = await _ReportBusiness.ReportCA307Async(huyenID, year, month, nhanVienID, hetHan);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA308Async")]
		public virtual async Task<List<Report>> ReportCA308Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
				result = await _ReportBusiness.ReportCA308Async(huyenID, year, month, nhanVienID);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA401Async")]
		public virtual async Task<List<Report>> ReportCA401Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
				bool isSmartCA = JsonConvert.DeserializeObject<bool>(Request.Form["isSmartCA"]);
				result = await _ReportBusiness.ReportCA401Async(huyenID, year, month, nhanVienID, isSmartCA);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA402Async")]
		public virtual async Task<List<Report>> ReportCA402Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
				bool isSmartCA = JsonConvert.DeserializeObject<bool>(Request.Form["isSmartCA"]);
				result = await _ReportBusiness.ReportCA402Async(huyenID, year, month, nhanVienID, isSmartCA);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA403Async")]
		public virtual async Task<List<Report>> ReportCA403Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
				bool isSmartCA = JsonConvert.DeserializeObject<bool>(Request.Form["isSmartCA"]);
				result = await _ReportBusiness.ReportCA403Async(huyenID, year, month, nhanVienID, isSmartCA);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA404Async")]
		public virtual async Task<List<Report>> ReportCA404Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
				bool isSmartCA = JsonConvert.DeserializeObject<bool>(Request.Form["isSmartCA"]);
				result = await _ReportBusiness.ReportCA404Async(huyenID, year, month, nhanVienID, isSmartCA);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA405Async")]
		public virtual async Task<List<Report>> ReportCA405Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
				int hetHan = JsonConvert.DeserializeObject<int>(Request.Form["hetHan"]);
				bool isSmartCA = JsonConvert.DeserializeObject<bool>(Request.Form["isSmartCA"]);
				result = await _ReportBusiness.ReportCA405Async(huyenID, year, month, nhanVienID, hetHan, isSmartCA);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA406Async")]
		public virtual async Task<List<Report>> ReportCA406Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
				bool isSmartCA = JsonConvert.DeserializeObject<bool>(Request.Form["isSmartCA"]);
				result = await _ReportBusiness.ReportCA406Async(huyenID, year, month, nhanVienID, isSmartCA);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA407Async")]
		public virtual async Task<List<Report>> ReportCA407Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
				bool isSmartCA = JsonConvert.DeserializeObject<bool>(Request.Form["isSmartCA"]);
				result = await _ReportBusiness.ReportCA407Async(huyenID, year, month, nhanVienID, isSmartCA);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA408Async")]
		public virtual async Task<List<Report>> ReportCA408Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
				bool isKetLuan = JsonConvert.DeserializeObject<bool>(Request.Form["isKetLuan"]);
				bool isSmartCA = JsonConvert.DeserializeObject<bool>(Request.Form["isSmartCA"]);
				result = await _ReportBusiness.ReportCA408Async(huyenID, year, month, nhanVienID, isKetLuan, isSmartCA);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA501Async")]
		public virtual async Task<Report> ReportCA501Async()
		{
			Report result = new Report();
			try
			{
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				bool isSmartCA = JsonConvert.DeserializeObject<bool>(Request.Form["isSmartCA"]);
				result = await _ReportBusiness.ReportCA501Async(year, month, isSmartCA);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA502Async")]
		public virtual async Task<List<Report>> ReportCA502Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				bool isSmartCA = JsonConvert.DeserializeObject<bool>(Request.Form["isSmartCA"]);
				result = await _ReportBusiness.ReportCA502Async(year, month, isSmartCA);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA503Async")]
		public virtual async Task<List<Report>> ReportCA503Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				bool isSmartCA = JsonConvert.DeserializeObject<bool>(Request.Form["isSmartCA"]);
				result = await _ReportBusiness.ReportCA503Async(year, month, isSmartCA);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA504Async")]
		public virtual async Task<List<Report>> ReportCA504Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				bool isSmartCA = JsonConvert.DeserializeObject<bool>(Request.Form["isSmartCA"]);
				result = await _ReportBusiness.ReportCA504Async(year, month, isSmartCA);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA505Async")]
		public virtual async Task<List<Report>> ReportCA505Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				bool isSmartCA = JsonConvert.DeserializeObject<bool>(Request.Form["isSmartCA"]);
				result = await _ReportBusiness.ReportCA505Async(year, month, isSmartCA);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA506Async")]
		public virtual async Task<List<Report>> ReportCA506Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				bool isSmartCA = JsonConvert.DeserializeObject<bool>(Request.Form["isSmartCA"]);
				result = await _ReportBusiness.ReportCA506Async(year, month, isSmartCA);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA507Async")]
		public virtual async Task<List<Report>> ReportCA507Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				bool isSmartCA = JsonConvert.DeserializeObject<bool>(Request.Form["isSmartCA"]);
				result = await _ReportBusiness.ReportCA507Async(year, month, isSmartCA);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA605Async")]
		public virtual async Task<List<Report>> ReportCA605Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
				bool isSmartCA = JsonConvert.DeserializeObject<bool>(Request.Form["isSmartCA"]);
				result = await _ReportBusiness.ReportCA605Async(huyenID, year, month, nhanVienID, isSmartCA);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA606Async")]
		public virtual async Task<List<Report>> ReportCA606Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
				bool isSmartCA = JsonConvert.DeserializeObject<bool>(Request.Form["isSmartCA"]);
				result = await _ReportBusiness.ReportCA606Async(huyenID, year, month, nhanVienID, isSmartCA);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA607Async")]
		public virtual async Task<List<Report>> ReportCA607Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
				int hetHan = JsonConvert.DeserializeObject<int>(Request.Form["hetHan"]);
				bool isSmartCA = JsonConvert.DeserializeObject<bool>(Request.Form["isSmartCA"]);
				result = await _ReportBusiness.ReportCA607Async(huyenID, year, month, nhanVienID, hetHan, isSmartCA);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCA608Async")]
		public virtual async Task<List<Report>> ReportCA608Async()
		{
			List<Report> result = new List<Report>();
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
				bool isSmartCA = JsonConvert.DeserializeObject<bool>(Request.Form["isSmartCA"]);
				result = await _ReportBusiness.ReportCA608Async(huyenID, year, month, nhanVienID, isSmartCA);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("ReportCASearchStringToListAsync")]
		public virtual async Task<List<Report>> ReportCASearchStringToListAsync()
		{
			List<Report> result = new List<Report>();
			try
			{
				string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);				
				result = await _ReportBusiness.ReportCASearchStringToListAsync(searchString);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
	}
}
