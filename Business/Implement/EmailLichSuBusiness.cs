
using Data.Repository.Implement;
using Data.Repository.Interface;
using Helper.Model;
using System;

namespace Business.Implement
{
    public class EmailLichSuBusiness : BaseBusiness<EmailLichSu, IEmailLichSuRepository>, IEmailLichSuBusiness
    {
        private readonly IEmailLichSuRepository _EmailLichSuRepository;
        public EmailLichSuBusiness(IEmailLichSuRepository EmailLichSuRepository) : base(EmailLichSuRepository)
        {
            _EmailLichSuRepository = EmailLichSuRepository;
        }
        public virtual string UpdateSQLByID(long ID)
        {
            SqlParameter[] parameters =
            {
                    new SqlParameter("@ID",ID),
            };
            return ExecuteNonQueryByStoredProcedure("sp_EmailLichSuUpdateSingleItem", parameters);
        }
        public virtual async Task<List<EmailLichSu>> GetBySearchStringToListAsync(string SearchString)
        {
            List<EmailLichSu> result = new List<EmailLichSu>();
            if (!string.IsNullOrEmpty(SearchString))
            {
                result = await GetByCondition(model => model.Name.Contains(SearchString) || model.EmailTo.Contains(SearchString) || model.EmailFrom.Contains(SearchString)).OrderByDescending(item => item.DateSend).ToListAsync();
            }
            return result;
        }
        public virtual async Task<List<EmailLichSu>> GetByBatDau_KetThucToListAsync(DateTime BatDau, DateTime KetThuc)
        {
            List<EmailLichSu> result = new List<EmailLichSu>();
            BatDau = new DateTime(BatDau.Year, BatDau.Month, BatDau.Day, 0, 0, 0);
            KetThuc = new DateTime(KetThuc.Year, KetThuc.Month, KetThuc.Day, 23, 59, 59);
            result = await GetByCondition(model => model.DateSend >= BatDau && model.DateSend <= KetThuc).OrderByDescending(item => item.DateSend).ToListAsync();

            return result;
        }
        public virtual async Task<List<EmailLichSu>> GetBySearchString_BatDau_KetThucToListAsync(string SearchString, DateTime BatDau, DateTime KetThuc)
        {
            List<EmailLichSu> result = new List<EmailLichSu>();
            if (!string.IsNullOrEmpty(SearchString))
            {
                result = await GetBySearchStringToListAsync(SearchString);
            }
            else
            {
                result = await GetByBatDau_KetThucToListAsync(BatDau, KetThuc);
            }
            return result;
        }
    }
}
