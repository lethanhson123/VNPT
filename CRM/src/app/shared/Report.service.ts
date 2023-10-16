import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './Base.service';
import { Report } from './Report.model';
@Injectable({
    providedIn: 'root'
})
export class ReportService extends BaseService{
    displayColumnsReport001: string[] = ['DichVu', 'MaThueBao', 'DoanhThu', 'DoanhThuLast', 'ChenhLech']; 
    displayColumnsReportVNPT001: string[] = ['Name', 'HuyenName', 'XaName', 'DoanhThu01', 'ChenhLech01', 'DoanhThu03', 'ChenhLech02', 'DoanhThu05', 'ChenhLech03', 'DoanhThu07', 'ChenhLech04', 'DoanhThu09', 'ChenhLech05', 'DoanhThu11', 'ChenhLech06', 'DoanhThu13', 'ChenhLech07']; 
    displayColumnsReportVNPT003: string[] = ['Name', 'HuyenName', 'XaName', 'DoanhThu', 'DoanhThu01', 'DoanhThu02', 'DoanhThu03', 'DoanhThu04', 'DoanhThu05', 'DoanhThu06', 'DoanhThu07', 'DoanhThu08', 'DoanhThu09', 'DoanhThu10', 'DoanhThu11', 'DoanhThu12']; 
    listReport001: Report[] | undefined;        
    listReport002: Report[] | undefined;        
    listReport003: Report[] | undefined;        
    listReport004: Report[] | undefined;        
    listReportVNPT001: Report[] | undefined;
    listReportVNPT003: Report[] | undefined;
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
}




