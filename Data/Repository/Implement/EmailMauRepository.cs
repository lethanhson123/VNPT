namespace Data.Repository.Implement
{
    public class EmailMauRepository : BaseRepository<EmailMau>, IEmailMauRepository
    {
        private readonly VNPTContext _context;        
        public EmailMauRepository(VNPTContext context) : base(context)
        {
            _context = context;            
        }
    }
}
