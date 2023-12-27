namespace Data.Repository.Implement
{
    public class NhanVienMenuRepository : BaseRepository<NhanVienMenu>, INhanVienMenuRepository
    {
        private readonly VNPTContext _context;        
        public NhanVienMenuRepository(VNPTContext context) : base(context)
        {
            _context = context;            
        }
    }
}
