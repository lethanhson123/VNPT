namespace Data.Model
{
    public partial class GoiCuoc : BaseModel
    {
		public int? Thang { get; set; }
		public int? ThangKhuyenMai { get; set; }
		public int? GiaCuoc { get; set; }
		public GoiCuoc()
        {
        }
    }
}
