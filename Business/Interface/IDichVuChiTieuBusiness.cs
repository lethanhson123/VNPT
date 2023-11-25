namespace Business.Interface
{
	public interface IDichVuChiTieuBusiness : IBaseBusiness<DichVuChiTieu>
	{
		Task<List<DichVuChiTieu>> GetByNam_ThangToListAsync(int nam, int thang);
	}
}

