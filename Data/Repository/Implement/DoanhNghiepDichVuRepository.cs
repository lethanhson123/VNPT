namespace Data.Repository.Implement
{
    public class DoanhNghiepDichVuRepository : BaseRepository<DoanhNghiepDichVu>, IDoanhNghiepDichVuRepository
    {
        private readonly VNPTContext _context;        
        public DoanhNghiepDichVuRepository(VNPTContext context) : base(context)
        {
            _context = context;            
        }
    }
}
