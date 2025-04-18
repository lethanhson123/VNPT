﻿namespace Business.Implement
{
    public class BaseBusiness<T, TRepository> : IBaseBusiness<T>
        where T : BaseModel
        where TRepository : IBaseRepository<T>
    {
        private readonly TRepository _repository;
        public BaseBusiness(TRepository repository)
        {
            _repository = repository;
        }
        public virtual void Initialization(T model)
        {
            if (string.IsNullOrEmpty(model.Code))
            {
                model.Code = GlobalHelper.InitializationDateTimeCode;
            }
			if (string.IsNullOrEmpty(model.Display))
			{
				model.Display = model.Name + "-" + model.Code;
			}			
            if ((model.SortOrder == null) || (model.SortOrder == GlobalHelper.InitializationNumber))
            {
                model.SortOrder = 1;
            }            
        }
        public virtual T Save(T model)
        {
            Initialization(model);
            if (!string.IsNullOrEmpty(model.Code))
            {
                T modelExist = _repository.GetByCode(model.Code);                
                if (model.ID > 0)
                {
                    if (modelExist.ID == 0)
                    {
                        _repository.Update(model);
                    }
                    else
                    {
                        if (modelExist.ID == model.ID)
                        {
                            _repository.Update(model);
                        }
                    }
                }
                else
                {
                    if (modelExist.ID == 0)
                    {
                        _repository.Add(model);
                    }
                }
            }
            return model;
        }
        public virtual async Task<T> SaveAsync(T model)
        {
            Initialization(model);
            if (!string.IsNullOrEmpty(model.Code))
            {
                T modelExist = await _repository.GetByCodeAsync(model.Code);
                if (model.ID > 0)
                {
                    if (modelExist.ID == 0)
                    {
                        await _repository.UpdateAsync(model);
                    }
                    else
                    {
                        if (modelExist.ID == model.ID)
                        {
                            await _repository.UpdateAsync(model);
                        }
                    }
                }
                else
                {
                    if (modelExist.ID == 0)
                    {
                        await _repository.AddAsync(model);
                    }
                }
            }
            return model;
        }
        public virtual int Add(T model)
        {
            Initialization(model);
            return _repository.Add(model);
        }
        public virtual async Task<int> AddAsync(T model)
        {
            Initialization(model);
            return await _repository.AddAsync(model);
        }
        public virtual int AddRange(List<T> list)
        {
            return _repository.AddRange(list);
        }
        public virtual async Task<int> AddRangeAsync(List<T> list)
        {
            return await _repository.AddRangeAsync(list);
        }
        public virtual int Update(T model)
        {
            Initialization(model);
            return _repository.Update(model);
        }
        public virtual async Task<int> UpdateAsync(T model)
        {
            Initialization(model);
            return await _repository.UpdateAsync(model);
        }
        public virtual int Remove(long ID)
        {
            return _repository.Remove(ID);
        }
        public virtual async Task<int> RemoveAsync(long ID)
        {
            return await _repository.RemoveAsync(ID);
        }
        public virtual int RemoveRange(List<T> list)
        {
            return _repository.RemoveRange(list);
        }
        public virtual async Task<int> RemoveRangeAsync(List<T> list)
        {
            return await _repository.RemoveRangeAsync(list);
        }
        public virtual List<T> GetAllToList()
        {
            return _repository.GetAllToList();
        }
        public virtual async Task<List<T>> GetAllToListAsync()
        {
            return await _repository.GetAllToListAsync();
        }
        public virtual List<T> GetAllAndEmptyToList()
        {
            List<T> result = new List<T>();
            T empty = (T)Activator.CreateInstance(typeof(T));
            empty.SortOrder = GlobalHelper.InitializationNumber;
            result.Add(empty);
            List<T> list = _repository.GetAllToList();
            if (list.Count > 0)
            {
                result.AddRange(list);
            }
            return result;
        }
        public virtual async Task<List<T>> GetAllAndEmptyToListAsync()
        {
            List<T> result = new List<T>();
            try
            {
                T empty = (T)Activator.CreateInstance(typeof(T));
                empty.SortOrder = GlobalHelper.InitializationNumber;
                result.Add(empty);
                List<T> list = await _repository.GetAllToListAsync();
                if (list.Count > 0)
                {
                    result.AddRange(list);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return result;
        }
        public virtual List<T> GetByActiveToList(bool active)
        {
            return _repository.GetByActiveToList(active);
        }
        public virtual async Task<List<T>> GetByActiveToListAsync(bool active)
        {
            return await _repository.GetByActiveToListAsync(active);
        }
		public virtual List<T> GetByIDToList(long ID)
		{
			return _repository.GetByIDToList(ID);
		}
		public virtual async Task<List<T>> GetByIDToListAsync(long ID)
		{
			return await _repository.GetByIDToListAsync(ID);
		}
		public virtual List<T> GetByParentIDToList(long parentID)
        {
            return _repository.GetByParentIDToList(parentID);
        }
        public virtual async Task<List<T>> GetByParentIDToListAsync(long parentID)
        {
            return await _repository.GetByParentIDToListAsync(parentID);
        }
        public virtual List<T> GetByParentIDAndEmptyToList(long parentID)
        {
            List<T> result = new List<T>();
            try
            {
                T empty = (T)Activator.CreateInstance(typeof(T));
                empty.SortOrder = GlobalHelper.InitializationNumber;
                result.Add(empty);
                List<T> list = _repository.GetByParentIDToList(parentID);
                if (list.Count > 0)
                {
                    result.AddRange(list);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return result;
        }
        public virtual async Task<List<T>> GetByParentIDAndEmptyToListAsync(long parentID)
        {
            List<T> result = new List<T>();
            try
            {
                T empty = (T)Activator.CreateInstance(typeof(T));
                empty.SortOrder = GlobalHelper.InitializationNumber;
                result.Add(empty);
                List<T> list = await _repository.GetByParentIDToListAsync(parentID);
                if (list.Count > 0)
                {
                    result.AddRange(list);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return result;
        }
        public virtual List<T> GetByParentIDAndActiveToList(long parentID, bool active)
        {
            return _repository.GetByParentIDAndActiveToList(parentID, active);
        }
        public virtual async Task<List<T>> GetByParentIDAndActiveToListAsync(long parentID, bool active)
        {
            return await _repository.GetByParentIDAndActiveToListAsync(parentID, active);
        }
        public virtual IQueryable<T> GetByCondition(Expression<Func<T, bool>> whereCondition)
        {
            return _repository.GetByCondition(whereCondition);
        }
        public virtual T GetByID(long ID)
        {
            var result = _repository.GetByID(ID);
            return result;
        }
        public virtual async Task<T> GetByIDAsync(long ID)
        {
            var result = await _repository.GetByIDAsync(ID);
            return result;
        }
        public virtual T GetByName(string name)
        {
            var result = _repository.GetByName(name);
            return result;
        }
        public virtual async Task<T> GetByNameAsync(string name)
        {
            var result = await _repository.GetByNameAsync(name);
            return result;
        }
        public virtual T GetByCode(string code)
        {
            var result = _repository.GetByCode(code);
            return result;
        }
        public virtual async Task<T> GetByCodeAsync(string code)
        {
            var result = await _repository.GetByCodeAsync(code);
            return result;
        }
        public virtual string ExecuteNonQueryByStoredProcedure(string storedProcedureName, params SqlParameter[] parameters)
        {
            return _repository.ExecuteNonQueryByStoredProcedure(storedProcedureName, parameters);
        }
        public virtual async Task<string> ExecuteNonQueryByStoredProcedureAsync(string storedProcedureName, params SqlParameter[] parameters)
        {
            return await _repository.ExecuteNonQueryByStoredProcedureAsync(storedProcedureName, parameters);
        }
        public virtual List<T> GetByStoredProcedureToList(string storedProcedureName, params SqlParameter[] parameters)
        {
            return _repository.GetByStoredProcedureToList(storedProcedureName, parameters);
        }
        public virtual async Task<List<T>> GetByStoredProcedureToListAsync(string storedProcedureName, params SqlParameter[] parameters)
        {
            return await _repository.GetByStoredProcedureToListAsync(storedProcedureName, parameters);
        }
    }
}
