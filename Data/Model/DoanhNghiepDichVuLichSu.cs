namespace Data.Model
{
    public partial class DoanhNghiepDichVuLichSu : BaseModel
    {
        public decimal? GiaTien { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
        public DoanhNghiepDichVuLichSu()
        {
        }
    }
}
