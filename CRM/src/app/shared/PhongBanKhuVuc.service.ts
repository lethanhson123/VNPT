import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './Base.service';
import { PhongBanKhuVuc } from './PhongBanKhuVuc.model';
@Injectable({
    providedIn: 'root'
})
export class PhongBanKhuVucService extends BaseService{
    displayColumns: string[] = ['ParentID', 'HuyenID', 'XaID', 'Active']; 
    list: PhongBanKhuVuc[] | undefined;
    formData!: PhongBanKhuVuc;
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "PhongBanKhuVuc";
    }    
    GetSQLByParentIDAsync(parentID: number) {
        let url = this.aPIURL + this.controller + '/GetSQLByParentIDAsync';
        const formUpload: FormData = new FormData();        
        formUpload.append('parentID', JSON.stringify(parentID));                      
        return this.httpClient.post(url, formUpload);
    }
}




