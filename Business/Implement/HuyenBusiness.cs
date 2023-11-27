
namespace Business.Implement
{
	public class HuyenBusiness : BaseBusiness<Huyen, IHuyenRepository>, IHuyenBusiness
	{
		private readonly IHuyenRepository _HuyenRepository;
		public HuyenBusiness(IHuyenRepository HuyenRepository) : base(HuyenRepository)
		{
			_HuyenRepository = HuyenRepository;
		}
		public virtual async Task<List<Huyen>> GetSQLByNhanVienID_ActiveAsync(long nhanVienID = 0, bool active = true)
		{
			List<Huyen> result = new List<Huyen>();
			if (nhanVienID > 0)
			{
				SqlParameter[] parameters =
				 {
					new SqlParameter("@NhanVienID",nhanVienID),
					new SqlParameter("@Active",active),
				};
				result = await _HuyenRepository.GetByStoredProcedureToListAsync("sp_HuyenSelectItemsByNhanVienIDAndActive", parameters);
			}
			return result;
		}
	}
}
