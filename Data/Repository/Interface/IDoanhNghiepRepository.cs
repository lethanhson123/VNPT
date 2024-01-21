namespace Data.Repository.Interface
{
    public interface IDoanhNghiepRepository : IBaseRepository<DoanhNghiep>
    {
		Task<List<DoanhNghiepTranfer>> GetByStoredProcedureToListTranferAsync(string storedProcedureName, params SqlParameter[] parameters);

	}
}
