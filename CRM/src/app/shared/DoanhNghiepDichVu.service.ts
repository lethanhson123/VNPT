import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './Base.service';
import { DoanhNghiepDichVu } from './DoanhNghiepDichVu.model';
@Injectable({
    providedIn: 'root'
})
export class DoanhNghiepDichVuService extends BaseService{
    displayColumns: string[] = ['NhanVienID','DichVuID','NgayKyHopDong', 'Code', 'MaThueBao', 'GiaTien', 'SoThang', 'Note', 'SortOrder', 'Active', 'Save']; 
    list: DoanhNghiepDichVu[] | undefined;        
    formData!: DoanhNghiepDichVu;
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "DoanhNghiepDichVu";
    }    
}




