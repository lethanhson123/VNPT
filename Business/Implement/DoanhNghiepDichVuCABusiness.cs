
using Data.Model;
using Data.Repository.Implement;

namespace Business.Implement
{
	public class DoanhNghiepDichVuCABusiness : BaseBusiness<DoanhNghiepDichVuCA, IDoanhNghiepDichVuCARepository>, IDoanhNghiepDichVuCABusiness
	{
		private readonly IDoanhNghiepDichVuCARepository _DoanhNghiepDichVuCARepository;
		private readonly IDoanhNghiepBusiness _DoanhNghiepBusiness;
		public DoanhNghiepDichVuCABusiness(IDoanhNghiepDichVuCARepository DoanhNghiepDichVuCARepository, IDoanhNghiepBusiness doanhNghiepBusiness) : base(DoanhNghiepDichVuCARepository)
		{
			_DoanhNghiepDichVuCARepository = DoanhNghiepDichVuCARepository;
			_DoanhNghiepBusiness = doanhNghiepBusiness;
		}
		public override void Initialization(DoanhNghiepDichVuCA model)
		{
			if (string.IsNullOrEmpty(model.Code))
			{
				model.Code = GlobalHelper.InitializationDateTimeCode;
			}
			model.Display = model.Name + "-" + model.Code;
			if ((model.SortOrder == null) || (model.SortOrder == GlobalHelper.InitializationNumber))
			{
				model.SortOrder = 1;
			}

			if (!string.IsNullOrEmpty(model.HopDong))
			{
				model.IsHopDong = true;
			}
			if (!string.IsNullOrEmpty(model.DonXinCapChungThuSo))
			{
				model.IsDonXinCapChungThuSo = true;
			}
			if (!string.IsNullOrEmpty(model.CCCD))
			{
				model.IsCCCD = true;
			}
			if (!string.IsNullOrEmpty(model.GiayPhepKinhDoanh))
			{
				model.IsGiayPhepKinhDoanh = true;
			}
			if (!string.IsNullOrEmpty(model.HoaDon))
			{
				model.IsHoaDon = true;
			}

			if ((model.IsHopDong == true) && (model.IsDonXinCapChungThuSo == true) && (model.IsCCCD == true) && (model.IsGiayPhepKinhDoanh == true) && (model.IsHoaDon == true))
			{
				model.IsKetLuan = true;
				model.KetLuan = GlobalHelper.InitializationString;
			}

			if (string.IsNullOrEmpty(model.KetLuan))
			{
				model.KetLuan = GlobalHelper.InitializationString;
			}
			model.KetLuan = model.KetLuan.Replace("[Hợp đồng]", "");
			model.KetLuan = model.KetLuan.Replace("[Phiếu đăng ký]", "");
			model.KetLuan = model.KetLuan.Replace("[CCCD/HC]", "");
			model.KetLuan = model.KetLuan.Replace("[Giấy phép kinh doanh]", "");
			model.KetLuan = model.KetLuan.Replace("[Biên bản nghiệm thu]", "");
			model.KetLuan = model.KetLuan.Replace("[Hoá đơn]", "");
			if (model.IsHopDong != true)
			{
				model.KetLuan = model.KetLuan + "[Hợp đồng]";
			}
			if (model.IsDonXinCapChungThuSo != true)
			{
				model.KetLuan = model.KetLuan + "[Phiếu đăng ký]";
			}
			if (model.IsCCCD != true)
			{
				model.KetLuan = model.KetLuan + "[CCCD/HC]";
			}
			if (model.IsGiayPhepKinhDoanh != true)
			{
				model.KetLuan = model.KetLuan + "[Giấy phép kinh doanh]";
			}
			if (model.IsBienBanNghiemThu != true)
			{
				model.KetLuan = model.KetLuan + "[Biên bản nghiệm thu]";
			}
			if (model.IsHoaDon != true)
			{
				model.KetLuan = model.KetLuan + "[Hoá đơn]";
			}
		}

		public override async Task<DoanhNghiepDichVuCA> SaveAsync(DoanhNghiepDichVuCA model)
		{
			Initialization(model);
			if (!string.IsNullOrEmpty(model.Code))
			{
				DoanhNghiepDichVuCA modelExist = await _DoanhNghiepDichVuCARepository.GetByCodeAsync(model.Code);
				if (model.ID > 0)
				{
					if (modelExist.ID == 0)
					{
						await _DoanhNghiepDichVuCARepository.UpdateAsync(model);
					}
					else
					{
						if (modelExist.ID == model.ID)
						{
							await _DoanhNghiepDichVuCARepository.UpdateAsync(model);
						}
					}
				}
				else
				{
					if (modelExist.ID == 0)
					{
						await _DoanhNghiepDichVuCARepository.AddAsync(model);
					}
				}
				if (model.ParentID > 0)
				{
					if (!string.IsNullOrEmpty(model.Email))
					{
						DoanhNghiep doanhNghiep = await _DoanhNghiepBusiness.GetByIDAsync(model.ParentID.Value);
						if (doanhNghiep != null)
						{
							if (doanhNghiep.ID > 0)
							{
								doanhNghiep.Email = model.Email;
								await _DoanhNghiepBusiness.SaveAsync(doanhNghiep);
							}
						}
						string url = GlobalHelper.APISite + "api/v1/Email/AsyncHetHan" + model.GetType().Name;
						var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
						HttpClient client = new HttpClient();
						var task = client.PostAsync(url, content);
						await task.Result.Content.ReadAsStringAsync();
					}
				}

			}
			return model;
		}
	}
}
