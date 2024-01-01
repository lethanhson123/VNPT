using Data.Model;
using System.Collections.Generic;

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DoanhNghiepController : BaseController<DoanhNghiep, IDoanhNghiepBusiness>
    {
        private readonly IDoanhNghiepBusiness _DoanhNghiepBusiness;
        public DoanhNghiepController(IDoanhNghiepBusiness DoanhNghiepBusiness) : base(DoanhNghiepBusiness)
        {
            _DoanhNghiepBusiness = DoanhNghiepBusiness;
        }
        [HttpPost]
        [Route("GetBySearchStringToListAsync")]
        public virtual async Task<List<DoanhNghiep>> GetBySearchStringToListAsync()
        {
            List<DoanhNghiep> result = new List<DoanhNghiep>();
            try
            {                
                string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
                result = await _DoanhNghiepBusiness.GetBySearchStringToListAsync(searchString);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("GetByHuyenIDAndXaIDOrSearchStringToListAsync")]
        public virtual async Task<List<DoanhNghiep>> GetByHuyenIDAndXaIDOrSearchStringToListAsync()
        {
            List<DoanhNghiep> result = new List<DoanhNghiep>();
            try
            {
                long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
                long xaID = JsonConvert.DeserializeObject<long>(Request.Form["xaID"]);
                string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
                result = await _DoanhNghiepBusiness.GetByHuyenIDAndXaIDOrSearchStringToListAsync(huyenID, xaID, searchString);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
		[HttpPost]
		[Route("GetCAByHuyenIDAndXaIDOrSearchStringToListAsync")]
		public virtual async Task<List<DoanhNghiep>> GetCAByHuyenIDAndXaIDOrSearchStringToListAsync()
		{
			List<DoanhNghiep> result = new List<DoanhNghiep>();
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				long xaID = JsonConvert.DeserializeObject<long>(Request.Form["xaID"]);
				string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
				result = await _DoanhNghiepBusiness.GetCAByHuyenIDAndXaIDOrSearchStringToListAsync(huyenID, xaID, searchString);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
        [Route("GetByNhanVienIDOrSearchStringToListAsync")]
        public virtual async Task<List<DoanhNghiep>> GetByNhanVienIDOrSearchStringToListAsync()
        {
            List<DoanhNghiep> result = new List<DoanhNghiep>();
            try
            {
                long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);                
                string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
                result = await _DoanhNghiepBusiness.GetByNhanVienIDOrSearchStringToListAsync(nhanVienID, searchString);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("GetByPhongBanIDOrSearchStringToListAsync")]
        public virtual async Task<List<DoanhNghiep>> GetByPhongBanIDOrSearchStringToListAsync()
        {
            List<DoanhNghiep> result = new List<DoanhNghiep>();
            try
            {
                long phongBanID = JsonConvert.DeserializeObject<long>(Request.Form["phongBanID"]);
                string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
                result = await _DoanhNghiepBusiness.GetByPhongBanIDOrSearchStringToListAsync(phongBanID, searchString);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
		[HttpPost]
		[Route("GetMaSoThueKhongTonTaiToListAsync")]
		public virtual async Task<List<DoanhNghiep>> GetMaSoThueKhongTonTaiToListAsync()
		{
			List<DoanhNghiep> result = new List<DoanhNghiep>();
			try
			{				
				result = await _DoanhNghiepBusiness.GetMaSoThueKhongTonTaiToListAsync();
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpGet]
        [Route("GetByIDStringAsync")]
        public async Task<DoanhNghiep> GetByIDStringAsync(string ID)
        {
            DoanhNghiep result = new DoanhNghiep();
            if (!string.IsNullOrEmpty(ID))
            {
                ID = GlobalHelper.InitializationURLCode(ID);
                result = await _DoanhNghiepBusiness.GetByIDAsync(int.Parse(ID));
            }
            return result;
        }
    }
}
