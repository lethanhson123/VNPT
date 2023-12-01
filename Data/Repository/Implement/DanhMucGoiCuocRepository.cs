namespace Data.Repository.Implement
{
    public class DanhMucGoiCuocRepository : BaseRepository<DanhMucGoiCuoc>, IDanhMucGoiCuocRepository
    {
        private readonly VNPTContext _context;        
        public DanhMucGoiCuocRepository(VNPTContext context) : base(context)
        {
            _context = context;            
        }
    }
}
