namespace Business.Interface
{
	public interface IMenuBusiness : IBaseBusiness<Menu>
	{
		Task<List<Menu>> GetByNhanVienIDToListAsync(long nhanVienID);
		Task<List<Menu>> GetSQLByNhanVienIDAndActiveToListAsync(long nhanVienID, bool active);
	}
}
