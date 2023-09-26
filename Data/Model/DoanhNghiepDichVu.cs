namespace Data.Model
{
    public partial class DoanhNghiepDichVu : BaseModel
    {
        public long? NhanVienID { get; set; }
        public long? DichVuID { get; set; }
        public DateTime? NgayKyHopDong { get; set; }
        public decimal? GiaTien { get; set; }
        public int? SoThang { get; set; }
        public DoanhNghiepDichVu()
        {
            GiaTien = GlobalHelper.InitializationNumber;
            SoThang = GlobalHelper.InitializationNumber;
        }
    }
}
