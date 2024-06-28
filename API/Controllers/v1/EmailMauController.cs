

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
                            var physicalPath = Path.Combine(folderPath, model.FileName);
                            using (var stream = new FileStream(physicalPath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                                model.FileName = GlobalHelper.APISite + GlobalHelper.Download + "/" + model.GetType().Name + "/" + model.FileName;
                            }

                            byte[] byteArray = System.IO.File.ReadAllBytes(physicalPath);
                            using (MemoryStream stream = new MemoryStream())
                            {
                                stream.Write(byteArray, 0, (int)byteArray.Length);
                                using (WordprocessingDocument doc = WordprocessingDocument.Open(stream, true))
                                {

                                    HtmlConverterSettings settings = new HtmlConverterSettings()
                                    {
                                        PageTitle = model.Name,
                                    };
                                    XElement html = HtmlConverter.ConvertToHtml(doc, settings);

                                    model.HTMLContent = html.ToStringNewLineOnAttributes();

                                    HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                                    document.LoadHtml(model.HTMLContent);
                                    var nodes = document.DocumentNode.SelectNodes("//body");
                                    foreach (var node in nodes)
                                    {
                                        model.HTMLContent = node.OuterHtml;
                                    }
                                    model.HTMLContent = model.HTMLContent.Replace(@"<body", @"<p");
                                    model.HTMLContent = model.HTMLContent.Replace(@"</body>", @"<p>");
                                    model.HTMLContent = model.HTMLContent.Replace(@"<div", @"<p");
                                    model.HTMLContent = model.HTMLContent.Replace(@"</div>", @"</p>");
                                    model.HTMLContent = model.HTMLContent.Replace(@"<h1", @"<p");
                                    model.HTMLContent = model.HTMLContent.Replace(@"</h1>", @"</p>");
                                    model.HTMLContent = model.HTMLContent.Replace(@"<h2", @"<p");
                                    model.HTMLContent = model.HTMLContent.Replace(@"</h2>", @"</p>");
                                    model.HTMLContent = model.HTMLContent.Replace(@"<h3", @"<p");
                                    model.HTMLContent = model.HTMLContent.Replace(@"</h3>", @"</p>");
                                    model.HTMLContent = model.HTMLContent.Replace(@"<h4", @"<p");
                                    model.HTMLContent = model.HTMLContent.Replace(@"</h4>", @"</p>");
                                    model.HTMLContent = model.HTMLContent.Replace(@"<h5", @"<p");
                                    model.HTMLContent = model.HTMLContent.Replace(@"</h5>", @"</p>");
                                    model.HTMLContent = model.HTMLContent.Replace(@"<h6", @"<p");
                                    model.HTMLContent = model.HTMLContent.Replace(@"</h6>", @"</p>");
                                    model.HTMLContent = model.HTMLContent.Replace(@"<table", @"<table class=""border""");
                                }
                            }
                        }
                    }
                    if (string.IsNullOrEmpty(model.HTMLContent))
                    {
                        model.HTMLContent = GlobalHelper.InitializationString;
                    }
                    if (model.HTMLContent.Contains("javascript:window.print();") == false)
                    {
                        if (model.Active == true)
                        {
                            string HTMLContent = GlobalHelper.InitializationString;
                            var physicalPathRead = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, "BieuMau.html");
                            using (FileStream fs = new FileStream(physicalPathRead, FileMode.Open))
                            {
                                using (StreamReader r = new StreamReader(fs, Encoding.UTF8))
                                {
                                    HTMLContent = r.ReadToEnd();
                                }
                            }
                            model.HTMLContent = HTMLContent.Replace("[MainContent]", model.HTMLContent);                            
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
