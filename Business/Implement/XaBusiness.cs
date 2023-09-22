
namespace Business.Implement
{
    public class XaBusiness : BaseBusiness<Xa, IXaRepository>, IXaBusiness
    {
        private readonly IXaRepository _XaRepository;
        public XaBusiness(IXaRepository XaRepository) : base(XaRepository)
        {
            _XaRepository = XaRepository;
        }
    }
}
