namespace Data.Repository.Implement
{
	public class DichVuChiTieuRepository : BaseRepository<DichVuChiTieu>
	, IDichVuChiTieuRepository
	{
		private readonly Data.Context.VNPTContext _context;
		public DichVuChiTieuRepository(Data.Context.VNPTContext context) : base(context)
		{
			_context = context;
		}
	}
}

