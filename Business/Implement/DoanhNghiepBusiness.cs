
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

		public virtual async Task<List<DoanhNghiep>> GetBySearchStringToListAsync(string searchString)
		{
			List<DoanhNghiep> result = new List<DoanhNghiep>();
			if (!string.IsNullOrEmpty(searchString))
			{
				result = await _DoanhNghiepRepository.GetByCondition(item => item.Code.Contains(searchString) || item.CodeCA.Contains(searchString) || item.Name.Contains(searchString) || item.UserName.Contains(searchString)).ToListAsync();
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
					result = await _DoanhNghiepRepository.GetByCondition(item => !string.IsNullOrEmpty(item.UserName)).Skip(0 * 20).Take(20).ToListAsync();
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
	}
}
