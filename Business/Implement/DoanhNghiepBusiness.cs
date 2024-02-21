
using Data.Model;
using System.Drawing.Printing;

namespace Business.Implement
{
	public class DoanhNghiepBusiness : BaseBusiness<DoanhNghiep, IDoanhNghiepRepository>, IDoanhNghiepBusiness
	{
		private readonly IDoanhNghiepRepository _DoanhNghiepRepository;
		public DoanhNghiepBusiness(IDoanhNghiepRepository DoanhNghiepRepository) : base(DoanhNghiepRepository)
		{
			_DoanhNghiepRepository = DoanhNghiepRepository;
		}
		public override void Initialization(DoanhNghiep model)
		{
			if (string.IsNullOrEmpty(model.Code))
			{
				model.Code = GlobalHelper.InitializationDateTimeCode;
			}
			model.Display = model.Name + "-" + model.Code;
			if ((model.SortOrder == null) || (model.SortOrder == GlobalHelper.InitializationNumber))
			{
				model.SortOrder = 1;
			}

			if (!string.IsNullOrEmpty(model.Name))
			{
				model.Name = model.Name.ToUpper();
			}
		}
		public virtual async Task<List<DoanhNghiep>> GetBySearchStringToListAsync(string searchString)
		{
			List<DoanhNghiep> result = new List<DoanhNghiep>();
			if (!string.IsNullOrEmpty(searchString))
			{
				result = await _DoanhNghiepRepository.GetByCondition(item => item.Code.Contains(searchString) || item.CodeCA.Contains(searchString) || item.Name.Contains(searchString) || item.UserName.Contains(searchString)).ToListAsync();
			}
			return result;
		}
		public virtual async Task<List<DoanhNghiep>> GetCABySearchStringToListAsync(string searchString)
		{
			List<DoanhNghiep> result = new List<DoanhNghiep>();
			if (!string.IsNullOrEmpty(searchString))
			{
				SqlParameter[] parameters =
				{
					new SqlParameter("@SearchString",searchString),						
				};
				result = await GetByStoredProcedureToListAsync("sp_DoanhNghiepSelectItemsBySearchString", parameters);				
			}
			return result;
		}
		public virtual async Task<List<DoanhNghiep>> GetByHuyenIDAndXaIDOrSearchStringToListAsync(long huyenID, long xaID, string searchString)
		{
			List<DoanhNghiep> result = new List<DoanhNghiep>();
			if (!string.IsNullOrEmpty(searchString))
			{
				result = await GetBySearchStringToListAsync(searchString);
			}
			else
			{
				if (huyenID > 0)
				{
					if (xaID > 0)
					{
						result = await _DoanhNghiepRepository.GetByCondition(item => item.HuyenID == huyenID && item.XaID == xaID).ToListAsync();
					}
					else
					{
						result = await _DoanhNghiepRepository.GetByCondition(item => item.HuyenID == huyenID).ToListAsync();
					}
				}
				else
				{
					result = await GetAllToListAsync();
				}
			}
			return result;
		}
		public virtual async Task<List<DoanhNghiep>> GetCAByHuyenIDAndXaIDOrSearchStringToListAsync(long huyenID, long xaID, string searchString)
		{
			List<DoanhNghiep> result = new List<DoanhNghiep>();
			if (!string.IsNullOrEmpty(searchString))
			{
				result = await GetCABySearchStringToListAsync(searchString);
			}
			else
			{
				if (huyenID > 0)
				{
					if (xaID > 0)
					{
						result = await _DoanhNghiepRepository.GetByCondition(item => item.HuyenID == huyenID && item.XaID == xaID && !string.IsNullOrEmpty(item.UserName)).ToListAsync();
					}
					else
					{
						result = await _DoanhNghiepRepository.GetByCondition(item => item.HuyenID == huyenID && !string.IsNullOrEmpty(item.UserName)).ToListAsync();
					}
				}
				else
				{
					result = await _DoanhNghiepRepository.GetByCondition(item => !string.IsNullOrEmpty(item.UserName)).ToListAsync();
				}
			}
			return result;
		}
		public virtual async Task<List<DoanhNghiep>> GetByNhanVienIDOrSearchStringToListAsync(long nhanVienID, string searchString)
		{
			List<DoanhNghiep> result = new List<DoanhNghiep>();
			if (!string.IsNullOrEmpty(searchString))
			{
				result = await GetBySearchStringToListAsync(searchString);
			}
			else
			{
				if (nhanVienID > 0)
				{
					result = await _DoanhNghiepRepository.GetByCondition(item => item.NhanVienID == nhanVienID).ToListAsync();
				}
			}
			return result;
		}
		public virtual async Task<List<DoanhNghiep>> GetByPhongBanIDOrSearchStringToListAsync(long phongBanID, string searchString)
		{
			List<DoanhNghiep> result = new List<DoanhNghiep>();
			if (!string.IsNullOrEmpty(searchString))
			{
				result = await GetBySearchStringToListAsync(searchString);
			}
			else
			{
				if (phongBanID > 0)
				{
					result = await _DoanhNghiepRepository.GetByCondition(item => item.PhongBanID == phongBanID).ToListAsync();
				}
			}
			return result;
		}
		public virtual async Task<List<DoanhNghiep>> GetMaSoThueKhongTonTaiToListAsync()
		{
			List<DoanhNghiep> result = new List<DoanhNghiep>();
			result = await _DoanhNghiepRepository.GetByCondition(item => item.Code == item.KHACHHANG_ID).OrderBy(item => item.HuyenID).ToListAsync();
			return result;
		}
		public virtual async Task<List<DoanhNghiepTranfer>> GetSQLBySearchString_HuyenIDToListTranferAsync(string searchString, long huyenID)
		{
			List<DoanhNghiepTranfer> result = new List<DoanhNghiepTranfer>();			
				SqlParameter[] parameters =
				 {
					new SqlParameter("@SearchString",searchString),
					new SqlParameter("@HuyenID",huyenID),
				};
				result = await _DoanhNghiepRepository.GetByStoredProcedureToListTranferAsync("sp_DoanhNghiepSelectItemsBySearchString_HuyenID", parameters);			
			return result;
		}
	}
}
