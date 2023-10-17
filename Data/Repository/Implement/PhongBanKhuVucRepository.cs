namespace Data.Repository.Implement
{
    public class PhongBanKhuVucRepository : BaseRepository<PhongBanKhuVuc>, IPhongBanKhuVucRepository
    {
        private readonly VNPTContext _context;        
        public PhongBanKhuVucRepository(VNPTContext context) : base(context)
        {
            _context = context;            
        }
    }
}
