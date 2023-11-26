import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BaseService } from './Base.service';
import { NhanVienToken } from './NhanVienToken.model';
@Injectable({
    providedIn: 'root'
})
export class NhanVienTokenService extends BaseService {   
    list: NhanVienToken[] | undefined;
    formData!: NhanVienToken;
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "NhanVienToken";
    }
    AuthenticationAsync(formData: NhanVienToken) {
        let url = this.aPIURL + this.controller + '/AuthenticationAsync';
        const formUpload: FormData = new FormData();       
        formUpload.append('data', JSON.stringify(formData));       
        return this.httpClient.post(url, formUpload);
    }
    GetByTokenAsync(token: string) {
        let url = this.aPIURL + this.controller + '/GetByTokenAsync';
        const formUpload: FormData = new FormData();       
        formUpload.append('token', JSON.stringify(token));       
        return this.httpClient.post(url, formUpload);
    }
}




