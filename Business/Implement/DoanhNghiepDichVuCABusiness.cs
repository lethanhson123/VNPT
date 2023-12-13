
using Business.Interface;
using Data.Model;
using Data.Repository.Implement;
using Data.Repository.Interface;

namespace Business.Implement
{
	public class DoanhNghiepDichVuCABusiness : BaseBusiness<DoanhNghiepDichVuCA, IDoanhNghiepDichVuCARepository>, IDoanhNghiepDichVuCABusiness
	{
		private readonly IDoanhNghiepDichVuCARepository _DoanhNghiepDichVuCARepository;
		private readonly IDoanhNghiepBusiness _DoanhNghiepBusiness;
		private readonly IHuyenBusiness _IHuyenBusiness;
		public DoanhNghiepDichVuCABusiness(IDoanhNghiepDichVuCARepository DoanhNghiepDichVuCARepository, IDoanhNghiepBusiness doanhNghiepBusiness, IHuyenBusiness iHuyenBusiness) : base(DoanhNghiepDichVuCARepository)
		{
			_DoanhNghiepDichVuCARepository = DoanhNghiepDichVuCARepository;
			_DoanhNghiepBusiness = doanhNghiepBusiness;
			_IHuyenBusiness = iHuyenBusiness;
		}
		public override void Initialization(DoanhNghiepDichVuCA model)
		{
			if (string.IsNullOrEmpty(model.Code))
			{
				model.Code = GlobalHelper.InitializationDateTimeCode;
			}
			model.Display = model.Name + "-" + model.Code;
			if ((model.SortOrder == null) || (model.SortOrder == GlobalHelper.InitializationNumber))
			{
				model.SortOrder = 1;
			}

			if (!string.IsNullOrEmpty(model.HopDong))
			{
				model.IsHopDong = true;
			}
			if (!string.IsNullOrEmpty(model.DonXinCapChungThuSo))
			{
				model.IsDonXinCapChungThuSo = true;
			}
			if (!string.IsNullOrEmpty(model.CCCD))
			{
				model.IsCCCD = true;
			}
			if (!string.IsNullOrEmpty(model.GiayPhepKinhDoanh))
			{
				model.IsGiayPhepKinhDoanh = true;
			}
			if (!string.IsNullOrEmpty(model.HoaDon))
			{
				model.IsHoaDon = true;
			}
			if (!string.IsNullOrEmpty(model.BienBanNghiemThu))
			{
				model.IsBienBanNghiemThu = true;
			}
			if ((model.IsHopDong == true) && (model.IsDonXinCapChungThuSo == true) && (model.IsCCCD == true) && (model.IsGiayPhepKinhDoanh == true) && (model.IsBienBanNghiemThu == true))
			{
				model.IsKetLuan = true;
				model.KetLuan = GlobalHelper.InitializationString;
			}

			if (string.IsNullOrEmpty(model.KetLuan))
			{
				model.KetLuan = GlobalHelper.InitializationString;
			}
			model.KetLuan = model.KetLuan.Replace("[Hợp đồng]", "");
			model.KetLuan = model.KetLuan.Replace("[Phiếu đăng ký]", "");
			model.KetLuan = model.KetLuan.Replace("[CCCD/HC]", "");
			model.KetLuan = model.KetLuan.Replace("[Giấy phép kinh doanh]", "");
			model.KetLuan = model.KetLuan.Replace("[Biên bản nghiệm thu]", "");
			model.KetLuan = model.KetLuan.Replace("[Hoá đơn]", "");

			if (model.IsKetLuan != true)
			{
				model.KetLuan = "Thiếu hồ sơ : ";
			}
			if (model.IsHopDong != true)
			{
				model.KetLuan = model.KetLuan + "[Hợp đồng]";
			}
			if (model.IsDonXinCapChungThuSo != true)
			{
				model.KetLuan = model.KetLuan + "[Phiếu đăng ký]";
			}
			if (model.IsCCCD != true)
			{
				model.KetLuan = model.KetLuan + "[CCCD/HC]";
			}
			if (model.IsGiayPhepKinhDoanh != true)
			{
				model.KetLuan = model.KetLuan + "[Giấy phép kinh doanh]";
			}
			if (model.IsBienBanNghiemThu != true)
			{
				model.KetLuan = model.KetLuan + "[Biên bản nghiệm thu]";
			}
			if (model.IsHoaDon != true)
			{
				model.KetLuan = model.KetLuan + "[Hoá đơn]";
				if (model.IsKetLuan == true)
				{
					model.KetLuan = "Thiếu hồ sơ : " + model.KetLuan;
				}
			}
		}

