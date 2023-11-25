using Data.Model;

namespace Business.Implement
{
	public class DichVuChiTieuBusiness : BaseBusiness<DichVuChiTieu, IDichVuChiTieuRepository>
	, IDichVuChiTieuBusiness
	{
		private readonly IDichVuChiTieuRepository _DichVuChiTieuRepository;
		public DichVuChiTieuBusiness(IDichVuChiTieuRepository DichVuChiTieuRepository) : base(DichVuChiTieuRepository)
		{
			_DichVuChiTieuRepository = DichVuChiTieuRepository;
		}
		public virtual async Task<List<DichVuChiTieu>> GetByNam_ThangToListAsync(int nam, int thang)
		{
			List<DichVuChiTieu> result = new List<DichVuChiTieu>();
			if (nam > 0)
			{
				SqlParameter[] parameters =
				 {
					new SqlParameter("@Nam",nam),
					new SqlParameter("@Thang",thang),
				};
				result = await _DichVuChiTieuRepository.GetByStoredProcedureToListAsync("sp_DichVuChiTieuSelectItemsByNam_Thang", parameters);
			}			
			return result;
		}
	}
}

