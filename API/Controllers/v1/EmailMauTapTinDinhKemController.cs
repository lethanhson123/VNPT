using Microsoft.AspNetCore.Hosting;

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class EmailMauTapTinDinhKemController : BaseController<EmailMauTapTinDinhKem, IEmailMauTapTinDinhKemBusiness>
    {
        private readonly IEmailMauTapTinDinhKemBusiness _EmailMauTapTinDinhKemBusiness;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public EmailMauTapTinDinhKemController(IEmailMauTapTinDinhKemBusiness EmailMauTapTinDinhKemBusiness, IWebHostEnvironment webHostEnvironment) : base(EmailMauTapTinDinhKemBusiness)
        {
            _EmailMauTapTinDinhKemBusiness = EmailMauTapTinDinhKemBusiness;
            _WebHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        [Route("SaveAndUploadFilesAsync")]
        public async Task<EmailMauTapTinDinhKem> SaveAndUploadFilesAsync()
        {
            EmailMauTapTinDinhKem model = JsonConvert.DeserializeObject<EmailMauTapTinDinhKem>(Request.Form["data"]);
            
            try
            {
                if (model.Description == GlobalHelper.Token)
                {
                    model.Description = GlobalHelper.APISuccessMessage;
                    if (Request.Form.Files.Count > 0)
                    {
                        for (int i = 0; i < Request.Form.Files.Count; i++)
                        {
                            var file = Request.Form.Files[i];
                            if (file == null || file.Length == 0)
                            {
                            }
                            if (file != null)
                            {
                                string fileExtension = Path.GetExtension(file.FileName);
                                model.Code = model.ID + "_" + GlobalHelper.InitializationDateTimeCode0001 + fileExtension;
                                string folderPath = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, model.GetType().Name);
                                bool isFolderExists = System.IO.Directory.Exists(folderPath);
                                if (!isFolderExists)
                                {
                                    System.IO.Directory.CreateDirectory(folderPath);
                                }
                                var physicalPath = Path.Combine(folderPath, model.Code);
                                using (var stream = new FileStream(physicalPath, FileMode.Create))
                                {
                                    file.CopyTo(stream);
                                    model.Code = GlobalHelper.APISite + GlobalHelper.Download + "/" + model.GetType().Name + "/" + model.Code;
                                    model.ID = GlobalHelper.InitializationNumber;
                                    await _EmailMauTapTinDinhKemBusiness.SaveAsync(model);                                   
                                }
                            }
                        }
                    }
                }
                else
                {
                    model.Description = GlobalHelper.APIErrorMessage;
                }
            }
            catch (Exception e)
            {
                model.Description = e.Message;
            }
            return model;
        }

    }
}
