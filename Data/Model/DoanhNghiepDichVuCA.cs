﻿namespace Data.Model
{
    public partial class DoanhNghiepDichVuCA : BaseModel
    {
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
        public DateTime? NgayHetHanNguyenMau { get; set; }
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
		public DoanhNghiepDichVuCA()
        {            
        }
    }
}
