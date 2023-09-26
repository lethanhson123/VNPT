import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './Base.service';
import { DoanhNghiepDichVuLichSu } from './DoanhNghiepDichVuLichSu.model';
@Injectable({
    providedIn: 'root'
})
export class DoanhNghiepDichVuLichSuService extends BaseService{
    displayColumns: string[] = ['GiaTien','Note', 'SortOrder', 'Active', 'Save']; 
    list: DoanhNghiepDichVuLichSu[] | undefined;        
    formData!: DoanhNghiepDichVuLichSu;
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "DoanhNghiepDichVuLichSu";
    }    
}




