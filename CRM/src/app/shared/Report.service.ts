import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './Base.service';
import { Report } from './Report.model';
@Injectable({
    providedIn: 'root'
})
export class ReportService extends BaseService{
    displayColumnsReport001: string[] = ['DichVu', 'MaThueBao', 'DoanhThu', 'DoanhThuLast', 'ChenhLech']; 
    displayColumnsReport004: string[] = ['Name', 'HuyenName', 'XaName', 'DoanhThu01', 'ChenhLech01', 'DoanhThu03', 'ChenhLech02', 'DoanhThu05', 'ChenhLech03', 'DoanhThu07', 'ChenhLech04', 'DoanhThu09', 'ChenhLech05', 'DoanhThu11', 'ChenhLech06', 'DoanhThu13', 'ChenhLech07']; 
    listReport001: Report[] | undefined;        
    listReport002: Report[] | undefined;        
    listReport003: Report[] | undefined;        
    listReport004: Report[] | undefined;        
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
}




