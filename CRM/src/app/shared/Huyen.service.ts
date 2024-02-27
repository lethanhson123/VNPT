import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class HuyenService extends BaseService {
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "Huyen";
        this.displayColumns = ['ParentID', 'Name', 'Note', 'SortOrder', 'Active', 'Save'];
    }
    GetSQLByNhanVienID_ActiveAsync() {
        var lastUpdatedMembershipID = localStorage.getItem(environment.NhanVienID);
        if (lastUpdatedMembershipID) {
            this.BaseParameter.NhanVienID = Number(lastUpdatedMembershipID);      
            this.BaseParameter.Active = true;      
            let url = this.aPIURL + this.controller + '/GetSQLByNhanVienID_ActiveAsync';
            const formUpload: FormData = new FormData();
            formUpload.append('data', JSON.stringify(this.BaseParameter));    
            return this.httpClient.post(url, formUpload);
        }
    }
}




