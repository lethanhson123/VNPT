
namespace Business.Implement
{
    public class DoanhNghiepBusiness : BaseBusiness<DoanhNghiep, IDoanhNghiepRepository>, IDoanhNghiepBusiness
    {
        private readonly IDoanhNghiepRepository _DoanhNghiepRepository;
        public DoanhNghiepBusiness(IDoanhNghiepRepository DoanhNghiepRepository) : base(DoanhNghiepRepository)
        {
            _DoanhNghiepRepository = DoanhNghiepRepository;
        }

        public virtual async Task<List<DoanhNghiep>> GetBySearchStringToListAsync(string searchString)
        {
            List<DoanhNghiep> result = new List<DoanhNghiep>();
            if (!string.IsNullOrEmpty(searchString))
            {
                result = await _DoanhNghiepRepository.GetByCondition(item => item.Code.Contains(searchString) || item.Name.Contains(searchString)).ToListAsync();
            }
            return result;
        }
        public virtual async Task<List<DoanhNghiep>> GetByHuyenIDAndXaIDOrSearchStringToListAsync(long huyenID, long xaID, string searchString)
        {
            List<DoanhNghiep> result = new List<DoanhNghiep>();
            if (!string.IsNullOrEmpty(searchString))
            {
                result = await GetBySearchStringToListAsync(searchString);
            }
            else
            {
                if (huyenID > 0)
                {
                    if (xaID > 0)
                    {
                        result = await _DoanhNghiepRepository.GetByCondition(item => item.HuyenID == huyenID && item.XaID == xaID).ToListAsync();
                    }
                    else
                    {
                        result = await _DoanhNghiepRepository.GetByCondition(item => item.HuyenID == huyenID).ToListAsync();
                    }
                }
                else
                {
                    result = await GetAllToListAsync();
                }

            }
            return result;
        }
    }
}
