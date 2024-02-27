import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './Base.service';
import { NhanVienKhuVuc } from './NhanVienKhuVuc.model';
@Injectable({
    providedIn: 'root'
})
export class NhanVienKhuVucService extends BaseService{
    displayColumns: string[] = ['HuyenID', 'XaID', 'Active']; 
    list: NhanVienKhuVuc[] | undefined;
    formData!: NhanVienKhuVuc;
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "NhanVienKhuVuc";
    }    
    GetSQLByParentIDAsync(parentID: number) {
        this.BaseParameter.ParentID = parentID;
        let url = this.aPIURL + this.controller + '/GetSQLByParentIDAsync';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));                    
        return this.httpClient.post(url, formUpload);
    }
}




