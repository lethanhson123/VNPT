namespace Data.Repository.Implement
{
    public class NganhNgheKinhDoanhRepository : BaseRepository<NganhNgheKinhDoanh>, INganhNgheKinhDoanhRepository
    {
        private readonly VNPTContext _context;        
        public NganhNgheKinhDoanhRepository(VNPTContext context) : base(context)
        {
            _context = context;            
        }
    }
}
