namespace Data.Repository.Implement
{
    public class NhanVienTaiKhoanRepository : BaseRepository<NhanVienTaiKhoan>, INhanVienTaiKhoanRepository
    {
        private readonly VNPTContext _context;        
        public NhanVienTaiKhoanRepository(VNPTContext context) : base(context)
        {
            _context = context;            
        }
    }
}
