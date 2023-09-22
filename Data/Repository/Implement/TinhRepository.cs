namespace Data.Repository.Implement
{
    public class TinhRepository : BaseRepository<Tinh>, ITinhRepository
    {
        private readonly VNPTContext _context;        
        public TinhRepository(VNPTContext context) : base(context)
        {
            _context = context;            
        }
    }
}
