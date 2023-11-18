namespace Data.Repository.Implement
{
    public class GoiCuocRepository : BaseRepository<GoiCuoc>, IGoiCuocRepository
    {
        private readonly VNPTContext _context;        
        public GoiCuocRepository(VNPTContext context) : base(context)
        {
            _context = context;            
        }
    }
}
