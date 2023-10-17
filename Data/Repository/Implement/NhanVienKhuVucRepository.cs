namespace Data.Repository.Implement
{
    public class NhanVienKhuVucRepository : BaseRepository<NhanVienKhuVuc>, INhanVienKhuVucRepository
    {
        private readonly VNPTContext _context;        
        public NhanVienKhuVucRepository(VNPTContext context) : base(context)
        {
            _context = context;            
        }
    }
}
