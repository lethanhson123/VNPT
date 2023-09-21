using Helper;
using Microsoft.AspNetCore.Hosting;

namespace API.Controllers
{
    public class BaseController<T, TBaseBusiness> : Controller
        where T : BaseModel
        where TBaseBusiness : IBaseBusiness<T>
    {
        private readonly TBaseBusiness _baseBusiness;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BaseController(TBaseBusiness baseBusiness
            , IWebHostEnvironment webHostEnvironment)
        {
            _baseBusiness = baseBusiness;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        [Route("SaveAndUploadFilesAsync")]
        public async Task<T> SaveAndUploadFilesAsync()
        {
            T model = JsonConvert.DeserializeObject<T>(Request.Form["data"]);
            model.Code = GlobalHelper.SetName(model.Name);
            try
            {
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
                            model.FileName = model.Code + "_" + i + "_" + GlobalHelper.InitializationDateTimeCode0001 + fileExtension;
                            string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, GlobalHelper.Image, model.GetType().Name);
                            bool isFolderExists = System.IO.Directory.Exists(folderPath);
                            if (!isFolderExists)
                            {
                                System.IO.Directory.CreateDirectory(folderPath);
                            }
                            var physicalPath = Path.Combine(folderPath, model.FileName);
                            using (var stream = new FileStream(physicalPath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                                T modelSave = (T)Activator.CreateInstance(typeof(T));
                                modelSave.ParentID = model.ParentID;
                                modelSave.FileName = model.FileName;
                                modelSave.Name = model.Name;
                                modelSave.Code = model.Code;
                                await _baseBusiness.SaveAsync(modelSave);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }
            return model;
        }       
        [HttpPost]
        [Route("SaveAndUploadFiles")]
        public T SaveAndUploadFiles()
        {
            T model = JsonConvert.DeserializeObject<T>(Request.Form["data"]);
            model.Code = GlobalHelper.SetName(model.Name);
            try
            {
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
                            model.FileName = model.Code + "_" + i + "_" + GlobalHelper.InitializationDateTimeCode0001 + fileExtension;
                            string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, GlobalHelper.Image, model.GetType().Name);
                            bool isFolderExists = System.IO.Directory.Exists(folderPath);
                            if (!isFolderExists)
                            {
                                System.IO.Directory.CreateDirectory(folderPath);
                            }
                            var physicalPath = Path.Combine(folderPath, model.FileName);
                            using (var stream = new FileStream(physicalPath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                                T modelSave = (T)Activator.CreateInstance(typeof(T));
                                modelSave.ParentID = model.ParentID;
                                modelSave.FileName = model.FileName;
                                modelSave.Name = model.Name;
                                modelSave.Code = model.Code;
                                _baseBusiness.Save(modelSave);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }

            return model;
        }

        [HttpPost]
        [Route("SaveAndUploadTwoFilesAsync")]
        public async Task<T> SaveAndUploadTwoFilesAsync()
        {
            T model = JsonConvert.DeserializeObject<T>(Request.Form["data"]);
            model.Code = GlobalHelper.SetName(model.Name);
            try
            {
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
                            if (fileExtension.Contains("txt") == false)
                            {
                                string fileName = model.Code + "_" + i + "_" + GlobalHelper.InitializationDateTimeCode0001 + fileExtension;
                                string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, GlobalHelper.Image, model.GetType().Name);
                                bool isFolderExists = System.IO.Directory.Exists(folderPath);
                                if (!isFolderExists)
                                {
                                    System.IO.Directory.CreateDirectory(folderPath);
                                }
                                var physicalPath = Path.Combine(folderPath, fileName);
                                using (var stream = new FileStream(physicalPath, FileMode.Create))
                                {
                                    file.CopyTo(stream);
                                    switch (i)
                                    {
                                        case 0:
                                            model.FileName = fileName;
                                            break;
                                        case 1:
                                            model.FileThumbnailName = fileName;
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }
            await _baseBusiness.SaveAsync(model);
            return model;
        }
        [HttpPost]
        [Route("SaveAndUploadTwoFiles")]
        public T SaveAndUploadTwoFiles()
        {
            T model = JsonConvert.DeserializeObject<T>(Request.Form["data"]);
            model.Code = GlobalHelper.SetName(model.Name);
            try
            {
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
                            if (fileExtension.Contains("txt") == false)
                            {
                                string fileName = model.Code + "_" + i + "_" + GlobalHelper.InitializationDateTimeCode0001 + fileExtension;
                                string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, GlobalHelper.Image, model.GetType().Name);
                                bool isFolderExists = System.IO.Directory.Exists(folderPath);
                                if (!isFolderExists)
                                {
                                    System.IO.Directory.CreateDirectory(folderPath);
                                }
                                var physicalPath = Path.Combine(folderPath, model.FileName);
                                using (var stream = new FileStream(physicalPath, FileMode.Create))
                                {
                                    file.CopyTo(stream);
                                    switch (i)
                                    {
                                        case 0:
                                            model.FileName = fileName;
                                            break;
                                        case 1:
                                            model.FileThumbnailName = fileName;
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }
            _baseBusiness.Save(model);
            return model;
        }
        [HttpPost]
        [Route("SaveAndUploadFileAsync")]
        public async Task<T> SaveAndUploadFileAsync()
        {
            T model = JsonConvert.DeserializeObject<T>(Request.Form["data"]);
            model.Code = GlobalHelper.SetName(model.Name);
            try
            {
                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files[0];
                    if (file == null || file.Length == 0)
                    {
                    }
                    if (file != null)
                    {
                        string fileExtension = Path.GetExtension(file.FileName);
                        model.FileName = model.Code + "_" + GlobalHelper.InitializationDateTimeCode0001 + fileExtension;
                        string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, GlobalHelper.Image, model.GetType().Name);
                        bool isFolderExists = System.IO.Directory.Exists(folderPath);
                        if (!isFolderExists)
                        {
                            System.IO.Directory.CreateDirectory(folderPath);
                        }
                        var physicalPath = Path.Combine(folderPath, model.FileName);
                        using (var stream = new FileStream(physicalPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }
            await _baseBusiness.SaveAsync(model);
            return model;
        }
        [HttpPost]
        [Route("SaveAndUploadFile")]
        public T SaveAndUploadFile()
        {
            T model = JsonConvert.DeserializeObject<T>(Request.Form["data"]);
            model.Code = GlobalHelper.SetName(model.Name);
            try
            {
                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files[0];
                    if (file == null || file.Length == 0)
                    {
                    }
                    if (file != null)
                    {
                        string fileExtension = Path.GetExtension(file.FileName);
                        model.FileName = model.Code + "_" + GlobalHelper.InitializationDateTimeCode0001 + fileExtension;
                        string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, GlobalHelper.Image, model.GetType().Name);
                        bool isFolderExists = System.IO.Directory.Exists(folderPath);
                        if (!isFolderExists)
                        {
                            System.IO.Directory.CreateDirectory(folderPath);
                        }
                        var physicalPath = Path.Combine(folderPath, model.FileName);
                        using (var stream = new FileStream(physicalPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string mes = e.Message;
            }
            _baseBusiness.Save(model);
            return model;
        }
        [HttpPost]
        [Route("SaveList")]
        public virtual List<T> SaveList()
        {
            List<T> result = JsonConvert.DeserializeObject<List<T>>(Request.Form["data"]);
            foreach (T item in result)
            {
                if (item.ID == 0)
                {
                    if (!string.IsNullOrEmpty(item.Name))
                    {
                        _baseBusiness.Save(item);
                    }
                }
                else
                {
                    _baseBusiness.Save(item);
                }
            }
            return result;
        }
        [HttpPost]
        [Route("SaveListAsync")]
        public virtual async Task<List<T>> SaveListAsync()
        {
            List<T> result = JsonConvert.DeserializeObject<List<T>>(Request.Form["data"]);
            foreach (T item in result)
            {
                if (item.ID == 0)
                {
                    if (!string.IsNullOrEmpty(item.Name))
                    {
                       await _baseBusiness.SaveAsync(item);
                    }
                }
                else
                {
                    await _baseBusiness.SaveAsync(item);
                }
            }
            return result;
        }
        [HttpPost]
        [Route("Save")]
        public virtual T Save()
        {
            T result = JsonConvert.DeserializeObject<T>(Request.Form["data"]);
            _baseBusiness.Save(result);
            return result;
        }
        [HttpPost]
        [Route("SaveAsync")]
        public virtual async Task<T> SaveAsync()
        {
            T result = JsonConvert.DeserializeObject<T>(Request.Form["data"]);
            await _baseBusiness.SaveAsync(result);
            return result;
        }
        [HttpPost]
        [Route("Remove")]
        public virtual int Remove()
        {
            long ID = JsonConvert.DeserializeObject<long>(Request.Form["data"]);
            int result = _baseBusiness.Remove(ID);
            return result;
        }
        [HttpPost]
        [Route("RemoveAsync")]
        public virtual async Task<int> RemoveAsync()
        {
            long ID = JsonConvert.DeserializeObject<long>(Request.Form["data"]);
            int result = await _baseBusiness.RemoveAsync(ID);
            return result;
        }

        [HttpPost]
        [Route("GetByID")]
        public virtual T GetByID()
        {
            long ID = JsonConvert.DeserializeObject<long>(Request.Form["data"]);
            T result = _baseBusiness.GetByID(ID);
            return result;
        }
        [HttpPost]
        [Route("GetByIDAsync")]
        public virtual async Task<T> GetByIDAsync()
        {
            long ID = JsonConvert.DeserializeObject<long>(Request.Form["data"]);
            T result = await _baseBusiness.GetByIDAsync(ID);
            return result;
        }
        [HttpPost]
        [Route("GetAllToList")]
        public virtual List<T> GetAllToList()
        {
            var result = _baseBusiness.GetAllToList();
            return result;
        }
        [HttpPost]
        [Route("GetAllToListAsync")]
        public virtual async Task<List<T>> GetAllToListAsync()
        {
            var result = await _baseBusiness.GetAllToListAsync();
            return result;
        }
        [HttpPost]
        [Route("GetAllAndEmptyToList")]
        public virtual List<T> GetAllAndEmptyToList()
        {
            var result = _baseBusiness.GetAllAndEmptyToList();
            return result;
        }
        [HttpPost]
        [Route("GetAllAndEmptyToListAsync")]
        public virtual async Task<List<T>> GetAllAndEmptyToListAsync()
        {
            var result = await _baseBusiness.GetAllAndEmptyToListAsync();
            return result;
        }
        [HttpPost]
        [Route("GetByActiveToList")]
        public virtual List<T> GetByActiveToList()
        {
            bool active = JsonConvert.DeserializeObject<bool>(Request.Form["data"]);
            var result = _baseBusiness.GetByActiveToList(active);
            return result;
        }
        [HttpPost]
        [Route("GetByActiveToListAsync")]
        public virtual async Task<List<T>> GetByActiveToListAsync()
        {
            bool active = JsonConvert.DeserializeObject<bool>(Request.Form["data"]);
            var result = await _baseBusiness.GetByActiveToListAsync(active);
            return result;
        }
        [HttpPost]
        [Route("GetByParentIDToList")]
        public virtual List<T> GetByParentIDToList()
        {
            long parentID = JsonConvert.DeserializeObject<long>(Request.Form["data"]);
            var result = _baseBusiness.GetByParentIDToList(parentID);
            return result;
        }
        [HttpPost]
        [Route("GetByParentIDToListAsync")]
        public virtual async Task<List<T>> GetByParentIDToListAsync()
        {
            long parentID = JsonConvert.DeserializeObject<long>(Request.Form["data"]);
            var result = await _baseBusiness.GetByParentIDToListAsync(parentID);
            return result;
        }
        [HttpPost]
        [Route("GetByParentIDAndEmptyToList")]
        public virtual List<T> GetByParentIDAndEmptyToList()
        {
            long parentID = JsonConvert.DeserializeObject<long>(Request.Form["data"]);
            var result = _baseBusiness.GetByParentIDAndEmptyToList(parentID);
            return result;
        }
        [HttpPost]
        [Route("GetByParentIDAndEmptyToListAsync")]
        public virtual async Task<List<T>> GetByParentIDAndEmptyToListAsync()
        {
            long parentID = JsonConvert.DeserializeObject<long>(Request.Form["data"]);
            var result = await _baseBusiness.GetByParentIDAndEmptyToListAsync(parentID);
            return result;
        }
        [HttpPost]
        [Route("GetByParentIDAndActiveToList")]
        public virtual List<T> GetByParentIDAndActiveToList()
        {
            long parentID = JsonConvert.DeserializeObject<long>(Request.Form["parentID"]);
            bool active = JsonConvert.DeserializeObject<bool>(Request.Form["active"]);
            var result = _baseBusiness.GetByParentIDAndActiveToList(parentID, active);
            return result;
        }
        [HttpPost]
        [Route("GetByParentIDAndActiveToListAsync")]
        public virtual async Task<List<T>> GetByParentIDAndActiveToListAsync()
        {
            long parentID = JsonConvert.DeserializeObject<long>(Request.Form["parentID"]);
            bool active = JsonConvert.DeserializeObject<bool>(Request.Form["active"]);
            var result = await _baseBusiness.GetByParentIDAndActiveToListAsync(parentID, active);
            return result;
        }
    }
}
