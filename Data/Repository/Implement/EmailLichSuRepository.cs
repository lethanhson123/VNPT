namespace Data.Repository.Implement
{
    public class EmailLichSuRepository : BaseRepository<EmailLichSu>, IEmailLichSuRepository
    {
        private readonly VNPTContext _context;        
        public EmailLichSuRepository(VNPTContext context) : base(context)
        {
            _context = context;            
        }
    }
}
