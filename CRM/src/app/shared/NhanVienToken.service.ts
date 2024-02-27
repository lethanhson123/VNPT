import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BaseService } from './Base.service';
import { NhanVienToken } from './NhanVienToken.model';
import { environment } from 'src/environments/environment';
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
        formData.Description = environment.TokenAPI;
        let url = this.aPIURL + this.controller + '/AuthenticationAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(formData));
        return this.httpClient.post(url, formUpload);
    }
    GetByTokenAsync(token: string) {
        this.BaseParameter.Code = token;
        let url = this.aPIURL + this.controller + '/GetByTokenAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
}




