﻿namespace Business.Interface
{
	public interface IDoanhNghiepDichVuCABusiness : IBaseBusiness<DoanhNghiepDichVuCA>
	{
		Task<DoanhNghiepDichVuCA> Save001Async(DoanhNghiepDichVuCA model);
		Task<List<DoanhNghiepDichVuCA>> GetByNhanVienIDToListAsync(long nhanVienID);
		Task<List<DoanhNghiepDichVuCA>> GetByNhanVienIDAndIsSmartCAToListAsync(long nhanVienID, bool isSmartCA);
		Task<List<DoanhNghiepDichVuCA>> GetByNhanVienIDAndYearAndMonthToListAsync(long nhanVienID, int year, int month);
		Task<bool> AsyncThieuHoSoDoanhNghiepDichVuCA();
		Task<bool> AsyncThieuHoSoDoanhNghiepDichVuCAIsSmartCA(bool isSmartCA);
		Task<bool> AsyncThieuHoSoDoanhNghiepDichVuCAByYearAndMonth(int year, int month);
		Task<DoanhNghiepDichVuCA> GetByUserName_Year_MonthToAsync(string userName, int year, int month);
		Task<DoanhNghiepDichVuCA> GetBySoChungThuToAsync(string soChungThu);
		Task<bool> DongBoDuLieuAsync();
		Task<bool> DongBoDuLieuNoteAsync();

		Task<string> UpdateItemBySoChungThuCapBuAsync(string soChungThuCapBu);
	}
}
