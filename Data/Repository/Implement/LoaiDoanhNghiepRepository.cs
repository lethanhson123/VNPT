namespace Data.Repository.Implement
{
    public class LoaiDoanhNghiepRepository : BaseRepository<LoaiDoanhNghiep>, ILoaiDoanhNghiepRepository
    {
        private readonly VNPTContext _context;        
        public LoaiDoanhNghiepRepository(VNPTContext context) : base(context)
        {
            _context = context;            
        }
    }
}
