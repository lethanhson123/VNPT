namespace Business.Interface
{
	public interface IDoanhNghiepDichVuLichSuBusiness : IBaseBusiness<DoanhNghiepDichVuLichSu>
	{
        Task<List<DoanhNghiepDichVuLichSu>> GetByDoanhNghiepIDAndYearAndMonthToListAsync(long doanhNghiepID, int year, int month);
        Task<string> InsertItemsByDataTableAsync(DataTable table);
    }
}
