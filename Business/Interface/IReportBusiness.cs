using Data.Model;

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

		Task<List<Report>> ReportCA101Async(long huyenID, int year, int month, long nhanVienID);
		Task<List<Report>> ReportCA102Async(long huyenID, int year, int month, long nhanVienID);
		Task<List<Report>> ReportCA103Async(long huyenID, int year, int month, long nhanVienID);
		Task<List<Report>> ReportCA104Async(long huyenID, int year, int month, long nhanVienID);
		Task<List<Report>> ReportCA105Async(long huyenID, int year, int month, long nhanVienID, int hetHan);
		Task<List<Report>> ReportCA106Async(long huyenID, int year, int month, long nhanVienID);
		Task<List<Report>> ReportCA107Async(long huyenID, int year, int month, long nhanVienID);
		Task<List<Report>> ReportCA108Async(long huyenID, int year, int month, long nhanVienID, bool isKetLuan);

		Task<Report> ReportCA201Async(int year, int month);
		Task<List<Report>> ReportCA202Async(int year, int month);
		Task<List<Report>> ReportCA203Async(int year, int month);
		Task<List<Report>> ReportCA204Async(int year, int month);
		Task<List<Report>> ReportCA205Async(int year, int month);
		Task<List<Report>> ReportCA206Async(int year, int month);
		Task<List<Report>> ReportCA207Async(int year, int month);

		Task<List<Report>> ReportCA305Async(long huyenID, int year, int month, long nhanVienID);
		Task<List<Report>> ReportCA306Async(long huyenID, int year, int month, long nhanVienID);
		Task<List<Report>> ReportCA307Async(long huyenID, int year, int month, long nhanVienID, int hetHan);
		Task<List<Report>> ReportCA308Async(long huyenID, int year, int month, long nhanVienID);


		Task<List<Report>> ReportCA401Async(long huyenID, int year, int month, long nhanVienID, bool isSmartCA);
		Task<List<Report>> ReportCA402Async(long huyenID, int year, int month, long nhanVienID, bool isSmartCA);
		Task<List<Report>> ReportCA403Async(long huyenID, int year, int month, long nhanVienID, bool isSmartCA);
		Task<List<Report>> ReportCA404Async(long huyenID, int year, int month, long nhanVienID, bool isSmartCA);
		Task<List<Report>> ReportCA405Async(long huyenID, int year, int month, long nhanVienID, int hetHan, bool isSmartCA);
		Task<List<Report>> ReportCA406Async(long huyenID, int year, int month, long nhanVienID, bool isSmartCA);
		Task<List<Report>> ReportCA407Async(long huyenID, int year, int month, long nhanVienID, bool isSmartCA);
		Task<List<Report>> ReportCA408Async(long huyenID, int year, int month, long nhanVienID, bool isKetLuan, bool isSmartCA);

		Task<Report> ReportCA501Async(int year, int month, bool isSmartCA);
		Task<List<Report>> ReportCA502Async(int year, int month, bool isSmartCA);
		Task<List<Report>> ReportCA503Async(int year, int month, bool isSmartCA);
		Task<List<Report>> ReportCA504Async(int year, int month, bool isSmartCA);
		Task<List<Report>> ReportCA505Async(int year, int month, bool isSmartCA);
		Task<List<Report>> ReportCA506Async(int year, int month, bool isSmartCA);
		Task<List<Report>> ReportCA507Async(int year, int month, bool isSmartCA);

		Task<List<Report>> ReportCA605Async(long huyenID, int year, int month, long nhanVienID, bool isSmartCA);
		Task<List<Report>> ReportCA606Async(long huyenID, int year, int month, long nhanVienID, bool isSmartCA);
		Task<List<Report>> ReportCA607Async(long huyenID, int year, int month, long nhanVienID, int hetHan, bool isSmartCA);
		Task<List<Report>> ReportCA608Async(long huyenID, int year, int month, long nhanVienID, bool isSmartCA);

		Task<List<Report>> ReportCASearchStringToListAsync(string searchString);

	}
}
