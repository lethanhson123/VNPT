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
		public DichVuChiTieu()
		{
		}
	}
}

