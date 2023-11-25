namespace Business.Interface
{
	public interface INhanVienBusiness : IBaseBusiness<NhanVien>
	{
		Task<NhanVien> AuthenticationAsync(NhanVien nhanVien);
	}
}
