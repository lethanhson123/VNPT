namespace Data.Repository.Implement
{
    public class DichVuRepository : BaseRepository<DichVu>, IDichVuRepository
    {
        private readonly VNPTContext _context;        
        public DichVuRepository(VNPTContext context) : base(context)
        {
            _context = context;            
        }
    }
}
