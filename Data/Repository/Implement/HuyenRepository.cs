namespace Data.Repository.Implement
{
    public class HuyenRepository : BaseRepository<Huyen>, IHuyenRepository
    {
        private readonly VNPTContext _context;        
        public HuyenRepository(VNPTContext context) : base(context)
        {
            _context = context;            
        }
    }
}
