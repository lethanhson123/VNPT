using Business.Interface;

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
		public async Task<NhanVienToken> AuthenticationAsync(NhanVienToken nhanVienToken)
		{
			NhanVienToken result = new NhanVienToken();
			result = await _NhanVienTokenRepository.GetByCondition(model => model.OTP001 == nhanVienToken.OTP001 && model.ParentID == nhanVienToken.ParentID && model.Active == true).FirstOrDefaultAsync();
			if (result==null)
			{
				result = new NhanVienToken();
			}
			return result;
		}
		public async Task<NhanVienToken> GetByTokenAsync(string token)
		{
			NhanVienToken result = new NhanVienToken();
			if (!string.IsNullOrEmpty(token))
			{
				result = await _NhanVienTokenRepository.GetByCondition(model => model.Token == token && model.Active == true).FirstOrDefaultAsync();
				if (result == null)
				{
					result = new NhanVienToken();
				}
			}			
			return result;
		}
	}
}

