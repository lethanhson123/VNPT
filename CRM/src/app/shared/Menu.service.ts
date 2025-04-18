import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { BaseService } from './Base.service';
import { Menu } from './Menu.model';
@Injectable({
    providedIn: 'root'
})
export class MenuService extends BaseService {
    displayColumns: string[] = ['No', 'ID', 'ParentID', 'Name', 'Display', 'Note', 'SortOrder', 'Active', 'Save'];

    List001: Menu[] | undefined;
    ListChild: Menu[] | undefined;
    ListParent: Menu[] | undefined;

    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "Menu";
    }
    GetByNhanVienIDToListAsync() {
        var nhanVienID = localStorage.getItem(environment.NhanVienID);
        if (nhanVienID) {
            this.BaseParameter.NhanVienID = Number(nhanVienID);     
            let url = this.aPIURL + this.controller + '/GetByNhanVienIDToListAsync';
            const formUpload: FormData = new FormData();
            formUpload.append('data', JSON.stringify(this.BaseParameter));    
            return this.httpClient.post(url, formUpload);
        }
    }
}




