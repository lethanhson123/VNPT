
namespace Business.Implement
{
    public class GoiCuocBusiness : BaseBusiness<GoiCuoc, IGoiCuocRepository>, IGoiCuocBusiness
    {
        private readonly IGoiCuocRepository _GoiCuocRepository;
        public GoiCuocBusiness(IGoiCuocRepository GoiCuocRepository) : base(GoiCuocRepository)
        {
            _GoiCuocRepository = GoiCuocRepository;
        }
    }
}
