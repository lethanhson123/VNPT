
namespace Business.Implement
{
	public class DoanhNghiepDichVuCABusiness : BaseBusiness<DoanhNghiepDichVuCA, IDoanhNghiepDichVuCARepository>, IDoanhNghiepDichVuCABusiness
	{
		private readonly IDoanhNghiepDichVuCARepository _DoanhNghiepDichVuCARepository;
		public DoanhNghiepDichVuCABusiness(IDoanhNghiepDichVuCARepository DoanhNghiepDichVuCARepository) : base(DoanhNghiepDichVuCARepository)
		{
			_DoanhNghiepDichVuCARepository = DoanhNghiepDichVuCARepository;
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
	}
}
