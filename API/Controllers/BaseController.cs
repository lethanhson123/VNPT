using Business.Model;
using Microsoft.AspNetCore.Http;

namespace API.Controllers
{
	public class BaseController<T, TBaseBusiness> : Controller
		where T : BaseModel
		where TBaseBusiness : IBaseBusiness<T>
	{
		private readonly TBaseBusiness _baseBusiness;

		public BaseController(TBaseBusiness baseBusiness)
		{
			_baseBusiness = baseBusiness;
		}

		[HttpPost]
		[Route("SaveList")]
		public virtual List<T> SaveList()
		{
			List<T> result = new List<T>();
			T itemResult = (T)Activator.CreateInstance(typeof(T));
			try
			{
				result = JsonConvert.DeserializeObject<List<T>>(Request.Form["data"]);
				if (result.Count > 0)
				{
					itemResult = result[0];
					if (itemResult.Description == GlobalHelper.Token)
					{
						itemResult.Description = GlobalHelper.APISuccessMessage;
						foreach (T item in result)
						{
							_baseBusiness.Save(item);
						}
					}
					else
					{
						itemResult.Description = GlobalHelper.APIErrorMessage;
					}
				}
			}
			catch (Exception ex)
			{
				itemResult.Description = ex.Message;
			}
			result = new List<T>();
			result.Add(itemResult);
			return result;
		}
		[HttpPost]
		[Route("SaveListAsync")]
		public virtual async Task<List<T>> SaveListAsync()
		{
			List<T> result = new List<T>();
			T itemResult = (T)Activator.CreateInstance(typeof(T));
			try
			{
				result = JsonConvert.DeserializeObject<List<T>>(Request.Form["data"]);
				if (result.Count > 0)
				{
					itemResult = result[0];
					if (itemResult.Description == GlobalHelper.Token)
					{
						itemResult.Description = GlobalHelper.APISuccessMessage;
						foreach (T item in result)
						{
							await _baseBusiness.SaveAsync(item);
						}
					}
					else
					{
						itemResult.Description = GlobalHelper.APIErrorMessage;
					}
				}
			}
			catch (Exception ex)
			{
				itemResult.Description = ex.Message;
			}
			result = new List<T>();
			result.Add(itemResult);
			return result;
		}
		[HttpPost]
		[Route("Save")]
		public virtual T Save()
		{
			T result = (T)Activator.CreateInstance(typeof(T));
			try
			{
				result = JsonConvert.DeserializeObject<T>(Request.Form["data"]);
				if (result.Description == GlobalHelper.Token)
				{
					result.Description = GlobalHelper.APISuccessMessage;
					_baseBusiness.Save(result);
				}
				else
				{
					result.Description = GlobalHelper.APIErrorMessage;
				}
			}
			catch (Exception ex)
			{
				result.Description = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("SaveAsync")]
		public virtual async Task<T> SaveAsync()
		{
			T result = (T)Activator.CreateInstance(typeof(T));
			try
			{
				result = JsonConvert.DeserializeObject<T>(Request.Form["data"]);
				if (result.Description == GlobalHelper.Token)
				{
					result.Description = GlobalHelper.APISuccessMessage;
					await _baseBusiness.SaveAsync(result);
				}
				else
				{
					result.Description = GlobalHelper.APIErrorMessage;
				}
			}
			catch (Exception ex)
			{
				result.Description = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("Remove")]
		public virtual BaseParameter Remove()
		{
			BaseParameter baseParameter = new BaseParameter();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					_baseBusiness.Remove(baseParameter.ID);
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
			return baseParameter;
		}
		[HttpPost]
		[Route("RemoveAsync")]
		public virtual async Task<BaseParameter> RemoveAsync()
		{
			BaseParameter baseParameter = new BaseParameter();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					await _baseBusiness.RemoveAsync(baseParameter.ID);
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
			return baseParameter;
		}

		[HttpPost]
		[Route("GetByID")]
		public virtual T GetByID()
		{
			BaseParameter baseParameter = new BaseParameter();
			T result = (T)Activator.CreateInstance(typeof(T));
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = _baseBusiness.GetByID(baseParameter.ID);
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
			result.Description = baseParameter.APIMessage;
			return result;
		}
		[HttpPost]
		[Route("GetByIDAsync")]
		public virtual async Task<T> GetByIDAsync()
		{
			BaseParameter baseParameter = new BaseParameter();
			T result = (T)Activator.CreateInstance(typeof(T));
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _baseBusiness.GetByIDAsync(baseParameter.ID);
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
			result.Description = baseParameter.APIMessage;
			return result;
		}
		[HttpPost]
		[Route("GetAllToList")]
		public virtual List<T> GetAllToList()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<T> result = new List<T>();
			T itemResult = (T)Activator.CreateInstance(typeof(T));
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = _baseBusiness.GetAllToList();					
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
				result = new List<T>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("GetAllToListAsync")]
		public virtual async Task<List<T>> GetAllToListAsync()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<T> result = new List<T>();
			T itemResult = (T)Activator.CreateInstance(typeof(T));
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _baseBusiness.GetAllToListAsync();					
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
				result = new List<T>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("GetAllAndEmptyToList")]
		public virtual List<T> GetAllAndEmptyToList()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<T> result = new List<T>();
			T itemResult = (T)Activator.CreateInstance(typeof(T));
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = _baseBusiness.GetAllAndEmptyToList();					
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
				result = new List<T>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("GetAllAndEmptyToListAsync")]
		public virtual async Task<List<T>> GetAllAndEmptyToListAsync()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<T> result = new List<T>();
			T itemResult = (T)Activator.CreateInstance(typeof(T));
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _baseBusiness.GetAllAndEmptyToListAsync();					
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
				result = new List<T>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("GetByActiveToList")]
		public virtual List<T> GetByActiveToList()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<T> result = new List<T>();
			T itemResult = (T)Activator.CreateInstance(typeof(T));
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = _baseBusiness.GetByActiveToList(baseParameter.Active.Value);					
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
				result = new List<T>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("GetByActiveToListAsync")]
		public virtual async Task<List<T>> GetByActiveToListAsync()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<T> result = new List<T>();
			T itemResult = (T)Activator.CreateInstance(typeof(T));
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _baseBusiness.GetByActiveToListAsync(baseParameter.Active.Value);					
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
				result = new List<T>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("GetByParentIDToList")]
		public virtual List<T> GetByParentIDToList()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<T> result = new List<T>();
			T itemResult = (T)Activator.CreateInstance(typeof(T));
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = _baseBusiness.GetByParentIDToList(baseParameter.ParentID.Value);					
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
				result = new List<T>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("GetByParentIDToListAsync")]
		public virtual async Task<List<T>> GetByParentIDToListAsync()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<T> result = new List<T>();
			T itemResult = (T)Activator.CreateInstance(typeof(T));
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _baseBusiness.GetByParentIDToListAsync(baseParameter.ParentID.Value);					
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
				result = new List<T>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("GetByParentIDAndEmptyToList")]
		public virtual List<T> GetByParentIDAndEmptyToList()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<T> result = new List<T>();
			T itemResult = (T)Activator.CreateInstance(typeof(T));
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = _baseBusiness.GetByParentIDAndEmptyToList(baseParameter.ParentID.Value);					
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
				result = new List<T>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("GetByParentIDAndEmptyToListAsync")]
		public virtual async Task<List<T>> GetByParentIDAndEmptyToListAsync()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<T> result = new List<T>();
			T itemResult = (T)Activator.CreateInstance(typeof(T));
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _baseBusiness.GetByParentIDAndEmptyToListAsync(baseParameter.ParentID.Value);					
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
				result = new List<T>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("GetByParentIDAndActiveToList")]
		public virtual List<T> GetByParentIDAndActiveToList()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<T> result = new List<T>();
			T itemResult = (T)Activator.CreateInstance(typeof(T));
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = _baseBusiness.GetByParentIDAndActiveToList(baseParameter.ParentID.Value, baseParameter.Active.Value);					
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
				result = new List<T>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("GetByParentIDAndActiveToListAsync")]
		public virtual async Task<List<T>> GetByParentIDAndActiveToListAsync()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<T> result = new List<T>();
			T itemResult = (T)Activator.CreateInstance(typeof(T));
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _baseBusiness.GetByParentIDAndActiveToListAsync(baseParameter.ParentID.Value, baseParameter.Active.Value);					
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
				result = new List<T>();
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
