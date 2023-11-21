namespace Data.Model
{
    public partial class Report : BaseModel
    {
        public string? PhongBan { get; set; }
        public string? NhanVien { get; set; }
        public string? DiaChi { get; set; }
        public string? DienThoai { get; set; }
        public string? HuyenName { get; set; }
        public string? XaName { get; set; }
        public long? DoanhNghiepID { get; set; }
		public string? DoanhNghiepName { get; set; }
		public long? DichVuID { get; set; }
        public string? DichVu { get; set; }
        public string? MaThueBao { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
        public decimal? DoanhThu { get; set; }
        public int? YearLast { get; set; }
        public int? MonthLast { get; set; }
        public decimal? DoanhThuLast { get; set; }
        public decimal? ChenhLech { get; set; }        
        public decimal? ChenhLech01 { get; set; }
        public decimal? ChenhLech02 { get; set; }
        public decimal? ChenhLech03 { get; set; }
        public decimal? ChenhLech04 { get; set; }
        public decimal? ChenhLech05 { get; set; }
        public decimal? ChenhLech06 { get; set; }
        public decimal? ChenhLech07 { get; set; }
        public decimal? DoanhThu01 { get; set; }
        public decimal? DoanhThu02 { get; set; }
        public decimal? DoanhThu03 { get; set; }
        public decimal? DoanhThu04 { get; set; }
        public decimal? DoanhThu05 { get; set; }
        public decimal? DoanhThu06 { get; set; }
        public decimal? DoanhThu07 { get; set; }
        public decimal? DoanhThu08 { get; set; }
        public decimal? DoanhThu09 { get; set; }
        public decimal? DoanhThu10 { get; set; }
        public decimal? DoanhThu11 { get; set; }
        public decimal? DoanhThu12 { get; set; }
        public decimal? DoanhThu13 { get; set; }
        public decimal? DoanhThu14 { get; set; }

		public string? UserName { get; set; }
		public string? SoChungThu { get; set; }
		public string? SoChungThuCu { get; set; }
		public DateTime? NgayHieuLuc { get; set; }
		public DateTime? NgayHetHan { get; set; }
		public string? TaiKhoanTaoYeuCau { get; set; }
		public string? TaiKhoanDuyetYeuCau { get; set; }
		public long? NhanVienID { get; set; }
		public string? NhanVienName { get; set; }
		public string? NhanVienDienThoai { get; set; }
		public Report()
        {
        }
    }
}
