namespace Data.Repository.Implement
{
    public class PhongBanRepository : BaseRepository<PhongBan>, IPhongBanRepository
    {
        private readonly VNPTContext _context;        
        public PhongBanRepository(VNPTContext context) : base(context)
        {
            _context = context;            
        }
    }
}
