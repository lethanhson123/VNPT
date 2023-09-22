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
    PostDoanhNghiepListByExcelFile(fileToUpload: File) {
        let url = this.aPIURL + this.controller + '/PostDoanhNghiepListByExcelFile';
        const formUpload: FormData = new FormData();
        formUpload.append('file', fileToUpload, fileToUpload.name);
        return this.httpClient.post(url, formUpload);
      }
}

