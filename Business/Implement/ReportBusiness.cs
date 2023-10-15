
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
                    new SqlParameter("@Month",GlobalHelper.InitializationDateTime.Month-1),
                };
            result = await _ReportRepository.GetByStoredProcedureToListAsync("sp_Report004", parameters);

            return result;
        }
    }
}
