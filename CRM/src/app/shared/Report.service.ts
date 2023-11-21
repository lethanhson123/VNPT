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
    displayColumnsReportCA006: string[] = ['No', 'HuyenName', 'DoanhNghiepName']; 
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
    listReportCA001: Report[] | undefined;
    listReportCA002: Report[] | undefined;
    listReportCA003: Report[] | undefined;
    listReportCA004: Report[] | undefined;
    listReportCA005: Report[] | undefined;
    listReportCA006: Report[] | undefined;
    listReportCA007: DoanhNghiep[] | undefined;
    listReportCA008: DoanhNghiep[] | undefined;    
    formData!: Report;
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "Report";
    }    
    Report001Async(doanhNghiepID: number) {
        let url = this.aPIURL + this.controller + '/Report001Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('doanhNghiepID', JSON.stringify(doanhNghiepID));          
        return this.httpClient.post(url, formUpload);
    }
    Report002Async(doanhNghiepID: number) {
        let url = this.aPIURL + this.controller + '/Report002Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('doanhNghiepID', JSON.stringify(doanhNghiepID));          
        return this.httpClient.post(url, formUpload);
    }
    Report003Async(doanhNghiepID: number) {
        let url = this.aPIURL + this.controller + '/Report003Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('doanhNghiepID', JSON.stringify(doanhNghiepID));          
        return this.httpClient.post(url, formUpload);
    }
    Report004Async(huyenID: number, xaID: number, searchString: string) {
        let url = this.aPIURL + this.controller + '/Report004Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('huyenID', JSON.stringify(huyenID));          
        formUpload.append('xaID', JSON.stringify(xaID)); 
        formUpload.append('searchString', JSON.stringify(searchString)); 
        return this.httpClient.post(url, formUpload);
    }
    ReportDoanhNghiep001Async(doanhNghiepID: number, year: number, month: number) {
        let url = this.aPIURL + this.controller + '/ReportDoanhNghiep001Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('doanhNghiepID', JSON.stringify(doanhNghiepID));          
        formUpload.append('year', JSON.stringify(year));
        formUpload.append('month', JSON.stringify(month));
        return this.httpClient.post(url, formUpload);
    }
    ReportDoanhNghiep002Async(doanhNghiepID: number, year: number, month: number) {
        let url = this.aPIURL + this.controller + '/ReportDoanhNghiep002Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('doanhNghiepID', JSON.stringify(doanhNghiepID)); 
        formUpload.append('year', JSON.stringify(year));
        formUpload.append('month', JSON.stringify(month));         
        return this.httpClient.post(url, formUpload);
    }
    ReportDoanhNghiep003Async(doanhNghiepID: number, year: number, month: number) {
        let url = this.aPIURL + this.controller + '/ReportDoanhNghiep003Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('doanhNghiepID', JSON.stringify(doanhNghiepID));  
        formUpload.append('year', JSON.stringify(year));
        formUpload.append('month', JSON.stringify(month));        
        return this.httpClient.post(url, formUpload);
    }
    ReportDoanhNghiep004Async(doanhNghiepID: number, year: number, month: number) {
        let url = this.aPIURL + this.controller + '/ReportDoanhNghiep004Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('doanhNghiepID', JSON.stringify(doanhNghiepID));  
        formUpload.append('year', JSON.stringify(year));
        formUpload.append('month', JSON.stringify(month));        
        return this.httpClient.post(url, formUpload);
    }
    ReportVNPT001Async(huyenID: number, xaID: number, searchString: string, year: number, month: number) {
        let url = this.aPIURL + this.controller + '/ReportVNPT001Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('huyenID', JSON.stringify(huyenID));          
        formUpload.append('xaID', JSON.stringify(xaID)); 
        formUpload.append('searchString', JSON.stringify(searchString));
        formUpload.append('year', JSON.stringify(year));
        formUpload.append('month', JSON.stringify(month));      
        return this.httpClient.post(url, formUpload);
    }
    ReportVNPT002Async(huyenID: number, xaID: number, searchString: string, loaiDichVuID: number, year: number, month: number) {
        let url = this.aPIURL + this.controller + '/ReportVNPT002Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('huyenID', JSON.stringify(huyenID));          
        formUpload.append('xaID', JSON.stringify(xaID)); 
        formUpload.append('searchString', JSON.stringify(searchString));
        formUpload.append('loaiDichVuID', JSON.stringify(loaiDichVuID));
        formUpload.append('year', JSON.stringify(year));
        formUpload.append('month', JSON.stringify(month));      
        return this.httpClient.post(url, formUpload);
    }
    ReportVNPT003Async(huyenID: number, xaID: number, searchString: string, dichVuID: number, year: number, month: number) {
        let url = this.aPIURL + this.controller + '/ReportVNPT003Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('huyenID', JSON.stringify(huyenID));          
        formUpload.append('xaID', JSON.stringify(xaID)); 
        formUpload.append('searchString', JSON.stringify(searchString));
        formUpload.append('dichVuID', JSON.stringify(dichVuID));
        formUpload.append('year', JSON.stringify(year));
        formUpload.append('month', JSON.stringify(month));      
        return this.httpClient.post(url, formUpload);
    }
    ReportVNPT004Async(phongBanID: number, year: number) {
        let url = this.aPIURL + this.controller + '/ReportVNPT004Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('phongBanID', JSON.stringify(phongBanID));        
        formUpload.append('year', JSON.stringify(year));         
        return this.httpClient.post(url, formUpload);
    }
    ReportVNPT005Async(nhanVienID: number, year: number) {
        let url = this.aPIURL + this.controller + '/ReportVNPT005Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('nhanVienID', JSON.stringify(nhanVienID));        
        formUpload.append('year', JSON.stringify(year));         
        return this.httpClient.post(url, formUpload);
    }
    ReportCA001Async(huyenID: number, year: number, month: number) {
        let url = this.aPIURL + this.controller + '/ReportCA001Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('huyenID', JSON.stringify(huyenID));        
        formUpload.append('year', JSON.stringify(year));         
        formUpload.append('month', JSON.stringify(month));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA002Async(huyenID: number, year: number, month: number) {
        let url = this.aPIURL + this.controller + '/ReportCA002Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('huyenID', JSON.stringify(huyenID));        
        formUpload.append('year', JSON.stringify(year));         
        formUpload.append('month', JSON.stringify(month));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA003Async(huyenID: number, year: number, month: number) {
        let url = this.aPIURL + this.controller + '/ReportCA003Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('huyenID', JSON.stringify(huyenID));        
        formUpload.append('year', JSON.stringify(year));         
        formUpload.append('month', JSON.stringify(month));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA004Async(huyenID: number, year: number, month: number) {
        let url = this.aPIURL + this.controller + '/ReportCA004Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('huyenID', JSON.stringify(huyenID));        
        formUpload.append('year', JSON.stringify(year));         
        formUpload.append('month', JSON.stringify(month));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA005Async(huyenID: number, year: number, month: number) {
        let url = this.aPIURL + this.controller + '/ReportCA005Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('huyenID', JSON.stringify(huyenID));        
        formUpload.append('year', JSON.stringify(year));         
        formUpload.append('month', JSON.stringify(month));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA006Async(huyenID: number, year: number, month: number) {
        let url = this.aPIURL + this.controller + '/ReportCA006Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('huyenID', JSON.stringify(huyenID));        
        formUpload.append('year', JSON.stringify(year));         
        formUpload.append('month', JSON.stringify(month));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA007Async(huyenID: number, year: number, month: number) {
        let url = this.aPIURL + this.controller + '/ReportCA007Async';
        const formUpload: FormData = new FormData();        
        formUpload.append('huyenID', JSON.stringify(huyenID));        
        formUpload.append('year', JSON.stringify(year));         
        formUpload.append('month', JSON.stringify(month));
        return this.httpClient.post(url, formUpload);
    }
}




