namespace Business.Interface
{
	public interface INhanVienTokenBusiness : IBaseBusiness<NhanVienToken>
	{
		Task<NhanVienToken> AuthenticationAsync(NhanVienToken nhanVienToken);
	}
}

