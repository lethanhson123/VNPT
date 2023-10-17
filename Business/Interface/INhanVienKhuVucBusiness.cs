namespace Business.Interface
{
	public interface INhanVienKhuVucBusiness : IBaseBusiness<NhanVienKhuVuc>
	{
        Task<List<NhanVienKhuVuc>> GetSQLByParentIDAsync(long parentID);

    }
}
