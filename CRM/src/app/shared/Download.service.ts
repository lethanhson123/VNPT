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
}

