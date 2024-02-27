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
			BaseParameter baseParameter = new BaseParameter();
			List<Xa> result = new List<Xa>();
			Xa itemResult = new Xa();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _XaBusiness.GetSQLByNhanVienID_ActiveAsync(baseParameter.NhanVienID.Value);
				}
				else
				{
					baseParameter.APIMessage = GlobalHelper.APIErrorMessage;
				}
			}
			catch (Exception ex)
			{
				baseParameter.APIMessage = ex.Message;
			}
			if (result == null)
			{
				result = new List<Xa>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
	}
}
