namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class XaController : BaseController<Xa, IXaBusiness>
    {
        private readonly IXaBusiness _XaBusiness;
        public XaController(IXaBusiness XaBusiness) : base(XaBusiness)
        {
            _XaBusiness = XaBusiness;
        }
		[HttpPost]
		[Route("GetSQLByNhanVienID_ActiveAsync")]
		public virtual async Task<List<Xa>> GetSQLByNhanVienID_ActiveAsync()
		{
			List<Xa> result = new List<Xa>();
			try
			{
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
				result = await _XaBusiness.GetSQLByNhanVienID_ActiveAsync(nhanVienID);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
	}
}
