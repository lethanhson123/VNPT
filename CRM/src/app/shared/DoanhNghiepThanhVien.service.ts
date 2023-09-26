import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './Base.service';
import { DoanhNghiepThanhVien } from './DoanhNghiepThanhVien.model';
@Injectable({
    providedIn: 'root'
})
export class DoanhNghiepThanhVienService extends BaseService{
    displayColumns: string[] = ['LoaiDoanhNghiepThanhVienID','Name','DienThoai','Email','NgaySinh','CCCD','CCCD_NgayCap','CCCD_NoiCap', 'Note', 'SortOrder', 'Active', 'Save']; 
    list: DoanhNghiepThanhVien[] | undefined;        
    formData!: DoanhNghiepThanhVien;
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "DoanhNghiepThanhVien";
    }    
}




