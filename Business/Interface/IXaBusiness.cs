namespace Business.Interface
{
	public interface IXaBusiness : IBaseBusiness<Xa>
	{
		Task<List<Xa>> GetSQLByNhanVienID_ActiveAsync(long nhanVienID = 0, bool active = true);
	}
}
