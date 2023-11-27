namespace Business.Interface
{
	public interface IHuyenBusiness : IBaseBusiness<Huyen>
	{
		Task<List<Huyen>> GetSQLByNhanVienID_ActiveAsync(long nhanVienID = 0, bool active = true);
	}
}
