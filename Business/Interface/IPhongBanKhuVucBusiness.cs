namespace Business.Interface
{
	public interface IPhongBanKhuVucBusiness : IBaseBusiness<PhongBanKhuVuc>
	{
        Task<List<PhongBanKhuVuc>> GetSQLByParentIDAsync(long parentID);

    }
}
