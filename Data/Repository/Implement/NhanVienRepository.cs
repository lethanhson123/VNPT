namespace Data.Repository.Implement
{
    public class NhanVienRepository : BaseRepository<NhanVien>, INhanVienRepository
    {
        private readonly VNPTContext _context;        
        public NhanVienRepository(VNPTContext context) : base(context)
        {
            _context = context;            
        }
    }
}
