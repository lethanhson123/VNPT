namespace Data.Repository.Implement
{
	public class NhanVienTokenRepository : BaseRepository<NhanVienToken>
	, INhanVienTokenRepository
	{
		private readonly Data.Context.VNPTContext _context;
		public NhanVienTokenRepository(Data.Context.VNPTContext context) : base(context)
		{
			_context = context;
		}
	}
}

