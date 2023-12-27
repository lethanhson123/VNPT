
namespace Business.Implement
{
	public class MenuBusiness : BaseBusiness<Menu, IMenuRepository>, IMenuBusiness
	{
		private readonly IMenuRepository _MenuRepository;
		private readonly INhanVienMenuBusiness _NhanVienMenuBusiness;
		public MenuBusiness(IMenuRepository MenuRepository, INhanVienMenuBusiness nhanVienMenuBusiness) : base(MenuRepository)
		{
			_MenuRepository = MenuRepository;
			_NhanVienMenuBusiness = nhanVienMenuBusiness;
		}
		public virtual async Task<List<Menu>> GetByNhanVienIDToListAsync(long nhanVienID)
		{
			List<Menu> result = new List<Menu>();
			if (nhanVienID > 0)
			{
				List<NhanVienMenu> listNhanVienMenu = await _NhanVienMenuBusiness.GetByParentIDAndActiveToListAsync(nhanVienID, true);
				if (listNhanVienMenu.Count > 0)
				{
					List<long> listNhanVienMenuMenuID = listNhanVienMenu.Select(item => item.MenuID.Value).ToList();
					result = await _MenuRepository.GetByCondition(item => listNhanVienMenuMenuID.Contains(item.ID)).ToListAsync();
				}
			}
			return result;
		}
	}
}
