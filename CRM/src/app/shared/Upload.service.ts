import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
@Injectable({
    providedIn: 'root'
})
export class UploadService {
    aPIURL: string = environment.APIURL;
    controller: string = "Upload";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
    }
    PostDoanhNghiepListByExcelFileAsync(fileToUpload: File) {
        let url = this.aPIURL + this.controller + '/PostDoanhNghiepListByExcelFileAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('file', fileToUpload, fileToUpload.name);
        return this.httpClient.post(url, formUpload);
    }
    PostDoanhThuByYearAndMonthListByExcelFileAsync(fileToUpload: File, year: number, month: number) {
        let url = this.aPIURL + this.controller + '/PostDoanhThuByYearAndMonthListByExcelFileAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('file', fileToUpload, fileToUpload.name);
        formUpload.append('year', JSON.stringify(year));
        formUpload.append('month', JSON.stringify(month));
        return this.httpClient.post(url, formUpload);
    }
}

