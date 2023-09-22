namespace Data.Repository.Implement
{
    public class XaRepository : BaseRepository<Xa>, IXaRepository
    {
        private readonly VNPTContext _context;        
        public XaRepository(VNPTContext context) : base(context)
        {
            _context = context;            
        }
    }
}
