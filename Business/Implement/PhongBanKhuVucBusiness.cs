
namespace Business.Implement
{
    public class PhongBanKhuVucBusiness : BaseBusiness<PhongBanKhuVuc, IPhongBanKhuVucRepository>, IPhongBanKhuVucBusiness
    {
        private readonly IPhongBanKhuVucRepository _PhongBanKhuVucRepository;
        public PhongBanKhuVucBusiness(IPhongBanKhuVucRepository PhongBanKhuVucRepository) : base(PhongBanKhuVucRepository)
        {
            _PhongBanKhuVucRepository = PhongBanKhuVucRepository;
        }
        public virtual async Task<List<PhongBanKhuVuc>> GetSQLByParentIDAsync(long parentID)
        {
            List<PhongBanKhuVuc> result = new List<PhongBanKhuVuc>();
            if (parentID > 0)
            {
                SqlParameter[] parameters =
                 {
                    new SqlParameter("@ParentID",parentID),
                };
                result = await _PhongBanKhuVucRepository.GetByStoredProcedureToListAsync("sp_PhongBanKhuVucSelectItemsByParentID", parameters);
            }
            return result;
        }
    }
}
