
namespace Business.Implement
{
    public class NhanVienKhuVucBusiness : BaseBusiness<NhanVienKhuVuc, INhanVienKhuVucRepository>, INhanVienKhuVucBusiness
    {
        private readonly INhanVienKhuVucRepository _NhanVienKhuVucRepository;
        public NhanVienKhuVucBusiness(INhanVienKhuVucRepository NhanVienKhuVucRepository) : base(NhanVienKhuVucRepository)
        {
            _NhanVienKhuVucRepository = NhanVienKhuVucRepository;
        }
        public virtual async Task<List<NhanVienKhuVuc>> GetSQLByParentIDAsync(long parentID)
        {
            List<NhanVienKhuVuc> result = new List<NhanVienKhuVuc>();
            if (parentID > 0)
            {
                SqlParameter[] parameters =
                 {
                    new SqlParameter("@ParentID",parentID),
                };
                result = await _NhanVienKhuVucRepository.GetByStoredProcedureToListAsync("sp_NhanVienKhuVucSelectItemsByParentID", parameters);
            }
            return result;
        }
    }
}
