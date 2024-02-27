import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class PhongBanService extends BaseService{
    displayColumns: string[] = ['Code', 'Name', 'Note', 'SortOrder', 'Active'];
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "PhongBan";
    }    
    GetByIDStringAsync(ID: string) {
        this.BaseParameter.IDString = ID;
        let url = this.aPIURL + this.controller + '/GetByIDStringAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
}




