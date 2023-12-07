namespace Business.Interface
{
	public interface IDoanhNghiepDichVuCABusiness : IBaseBusiness<DoanhNghiepDichVuCA>
	{
		Task<DoanhNghiepDichVuCA> Save001Async(DoanhNghiepDichVuCA model);
		Task<List<DoanhNghiepDichVuCA>> GetByNhanVienIDToListAsync(long nhanVienID);
		Task<List<DoanhNghiepDichVuCA>> GetByNhanVienIDAndYearAndMonthToListAsync(long nhanVienID, int year, int month);
		Task<bool> AsyncThieuHoSoDoanhNghiepDichVuCA();
	}
}
