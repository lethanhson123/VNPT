namespace Data.Repository.Implement
{
    public class MenuRepository : BaseRepository<Menu>, IMenuRepository
    {
        private readonly VNPTContext _context;        
        public MenuRepository(VNPTContext context) : base(context)
        {
            _context = context;            
        }
    }
}
