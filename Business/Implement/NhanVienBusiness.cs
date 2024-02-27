
using Data.Repository.Implement;

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
		public override async Task<NhanVien> SaveAsync(NhanVien model)
		{
			Initialization(model);
			if (!string.IsNullOrEmpty(model.Code))
			{
				NhanVien modelExist = await GetByCodeAsync(model.Code);
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
		public virtual int CheckMatKhau(NhanVien model)
		{
			int result = GlobalHelper.InitializationNumber;
			if (!string.IsNullOrEmpty(model.MatKhau))
			{
				if (model.MatKhau.Length > 6)
				{
					result = result + 1;
				}
			}
			return result;
		}
		public override async Task<int> AddAsync(NhanVien model)
		{
			int result = CheckMatKhau(model);
			if (result == 1)
			{
				Initialization(model);
				result = await _NhanVienRepository.AddAsync(model);
			}
			return result;
		}
		public override async Task<int> UpdateAsync(NhanVien model)
		{
			int result = CheckMatKhau(model);
			if (result == 1)
			{
				Initialization(model);
				result = await _NhanVienRepository.UpdateAsync(model);
			}
			return result;
		}
		public async Task<NhanVien> AuthenticationAsync(NhanVien nhanVien)
		{
			NhanVien result = new NhanVien();
			result = await _NhanVienRepository.GetByCondition(model => model.Email == nhanVien.Email && model.MatKhau == nhanVien.MatKhau).FirstOrDefaultAsync();
			if (result == null)
			{
				result = new NhanVien();
			}
			if (result.ID > 0)
			{
				NhanVienToken nhanVienToken = new NhanVienToken();
				nhanVienToken.ParentID = result.ID;
				nhanVienToken.Token = GlobalHelper.InitializationGUICode;
				nhanVienToken.OTP001 = result.ID.ToString() + GlobalHelper.InitializationTicks;
				nhanVienToken.NgayBatDau = GlobalHelper.InitializationDateTime;
				nhanVienToken.NgayKetThuc = nhanVienToken.NgayBatDau.Value.AddMonths(1);
				nhanVienToken.Active = true;
				int resultSave = await _NhanVienTokenBusiness.AddAsync(nhanVienToken);
				if (resultSave > 0)
				{
					string url = GlobalHelper.APISite + "api/v1/Email/Async" + nhanVienToken.GetType().Name;
					var content = new StringContent(JsonConvert.SerializeObject(nhanVienToken), Encoding.UTF8, "application/json");
					HttpClient client = new HttpClient();
					var task = client.PostAsync(url, content);
					await task.Result.Content.ReadAsStringAsync();
				}
			}
			return result;
		}
	}
}
