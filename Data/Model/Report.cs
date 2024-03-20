namespace Data.Model
{
    public partial class Report : BaseModel
    {
		public decimal? SanLuong { get; set; }
		public decimal? PhatTrien { get; set; }
		public decimal? GiaHan { get; set; }
		public decimal? HoSo { get; set; }
		public decimal? HoSoChuaHoanThanh { get; set; }
		public decimal? HoSoHoanThanh { get; set; }
		public decimal? PhatTrienChiTieu { get; set; }
		public decimal? GiaHanChiTieu { get; set; }
		public decimal? TyLeHoSo { get; set; }
		public decimal? TyLePhatTrien { get; set; }
		public decimal? TyLeGiaHan { get; set; }

		public long? NhanVienTaoYeuCauID { get; set; }
		public string? NhanVienTaoYeuCauName { get; set; }
		public long? PhongBanTaoYeuCauID { get; set; }
		public string? PhongBanTaoYeuCauName { get; set; }
		public long? NhanVienDuyetYeuCauID { get; set; }
		public long? PhongBanDuyetYeuCauID { get; set; }
		public string? PhongBanDuyetYeuCauName { get; set; }

		public string? PhongBan { get; set; }
		public string? PhongBanName { get; set; }
		public string? NhanVienName { get; set; }
		public string? DiaChi { get; set; }        
        public string? HuyenName { get; set; }
        public string? XaName { get; set; }
        public long? DoanhNghiepID { get; set; }
		public string? DoanhNghiepName { get; set; }
		public string? CodeCA { get; set; }		
		public string? LoaiGoiCuoc { get; set; }		
		public string? DichVu { get; set; }        
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

		public long? NhanVienID { get; set; }
		public long? DichVuID { get; set; }
		public DateTime? NgayKyHopDong { get; set; }
		public decimal? GiaTien { get; set; }
		public int? SoThang { get; set; }
		public string? MaThueBao { get; set; }
		public string? DiaChiLapDat { get; set; }
		public string? DichVuVienThong { get; set; }
		public long? PhongBanID { get; set; }
		public long? GoiCuocID { get; set; }
		public string? UserName { get; set; }
		public string? SoChungThu { get; set; }
		public string? SubjectDN { get; set; }
		public DateTime? NgayHieuLuc { get; set; }
		public DateTime? NgayHetHan { get; set; }
		public int? SoNgayNoKhach { get; set; }
		public string? TenGoiCuoc { get; set; }
		public int? ThoiGianGoiCuoc { get; set; }
		public int? ThoiGianKhuyenMai { get; set; }
		public string? DienThoai { get; set; }
		public string? Email { get; set; }
		public string? TaiKhoanTaoYeuCau { get; set; }
		public string? TaiKhoanDuyetYeuCau { get; set; }
		public long? LoaiYeuCauID { get; set; }
		public string? LoaiYeuCau { get; set; }
		public string? TrangThaiChungThu { get; set; }
		public long? LoaiTrangThaiID { get; set; }
		public string? SoChungThuCu { get; set; }
		public string? IDThucThe { get; set; }
		public string? IDChungThu { get; set; }
		public string? NguoiLienHe { get; set; }
		public string? IDYeuCau { get; set; }
		public string? DonVi { get; set; }
		public string? MaNhanVien { get; set; }
		public string? NhanVien { get; set; }
		public bool? IsHopDong { get; set; }
		public string? HopDong { get; set; }
		public bool? IsDonXinCapChungThuSo { get; set; }
		public string? DonXinCapChungThuSo { get; set; }
		public bool? IsGiayPhepKinhDoanh { get; set; }
		public string? GiayPhepKinhDoanh { get; set; }
		public bool? IsBienBanNghiemThu { get; set; }
		public string? BienBanNghiemThu { get; set; }
		public bool? IsHoaDon { get; set; }
		public string? HoaDon { get; set; }
		public bool? IsCCCD { get; set; }
		public string? CCCD { get; set; }
		public bool? IsKetLuan { get; set; }
		public string? KetLuan { get; set; }
		public bool? IsCapBu { get; set; }
		public Report()
        {
        }
    }
}
