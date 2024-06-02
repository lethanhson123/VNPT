namespace Business.Interface
{
	public interface IEmailLichSuBusiness : IBaseBusiness<EmailLichSu>
	{
        string UpdateSQLByID(long ID);
        Task<List<EmailLichSu>> GetBySearchString_BatDau_KetThucToListAsync(string SearchString, DateTime BatDau, DateTime KetThuc);
    }
}
