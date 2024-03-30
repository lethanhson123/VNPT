import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class XaService extends BaseService {
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.Controller = "Xa";
    }
    
    GetSQLByNhanVienID_ActiveAsync() {
        this.BaseParameter.NhanVienID = Number(localStorage.getItem(environment.NhanVienID));
        this.BaseParameter.Active = true;
        let url = this.APIURL + this.Controller + '/GetSQLByNhanVienID_ActiveAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
}




