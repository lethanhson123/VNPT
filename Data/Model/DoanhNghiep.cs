namespace Data.Model
{
    public partial class DoanhNghiep : BaseModel
    {
        public string? DiaChi { get; set; }
        public decimal? VonDieuLe { get; set; }
        public long? LoaiTrangThaiID { get; set; }
        public string? DienThoai { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public long? NganhNgheKinhDoanhChinhID { get; set; }
        public long? NganhNgheKinhDoanhID { get; set; }
        public DateTime? NgayCap { get; set; }
        public DateTime? NgayDangKyThayDoi { get; set; }
        public long? LoaiDoanhNghiepID { get; set; }
        public int? SoLuongLaoDong { get; set; }
        public long? TinhID { get; set; }
        public long? HuyenID { get; set; }
        public long? XaID { get; set; }
        public string? NganhNgheKinhDoanh { get; set; }
        public long? NhanVienID { get; set; }
        public string? KHACHHANG_ID { get; set; }
        public DoanhNghiep()
        {
        }
    }
}
