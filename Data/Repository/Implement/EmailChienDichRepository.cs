namespace Data.Repository.Implement
{
    public class EmailChienDichRepository : BaseRepository<EmailChienDich>, IEmailChienDichRepository
    {
        private readonly VNPTContext _context;        
        public EmailChienDichRepository(VNPTContext context) : base(context)
        {
            _context = context;            
        }
    }
}
