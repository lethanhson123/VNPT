namespace Data.Repository.Implement
{
    public class EmailChienDichChiTietRepository : BaseRepository<EmailChienDichChiTiet>, IEmailChienDichChiTietRepository
    {
        private readonly VNPTContext _context;        
        public EmailChienDichChiTietRepository(VNPTContext context) : base(context)
        {
            _context = context;            
        }
    }
}
