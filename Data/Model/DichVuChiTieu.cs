namespace Data.Model
{
	public partial class DichVuChiTieu : BaseModel
	{
		public long? GoiCuocID { get; set; }
		public long? PhongBanID { get; set; }
		public long? NhanVienID { get; set; }
		public int? Nam { get; set; }
		public int? Thang { get; set; }
		public int? PhatTrien { get; set; }
		public int? GiaHan { get; set; }
		public int? PhongBanPhatTrien { get; set; }
		public int? PhongBanGiaHan { get; set; }
		public int? SmartCAPhatTrien { get; set; }
		public int? SmartCAGiaHan { get; set; }
		public int? SmartCAPhongBanPhatTrien { get; set; }
		public int? SmartCAPhongBanGiaHan { get; set; }
		public decimal? DoanhThu { get; set; }
		public decimal? PhongBanDoanhThu { get; set; }
		public int? CACapBu { get; set; }
		public int? CACapBuPhongBan { get; set; }
		public int? SmartCACapBu { get; set; }
		public int? SmartCACapBuPhongBan { get; set; }
		public DichVuChiTieu()
		{
		}
	}
}

