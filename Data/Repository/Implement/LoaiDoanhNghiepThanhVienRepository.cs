namespace Data.Repository.Implement
{
    public class LoaiDoanhNghiepThanhVienRepository : BaseRepository<LoaiDoanhNghiepThanhVien>, ILoaiDoanhNghiepThanhVienRepository
    {
        private readonly VNPTContext _context;        
        public LoaiDoanhNghiepThanhVienRepository(VNPTContext context) : base(context)
        {
            _context = context;            
        }
    }
}
