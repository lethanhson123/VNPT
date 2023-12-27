import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './Base.service';
import { NhanVienMenu } from './NhanVienMenu.model';
@Injectable({
    providedIn: 'root'
})
export class NhanVienMenuService extends BaseService{
    displayColumns: string[] = ['ParentID', 'Code', 'Name', 'Note', 'SortOrder', 'Active', 'Save']; 
    list: NhanVienMenu[] | undefined;
    formData!: NhanVienMenu;
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "NhanVienMenu";
    }    
}




