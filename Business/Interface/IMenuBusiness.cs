namespace Business.Interface
{
	public interface IMenuBusiness : IBaseBusiness<Menu>
	{
		Task<List<Menu>> GetByNhanVienIDToListAsync(long nhanVienID);
	}
}
