namespace Data.Model
{
    public partial class DoanhNghiepThanhVien : BaseModel
    {
        public long? LoaiDoanhNghiepThanhVienID { get; set; }
        public string? DienThoai { get; set; }
        public string? Email { get; set; }
        public string? CCCD { get; set; }
        public DateTime? CCCD_NgayCap { get; set; }
        public string? CCCD_NoiCap { get; set; }        
        public DoanhNghiepThanhVien()
        {
        }
    }
}
