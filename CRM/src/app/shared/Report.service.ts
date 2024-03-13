import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './Base.service';
import { Report } from './Report.model';
import { DoanhNghiep } from './DoanhNghiep.model';
@Injectable({
    providedIn: 'root'
})
export class ReportService extends BaseService{
    displayColumnsReport001: string[] = ['DichVu', 'MaThueBao', 'DoanhThu', 'DoanhThuLast', 'ChenhLech']; 
    displayColumnsReportVNPT001: string[] = ['No', 'Name', 'HuyenName', 'DoanhThu', 'DoanhThu01', 'DoanhThu03', 'DoanhThu05', 'DoanhThu07', 'DoanhThu09', 'DoanhThu11', 'DoanhThu13']; 
    displayColumnsReportVNPT003: string[] = ['No', 'Name', 'HuyenName', 'DoanhThu', 'DoanhThu01', 'DoanhThu02', 'DoanhThu03', 'DoanhThu04', 'DoanhThu05', 'DoanhThu06', 'DoanhThu07', 'DoanhThu08', 'DoanhThu09', 'DoanhThu10', 'DoanhThu11', 'DoanhThu12']; 
    displayColumnsReportCA001: string[] = ['No', 'HuyenName', 'DoanhNghiepName', 'UserName', 'SoChungThu', 'SoChungThuCu', 'NgayHieuLuc', 'NgayHetHan', 'NhanVienName', 'TaiKhoanTaoYeuCau', 'TaiKhoanDuyetYeuCau']; 
    displayColumnsReportCA002: string[] = ['DoanhNghiepName', 'UserName', 'IsKetLuan', 'KetLuan', 'IsHopDong', 'IsDonXinCapChungThuSo', 'IsCCCD', 'IsGiayPhepKinhDoanh', 'IsBienBanNghiemThu', 'IsHoaDon', 'Note', 'CodeCA', 'SoChungThu', 'SoChungThuCu', 'NgayHieuLuc', 'NgayHetHan', 'TenGoiCuoc', 'LoaiGoiCuoc', 'ThoiGianGoiCuoc', 'Email', 'DienThoai', 'TaiKhoanTaoYeuCau', 'NhanVienTaoYeuCauName', 'TaiKhoanDuyetYeuCau', 'PhongBanDuyetYeuCauName', 'LoaiYeuCau', 'DoanhThu']; 
    
    displayColumnsReportCA002001: string[] = ['DoanhNghiepName', 'LastUpdatedDate', 'UserName', 'IsKetLuan', 'KetLuan', 'IsHopDong', 'IsDonXinCapChungThuSo', 'IsCCCD', 'IsGiayPhepKinhDoanh', 'IsBienBanNghiemThu', 'IsHoaDon', 'Note', 'CodeCA', 'SoChungThu', 'SoChungThuCu', 'NgayHieuLuc', 'NgayHetHan', 'TenGoiCuoc', 'LoaiGoiCuoc', 'ThoiGianGoiCuoc', 'Email', 'DienThoai', 'TaiKhoanTaoYeuCau', 'NhanVienTaoYeuCauName', 'TaiKhoanDuyetYeuCau', 'PhongBanDuyetYeuCauName', 'LoaiYeuCau', 'DoanhThu']; 
    displayColumnsReportCA202312: string[] = ['DoanhNghiepName', 'UserName', 'SoChungThu', 'SoChungThuCu', 'NgayHieuLuc', 'NgayHetHan', 'TenGoiCuoc', 'LoaiGoiCuoc', 'ThoiGianGoiCuoc', 'Email', 'DienThoai', 'TaiKhoanTaoYeuCau', 'NhanVienTaoYeuCauName', 'TaiKhoanDuyetYeuCau', 'PhongBanDuyetYeuCauName', 'LoaiYeuCau', 'DoanhThu']; 
    displayColumnsReportCA006: string[] = ['No', 'HuyenName', 'DoanhNghiepName']; 
    displayColumnsReportCA203: string[] = ['No', 'NhanVienTaoYeuCauName', 'SanLuong', 'DoanhThu']; 
    displayColumnsReportCA204: string[] = ['No', 'NhanVienTaoYeuCauName', 'SanLuong', 'PhatTrienChiTieu', 'DoanhThu', 'TyLePhatTrien']; 
    displayColumnsReportCA206: string[] = ['No', 'PhongBanTaoYeuCauName', 'HoSo', 'HoSoHoanThanh', 'HoSoChuaHoanThanh', 'TyLeHoanThanh'];
    
    
    displayColumnsReportCACapBu101: string[] = ['No', 'PhongBanTaoYeuCauName', 'GiaHan', 'GiaHanChiTieu', 'TyLeHoSo']; 
    displayColumnsReportCACapBu102: string[] = ['No', 'NhanVienTaoYeuCauName', 'GiaHan', 'GiaHanChiTieu', 'TyLeHoSo']; 
    displayColumnsReportCACapBu: string[] = ['DoanhNghiepName', 'UserName', 'IsCapBu', 'IsKetLuan', 'KetLuan', 'IsHopDong', 'IsDonXinCapChungThuSo', 'IsCCCD', 'IsGiayPhepKinhDoanh', 'IsBienBanNghiemThu', 'IsHoaDon', 'Note', 'CodeCA', 'SoChungThu', 'SoChungThuCu', 'NgayHieuLuc', 'NgayHetHan', 'TenGoiCuoc', 'LoaiGoiCuoc', 'ThoiGianGoiCuoc', 'Email', 'DienThoai', 'TaiKhoanTaoYeuCau', 'NhanVienTaoYeuCauName', 'TaiKhoanDuyetYeuCau', 'PhongBanDuyetYeuCauName', 'LoaiYeuCau', 'DoanhThu']; 

