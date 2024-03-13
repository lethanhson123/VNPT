
using Data.Repository.Implement;

namespace Business.Implement
{
	public class NhanVienTaiKhoanBusiness : BaseBusiness<NhanVienTaiKhoan, INhanVienTaiKhoanRepository>, INhanVienTaiKhoanBusiness
	{
		private readonly INhanVienTaiKhoanRepository _NhanVienTaiKhoanRepository;
		public NhanVienTaiKhoanBusiness(INhanVienTaiKhoanRepository NhanVienTaiKhoanRepository) : base(NhanVienTaiKhoanRepository)
		{
			_NhanVienTaiKhoanRepository = NhanVienTaiKhoanRepository;
		}
		public override async Task<NhanVienTaiKhoan> SaveAsync(NhanVienTaiKhoan model)
		{
			Initialization(model);
			if (!string.IsNullOrEmpty(model.Code))
			{
				NhanVienTaiKhoan modelExist = new NhanVienTaiKhoan();
				if (model.ParentID > 1)
				{
					modelExist = await GetByCondition(item => item.Code == model.Code && item.ParentID > 1).FirstOrDefaultAsync();
				}
				if (model.ParentID == 1)
				{
					modelExist = await GetByCondition(item => item.Code == model.Code && item.ParentID == 1).FirstOrDefaultAsync();
				}
				if (modelExist == null)
				{
					modelExist = new NhanVienTaiKhoan();
				}
				if (model.ID > 0)
				{
					if (modelExist.ID == 0)
					{
						await UpdateAsync(model);
					}
					else
					{
						if (modelExist.ID == model.ID)
						{
							await UpdateAsync(model);
						}
					}
				}
				else
				{
					if (modelExist.ID == 0)
					{
						await AddAsync(model);
					}
				}
			}
			return model;
		}
	}
}
