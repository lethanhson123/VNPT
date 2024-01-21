namespace Data.Repository.Implement
{
    public class DoanhNghiepRepository : BaseRepository<DoanhNghiep>, IDoanhNghiepRepository
    {
        private readonly VNPTContext _context;        
        public DoanhNghiepRepository(VNPTContext context) : base(context)
        {
            _context = context;            
        }
		public virtual async Task<List<DoanhNghiepTranfer>> GetByStoredProcedureToListTranferAsync(string storedProcedureName, params SqlParameter[] parameters)
		{
			List<DoanhNghiepTranfer> result = new List<DoanhNghiepTranfer>();
			try
			{
				DataTable dt = await SQLHelper.FillDataTableAsync(_context.Database.GetConnectionString(), storedProcedureName, parameters);
				result = SQLHelper.ToList<DoanhNghiepTranfer>(dt);
			}
			catch (Exception ex)
			{
				string message = ex.Message;
			}
			return result;
		}
	}
}
