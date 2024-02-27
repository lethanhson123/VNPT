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
			BaseParameter baseParameter = new BaseParameter();
			List<DoanhNghiep> result = new List<DoanhNghiep>();
			DoanhNghiep itemResult = new DoanhNghiep();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _DoanhNghiepBusiness.GetBySearchStringToListAsync(baseParameter.SearchString);					
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
				result = new List<DoanhNghiep>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("GetByHuyenIDAndXaIDOrSearchStringToListAsync")]
		public virtual async Task<List<DoanhNghiep>> GetByHuyenIDAndXaIDOrSearchStringToListAsync()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<DoanhNghiep> result = new List<DoanhNghiep>();
			DoanhNghiep itemResult = new DoanhNghiep();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _DoanhNghiepBusiness.GetByHuyenIDAndXaIDOrSearchStringToListAsync(baseParameter.HuyenID.Value, baseParameter.XaID.Value, baseParameter.SearchString);					
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
				result = new List<DoanhNghiep>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("GetCAByHuyenIDAndXaIDOrSearchStringToListAsync")]
		public virtual async Task<List<DoanhNghiep>> GetCAByHuyenIDAndXaIDOrSearchStringToListAsync()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<DoanhNghiep> result = new List<DoanhNghiep>();
			DoanhNghiep itemResult = new DoanhNghiep();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _DoanhNghiepBusiness.GetCAByHuyenIDAndXaIDOrSearchStringToListAsync(baseParameter.HuyenID.Value, baseParameter.XaID.Value, baseParameter.SearchString);					
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
				result = new List<DoanhNghiep>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("GetByNhanVienIDOrSearchStringToListAsync")]
		public virtual async Task<List<DoanhNghiep>> GetByNhanVienIDOrSearchStringToListAsync()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<DoanhNghiep> result = new List<DoanhNghiep>();
			DoanhNghiep itemResult = new DoanhNghiep();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _DoanhNghiepBusiness.GetByNhanVienIDOrSearchStringToListAsync(baseParameter.NhanVienID.Value, baseParameter.SearchString);					
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
				result = new List<DoanhNghiep>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("GetByPhongBanIDOrSearchStringToListAsync")]
		public virtual async Task<List<DoanhNghiep>> GetByPhongBanIDOrSearchStringToListAsync()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<DoanhNghiep> result = new List<DoanhNghiep>();
			DoanhNghiep itemResult = new DoanhNghiep();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _DoanhNghiepBusiness.GetByPhongBanIDOrSearchStringToListAsync(baseParameter.PhongBanID.Value, baseParameter.SearchString);					
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
				result = new List<DoanhNghiep>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("GetMaSoThueKhongTonTaiToListAsync")]
		public virtual async Task<List<DoanhNghiep>> GetMaSoThueKhongTonTaiToListAsync()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<DoanhNghiep> result = new List<DoanhNghiep>();
			DoanhNghiep itemResult = new DoanhNghiep();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _DoanhNghiepBusiness.GetMaSoThueKhongTonTaiToListAsync();					
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
				result = new List<DoanhNghiep>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("GetByIDStringAsync")]
		public async Task<DoanhNghiep> GetByIDStringAsync()
		{
			BaseParameter baseParameter = new BaseParameter();
			DoanhNghiep result = new DoanhNghiep();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					if (!string.IsNullOrEmpty(baseParameter.IDString))
					{
						baseParameter.IDString = GlobalHelper.InitializationURLCode(baseParameter.IDString);
						baseParameter.ID = int.Parse(baseParameter.IDString);
						result = await _DoanhNghiepBusiness.GetByIDAsync(baseParameter.ID);
					}					
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
		[Route("GetSQLBySearchString_HuyenIDToListTranferAsync")]
		public virtual async Task<List<DoanhNghiepTranfer>> GetSQLBySearchString_HuyenIDToListTranferAsync()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<DoanhNghiepTranfer> result = new List<DoanhNghiepTranfer>();
			DoanhNghiepTranfer itemResult = new DoanhNghiepTranfer();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _DoanhNghiepBusiness.GetSQLBySearchString_HuyenIDToListTranferAsync(baseParameter.SearchString, baseParameter.HuyenID.Value);					
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
				result = new List<DoanhNghiepTranfer>();
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
