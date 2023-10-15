namespace Data.Repository.Implement
{
    public class DoanhNghiepDichVuLichSuRepository : BaseRepository<DoanhNghiepDichVuLichSu>, IDoanhNghiepDichVuLichSuRepository
    {
        private readonly VNPTContext _context;        
        public DoanhNghiepDichVuLichSuRepository(VNPTContext context) : base(context)
        {
            _context = context;            
        }        
    }
}
