namespace Data.Repository.Implement
{
    public class EmailConfigRepository : BaseRepository<EmailConfig>, IEmailConfigRepository
    {
        private readonly VNPTContext _context;        
        public EmailConfigRepository(VNPTContext context) : base(context)
        {
            _context = context;            
        }
    }
}
