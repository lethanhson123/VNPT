import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
@Injectable({
    providedIn: 'root'
})
export class UploadService {
    aPIURL: string = environment.APIUploadURL;
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
    PostGoiCuocListByExcelFileAsync(fileToUpload: File) {
        let url = this.aPIURL + this.controller + '/PostGoiCuocListByExcelFileAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('file', fileToUpload, fileToUpload.name);
        return this.httpClient.post(url, formUpload);
    }
    PostCA20ListByExcelFileAsync(fileToUpload: File) {
        let url = this.aPIURL + this.controller + '/PostCA20ListByExcelFileAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('file', fileToUpload, fileToUpload.name);
        return this.httpClient.post(url, formUpload);
    }
    PostCACapBuByExcelFileAsync(fileToUpload: File) {
        let url = this.aPIURL + this.controller + '/PostCACapBuByExcelFileAsync';
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
    PostDoanhThuByYearAndMonthListByExcelFile(fileToUpload: File, year: number, month: number) {
        let url = this.aPIURL + this.controller + '/PostDoanhThuByYearAndMonthListByExcelFile';
        const formUpload: FormData = new FormData();
        formUpload.append('file', fileToUpload, fileToUpload.name);
        formUpload.append('year', JSON.stringify(year));
        formUpload.append('month', JSON.stringify(month));
        return this.httpClient.post(url, formUpload);
    }
    PostDoanhThuByYearAndMonthList2023ByExcelFileAsync(fileToUpload: File, year: number, month: number) {
        let url = this.aPIURL + this.controller + '/PostDoanhThuByYearAndMonthList2023ByExcelFileAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('file', fileToUpload, fileToUpload.name);
        formUpload.append('year', JSON.stringify(year));
        formUpload.append('month', JSON.stringify(month));
        return this.httpClient.post(url, formUpload);
    }
    PostDoanhNghiepDichVuCAByExcelFileAsync(fileToUpload: File) {
        let url = this.aPIURL + this.controller + '/PostDoanhNghiepDichVuCAByExcelFileAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('file', fileToUpload, fileToUpload.name);        
        return this.httpClient.post(url, formUpload);
    }
    PostDoanhNghiepDichVuCASoChungThuByExcelFileAsync(fileToUpload: File) {
        let url = this.aPIURL + this.controller + '/PostDoanhNghiepDichVuCASoChungThuByExcelFileAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('file', fileToUpload, fileToUpload.name);        
        return this.httpClient.post(url, formUpload);
    }
}

