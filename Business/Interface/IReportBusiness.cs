namespace Business.Interface
{
	public interface IReportBusiness : IBaseBusiness<Report>
	{
        Task<List<Report>> Report001Async(long doanhNghiepID);
        Task<List<Report>> Report002Async(long doanhNghiepID);
        Task<List<Report>> Report003Async(long doanhNghiepID);
        Task<List<Report>> Report004Async(long huyenID, long xaID, string searchString);
        Task<List<Report>> ReportDoanhNghiep001Async(long doanhNghiepID, int year, int month);
        Task<List<Report>> ReportDoanhNghiep002Async(long doanhNghiepID, int year, int month);
        Task<List<Report>> ReportDoanhNghiep003Async(long doanhNghiepID, int year, int month);
        Task<List<Report>> ReportDoanhNghiep004Async(long doanhNghiepID, int year, int month);
        Task<List<Report>> ReportVNPT001Async(long huyenID, long xaID, string searchString, int year, int month);
        Task<List<Report>> ReportVNPT002Async(long huyenID, long xaID, string searchString, long loaiDichVuID, int year, int month);
        Task<List<Report>> ReportVNPT003Async(long huyenID, long xaID, string searchString, long dichVuID, int year, int month);
        Task<List<Report>> ReportVNPT004Async(long phongBanID, int year);
        Task<List<Report>> ReportVNPT005Async(long nhanVienID, int year);
        Task<List<Report>> ReportCA001Async(long huyenID, int year, int month);
		Task<List<Report>> ReportCA002Async(long huyenID, int year, int month);
		Task<List<Report>> ReportCA003Async(long huyenID, int year, int month);
		Task<List<Report>> ReportCA004Async(long huyenID, int year, int month);
		Task<List<Report>> ReportCA005Async(long huyenID, int year, int month);
		Task<List<Report>> ReportCA006Async(long huyenID, int year, int month);
		Task<List<Report>> ReportCA007Async(long huyenID, int year, int month);	

	}
}
