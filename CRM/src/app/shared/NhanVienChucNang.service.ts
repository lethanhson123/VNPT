import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './Base.service';
import { NhanVienChucNang } from './NhanVienChucNang.model';
@Injectable({
    providedIn: 'root'
})
export class NhanVienChucNangService extends BaseService {       
    
    displayColumns: string[] = ['HuyenID', 'XaID', 'Active']; 
    list: NhanVienChucNang[] | undefined;
    formData!: NhanVienChucNang;

    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "NhanVienChucNang";
    }
}