    listReport001: Report[] | undefined;        
    listReport002: Report[] | undefined;        
    listReport003: Report[] | undefined;        
    listReport004: Report[] | undefined;        
    listReportVNPT001: Report[] | undefined;
    listReportVNPT001View: Report[] | undefined;
    listReportVNPT003: Report[] | undefined;
    listReportVNPT003View: Report[] | undefined;
    listReportVNPT004: Report[] | undefined;
    listReportVNPT004View: Report[] | undefined;
    listReportVNPT005: Report[] | undefined;
    listReportVNPT005View: Report[] | undefined;

    listReportVNPT1001: Report[] | undefined;
    listReportVNPT1002: Report[] | undefined;


    listReportCA001: Report[] | undefined;
    listReportCA002: Report[] | undefined;
    listReportCA003: Report[] | undefined;
    listReportCA004: Report[] | undefined;
    listReportCA005: Report[] | undefined;
    listReportCA006: Report[] | undefined;
    listReportCA007: DoanhNghiep[] | undefined;
    listReportCA008: Report[] | undefined;    
    listReportCA202: Report[] | undefined;    
    listReportCA203: Report[] | undefined;    
    listReportCA204: Report[] | undefined;    
    listReportCA205: Report[] | undefined;    
    listReportCA206: Report[] | undefined;
    listReportCA207: Report[] | undefined;
    listReportCA305: Report[] | undefined;    
    listReportCA306: Report[] | undefined;    
    listReportCA307: Report[] | undefined;    
    listReportCA308: Report[] | undefined;    

    listReportCACapBu101: Report[] | undefined; 
    listReportCACapBu102: Report[] | undefined; 
    listReportCACapBu103: Report[] | undefined; 
    listReportCACapBu201: Report[] | undefined; 
    listReportCACapBu202: Report[] | undefined; 
    listReportCACapBu203: Report[] | undefined; 


