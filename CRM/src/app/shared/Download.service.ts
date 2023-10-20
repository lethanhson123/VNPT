import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { YearMonth } from './YearMonth.model';
@Injectable({
    providedIn: 'root'
})
export class DownloadService {
    listYear: YearMonth[] | undefined;
    listMonth: YearMonth[] | undefined;
    aPIURL: string = environment.APIURL;
    controller: string = "Download";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
    }
    GetRandomColor(count) {
        var arr = [];
        for (var i = 0; i < count; i++) {
            var letters = '0123456789ABCDEF'.split('');
            var color = '#';
            for (var x = 0; x < 6; x++) {
                color += letters[Math.floor(Math.random() * 16)];
            }
        }
        return color;
    }
    GetMonthToList() {
        let url = this.aPIURL + this.controller + '/GetMonthToList';
        return this.httpClient.get(url).toPromise();
    }
    GetYearToList() {
        let url = this.aPIURL + this.controller + '/GetYearToList';
        return this.httpClient.get(url).toPromise();
    }
    Report0004ToExcelAsync(huyenID: number, xaID: number, searchString: string) {
        let url = this.aPIURL + this.controller + '/Report0004ToExcelAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('huyenID', JSON.stringify(huyenID));
        formUpload.append('xaID', JSON.stringify(xaID));
        formUpload.append('searchString', JSON.stringify(searchString));
        return this.httpClient.post(url, formUpload);
    }
    ReportVNPT001ToExcelAsync(huyenID: number, xaID: number, searchString: string, year: number, month: number) {
        let url = this.aPIURL + this.controller + '/ReportVNPT001ToExcelAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('huyenID', JSON.stringify(huyenID));
        formUpload.append('xaID', JSON.stringify(xaID));
        formUpload.append('searchString', JSON.stringify(searchString));
        formUpload.append('year', JSON.stringify(year));
        formUpload.append('month', JSON.stringify(month));  
        return this.httpClient.post(url, formUpload);
    }
    ReportVNPT003ToExcelAsync(huyenID: number, xaID: number, searchString: string, dichVuID: number, year: number, month: number) {
        let url = this.aPIURL + this.controller + '/ReportVNPT003ToExcelAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('huyenID', JSON.stringify(huyenID));
        formUpload.append('xaID', JSON.stringify(xaID));
        formUpload.append('searchString', JSON.stringify(searchString));
        formUpload.append('dichVuID', JSON.stringify(dichVuID));
        formUpload.append('year', JSON.stringify(year));
        formUpload.append('month', JSON.stringify(month));  
        return this.httpClient.post(url, formUpload);
    }
    ReportVNPT004ToExcelAsync(phongBanID: number, year: number) {
        let url = this.aPIURL + this.controller + '/ReportVNPT004ToExcelAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('phongBanID', JSON.stringify(phongBanID));        
        formUpload.append('year', JSON.stringify(year));        
        return this.httpClient.post(url, formUpload);
    }
    ReportVNPT005ToExcelAsync(nhanVienID: number, year: number) {
        let url = this.aPIURL + this.controller + '/ReportVNPT005ToExcelAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('nhanVienID', JSON.stringify(nhanVienID));        
        formUpload.append('year', JSON.stringify(year));        
        return this.httpClient.post(url, formUpload);
    }
}

