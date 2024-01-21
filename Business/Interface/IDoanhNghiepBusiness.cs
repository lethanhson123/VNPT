namespace Business.Interface
{
	public interface IDoanhNghiepBusiness : IBaseBusiness<DoanhNghiep>
	{
        Task<List<DoanhNghiep>> GetBySearchStringToListAsync(string searchString);
        Task<List<DoanhNghiep>> GetByHuyenIDAndXaIDOrSearchStringToListAsync(long huyenID, long xaID, string searchString);
		Task<List<DoanhNghiep>> GetCAByHuyenIDAndXaIDOrSearchStringToListAsync(long huyenID, long xaID, string searchString);

		Task<List<DoanhNghiep>> GetByNhanVienIDOrSearchStringToListAsync(long nhanVienID, string searchString);
        Task<List<DoanhNghiep>> GetByPhongBanIDOrSearchStringToListAsync(long phongBanID, string searchString);
		Task<List<DoanhNghiep>> GetMaSoThueKhongTonTaiToListAsync();
		Task<List<DoanhNghiepTranfer>> GetSQLBySearchString_HuyenIDToListTranferAsync(string searchString, long huyenID);

	}
}
