import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './Base.service';
import { GoiCuoc } from './GoiCuoc.model';
@Injectable({
    providedIn: 'root'
})
export class GoiCuocService extends BaseService{    
    displayColumns: string[] = ['No', 'Name','Description', 'Note', 'Thang','ThangKhuyenMai','GiaCuoc', 'IsSmartCA', 'Active', 'Save']; 
    list: GoiCuoc[] | undefined;
    formData!: GoiCuoc; 
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "GoiCuoc";
    }    
}




