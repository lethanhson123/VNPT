namespace Data.Repository.Implement
{
    public class ReportRepository : BaseRepository<Report>, IReportRepository
    {
        private readonly VNPTContext _context;        
        public ReportRepository(VNPTContext context) : base(context)
        {
            _context = context;            
        }		
	}
}
