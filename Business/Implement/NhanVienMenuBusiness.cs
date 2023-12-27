
namespace Business.Implement
{
    public class NhanVienMenuBusiness : BaseBusiness<NhanVienMenu, INhanVienMenuRepository>, INhanVienMenuBusiness
    {
        private readonly INhanVienMenuRepository _NhanVienMenuRepository;
        public NhanVienMenuBusiness(INhanVienMenuRepository NhanVienMenuRepository) : base(NhanVienMenuRepository)
        {
            _NhanVienMenuRepository = NhanVienMenuRepository;
        }
		public override async Task<List<NhanVienMenu>> GetByParentIDToListAsync(long parentID)
		{
			List<NhanVienMenu> result = new List<NhanVienMenu>();
			if (parentID > 0)
			{
				SqlParameter[] parameters =
				 {
					new SqlParameter("@ParentID",parentID),
				};
				result = await _NhanVienMenuRepository.GetByStoredProcedureToListAsync("sp_NhanVienMenuSelectItemsByParentID", parameters);
			}
			return result;
		}
	}
}
