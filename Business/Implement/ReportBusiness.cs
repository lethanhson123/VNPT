
using Data.Model;

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
    }
}
