namespace Business.Implement
{
    public class DoanhNghiepDichVuLichSuBusiness : BaseBusiness<DoanhNghiepDichVuLichSu, IDoanhNghiepDichVuLichSuRepository>, IDoanhNghiepDichVuLichSuBusiness
    {
        private readonly IDoanhNghiepDichVuLichSuRepository _DoanhNghiepDichVuLichSuRepository;
        private readonly IDoanhNghiepDichVuBusiness _DoanhNghiepDichVuBusiness;
        public DoanhNghiepDichVuLichSuBusiness(IDoanhNghiepDichVuLichSuRepository DoanhNghiepDichVuLichSuRepository, IDoanhNghiepDichVuBusiness DoanhNghiepDichVuBusiness) : base(DoanhNghiepDichVuLichSuRepository)
        {
            _DoanhNghiepDichVuLichSuRepository = DoanhNghiepDichVuLichSuRepository;
            _DoanhNghiepDichVuBusiness = DoanhNghiepDichVuBusiness;
        }
        public virtual async Task<List<DoanhNghiepDichVuLichSu>> GetByDoanhNghiepIDAndYearAndMonthToListAsync(long doanhNghiepID, int year, int month)
        {
            List<DoanhNghiepDichVuLichSu> result = new List<DoanhNghiepDichVuLichSu>();
            result = await _DoanhNghiepDichVuLichSuRepository.GetByCondition(item => item.DoanhNghiepID == doanhNghiepID && item.Year == year && item.Month == month).ToListAsync();
            return result;
        }
        public async Task<string> InsertItemsByDataTableAsync(DataTable table)
        {
            string result = GlobalHelper.InitializationString;
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    int rowCount = GlobalHelper.DoanhNghiepDichVuLichSuRowCount;
                    int rowFrom = 0;
                    int rowTo = rowCount;
                    try
                    {
                        while (rowTo < table.Rows.Count)
                        {
                            DataTable tableSub = table.Clone();
                            tableSub.TableName = "tableSub";
                            tableSub.Clear();
                            for (int i = rowFrom; i < rowTo; i++)
                            {
                                DataRow newRow = tableSub.NewRow();
                                newRow.ItemArray = table.Rows[i].ItemArray;
                                tableSub.Rows.Add(newRow);
                            }
                            SqlParameter[] parameters =
                            {
                            new SqlParameter("@Table",tableSub),
                            };
                            result = await ExecuteNonQueryByStoredProcedureAsync("sp_DoanhNghiepDichVuLichSuInsertItemsByDoanhNghiepDichVuLichSuExcel", parameters);
                            if (result != "-1")
                            {

                            }
                            rowFrom = rowTo;
                            rowTo = rowTo + rowCount;
                        }
                        DataTable tableSub001 = table.Clone();
                        tableSub001.TableName = "tableSub";
                        tableSub001.Clear();
                        for (int i = rowFrom; i < table.Rows.Count; i++)
                        {
                            DataRow newRow = tableSub001.NewRow();
                            newRow.ItemArray = table.Rows[i].ItemArray;
                            tableSub001.Rows.Add(newRow);
                        }
                        SqlParameter[] parameters001 =
                        {
                            new SqlParameter("@Table",tableSub001),
                            };
                        result = await ExecuteNonQueryByStoredProcedureAsync("sp_DoanhNghiepDichVuLichSuInsertItemsByDoanhNghiepDichVuLichSuExcel", parameters001);
                        if (result != "-1")
                        {

                        }
                    }
                    catch (Exception ex)
                    {
                        result = ex.Message;
                    }
                }
            }
            return result;
        }
    }
}
