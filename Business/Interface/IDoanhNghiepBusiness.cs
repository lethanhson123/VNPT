namespace Business.Interface
{
	public interface IDoanhNghiepBusiness : IBaseBusiness<DoanhNghiep>
	{
        Task<List<DoanhNghiep>> GetByHuyenIDAndXaIDOrSearchStringToListAsync(long huyenID, long xaID, string searchString);

    }
}
