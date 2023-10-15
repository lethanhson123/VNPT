namespace Data.Model
{
    public partial class DoanhNghiepDichVuLichSu : BaseModel
    {
        public decimal? GiaTien { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
        public long? DichVuID { get; set; }
        public long? DoanhNghiepID { get; set; }
        public DoanhNghiepDichVuLichSu()
        {
        }
    }
}
