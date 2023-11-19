namespace Data.Repository.Implement
{
    public class DoanhNghiepDichVuCARepository : BaseRepository<DoanhNghiepDichVuCA>, IDoanhNghiepDichVuCARepository
    {
        private readonly VNPTContext _context;        
        public DoanhNghiepDichVuCARepository(VNPTContext context) : base(context)
        {
            _context = context;            
        }
    }
}
