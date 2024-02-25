namespace Data.Repository.Implement
{
    public class DanhMucChucNangRepository : BaseRepository<DanhMucChucNang>, IDanhMucChucNangRepository
    {
        private readonly VNPTContext _context;        
        public DanhMucChucNangRepository(VNPTContext context) : base(context)
        {
            _context = context;            
        }
    }
}
