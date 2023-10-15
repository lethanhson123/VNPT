namespace Data.Repository.Implement
{
    public class LoaiDichVuRepository : BaseRepository<LoaiDichVu>, ILoaiDichVuRepository
    {
        private readonly VNPTContext _context;        
        public LoaiDichVuRepository(VNPTContext context) : base(context)
        {
            _context = context;            
        }
    }
}