		public virtual async Task<DoanhNghiepDichVuCA> Save001Async(DoanhNghiepDichVuCA model)
		{
			Initialization(model);
			if (!string.IsNullOrEmpty(model.Code))
			{
				DoanhNghiepDichVuCA modelExist = await _DoanhNghiepDichVuCARepository.GetByCodeAsync(model.Code);
				if (model.ID > 0)
				{
					if (modelExist.ID == 0)
					{
						await _DoanhNghiepDichVuCARepository.UpdateAsync(model);
					}
					else
					{
						if (modelExist.ID == model.ID)
						{
							await _DoanhNghiepDichVuCARepository.UpdateAsync(model);
						}
					}
				}
				else
				{
					if (modelExist.ID == 0)
					{
						await _DoanhNghiepDichVuCARepository.AddAsync(model);
					}
				}
				if (model.ParentID > 0)
				{
					if (!string.IsNullOrEmpty(model.Email))
					{
						DoanhNghiep doanhNghiep = await _DoanhNghiepBusiness.GetByIDAsync(model.ParentID.Value);
						if (doanhNghiep != null)
						{
							if (doanhNghiep.ID > 0)
							{
								doanhNghiep.Email = model.Email;
								await _DoanhNghiepBusiness.SaveAsync(doanhNghiep);
							}
						}
						string url = GlobalHelper.APISite + "api/v1/Email/AsyncHetHan" + model.GetType().Name;
						var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
						HttpClient client = new HttpClient();
						var task = client.PostAsync(url, content);
						await task.Result.Content.ReadAsStringAsync();
					}
				}

			}
			return model;
		}
		public virtual async Task<bool> AsyncThieuHoSoDoanhNghiepDichVuCA()
		{
			string url = GlobalHelper.APISite + "api/v1/Email/AsyncThieuHoSoDoanhNghiepDichVuCA";
			var content = new StringContent(JsonConvert.SerializeObject(""), Encoding.UTF8, "application/json");
			HttpClient client = new HttpClient();
			var task = client.PostAsync(url, content);
			await task.Result.Content.ReadAsStringAsync();
			return true;
		}
		public virtual async Task<bool> AsyncThieuHoSoDoanhNghiepDichVuCAByYearAndMonth(int year, int month)
		{
			string data = year + "_" + month;
			string url = GlobalHelper.APISite + "api/v1/Email/AsyncThieuHoSoDoanhNghiepDichVuCAByYearAndMonth";
			var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
			HttpClient client = new HttpClient();
			var task = client.PostAsync(url, content);
			await task.Result.Content.ReadAsStringAsync();
			return true;
		}
		public virtual async Task<List<DoanhNghiepDichVuCA>> GetByNhanVienIDToListAsync(long nhanVienID)
		{
			List<DoanhNghiepDichVuCA> result = new List<DoanhNghiepDichVuCA>();
			if (nhanVienID > 0)
			{
				SqlParameter[] parameters =
				 {
					new SqlParameter("@NhanVienID",nhanVienID),
				};
				result = await _DoanhNghiepDichVuCARepository.GetByStoredProcedureToListAsync("sp_DoanhNghiepDichVuCASelectItemsByNhanVienID", parameters);
			}
			return result;
		}
		public virtual async Task<List<DoanhNghiepDichVuCA>> GetByNhanVienIDAndYearAndMonthToListAsync(long nhanVienID, int year, int month)
		{
			List<DoanhNghiepDichVuCA> result = new List<DoanhNghiepDichVuCA>();
			if (nhanVienID > 0)
			{
				SqlParameter[] parameters =
				 {
					new SqlParameter("@NhanVienID",nhanVienID),
					new SqlParameter("@Year",year),
					new SqlParameter("@Month",month),
				};
				result = await _DoanhNghiepDichVuCARepository.GetByStoredProcedureToListAsync("sp_DoanhNghiepDichVuCASelectItemsByNhanVienIDAndYearAndMonth", parameters);
			}
			return result;
		}
		public virtual async Task<DoanhNghiepDichVuCA> GetByUserName_Year_MonthToAsync(string userName, int year, int month)
		{
			return await _DoanhNghiepDichVuCARepository.GetByCondition(model => model.UserName == userName && model.NgayHieuLuc.Value.Year == year && model.NgayHieuLuc.Value.Month == month).FirstOrDefaultAsync();
		}
		public virtual async Task<bool> DongBoDuLieuAsync()
		{
			List<Huyen> listHuyen = await _IHuyenBusiness.GetAllToListAsync();
			List<DoanhNghiepDichVuCA> listDoanhNghiepDichVuCA = await _DoanhNghiepDichVuCARepository.GetAllToListAsync();
			foreach (DoanhNghiepDichVuCA doanhNghiepDichVuCA in listDoanhNghiepDichVuCA)
			{
				try
				{
					if (!string.IsNullOrEmpty(doanhNghiepDichVuCA.UserName))
					{
						DoanhNghiep doanhNghiep = new DoanhNghiep();
						doanhNghiep.Code = doanhNghiepDichVuCA.UserName.Substring(6);
						if (!string.IsNullOrEmpty(doanhNghiep.Code))
						{
							doanhNghiep = await _DoanhNghiepBusiness.GetByCodeAsync(doanhNghiep.Code);
							if (doanhNghiep == null)
							{
								doanhNghiep = new DoanhNghiep();
							}
							doanhNghiep.Description = doanhNghiepDichVuCA.SubjectDN;
							doanhNghiep.UserName = doanhNghiepDichVuCA.UserName;
							doanhNghiep.Code = doanhNghiepDichVuCA.UserName.Substring(6);
							string subjectDN = doanhNghiepDichVuCA.SubjectDN.Replace(@"CN=", @"~");
							if (subjectDN.Split('~').Length > 0)
							{
								doanhNghiep.Name = subjectDN.Split('~')[1];
								doanhNghiep.Name = doanhNghiep.Name.Split(',')[0];
							}

							if (doanhNghiepDichVuCA.SubjectDN.Contains(@"L="))
							{
								subjectDN = doanhNghiepDichVuCA.SubjectDN.Replace(@"L=", @"~");
								if (subjectDN.Split('~').Length > 0)
								{
									subjectDN = subjectDN.Split('~')[1];
									subjectDN = subjectDN.Split(',')[0];
									subjectDN = subjectDN.Trim();
									string huyenName = subjectDN.Split(' ')[subjectDN.Split(' ').Length - 1];
									huyenName = huyenName.Trim();
									Huyen huyen = listHuyen.Where(item => item.Name.Contains(huyenName)).FirstOrDefault();
									if (huyen != null)
									{
										doanhNghiep.HuyenID = huyen.ID;
									}
								}
							}
							await _DoanhNghiepBusiness.SaveAsync(doanhNghiep);
							if (doanhNghiep.ID > 0)
							{
								doanhNghiepDichVuCA.ParentID = doanhNghiep.ID;
								await _DoanhNghiepDichVuCARepository.UpdateAsync(doanhNghiepDichVuCA);
							}
						}
					}
				}
				catch (Exception ex)
				{
					string mes = ex.Message;
				}


			}
			return true;
		}
	}
}
