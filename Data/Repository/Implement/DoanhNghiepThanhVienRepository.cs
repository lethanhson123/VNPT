namespace Data.Repository.Implement
{
    public class DoanhNghiepThanhVienRepository : BaseRepository<DoanhNghiepThanhVien>, IDoanhNghiepThanhVienRepository
    {
        private readonly VNPTContext _context;        
        public DoanhNghiepThanhVienRepository(VNPTContext context) : base(context)
        {
            _context = context;            
        }
    }
}
