namespace Data.Repository.Implement
{
    public class EmailMauTapTinDinhKemRepository : BaseRepository<EmailMauTapTinDinhKem>, IEmailMauTapTinDinhKemRepository
    {
        private readonly VNPTContext _context;        
        public EmailMauTapTinDinhKemRepository(VNPTContext context) : base(context)
        {
            _context = context;            
        }
    }
}