    formData!: Report;
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "Report";
    }    
    ReportCACapBu101ToListAsync() {        
        let url = this.aPIURL + this.controller + '/ReportCACapBu101ToListAsync';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));             
        return this.httpClient.post(url, formUpload);
    }
    ReportCACapBu102ToListAsync() {        
        let url = this.aPIURL + this.controller + '/ReportCACapBu102ToListAsync';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));             
        return this.httpClient.post(url, formUpload);
    }
    ReportCACapBu103ToListAsync() {        
        let url = this.aPIURL + this.controller + '/ReportCACapBu103ToListAsync';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));             
        return this.httpClient.post(url, formUpload);
    }
    ReportCACapBu201ToListAsync() {        
        let url = this.aPIURL + this.controller + '/ReportCACapBu201ToListAsync';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));             
        return this.httpClient.post(url, formUpload);
    }
    ReportCACapBu202ToListAsync() {        
        let url = this.aPIURL + this.controller + '/ReportCACapBu202ToListAsync';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));             
        return this.httpClient.post(url, formUpload);
    }
    ReportCACapBu203ToListAsync() {        
        let url = this.aPIURL + this.controller + '/ReportCACapBu203ToListAsync';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));             
        return this.httpClient.post(url, formUpload);
    }


    Report001Async(doanhNghiepID: number) {
        this.BaseParameter.DoanhNghiepID = doanhNghiepID;      
        let url = this.aPIURL + this.controller + '/Report001Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));             
        return this.httpClient.post(url, formUpload);
    }
    Report002Async(doanhNghiepID: number) {
        this.BaseParameter.DoanhNghiepID = doanhNghiepID;    
        let url = this.aPIURL + this.controller + '/Report002Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));            
        return this.httpClient.post(url, formUpload);
    }
    Report003Async(doanhNghiepID: number) {
        this.BaseParameter.DoanhNghiepID = doanhNghiepID;    
        let url = this.aPIURL + this.controller + '/Report003Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));          
        return this.httpClient.post(url, formUpload);
    }
    Report004Async(huyenID: number, xaID: number, searchString: string) {
        this.BaseParameter.HuyenID = huyenID;
        this.BaseParameter.XaID = xaID;
        this.BaseParameter.SearchString = searchString;
        let url = this.aPIURL + this.controller + '/Report004Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter)); 
        return this.httpClient.post(url, formUpload);
    }
    ReportDoanhNghiep001Async(doanhNghiepID: number, year: number, month: number) {
        this.BaseParameter.DoanhNghiepID = doanhNghiepID;
        this.BaseParameter.Year = year;
        this.BaseParameter.Month = month;
        let url = this.aPIURL + this.controller + '/ReportDoanhNghiep001Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter)); 
        return this.httpClient.post(url, formUpload);
    }
    ReportDoanhNghiep002Async(doanhNghiepID: number, year: number, month: number) {
        this.BaseParameter.DoanhNghiepID = doanhNghiepID;
        this.BaseParameter.Year = year;
        this.BaseParameter.Month = month;
        let url = this.aPIURL + this.controller + '/ReportDoanhNghiep002Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));   
        return this.httpClient.post(url, formUpload);
    }
    ReportDoanhNghiep003Async(doanhNghiepID: number, year: number, month: number) {
        this.BaseParameter.DoanhNghiepID = doanhNghiepID;
        this.BaseParameter.Year = year;
        this.BaseParameter.Month = month;
        let url = this.aPIURL + this.controller + '/ReportDoanhNghiep003Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));   
        return this.httpClient.post(url, formUpload);
    }
    ReportDoanhNghiep004Async(doanhNghiepID: number, year: number, month: number) {
        this.BaseParameter.DoanhNghiepID = doanhNghiepID;
        this.BaseParameter.Year = year;
        this.BaseParameter.Month = month;
        let url = this.aPIURL + this.controller + '/ReportDoanhNghiep004Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));         
        return this.httpClient.post(url, formUpload);
    }
    ReportVNPT001Async(huyenID: number, xaID: number, searchString: string, year: number, month: number) {
        this.BaseParameter.HuyenID = huyenID;
        this.BaseParameter.XaID = xaID;
        this.BaseParameter.SearchString = searchString;
        this.BaseParameter.Year = year;
        this.BaseParameter.Month = month;
        let url = this.aPIURL + this.controller + '/ReportVNPT001Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));   
        return this.httpClient.post(url, formUpload);
    }
    ReportVNPT002Async(huyenID: number, xaID: number, searchString: string, loaiDichVuID: number, year: number, month: number) {
        this.BaseParameter.HuyenID = huyenID;
        this.BaseParameter.XaID = xaID;
        this.BaseParameter.SearchString = searchString;
        this.BaseParameter.LoaiDichVuID = loaiDichVuID;
        this.BaseParameter.Year = year;
        this.BaseParameter.Month = month;
        let url = this.aPIURL + this.controller + '/ReportVNPT002Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));       
        return this.httpClient.post(url, formUpload);
    }
    ReportVNPT003Async(huyenID: number, xaID: number, searchString: string, dichVuID: number, year: number, month: number) {
        this.BaseParameter.HuyenID = huyenID;
        this.BaseParameter.XaID = xaID;
        this.BaseParameter.SearchString = searchString;
        this.BaseParameter.DichVuID = dichVuID;
        this.BaseParameter.Year = year;
        this.BaseParameter.Month = month;
        let url = this.aPIURL + this.controller + '/ReportVNPT003Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter)); 
        return this.httpClient.post(url, formUpload);
    }
    ReportVNPT004Async(phongBanID: number, year: number) {
        this.BaseParameter.PhongBanID = phongBanID;
        this.BaseParameter.Year = year;        
        let url = this.aPIURL + this.controller + '/ReportVNPT004Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));       
        return this.httpClient.post(url, formUpload);
    }
    ReportVNPT005Async(nhanVienID: number, year: number) {
        this.BaseParameter.NhanVienID = nhanVienID;
        this.BaseParameter.Year = year;        
        let url = this.aPIURL + this.controller + '/ReportVNPT005Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));             
        return this.httpClient.post(url, formUpload);
    }
    ReportCA001Async(huyenID: number, year: number, month: number) {
        this.BaseParameter.HuyenID = huyenID;
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;   
        let url = this.aPIURL + this.controller + '/ReportCA001Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));    
        return this.httpClient.post(url, formUpload);
    }
    ReportCA002Async(huyenID: number, year: number, month: number) {
        this.BaseParameter.HuyenID = huyenID;
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;   
        let url = this.aPIURL + this.controller + '/ReportCA002Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));    
        return this.httpClient.post(url, formUpload);
    }
    ReportCA003Async(huyenID: number, year: number, month: number) {
        this.BaseParameter.HuyenID = huyenID;
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;   
        let url = this.aPIURL + this.controller + '/ReportCA003Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA004Async(huyenID: number, year: number, month: number) {
        this.BaseParameter.HuyenID = huyenID;
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;   
        let url = this.aPIURL + this.controller + '/ReportCA004Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA005Async(huyenID: number, year: number, month: number) {
        this.BaseParameter.HuyenID = huyenID;
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;   
        let url = this.aPIURL + this.controller + '/ReportCA005Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA006Async(huyenID: number, year: number, month: number) {
        this.BaseParameter.HuyenID = huyenID;
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;   
        let url = this.aPIURL + this.controller + '/ReportCA006Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA007Async(huyenID: number, year: number, month: number) {
        this.BaseParameter.HuyenID = huyenID;
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;   
        let url = this.aPIURL + this.controller + '/ReportCA007Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA101Async(huyenID: number, year: number, month: number, nhanVienID: number) {
        this.BaseParameter.HuyenID = huyenID;
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;   
        this.BaseParameter.NhanVienID = nhanVienID;   
        let url = this.aPIURL + this.controller + '/ReportCA101Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA102Async(huyenID: number, year: number, month: number, nhanVienID: number) {
        this.BaseParameter.HuyenID = huyenID;
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;   
        this.BaseParameter.NhanVienID = nhanVienID;   
        let url = this.aPIURL + this.controller + '/ReportCA102Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA103Async(huyenID: number, year: number, month: number, nhanVienID: number) {
        this.BaseParameter.HuyenID = huyenID;
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;   
        this.BaseParameter.NhanVienID = nhanVienID; 
        let url = this.aPIURL + this.controller + '/ReportCA103Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA104Async(huyenID: number, year: number, month: number, nhanVienID: number) {
        this.BaseParameter.HuyenID = huyenID;
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;   
        this.BaseParameter.NhanVienID = nhanVienID; 
        let url = this.aPIURL + this.controller + '/ReportCA104Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA105Async(huyenID: number, year: number, month: number, nhanVienID: number, hetHan: number) {
        this.BaseParameter.HuyenID = huyenID;
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;   
        this.BaseParameter.NhanVienID = nhanVienID; 
        this.BaseParameter.HetHan = hetHan; 
        let url = this.aPIURL + this.controller + '/ReportCA105Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA106Async(huyenID: number, year: number, month: number, nhanVienID: number) {
        this.BaseParameter.HuyenID = huyenID;
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;   
        this.BaseParameter.NhanVienID = nhanVienID; 
        let url = this.aPIURL + this.controller + '/ReportCA106Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA107Async(huyenID: number, year: number, month: number, nhanVienID: number) {
        this.BaseParameter.HuyenID = huyenID;
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;   
        this.BaseParameter.NhanVienID = nhanVienID; 
        let url = this.aPIURL + this.controller + '/ReportCA107Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA108Async(huyenID: number, year: number, month: number, nhanVienID: number, isKetLuan: boolean) {
        this.BaseParameter.HuyenID = huyenID;
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;   
        this.BaseParameter.NhanVienID = nhanVienID; 
        this.BaseParameter.IsKetLuan = isKetLuan; 
        let url = this.aPIURL + this.controller + '/ReportCA108Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA201Async(year: number, month: number) {
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;   
        let url = this.aPIURL + this.controller + '/ReportCA201Async';
        const formUpload: FormData = new FormData();                      
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA201_001Async(year: number, month: number, nhanVienID: number) {
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;   
        this.BaseParameter.NhanVienID = nhanVienID; 
        let url = this.aPIURL + this.controller + '/ReportCA201_001Async';
        const formUpload: FormData = new FormData();                      
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA202Async(year: number, month: number) {
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;   
        let url = this.aPIURL + this.controller + '/ReportCA202Async';
        const formUpload: FormData = new FormData();                      
        formUpload.append('data', JSON.stringify(this.BaseParameter));    
        return this.httpClient.post(url, formUpload);
    }
    ReportCA203Async(year: number, month: number) {
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;   
        let url = this.aPIURL + this.controller + '/ReportCA203Async';
        const formUpload: FormData = new FormData();                      
        formUpload.append('data', JSON.stringify(this.BaseParameter));         
        return this.httpClient.post(url, formUpload);
    }
    ReportCA204Async(year: number, month: number) {
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;          
        let url = this.aPIURL + this.controller + '/ReportCA204Async';
        const formUpload: FormData = new FormData();                      
        formUpload.append('data', JSON.stringify(this.BaseParameter));          
        return this.httpClient.post(url, formUpload);
    }
    ReportCA205Async(year: number, month: number) {
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;     
        let url = this.aPIURL + this.controller + '/ReportCA205Async';
        const formUpload: FormData = new FormData();                      
        formUpload.append('data', JSON.stringify(this.BaseParameter));                
        return this.httpClient.post(url, formUpload);
    }
    ReportCA206Async(year: number, month: number) {
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;     
        let url = this.aPIURL + this.controller + '/ReportCA206Async';
        const formUpload: FormData = new FormData();                      
        formUpload.append('data', JSON.stringify(this.BaseParameter));     
        return this.httpClient.post(url, formUpload);
    }
    ReportCA207Async(year: number, month: number) {
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;  
        let url = this.aPIURL + this.controller + '/ReportCA207Async';
        const formUpload: FormData = new FormData();                      
        formUpload.append('data', JSON.stringify(this.BaseParameter));         
        return this.httpClient.post(url, formUpload);
    }
    ReportCA305Async(huyenID: number, year: number, month: number, nhanVienID: number) {
        this.BaseParameter.HuyenID = huyenID; 
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;            
        this.BaseParameter.NhanVienID = nhanVienID;  
        let url = this.aPIURL + this.controller + '/ReportCA305Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA306Async(huyenID: number, year: number, month: number, nhanVienID: number) {
        this.BaseParameter.HuyenID = huyenID; 
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;            
        this.BaseParameter.NhanVienID = nhanVienID; 
        let url = this.aPIURL + this.controller + '/ReportCA306Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA307Async(huyenID: number, year: number, month: number, nhanVienID: number, hetHan: number) {
        this.BaseParameter.HuyenID = huyenID; 
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;            
        this.BaseParameter.NhanVienID = nhanVienID; 
        this.BaseParameter.HetHan = hetHan; 
        let url = this.aPIURL + this.controller + '/ReportCA307Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA308Async(huyenID: number, year: number, month: number, nhanVienID: number) {
        this.BaseParameter.HuyenID = huyenID; 
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;            
        this.BaseParameter.NhanVienID = nhanVienID; 
        let url = this.aPIURL + this.controller + '/ReportCA308Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA401Async(huyenID: number, year: number, month: number, nhanVienID: number, isSmartCA: boolean) {
        this.BaseParameter.HuyenID = huyenID; 
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;            
        this.BaseParameter.NhanVienID = nhanVienID; 
        this.BaseParameter.IsSmartCA = isSmartCA; 
        let url = this.aPIURL + this.controller + '/ReportCA401Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA402Async(huyenID: number, year: number, month: number, nhanVienID: number, isSmartCA: boolean) {
        this.BaseParameter.HuyenID = huyenID; 
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;            
        this.BaseParameter.NhanVienID = nhanVienID; 
        this.BaseParameter.IsSmartCA = isSmartCA; 
        let url = this.aPIURL + this.controller + '/ReportCA402Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA403Async(huyenID: number, year: number, month: number, nhanVienID: number, isSmartCA: boolean) {
        this.BaseParameter.HuyenID = huyenID; 
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;            
        this.BaseParameter.NhanVienID = nhanVienID; 
        this.BaseParameter.IsSmartCA = isSmartCA; 
        let url = this.aPIURL + this.controller + '/ReportCA403Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA404Async(huyenID: number, year: number, month: number, nhanVienID: number, isSmartCA: boolean) {
        this.BaseParameter.HuyenID = huyenID; 
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;            
        this.BaseParameter.NhanVienID = nhanVienID; 
        this.BaseParameter.IsSmartCA = isSmartCA; 
        let url = this.aPIURL + this.controller + '/ReportCA404Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA405Async(huyenID: number, year: number, month: number, nhanVienID: number, hetHan: number, isSmartCA: boolean) {
        this.BaseParameter.HuyenID = huyenID; 
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;            
        this.BaseParameter.NhanVienID = nhanVienID; 
        this.BaseParameter.HetHan = hetHan; 
        this.BaseParameter.IsSmartCA = isSmartCA; 
        let url = this.aPIURL + this.controller + '/ReportCA405Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA406Async(huyenID: number, year: number, month: number, nhanVienID: number, isSmartCA: boolean) {
        this.BaseParameter.HuyenID = huyenID; 
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;            
        this.BaseParameter.NhanVienID = nhanVienID;         
        this.BaseParameter.IsSmartCA = isSmartCA; 
        let url = this.aPIURL + this.controller + '/ReportCA406Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA407Async(huyenID: number, year: number, month: number, nhanVienID: number, isSmartCA: boolean) {
        this.BaseParameter.HuyenID = huyenID; 
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;            
        this.BaseParameter.NhanVienID = nhanVienID;         
        this.BaseParameter.IsSmartCA = isSmartCA; 
        let url = this.aPIURL + this.controller + '/ReportCA407Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA408Async(huyenID: number, year: number, month: number, nhanVienID: number, isKetLuan: boolean, isSmartCA: boolean) {
        this.BaseParameter.HuyenID = huyenID; 
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;            
        this.BaseParameter.NhanVienID = nhanVienID;         
        this.BaseParameter.IsKetLuan = isKetLuan; 
        this.BaseParameter.IsSmartCA = isSmartCA; 
        let url = this.aPIURL + this.controller + '/ReportCA408Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA501Async(year: number, month: number, isSmartCA: boolean) {
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;                    
        this.BaseParameter.IsSmartCA = isSmartCA; 
        let url = this.aPIURL + this.controller + '/ReportCA501Async';
        const formUpload: FormData = new FormData();                      
        formUpload.append('data', JSON.stringify(this.BaseParameter));   
        return this.httpClient.post(url, formUpload);
    }
    ReportCA501_001Async(year: number, month: number, nhanVienID: number, isSmartCA: boolean) {
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;            
        this.BaseParameter.NhanVienID = nhanVienID;                 
        this.BaseParameter.IsSmartCA = isSmartCA; 
        let url = this.aPIURL + this.controller + '/ReportCA501_001Async';
        const formUpload: FormData = new FormData();                      
        formUpload.append('data', JSON.stringify(this.BaseParameter));   
        return this.httpClient.post(url, formUpload);
    }
    ReportCA502Async(year: number, month: number, isSmartCA: boolean) {
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;                                   
        this.BaseParameter.IsSmartCA = isSmartCA; 
        let url = this.aPIURL + this.controller + '/ReportCA502Async';
        const formUpload: FormData = new FormData();                      
        formUpload.append('data', JSON.stringify(this.BaseParameter));     
        return this.httpClient.post(url, formUpload);
    }
    ReportCA503Async(year: number, month: number, isSmartCA: boolean) {
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;                                   
        this.BaseParameter.IsSmartCA = isSmartCA; 
        let url = this.aPIURL + this.controller + '/ReportCA503Async';
        const formUpload: FormData = new FormData();                      
        formUpload.append('data', JSON.stringify(this.BaseParameter));      
        return this.httpClient.post(url, formUpload);
    }
    ReportCA504Async(year: number, month: number, isSmartCA: boolean) {
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;                                   
        this.BaseParameter.IsSmartCA = isSmartCA; 
        let url = this.aPIURL + this.controller + '/ReportCA504Async';
        const formUpload: FormData = new FormData();                      
        formUpload.append('data', JSON.stringify(this.BaseParameter));   
        return this.httpClient.post(url, formUpload);
    }
    ReportCA505Async(year: number, month: number, isSmartCA: boolean) {
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;                                   
        this.BaseParameter.IsSmartCA = isSmartCA; 
        let url = this.aPIURL + this.controller + '/ReportCA505Async';
        const formUpload: FormData = new FormData();                      
        formUpload.append('data', JSON.stringify(this.BaseParameter)); 
        return this.httpClient.post(url, formUpload);
    }
    ReportCA506Async(year: number, month: number, isSmartCA: boolean) {
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;                                   
        this.BaseParameter.IsSmartCA = isSmartCA; 
        let url = this.aPIURL + this.controller + '/ReportCA506Async';
        const formUpload: FormData = new FormData();                      
        formUpload.append('data', JSON.stringify(this.BaseParameter));      
        return this.httpClient.post(url, formUpload);
    }
    ReportCA507Async(year: number, month: number, isSmartCA: boolean) {
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;                                   
        this.BaseParameter.IsSmartCA = isSmartCA; 
        let url = this.aPIURL + this.controller + '/ReportCA507Async';
        const formUpload: FormData = new FormData();                      
        formUpload.append('data', JSON.stringify(this.BaseParameter));     
        return this.httpClient.post(url, formUpload);
    }
    ReportCA605Async(huyenID: number, year: number, month: number, nhanVienID: number, isSmartCA: boolean) {
        this.BaseParameter.HuyenID = huyenID;  
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;             
        this.BaseParameter.NhanVienID = nhanVienID;                            
        this.BaseParameter.IsSmartCA = isSmartCA; 
        let url = this.aPIURL + this.controller + '/ReportCA605Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA606Async(huyenID: number, year: number, month: number, nhanVienID: number, isSmartCA: boolean) {
        this.BaseParameter.HuyenID = huyenID;  
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;             
        this.BaseParameter.NhanVienID = nhanVienID;                            
        this.BaseParameter.IsSmartCA = isSmartCA; 
        let url = this.aPIURL + this.controller + '/ReportCA606Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA607Async(huyenID: number, year: number, month: number, nhanVienID: number, hetHan: number, isSmartCA: boolean) {
        this.BaseParameter.HuyenID = huyenID;  
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;             
        this.BaseParameter.NhanVienID = nhanVienID;      
        this.BaseParameter.HetHan = hetHan;                      
        this.BaseParameter.IsSmartCA = isSmartCA; 
        let url = this.aPIURL + this.controller + '/ReportCA607Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA608Async(huyenID: number, year: number, month: number, nhanVienID: number, isSmartCA: boolean) {
        this.BaseParameter.HuyenID = huyenID;  
        this.BaseParameter.Year = year;    
        this.BaseParameter.Month = month;             
        this.BaseParameter.NhanVienID = nhanVienID;                             
        this.BaseParameter.IsSmartCA = isSmartCA; 
        let url = this.aPIURL + this.controller + '/ReportCA608Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCASearchStringToListAsync(searchString: string) {
        this.BaseParameter.SearchString = searchString; 
        let url = this.aPIURL + this.controller + '/ReportCASearchStringToListAsync';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));        
        return this.httpClient.post(url, formUpload);
    }
    ReportVNPT1001ToListAsync() {
        let url = this.aPIURL + this.controller + '/ReportVNPT1001ToListAsync';
        const formUpload: FormData = new FormData();       
        formUpload.append('data', JSON.stringify(this.BaseParameter));             
        return this.httpClient.post(url, formUpload);
    }
    ReportVNPT1002ToListAsync() {
        let url = this.aPIURL + this.controller + '/ReportVNPT1002ToListAsync';
        const formUpload: FormData = new FormData();   
        formUpload.append('data', JSON.stringify(this.BaseParameter));                 
        return this.httpClient.post(url, formUpload);
    }
}




