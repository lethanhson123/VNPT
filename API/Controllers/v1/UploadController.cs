using Data.Model;
using Helper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using System.Collections.Generic;
using System.Drawing;

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class UploadController : BaseController<DoanhNghiep, IDoanhNghiepBusiness>
    {
        private readonly IWebHostEnvironment _WebHostEnvironment;
        private readonly IDoanhNghiepBusiness _IDoanhNghiepBusiness;
        private readonly IDichVuBusiness _IDichVuBusiness;
        private readonly IDoanhNghiepDichVuBusiness _IDoanhNghiepDichVuBusiness;
        private readonly IDoanhNghiepThanhVienBusiness _IDoanhNghiepThanhVienBusiness;
        private readonly IHuyenBusiness _IHuyenBusiness;
        private readonly ILoaiDoanhNghiepBusiness _ILoaiDoanhNghiepBusiness;
        private readonly ILoaiDoanhNghiepThanhVienBusiness _ILoaiDoanhNghiepThanhVienBusiness;
        private readonly ILoaiTrangThaiBusiness _ILoaiTrangThaiBusiness;
        private readonly INganhNgheKinhDoanhBusiness _INganhNgheKinhDoanhBusiness;
        private readonly IXaBusiness _IXaBusiness;
        private readonly IPhongBanBusiness _IPhongBanBusiness;
        private readonly IDoanhNghiepDichVuLichSuBusiness _IDoanhNghiepDichVuLichSuBusiness;

        public UploadController(IWebHostEnvironment WebHostEnvironment
            , IDoanhNghiepBusiness IDoanhNghiepBusiness
            , IDichVuBusiness IDichVuBusiness
            , IDoanhNghiepDichVuBusiness IDoanhNghiepDichVuBusiness
            , IDoanhNghiepThanhVienBusiness IDoanhNghiepThanhVienBusiness
            , IHuyenBusiness IHuyenBusiness
            , ILoaiDoanhNghiepBusiness ILoaiDoanhNghiepBusiness
            , ILoaiDoanhNghiepThanhVienBusiness ILoaiDoanhNghiepThanhVienBusiness
            , ILoaiTrangThaiBusiness ILoaiTrangThaiBusiness
            , INganhNgheKinhDoanhBusiness INganhNgheKinhDoanhBusiness
            , IXaBusiness IXaBusiness
            , IPhongBanBusiness IPhongBanBusiness
            , IDoanhNghiepDichVuLichSuBusiness IDoanhNghiepDichVuLichSuBusiness
            ) : base(IDoanhNghiepBusiness)
        {
            _WebHostEnvironment = WebHostEnvironment;
            _IDoanhNghiepBusiness = IDoanhNghiepBusiness;
            _IDichVuBusiness = IDichVuBusiness;
            _IDoanhNghiepDichVuBusiness = IDoanhNghiepDichVuBusiness;
            _IDoanhNghiepThanhVienBusiness = IDoanhNghiepThanhVienBusiness;
            _IHuyenBusiness = IHuyenBusiness;
            _ILoaiDoanhNghiepBusiness = ILoaiDoanhNghiepBusiness;
            _ILoaiDoanhNghiepThanhVienBusiness = ILoaiDoanhNghiepThanhVienBusiness;
            _ILoaiTrangThaiBusiness = ILoaiTrangThaiBusiness;
            _INganhNgheKinhDoanhBusiness = INganhNgheKinhDoanhBusiness;
            _IXaBusiness = IXaBusiness;
            _IPhongBanBusiness = IPhongBanBusiness;
            _IDoanhNghiepDichVuLichSuBusiness = IDoanhNghiepDichVuLichSuBusiness;
        }
        [HttpPost]
        [Route("PostDoanhNghiepListByExcelFileAsync")]
        public virtual async Task<List<DoanhNghiep>> PostDoanhNghiepListByExcelFileAsync()
        {
            List<DoanhNghiep> result = new List<DoanhNghiep>();
            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files[0];
                if (file == null || file.Length == 0)
                {
                }
                if (file != null)
                {
                    string fileExtension = Path.GetExtension(file.FileName);
                    string fileName = "DoanhNghiep_" + GlobalHelper.InitializationDateTimeCode0001 + fileExtension;
                    var physicalPath = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Upload, fileName);
                    using (var stream = new FileStream(physicalPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    try
                    {
                        FileInfo fileLocation = new FileInfo(physicalPath);
                        if (fileLocation.Length > 0)
                        {
                            if ((fileExtension == ".xlsx") || (fileExtension == ".xls"))
                            {
                                using (ExcelPackage package = new ExcelPackage(fileLocation))
                                {
                                    if (package.Workbook.Worksheets.Count > 0)
                                    {
                                        ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                                        if (workSheet != null)
                                        {
                                            int totalRows = workSheet.Dimension.Rows;
                                            for (int i = 2; i <= totalRows; i++)
                                            {
                                                DoanhNghiep doanhNghiep = new DoanhNghiep();
                                                if (workSheet.Cells[i, 2].Value != null)
                                                {
                                                    doanhNghiep.Code = workSheet.Cells[i, 2].Value.ToString().Trim();
                                                }
                                                if (!string.IsNullOrEmpty(doanhNghiep.Code))
                                                {
                                                    DoanhNghiep doanhNghiepExist = await _IDoanhNghiepBusiness.GetByCodeAsync(doanhNghiep.Code);
                                                    if (doanhNghiepExist.ID == 0)
                                                    {
                                                        if (workSheet.Cells[i, 3].Value != null)
                                                        {
                                                            doanhNghiep.Name = workSheet.Cells[i, 3].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 4].Value != null)
                                                        {
                                                            doanhNghiep.DiaChi = workSheet.Cells[i, 4].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 5].Value != null)
                                                        {
                                                            doanhNghiep.Note = workSheet.Cells[i, 5].Value.ToString().Trim();
                                                            Huyen huyenExist = await _IHuyenBusiness.GetByNameAsync(doanhNghiep.Note);
                                                            if (huyenExist.ID == 0)
                                                            {
                                                                huyenExist = new Huyen();
                                                                huyenExist.SortOrder = 1;
                                                                huyenExist.ParentID = 1;
                                                                huyenExist.Name = doanhNghiep.Note;
                                                                await _IHuyenBusiness.AddAsync(huyenExist);
                                                            }
                                                            doanhNghiep.HuyenID = huyenExist.ID;
                                                        }
                                                        if (workSheet.Cells[i, 6].Value != null)
                                                        {
                                                            doanhNghiep.Note = workSheet.Cells[i, 6].Value.ToString().Trim();
                                                            Xa xaExist = await _IXaBusiness.GetByNameAsync(doanhNghiep.Note);
                                                            if (xaExist.ID == 0)
                                                            {
                                                                xaExist = new Xa();
                                                                xaExist.SortOrder = 1;
                                                                xaExist.ParentID = doanhNghiep.HuyenID;
                                                                xaExist.Name = doanhNghiep.Note;
                                                                await _IXaBusiness.AddAsync(xaExist);
                                                            }
                                                            doanhNghiep.XaID = xaExist.ID;
                                                        }
                                                        if (workSheet.Cells[i, 7].Value != null)
                                                        {
                                                            try
                                                            {
                                                                doanhNghiep.VonDieuLe = decimal.Parse(workSheet.Cells[i, 7].Value.ToString().Trim());
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                string mes = ex.Message;
                                                            }
                                                        }
                                                        if (workSheet.Cells[i, 8].Value != null)
                                                        {
                                                            doanhNghiep.Note = workSheet.Cells[i, 8].Value.ToString().Trim();
                                                            LoaiTrangThai loaiTrangThaiExist = await _ILoaiTrangThaiBusiness.GetByNameAsync(doanhNghiep.Note);
                                                            if (loaiTrangThaiExist.ID == 0)
                                                            {
                                                                loaiTrangThaiExist = new LoaiTrangThai();
                                                                loaiTrangThaiExist.SortOrder = 1;
                                                                loaiTrangThaiExist.Name = doanhNghiep.Note;
                                                                await _ILoaiTrangThaiBusiness.AddAsync(loaiTrangThaiExist);
                                                            }
                                                            doanhNghiep.LoaiTrangThaiID = loaiTrangThaiExist.ID;
                                                        }
                                                        if (workSheet.Cells[i, 9].Value != null)
                                                        {
                                                            doanhNghiep.DienThoai = workSheet.Cells[i, 9].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 10].Value != null)
                                                        {
                                                            doanhNghiep.Email = workSheet.Cells[i, 10].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 17].Value != null)
                                                        {
                                                            doanhNghiep.Note = workSheet.Cells[i, 17].Value.ToString().Trim();
                                                            string code = doanhNghiep.Note.Split(':')[0];
                                                            NganhNgheKinhDoanh nganhNgheKinhDoanhExist = await _INganhNgheKinhDoanhBusiness.GetByCodeAsync(code);
                                                            if (nganhNgheKinhDoanhExist.ID == 0)
                                                            {
                                                                nganhNgheKinhDoanhExist = new NganhNgheKinhDoanh();
                                                                nganhNgheKinhDoanhExist.SortOrder = 1;
                                                                nganhNgheKinhDoanhExist.Code = code;
                                                                if (doanhNghiep.Note.Split(':').Length > 1)
                                                                {
                                                                    nganhNgheKinhDoanhExist.Name = doanhNghiep.Note.Split(':')[1];
                                                                }
                                                                await _INganhNgheKinhDoanhBusiness.AddAsync(nganhNgheKinhDoanhExist);
                                                            }
                                                            doanhNghiep.NganhNgheKinhDoanhChinhID = nganhNgheKinhDoanhExist.ID;
                                                        }
                                                        if (workSheet.Cells[i, 18].Value != null)
                                                        {
                                                            doanhNghiep.NganhNgheKinhDoanh = workSheet.Cells[i, 18].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 19].Value != null)
                                                        {
                                                            try
                                                            {
                                                                doanhNghiep.Note = workSheet.Cells[i, 19].Value.ToString().Trim();
                                                                int day = int.Parse(doanhNghiep.Note.Split('/')[0]);
                                                                int month = int.Parse(doanhNghiep.Note.Split('/')[1]);
                                                                int year = int.Parse(doanhNghiep.Note.Split('/')[2].Split(' ')[0]);
                                                                doanhNghiep.NgayCap = new DateTime(year, month, day);
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                string mes = ex.Message;
                                                            }
                                                        }
                                                        if (workSheet.Cells[i, 20].Value != null)
                                                        {
                                                            try
                                                            {
                                                                doanhNghiep.Note = workSheet.Cells[i, 20].Value.ToString().Trim();
                                                                int day = int.Parse(doanhNghiep.Note.Split('/')[0]);
                                                                int month = int.Parse(doanhNghiep.Note.Split('/')[1]);
                                                                int year = int.Parse(doanhNghiep.Note.Split('/')[2].Split(' ')[0]);
                                                                doanhNghiep.NgayDangKyThayDoi = new DateTime(year, month, day);
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                string mes = ex.Message;
                                                            }
                                                        }
                                                        if (workSheet.Cells[i, 21].Value != null)
                                                        {
                                                            doanhNghiep.Note = workSheet.Cells[i, 21].Value.ToString().Trim();
                                                            LoaiDoanhNghiep loaiDoanhNghiepExist = await _ILoaiDoanhNghiepBusiness.GetByNameAsync(doanhNghiep.Note);
                                                            if (loaiDoanhNghiepExist.ID == 0)
                                                            {
                                                                loaiDoanhNghiepExist = new LoaiDoanhNghiep();
                                                                loaiDoanhNghiepExist.SortOrder = 1;
                                                                loaiDoanhNghiepExist.Name = doanhNghiep.Note;
                                                                await _ILoaiDoanhNghiepBusiness.AddAsync(loaiDoanhNghiepExist);
                                                            }
                                                            doanhNghiep.LoaiDoanhNghiepID = loaiDoanhNghiepExist.ID;
                                                        }
                                                        if (workSheet.Cells[i, 22].Value != null)
                                                        {
                                                            try
                                                            {
                                                                doanhNghiep.SoLuongLaoDong = int.Parse(workSheet.Cells[i, 22].Value.ToString().Trim());
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                string mes = ex.Message;
                                                            }
                                                        }
                                                        if (workSheet.Cells[i, 25].Value != null)
                                                        {
                                                            LoaiDoanhNghiep loaiDoanhNghiepExist = await _ILoaiDoanhNghiepBusiness.GetByIDAsync(doanhNghiep.LoaiDoanhNghiepID.Value);
                                                            if (loaiDoanhNghiepExist.ID > 0)
                                                            {
                                                                loaiDoanhNghiepExist.Note = workSheet.Cells[i, 25].Value.ToString().Trim();
                                                                await _ILoaiDoanhNghiepBusiness.UpdateAsync(loaiDoanhNghiepExist);
                                                            }
                                                        }
                                                        await _IDoanhNghiepBusiness.SaveAsync(doanhNghiep);
                                                        if (doanhNghiep.ID > 0)
                                                        {
                                                            result.Add(doanhNghiep);
                                                            if (workSheet.Cells[i, 26].Value != null)
                                                            {
                                                                doanhNghiep.Note = workSheet.Cells[i, 26].Value.ToString().Trim();
                                                                if (doanhNghiep.Note != "-")
                                                                {
                                                                    DoanhNghiepDichVu doanhNghiepDichVu = new DoanhNghiepDichVu();
                                                                    doanhNghiepDichVu.SortOrder = 1;
                                                                    doanhNghiepDichVu.ParentID = doanhNghiep.ID;
                                                                    doanhNghiepDichVu.DichVuID = 1;
                                                                    await _IDoanhNghiepDichVuBusiness.AddAsync(doanhNghiepDichVu);
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 27].Value != null)
                                                            {
                                                                doanhNghiep.Note = workSheet.Cells[i, 27].Value.ToString().Trim();
                                                                if (doanhNghiep.Note != "-")
                                                                {
                                                                    DoanhNghiepDichVu doanhNghiepDichVu = new DoanhNghiepDichVu();
                                                                    doanhNghiepDichVu.SortOrder = 1;
                                                                    doanhNghiepDichVu.ParentID = doanhNghiep.ID;
                                                                    doanhNghiepDichVu.DichVuID = 2;
                                                                    await _IDoanhNghiepDichVuBusiness.AddAsync(doanhNghiepDichVu);
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 28].Value != null)
                                                            {
                                                                doanhNghiep.Note = workSheet.Cells[i, 28].Value.ToString().Trim();
                                                                if (doanhNghiep.Note != "-")
                                                                {
                                                                    DoanhNghiepDichVu doanhNghiepDichVu = new DoanhNghiepDichVu();
                                                                    doanhNghiepDichVu.SortOrder = 1;
                                                                    doanhNghiepDichVu.ParentID = doanhNghiep.ID;
                                                                    doanhNghiepDichVu.DichVuID = 3;
                                                                    await _IDoanhNghiepDichVuBusiness.AddAsync(doanhNghiepDichVu);
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 29].Value != null)
                                                            {
                                                                doanhNghiep.Note = workSheet.Cells[i, 29].Value.ToString().Trim();
                                                                if (doanhNghiep.Note != "-")
                                                                {
                                                                    DoanhNghiepDichVu doanhNghiepDichVu = new DoanhNghiepDichVu();
                                                                    doanhNghiepDichVu.SortOrder = 1;
                                                                    doanhNghiepDichVu.ParentID = doanhNghiep.ID;
                                                                    doanhNghiepDichVu.DichVuID = 4;
                                                                    await _IDoanhNghiepDichVuBusiness.AddAsync(doanhNghiepDichVu);
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 30].Value != null)
                                                            {
                                                                doanhNghiep.Note = workSheet.Cells[i, 30].Value.ToString().Trim();
                                                                if (doanhNghiep.Note != "-")
                                                                {
                                                                    DoanhNghiepDichVu doanhNghiepDichVu = new DoanhNghiepDichVu();
                                                                    doanhNghiepDichVu.SortOrder = 1;
                                                                    doanhNghiepDichVu.ParentID = doanhNghiep.ID;
                                                                    doanhNghiepDichVu.DichVuID = 5;
                                                                    await _IDoanhNghiepDichVuBusiness.AddAsync(doanhNghiepDichVu);
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 31].Value != null)
                                                            {
                                                                doanhNghiep.Note = workSheet.Cells[i, 31].Value.ToString().Trim();
                                                                if (doanhNghiep.Note != "-")
                                                                {
                                                                    DoanhNghiepDichVu doanhNghiepDichVu = new DoanhNghiepDichVu();
                                                                    doanhNghiepDichVu.SortOrder = 1;
                                                                    doanhNghiepDichVu.ParentID = doanhNghiep.ID;
                                                                    doanhNghiepDichVu.DichVuID = 6;
                                                                    await _IDoanhNghiepDichVuBusiness.AddAsync(doanhNghiepDichVu);
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 32].Value != null)
                                                            {
                                                                doanhNghiep.Note = workSheet.Cells[i, 32].Value.ToString().Trim();
                                                                if (doanhNghiep.Note != "-")
                                                                {
                                                                    DoanhNghiepDichVu doanhNghiepDichVu = new DoanhNghiepDichVu();
                                                                    doanhNghiepDichVu.SortOrder = 1;
                                                                    doanhNghiepDichVu.ParentID = doanhNghiep.ID;
                                                                    doanhNghiepDichVu.DichVuID = 7;
                                                                    await _IDoanhNghiepDichVuBusiness.AddAsync(doanhNghiepDichVu);
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 33].Value != null)
                                                            {
                                                                doanhNghiep.Note = workSheet.Cells[i, 33].Value.ToString().Trim();
                                                                if (doanhNghiep.Note != "-")
                                                                {
                                                                    DoanhNghiepDichVu doanhNghiepDichVu = new DoanhNghiepDichVu();
                                                                    doanhNghiepDichVu.SortOrder = 1;
                                                                    doanhNghiepDichVu.ParentID = doanhNghiep.ID;
                                                                    doanhNghiepDichVu.DichVuID = 8;
                                                                    await _IDoanhNghiepDichVuBusiness.AddAsync(doanhNghiepDichVu);
                                                                }
                                                            }

                                                            if (workSheet.Cells[i, 11].Value != null)
                                                            {
                                                                DoanhNghiepThanhVien doanhNghiepThanhVien = new DoanhNghiepThanhVien();
                                                                doanhNghiepThanhVien.SortOrder = 1;
                                                                doanhNghiepThanhVien.ParentID = doanhNghiep.ID;
                                                                doanhNghiepThanhVien.LoaiDoanhNghiepThanhVienID = 1;
                                                                doanhNghiepThanhVien.Name = workSheet.Cells[i, 11].Value.ToString().Trim();
                                                                if (workSheet.Cells[i, 12].Value != null)
                                                                {
                                                                    try
                                                                    {
                                                                        doanhNghiepThanhVien.Note = workSheet.Cells[i, 12].Value.ToString().Trim();
                                                                        int day = int.Parse(doanhNghiepThanhVien.Note.Split('/')[0]);
                                                                        int month = int.Parse(doanhNghiepThanhVien.Note.Split('/')[1]);
                                                                        int year = int.Parse(doanhNghiepThanhVien.Note.Split('/')[2].Split(' ')[0]);
                                                                        doanhNghiepThanhVien.NgaySinh = new DateTime(year, month, day);
                                                                    }
                                                                    catch (Exception ex)
                                                                    {
                                                                        string mes = ex.Message;
                                                                    }
                                                                }
                                                                if (workSheet.Cells[i, 13].Value != null)
                                                                {
                                                                    doanhNghiepThanhVien.CCCD = workSheet.Cells[i, 13].Value.ToString().Trim();
                                                                }
                                                                if (workSheet.Cells[i, 14].Value != null)
                                                                {
                                                                    try
                                                                    {
                                                                        doanhNghiepThanhVien.Note = workSheet.Cells[i, 14].Value.ToString().Trim();
                                                                        int day = int.Parse(doanhNghiepThanhVien.Note.Split('/')[0]);
                                                                        int month = int.Parse(doanhNghiepThanhVien.Note.Split('/')[1]);
                                                                        int year = int.Parse(doanhNghiepThanhVien.Note.Split('/')[2].Split(' ')[0]);
                                                                        doanhNghiepThanhVien.CCCD_NgayCap = new DateTime(year, month, day);
                                                                    }
                                                                    catch (Exception ex)
                                                                    {
                                                                        string mes = ex.Message;
                                                                    }
                                                                }
                                                                if (workSheet.Cells[i, 15].Value != null)
                                                                {
                                                                    doanhNghiepThanhVien.CCCD_NoiCap = workSheet.Cells[i, 15].Value.ToString().Trim();
                                                                }
                                                                await _IDoanhNghiepThanhVienBusiness.AddAsync(doanhNghiepThanhVien);
                                                            }
                                                            if (workSheet.Cells[i, 16].Value != null)
                                                            {
                                                                DoanhNghiepThanhVien doanhNghiepThanhVien = new DoanhNghiepThanhVien();
                                                                doanhNghiepThanhVien.SortOrder = 1;
                                                                doanhNghiepThanhVien.ParentID = doanhNghiep.ID;
                                                                doanhNghiepThanhVien.LoaiDoanhNghiepThanhVienID = 2;
                                                                doanhNghiepThanhVien.Name = workSheet.Cells[i, 16].Value.ToString().Trim();
                                                                await _IDoanhNghiepThanhVienBusiness.AddAsync(doanhNghiepThanhVien);
                                                            }
                                                            if (workSheet.Cells[i, 23].Value != null)
                                                            {
                                                                string note = workSheet.Cells[i, 23].Value.ToString().Trim();
                                                                foreach (string name in note.Split(','))
                                                                {
                                                                    if (!string.IsNullOrEmpty(name))
                                                                    {
                                                                        DoanhNghiepThanhVien doanhNghiepThanhVien = new DoanhNghiepThanhVien();
                                                                        doanhNghiepThanhVien.SortOrder = 1;
                                                                        doanhNghiepThanhVien.ParentID = doanhNghiep.ID;
                                                                        doanhNghiepThanhVien.LoaiDoanhNghiepThanhVienID = 3;
                                                                        doanhNghiepThanhVien.Name = name;
                                                                        await _IDoanhNghiepThanhVienBusiness.AddAsync(doanhNghiepThanhVien);
                                                                    }
                                                                }
                                                            }
                                                            if (workSheet.Cells[i, 24].Value != null)
                                                            {
                                                                string note = workSheet.Cells[i, 24].Value.ToString().Trim();
                                                                foreach (string name in note.Split(','))
                                                                {
                                                                    if (!string.IsNullOrEmpty(name))
                                                                    {
                                                                        DoanhNghiepThanhVien doanhNghiepThanhVien = new DoanhNghiepThanhVien();
                                                                        doanhNghiepThanhVien.SortOrder = 1;
                                                                        doanhNghiepThanhVien.ParentID = doanhNghiep.ID;
                                                                        doanhNghiepThanhVien.LoaiDoanhNghiepThanhVienID = 4;
                                                                        doanhNghiepThanhVien.Name = name;
                                                                        await _IDoanhNghiepThanhVienBusiness.AddAsync(doanhNghiepThanhVien);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
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
                }
            }
            return result;
        }

        [HttpPost]
        [Route("PostDoanhThuByYearAndMonthListByExcelFileAsync")]
        public virtual async Task<List<DoanhNghiep>> PostDoanhThuByYearAndMonthListByExcelFileAsync()
        {
            List<DoanhNghiep> result = new List<DoanhNghiep>();
            int yearDoanhThu = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
            int monthDoanhThu = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files[0];
                if (file == null || file.Length == 0)
                {
                }
                if (file != null)
                {
                    string fileExtension = Path.GetExtension(file.FileName);
                    string fileName = "DoanhThu_" + yearDoanhThu + "_" + monthDoanhThu + "_" + GlobalHelper.InitializationDateTimeCode0001 + fileExtension;
                    var physicalPath = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Upload, fileName);
                    using (var stream = new FileStream(physicalPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    try
                    {
                        FileInfo fileLocation = new FileInfo(physicalPath);
                        if (fileLocation.Length > 0)
                        {
                            if ((fileExtension == ".xlsx") || (fileExtension == ".xls"))
                            {
                                using (ExcelPackage package = new ExcelPackage(fileLocation))
                                {
                                    if (package.Workbook.Worksheets.Count > 0)
                                    {
                                        ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                                        if (workSheet != null)
                                        {
                                            int totalRows = workSheet.Dimension.Rows;
                                            for (int i = 2; i <= totalRows; i++)
                                            {
                                                DoanhNghiep doanhNghiep = new DoanhNghiep();
                                                if (workSheet.Cells[i, 2].Value != null)
                                                {
                                                    doanhNghiep.Code = workSheet.Cells[i, 2].Value.ToString().Trim();
                                                }
                                                if (workSheet.Cells[i, 1].Value != null)
                                                {
                                                    doanhNghiep.KHACHHANG_ID = workSheet.Cells[i, 1].Value.ToString().Trim();
                                                }
                                                if (!string.IsNullOrEmpty(doanhNghiep.Code))
                                                {
                                                    DoanhNghiep doanhNghiepExist = await _IDoanhNghiepBusiness.GetByCodeAsync(doanhNghiep.Code);
                                                    if (doanhNghiepExist.ID == 0)
                                                    {
                                                        if (workSheet.Cells[i, 3].Value != null)
                                                        {
                                                            doanhNghiep.Name = workSheet.Cells[i, 3].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 4].Value != null)
                                                        {
                                                            doanhNghiep.DiaChi = workSheet.Cells[i, 4].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 5].Value != null)
                                                        {
                                                            doanhNghiep.DienThoai = workSheet.Cells[i, 5].Value.ToString().Trim();
                                                        }                                                        
                                                    }                                                    
                                                    await _IDoanhNghiepBusiness.SaveAsync(doanhNghiep);
                                                    result.Add(doanhNghiep);
                                                    DichVu dichVu = new DichVu();
                                                    if (workSheet.Cells[i, 10].Value != null)
                                                    {
                                                        dichVu.Name = workSheet.Cells[i, 10].Value.ToString().Trim();
                                                    }
                                                    DichVu dichVuExist = await _IDichVuBusiness.GetByCondition(item => item.Name.Contains(dichVu.Name) || dichVu.Name.Contains(item.Name)).FirstOrDefaultAsync();
                                                    if (dichVuExist == null)
                                                    {
                                                        dichVuExist = new DichVu();
                                                    }
                                                    if (dichVuExist.ID > 0)
                                                    {
                                                        DoanhNghiepDichVu doanhNghiepDichVu = new DoanhNghiepDichVu();
                                                        doanhNghiepDichVu.ParentID = doanhNghiep.ID;
                                                        doanhNghiepDichVu.DichVuID = dichVuExist.ID;
                                                        if (workSheet.Cells[i, 6].Value != null)
                                                        {
                                                            try
                                                            {
                                                                doanhNghiepDichVu.Note = workSheet.Cells[i, 6].Value.ToString().Trim();
                                                                int day = int.Parse(doanhNghiepDichVu.Note.Split('/')[0]);
                                                                int month = int.Parse(doanhNghiepDichVu.Note.Split('/')[1]);
                                                                int year = int.Parse(doanhNghiepDichVu.Note.Split('/')[2].Split(' ')[0]);
                                                                doanhNghiepDichVu.NgayKyHopDong = new DateTime(year, month, day);
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                string mes = ex.Message;
                                                            }
                                                        }
                                                        if (workSheet.Cells[i, 7].Value != null)
                                                        {
                                                            doanhNghiepDichVu.MaThueBao = workSheet.Cells[i, 7].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 9].Value != null)
                                                        {
                                                            doanhNghiepDichVu.DiaChiLapDat = workSheet.Cells[i, 9].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 11].Value != null)
                                                        {
                                                            doanhNghiepDichVu.DichVuVienThong = workSheet.Cells[i, 11].Value.ToString().Trim();
                                                        }
                                                        if (workSheet.Cells[i, 12].Value != null)
                                                        {
                                                            PhongBan phongBan = new PhongBan();
                                                            phongBan.Name = workSheet.Cells[i, 12].Value.ToString().Trim();
                                                            PhongBan phongBanExist = await _IPhongBanBusiness.GetByNameAsync(phongBan.Name);
                                                            if (phongBanExist.ID == 0)
                                                            {
                                                                await _IPhongBanBusiness.SaveAsync(phongBan);
                                                            }
                                                            doanhNghiepDichVu.PhongBanID = phongBan.ID;
                                                        }
                                                        if (workSheet.Cells[i, 13].Value != null)
                                                        {
                                                            try
                                                            {
                                                                doanhNghiepDichVu.GiaTien = int.Parse(workSheet.Cells[i, 13].Value.ToString().Trim());
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                string mes = ex.Message;
                                                            }
                                                        }
                                                        DoanhNghiepDichVu doanhNghiepDichVuExist = await _IDoanhNghiepDichVuBusiness.GetByCondition(item => item.ParentID == doanhNghiepDichVu.ParentID && item.DichVuID == doanhNghiepDichVu.DichVuID).FirstOrDefaultAsync();
                                                        if (doanhNghiepDichVuExist == null)
                                                        {
                                                            doanhNghiepDichVuExist = new DoanhNghiepDichVu();
                                                        }
                                                        await _IDoanhNghiepDichVuBusiness.SaveAsync(doanhNghiepDichVu);                                                        
                                                        DoanhNghiepDichVuLichSu doanhNghiepDichVuLichSu = new DoanhNghiepDichVuLichSu();
                                                        doanhNghiepDichVuLichSu.ParentID = doanhNghiepDichVu.ID;
                                                        doanhNghiepDichVuLichSu.Year = yearDoanhThu;
                                                        doanhNghiepDichVuLichSu.Month = monthDoanhThu;
                                                        doanhNghiepDichVuLichSu.GiaTien = doanhNghiepDichVu.GiaTien;
                                                        DoanhNghiepDichVuLichSu doanhNghiepDichVuLichSuExist = await _IDoanhNghiepDichVuLichSuBusiness.GetByCondition(item => item.ParentID == doanhNghiepDichVuLichSu.ParentID && item.Year == doanhNghiepDichVuLichSu.Year && item.Month == doanhNghiepDichVuLichSu.Month).FirstOrDefaultAsync();
                                                        if (doanhNghiepDichVuLichSuExist == null)
                                                        {
                                                            doanhNghiepDichVuLichSuExist = new DoanhNghiepDichVuLichSu();
                                                        }
                                                        if (doanhNghiepDichVuLichSuExist.ID == 0)
                                                        {
                                                            await _IDoanhNghiepDichVuLichSuBusiness.SaveAsync(doanhNghiepDichVuLichSu);
                                                        }
                                                    }
                                                }
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
                }
            }
            return result;
        }
    }
}
