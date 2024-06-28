using Microsoft.AspNetCore.Hosting;

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class EmailMauController : BaseController<EmailMau, IEmailMauBusiness>
    {
        private readonly IEmailMauBusiness _EmailMauBusiness;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public EmailMauController(IEmailMauBusiness EmailMauBusiness, IWebHostEnvironment WebHostEnvironment) : base(EmailMauBusiness)
        {
            _EmailMauBusiness = EmailMauBusiness;
            _WebHostEnvironment = WebHostEnvironment;
        }
        [HttpPost]
        [Route("SaveAndUploadFileAsync")]
        public async Task<EmailMau> SaveAndUploadFileAsync()
        {
            EmailMau model = JsonConvert.DeserializeObject<EmailMau>(Request.Form["data"]);
            try
            {
                if (model.Description == GlobalHelper.Token)
                {
                    model.Description = GlobalHelper.APISuccessMessage;
                    if (Request.Form.Files.Count > 0)
                    {
                        var file = Request.Form.Files[0];
                        if (file == null || file.Length == 0)
                        {
                        }
                        if (file != null)
                        {
                            string fileExtension = Path.GetExtension(file.FileName);
                            model.FileName = model.ID + "_" + GlobalHelper.InitializationDateTimeCode0001 + fileExtension;
                            string folderPath = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, model.GetType().Name);
                            bool isFolderExists = System.IO.Directory.Exists(folderPath);
                            if (!isFolderExists)
                            {
                                System.IO.Directory.CreateDirectory(folderPath);
                            }
                            var physicalPath = Path.Combine(folderPath, model.Note);
                            using (var stream = new FileStream(physicalPath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                                model.FileName = GlobalHelper.APISite + GlobalHelper.Download + "/" + model.GetType().Name + "/" + model.FileName;
                            }
                        }
                    }
                    await _EmailMauBusiness.SaveAsync(model);
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
