namespace Data.Model
{
	public partial class NhanVienToken : BaseModel
	{		
		public string? Token { get; set; }
		public DateTime? NgayBatDau { get; set; }
		public DateTime? NgayKetThuc { get; set; }
		public string? OTP001 { get; set; }
		public string? OTP002 { get; set; }

		public NhanVienToken()
		{
		}
	}
}

