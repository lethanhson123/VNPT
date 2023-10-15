namespace Business.Interface
{
	public interface IReportBusiness : IBaseBusiness<Report>
	{
        Task<List<Report>> Report001Async(long doanhNghiepID);
        Task<List<Report>> Report002Async(long doanhNghiepID);
        Task<List<Report>> Report003Async(long doanhNghiepID);
        Task<List<Report>> Report004Async(long huyenID, long xaID, string searchString);

    }
}
