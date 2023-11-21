import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class NhanVienTaiKhoanService extends BaseService{  
    displayColumns: string[] = ['No', 'ParentID', 'Code', 'Note', 'SortOrder', 'Active', 'Save'];    
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "NhanVienTaiKhoan";
    }    
}




