import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { BaseService } from './Base.service';
import { Menu } from './Menu.model';
@Injectable({
    providedIn: 'root'
})
export class MenuService extends BaseService {
    displayColumns: string[] = ['ParentID', 'Code', 'Name', 'Note', 'SortOrder', 'Active', 'Save'];
    listLogin: Menu[] | undefined;  
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "Menu";
    }
    GetByNhanVienIDToListAsync() {
        var nhanVienID = localStorage.getItem(environment.NhanVienID);        
        if (nhanVienID) {
            let url = this.aPIURL + this.controller + '/GetByNhanVienIDToListAsync';
            const formUpload: FormData = new FormData();
            formUpload.append('data', JSON.stringify(Number(nhanVienID)));
            return this.httpClient.post(url, formUpload);
        }
    }
}




