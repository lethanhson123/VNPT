namespace Business.Implement
{
	public class NhanVienTokenBusiness : BaseBusiness<NhanVienToken, INhanVienTokenRepository>
	, INhanVienTokenBusiness
	{
		private readonly INhanVienTokenRepository _NhanVienTokenRepository;
		public NhanVienTokenBusiness(INhanVienTokenRepository NhanVienTokenRepository) : base(NhanVienTokenRepository)
		{
			_NhanVienTokenRepository = NhanVienTokenRepository;
		}
	}
}

