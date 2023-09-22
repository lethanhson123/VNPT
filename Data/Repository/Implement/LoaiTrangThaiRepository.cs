namespace Data.Repository.Implement
{
    public class LoaiTrangThaiRepository : BaseRepository<LoaiTrangThai>, ILoaiTrangThaiRepository
    {
        private readonly VNPTContext _context;        
        public LoaiTrangThaiRepository(VNPTContext context) : base(context)
        {
            _context = context;            
        }
    }
}
