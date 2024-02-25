namespace Data.Repository.Implement
{
    public class NhanVienChucNangRepository : BaseRepository<NhanVienChucNang>, INhanVienChucNangRepository
    {
        private readonly VNPTContext _context;        
        public NhanVienChucNangRepository(VNPTContext context) : base(context)
        {
            _context = context;            
        }
    }
}
