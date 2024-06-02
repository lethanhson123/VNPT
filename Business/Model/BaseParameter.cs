namespace Business.Model
{
	public partial class BaseParameter : BaseModel
	{
		public bool? IsSmartCA { get; set; }
		public bool? IsKetLuan { get; set; }
		public string? IDString { get; set; }
		public string? Token { get; set; }
		public string? APIMessage { get; set; }
		public string? SearchString { get; set; }
		public int? Year { get; set; }
		public int? Month { get; set; }
		public int? HetHan { get; set; }
		public long? HuyenID { get; set; }
		public long? XaID { get; set; }
		public long? NhanVienID { get; set; }
		public long? PhongBanID { get; set; }
		public long? DoanhNghiepID { get; set; }
		public long? LoaiDichVuID { get; set; }
		public long? DichVuID { get; set; }
        public DateTime? BatDau { get; set; }
        public DateTime? KetThuc { get; set; }
        public BaseParameter()
		{
		}
	}
}
