namespace Data.Model
{
    public partial class NhanVien : BaseModel
    {
        public string? DiaChi { get; set; }
        public string? DienThoai { get; set; }
        public string? Email { get; set; }
        public string? CCCD { get; set; }
        public string? MatKhau { get; set; }
        public NhanVien()
        {
        }
    }
}
