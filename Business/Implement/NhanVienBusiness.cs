
using Business.Interface;

namespace Business.Implement
{
	public class NhanVienBusiness : BaseBusiness<NhanVien, INhanVienRepository>, INhanVienBusiness
	{
		private readonly INhanVienRepository _NhanVienRepository;
		private readonly INhanVienTokenBusiness _NhanVienTokenBusiness;
		public NhanVienBusiness(INhanVienRepository NhanVienRepository
			, INhanVienTokenBusiness NhanVienTokenBusiness
			) : base(NhanVienRepository)
		{
			_NhanVienRepository = NhanVienRepository;
			_NhanVienTokenBusiness = NhanVienTokenBusiness;
		}
		public async Task<NhanVien> AuthenticationAsync(NhanVien nhanVien)
		{
			NhanVien result = new NhanVien();
			result = await _NhanVienRepository.GetByCondition(model => model.DienThoai == nhanVien.DienThoai && model.MatKhau == nhanVien.MatKhau && model.Active == true).FirstOrDefaultAsync();

			NhanVienToken nhanVienToken = new NhanVienToken();
			nhanVienToken.ParentID = result.ID;
			nhanVienToken.Token = GlobalHelper.InitializationGUICode;
			nhanVienToken.NgayBatDau = GlobalHelper.InitializationDateTime;
			nhanVienToken.NgayKetThuc = nhanVienToken.NgayBatDau.Value.AddMonths(1);
			nhanVienToken.Active = true;
			int resultSave = _NhanVienTokenBusiness.Add(nhanVienToken);
			if (resultSave > 0)
			{				
			}
			return nhanVien;
		}
	}
}
