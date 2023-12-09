namespace Business.Implement
{
	public class ReportBusiness : BaseBusiness<Report, IReportRepository>, IReportBusiness
	{
		private readonly IReportRepository _ReportRepository;
		public ReportBusiness(IReportRepository ReportRepository) : base(ReportRepository)
		{
			_ReportRepository = ReportRepository;
		}
		public virtual async Task<List<Report>> Report001Async(long doanhNghiepID)
		{
			List<Report> result = new List<Report>();
			if (doanhNghiepID > 0)
			{
				SqlParameter[] parameters =
				 {
					new SqlParameter("@DoanhNghiepID",doanhNghiepID),
				};
				result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_Report001", parameters);
			}
			return result;
		}
		public virtual async Task<List<Report>> Report002Async(long doanhNghiepID)
		{
			List<Report> result = new List<Report>();
			if (doanhNghiepID > 0)
			{
				SqlParameter[] parameters =
				 {
					new SqlParameter("@DoanhNghiepID",doanhNghiepID),
				};
				result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_Report002", parameters);
			}
			return result;
		}
		public virtual async Task<List<Report>> Report003Async(long doanhNghiepID)
		{
			List<Report> result = new List<Report>();
			if (doanhNghiepID > 0)
			{
				SqlParameter[] parameters =
				 {
					new SqlParameter("@DoanhNghiepID",doanhNghiepID),
				};
				result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_Report003", parameters);
			}
			return result;
		}
		public virtual async Task<List<Report>> Report004Async(long huyenID, long xaID, string searchString)
		{
			List<Report> result = new List<Report>();

			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@XaID",xaID),
					new SqlParameter("@SearchString",searchString),
					new SqlParameter("@Year",GlobalHelper.InitializationDateTime.Year),
					new SqlParameter("@Month",GlobalHelper.InitializationDateTime.Month - 1),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_Report004", parameters);

			return result;
		}
		public virtual async Task<List<Report>> ReportDoanhNghiep001Async(long doanhNghiepID, int year, int month)
		{
			List<Report> result = new List<Report>();
			if (doanhNghiepID > 0)
			{
				SqlParameter[] parameters =
				 {
					new SqlParameter("@DoanhNghiepID",doanhNghiepID),
					new SqlParameter("@Year",year),
					new SqlParameter("@Month",month),
				};
				result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportDoanhNghiep001", parameters);
			}
			return result;
		}
		public virtual async Task<List<Report>> ReportDoanhNghiep002Async(long doanhNghiepID, int year, int month)
		{
			List<Report> result = new List<Report>();
			if (doanhNghiepID > 0)
			{
				SqlParameter[] parameters =
				 {
					new SqlParameter("@DoanhNghiepID",doanhNghiepID),
					new SqlParameter("@Year",year),
					new SqlParameter("@Month",month),
				};
				result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportDoanhNghiep002", parameters);
			}
			return result;
		}
		public virtual async Task<List<Report>> ReportDoanhNghiep003Async(long doanhNghiepID, int year, int month)
		{
			List<Report> result = new List<Report>();
			if (doanhNghiepID > 0)
			{
				SqlParameter[] parameters =
				 {
					new SqlParameter("@DoanhNghiepID",doanhNghiepID),
					new SqlParameter("@Year",year),
					new SqlParameter("@Month",month),
				};
				result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportDoanhNghiep003", parameters);
			}
			return result;
		}
		public virtual async Task<List<Report>> ReportDoanhNghiep004Async(long doanhNghiepID, int year, int month)
		{
			List<Report> result = new List<Report>();
			if (doanhNghiepID > 0)
			{
				SqlParameter[] parameters =
				 {
					new SqlParameter("@DoanhNghiepID",doanhNghiepID),
					new SqlParameter("@Year",year),
					new SqlParameter("@Month",month),
				};
				result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportDoanhNghiep004", parameters);
			}
			return result;
		}
		public virtual async Task<List<Report>> ReportVNPT001Async(long huyenID, long xaID, string searchString, int year, int month)
		{
			List<Report> result = new List<Report>();

			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@XaID",xaID),
					new SqlParameter("@SearchString",searchString),
					new SqlParameter("@Year",year),
					new SqlParameter("@Month",month),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportVNPT001", parameters);

			return result;
		}
		public virtual async Task<List<Report>> ReportVNPT002Async(long huyenID, long xaID, string searchString, long loaiDichVuID, int year, int month)
		{
			List<Report> result = new List<Report>();

			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@XaID",xaID),
					new SqlParameter("@SearchString",searchString),
					new SqlParameter("@LoaiDichVuID",loaiDichVuID),
					new SqlParameter("@Year",year),
					new SqlParameter("@Month",month),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportVNPT002", parameters);

			return result;
		}
		public virtual async Task<List<Report>> ReportVNPT003Async(long huyenID, long xaID, string searchString, long dichVuID, int year, int month)
		{
			List<Report> result = new List<Report>();

			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@XaID",xaID),
					new SqlParameter("@SearchString",searchString),
					new SqlParameter("@DichVuID",dichVuID),
					new SqlParameter("@Year",year),
					new SqlParameter("@Month",month),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportVNPT003", parameters);

			return result;
		}
		public virtual async Task<List<Report>> ReportVNPT004Async(long phongBanID, int year)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@PhongBanID",phongBanID),
					new SqlParameter("@Year",year),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportVNPT004", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportVNPT005Async(long nhanVienID, int year)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@NhanVienID",nhanVienID),
					new SqlParameter("@Year",year),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportVNPT005", parameters);
			return result;
		}

		public virtual async Task<List<Report>> ReportCA001Async(long huyenID, int year, int month)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA001", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA002Async(long huyenID, int year, int month)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA002", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA003Async(long huyenID, int year, int month)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA003", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA004Async(long huyenID, int year, int month)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA004", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA005Async(long huyenID, int year, int month)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA005", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA006Async(long huyenID, int year, int month)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA006", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA007Async(long huyenID, int year, int month)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA007", parameters);
			return result;
		}

		public virtual async Task<List<Report>> ReportCA101Async(long huyenID, int year, int month, long nhanVienID)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
					new SqlParameter("@NhanVienID", nhanVienID),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA101", parameters);
			return result;
		}

		public virtual async Task<List<Report>> ReportCA102Async(long huyenID, int year, int month, long nhanVienID)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
					new SqlParameter("@NhanVienID", nhanVienID),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA102", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA103Async(long huyenID, int year, int month, long nhanVienID)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
					new SqlParameter("@NhanVienID", nhanVienID),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA103", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA104Async(long huyenID, int year, int month, long nhanVienID)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
					new SqlParameter("@NhanVienID", nhanVienID),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA104", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA105Async(long huyenID, int year, int month, long nhanVienID)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
					new SqlParameter("@NhanVienID", nhanVienID),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA105", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA106Async(long huyenID, int year, int month, long nhanVienID)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
					new SqlParameter("@NhanVienID", nhanVienID),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA106", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA107Async(long huyenID, int year, int month, long nhanVienID)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
					new SqlParameter("@NhanVienID", nhanVienID),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA107", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA108Async(long huyenID, int year, int month, long nhanVienID, bool isKetLuan)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
					new SqlParameter("@NhanVienID", nhanVienID),
					new SqlParameter("@IsKetLuan", isKetLuan),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA108", parameters);
			return result;
		}
		public virtual async Task<Report> ReportCA201Async(int year, int month)
		{
			Report result = new Report();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
				};
			List<Report> list = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA201", parameters);
			if (list.Count > 0)
			{
				result = list[0];
			}
			return result;
		}
		public virtual async Task<List<Report>> ReportCA202Async(int year, int month)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA202", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA203Async(int year, int month)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA203", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA204Async(int year, int month)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA204", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA205Async(int year, int month)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA205", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA206Async(int year, int month)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA206", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA207Async(int year, int month)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA207", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA305Async(long huyenID, int year, int month, long nhanVienID)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
					new SqlParameter("@NhanVienID", nhanVienID),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA305", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA306Async(long huyenID, int year, int month, long nhanVienID)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
					new SqlParameter("@NhanVienID", nhanVienID),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA306", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA307Async(long huyenID, int year, int month, long nhanVienID)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
					new SqlParameter("@NhanVienID", nhanVienID),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA307", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA308Async(long huyenID, int year, int month, long nhanVienID)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
					new SqlParameter("@NhanVienID", nhanVienID),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA308", parameters);
			return result;
		}

		public virtual async Task<List<Report>> ReportCA401Async(long huyenID, int year, int month, long nhanVienID, bool isSmartCA)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
					new SqlParameter("@NhanVienID", nhanVienID),
					new SqlParameter("@IsSmartCA", isSmartCA),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA401", parameters);
			return result;
		}

		public virtual async Task<List<Report>> ReportCA402Async(long huyenID, int year, int month, long nhanVienID, bool isSmartCA)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
					new SqlParameter("@NhanVienID", nhanVienID),
					new SqlParameter("@IsSmartCA", isSmartCA),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA402", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA403Async(long huyenID, int year, int month, long nhanVienID, bool isSmartCA)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
					new SqlParameter("@NhanVienID", nhanVienID),
					new SqlParameter("@IsSmartCA", isSmartCA),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA403", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA404Async(long huyenID, int year, int month, long nhanVienID, bool isSmartCA)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
					new SqlParameter("@NhanVienID", nhanVienID),
					new SqlParameter("@IsSmartCA", isSmartCA),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA404", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA405Async(long huyenID, int year, int month, long nhanVienID, bool isSmartCA)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
					new SqlParameter("@NhanVienID", nhanVienID),
					new SqlParameter("@IsSmartCA", isSmartCA),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA405", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA406Async(long huyenID, int year, int month, long nhanVienID, bool isSmartCA)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
					new SqlParameter("@NhanVienID", nhanVienID),
					new SqlParameter("@IsSmartCA", isSmartCA),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA406", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA407Async(long huyenID, int year, int month, long nhanVienID, bool isSmartCA)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
					new SqlParameter("@NhanVienID", nhanVienID),
					new SqlParameter("@IsSmartCA", isSmartCA),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA407", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA408Async(long huyenID, int year, int month, long nhanVienID, bool isKetLuan, bool isSmartCA)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
					new SqlParameter("@NhanVienID", nhanVienID),
					new SqlParameter("@IsKetLuan", isKetLuan),
					new SqlParameter("@IsSmartCA", isSmartCA),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA408", parameters);
			return result;
		}
		public virtual async Task<Report> ReportCA501Async(int year, int month, bool isSmartCA)
		{
			Report result = new Report();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
					new SqlParameter("@IsSmartCA", isSmartCA),
				};
			List<Report> list = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA501", parameters);
			if (list.Count > 0)
			{
				result = list[0];
			}
			return result;
		}
		public virtual async Task<List<Report>> ReportCA502Async(int year, int month, bool isSmartCA)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
					new SqlParameter("@IsSmartCA", isSmartCA),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA502", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA503Async(int year, int month, bool isSmartCA)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
					new SqlParameter("@IsSmartCA", isSmartCA),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA503", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA504Async(int year, int month, bool isSmartCA)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
					new SqlParameter("@IsSmartCA", isSmartCA),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA504", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA505Async(int year, int month, bool isSmartCA)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
					new SqlParameter("@IsSmartCA", isSmartCA),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA505", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA506Async(int year, int month, bool isSmartCA)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
					new SqlParameter("@IsSmartCA", isSmartCA),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA506", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA507Async(int year, int month, bool isSmartCA)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
					new SqlParameter("@IsSmartCA", isSmartCA),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA507", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA605Async(long huyenID, int year, int month, long nhanVienID, bool isSmartCA)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
					new SqlParameter("@NhanVienID", nhanVienID),
					new SqlParameter("@IsSmartCA", isSmartCA),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA605", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA606Async(long huyenID, int year, int month, long nhanVienID, bool isSmartCA)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
					new SqlParameter("@NhanVienID", nhanVienID),
					new SqlParameter("@IsSmartCA", isSmartCA),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA606", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA607Async(long huyenID, int year, int month, long nhanVienID, bool isSmartCA)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
					new SqlParameter("@NhanVienID", nhanVienID),
					new SqlParameter("@IsSmartCA", isSmartCA),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA607", parameters);
			return result;
		}
		public virtual async Task<List<Report>> ReportCA608Async(long huyenID, int year, int month, long nhanVienID, bool isSmartCA)
		{
			List<Report> result = new List<Report>();
			SqlParameter[] parameters =
			 {
					new SqlParameter("@HuyenID",huyenID),
					new SqlParameter("@Year", year),
					new SqlParameter("@Month", month),
					new SqlParameter("@NhanVienID", nhanVienID),
					new SqlParameter("@IsSmartCA", isSmartCA),
				};
			result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_ReportCA608", parameters);
			return result;
		}
	}
}
