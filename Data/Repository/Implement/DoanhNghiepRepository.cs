namespace Data.Repository.Implement
{
    public class DoanhNghiepRepository : BaseRepository<DoanhNghiep>, IDoanhNghiepRepository
    {
        private readonly VNPTContext _context;        
        public DoanhNghiepRepository(VNPTContext context) : base(context)
        {
            _context = context;            
        }
    }
}
