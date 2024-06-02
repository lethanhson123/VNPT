using Microsoft.AspNetCore.Hosting;

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class EmailLichSuController : BaseController<EmailLichSu, IEmailLichSuBusiness>
    {
        private readonly IEmailLichSuBusiness _EmailLichSuBusiness;
        public EmailLichSuController(IEmailLichSuBusiness EmailLichSuBusiness) : base(EmailLichSuBusiness)
        {
            _EmailLichSuBusiness = EmailLichSuBusiness;
        }
        [HttpGet]
        [Route("OnLoadOpen")]
        public string OnLoadOpen(long ID)
        {  
            string result= _EmailLichSuBusiness.UpdateSQLByID(ID);
            return result;
        }
        [HttpPost]
        [Route("GetBySearchString_BatDau_KetThucToListAsync")]
        public virtual async Task<List<EmailLichSu>> GetBySearchString_BatDau_KetThucToListAsync()
        {
            BaseParameter baseParameter = new BaseParameter();
            List<EmailLichSu> result = new List<EmailLichSu>();
           
            try
            {
                baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                if (baseParameter.Token == GlobalHelper.Token)
                {
                    baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
                    result = await _EmailLichSuBusiness.GetBySearchString_BatDau_KetThucToListAsync(baseParameter.SearchString, baseParameter.BatDau.Value, baseParameter.KetThuc.Value);
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
            return result;
        }
    }
}
