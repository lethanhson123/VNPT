
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
			//model.KetLuan = GlobalHelper.InitializationString;
			if (model.IsHopDong != true)
			{
				model.KetLuan = model.KetLuan + "| Thiếu Hợp đồng |";
			}
			if (model.IsDonXinCapChungThuSo != true)
			{
				model.KetLuan = model.KetLuan + "| Thiếu Đơn xin cấp chứng thư số |";
			}
			if (model.IsCCCD != true)
			{
				model.KetLuan = model.KetLuan + "| Thiếu CCCD |";
			}
			if (model.IsGiayPhepKinhDoanh != true)
			{
				model.KetLuan = model.KetLuan + "| Thiếu Giấy phép kinh doanh |";
			}
			if (model.IsBienBanNghiemThu != true)
			{
				model.KetLuan = model.KetLuan + "| Thiếu Biên bản nghiệm thu |";
			}
			if (model.IsHoaDon != true)
			{
				model.KetLuan = model.KetLuan + "| Thiếu Hoá đơn |";
			}
		}
	}
}
