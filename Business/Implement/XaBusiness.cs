
namespace Business.Implement
{
    public class XaBusiness : BaseBusiness<Xa, IXaRepository>, IXaBusiness
    {
        private readonly IXaRepository _XaRepository;
        public XaBusiness(IXaRepository XaRepository) : base(XaRepository)
        {
            _XaRepository = XaRepository;
        }
		public virtual async Task<List<Xa>> GetSQLByNhanVienID_ActiveAsync(long nhanVienID = 0, bool active = true)
		{
			List<Xa> result = new List<Xa>();
			if (nhanVienID > 0)
			{
				SqlParameter[] parameters =
				 {
					new SqlParameter("@NhanVienID",nhanVienID),
					new SqlParameter("@Active",active),
				};
				result = await _XaRepository.GetByStoredProcedureToListAsync("sp_XaSelectItemsByNhanVienIDAndActive", parameters);
			}
			return result;
		}
	}
}
